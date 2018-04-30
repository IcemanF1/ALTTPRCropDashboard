Imports System.Net.Sockets
Imports Newtonsoft.Json.Linq
Imports OBSWebsocketDotNet

Public Class OBSWebSocketPlus
    Inherits OBSWebsocket
    Public Function GetSceneItemProperties(
           ByVal sceneName As String,
           ByVal item As String) As SceneItemProperties

        Dim requestParameters As New JObject

        If Not String.IsNullOrEmpty(sceneName) Then
            requestParameters.Add("scene-name", sceneName)
        End If

        requestParameters.Add("item", item)

        Return New SceneItemProperties(SendRequest("GetSceneItemProperties", requestParameters))

    End Function
    Public Sub SetTextGDI(ByVal source As String, ByVal TextValue As String)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("text", TextValue)

        SendRequest("SetTextGDIPlusProperties", requestParameters)
    End Sub
    Public Sub SetBrowserSource(ByVal source As String, ByVal urlValue As String)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("url", urlValue)

        SendRequest("SetBrowserSourceProperties", requestParameters)

    End Sub
    Public Sub SetSceneItemProperties(ByVal item As String, ByVal CropT As Integer, ByVal CropB As Integer,
                                    ByVal CropL As Integer, ByVal CropR As Integer)

        Dim requestParameters As New JObject

        Dim cropInfo As New JObject

        cropInfo.Add("top", CropT)
        cropInfo.Add("bottom", CropB)
        cropInfo.Add("left", CropL)
        cropInfo.Add("right", CropR)
        requestParameters.Add("item", item)
        requestParameters.Add("crop", cropInfo)

        SendRequest("SetSceneItemProperties", requestParameters)
    End Sub
    Public Function IsPortOpen(ByVal ConnectionAddress As String) As Boolean
        Dim Client As TcpClient = Nothing


        Dim Host As String = ConnectionAddress.Split(":")(1).Remove(0, 2)
        Dim PortNumber As Integer = ConnectionAddress.Split(":")(2)

        Try
            Client = New TcpClient(Host, PortNumber)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not Client Is Nothing Then
                Client.Close()
            End If
        End Try
    End Function
End Class

Public Class SceneItemProperties
    Public Property Crop As SceneItemCropInfo
    Public Property Name As String
    Public Property ItemID As Integer
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
        ItemID = CType(data("id"), String)

        Dim positionInfo As JObject = data("position")
        PositionX = CType(positionInfo("x"), Double)
        PositionY = CType(positionInfo("y"), Double)
        PositionAlignment = CType(positionInfo("alignment"), Double)

        Rotation = CType(data("rotation"), Double)

        Dim scaleInfo As JObject = data("scale")
        ScaleX = CType(scaleInfo("x"), Double)
        ScaleY = CType(scaleInfo("y"), Double)

        Dim cropTemp As New SceneItemCropInfo
        Dim cropInfo As JObject = data("crop")
        cropTemp.Bottom = CType(cropInfo("bottom"), Integer)
        cropTemp.Top = CType(cropInfo("top"), Integer)
        cropTemp.Left = CType(cropInfo("left"), Integer)
        cropTemp.Right = CType(cropInfo("right"), Integer)

        Crop = cropTemp

        Visible = CType(data("visible"), Boolean)

        If data("locked") Is Nothing Then
            Locked = False
        Else
            Locked = CType(data("locked"), Boolean)
        End If


        Dim boundsInfo As JObject = data("bounds")
        BoundsX = CType(boundsInfo("x"), Double)
        BoundsY = CType(boundsInfo("y"), Double)
        BoundsType = CType(boundsInfo("type"), String)
        BoundsAlignment = CType(boundsInfo("alignment"), Double)

    End Sub

End Class


