Imports Newtonsoft.Json.Linq
Imports OBSWebsocketDotNet

Public Class OBSWebSocketPlus
    Public Shared Function GetSceneItemProperties(
           ByVal sceneName As String,
           ByVal item As String, ByVal OBSConnection As OBSWebsocket) As SceneItemProperties

        Dim requestParameters As New JObject

        If Not String.IsNullOrEmpty(sceneName) Then
            requestParameters.Add("scene-name", sceneName)
        End If

        requestParameters.Add("item", item)

        Return New SceneItemProperties(OBSConnection.SendRequest("GetSceneItemProperties", requestParameters))

    End Function
    Public Shared Sub SetTextGDI(ByVal source As String, ByVal TextValue As String, ByVal OBSConnection As OBSWebsocket)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("text", TextValue)

        OBSConnection.SendRequest("SetTextGDIPlusProperties", requestParameters)
    End Sub
    Public Shared Sub SetBrowserSource(ByVal source As String, ByVal urlValue As String, ByVal OBSConnection As OBSWebsocket)
        Dim requestParameters As New JObject

        requestParameters.Add("source", source)
        requestParameters.Add("url", urlValue)

        OBSConnection.SendRequest("SetBrowserSourceProperties", requestParameters)

    End Sub
    Public Shared Sub SetSceneItemProperties(ByVal item As String, ByVal CropT As Integer, ByVal CropB As Integer,
                                    ByVal CropL As Integer, ByVal CropR As Integer, ByVal OBSConnection As OBSWebsocket)

        Dim requestParameters As New JObject

        Dim cropInfo As New JObject

        cropInfo.Add("top", CropT)
        cropInfo.Add("bottom", CropB)
        cropInfo.Add("left", CropL)
        cropInfo.Add("right", CropR)
        requestParameters.Add("item", item)
        requestParameters.Add("crop", cropInfo)

        'If isConnection1 = True Then
        '    OBSWebScocketCropper._obs.SendRequest("SetSceneItemProperties", requestParameters)
        'Else
        '    OBSWebScocketCropper._obs2.SendRequest("SetSceneItemProperties", requestParameters)
        'End If

        OBSConnection.SendRequest("SetSceneItemProperties", requestParameters)
    End Sub
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


