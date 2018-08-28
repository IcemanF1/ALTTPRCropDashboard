Imports ALTTPRCropDashboard.Data.ViewModels
Imports ALTTPRCropDashboard.DB

Public Class RunnerControls
    Private ReadOnly _viewModel As New CropperViewModel
    Public Shared ReuseInfo As Boolean
    Private ReadOnly _cropperMath As New CropperMath

    Private Sub RunnerControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConfigureDataBindings()
        RefreshRunnerNames()
    End Sub
    Private Sub lblStreamlink_Click(sender As Object, e As EventArgs) Handles lblStreamlink.Click

    End Sub
    Private Sub RegisterCropBindings(cropVm As CropViewModel, leftControl As Control, topControl As Control, bottomControl As Control, rightControl As Control)
        leftControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Left), False, DataSourceUpdateMode.OnPropertyChanged)
        topControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Top), False, DataSourceUpdateMode.OnPropertyChanged)
        bottomControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Bottom), False, DataSourceUpdateMode.OnPropertyChanged)
        rightControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Right), False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub RefreshRunnerNames()
        Dim tempRunner As String = cbRunnerName.Text

        ReuseInfo = False

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.RunnerName}).Distinct().ToList().OrderBy(Function(r) r.RacerName, StringComparer.CurrentCultureIgnoreCase).ToList()
            cbRunnerName.DataSource = validNames
        End Using

        cbRunnerName.Text = tempRunner

        ReuseInfo = True

    End Sub
    Private Sub ConfigureDataBindings()
        RegisterCropBindings(_viewModel.Runner.GameCrop,
             txtCropGame_Left,
             txtCropGame_Top,
             txtCropGame_Bottom,
             txtCropGame_Right)
        RegisterCropBindings(_viewModel.Runner.TimerCrop,
             txtCropTimer_Left,
             txtCropTimer_Top,
             txtCropTimer_Bottom,
             txtCropTimer_Right)
    End Sub
    Private Sub lblViewOnTwitch_Click(sender As Object, e As EventArgs) Handles lblViewOnTwitch.Click
        If Not String.IsNullOrWhiteSpace(_viewModel.Runner.Twitch) Then
            Process.Start("https://twitch.tv/" & _viewModel.Runner.Twitch)
        End If
    End Sub
    Private Sub cbLeftRunner_KeyUp(sender As Object, e As KeyEventArgs) Handles cbRunnerName.KeyUp
        Dim index As Integer
        Dim actual As String
        Dim found As String

        If ((e.KeyCode = Keys.Back) Or
    (e.KeyCode = Keys.Left) Or
    (e.KeyCode = Keys.Right) Or
    (e.KeyCode = Keys.Up) Or
    (e.KeyCode = Keys.Delete) Or
    (e.KeyCode = Keys.Down) Or
    (e.KeyCode = Keys.PageUp) Or
    (e.KeyCode = Keys.PageDown) Or
    (e.KeyCode = Keys.Home) Or
    (e.KeyCode = Keys.End)) Then

            Return
        End If

        ' Store the actual text that has been typed.
        actual = cbRunnerName.Text

        ' Find the first match for the typed value.
        index = cbRunnerName.FindString(actual)

        ' Get the text of the first match.
        If (index > -1) Then
            found = cbRunnerName.Items(index).ToString()

            ' Select this item from the list.
            cbRunnerName.SelectedIndex = index

            ' Select the portion of the text that was automatically
            ' added so that additional typing will replace it.
            cbRunnerName.SelectionStart = actual.Length
            cbRunnerName.SelectionLength = found.Length
        End If
    End Sub
    Private Sub cbLeftRunner_TextChanged(sender As Object, e As EventArgs) Handles cbRunnerName.TextChanged
        If ReuseInfo = True Then
            _viewModel.Runner.Name = cbRunnerName.Text
            ClearTextBoxes("Both")
            RefreshCropFromData("Both")
        End If
    End Sub
    Private Sub ClearTextBoxes(refreshAction As String)
        Dim runnerVm As RunnerViewModel

        runnerVm = _viewModel.Runner

        If refreshAction = "Both" OrElse refreshAction = "Game" Then
            runnerVm.GameCrop.UpdateFromRectangle(Rectangle.Empty)
        End If
        If refreshAction = "Both" OrElse refreshAction = "Timer" Then
            runnerVm.TimerCrop.UpdateFromRectangle(Rectangle.Empty)
        End If
    End Sub
    Private Sub RefreshCropFromData(ByVal refreshAction As String)
        If Not ObsWebSocketCropper._viewModel.ObsConnected Then
            Return
        End If

        Dim savedMasterSize As Size
        Dim realMasterSize As Size
        Dim scaling As Double
        Dim savedCrop As Rectangle
        Dim realCrop As Rectangle

        Dim runnerVm As RunnerViewModel

        runnerVm = _viewModel.Runner

        Dim runnerName As String

        runnerName = cbRunnerName.Text

        Using context As New CropDbContext
            Dim runnerInfo As Crop

            scaling = runnerVm.Scale
            runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.RunnerName = runnerName)
            If runnerInfo Is Nothing Then
                runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.RunnerName = runnerName)
            End If
            If runnerInfo Is Nothing Then
                runnerInfo = New Crop
                Dim initialSize = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(GetMasterSize(), scaling))
                runnerInfo.SizeWidth = initialSize.Width
                runnerInfo.SizeHeight = initialSize.Height

            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.TimerCropLeft, runnerInfo.TimerCropTop, runnerInfo.TimerCropRight, runnerInfo.TimerCropBottom)
            realCrop = _cropperMath.AddDefaultCrop(savedCrop)

            savedMasterSize = New Size(runnerInfo.SizeWidth, runnerInfo.SizeHeight)

            If refreshAction = "Both" Or refreshAction = "Timer" Then
                realMasterSize = _cropperMath.AddScaling(_cropperMath.AddDefaultCropSize(savedMasterSize), scaling)
                realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, runnerVm.Scale)
                runnerVm.TimerCrop.UpdateFromRectangle(realCrop)
            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.GameCropLeft, runnerInfo.GameCropTop, runnerInfo.GameCropRight, runnerInfo.GameCropBottom)
            realCrop = _cropperMath.AddDefaultCrop(savedCrop)

            If refreshAction = "Both" Or refreshAction = "Game" Then
                realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, scaling)
                runnerVm.GameCrop.UpdateFromRectangle(realCrop)
                runnerVm.Twitch = runnerInfo.Runner
            End If

            lblRunnerTwitch.Text = "Twitch: " & runnerVm.Twitch

            runnerVm.MasterSize.UpdateFromSize(realMasterSize)
            runnerVm.Scale = scaling
        End Using

        'SetHeightLabels()
    End Sub
    Private Function GetMasterSize() As Size


        If String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
            Return Size.Empty
        End If

        Dim currentScene = If(ObsWebSocketCropper.Obs.StudioModeEnabled, ObsWebSocketCropper.Obs.GetPreviewScene(), ObsWebSocketCropper.Obs.GetCurrentScene())

        Dim target As String

        target = My.Settings.LeftGameName.ToLower

        Dim adequateSource = currentScene.Items.FirstOrDefault(Function(scene) scene.SourceName.ToLower = target)

        If adequateSource.SourceName Is Nothing OrElse String.IsNullOrWhiteSpace(adequateSource.SourceName) Then
            MessageBox.Show(Me, $"Cannot find source {target} in the current scene. Are you on the right scene?")
        End If

        Return New Size(adequateSource.SourceWidth, adequateSource.SourceHeight)

    End Function

End Class
