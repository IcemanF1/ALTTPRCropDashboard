Public Class CropperMath

    Public Property DefaultCrop As New Rectangle


    Public Function RemoveDefaultCrop(rect As Rectangle) As Rectangle
        Return Rectangle.FromLTRB(Math.Max(rect.Left - DefaultCrop.Left, 0),
                                  Math.Max(rect.Top - DefaultCrop.Top, 0),
                                  Math.Max(rect.Right - DefaultCrop.Right, 0),
                                  Math.Max(rect.Bottom - DefaultCrop.Bottom, 0)
                                )
    End Function

    Public Function RemoveDefaultCropSize(size As Size) As Size
        Return New Size(Math.Max(size.Width - DefaultCrop.Left - DefaultCrop.Right, 0),
                        Math.Max(size.Height - DefaultCrop.Top - DefaultCrop.Bottom, 0))
    End Function

    Public Function AddDefaultCrop(rect As Rectangle) As Rectangle
        Return Rectangle.FromLTRB(rect.Left + DefaultCrop.Left, rect.Top + DefaultCrop.Top, rect.Right + DefaultCrop.Right, rect.Bottom + DefaultCrop.Bottom)
    End Function


    Public Function AddDefaultCropSize(size As Size) As Size
        Return New Size(size.Width + DefaultCrop.Left + DefaultCrop.Right,
                        size.Height + DefaultCrop.Top + DefaultCrop.Bottom)
    End Function

    Public Function AdjustCrop(crop As CropInfo, newMasterSizeWithoutDefault As Size) As CropInfo
        'Let's calculate how much we differ from the original source
        Dim aspectRatioScale As New PointF(newMasterSizeWithoutDefault.Width / crop.MasterSizeWithoutDefault.Width, newMasterSizeWithoutDefault.Height / crop.MasterSizeWithoutDefault.Height)
        'From that, we take the smaller ratio
        Dim aspectRatioChange = Math.Min(aspectRatioScale.X, aspectRatioScale.Y)
        'Then by scaling the original, we get the size of the video when scaled up.
        Dim scaledMasterSize As New Size(crop.MasterSizeWithoutDefault.Width * aspectRatioChange,
                                         crop.MasterSizeWithoutDefault.Height * aspectRatioChange)
        'And the remaining space is black bars.
        Dim blackBarsSize As New Size(newMasterSizeWithoutDefault.Width - scaledMasterSize.Width,
                                      newMasterSizeWithoutDefault.Height - scaledMasterSize.Height)
        'These black bars are around the source. On non-even sizes, 1px bigger on one side.
        Dim blackBars = Rectangle.FromLTRB(Math.Ceiling(blackBarsSize.Width / 2.0),
                                           Math.Ceiling(blackBarsSize.Height / 2.0),
                                           Math.Floor(blackBarsSize.Width / 2.0),
                                           Math.Floor(blackBarsSize.Height / 2.0))
        'Now we also scale the crop numbers, since they now refer to a much bigger stream.
        Dim scaledCrop = Rectangle.FromLTRB(crop.CropWithoutDefault.Left * aspectRatioChange,
                                            crop.CropWithoutDefault.Top * aspectRatioChange,
                                            crop.CropWithoutDefault.Right * aspectRatioChange,
                                            crop.CropWithoutDefault.Bottom * aspectRatioChange)


        Return New CropInfo With {
                .CropWithoutDefault = scaledCrop,
                .BlackBars = blackBars,
                .MasterSizeWithoutDefault = scaledMasterSize
            }

    End Function

End Class


Public Class CropInfo
    Public Property CropWithoutDefault As Rectangle
    Public Property BlackBars As New Rectangle
    Public Property MasterSizeWithoutDefault As Size

    Public ReadOnly Property CropWithBlackBarsWithoutDefault As Rectangle
        Get
            Return Rectangle.FromLTRB(CropWithoutDefault.Left + BlackBars.Left, CropWithoutDefault.Top + BlackBars.Top, CropWithoutDefault.Right + BlackBars.Right, CropWithoutDefault.Bottom + BlackBars.Bottom)
        End Get
    End Property
End Class