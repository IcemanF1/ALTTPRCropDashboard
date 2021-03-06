﻿Imports System.Net.Sockets
Imports Newtonsoft.Json.Linq
Imports OBSWebsocketDotNet

Public Class ObsWebSocketPlus
    Inherits OBSWebsocket
    Public Function GetSceneItemProperties(
           sceneName As String,
           item As String) As SceneItemProperties

        Dim requestParameters As New JObject

        If String.IsNullOrEmpty(sceneName) Then
            sceneName = If(StudioModeEnabled(), GetPreviewScene().Name, GetCurrentScene().Name)
        End If

        If Not String.IsNullOrEmpty(sceneName) Then
            requestParameters.Add("scene-name", sceneName)
        End If

        requestParameters.Add("item", item)

        Return New SceneItemProperties(SendRequest("GetSceneItemProperties", requestParameters))

    End Function
    Public Function GetSourceSettings(
           sourcename As String) As SourceSettings

        Dim requestParameters As New JObject

        requestParameters.Add("sourceName", sourcename)

        Return New SourceSettings(SendRequest("GetSourceSettings", requestParameters))

    End Function
    Public Sub SetTextGdi(source As String, textValue As String)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("text", textValue)

        SendRequest("SetTextGDIPlusProperties", requestParameters)
    End Sub
    Public Sub SetSourceSettings(source As String, cursor As Boolean, window As String, priority As Integer)
        Dim requestParameters As New JObject

        Dim sourceSettings As New JObject
        sourceSettings.Add("window", window)
        'SourceSettings.Add("cursor", cursor)
        'SourceSettings.Add("priority", priority)

        requestParameters.Add("sourceName", source)
        requestParameters.Add("sourceType", "window_capture")
        requestParameters.Add("sourceSettings", sourceSettings)

        SendRequest("SetSourceSettings", requestParameters)
    End Sub
    Public Function GetTextGDIProperties(source As String) As TextGDI
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)

        Return New TextGDI(SendRequest("GetTextGDIPlusProperties", requestParameters))
    End Function
    Public Sub SetBrowserSource(source As String, urlValue As String)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("url", urlValue)

        SendRequest("SetBrowserSourceProperties", requestParameters)

    End Sub
    Public Sub SetSceneItemProperties(item As String, cropT As Integer, cropB As Integer,
                                    cropL As Integer, cropR As Integer, boundingWidth As Integer,
                                      bondingHeight As Integer, positionX As Integer, positionY As Integer)

        Dim requestParameters As New JObject

        Dim cropInfo As New JObject
        Dim boundInfo As New JObject
        Dim positioInfo As New JObject

        requestParameters.Add("scene-name", If(StudioModeEnabled(), GetPreviewScene().Name, GetCurrentScene().Name))

        cropInfo.Add("top", cropT)
        cropInfo.Add("bottom", cropB)
        cropInfo.Add("left", cropL)
        cropInfo.Add("right", cropR)

        requestParameters.Add("item", item)
        requestParameters.Add("crop", cropInfo)

        Dim boundType As String = "OBS_BOUNDS_STRETCH"

        If boundingWidth > 0 Then
            boundInfo.Add("x", boundingWidth)
            boundInfo.Add("y", bondingHeight)
            'boundInfo.Add("type", boundType)
            boundInfo.Add("alignment", 0)
            requestParameters.Add("bounds", boundInfo)
        End If

        If positionX > 0 Then
            positioInfo.Add("x", positionX)
            positioInfo.Add("y", positionY)
            requestParameters.Add("position", positioInfo)
        End If

        SendRequest("SetSceneItemProperties", requestParameters)
    End Sub
    Public Function IsPortOpen(connectionAddress As String) As Boolean
        Dim client As TcpClient = Nothing


        Dim host As String = connectionAddress.Split(":"c)(1).Remove(0, 2)
        Dim portNumber As Integer = CInt(connectionAddress.Split(":"c)(2))

        Try
            client = New TcpClient(host, portNumber)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not client Is Nothing Then
                client.Close()
            End If
        End Try
    End Function
    Public Function ConfirmSourceType(ByVal ExpectedSourceType As String, ByVal SourceName As String) As Boolean
        Dim SourceInfo As SourceSettings
        SourceInfo = GetSourceSettings(SourceName)

        Return SourceInfo.sourcetype = ExpectedSourceType

    End Function
End Class
Public Class TextGDI
    Public Property FontFace As String
    Public Property FontSize As Integer
    Public Property text As String

    Public Sub New(ByRef data As JObject)
        FontFace = CType(data("font").Item("face"), String)
        FontSize = CType(data("font").Item("size"), Integer)
        text = CType(data("text"), String)
    End Sub
End Class
Public Class SourceSettings
    'Public Property SourceName As String

    Public Property Window As String
    Public Property Priority As Integer
    Public Property Cursor As Boolean
    Public Property SourceType As String


    Public Sub New(ByRef data As JObject)
        SourceType = CType(data("sourceType"), String)

        If SourceType = "window_capture" Then
            Window = CType(data("sourceSettings").Item("window"), String)
            Priority = If(CType(data("sourceSettings").Item("priority"), Integer?), 1)

            If data("sourceSettings").Item("cursor") Is Nothing Then
                Cursor = False
            Else
                Cursor = CType(data("sourceSettings").Item("cursor"), Boolean)
            End If
        Else
            Window = ""
            Priority = 0
            Cursor = False
        End If

    End Sub
End Class
Public Class SceneItemProperties
    Public Property Crop As SceneItemCropInfo
    Public Property Name As String
    Public Property ItemId As Integer
    Public Property PositionX As Double
    Public Property PositionY As Double
    Public Property PositionAlignment As Double
    Public Property Rotation As Double
    Public Property ScaleX As Double
    Public Property ScaleY As Double
    Public Property Visible As Boolean
    Public Property Locked As Boolean
    Public Property BoundsX As Double
    Public Property BoundsY As Double
    Public Property BoundsAlignment As Double
    Public Property BoundsType As String

    Public Sub New(ByRef data As JObject)
        Name = CType(data("name"), String)
        ItemId = CInt(If(data("id"), 0))

        Dim positionInfo As JObject = CType(data("position"), JObject)
        PositionX = CType(positionInfo("x"), Double)
        PositionY = CType(positionInfo("y"), Double)
        PositionAlignment = CType(positionInfo("alignment"), Double)

        Rotation = CType(data("rotation"), Double)

        Dim scaleInfo As JObject = CType(data("scale"), JObject)
        ScaleX = CType(scaleInfo("x"), Double)
        ScaleY = CType(scaleInfo("y"), Double)

        Dim cropTemp As New SceneItemCropInfo
        Dim cropInfo As JObject = CType(data("crop"), JObject)
        cropTemp.Bottom = CInt(If(cropInfo("bottom"), 0))
        cropTemp.Top = CInt(If(cropInfo("top"), 0))
        cropTemp.Left = CInt(If(cropInfo("left"), 0))
        cropTemp.Right = CInt(If(cropInfo("right"), 0))

        Crop = cropTemp

        Visible = If(CType(data("visible"), Boolean?), False)

        If data("locked") Is Nothing Then
            Locked = False
        Else
            Locked = CType(data("locked"), Boolean)
        End If

        Dim boundsInfo As JObject = CType(data("bounds"), JObject)
        BoundsType = CType(boundsInfo("type"), String)

        If BoundsType <> "OBS_BOUNDS_NONE" Then
            BoundsX = CType(boundsInfo("x"), Double)
            BoundsY = CType(boundsInfo("y"), Double)
            BoundsAlignment = CType(boundsInfo("alignment"), Double)
        Else
            BoundsX = 0
            BoundsY = 0
            BoundsAlignment = 0
        End If



    End Sub

End Class


