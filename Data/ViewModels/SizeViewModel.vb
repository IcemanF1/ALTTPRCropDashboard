Namespace Data.ViewModels
    Public Class SizeViewModel
        Inherits ViewModelBase

        Private _width As Integer
        Property Width As Integer
            Get
                Return _width
            End Get
            Set
                SetField(_width, Value)
            End Set
        End Property

        Private _height As Integer
        Property Height As Integer
            Get
                Return _height
            End Get
            Set
                SetField(_height, Value)
            End Set
        End Property


        Public Function AsSize() As Size
            Return New Size(Width, Height)
        End Function

        Public Sub UpdateFromSize(size As Size)
            Width = size.Width
            Height = size.Height
        End Sub
    End Class
End Namespace