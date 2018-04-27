Imports Newtonsoft.Json.Linq
Imports System
Imports System.Collections.Generic

Namespace OBSWebsocketDotNet

    Public Enum OutputState
        Starting
        Started
        Stopping
        Stopped
    End Enum

    Public Delegate Sub SceneChangeCallback(ByVal sender As OBSWebsocket, ByVal newSceneName As String)

    Public Delegate Sub SourceOrderChangeCallback(ByVal sender As OBSWebsocket, ByVal sceneName As String)

    Public Delegate Sub SceneItemUpdateCallback(ByVal sender As OBSWebsocket, ByVal sceneName As String, ByVal itemName As String)

    Public Delegate Sub TransitionChangeCallback(ByVal sender As OBSWebsocket, ByVal newTransitionName As String)

    Public Delegate Sub TransitionDurationChangeCallback(ByVal sender As OBSWebsocket, ByVal newDuration As Integer)

    Public Delegate Sub OutputStateCallback(ByVal sender As OBSWebsocket, ByVal type As OutputState)

    Public Delegate Sub StreamStatusCallback(ByVal sender As OBSWebsocket, ByVal status As StreamStatus)

    Public Delegate Sub StudioModeChangeCallback(ByVal sender As OBSWebsocket, ByVal enabled As Boolean)

    Public Structure OBSScene

        Public Name As String

        Public Items As List(Of SceneItem)

        Public Sub New(ByVal data As JObject)
            Name = CStr(data("name"))
            Items = New List(Of SceneItem)()
            Dim sceneItems = CType(data("sources"), JArray)
            For Each item As JObject In sceneItems
                Items.Add(New SceneItem(item))
            Next
        End Sub
    End Structure

    Public Structure SceneItem

        Public SourceName As String

        Public InternalType As String

        Public AudioVolume As Single

        Public XPos As Single

        Public YPos As Single

        Public SourceWidth As Integer

        Public SourceHeight As Integer

        Public Width As Single

        Public Height As Single

        Public Sub New(ByVal data As JObject)
            SourceName = CStr(data("name"))
            InternalType = CStr(data("type"))
            AudioVolume = CSng(data("volume"))
            XPos = CSng(data("x"))
            YPos = CSng(data("y"))
            SourceWidth = CInt(data("source_cx"))
            SourceHeight = CInt(data("source_cy"))
            Width = CSng(data("cx"))
            Height = CSng(data("cy"))
        End Sub
    End Structure

    Public Structure OBSAuthInfo

        Public ReadOnly AuthRequired As Boolean

        Public ReadOnly Challenge As String

        Public ReadOnly PasswordSalt As String

        Public Sub New(ByVal data As JObject)
            AuthRequired = CBool(data("authRequired"))
            Challenge = CStr(data("challenge"))
            PasswordSalt = CStr(data("salt"))
        End Sub
    End Structure

    Public Structure OBSVersion

        Public ReadOnly PluginVersion As String

        Public ReadOnly OBSStudioVersion As String

        Public Sub New(ByVal data As JObject)
            PluginVersion = CStr(data("obs-websocket-version"))
            OBSStudioVersion = CStr(data("obs-studio-version"))
        End Sub
    End Structure

    Public Structure StreamStatus

        Public ReadOnly Streaming As Boolean

        Public ReadOnly Recording As Boolean

        Public ReadOnly BytesPerSec As Integer

        Public ReadOnly KbitsPerSec As Integer

        Public ReadOnly Strain As Single

        Public ReadOnly TotalStreamTime As Integer

        Public ReadOnly TotalFrames As Integer

        Public ReadOnly DroppedFrames As Integer

        Public ReadOnly FPS As Single

        Public Sub New(ByVal data As JObject)
            Streaming = CBool(data("streaming"))
            Recording = CBool(data("recording"))
            BytesPerSec = CInt(data("bytes-per-sec"))
            KbitsPerSec = CInt(data("kbits-per-sec"))
            Strain = CSng(data("strain"))
            TotalStreamTime = CInt(data("total-stream-time"))
            TotalFrames = CInt(data("num-total-frames"))
            DroppedFrames = CInt(data("num-dropped-frames"))
            FPS = CSng(data("fps"))
        End Sub
    End Structure

    Public Structure OutputStatus

        Public ReadOnly IsStreaming As Boolean

        Public ReadOnly IsRecording As Boolean

        Public Sub New(ByVal data As JObject)
            IsStreaming = CBool(data("streaming"))
            IsRecording = CBool(data("recording"))
        End Sub
    End Structure

    Public Structure TransitionSettings

        Public ReadOnly Name As String

        Public ReadOnly Duration As Integer

        Public Sub New(ByVal data As JObject)
            Name = CStr(data("name"))
            Duration = CInt(data("duration"))
        End Sub
    End Structure

    Public Structure VolumeInfo

        Public ReadOnly Volume As Single

        Public ReadOnly Muted As Boolean

        Public Sub New(ByVal data As JObject)
            Volume = CSng(data("volume"))
            Muted = CBool(data("muted"))
        End Sub
    End Structure

    Public Structure StreamingService

        Public Type As String

        Public Settings As JObject
    End Structure

    Public Structure CommonRTMPStreamingService

        Public ServiceName As String

        Public ServerUrl As String

        Public StreamKey As String

        Public Sub New(ByVal settings As JObject)
            ServiceName = CStr(settings("service"))
            ServerUrl = CStr(settings("server"))
            StreamKey = CStr(settings("key"))
        End Sub

        Public Function ToJSON() As JObject
            Dim obj = New JObject()
            obj.Add("service", ServiceName)
            obj.Add("server", ServerUrl)
            obj.Add("key", StreamKey)
            Return obj
        End Function
    End Structure

    Public Structure CustomRTMPStreamingService

        Public ServerAddress As String

        Public StreamKey As String

        Public UseAuthentication As Boolean

        Public AuthUsername As String

        Public AuthPassword As String

        Public Sub New(ByVal settings As JObject)
            ServerAddress = CStr(settings("server"))
            StreamKey = CStr(settings("key"))
            UseAuthentication = CBool(settings("use_auth"))
            AuthUsername = CStr(settings("username"))
            AuthPassword = CStr(settings("password"))
        End Sub

        Public Function ToJSON() As JObject
            Dim obj = New JObject()
            obj.Add("server", ServerAddress)
            obj.Add("key", StreamKey)
            obj.Add("use_auth", UseAuthentication)
            obj.Add("username", AuthUsername)
            obj.Add("password", AuthPassword)
            Return obj
        End Function
    End Structure

    Public Structure SceneItemCropInfo

        Public Top As Integer

        Public Bottom As Integer

        Public Left As Integer

        Public Right As Integer
    End Structure

    Public Structure BrowserSourceProperties

        Public URL As String

        Public IsLocalFile As Boolean

        Public CustomCSS As String

        Public Width As Integer

        Public Height As Integer

        Public FPS As Integer

        Public ShutdownWhenNotVisible As Boolean

        Public Visible As Boolean

        Public Sub New(ByVal props As JObject)
            URL = CStr(props("url"))
            IsLocalFile = CBool(props("is_local_file"))
            CustomCSS = CStr(props("css"))
            Width = CInt(props("width"))
            Height = CInt(props("height"))
            FPS = CInt(props("fps"))
            ShutdownWhenNotVisible = CBool(props("shutdown"))
            Visible = CBool(props("render"))
        End Sub

        Public Function ToJSON() As JObject
            Dim obj = New JObject()
            obj.Add("url", URL)
            obj.Add("is_local_file", IsLocalFile)
            obj.Add("css", CustomCSS)
            obj.Add("width", Width)
            obj.Add("height", Height)
            obj.Add("fps", FPS)
            obj.Add("shutdown", ShutdownWhenNotVisible)
            obj.Add("render", Visible)
            Return obj
        End Function
    End Structure

    Public Class AuthFailureException
        Inherits Exception

    End Class

    Public Class ErrorResponseException
        Inherits Exception

        Public Sub New(ByVal message As String)
        End Sub
    End Class
End Namespace
