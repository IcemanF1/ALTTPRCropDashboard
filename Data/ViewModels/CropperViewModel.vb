Namespace Data.ViewModels
    Public Class CropperViewModel
        Inherits ViewModelBase

        Private _obsConnected As Boolean

        Public ReadOnly Property LeftRunner As RunnerViewModel = New RunnerViewModel
        Public ReadOnly Property RightRunner As RunnerViewModel = New RunnerViewModel
        Public ReadOnly Property Runner As RunnerViewModel = New RunnerViewModel

        Public ReadOnly Property Runner1 As RunnerViewModel = New RunnerViewModel
        Public ReadOnly Property Runner2 As RunnerViewModel = New RunnerViewModel
        Public ReadOnly Property Runner3 As RunnerViewModel = New RunnerViewModel
        Public ReadOnly Property Runner4 As RunnerViewModel = New RunnerViewModel

        Public Property ObsConnected As Boolean
            Get
                Return _obsConnected
            End Get
            Set
                SetField(_obsConnected, Value)
            End Set
        End Property
    End Class
End Namespace