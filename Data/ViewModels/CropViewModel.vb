Imports OBSWebsocketDotNet

Namespace Data.ViewModels
    Public Class CropViewModel
        Inherits ViewModelBase

        Private _top As Integer
        Private _left As Integer
        Private _right As Integer
        Private _bottom As Integer

        Property Top As Integer
            Get
                Return _top
            End Get
            Set
                SetField(_top, Value)
            End Set
        End Property

        Property Left As Integer
            Get
                Return _left
            End Get
            Set
                SetField(_left, Value)
            End Set
        End Property

        Public Property Right As Integer
            Get
                Return _right
            End Get
            Set
                SetField(_right, Value)
            End Set
        End Property

        Public Property Bottom As Integer
            Get
                Return _bottom
            End Get
            Set
                SetField(_bottom, Value)
            End Set
        End Property

        Public Function AsRectangle() As Rectangle
            Return Rectangle.FromLTRB(Left, Top, Right, Bottom)
        End Function

        Public Sub UpdateFromRectangle(rect As Rectangle)
            Left = rect.Left
            Top = rect.Top
            Bottom = rect.Bottom
            Right = rect.Right
        End Sub
        Public Sub UpdateFromRectangle(rect As SceneItemCropInfo)
            Left = rect.Left
            Top = rect.Top
            Bottom = rect.Bottom
            Right = rect.Right
        End Sub
    End Class
End Namespace