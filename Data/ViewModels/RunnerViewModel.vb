Namespace Data.ViewModels

    Public Class RunnerViewModel
        Inherits ViewModelBase

        Private _runnerName As String
        Private _runnerTwitch As String
        Private _scale As Double = 1


        Public ReadOnly Property TimerCrop As CropViewModel = New CropViewModel
        Public ReadOnly Property GameCrop As CropViewModel = New CropViewModel
        Public ReadOnly Property Size As SizeViewModel = New SizeViewModel
        Public ReadOnly Property CurrentSize As SizeViewModel = New SizeViewModel

        Public Property Name As String
            Get
                Return _runnerName
            End Get
            Set
                SetField(_runnerName, Value)
            End Set
        End Property

        Public Property Twitch As String
            Get
                Return _runnerTwitch
            End Get
            Set
                SetField(_runnerTwitch, Value)
            End Set
        End Property

        Public Property Scale As Double
            Get
                Return _scale
            End Get
            Set
                SetField(_scale, Value)
            End Set
        End Property


    End Class
End Namespace