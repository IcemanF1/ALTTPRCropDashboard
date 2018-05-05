Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports ALTTPRCropDashboard.Data
Imports OBSWebsocketDotNet

Namespace DB
    Public Class Crop
        Public Overridable Property Id As Guid
        <Required>
        Public Overridable Property Runner As String
        <Required>
        Public Overridable Property Submitter As String
        Public Overridable Property SubmittedOn As DateTime?
        Public Overridable Property GameCropTop As Integer
        Public Overridable Property GameCropLeft As Integer
        Public Overridable Property GameCropBottom As Integer
        Public Overridable Property GameCropRight As Integer
        Public Overridable Property TimerCropTop As Integer
        Public Overridable Property TimerCropLeft As Integer
        Public Overridable Property TimerCropBottom As Integer
        Public Overridable Property TimerCropRight As Integer
        Public Overridable Property SizeWidth As Integer
        Public Overridable Property SizeHeight As Integer
        Public Overridable Property RunnerName As String
        <NotMapped>
        Public Property TimerCrop As SceneItemCropInfo
            Get
                Return New SceneItemCropInfo With {.Bottom = TimerCropBottom, .Left = TimerCropLeft, .Top = TimerCropTop, .Right = TimerCropRight}
            End Get
            Set
                TimerCropTop = Value.Top
                TimerCropBottom = Value.Bottom
                TimerCropLeft = Value.Left
                TimerCropRight = Value.Right
            End Set
        End Property
        <NotMapped>
        Public Property GameCrop As SceneItemCropInfo
            Get
                Return New SceneItemCropInfo With {.Bottom = GameCropBottom, .Left = GameCropLeft, .Top = GameCropTop, .Right = GameCropRight}
            End Get
            Set
                GameCropTop = Value.Top
                GameCropBottom = Value.Bottom
                GameCropLeft = Value.Left
                GameCropRight = Value.Right
            End Set
        End Property
        <NotMapped>
        Public Property Size As WindowSize
            Get
                Return New WindowSize With {.Height = SizeHeight, .Width = SizeWidth}
            End Get
            Set
                SizeWidth = Value.Width
                SizeHeight = Value.Height
            End Set
        End Property
    End Class
End Namespace