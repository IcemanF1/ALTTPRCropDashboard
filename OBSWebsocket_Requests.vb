Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic

Namespace OBSWebsocketDotNet

    Partial Public Class OBSWebsocket

        Public Function GetCurrentScene() As OBSScene
            Dim response As JObject = SendRequest("GetCurrentScene")
            Return New OBSScene(response)
        End Function

        Public Sub SetCurrentScene(ByVal sceneName As String)
            Dim requestFields = New JObject()
            requestFields.Add("scene-name", sceneName)
            SendRequest("SetCurrentScene", requestFields)
        End Sub

        Public Function ListScenes() As List(Of OBSScene)
            Dim response As JObject = SendRequest("GetSceneList")
            Dim items As JArray = CType(response("scenes"), JArray)
            Dim scenes = New List(Of OBSScene)()
            For Each sceneData As JObject In items
                Dim scene As OBSScene = New OBSScene(sceneData)
                scenes.Add(scene)
            Next

            Return scenes
        End Function

        Public Sub SetSourceRender(ByVal itemName As String, ByVal visible As Boolean, ByVal Optional sceneName As String = Nothing)
            Dim requestFields = New JObject()
            requestFields.Add("source", itemName)
            requestFields.Add("render", visible)
            If sceneName IsNot Nothing Then requestFields.Add("scene-name", sceneName)
            SendRequest("SetSourceRender", requestFields)
        End Sub

        Public Sub ToggleStreaming()
            SendRequest("StartStopStreaming")
        End Sub

        Public Sub ToggleRecording()
            SendRequest("StartStopRecording")
        End Sub

        Public Function GetStreamingStatus() As OutputStatus
            Dim response As JObject = SendRequest("GetStreamingStatus")
            Dim outputStatus = New OutputStatus(response)
            Return outputStatus
        End Function

        Public Function ListTransitions() As List(Of String)
            Dim response As JObject = SendRequest("GetTransitionList")
            Dim items As JArray = CType(response("transitions"), JArray)
            Dim transitionNames As List(Of String) = New List(Of String)()
            For Each item As JObject In items
                transitionNames.Add(CStr(item("name")))
            Next

            Return transitionNames
        End Function

        Public Function GetCurrentTransition() As TransitionSettings
            Dim respBody As JObject = SendRequest("GetCurrentTransition")
            Return New TransitionSettings(respBody)
        End Function

        Public Sub SetCurrentTransition(ByVal transitionName As String)
            Dim requestFields = New JObject()
            requestFields.Add("transition-name", transitionName)
            SendRequest("SetCurrentTransition", requestFields)
        End Sub

        Public Sub SetTransitionDuration(ByVal duration As Integer)
            Dim requestFields = New JObject()
            requestFields.Add("duration", duration)
            SendRequest("SetTransitionDuration", requestFields)
        End Sub

        Public Sub SetVolume(ByVal sourceName As String, ByVal volume As Single)
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            requestFields.Add("volume", volume)
            SendRequest("SetVolume", requestFields)
        End Sub

        Public Function GetVolume(ByVal sourceName As String) As VolumeInfo
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            Dim response = SendRequest("GetVolume", requestFields)
            Return New VolumeInfo(response)
        End Function

        Public Sub SetMute(ByVal sourceName As String, ByVal mute As Boolean)
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            requestFields.Add("mute", mute)
            SendRequest("SetMute", requestFields)
        End Sub

        Public Sub ToggleMute(ByVal sourceName As String)
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            SendRequest("ToggleMute", requestFields)
        End Sub

        Public Sub SetSceneItemPosition(ByVal itemName As String, ByVal x As Single, ByVal y As Single, ByVal Optional sceneName As String = Nothing)
            Dim requestFields = New JObject()
            requestFields.Add("item", itemName)
            requestFields.Add("x", x)
            requestFields.Add("y", y)
            If sceneName IsNot Nothing Then requestFields.Add("scene-name", sceneName)
            SendRequest("SetSceneItemPosition", requestFields)
        End Sub

        Public Sub SetSceneItemTransform(ByVal itemName As String, ByVal Optional rotation As Single = 0, ByVal Optional xScale As Single = 1, ByVal Optional yScale As Single = 1, ByVal Optional sceneName As String = Nothing)
            Dim requestFields = New JObject()
            requestFields.Add("item", itemName)
            requestFields.Add("x-scale", xScale)
            requestFields.Add("y-scale", yScale)
            requestFields.Add("rotation", rotation)
            If sceneName IsNot Nothing Then requestFields.Add("scene-name", sceneName)
            SendRequest("SetSceneItemTransform", requestFields)
        End Sub

        Public Sub SetCurrentSceneCollection(ByVal scName As String)
            Dim requestFields = New JObject()
            requestFields.Add("sc-name", scName)
            SendRequest("SetCurrentSceneCollection", requestFields)
        End Sub

        Public Function GetCurrentSceneCollection() As String
            Dim response = SendRequest("GetCurrentSceneCollection")
            Return CStr(response("sc-name"))
        End Function

        Public Function ListSceneCollections() As List(Of String)
            Dim response = SendRequest("ListSceneCollections")
            Dim items = CType(response("scene-collections"), JArray)
            Dim sceneCollections As List(Of String) = New List(Of String)()
            For Each item As JObject In items
                sceneCollections.Add(CStr(item("sc-name")))
            Next

            Return sceneCollections
        End Function

        Public Sub SetCurrentProfile(ByVal profileName As String)
            Dim requestFields = New JObject()
            requestFields.Add("profile-name", profileName)
            SendRequest("SetCurrentProfile", requestFields)
        End Sub

        Public Function GetCurrentProfile() As String
            Dim response = SendRequest("GetCurrentProfile")
            Return CStr(response("profile-name"))
        End Function

        Public Function ListProfiles() As List(Of String)
            Dim response = SendRequest("ListProfiles")
            Dim items = CType(response("profiles"), JArray)
            Dim profiles As List(Of String) = New List(Of String)()
            For Each item As JObject In items
                profiles.Add(CStr(item("profile-name")))
            Next

            Return profiles
        End Function

        Public Sub StartStreaming()
            SendRequest("StartStreaming")
        End Sub

        Public Sub StopStreaming()
            SendRequest("StopStreaming")
        End Sub

        Public Sub StartRecording()
            SendRequest("StartRecording")
        End Sub

        Public Sub StopRecording()
            SendRequest("StopRecording")
        End Sub

        Public Sub SetRecordingFolder(ByVal recFolder As String)
            Dim requestFields = New JObject()
            requestFields.Add("rec-folder", recFolder)
            SendRequest("SetRecordingFolder", requestFields)
        End Sub

        Public Function GetRecordingFolder() As String
            Dim response = SendRequest("GetRecordingFolder")
            Return CStr(response("rec-folder"))
        End Function

        Public Function GetTransitionDuration() As Integer
            Dim response = SendRequest("GetTransitionDuration")
            Return CInt(response("transition-duration"))
        End Function

        Public Function StudioModeEnabled() As Boolean
            Dim response = SendRequest("GetStudioModeStatus")
            Return CBool(response("studio-mode"))
        End Function

        Public Sub SetStudioMode(ByVal enable As Boolean)
            If enable Then SendRequest("EnableStudioMode") Else SendRequest("DisableStudioMode")
        End Sub

        Public Sub ToggleStudioMode()
            SendRequest("ToggleStudioMode")
        End Sub

        Public Function GetPreviewScene() As OBSScene
            Dim response = SendRequest("GetPreviewScene")
            Return New OBSScene(response)
        End Function

        Public Sub SetPreviewScene(ByVal previewScene As String)
            Dim requestFields = New JObject()
            requestFields.Add("scene-name", previewScene)
            SendRequest("SetPreviewScene", requestFields)
        End Sub

        Public Sub SetPreviewScene(ByVal previewScene As OBSScene)
            SetPreviewScene(previewScene.Name)
        End Sub

        Public Sub TransitionToProgram(ByVal Optional transitionDuration As Integer = -1, ByVal Optional transitionName As String = Nothing)
            Dim requestFields = New JObject()
            If transitionDuration > -1 OrElse transitionName IsNot Nothing Then
                Dim withTransition = New JObject()
                If transitionDuration > -1 Then withTransition.Add("duration")
                If transitionName IsNot Nothing Then withTransition.Add("name", transitionName)
                requestFields.Add("with-transition", withTransition)
            End If

            SendRequest("TransitionToProgram", requestFields)
        End Sub

        Public Function GetMute(ByVal sourceName As String) As Boolean
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            Dim response = SendRequest("GetMute")
            Return CBool(response("muted"))
        End Function

        Public Sub ToggleReplayBuffer()
            SendRequest("StartStopReplayBuffer")
        End Sub

        Public Sub StartReplayBuffer()
            SendRequest("StartReplayBuffer")
        End Sub

        Public Sub StopReplayBuffer()
            SendRequest("StopReplayBuffer")
        End Sub

        Public Sub SaveReplayBuffer()
            SendRequest("SaveReplayBuffer")
        End Sub

        Public Sub SetSyncOffset(ByVal sourceName As String, ByVal syncOffset As Integer)
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            requestFields.Add("offset", syncOffset)
            SendRequest("SetSyncOffset", requestFields)
        End Sub

        Public Function GetSyncOffset(ByVal sourceName As String) As Integer
            Dim requestFields = New JObject()
            requestFields.Add("source", sourceName)
            Dim response = SendRequest("GetSyncOffset", requestFields)
            Return CInt(response("offset"))
        End Function

        Public Sub SetSceneItemCrop(ByVal sceneItemName As String, ByVal cropInfo As SceneItemCropInfo, ByVal Optional sceneName As String = Nothing)
            Dim requestFields = New JObject()
            If sceneName IsNot Nothing Then requestFields.Add("scene-name")
            requestFields.Add("item", sceneItemName)
            requestFields.Add("top", cropInfo.Top)
            requestFields.Add("bottom", cropInfo.Bottom)
            requestFields.Add("left", cropInfo.Left)
            requestFields.Add("right", cropInfo.Right)
            SendRequest("SetSceneItemCrop", requestFields)
        End Sub

        Public Sub SetSceneItemCrop(ByVal sceneItem As SceneItem, ByVal cropInfo As SceneItemCropInfo, ByVal scene As OBSScene)
            SetSceneItemCrop(sceneItem.SourceName, cropInfo, scene.Name)
        End Sub

        Public Function GetSpecialSources() As Dictionary(Of String, String)
            Dim response = SendRequest("GetSpecialSources")
            Dim sources = New Dictionary(Of String, String)()
            For Each x As KeyValuePair(Of String, JToken) In response
                Dim key As String = x.Key
                Dim value As String = CStr(x.Value)
                If key <> "request-type" AndAlso key <> "message-id" Then
                    sources.Add(key, value)
                End If
            Next

            Return sources
        End Function

        Public Sub SetStreamingSettings(ByVal service As StreamingService, ByVal save As Boolean)
            Dim requestFields = New JObject()
            requestFields.Add("type", service.Type)
            requestFields.Add("settings", service.Settings)
            requestFields.Add("save", save)
            SendRequest("SetStreamSettings", requestFields)
        End Sub

        Public Function GetStreamSettings() As StreamingService
            Dim response = SendRequest("GetStreamSettings")
            Dim service = New StreamingService()
            service.Type = CStr(response("type"))
            service.Settings = CType(response("settings"), JObject)
            Return service
        End Function

        Public Sub SaveStreamSettings()
            SendRequest("SaveStreamSettings")
        End Sub

        Public Function GetBrowserSourceProperties(ByVal sourceName As String, ByVal Optional sceneName As String = Nothing) As BrowserSourceProperties
            Dim request = New JObject()
            request.Add("source", sourceName)
            If sceneName IsNot Nothing Then request.Add("scene-name", sourceName)
            Dim response = SendRequest("GetBrowserSourceProperties", request)
            Return New BrowserSourceProperties(response)
        End Function

        Public Sub SetBrowserSourceProperties(ByVal sourceName As String, ByVal props As BrowserSourceProperties, ByVal Optional sceneName As String = Nothing)
            Dim request = New JObject()
            request.Add("source", sourceName)
            If sceneName IsNot Nothing Then request.Add("scene-name", sourceName)
            request.Merge(props.ToJSON(), New JsonMergeSettings() With {.MergeArrayHandling = MergeArrayHandling.Union})
            SendRequest("SetBrowserSourceProperties", request)
        End Sub
    End Class
End Namespace
