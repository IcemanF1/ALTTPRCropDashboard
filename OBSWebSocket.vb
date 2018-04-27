Imports System
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Text
Imports WebSocketSharp
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks

Namespace OBSWebsocketDotNet

    Public Class OBSWebSocket

        Public Event SceneChanged As SceneChangeCallback

        Public Event SceneListChanged As EventHandler

        Public Event SourceOrderChanged As SourceOrderChangeCallback

        Public Event SceneItemAdded As SceneItemUpdateCallback

        Public Event SceneItemRemoved As SceneItemUpdateCallback

        Public Event SceneItemVisibilityChanged As SceneItemUpdateCallback

        Public Event SceneCollectionChanged As EventHandler

        Public Event SceneCollectionListChanged As EventHandler

        Public Event TransitionChanged As TransitionChangeCallback

        Public Event TransitionDurationChanged As TransitionDurationChangeCallback

        Public Event TransitionListChanged As EventHandler

        Public Event TransitionBegin As EventHandler

        Public Event ProfileChanged As EventHandler

        Public Event ProfileListChanged As EventHandler

        Public Event StreamingStateChanged As OutputStateCallback

        Public Event RecordingStateChanged As OutputStateCallback

        Public Event ReplayBufferStateChanged As OutputStateCallback

        Public Event StreamStatus As StreamStatusCallback

        Public Event PreviewSceneChanged As SceneChangeCallback

        Public Event StudioModeSwitched As StudioModeChangeCallback

        Public Event OBSExit As EventHandler

        Public Event Connected As EventHandler

        Public Event Disconnected As EventHandler

        Public Property WSTimeout As TimeSpan
            Get
                If WSConnection IsNot Nothing Then Return WSConnection.WaitTime Else Return _pWSTimeout
            End Get

            Set(ByVal value As TimeSpan)
                _pWSTimeout = value
                If WSConnection IsNot Nothing Then WSConnection.WaitTime = _pWSTimeout
            End Set
        End Property

        Private _pWSTimeout As TimeSpan

        Public Function IsConnected() As Boolean
            'Get
            Return (If(WSConnection IsNot Nothing, WSConnection.IsAlive, False))
            'End Get
        End Function

        Public Property WSConnection As WebSocket

        Private Delegate Sub RequestCallback(ByVal sender As OBSWebsocket, ByVal body As JObject)

        Private _responseHandlers As Dictionary(Of String, TaskCompletionSource(Of JObject))

        Public Sub New()
            _responseHandlers = New Dictionary(Of String, TaskCompletionSource(Of JObject))()
        End Sub

        Public Sub Connect(ByVal url As String, ByVal password As String)
            'If WSConnection IsNot Nothing AndAlso WSConnection.IsAlive Then Disconnect()
            WSConnection = New WebSocket(url)
            WSConnection.WaitTime = _pWSTimeout
            'WSConnection.OnMessage += AddressOf WebsocketMessageHandler
            'WSConnection.OnClose += Function(s, e)
            '                            RaiseEvent Disconnected(Me, e)
            '                        End Function
            WSConnection.Connect()
            Dim authInfo As OBSAuthInfo = GetAuthInfo()
            If authInfo.AuthRequired Then Authenticate(password, authInfo)
            RaiseEvent Connected(Me, Nothing)
        End Sub

        Public Sub Disconnect()
            If WSConnection IsNot Nothing Then WSConnection.Close()
            WSConnection = Nothing
            For Each cb In _responseHandlers
                Dim tcs = cb.Value
                tcs.TrySetCanceled()
            Next
        End Sub

        Private Sub WebsocketMessageHandler(ByVal sender As Object, ByVal e As MessageEventArgs)
            If Not e.Data.ToString Then Return
            Dim body As JObject = JObject.Parse(e.Data.ToString)
            If body("message-id") IsNot Nothing Then
                Dim msgID As String = CStr(body("message-id"))
                Dim handler = _responseHandlers(msgID)
                If handler IsNot Nothing Then
                    handler.SetResult(body)
                    _responseHandlers.Remove(msgID)
                End If
            ElseIf body("update-type") IsNot Nothing Then
                Dim eventType As String = body("update-type").ToString()
                ProcessEventType(eventType, body)
            End If
        End Sub

        Public Function SendRequest(ByVal requestType As String, ByVal Optional additionalFields As JObject = Nothing) As JObject
            Dim messageID As String
            Do
                messageID = NewMessageID()
            Loop While _responseHandlers.ContainsKey(messageID)

            Dim body = New JObject()
            body.Add("request-type", requestType)
            body.Add("message-id", messageID)
            If additionalFields IsNot Nothing Then
                Dim mergeSettings = New JsonMergeSettings With {.MergeArrayHandling = MergeArrayHandling.Union}
                body.Merge(additionalFields)
            End If

            Dim tcs = New TaskCompletionSource(Of JObject)()
            _responseHandlers.Add(messageID, tcs)
            WSConnection.Send(body.ToString())
            tcs.Task.Wait()
            If tcs.Task.IsCanceled Then Throw New ErrorResponseException("Request canceled")
            Dim result = tcs.Task.Result
            If CStr(result("status")) = "error" Then Throw New ErrorResponseException(CStr(result("error")))
            Return result
        End Function

        Public Function GetVersion() As OBSVersion
            Dim response As JObject = SendRequest("GetVersion")
            Return New OBSVersion(response)
        End Function

        Public Function GetAuthInfo() As OBSAuthInfo
            Dim response As JObject = SendRequest("GetAuthRequired")
            Return New OBSAuthInfo(response)
        End Function

        Public Function Authenticate(ByVal password As String, ByVal authInfo As OBSAuthInfo) As Boolean
            Dim secret As String = HashEncode(password & authInfo.PasswordSalt)
            Dim authResponse As String = HashEncode(secret & authInfo.Challenge)
            Dim requestFields = New JObject()
            requestFields.Add("auth", authResponse)
            Try
                SendRequest("Authenticate", requestFields)
            Catch __unusedErrorResponseException1__ As ErrorResponseException
                Throw New AuthFailureException()
            End Try

            Return True
        End Function

        Protected Sub ProcessEventType(ByVal eventType As String, ByVal body As JObject)
            Dim status As StreamStatus
            Select Case eventType
                Case "SwitchScenes"
                    RaiseEvent SceneChanged(Me, CStr(body("scene-name")))
                Case "ScenesChanged"
                    RaiseEvent SceneListChanged(Me, EventArgs.Empty)
                Case "SourceOrderChanged"
                    RaiseEvent SourceOrderChanged(Me, CStr(body("scene-name")))
                Case "SceneItemAdded"
                    RaiseEvent SceneItemAdded(Me, CStr(body("scene-name")), CStr(body("item-name")))
                Case "SceneItemRemoved"
                    RaiseEvent SceneItemRemoved(Me, CStr(body("scene-name")), CStr(body("item-name")))
                Case "SceneItemVisibilityChanged"
                    RaiseEvent SceneItemVisibilityChanged(Me, CStr(body("scene-name")), CStr(body("item-name")))
                Case "SceneCollectionChanged"
                    RaiseEvent SceneCollectionChanged(Me, EventArgs.Empty)
                Case "SceneCollectionListChanged"
                    RaiseEvent SceneCollectionListChanged(Me, EventArgs.Empty)
                Case "SwitchTransition"
                    RaiseEvent TransitionChanged(Me, CStr(body("transition-name")))
                Case "TransitionDurationChanged"
                    RaiseEvent TransitionDurationChanged(Me, CInt(body("new-duration")))
                Case "TransitionListChanged"
                    RaiseEvent TransitionListChanged(Me, EventArgs.Empty)
                Case "TransitionBegin"
                    RaiseEvent TransitionBegin(Me, EventArgs.Empty)
                Case "ProfileChanged"
                    RaiseEvent ProfileChanged(Me, EventArgs.Empty)
                Case "ProfileListChanged"
                    RaiseEvent ProfileListChanged(Me, EventArgs.Empty)
                Case "StreamStarting"
                    RaiseEvent StreamingStateChanged(Me, OutputState.Starting)
                Case "StreamStarted"
                    RaiseEvent StreamingStateChanged(Me, OutputState.Started)
                Case "StreamStopping"
                    RaiseEvent StreamingStateChanged(Me, OutputState.Stopping)
                Case "StreamStopped"
                    RaiseEvent StreamingStateChanged(Me, OutputState.Stopped)
                Case "RecordingStarting"
                    RaiseEvent RecordingStateChanged(Me, OutputState.Starting)
                Case "RecordingStarted"
                    RaiseEvent RecordingStateChanged(Me, OutputState.Started)
                Case "RecordingStopping"
                    RaiseEvent RecordingStateChanged(Me, OutputState.Stopping)
                Case "RecordingStopped"
                    RaiseEvent RecordingStateChanged(Me, OutputState.Stopped)
                Case "StreamStatus"
                    'If StreamStatus IsNot Nothing Then
                    '    status = New StreamStatus(body)
                    '    StreamStatus(Me, status)
                    'End If

                Case "PreviewSceneChanged"
                    RaiseEvent PreviewSceneChanged(Me, CStr(body("scene-name")))
                Case "StudioModeSwitched"
                    RaiseEvent StudioModeSwitched(Me, CBool(body("new-state")))
                Case "ReplayStarting"
                    RaiseEvent ReplayBufferStateChanged(Me, OutputState.Starting)
                Case "ReplayStarted"
                    RaiseEvent ReplayBufferStateChanged(Me, OutputState.Started)
                Case "ReplayStopping"
                    RaiseEvent ReplayBufferStateChanged(Me, OutputState.Stopping)
                Case "ReplayStopped"
                    RaiseEvent ReplayBufferStateChanged(Me, OutputState.Stopped)
                Case "Exiting"
                    RaiseEvent OBSExit(Me, EventArgs.Empty)
            End Select
        End Sub

        Protected Function HashEncode(ByVal input As String) As String
            Dim sha256 = New SHA256Managed()
            Dim textBytes As Byte() = Encoding.ASCII.GetBytes(input)
            Dim hash As Byte() = sha256.ComputeHash(textBytes)
            Return System.Convert.ToBase64String(hash)
        End Function

        Protected Function NewMessageID(ByVal Optional length As Integer = 16) As String
            Const pool As String = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim random = New Random()
            Dim result As String = ""
            For i As Integer = 0 To length - 1
                Dim index As Integer = random.[Next](0, pool.Length - 1)
                result += pool(index)
            Next

            Return result
        End Function
    End Class
End Namespace
