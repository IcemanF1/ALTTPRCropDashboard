Imports System.Configuration
Imports OBSWebsocketDotNet
Imports ALTTPRCropDashboard.Data
Imports ALTTPRCropDashboard.DB
Imports System.IO
Imports ALTTPRCropDashboard.Data.ViewModels
Imports System.Globalization


Public Class ObsWebSocketCropper
    Public ProgramName As String = "OBS WebSocket Cropper"
    Private isLoaded As Boolean
    Private _configInfo As New DataSet

    Public WithEvents Obs As New ObsWebSocketPlus
    Private WithEvents _obs2 As New ObsWebSocketPlus

    Private Const ApprovedChars As String = "0123456789"

    Public ObsConnectionStatus As String
    Public ObsConnectionStatus2 As String

    Public ReadOnly Property ConnectionString As String
        Get
            Return My.Settings.ConnectionString1 & ":" & My.Settings.ConnectionPort1
        End Get
    End Property
    Public ReadOnly Property ConnectionString2 As String
        Get
            Return My.Settings.ConnectionString2 & ":" & My.Settings.ConnectionPort2
        End Get
    End Property

    Public Shared ObsSettingsResult As String
    Public Shared NewRunnerName As String
    Public Shared NewRunnerTwitch As String
    Public Shared GetObsInfo As Boolean
    Public Shared ReuseInfo As Boolean

    Private _cropApi As CropApi
    Private ReadOnly _cropperMath As New CropperMath
    Private _vlcListLeft As New DataSet
    Private _vlcListRight As New DataSet
    Private _vlcListLeftBottom As New DataSet
    Private _vlcListRightBottom As New DataSet
    Private ReadOnly _viewModel As New CropperViewModel

    'Public WithEvents RControl1 As New RunnerControls
    'Public WithEvents RControl2 As New RunnerControls
    'Public WithEvents RControl3 As New RunnerControls
    'Public WithEvents RControl4 As New RunnerControls

    Private _check2NdObs As Boolean
    Private _lastUpdate As Integer

#Region " Button Clicks "
    Private Sub btnConnectOBS1_Click(sender As Object, e As EventArgs) Handles btnConnectOBS1.Click
        ConnectToObs()
    End Sub
    Private Sub btnSetTrackCommNames_Click(sender As Object, e As EventArgs) Handles btnSetTrackCommNames.Click
        'If Not String.IsNullOrWhiteSpace(My.Settings.LeftRunnerOBS) AndAlso Not String.IsNullOrWhiteSpace(RControl1.cbRunnerName.Text) Then
        '    DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.LeftRunnerOBS, RControl1.cbRunnerName.Text))
        'End If
        'If Not String.IsNullOrWhiteSpace(My.Settings.RightRunnerOBS) AndAlso Not String.IsNullOrWhiteSpace(RControl2.cbRunnerName.Text) Then
        '    DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.RightRunnerOBS, RControl2.cbRunnerName.Text))
        'End If
        'If Not String.IsNullOrWhiteSpace(My.Settings.LeftRunnerOBS) AndAlso Not String.IsNullOrWhiteSpace(RControl3.cbRunnerName.Text) Then
        '    DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.LeftRunnerOBS, RControl3.cbRunnerName.Text))
        'End If
        'If Not String.IsNullOrWhiteSpace(My.Settings.RightRunnerOBS) AndAlso Not String.IsNullOrWhiteSpace(RControl4.cbRunnerName.Text) Then
        '    DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.RightRunnerOBS, RControl4.cbRunnerName.Text))
        'End If

        If Not String.IsNullOrWhiteSpace(My.Settings.CommentaryOBS) AndAlso Not String.IsNullOrWhiteSpace(txtCommentaryNames.Text) Then
            DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.CommentaryOBS, txtCommentaryNames.Text))
        End If
        If Not String.IsNullOrWhiteSpace(My.Settings.GameSettings) AndAlso Not String.IsNullOrWhiteSpace(txtGameSettings.Text) Then
            DispatchToObs(Sub(o) o.SetTextGdi(My.Settings.GameSettings, txtGameSettings.Text))
        End If

        'SetTracker(1, RControl1.trackerURL)
        'SetTracker(2, RControl2.trackerURL)
        'SetTracker(3, RControl3.trackerURL)
        'SetTracker(4, RControl4.trackerURL)
    End Sub
    Private Sub ObsConnectionChanged(sender As Object, e As EventArgs) Handles Obs.Connected, Obs.Disconnected
        'RefreshVlc()
        ObsConnectionStatus = If(Obs.IsConnected, "Connected", "Not Connected")
        _viewModel.ObsConnected = Obs.IsConnected
        lblOBS1ConnectedStatus.Text = ObsConnectionStatus

        If Not _viewModel.ObsConnected Then
            'If our primary OBS connection died, then the secondary connection is also no longer useful.
            DispatchToObs(Sub(o) o.Disconnect())
        End If
    End Sub
    Private Sub Obs2ConnectionChanged(sender As Object, e As EventArgs) Handles _obs2.Connected, _obs2.Disconnected
        ObsConnectionStatus2 = If(_obs2.IsConnected, "Connected", "Not Connected")
        lblOBS2ConnectedStatus.Text = ObsConnectionStatus
    End Sub
    Private Sub btnSyncWithServer_Click(sender As Object, e As EventArgs) Handles btnSyncWithServer.Click
        SyncWithServer()
    End Sub
    Private Sub SyncWithServer()
        Cursor = Cursors.WaitCursor
        Try
            If Not String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings("ServerURL")) Then
                _cropApi = New CropApi(ConfigurationManager.AppSettings("ServerURL"))

                SendToServer()
                GetSyncFromServer()
            Else
                MsgBox("You are missing the API config file.  Please ask someone in the restream channel in discord if you believe you should need this file.", MsgBoxStyle.OkOnly, ProgramName)
            End If
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnGetProcesses_Click(sender As Object, e As EventArgs) Handles btnGetProcesses.Click
        RefreshVlc()
    End Sub
    ''' <summary>
    ''' Call the same code on all connected OBS instances
    ''' </summary>
    ''' <param name="callback">The code to execute</param>
    Public Sub DispatchToObs(callback As Action(Of ObsWebSocketPlus))
        If callback Is Nothing Then
            Exit Sub
        End If

        If Obs.IsConnected Then
            callback(Obs)
        End If
        If _obs2.IsConnected Then
            callback(_obs2)
        End If

    End Sub
    Private Sub btn2ndOBS_Click(sender As Object, e As EventArgs) Handles btn2ndOBS.Click
        GetIniFile(False, False)

        _check2NdObs = True
        Timer1.Start()


    End Sub
    Private Sub btnConnectOBS2_Click(sender As Object, e As EventArgs) Handles btnConnectOBS2.Click
        ConnectToObs2()
    End Sub

#End Region
#Region " Crop Math / Crop Settings "
    Public Sub GetCrop(runnerNumber As Integer)
        Try
            If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                FillCurrentCropInfoFromObs(runnerNumber)
            End If
        Catch ex As ErrorResponseException
            MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
        End Try
    End Sub
    Public Sub SaveRunnerCrop(runnerNumber As Integer)

        Dim needsRefresh = False
        Dim submitterName = My.Settings.TwitchChannel
        Dim runnerVm As RunnerViewModel

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

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
    Public Sub FillCurrentCropInfoFromObs(runnerNumber As Integer)

        Dim sceneName As String = If(Obs.StudioModeEnabled, Obs.GetPreviewScene().Name, Obs.GetCurrentScene().Name)

        Dim runnerVm As RunnerViewModel
        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)
        Dim timerSource = GlobalParam.GetTimerSource(runnerNumber)

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        runnerVm.MasterSize.UpdateFromSize(GetMasterSize(gameSource))

        If Not String.IsNullOrWhiteSpace(timerSource) Then
            runnerVm.TimerCrop.UpdateFromRectangle(Obs.GetSceneItemProperties(sceneName, timerSource).Crop)
        End If
        If Not String.IsNullOrWhiteSpace(gameSource) Then
            runnerVm.GameCrop.UpdateFromRectangle(Obs.GetSceneItemProperties(sceneName, gameSource).Crop)
        End If

    End Sub
    Private Sub Uncrop(ByVal sourceName As String)
        DispatchToObs(Sub(o) o.SetSceneItemProperties(sourceName, 0 + My.Settings.DefaultCropTop, 0 + My.Settings.DefaultCropBottom, 0, 0, 0, 0, 0, 0))
    End Sub
    Public Sub UncropSource(runnerNumber As Integer, isTimer As Boolean)
        Dim obsSourceName As String

        If isTimer Then
            obsSourceName = GlobalParam.GetTimerSource(runnerNumber)
        Else
            obsSourceName = GlobalParam.GetGameSource(runnerNumber)
        End If

        If Not String.IsNullOrWhiteSpace(obsSourceName) Then
            Uncrop(obsSourceName)
        End If
    End Sub
    Public Sub SetRunner(runnerNumber As Integer, runnerName As String)
        Select Case runnerNumber
            Case 1
                _viewModel.Runner1.Name = runnerName
            Case 2
                _viewModel.Runner2.Name = runnerName
            Case 3
                _viewModel.Runner3.Name = runnerName
            Case 4
                _viewModel.Runner4.Name = runnerName
        End Select


    End Sub
    Public Sub ClearTextBoxes(refreshAction As String, runnerNumber As Integer)
        Dim runnerVm As RunnerViewModel

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        If refreshAction = "Both" OrElse refreshAction = "Game" Then
            runnerVm.GameCrop.UpdateFromRectangle(Rectangle.Empty)
        End If
        If refreshAction = "Both" OrElse refreshAction = "Timer" Then
            runnerVm.TimerCrop.UpdateFromRectangle(Rectangle.Empty)
        End If
    End Sub
    Public Sub RefreshCropFromData(ByVal refreshAction As String, runnerNumber As Integer, runnerName As String)
        If Not Obs.IsConnected Then
            Return
        End If

        Dim savedMasterSize As Size
        Dim realMasterSize As Size
        Dim scaling As Double
        Dim savedCrop As Rectangle
        Dim realCrop As Rectangle

        Dim runnerVm As RunnerViewModel
        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        Using context As New CropDbContext
            Dim runnerInfo As Crop

            scaling = runnerVm.Scale
            runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.RunnerName = runnerName)
            If runnerInfo Is Nothing Then
                runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.RunnerName = runnerName)
            End If
            If runnerInfo Is Nothing Then
                runnerInfo = New Crop
                Dim initialSize = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(GetMasterSize(gameSource), scaling))
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

            Select Case runnerNumber
                Case 1
                    rControl1.twitchName = "Twitch: " & runnerVm.Twitch
                Case 2
                    rControl2.twitchName = "Twitch: " & runnerVm.Twitch
                Case 3
                    rControl3.twitchName = "Twitch: " & runnerVm.Twitch
                Case 4
                    rControl4.twitchName = "Twitch: " & runnerVm.Twitch
            End Select

            runnerVm.MasterSize.UpdateFromSize(realMasterSize)
            runnerVm.Scale = scaling
        End Using

        'SetHeightLabels()
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
    Public Sub AdjustScalingTrigger(runnerNumber As Integer, scalingPercent As String)
        Dim runnerVm As RunnerViewModel

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        AdjustScaling(_viewModel.RightRunner, ParsePercent(scalingPercent))
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
#End Region

#Region " Refresh / Set User Info "
    Private Sub RefreshObs()
        Dim lObs = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("obs", True, Globalization.CultureInfo.InvariantCulture)).ToList()

        If lObs.Count > 1 Then
            Timer1.Stop()
            GetIniFile(False, True)
            _check2NdObs = False
        ElseIf lObs.Count = 1 Then
            Dim obsProcess As New ProcessStartInfo
            Dim workDirectory As String
            workDirectory = lObs.Item(0).MainModule.FileName.Remove(lObs.Item(0).MainModule.FileName.LastIndexOf("\"), lObs.Item(0).MainModule.FileName.Length - lObs.Item(0).MainModule.FileName.LastIndexOf("\"))

            obsProcess.FileName = lObs.Item(0).MainModule.FileName
            obsProcess.WorkingDirectory = workDirectory

            Process.Start(obsProcess)
        End If
    End Sub
    Private Sub RefreshVlc()
        'RControl1.RefreshVlc()
        'RControl2.RefreshVlc()
        'RControl3.RefreshVlc()
        'RControl4.RefreshVlc()
    End Sub
    Private Sub RefreshRunnerNames()
        rControl1.RefreshRunnerNames()
        rControl2.RefreshRunnerNames()
        rControl3.RefreshRunnerNames()
        rControl4.RefreshRunnerNames()
    End Sub
    Public Sub RefreshCropperDefaultCrop()
        _cropperMath.DefaultCrop = Rectangle.FromLTRB(0, My.Settings.DefaultCropTop, 0, My.Settings.DefaultCropBottom)
    End Sub
#End Region
#Region " Radio Buttons "
    Private Sub rb1Runner_CheckedChanged(sender As Object, e As EventArgs) Handles rb1Runner.CheckedChanged
        If rb1Runner.Checked = True Then
            rb2Runner.Checked = False
            rb3Runner.Checked = False
            rb4Runner.Checked = False

            SetControlsVisible(1)
        End If
    End Sub
    Private Sub rb2Runner_CheckedChanged(sender As Object, e As EventArgs) Handles rb2Runner.CheckedChanged
        If rb2Runner.Checked = True Then
            rb1Runner.Checked = False
            rb3Runner.Checked = False
            rb4Runner.Checked = False

            SetControlsVisible(2)
        End If
    End Sub
    Private Sub rb3Runner_CheckedChanged(sender As Object, e As EventArgs) Handles rb3Runner.CheckedChanged
        If rb3Runner.Checked = True Then
            rb2Runner.Checked = False
            rb1Runner.Checked = False
            rb4Runner.Checked = False

            SetControlsVisible(3)
        End If
    End Sub
    Private Sub rb4Runner_CheckedChanged(sender As Object, e As EventArgs) Handles rb4Runner.CheckedChanged
        If rb4Runner.Checked = True Then
            rb2Runner.Checked = False
            rb3Runner.Checked = False
            rb1Runner.Checked = False

            SetControlsVisible(4)
        End If
    End Sub
#End Region
#Region " Misc Functions "
    Private Sub RegisterExpertModeFeatures(ParamArray features() As Control)
        For Each control In features
            control.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        Next
    End Sub
    Private Sub RegisterFourPlayerMode(ParamArray features() As Control)
        For Each control In features
            control.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.FourPlayers), False, DataSourceUpdateMode.OnPropertyChanged)
        Next
    End Sub
    Private Sub RegisterObsDependency(ParamArray features() As Control)
        For Each control In features
            control.DataBindings.Add("Enabled", _viewModel, NameOf(_viewModel.ObsConnected), False, DataSourceUpdateMode.OnPropertyChanged)
        Next
    End Sub
    Private Sub RegisterCropBindings(cropVm As CropViewModel, leftControl As Control, topControl As Control, bottomControl As Control, rightControl As Control)
        leftControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Left), False, DataSourceUpdateMode.OnPropertyChanged)
        topControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Top), False, DataSourceUpdateMode.OnPropertyChanged)
        bottomControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Bottom), False, DataSourceUpdateMode.OnPropertyChanged)
        rightControl.DataBindings.Add("Text", cropVm, NameOf(cropVm.Right), False, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
    Private Sub ConfigureDataBindings()
        ' Expert mode only features
        RegisterExpertModeFeatures(chkAlwaysOnTop)
        RegisterExpertModeFeatures(lblOBS2ConnectedStatus, btnConnectOBS2, btn2ndOBS)

        chkAlwaysOnTop.DataBindings.Add("Checked", My.Settings, NameOf(My.Settings.AlwaysOnTop), False, DataSourceUpdateMode.OnPropertyChanged)
        DataBindings.Add("TopMost", My.Settings, NameOf(My.Settings.AlwaysOnTop), False, DataSourceUpdateMode.OnPropertyChanged)

        'All OBS dependencies

        RegisterObsDependency(btnGetProcesses)
        RegisterObsDependency(btnSetTrackCommNames)
        RegisterObsDependency(btnSyncWithServer, btn2ndOBS, btnConnectOBS2, btnResetDatabase)
        RegisterObsDependency(gbTrackerComms)

        RegisterCropBindings(_viewModel.Runner1.GameCrop,
            rControl1.txtCropGame_Left,
            rControl1.txtCropGame_Top,
            rControl1.txtCropGame_Bottom,
            rControl1.txtCropGame_Right)

        RegisterCropBindings(_viewModel.Runner1.TimerCrop,
             rControl1.txtCropTimer_Left,
             rControl1.txtCropTimer_Top,
             rControl1.txtCropTimer_Bottom,
             rControl1.txtCropTimer_Right)

        RegisterCropBindings(_viewModel.Runner2.GameCrop,
    rControl2.txtCropGame_Left,
    rControl2.txtCropGame_Top,
    rControl2.txtCropGame_Bottom,
    rControl2.txtCropGame_Right)

        RegisterCropBindings(_viewModel.Runner2.TimerCrop,
             rControl2.txtCropTimer_Left,
             rControl2.txtCropTimer_Top,
             rControl2.txtCropTimer_Bottom,
             rControl2.txtCropTimer_Right)

        RegisterCropBindings(_viewModel.Runner3.GameCrop,
    rControl3.txtCropGame_Left,
    rControl3.txtCropGame_Top,
    rControl3.txtCropGame_Bottom,
    rControl3.txtCropGame_Right)

        RegisterCropBindings(_viewModel.Runner3.TimerCrop,
             rControl3.txtCropTimer_Left,
             rControl3.txtCropTimer_Top,
             rControl3.txtCropTimer_Bottom,
             rControl3.txtCropTimer_Right)

        RegisterCropBindings(_viewModel.Runner4.GameCrop,
    rControl4.txtCropGame_Left,
    rControl4.txtCropGame_Top,
    rControl4.txtCropGame_Bottom,
    rControl4.txtCropGame_Right)

        RegisterCropBindings(_viewModel.Runner4.TimerCrop,
             rControl4.txtCropTimer_Left,
             rControl4.txtCropTimer_Top,
             rControl4.txtCropTimer_Bottom,
             rControl4.txtCropTimer_Right)
    End Sub
    Private Sub OBSWebScocketCropper_Load(sender As Object, e As EventArgs) Handles Me.Load
        isLoaded = False

        ReuseInfo = True
        lblOBS1ConnectedStatus.Text = "Not Connected"
        lblOBS2ConnectedStatus.Text = "Not Connected"

        AddUserControls()

        ConfigureDataBindings()

        If My.Settings.HasFinishedWelcome = False Then
            Dim uSettings As New UserSettings

            UserSettings.ShowVLCOption = True
            uSettings.ShowDialog(Me)

            If My.Settings.HasFinishedWelcome = False Then
                MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
                Close()
            End If

            CheckUnusedFields()

            If ObsSettingsResult = "VLC" Then
                VlcSettings.ShowDialog(Me)

            End If


            RefreshRunnerNames()
        Else
            RefreshRunnerNames()

            CheckUnusedFields()
        End If

        ExpertModeToolStripMenuItem.Checked = My.Settings.ExpertMode
        SetSourceNames()

        GlobalParam.RefreshConfigList()


        rb2Runner.Checked = True

        isLoaded = True
    End Sub
    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog(Me)
    End Sub
    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub ChangeVLCSettingsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangeVLCSettingsToolStripMenuItem.Click
        VlcSettings.ShowDialog(Me)

        RefreshCropperDefaultCrop()
    End Sub
    Private Sub ExpertModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpertModeToolStripMenuItem.Click
        My.Settings.ExpertMode = ExpertModeToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub
    Private Sub ChangeUserSettingsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangeUserSettingsToolStripMenuItem.Click
        Dim uSettings As New UserSettings

        UserSettings.ShowVLCOption = False
        uSettings.ShowDialog(Me)

        If My.Settings.HasFinishedWelcome = False Then
            MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
            Close()

        Else
            SetSourceNames()
            RefreshRunnerNames()
            RefreshCropperDefaultCrop()
            CheckUnusedFields()
        End If
    End Sub
    Private Sub GetSyncFromServer()

        Dim cropList As IEnumerable(Of RunnerInfo)
        Try
            cropList = _cropApi.GetCrops()

        Catch ex As Exception
            MessageBox.Show(Me, "Error While retrieving data from server: " & ex.ToString())
            Return
        End Try


        Using context As New CropDbContext

            Dim validGuids As New List(Of Guid)

            For Each runnerInfo In cropList
                Dim runnerInfoCopy = runnerInfo
                Dim existingCrops = context.Crops.Where(Function(x) x.Runner = runnerInfoCopy.Runner)

                For Each crop In runnerInfo.Crops
                    If Not crop.Id.HasValue Then
                        Throw New ArgumentNullException(NameOf(crop.Id))
                    End If

                    Dim id = If(crop.Id, Guid.Empty)

                    validGuids.Add(id)
                    Dim matchingItem = If(existingCrops.FirstOrDefault(Function(x) x.Id = id),
                        New Crop With {.Runner = runnerInfo.Runner})

                    matchingItem.SizeWidth = crop.Size.Width
                    matchingItem.SizeHeight = crop.Size.Height
                    matchingItem.GameCropTop = crop.GameCrop.Top
                    matchingItem.GameCropBottom = crop.GameCrop.Bottom
                    matchingItem.GameCropRight = crop.GameCrop.Right
                    matchingItem.GameCropLeft = crop.GameCrop.Left
                    matchingItem.TimerCropTop = crop.TimerCrop.Top
                    matchingItem.TimerCropBottom = crop.TimerCrop.Bottom
                    matchingItem.TimerCropRight = crop.TimerCrop.Right
                    matchingItem.TimerCropLeft = crop.TimerCrop.Left
                    matchingItem.Submitter = crop.Submitter

                    matchingItem.SubmittedOn = crop.SubmittedOn

                    If crop.RunnerName Is Nothing Then
                        matchingItem.RunnerName = runnerInfo.Runner
                    Else
                        matchingItem.RunnerName = crop.RunnerName
                    End If

                    If matchingItem.Id <> crop.Id Then
                        matchingItem.Id = id
                        context.Crops.Add(matchingItem)
                    End If

                Next
            Next

            'This will need to be updated back to raw sql in context.Database.ExecuteSqlCommand
            Dim nonExistingItems = context.Crops.Where(Function(x) Not validGuids.Contains(x.Id))
            For Each item In nonExistingItems
                item.SubmittedOn = Nothing
            Next

            context.SaveChanges()
        End Using

        RefreshRunnerNames()
    End Sub
    Private Sub GetIniFile(python As Boolean, resetWebSocketPort As Boolean)

        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        Dim fileName As String = appDataPath & "\obs-studio\global.ini"

        Dim iniContents As Dictionary(Of String, Dictionary(Of String, String)) = IniParser.ParseFile(fileName)

        For Each sectionName As String In iniContents.Keys
            For Each valueName As String In iniContents(sectionName).Keys
                Dim value As String = iniContents(sectionName)(valueName)

                '[SectionName]
                'ValueName=Value
                'ValueName=Value
                '
                'SectionName: The name of the current section (ex: Jones).
                'ValueName  : The name of the current value   (ex: Email).
                'Value      : The value of [ValueName]        (ex: josh.jones@gmail.com).

                If python = True Then
                    If sectionName.ToLower = "python" Then
                        If valueName.ToLower = "path64bit" Then
                            MsgBox(value, MsgBoxStyle.OkOnly)
                            ''IniParser.WritePrivateProfileStringW(SectionName, ValueName, Value & "_Test", FileName)
                        End If
                    End If
                Else
                    If sectionName.ToLower = "websocketapi" Then
                        If valueName.ToLower = "serverport" Then
                            If resetWebSocketPort = True Then
                                IniParser.WritePrivateProfileStringW(sectionName, valueName, My.Settings.ConnectionPort1.ToString, fileName)
                            Else
                                IniParser.WritePrivateProfileStringW(sectionName, valueName, My.Settings.ConnectionPort2.ToString, fileName)
                            End If


                        End If
                    End If
                End If

            Next
        Next
    End Sub
    Private Sub SendToServer()
        Using context As New CropDbContext
            Dim unsentData = context.Crops.Where(Function(crop) Not crop.SubmittedOn.HasValue)
            Try
                For Each localRunner In unsentData

                    Dim runner As New RunnerCropAdd With {
                            .Size = localRunner.Size,
                            .GameCrop = localRunner.GameCrop,
                            .TimerCrop = localRunner.TimerCrop,
                            .Runner = localRunner.Runner,
                            .RunnerName = localRunner.RunnerName,
                            .Submitter = localRunner.Submitter,
                            .Id = localRunner.Id
                            }

                    _cropApi.UpdateCrop(runner)
                    localRunner.SubmittedOn = runner.SubmittedOn

                Next
            Finally
                'save any changes already made, hopefully all of them.
                context.SaveChanges()
            End Try

        End Using

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        _lastUpdate = _lastUpdate + 1

        If _lastUpdate > 5 Then
            _lastUpdate = 0
            If _check2NdObs = True Then
                RefreshObs()
            End If
        End If
    End Sub
    Private Sub ConnectToObs2()
        Cursor = Cursors.WaitCursor

        Try

            If Not _obs2.IsConnected Then

                Dim isPortOpen As Boolean = _obs2.IsPortOpen(ConnectionString2)

                If Not isPortOpen Then
                    MsgBox("OBS2 WebSocket is not running.  Please make sure the OBS2 WebSocket is enabled before continuing!", MsgBoxStyle.OkOnly, ProgramName)
                Else
                    _obs2.Connect(ConnectionString2, My.Settings.Password2)
                End If
            ElseIf MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                _obs2.Disconnect()
            End If

        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub ConnectToObs()
        Cursor = Cursors.WaitCursor
        Try

            If Obs.IsConnected = False Then
                Dim isPortOpen As Boolean = Obs.IsPortOpen(ConnectionString)
                If isPortOpen = False Then
                    MsgBox("OBS WebSocket is not running.  Please make sure the OBS WebSocket is enabled before continuing!", MsgBoxStyle.OkOnly, ProgramName)
                Else
                    Obs.Connect(ConnectionString, My.Settings.Password1)
                End If
            ElseIf MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                Obs.Disconnect()
            End If

        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub CheckUnusedFields()
        Dim visComms, visGameSettings As Boolean

        visComms = Not String.IsNullOrWhiteSpace(My.Settings.CommentaryOBS)
        txtCommentaryNames.Visible = visComms
        lblCommentary.Visible = visComms

        visGameSettings = Not String.IsNullOrWhiteSpace(My.Settings.GameSettings)
        txtGameSettings.Visible = visGameSettings
        lblGameSettings.Visible = visGameSettings

    End Sub
    Private Sub OBSWebSocketCropper_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            SyncWithServer()
        ElseIf (e.KeyCode = Keys.Q AndAlso e.Modifiers = Keys.Control) Then
            Try
                SetMath(1)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
            Try
                FillCurrentCropInfoFromObs(1)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control) Then
            Try
                SaveRunnerCrop(1)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control) Then
            Try
                SetMath(2)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.T AndAlso e.Modifiers = Keys.Control) Then
            Try
                FillCurrentCropInfoFromObs(2)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.Y AndAlso e.Modifiers = Keys.Control) Then
            Try
                SaveRunnerCrop(2)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        End If
    End Sub
    Private Sub btnTestSourceSettings_Click(sender As Object, e As EventArgs) Handles btnTestSourceSettings.Click
        TestSourceSettings()
    End Sub
    Private Sub TestSourceSettings()
        Dim rightGameSourceInfo As SourceSettings
        Dim commentarySizeInfo As SceneItemProperties
        Dim commentaryFontInfo As TextGDI
        Dim micIconInfo As SceneItemProperties


        'micIconInfo = Obs.GetSceneItemProperties("", "MicIcon")
        commentarySizeInfo = Obs.GetSceneItemProperties("", My.Settings.LeftGameName)
        rightGameSourceInfo = Obs.GetSourceSettings(My.Settings.CommentaryOBS)
        commentaryFontInfo = Obs.GetTextGDIProperties(My.Settings.CommentaryOBS)


        If commentaryFontInfo IsNot Nothing Then
            Dim textString As String
            Dim fontSize As Integer
            Dim fontName As String

            fontName = commentaryFontInfo.FontFace
            fontSize = commentaryFontInfo.FontSize

            Dim textFont As New Font(fontName, fontSize)

            textString = commentaryFontInfo.text

            Dim comSize As Size = TextRenderer.MeasureText(textString, textFont)

            Dim sizeOfString As SizeF
            Dim g As Graphics = CreateGraphics()
            sizeOfString = g.MeasureString(textString, textFont)

            Dim micX As Integer = CInt(commentarySizeInfo.PositionX - (sizeOfString.Width / 3))

            Obs.SetSceneItemPosition("MicIcon", micX, CInt(micIconInfo.PositionY))

        End If
    End Sub
    Private Sub ObsWebSocketCropper_FormClosing(sender As Object, e As FormClosingEventArgs)
        My.Settings.Save()
    End Sub
    Private Sub btnResetDatabase_Click(sender As Object, e As EventArgs) Handles btnResetDatabase.Click
        If MsgBox("This will completely reset the database to nothing.  Are you sure you wish to do this?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
            Using context As New CropDbContext
                context.Database.ExecuteSqlCommand("Delete from crops")
                context.SaveChanges()
                RefreshRunnerNames()
            End Using
        End If

    End Sub
    'Private Sub RefreshBoundingBoxSize()
    '    If Not String.IsNullOrWhiteSpace(cbConfigFiles.Text) Then
    '        If cbConfigFiles.Text.Trim.ToLower = "default" Then
    '            RefreshBoundingBoxFromDefault()
    '        Else
    '            RefreshBoundingBoxFromConfigFile(cbConfigFiles.SelectedValue.ToString)
    '        End If
    '    Else
    '        RefreshBoundingBoxFromDefault()
    '    End If

    '    SetBoundingPositions()
    'End Sub
    Private Sub RefreshBoundingBoxFromDefault()
        If rb3Runner.Checked = True Or rb4Runner.Checked = True Then
            GlobalParam.BoundingSizeGame.Width = My.Settings.BoundingSizeWidthGameFourPlayer
            GlobalParam.BoundingSizeGame.Height = My.Settings.BoundingSizeHeightGameFourPlayer

            GlobalParam.BoundingSizeTimer.Width = My.Settings.BoundingSizeWidthTimerFourPlayer
            GlobalParam.BoundingSizeTimer.Height = My.Settings.BoundingSizeHeightTimerFourPlayer

            GlobalParam.PositionXTimer_Runner1 = My.Settings.PositionXTimerTopRightFourPlayer
            GlobalParam.PositionXTimer_Runner2 = My.Settings.PositionXTimerTopLeftFourPlayer
            GlobalParam.PositionXTimer_Runner3 = My.Settings.PositionXTimerBottomRightFourPlayer
            GlobalParam.PositionXTimer_Runner4 = My.Settings.PositionXTimerBottomLeftFourPlayer

            GlobalParam.positionXGame_Runner1 = My.Settings.PositionXGameTopRightFourPlayer
            GlobalParam.positionXGame_Runner2 = My.Settings.PositionXGameTopLeftFourPlayer
            GlobalParam.positionXGame_Runner3 = My.Settings.PositionXGameBottomRightFourPlayer
            GlobalParam.positionXGame_Runner4 = My.Settings.PositionXGameBottomLeftFourPlayer

            GlobalParam.PositionYTimer_Runner1 = My.Settings.PositionYTimerTopRightFourPlayer
            GlobalParam.PositionYTimer_Runner2 = My.Settings.PositionYTimerTopLeftFourPlayer
            GlobalParam.PositionYTimer_Runner3 = My.Settings.PositionYTimerBottomRightFourPlayer
            GlobalParam.PositionYTimer_Runner4 = My.Settings.PositionYTimerBottomLeftFourPlayer

            GlobalParam.PositionYGame_Runner1 = My.Settings.PositionYGameTopRightFourPlayer
            GlobalParam.PositionYGame_Runner2 = My.Settings.PositionYGameTopLeftFourPlayer
            GlobalParam.PositionYGame_Runner3 = My.Settings.PositionYGameBottomRightFourPlayer
            GlobalParam.PositionYGame_Runner4 = My.Settings.PositionYGameBottomLeftFourPlayer
        Else
            GlobalParam.BoundingSizeGame.Width = My.Settings.BoundingSizeWidthGameTwoPlayer
            GlobalParam.BoundingSizeGame.Height = My.Settings.BoundingSizeHeightGameTwoPlayer

            GlobalParam.BoundingSizeTimer.Width = My.Settings.BoundingSizeWidthTimerTwoPlayer
            GlobalParam.BoundingSizeTimer.Height = My.Settings.BoundingSizeHeightTimerTwoPlayer

            GlobalParam.PositionXTimer_Runner1 = My.Settings.PositionXTimerRightTwoPlayer
            GlobalParam.PositionXTimer_Runner2 = My.Settings.PositionXTimerLeftTwoPlayer

            GlobalParam.positionXGame_Runner1 = My.Settings.PositionXGameRightTwoPlayer
            GlobalParam.positionXGame_Runner2 = My.Settings.PositionXGameLeftTwoPlayer

            GlobalParam.PositionYTimer_Runner1 = My.Settings.PositionYTimerRightTwoPlayer
            GlobalParam.PositionYTimer_Runner2 = My.Settings.PositionYTimerLeftTwoPlayer

            GlobalParam.PositionYGame_Runner1 = My.Settings.PositionYGameRightTwoPlayer
            GlobalParam.PositionYGame_Runner2 = My.Settings.PositionYGameLeftTwoPlayer
        End If
    End Sub
    Private Sub RefreshBoundingBoxFromConfigFile(configPath As String)
        If _configInfo Is Nothing = False Then
            If _configInfo.Tables.Count > 0 Then
                _configInfo.Reset()
            End If
        End If

        _configInfo.ReadXml(configPath)

        If _configInfo.Tables.Count > 0 Then
            If _configInfo.Tables("ConfigInfo").Rows.Count > 0 Then
                If rb3Runner.Checked = True Or rb4Runner.Checked = True Then
                    GlobalParam.BoundingSizeGame.Height = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameFourPlayer").ToString), My.Settings.BoundingSizeHeightGameFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameFourPlayer").ToString))
                    GlobalParam.BoundingSizeGame.Width = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameFourPlayer").ToString), My.Settings.BoundingSizeWidthGameFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameFourPlayer").ToString))

                    GlobalParam.BoundingSizeTimer.Height = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerFourPlayer").ToString), My.Settings.BoundingSizeHeightTimerFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerFourPlayer").ToString))
                    GlobalParam.BoundingSizeTimer.Width = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerFourPlayer").ToString), My.Settings.BoundingSizeWidthTimerFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerFourPlayer").ToString))

                    GlobalParam.PositionXTimer_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopRightFourPlayer").ToString), My.Settings.PositionXTimerTopRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopRightFourPlayer").ToString))
                    GlobalParam.PositionXTimer_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopLeftFourPlayer").ToString), My.Settings.PositionXTimerTopLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopLeftFourPlayer").ToString))
                    GlobalParam.PositionXTimer_Runner3 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomRightFourPlayer").ToString), My.Settings.PositionXTimerBottomRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomRightFourPlayer").ToString))
                    GlobalParam.PositionXTimer_Runner4 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomLeftFourPlayer").ToString), My.Settings.PositionXTimerBottomLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomLeftFourPlayer").ToString))

                    GlobalParam.positionXGame_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopRightFourPlayer").ToString), My.Settings.PositionXGameTopRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopRightFourPlayer").ToString))
                    GlobalParam.positionXGame_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopLeftFourPlayer").ToString), My.Settings.PositionXGameTopLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopLeftFourPlayer").ToString))
                    GlobalParam.positionXGame_Runner3 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomRightFourPlayer").ToString), My.Settings.PositionXGameBottomRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomRightFourPlayer").ToString))
                    GlobalParam.positionXGame_Runner4 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomLeftFourPlayer").ToString), My.Settings.PositionXGameBottomLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomLeftFourPlayer").ToString))

                    GlobalParam.PositionYTimer_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopRightFourPlayer").ToString), My.Settings.PositionYTimerTopRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopRightFourPlayer").ToString))
                    GlobalParam.PositionYTimer_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopLeftFourPlayer").ToString), My.Settings.PositionYTimerTopLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopLeftFourPlayer").ToString))
                    GlobalParam.PositionYTimer_Runner3 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomRightFourPlayer").ToString), My.Settings.PositionYTimerBottomRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomRightFourPlayer").ToString))
                    GlobalParam.PositionYTimer_Runner4 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomLeftFourPlayer").ToString), My.Settings.PositionYTimerBottomLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomLeftFourPlayer").ToString))

                    GlobalParam.PositionYGame_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopRightFourPlayer").ToString), My.Settings.PositionYGameTopRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopRightFourPlayer").ToString))
                    GlobalParam.PositionYGame_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopLeftFourPlayer").ToString), My.Settings.PositionYGameTopLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopLeftFourPlayer").ToString))
                    GlobalParam.PositionYGame_Runner3 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomRightFourPlayer").ToString), My.Settings.PositionYGameBottomRightFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomRightFourPlayer").ToString))
                    GlobalParam.PositionYGame_Runner4 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomLeftFourPlayer").ToString), My.Settings.PositionYGameBottomLeftFourPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomLeftFourPlayer").ToString))
                Else
                    GlobalParam.BoundingSizeGame.Height = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameTwoPlayer").ToString), My.Settings.BoundingSizeHeightGameTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameTwoPlayer").ToString))
                    GlobalParam.BoundingSizeGame.Width = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameTwoPlayer").ToString), My.Settings.BoundingSizeWidthGameTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameTwoPlayer").ToString))

                    GlobalParam.BoundingSizeTimer.Height = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerTwoPlayer").ToString), My.Settings.BoundingSizeHeightTimerTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerTwoPlayer").ToString))
                    GlobalParam.BoundingSizeTimer.Width = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerTwoPlayer").ToString), My.Settings.BoundingSizeWidthTimerTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerTwoPlayer").ToString))

                    GlobalParam.PositionXTimer_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerRightTwoPlayer").ToString), My.Settings.PositionXTimerRightTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerRightTwoPlayer").ToString))
                    GlobalParam.PositionXTimer_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerLeftTwoPlayer").ToString), My.Settings.PositionXTimerLeftTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerLeftTwoPlayer").ToString))

                    GlobalParam.positionXGame_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameRightTwoPlayer").ToString), My.Settings.PositionXGameRightTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameRightTwoPlayer").ToString))
                    GlobalParam.positionXGame_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameLeftTwoPlayer").ToString), My.Settings.PositionXGameLeftTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameLeftTwoPlayer").ToString))

                    GlobalParam.PositionYTimer_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerRightTwoPlayer").ToString), My.Settings.PositionYTimerRightTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerRightTwoPlayer").ToString))
                    GlobalParam.PositionYTimer_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerLeftTwoPlayer").ToString), My.Settings.PositionYTimerLeftTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerLeftTwoPlayer").ToString))

                    GlobalParam.PositionYGame_Runner1 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameRightTwoPlayer").ToString), My.Settings.PositionYGameRightTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameRightTwoPlayer").ToString))
                    GlobalParam.PositionYGame_Runner2 = If(String.IsNullOrWhiteSpace(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameLeftTwoPlayer").ToString), My.Settings.PositionYGameLeftTwoPlayer, CInt(_configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameLeftTwoPlayer").ToString))

                End If

            End If
        End If
    End Sub
    Private Sub ConfigEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ConfigEditor.ShowDialog()
    End Sub
    Private Sub LoadConfigFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        With ofdOpenConfig
            .Reset()
            .FileName = ""
            .DefaultExt = ".xml"
            .Filter = "XML Files|*.xml"
            .RestoreDirectory = True
            .InitialDirectory = GlobalParam.ConfigFilePath

            Select Case .ShowDialog
                Case DialogResult.OK
                    lblConfigFile.Text = .FileName
                    RefreshBoundingBoxFromConfigFile(.FileName)
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End With

    End Sub
    Private Sub AddUserControls()
        Dim sVert, sHori, uWidth As Integer

        sHori = 110
        sVert = 153
        uWidth = 436

        rControl1.Location = New System.Drawing.Point(169, sHori)
        rControl1.lblRunnerNumber.Text = "1"

        rControl2.Location = New System.Drawing.Point(521, sHori)
        rControl2.lblRunnerNumber.Text = "2"
        'rControl2.Name = "Player2Controls"
        'Me.Controls.Add(rControl2)

        rControl3.Location = New System.Drawing.Point(873, sHori)
        rControl3.lblRunnerNumber.Text = "3"
        'rControl3.Name = "Player3Controls"
        'Me.Controls.Add(rControl3)

        rControl4.Location = New System.Drawing.Point(1225, sHori)
        rControl4.lblRunnerNumber.Text = "4"
        'rControl4.Name = "Player4Controls"
        'Me.Controls.Add(rControl4)

        RegisterObsDependency(rControl1)
        RegisterObsDependency(rControl2)
        RegisterObsDependency(rControl3)
        RegisterObsDependency(rControl4)

    End Sub
    Private Sub SetControlsVisible(numbPlayers As Integer)
        Dim fSize As Size

        Dim mFormHeight As Integer = 643

        Select Case numbPlayers
            Case 1
                fSize.Width = 618
                fSize.Height = mFormHeight

                rControl1.Visible = True
                rControl2.Visible = False
                rControl3.Visible = False
                rControl4.Visible = False
            Case 2
                fSize.Width = 891
                fSize.Height = mFormHeight

                rControl1.Visible = True
                rControl2.Visible = True
                rControl3.Visible = False
                rControl4.Visible = False
            Case 3
                fSize.Width = 1244
                fSize.Height = mFormHeight

                rControl1.Visible = True
                rControl2.Visible = True
                rControl3.Visible = True
                rControl4.Visible = False
            Case 4
                fSize.Width = 1600
                fSize.Height = mFormHeight

                rControl1.Visible = True
                rControl2.Visible = True
                rControl3.Visible = True
                rControl4.Visible = True
        End Select

        If Not String.IsNullOrWhiteSpace(lblConfigFile.Text) Then
            RefreshBoundingBoxFromConfigFile(lblConfigFile.Text)
        Else
            RefreshBoundingBoxFromDefault()
        End If


        Me.Size = fSize
    End Sub
    Public Shared Function CheckIfKeyAllowed(keyChar As String) As Boolean
        Return Not ApprovedChars.Contains(keyChar) AndAlso keyChar <> vbBack
    End Function
    Private Sub SetSourceNames()
        GlobalParam.gameSource_Runner1 = My.Settings.LeftGameName
        GlobalParam.timerSource_Runner1 = My.Settings.LeftTimerName
        GlobalParam.runnerNameSource_Runner1 = My.Settings.LeftRunnerOBS
        GlobalParam.streamLinkParams_Runner1 = My.Settings.LeftStreamlinkVlcParams
        GlobalParam.trackerSource_Runner1 = My.Settings.LeftTrackerOBS

        GlobalParam.gameSource_Runner2 = My.Settings.RightGameName
        GlobalParam.timerSource_Runner2 = My.Settings.RightTimerName
        GlobalParam.runnerNameSource_Runner2 = My.Settings.RightRunnerOBS
        GlobalParam.streamLinkParams_Runner2 = My.Settings.RightStreamlinkVlcParams
        GlobalParam.trackerSource_Runner2 = My.Settings.RightTrackerOBS

        GlobalParam.gameSource_Runner3 = My.Settings.LeftGameName_Bottom
        GlobalParam.timerSource_Runner3 = My.Settings.LeftTimerName_Bottom
        GlobalParam.runnerNameSource_Runner3 = My.Settings.LeftRunnerOBS_Bottom
        GlobalParam.streamLinkParams_Runner3 = My.Settings.LeftStreamlinkVlcParams
        GlobalParam.trackerSource_Runner3 = My.Settings.LeftTrackerOBS_Bottom

        GlobalParam.gameSource_Runner4 = My.Settings.RightGameName_Bottom
        GlobalParam.timerSource_Runner4 = My.Settings.RightTimerName_Bottom
        GlobalParam.runnerNameSource_Runner4 = My.Settings.RightRunnerOBS_Bottom
        GlobalParam.streamLinkParams_Runner4 = My.Settings.RightStreamlinkVlcParams
        GlobalParam.trackerSource_Runner4 = My.Settings.RightTrackerOBS_Bottom
    End Sub
    Private Sub SetBoundingPositions()
        'rControl1.BoundingSizeGame = BoundingSizeGame
        'rControl1.BoundingSizeTimer = BoundingSizeTimer
        'rControl1.PositionYTimer = PositionYTimer_TL
        'rControl1.PositionYGame = PositionYGame_TL
        'rControl1.positionXTimer = PositionXTimer_TL
        'rControl1.positionXGame = positionXGame_TL

        'rControl2.BoundingSizeGame = BoundingSizeGame
        'rControl2.BoundingSizeTimer = BoundingSizeTimer
        'rControl2.PositionYTimer = PositionYTimer_TR
        'rControl2.PositionYGame = PositionYGame_TR
        'rControl2.positionXTimer = PositionXTimer_TR
        'rControl2.positionXGame = positionXGame_TR

        'rControl3.BoundingSizeGame = BoundingSizeGame
        'rControl3.BoundingSizeTimer = BoundingSizeTimer
        'rControl3.PositionYTimer = PositionYTimer_BL
        'rControl3.PositionYGame = PositionYGame_BL
        'rControl3.positionXTimer = PositionXTimer_BL
        'rControl3.positionXGame = positionXGame_BL

        'rControl4.BoundingSizeGame = BoundingSizeGame
        'rControl4.BoundingSizeTimer = BoundingSizeTimer
        'rControl4.PositionYTimer = PositionYTimer_BR
        'rControl4.PositionYGame = PositionYGame_BR
        'rControl4.positionXTimer = PositionXTimer_BR
        'rControl4.positionXGame = positionXGame_BR
    End Sub
    Private Sub lblConfigFile_DoubleClick(sender As Object, e As EventArgs) Handles lblConfigFile.DoubleClick
        lblConfigFile.Text = ""
    End Sub
    Public Function GetMasterSize(sourceName As String) As Size

        If String.IsNullOrWhiteSpace(sourceName) Then
            Return Size.Empty
        End If


        Dim currentScene = If(Obs.StudioModeEnabled, Obs.GetPreviewScene(), Obs.GetCurrentScene())

        Dim target As String

        target = sourceName.ToLower

        Dim adequateSource = currentScene.Items.FirstOrDefault(Function(scene) scene.SourceName.ToLower = target)

        If adequateSource.SourceName Is Nothing OrElse String.IsNullOrWhiteSpace(adequateSource.SourceName) Then
            MessageBox.Show(Me, $"Cannot find source {target} in the current scene. Are you on the right scene?")
        End If

        Return New Size(adequateSource.SourceWidth, adequateSource.SourceHeight)

    End Function
    Public Sub ProcessCrop(cropWithDefault As Rectangle, savedMasterSize As Size, currentMasterSize As Size, sourceName As String, scaling As Double,
                        boundingSize As Rectangle, positionX As Integer, positionY As Integer)

        Dim resultingCrop = _cropperMath.AdjustCrop(New CropInfo With {
                                                          .MasterSizeWithoutDefault = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(savedMasterSize, scaling)),
                                                          .CropWithoutDefault = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, savedMasterSize, scaling))
                                                          }, _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(currentMasterSize, scaling)))

        Dim realCrop = _cropperMath.AddScaling(_cropperMath.AddDefaultCrop(resultingCrop.CropWithBlackBarsWithoutDefault), _cropperMath.AddScaling(_cropperMath.AddDefaultCropSize(resultingCrop.MasterSizeWithoutDefault), scaling), scaling)

        Obs.SetSceneItemProperties(sourceName, realCrop.Top, realCrop.Bottom, realCrop.Left, realCrop.Right, boundingSize.Width, boundingSize.Height, positionX, positionY)
        If ObsConnectionStatus2 = "Connected" Then
            _obs2.SetSceneItemProperties(sourceName, realCrop.Top, realCrop.Bottom, realCrop.Left, realCrop.Right, boundingSize.Width, boundingSize.Height, positionX, positionY)
        End If

    End Sub
    Public Sub SetCrop(runnerNumber As Integer)
        Dim runnerVm As RunnerViewModel
        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)
        Dim timerSource = GlobalParam.GetTimerSource(runnerNumber)

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        If runnerVm.MasterSize.Height = 0 OrElse runnerVm.MasterSize.Width = 0 Then
            runnerVm.MasterSize.UpdateFromSize(GetMasterSize(gameSource))
        End If
        Try
            SetMath(runnerNumber)
        Catch ex As ErrorResponseException
            MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
        End Try
    End Sub
    Public Sub SetMath(runnerNumber As Integer)
        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)
        Dim timerSource = GlobalParam.GetTimerSource(runnerNumber)

        GetCurrentCropSettings(runnerNumber)

        RefreshCropperDefaultCrop()

        Dim runnerVm As RunnerViewModel

        Dim PositionYTimer, PositionYGame, positionXTimer, positionXGame As Integer

        runnerVm = _viewModel.Runner

        If runnerVm.MasterSize.Height > 0 And runnerVm.MasterSize.Width > 0 Then
            If Not String.IsNullOrWhiteSpace(gameSource) Then
                ProcessCrop(runnerVm.GameCrop.AsRectangle(),
                            runnerVm.MasterSize.AsSize(),
                            runnerVm.CurrentSize.AsSize(),
                            gameSource,
                            runnerVm.Scale,
                            GlobalParam.BoundingSizeGame,
                            positionXGame,
                            PositionYGame
)
            End If

            If Not String.IsNullOrWhiteSpace(timerSource) Then
                ProcessCrop(runnerVm.TimerCrop.AsRectangle(),
                            runnerVm.MasterSize.AsSize(),
                            runnerVm.CurrentSize.AsSize(),
                            timerSource,
                            runnerVm.Scale,
                            GlobalParam.BoundingSizeTimer,
                            positionXTimer,
                            PositionYTimer
)
            End If

        Else
            MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
        End If
    End Sub
    Private Sub GetCurrentCropSettings(runnerNumber As Integer)
        Dim runnerVm As RunnerViewModel
        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        runnerVm.CurrentSize.UpdateFromSize(GetMasterSize(gameSource))
    End Sub

    Public Sub SetVlcWindows(runnerNumber As Integer, vlcSource As String)

        Dim runnerVm As RunnerViewModel

        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)
        Dim timerSource = GlobalParam.GetTimerSource(runnerNumber)

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
            Case 2
                runnerVm = _viewModel.Runner2
            Case 3
                runnerVm = _viewModel.Runner3
            Case 4
                runnerVm = _viewModel.Runner4
        End Select

        If Not String.IsNullOrWhiteSpace(vlcSource) Then
            vlcSource = vlcSource.Replace(":", "#3A") & ":QWidget:vlc.exe"
            If Not String.IsNullOrWhiteSpace(gameSource) Then
                DispatchToObs(Sub(o) o.SetSourceSettings(gameSource, False, vlcSource, 1))
            End If
            If Not String.IsNullOrWhiteSpace(timerSource) Then
                DispatchToObs(Sub(o) o.SetSourceSettings(timerSource, False, vlcSource, 1))
            End If

            'GetCurrentCropSettings()

        End If

    End Sub
    Private Sub StartStreamlink(twitch As String, streamLinkParams As String)
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
    Public Sub StartStreamLink(runnerNumber As Integer)
        Dim runnerVm As RunnerViewModel
        Dim streamLinkParams As String

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
                streamLinkParams = GlobalParam.streamLinkParams_Runner1
            Case 2
                runnerVm = _viewModel.Runner2
                streamLinkParams = GlobalParam.streamLinkParams_Runner2
            Case 3
                runnerVm = _viewModel.Runner3
                streamLinkParams = GlobalParam.streamLinkParams_Runner3
            Case 4
                runnerVm = _viewModel.Runner4
                streamLinkParams = GlobalParam.streamLinkParams_Runner4
        End Select
        If Not String.IsNullOrWhiteSpace(runnerVm.Twitch) Then
            StartStreamlink(runnerVm.Twitch, streamLinkParams)
        Else
            MsgBox("No Runner selected, cannot continue.")
        End If
    End Sub
    Public Sub OpenTwitch(runnerNumber As Integer, isVOD As Boolean)
        Dim runnerVm As RunnerViewModel
        Dim streamLinkParams As String

        Select Case runnerNumber
            Case 1
                runnerVm = _viewModel.Runner1
                streamLinkParams = GlobalParam.streamLinkParams_Runner1
            Case 2
                runnerVm = _viewModel.Runner2
                streamLinkParams = GlobalParam.streamLinkParams_Runner2
            Case 3
                runnerVm = _viewModel.Runner3
                streamLinkParams = GlobalParam.streamLinkParams_Runner3
            Case 4
                runnerVm = _viewModel.Runner4
                streamLinkParams = GlobalParam.streamLinkParams_Runner4
        End Select

        If Not String.IsNullOrWhiteSpace(runnerVm.Twitch) Then
            If isVOD Then
                Process.Start("https://twitch.tv/" & runnerVm.Twitch & "/videos/all")
            Else
                Process.Start("https://twitch.tv/" & runnerVm.Twitch)
            End If
        End If

    End Sub
    Public Sub AddNewRunner(runnerNumber As Integer, runnerNameField As ComboBox, runnerTwitchField As Label)
        NewRunnerName = ""
        NewRunnerTwitch = ""
        GetObsInfo = False
        ReuseInfo = True

        Dim gameSource = GlobalParam.GetGameSource(runnerNumber)

        Dim dResult = NewRunner.ShowDialog(Me)

        If dResult = DialogResult.OK Then
            Dim runnerVm As RunnerViewModel

            Select Case runnerNumber
                Case 1
                    runnerVm = _viewModel.Runner1
                Case 2
                    runnerVm = _viewModel.Runner2
                Case 3
                    runnerVm = _viewModel.Runner3
                Case 4
                    runnerVm = _viewModel.Runner4
            End Select

            If Not String.IsNullOrWhiteSpace(NewRunnerName) Then
                runnerVm.Name = NewRunnerName
                runnerNameField.Text = NewRunnerName
            End If

            runnerVm.Twitch = If(String.IsNullOrWhiteSpace(NewRunnerTwitch), NewRunnerName, NewRunnerTwitch)
            runnerTwitchField.Text = "Twitch: " & runnerVm.Twitch

            If GetObsInfo = True Then
                If runnerVm.MasterSize.Height = 0 OrElse runnerVm.MasterSize.Width = 0 Then
                    runnerVm.MasterSize.UpdateFromSize(GetMasterSize(gameSource))
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
    Public Sub SetTracker(runnerNumber As Integer, trackerTextBox As String)
        Dim trackerSource As String

        Select Case runnerNumber
            Case 1
                trackerSource = GlobalParam.trackerSource_Runner1
            Case 2
                trackerSource = GlobalParam.trackerSource_Runner2
            Case 3
                trackerSource = GlobalParam.trackerSource_Runner3
            Case 4
                trackerSource = GlobalParam.trackerSource_Runner4
        End Select

        If Not String.IsNullOrWhiteSpace(trackerSource) AndAlso Not String.IsNullOrWhiteSpace(trackerTextBox) Then
            Dim TrackerURL = If(ConfigurationManager.AppSettings("TrackerURL"), "")
            Dim trackerString As String
            If trackerTextBox.ToLower.StartsWith("http") Then
                trackerString = trackerTextBox
            Else
                trackerString = TrackerURL & trackerTextBox
            End If

            DispatchToObs(Sub(o) o.SetBrowserSource(My.Settings.LeftTrackerOBS, trackerString))
        End If
    End Sub


#End Region
End Class
