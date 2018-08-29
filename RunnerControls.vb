Imports ALTTPRCropDashboard.Data.ViewModels
Imports ALTTPRCropDashboard.DB
Imports System.IO
Imports OBSWebsocketDotNet
Imports System.Globalization
Imports System.Configuration

Public Class RunnerControls
    Private ReadOnly _viewModel As New CropperViewModel
    Public Shared ReuseInfo As Boolean
    Private ReadOnly _cropperMath As New CropperMath

    Private Const ApprovedChars As String = "0123456789"

    Public Shared gameSource As String
    Public Shared timerSource As String
    Public Shared streamLinkParams As String
    Public Shared runnerNameSource As String
    Public Shared trackerSource As String

    Public Shared PositionYTimer As Integer
    Public Shared PositionYGame As Integer
    Public Shared positionXTimer As Integer
    Public Shared positionXGame As Integer

    Public Shared BoundingSizeTimer As Rectangle
    Public Shared BoundingSizeGame As Rectangle

    Private _vlcList As New DataSet


#Region " Button Clicks "
    Private Sub btnGameUncrop_Click(sender As Object, e As EventArgs) Handles btnGameUncrop.Click
        If Not String.IsNullOrWhiteSpace(gameSource) Then
            Uncrop(gameSource)
        End If
    End Sub
    Private Sub btnGameDB_Click(sender As Object, e As EventArgs) Handles btnGameDB.Click
        ClearTextBoxes("Game")
        RefreshCropFromData("Game")
    End Sub
    Private Sub btnSaveCrop_Click(sender As Object, e As EventArgs) Handles btnSaveCrop.Click
        SaveRunnerCrop()
    End Sub
    Private Sub btnSetCrop_Click(sender As Object, e As EventArgs) Handles btnSetCrop.Click

    End Sub
    Private Sub btnGetCrop_Click(sender As Object, e As EventArgs) Handles btnGetCrop.Click
        Try
            If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ObsWebSocketCropper.ProgramName) = MsgBoxResult.Yes Then
                FillCurrentCropInfoFromObs()
            End If
        Catch ex As ErrorResponseException
            MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
        End Try
    End Sub
    Private Sub btnNewRunner_Click(sender As Object, e As EventArgs) Handles btnNewRunner.Click
        AddNewRunner()
    End Sub
    Private Sub btnTimerDB_Click(sender As Object, e As EventArgs) Handles btnTimerDB.Click
        ClearTextBoxes("Timer")
        RefreshCropFromData("Timer")
    End Sub
    Private Sub btnTimerUncrop_Click(sender As Object, e As EventArgs) Handles btnTimerUncrop.Click
        If Not String.IsNullOrWhiteSpace(timerSource) Then
            Uncrop(timerSource)
        End If
    End Sub
    Private Sub btnSetVLC_Click(sender As Object, e As EventArgs) Handles btnSetVLC.Click
        SetVlcWindows()
    End Sub
#End Region
#Region " Crop Math / Crop Settings "

    Public Sub SaveRunnerCrop()

        Dim needsRefresh = False
        Dim submitterName = My.Settings.TwitchChannel
        Dim runnerVm As RunnerViewModel

        runnerVm = _viewModel.Runner

        Dim runnerTwitch = runnerVm.Twitch
        Dim runnerName = runnerVm.Name

        'GetCurrentCropSettings() 

        Dim savedMasterSize = runnerVm.MasterSize.AsSize()
        Dim masterSizeWithoutDefaultRight As Size = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(savedMasterSize, runnerVm.Scale))
        Dim cropWithoutDefaultGame As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(runnerVm.GameCrop.AsRectangle(), savedMasterSize, runnerVm.Scale))
        Dim cropWithoutDefaultTimer As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(runnerVm.TimerCrop.AsRectangle(), savedMasterSize, runnerVm.Scale))

        Using context As New CropDbContext
            If Not String.IsNullOrWhiteSpace(runnerTwitch) Then
                Dim runner = context.Crops.FirstOrDefault(Function(x) x.Submitter = submitterName AndAlso x.Runner = runnerTwitch)
                If runner Is Nothing Then
                    'Swap with twitch name
                    runner = New Crop With {
                        .Submitter = submitterName,
                        .Runner = runnerTwitch,
                        .Id = Guid.NewGuid()
                        }
                    context.Crops.Add(runner)
                    needsRefresh = True
                End If

                runner.GameCropTop = cropWithoutDefaultGame.Top
                runner.GameCropBottom = cropWithoutDefaultGame.Bottom
                runner.GameCropRight = cropWithoutDefaultGame.Right
                runner.GameCropLeft = cropWithoutDefaultGame.Left
                runner.TimerCropTop = cropWithoutDefaultTimer.Top
                runner.TimerCropBottom = cropWithoutDefaultTimer.Bottom
                runner.TimerCropRight = cropWithoutDefaultTimer.Right
                runner.TimerCropLeft = cropWithoutDefaultTimer.Left
                runner.SizeHeight = masterSizeWithoutDefaultRight.Height
                runner.SizeWidth = masterSizeWithoutDefaultRight.Width
                runner.SubmittedOn = Nothing
                runner.RunnerName = runnerName

                context.SaveChanges()
            End If
        End Using

        If needsRefresh Then
            RefreshRunnerNames()
        End If
    End Sub

#End Region
#Region " Runner Drop Downs "
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

#End Region
#Region " Label Clicks "
    Private Sub lblViewOnTwitch_Click(sender As Object, e As EventArgs) Handles lblViewOnTwitch.Click
        If Not String.IsNullOrWhiteSpace(_viewModel.Runner.Twitch) Then
            Process.Start("https://twitch.tv/" & _viewModel.Runner.Twitch)
        End If
    End Sub
    Private Sub lblStreamlink_Click(sender As Object, e As EventArgs) Handles lblStreamlink.Click
        If Not String.IsNullOrWhiteSpace(_viewModel.Runner.Twitch) Then
            StartStreamlink(_viewModel.Runner.Twitch)
        Else
            MsgBox("No Runner selected, cannot continue.")
        End If
    End Sub
    Private Sub lblVOD_Click(sender As Object, e As EventArgs) Handles lblVOD.Click
        If Not String.IsNullOrWhiteSpace(_viewModel.Runner.Twitch) Then
            Process.Start("https://twitch.tv/" & _viewModel.Runner.Twitch & "/videos/all")
        End If
    End Sub

#End Region
#Region " Misc Functions "
    Private Sub RunnerControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateNewSourceTable()
        ConfigureDataBindings()
        SetLabels()
    End Sub
    Private Sub RegisterCropBindings(cropVm As CropViewModel, leftControl As Control, topControl As Control, bottomControl As Control, rightControl As Control)
        leftControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Left), False, DataSourceUpdateMode.OnPropertyChanged)
        topControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Top), False, DataSourceUpdateMode.OnPropertyChanged)
        bottomControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Bottom), False, DataSourceUpdateMode.OnPropertyChanged)
        rightControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Right), False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Public Sub RefreshRunnerNames()
        Dim tempRunner As String = cbRunnerName.Text

        ReuseInfo = False

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.RunnerName}).Distinct().ToList().OrderBy(Function(r) r.RacerName, StringComparer.CurrentCultureIgnoreCase).ToList()
            cbRunnerName.DataSource = validNames
        End Using

        cbRunnerName.Text = tempRunner

        ReuseInfo = True

    End Sub
    Private Sub RegisterExpertModeFeatures(ParamArray features() As Control)
        For Each control In features
            control.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        Next
    End Sub
    Public Sub ConfigureDataBindings()
        RegisterExpertModeFeatures(lblViewOnTwitch, lblVOD, lblStreamlink)
        RegisterExpertModeFeatures(btnTimerDB, btnGameDB)
        RegisterExpertModeFeatures(lblScaling, cbScaling)

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
        If Not ObsWebSocketCropper.Obs.IsConnected Then
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
                Dim initialSize = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(ObsWebSocketCropper.GetMasterSize(gameSource), scaling))
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
    Private Sub AddNewRunner()
        ObsWebSocketCropper.NewRunnerName = ""
        ObsWebSocketCropper.NewRunnerTwitch = ""
        ObsWebSocketCropper.GetObsInfo = False
        ReuseInfo = True

        Dim dResult = NewRunner.ShowDialog(Me)
        Dim runnerNameField As ComboBox

        runnerNameField = cbRunnerName

        Dim runnerTwitchField As Label

        runnerTwitchField = lblRunnerTwitch

        If dResult = DialogResult.OK Then
            Dim runnerVm As RunnerViewModel

            runnerVm = _viewModel.Runner

            If Not String.IsNullOrWhiteSpace(ObsWebSocketCropper.NewRunnerName) Then
                runnerVm.Name = ObsWebSocketCropper.NewRunnerName
                runnerNameField.Text = ObsWebSocketCropper.NewRunnerName
            End If

            runnerVm.Twitch = If(String.IsNullOrWhiteSpace(ObsWebSocketCropper.NewRunnerTwitch), ObsWebSocketCropper.NewRunnerName, ObsWebSocketCropper.NewRunnerTwitch)
            runnerTwitchField.Text = "Twitch: " & runnerVm.Twitch

            If ObsWebSocketCropper.GetObsInfo = True Then
                If runnerVm.MasterSize.Height = 0 OrElse runnerVm.MasterSize.Width = 0 Then
                    runnerVm.MasterSize.UpdateFromSize(ObsWebSocketCropper.GetMasterSize(gameSource))
                End If

                Try
                    'SetMath()
                Catch ex As ErrorResponseException
                    MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
                End Try
            End If
        End If

        ObsWebSocketCropper.GetObsInfo = False
        ReuseInfo = True
    End Sub
    Private Sub StartStreamlink(twitch As String)
        Dim replacedPath = My.Settings.StreamlinkPath?.Replace("%LOCALAPPDATA%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
        If replacedPath Is Nothing OrElse Not File.Exists(replacedPath) Then
            Dim initialPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Streamlink", "bin")
            Dim fsDialog As New OpenFileDialog
            fsDialog.FileName = "streamlink.exe"
            fsDialog.Title = "Please provide the path to streamlink.exe"
            fsDialog.Filter = "Exe files |*.exe"
            fsDialog.InitialDirectory = initialPath
            fsDialog.CheckFileExists = True

            Dim result = fsDialog.ShowDialog(Me)

            If result <> DialogResult.OK OrElse Not File.Exists(fsDialog.FileName) Then
                Exit Sub
            End If

            My.Settings.StreamlinkPath = fsDialog.FileName
            My.Settings.Save()

            replacedPath = fsDialog.FileName
        End If

        Dim streamLinkArguments As String = $"--player-args=""--file-caching 2000 --no-one-instance --network-caching 2000 --input-title-format {twitch} {{filename}}"" https://www.twitch.tv/{twitch} best --player-continuous-http --player-no-close"

        Dim customArgs As String

        customArgs = streamLinkParams

        If Not String.IsNullOrWhiteSpace(customArgs) Then
            streamLinkArguments = customArgs
        End If

        Dim myProcess = New Process
        myProcess.StartInfo = New ProcessStartInfo With {
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .FileName = replacedPath,
            .Arguments = streamLinkArguments,
        .RedirectStandardError = False,
            .RedirectStandardOutput = True
                        }

        myProcess.Start()
    End Sub
    Public Sub RefreshCropperDefaultCrop()
        _cropperMath.DefaultCrop = Rectangle.FromLTRB(0, My.Settings.DefaultCropTop, 0, My.Settings.DefaultCropBottom)
    End Sub
    Private Sub Uncrop(ByVal sourceName As String)
        ObsWebSocketCropper.DispatchToObs(Sub(o) o.SetSceneItemProperties(sourceName, 0 + My.Settings.DefaultCropTop, 0 + My.Settings.DefaultCropBottom, 0, 0, 0, 0, 0, 0))
    End Sub
    Public Sub FillCurrentCropInfoFromObs()

        Dim sceneName As String = If(ObsWebSocketCropper.Obs.StudioModeEnabled, ObsWebSocketCropper.Obs.GetPreviewScene().Name, ObsWebSocketCropper.Obs.GetCurrentScene().Name)

        Dim runnerVm As RunnerViewModel

        runnerVm = _viewModel.Runner

        runnerVm.MasterSize.UpdateFromSize(ObsWebSocketCropper.GetMasterSize(gameSource))

        If Not String.IsNullOrWhiteSpace(timerSource) Then
            runnerVm.TimerCrop.UpdateFromRectangle(ObsWebSocketCropper.Obs.GetSceneItemProperties(sceneName, timerSource).Crop)
        End If
        If Not String.IsNullOrWhiteSpace(gameSource) Then
            runnerVm.GameCrop.UpdateFromRectangle(ObsWebSocketCropper.Obs.GetSceneItemProperties(sceneName, gameSource).Crop)
        End If

    End Sub
    Private Sub cbRightScaling_TextChanged(sender As Object, e As EventArgs) Handles cbScaling.TextChanged
        AdjustScaling(_viewModel.RightRunner, ParsePercent(cbScaling.Text))
    End Sub
    Private Sub AdjustScaling(runnerVm As RunnerViewModel, newScale As Double)
        If Math.Abs(newScale - runnerVm.Scale) < 0.0001 OrElse Math.Abs(runnerVm.Scale) < 0.0001 Then
            Exit Sub
        End If

        Dim newSize = _cropperMath.AddScaling(_cropperMath.RemoveScaling(runnerVm.MasterSize.AsSize(), runnerVm.Scale), newScale)
        runnerVm.GameCrop.UpdateFromRectangle(TransScale(runnerVm.GameCrop.AsRectangle(),
                                                         runnerVm.MasterSize.AsSize(),
                                                         runnerVm.Scale,
                                                         newSize,
                                                         newScale))
        runnerVm.TimerCrop.UpdateFromRectangle(TransScale(runnerVm.TimerCrop.AsRectangle(),
                                                          runnerVm.MasterSize.AsSize(),
                                                          runnerVm.Scale,
                                                          newSize,
                                                          newScale))
        runnerVm.MasterSize.UpdateFromSize(newSize)
        runnerVm.Scale = newScale
    End Sub
    Private Function ParsePercent(percent As String) As Double
        If (String.IsNullOrWhiteSpace(percent)) Then
            Return 1
        End If

        Return Double.Parse(percent.Replace("%", "")) / 100.0
    End Function
    Private Function TransScale(rect As Rectangle, originalSize As Size, originalScaling As Double, newSize As Size, newScaling As Double) As Rectangle
        Return _cropperMath.AddScaling(_cropperMath.RemoveScaling(rect, originalSize, originalScaling), newSize, newScaling)
    End Function
    Private Sub SetVlcWindows()

        Dim vlcSource As String
        Dim vmRunner As RunnerViewModel

        vlcSource = cbVLCSource.Text
        vmRunner = _viewModel.Runner

        If Not String.IsNullOrWhiteSpace(vlcSource) Then
            vlcSource = vlcSource.Replace(":", "#3A") & ":QWidget:vlc.exe"
            If Not String.IsNullOrWhiteSpace(gameSource) Then
                ObsWebSocketCropper.DispatchToObs(Sub(o) o.SetSourceSettings(gameSource, False, vlcSource, 1))
            End If
            If Not String.IsNullOrWhiteSpace(timerSource) Then
                ObsWebSocketCropper.DispatchToObs(Sub(o) o.SetSourceSettings(timerSource, False, vlcSource, 1))
            End If

            'GetCurrentCropSettings()

        End If

    End Sub
    Public Sub RefreshVlc()
        Dim vlcProcesses = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("vlc", True, Globalization.CultureInfo.InvariantCulture)).ToList()
        If Not vlcProcesses.Any() Then
            Exit Sub
        End If

        Dim Vlc As String


        If Not String.IsNullOrWhiteSpace(cbVLCSource.Text) Then
            Vlc = cbVLCSource.Text
        Else
            Vlc = ""
        End If

        _vlcList.Clear()

        Dim data = vlcProcesses.Select(Function(v) New With {.VLCName = v.MainWindowTitle}).ToList()

        cbVLCSource.DataSource = data.ToList()
        cbVLCSource.DisplayMember = "VLCName"
        cbVLCSource.ValueMember = "VLCName"

        cbVLCSource.Text = ""


        If Not String.IsNullOrWhiteSpace(lblRunnerTwitch.Text) Then
            Dim tempText = lblRunnerTwitch.Text.Remove(0, 8)
            Dim match = data.FirstOrDefault(Function(d) d.VLCName.StartsWith(tempText, True, CultureInfo.InvariantCulture))

            If match IsNot Nothing Then
                cbVLCSource.Text = match.VLCName
            End If
        End If

    End Sub
    Private Sub CreateNewSourceTable()
        If _vlcList.Tables.Count = 0 Then
            _vlcList.Tables.Add("Processes")
            _vlcList.Tables("Processes").Columns.Add("VLCName")
        Else
            _vlcList.Tables("Processes").Clear()
        End If
    End Sub
    Private Sub ValidateKeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles txtCropTimer_Top.KeyPress, txtCropTimer_Right.KeyPress,
                txtCropTimer_Left.KeyPress, txtCropTimer_Bottom.KeyPress,
                txtCropGame_Top.KeyPress, txtCropGame_Right.KeyPress,
                txtCropGame_Left.KeyPress, txtCropGame_Bottom.KeyPress

        e.Handled = ObsWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Public Sub SetTracker()
        If Not String.IsNullOrWhiteSpace(trackerSource) AndAlso Not String.IsNullOrWhiteSpace(txtTrackerURL.Text) Then
            Dim TrackerURL = If(ConfigurationManager.AppSettings("TrackerURL"), "")
            Dim trackerString As String
            If txtTrackerURL.Text.ToLower.StartsWith("http") Then
                trackerString = txtTrackerURL.Text
            Else
                trackerString = TrackerURL & txtTrackerURL.Text
            End If

            ObsWebSocketCropper.DispatchToObs(Sub(o) o.SetBrowserSource(My.Settings.LeftTrackerOBS, trackerString))
        End If
    End Sub
    Private Sub SetLabels()
        gameSource = lblGameSource.Text
    End Sub
#End Region

End Class
