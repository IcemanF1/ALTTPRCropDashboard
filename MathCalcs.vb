Imports OBSWebsocketDotNet

Public Class MathCalcs
    Public Shared Function SetCropNewMath(ByVal CropTop As Integer, ByVal CropLeft As Integer,
                                   ByVal CropBottom As Integer, ByVal CropRight As Integer,
                                   ByVal DefaultTopCrop As Integer, ByVal DefaultBottomCrop As Integer,
                                   ByVal MasterHeight As Integer, ByVal MasterWidth As Integer,
                                   ByVal SourceHeight As Integer, ByVal SourceWidth As Integer) As SceneItemCropInfo

        Dim NCropTop, NCropBottom, NCropLeft, NCropRight As Integer


        NCropTop = CropTop ' - DefaultTopCrop
        NCropBottom = CropBottom ' - DefaultBottomCrop
        NCropLeft = CropLeft
        NCropRight = CropRight

        Dim NHeight, NWidth As Integer

        NHeight = SourceHeight '- (DefaultTopCrop + DefaultBottomCrop)
        NWidth = SourceWidth

        Dim AspectRatioHeight, AspectRatioWidth As Decimal
        Dim AbsAspectRatioHeight, AbsAspectRatioWidth As Decimal

        AspectRatioHeight = NHeight / MasterHeight
        AbsAspectRatioHeight = Math.Max(NHeight, MasterHeight) / Math.Min(NHeight, MasterHeight)

        AspectRatioWidth = NWidth / MasterWidth
        AbsAspectRatioWidth = Math.Max(NWidth, MasterWidth) / Math.Min(NWidth, MasterWidth)

        Dim SavedScaleChange As Decimal = 1

        SavedScaleChange = Math.Min(AspectRatioHeight, AspectRatioWidth)

        Dim scale As Decimal

        scale = SavedScaleChange

        Dim USHeight, USWidth As Decimal
        USHeight = MasterHeight * SavedScaleChange
        USWidth = MasterWidth * SavedScaleChange

        Dim BBHeight, BBWidth As Decimal

        BBWidth = Math.Abs(USWidth - NWidth)
        BBHeight = Math.Abs(USHeight - NHeight)

        Dim ACTop, ACBottom, ACLLeft, ACRight,
            BBTop, BBBottom, BBLeft, BBRight As Integer

        ACTop = NCropTop * scale
        ACBottom = NCropBottom * scale
        ACLLeft = NCropLeft * scale
        ACRight = NCropRight * scale

        BBTop = BBHeight / 2
        BBBottom = BBHeight / 2
        BBLeft = BBWidth / 2
        BBRight = BBWidth / 2

        Dim Crop As New SceneItemCropInfo

        Crop.Top = ACTop + BBTop + DefaultTopCrop
        Crop.Bottom = ACBottom + BBBottom + DefaultBottomCrop
        Crop.Left = ACLLeft + BBLeft
        Crop.Right = ACRight + BBRight

        Return Crop

    End Function
End Class
