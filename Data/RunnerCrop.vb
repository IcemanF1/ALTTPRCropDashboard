Imports OBSWebsocketDotNet

Namespace Data

    Public Class RunnerCrop
        Public Property Id As Guid?
        Public Property TimerCrop As SceneItemCropInfo
        Public Property GameCrop As SceneItemCropInfo
        Public Property Size As WindowSize
        Public Property Submitter As String
        Public Property SubmittedOn As DateTime?
        Public Property RunnerName As String
    End Class
End Namespace