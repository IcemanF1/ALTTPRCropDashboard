Imports System.Configuration
Imports OBSWebsocketDotNet
Imports ALTTPRCropDashboard.Data
Imports ALTTPRCropDashboard.DB
Imports System.IO

Public Class ObsWebSocketCropper
    Public ReadOnly contextString As String

    Public ReadOnly Obs As New ObsWebSocketPlus
    Public ObsConnectionStatus As String
    Public ObsConnectionStatus2 As String

    ReadOnly _obs2 As New ObsWebSocketPlus
    Public ConnectionString As String
    Public ConnectionString2 As String

    Dim _rSourceHeight As Integer
    Dim _rSourceWidth As Integer

    Dim _lSourceHeight As Integer
    Dim _lSourceWidth As Integer

    Dim _cropApi As CropApi

    Dim _masterWidthRight As Integer
    Dim _masterHeightRight As Integer
    Dim _masterScaleRight As Double

    Dim _masterWidthLeft As Integer
    Dim _masterHeightLeft As Integer
    Dim _masterScaleLeft As Double

    Dim _vlcListLeft As New DataSet
    Dim _vlcListRight As New DataSet

    Dim _leftRunnerGameSceneInfo As SceneItemProperties
    Dim _rightRunnerGameSceneInfo As SceneItemProperties
    Dim _leftRunnerTimerSceneInfo As SceneItemProperties
    Dim _rightRunnerTimerSceneInfo As SceneItemProperties

    ReadOnly _cropperMath As New CropperMath

    Public ProgramName As String = "OBS WebSocket Cropper"

    Dim _approvedChars As String = "0123456789"

    Dim _check2NdObs As Boolean = False
    Dim _lastUpdate As Integer

    Dim ProgramLoaded As Boolean

    Public Shared OBSSettingsResult As String

    Public Shared NewRunnerName As String
    Public Shared NewRunnerTwitch As String
    Public Shared GetOBSInfo As Boolean
    Public Shared ReuseInfo As Boolean

    Dim LeftRunnerTwitch As String
    Dim RightRunnerTwitch As String

#Region " Create New Tables "
    Private Sub CreateNewSourceTable()
        If _vlcListLeft.Tables.Count = 0 Then
            _vlcListLeft.Tables.Add("Processes")
            _vlcListLeft.Tables("Processes").Columns.Add("VLCName")
        Else
            _vlcListLeft.Tables("Processes").Clear()
        End If

        If _vlcListRight.Tables.Count = 0 Then
            _vlcListRight.Tables.Add("Processes")
            _vlcListRight.Tables("Processes").Columns.Add("VLCName")
        Else
            _vlcListRight.Tables("Processes").Clear()
        End If

    End Sub

#End Region
#Region " Button Clicks "
    Private Sub btnSetRightCrop_Click(sender As Object, e As EventArgs) Handles btnSetRightCrop.Click
        If ConnectionIsActive() = True Then
            If _masterHeightRight = 0 Then
                SetMasterSourceDimensions()
            End If
            Try
                GetCurrentSceneInfo(True)

                SetNewNewMath(True)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try

        End If

    End Sub
    Private Sub btnConnectOBS1_Click(sender As Object, e As EventArgs) Handles btnConnectOBS1.Click
        ConnectToObs()
    End Sub
    Private Sub btnGetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnGetLeftCrop.Click
        If ConnectionIsActive() = True Then
            Try
                GetCurrentSceneInfo(False)
                If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                    FillCurrentCropInfoFromObs(False)
                End If
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try

        End If
    End Sub
    Private Sub btnGetRightCrop_Click(sender As Object, e As EventArgs) Handles btnGetRightCrop.Click
        If ConnectionIsActive() = True Then
            Try
                GetCurrentSceneInfo(True)

                If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                    FillCurrentCropInfoFromObs(True)
                End If
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        End If

    End Sub
    Private Sub btnSetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSetLeftCrop.Click
        If ConnectionIsActive() = True Then
            Try
                If _masterHeightLeft = 0 Then
                    SetMasterSourceDimensions()
                End If

                GetCurrentSceneInfo(False)

                SetNewNewMath(False)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        End If

    End Sub
    Private Sub btnSetTrackCommNames_Click(sender As Object, e As EventArgs) Handles btnSetTrackCommNames.Click
        If ConnectionIsActive() = True Then
            Dim TrackerURL As String
            If Not String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings("TrackerURL")) Then
                TrackerURL = ConfigurationManager.AppSettings("TrackerURL")
            End If

            If Not String.IsNullOrWhiteSpace(My.Settings.LeftRunnerOBS) Then
                If cbLeftRunnerName.Text.Trim.Length > 0 Then
                    Obs.SetTextGdi(My.Settings.LeftRunnerOBS, cbLeftRunnerName.Text)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetTextGdi(My.Settings.LeftRunnerOBS, cbLeftRunnerName.Text)
                    End If
                End If
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.RightRunnerOBS) Then
                If cbRightRunnerName.Text.Trim.Length > 0 Then
                    Obs.SetTextGdi(My.Settings.RightRunnerOBS, cbRightRunnerName.Text)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetTextGdi(My.Settings.RightRunnerOBS, cbRightRunnerName.Text)
                    End If
                End If
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.CommentaryOBS) Then
                If txtCommentaryNames.Text.Trim.Length > 0 Then
                    Obs.SetTextGdi(My.Settings.CommentaryOBS, txtCommentaryNames.Text)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetTextGdi(My.Settings.CommentaryOBS, txtCommentaryNames.Text)
                    End If
                End If
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftTrackerOBS) Then
                If txtLeftTrackerURL.Text.Trim.Length > 0 Then
                    Dim TrackerString As String
                    If txtLeftTrackerURL.Text.ToLower.StartsWith("http") Then
                        TrackerString = txtLeftTrackerURL.Text
                    Else
                        If Not String.IsNullOrWhiteSpace(TrackerURL) Then
                            TrackerString = TrackerURL & txtLeftTrackerURL.Text
                        End If
                    End If
                    Obs.SetBrowserSource(My.Settings.LeftTrackerOBS, TrackerString)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetBrowserSource(My.Settings.LeftTrackerOBS, TrackerString)
                    End If
                End If
            End If

            If Not String.IsNullOrWhiteSpace(My.Settings.RightTrackerOBS) Then
                If txtRightTrackerURL.Text.Trim.Length > 0 Then
                    Dim TrackerString As String
                    If txtRightTrackerURL.Text.ToLower.StartsWith("http") Then
                        TrackerString = txtRightTrackerURL.Text
                    Else
                        If Not String.IsNullOrWhiteSpace(TrackerURL) Then
                            TrackerString = TrackerURL & txtRightTrackerURL.Text
                        End If
                    End If
                    Obs.SetBrowserSource(My.Settings.RightTrackerOBS, TrackerString)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetBrowserSource(My.Settings.RightTrackerOBS, TrackerString)
                    End If
                End If
            End If
        End If


    End Sub
    Private Sub btnSaveLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSaveLeftCrop.Click
        If ConnectionIsActive() = True Then
            SaveRunnerCrop(False)

            RefreshRunnerNames()
        End If
    End Sub
    Private Sub btnSaveRightCrop_Click(sender As Object, e As EventArgs) Handles btnSaveRightCrop.Click
        If ConnectionIsActive() = True Then
            SaveRunnerCrop(True)

            RefreshRunnerNames()
        End If

    End Sub
    Private Sub btnSyncWithServer_Click(sender As Object, e As EventArgs) Handles btnSyncWithServer.Click
        If ConnectionIsActive() = True Then
            SyncWithServer()
        End If
    End Sub
    Private Sub SyncWithServer()
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings("ServerURL")) Then
                _cropApi = New CropApi(ConfigurationManager.AppSettings("ServerURL"))

                SendToServer()
                GetSyncFromServer()
            Else
                MsgBox("You are missing the API config file.  Please ask someone in the restream channel in discord if you believe you should need this file.", MsgBoxStyle.OkOnly, ProgramName)
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnGetProcesses_Click(sender As Object, e As EventArgs) Handles btnGetProcesses.Click
        RefreshVLC()

    End Sub
    Private Sub btnSetLeftVLC_Click(sender As Object, e As EventArgs) Handles btnSetLeftVLC.Click
        If ConnectionIsActive() = True Then
            SetVlcWindows(False)
        End If

    End Sub
    Private Sub SetVlcWindows(isRightWindow As Boolean)
        Dim vlcString As String

        If isRightWindow = False Then
            If Not String.IsNullOrWhiteSpace(cbLeftVLCSource.Text) Then
                vlcString = cbLeftVLCSource.Text.Replace(":", "#3A") & ":QWidget:vlc.exe"

                If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                    Obs.SetSourceSettings(My.Settings.LeftGameName, False, vlcString, 1)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.LeftGameName, False, vlcString, 1)
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
                    Obs.SetSourceSettings(My.Settings.LeftTimerName, False, vlcString, 1)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.LeftTimerName, False, vlcString, 1)
                    End If
                End If
            End If
        Else
            If Not String.IsNullOrWhiteSpace(cbRightVLCSource.Text) Then
                vlcString = cbRightVLCSource.Text.Replace(":", "#3A") & ":QWidget:vlc.exe"

                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    Obs.SetSourceSettings(My.Settings.RightGameName, False, vlcString, 1)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.RightGameName, False, vlcString, 1)
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName) Then
                    Obs.SetSourceSettings(My.Settings.RightTimerName, False, vlcString, 1)
                    If ObsConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.RightTimerName, False, vlcString, 1)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btn2ndOBS_Click(sender As Object, e As EventArgs) Handles btn2ndOBS.Click
        If ConnectionIsActive() = True Then
            GetIniFile(False, False)

            _check2NdObs = True
            Timer1.Start()
        End If


    End Sub
    Private Sub btnConnectOBS2_Click(sender As Object, e As EventArgs) Handles btnConnectOBS2.Click
        If ConnectionIsActive() = True Then
            ConnectToObs2()
        End If

    End Sub
    Private Sub btnSetRightVLC_Click(sender As Object, e As EventArgs) Handles btnSetRightVLC.Click
        If ConnectionIsActive() = True Then
            SetVlcWindows(True)
        End If


    End Sub
    Private Sub btnNewLeftRunner_Click(sender As Object, e As EventArgs) Handles btnNewLeftRunner.Click
        If ConnectionIsActive() = True Then
            AddNewRunner(False)
        End If


    End Sub
    Private Sub btnNewRightRunner_Click(sender As Object, e As EventArgs) Handles btnNewRightRunner.Click
        If ConnectionIsActive() = True Then
            AddNewRunner(True)
        End If


    End Sub
    Private Sub btnLeftTimerDB_Click(sender As Object, e As EventArgs) Handles btnLeftTimerDB.Click
        ClearTextBoxes(False, "Timer")
        RefreshCropFromData(False, "Timer")
    End Sub
    Private Sub btnLeftGameDB_Click(sender As Object, e As EventArgs) Handles btnLeftGameDB.Click
        ClearTextBoxes(False, "Game")
        RefreshCropFromData(False, "Game")
    End Sub
    Private Sub btnRightTimerDB_Click(sender As Object, e As EventArgs) Handles btnRightTimerDB.Click
        ClearTextBoxes(True, "Timer")
        RefreshCropFromData(True, "Timer")
    End Sub
    Private Sub btnRightGameDB_Click(sender As Object, e As EventArgs) Handles btnRightGameDB.Click
        ClearTextBoxes(True, "Game")
        RefreshCropFromData(True, "Game")
    End Sub
    Private Sub btnLeftTimerUncrop_Click(sender As Object, e As EventArgs) Handles btnLeftTimerUncrop.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
            Uncrop(My.Settings.LeftTimerName)
        End If
    End Sub
    Private Sub btnRightTimerUncrop_Click(sender As Object, e As EventArgs) Handles btnRightTimerUncrop.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName) Then
            Uncrop(My.Settings.RightTimerName)
        End If
    End Sub
    Private Sub btnRightGameUncrop_Click(sender As Object, e As EventArgs) Handles btnRightGameUncrop.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
            Uncrop(My.Settings.RightGameName)
        End If
    End Sub
    Private Sub btnLeftGameUncrop_Click(sender As Object, e As EventArgs) Handles btnLeftGameUncrop.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
            Uncrop(My.Settings.LeftGameName)
        End If
    End Sub
#End Region
#Region " Crop Math / Crop Settings "
    Private Sub GetCurrentCropSettings(isRightWindow As Boolean)
        Dim scenes = Obs.ListScenes()

        Dim theSize = GetMasterSize(isRightWindow)
        If isRightWindow Then
            _rSourceHeight = theSize.Height
            _rSourceWidth = theSize.Width
        Else
            _lSourceHeight = theSize.Height
            _lSourceWidth = theSize.Width
        End If

        SetHeightLabels()
    End Sub
    Private Sub SaveRunnerCrop(isRightWindow As Boolean)
        SetMasterSourceDimensions()

        Dim savedMasterSize As Size
        Dim cropWithDefault As Rectangle
        Dim submitterName = My.Settings.TwitchChannel
        Dim scaling As Double

        If isRightWindow = True Then
            GetCurrentCropSettings(True)
            scaling = ParsePercent(cbRightScaling.Text)

            savedMasterSize = New Size(_masterWidthRight, _masterHeightRight)
            ' Has the scaling changed since MasterSize has been set? If yes, we need to account for that..
            Dim correctedMasterSize = _cropperMath.AddScaling(_cropperMath.RemoveScaling(savedMasterSize, _masterScaleRight), scaling)

            Dim masterSizeWithoutDefaultRight As Size = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(savedMasterSize, _masterScaleRight))

            cropWithDefault = Rectangle.FromLTRB(_txtCropRightGame_Left.Text,
                                   _txtCropRightGame_Top.Text,
                                   _txtCropRightGame_Right.Text,
                                   _txtCropRightGame_Bottom.Text)

            Dim cropWithoutDefaultRightGame As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, correctedMasterSize, scaling))

            cropWithDefault = Rectangle.FromLTRB(_txtCropRightTimer_Left.Text,
                                                 _txtCropRightTimer_Top.Text,
                                                 _txtCropRightTimer_Right.Text,
                                                 _txtCropRightTimer_Bottom.Text)

            Dim cropWithoutDefaultRightTimer As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, correctedMasterSize, scaling))

            Using context As New CropDbContext

                If Not String.IsNullOrWhiteSpace(RightRunnerTwitch) Then
                    Dim rightRunner = context.Crops.FirstOrDefault(Function(x) x.Submitter = submitterName AndAlso x.Runner = RightRunnerTwitch)

                    If rightRunner Is Nothing Then
                        'Swap with twitch name
                        rightRunner = New Crop With {
                                .Submitter = submitterName,
                                .Runner = RightRunnerTwitch,
                                .Id = Guid.NewGuid()
                            }
                        context.Crops.Add(rightRunner)
                    End If

                    rightRunner.GameCropTop = cropWithoutDefaultRightGame.Top
                    rightRunner.GameCropBottom = cropWithoutDefaultRightGame.Bottom
                    rightRunner.GameCropRight = cropWithoutDefaultRightGame.Right
                    rightRunner.GameCropLeft = cropWithoutDefaultRightGame.Left
                    rightRunner.TimerCropTop = cropWithoutDefaultRightTimer.Top
                    rightRunner.TimerCropBottom = cropWithoutDefaultRightTimer.Bottom
                    rightRunner.TimerCropRight = cropWithoutDefaultRightTimer.Right
                    rightRunner.TimerCropLeft = cropWithoutDefaultRightTimer.Left
                    rightRunner.SizeHeight = masterSizeWithoutDefaultRight.Height
                    rightRunner.SizeWidth = masterSizeWithoutDefaultRight.Width
                    rightRunner.SubmittedOn = Nothing
                    rightRunner.RunnerName = cbRightRunnerName.Text
                End If

                context.SaveChanges()
            End Using
        Else
            GetCurrentCropSettings(False)
            scaling = ParsePercent(cbLeftScaling.Text)

            savedMasterSize = New Size(_masterWidthLeft, _masterHeightLeft)

            ' Has the scaling changed since MasterSize has been set? If yes, we need to account for that..
            Dim correctedMasterSize = _cropperMath.AddScaling(_cropperMath.RemoveScaling(savedMasterSize, _masterScaleLeft), scaling)

            Dim masterSizeWithoutDefaultLeft As Size = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(savedMasterSize, _masterScaleLeft))

            cropWithDefault = Rectangle.FromLTRB(_txtCropLeftGame_Left.Text,
                                     _txtCropLeftGame_Top.Text,
                                     _txtCropLeftGame_Right.Text,
                                     _txtCropLeftGame_Bottom.Text)

            Dim cropWithoutDefaultLeftGame As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, correctedMasterSize, scaling))

            cropWithDefault = Rectangle.FromLTRB(_txtCropLeftTimer_Left.Text,
                                                 _txtCropLeftTimer_Top.Text,
                                                 _txtCropLeftTimer_Right.Text,
                                                 _txtCropLeftTimer_Bottom.Text)


            Dim cropWithoutDefaultLeftTimer As Rectangle = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, correctedMasterSize, scaling))

            Using context As New CropDbContext
                If Not String.IsNullOrWhiteSpace(LeftRunnerTwitch) Then
                    Dim leftRunner = context.Crops.FirstOrDefault(Function(x) x.Submitter = submitterName AndAlso x.Runner = LeftRunnerTwitch)

                    If leftRunner Is Nothing Then
                        leftRunner = New Crop With {
                            .Submitter = submitterName,
                            .Runner = LeftRunnerTwitch,
                            .Id = Guid.NewGuid()
                            }
                        context.Crops.Add(leftRunner)
                    End If

                    leftRunner.GameCropTop = cropWithoutDefaultLeftGame.Top
                    leftRunner.GameCropBottom = cropWithoutDefaultLeftGame.Bottom
                    leftRunner.GameCropRight = cropWithoutDefaultLeftGame.Right
                    leftRunner.GameCropLeft = cropWithoutDefaultLeftGame.Left
                    leftRunner.TimerCropTop = cropWithoutDefaultLeftTimer.Top
                    leftRunner.TimerCropBottom = cropWithoutDefaultLeftTimer.Bottom
                    leftRunner.TimerCropRight = cropWithoutDefaultLeftTimer.Right
                    leftRunner.TimerCropLeft = cropWithoutDefaultLeftTimer.Left
                    leftRunner.SizeHeight = masterSizeWithoutDefaultLeft.Height
                    leftRunner.SizeWidth = masterSizeWithoutDefaultLeft.Width
                    leftRunner.SubmittedOn = Nothing
                    leftRunner.RunnerName = cbLeftRunnerName.Text
                End If

                context.SaveChanges()
            End Using
        End If


    End Sub
    Private Function GetMasterSize(isRight As Boolean) As Size

        If isRight AndAlso String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
            Return Size.Empty
        End If
        If Not isRight AndAlso String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
            Return Size.Empty
        End If

        Dim currentScene = If(Obs.StudioModeEnabled, Obs.GetPreviewScene(), Obs.GetCurrentScene())
        Dim target = If(isRight, My.Settings.RightGameName, My.Settings.LeftGameName).ToLower

        Dim adequateSource = currentScene.Items.FirstOrDefault(Function(scene) scene.SourceName.ToLower = target)

        If adequateSource.SourceName Is Nothing OrElse String.IsNullOrWhiteSpace(adequateSource.SourceName) Then
            MessageBox.Show(Me, $"Cannot find source {target} in the current scene. Are you on the right scene?")
        End If

        Return New Size(adequateSource.SourceWidth, adequateSource.SourceHeight)

    End Function
    Private Sub SetMasterSourceDimensions()

        Dim leftSize = GetMasterSize(False)
        _masterHeightLeft = leftSize.Height
        _masterWidthLeft = leftSize.Width
        _masterScaleLeft = ParsePercent(cbLeftScaling.Text)

        Dim rightSize = GetMasterSize(True)
        _masterHeightRight = rightSize.Height
        _masterWidthRight = rightSize.Width
        _masterScaleRight = ParsePercent(cbRightScaling.Text)


        SetHeightLabels()
    End Sub
    Private Sub ResetHeightWidthLabels()
        lblLMasterHeight.Text = "Master Height:  0"
        lblLMasterWidth.Text = "Master Width: 0"
        lblLSourceHeight.Text = "Source Height: 0"
        lblLSourceWidth.Text = "Master Width: 0"

        lblRMasterHeight.Text = "Master Height: 0"
        lblRMasterWidth.Text = "Master Width: 0"
        lblRSourceHeight.Text = "Source Height: 0"
        lblRSourceWidth.Text = "Master Width: 0"
    End Sub
    Private Sub SetHeightLabels()
        lblLMasterHeight.Text = "Master Height: " & _masterHeightLeft
        lblLMasterWidth.Text = "Master Width: " & _masterWidthLeft
        lblLSourceHeight.Text = "Source Height: " & _lSourceHeight
        lblLSourceWidth.Text = "Master Width: " & _lSourceWidth

        lblRMasterHeight.Text = "Master Height: " & _masterHeightRight
        lblRMasterWidth.Text = "Master Width: " & _masterWidthRight
        lblRSourceHeight.Text = "Source Height: " & _rSourceHeight
        lblRSourceWidth.Text = "Master Width: " & _rSourceWidth
    End Sub
    Private Sub GetCurrentSceneInfo(isRightWindow As Boolean)
        Dim sceneName As String = If(Obs.StudioModeEnabled, Obs.GetPreviewScene().Name, Obs.GetCurrentScene().Name)
        If isRightWindow = False Then
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                _leftRunnerGameSceneInfo = Obs.GetSceneItemProperties(sceneName, My.Settings.LeftGameName)
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
                _leftRunnerTimerSceneInfo = Obs.GetSceneItemProperties(sceneName, My.Settings.LeftTimerName)
            End If
        Else
            If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                _rightRunnerGameSceneInfo = Obs.GetSceneItemProperties(sceneName, My.Settings.RightGameName)
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName) Then
                _rightRunnerTimerSceneInfo = Obs.GetSceneItemProperties(sceneName, My.Settings.RightTimerName)
            End If
        End If
    End Sub
    Private Sub ProcessCrop(cropWithDefault As Rectangle, savedMasterSize As Size, currentMasterSize As Size, sourceName As String, scaling As Double)
        Dim resultingCrop = _cropperMath.AdjustCrop(New CropInfo With {
                                                      .MasterSizeWithoutDefault = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(savedMasterSize, scaling)),
                                                      .CropWithoutDefault = _cropperMath.RemoveDefaultCrop(_cropperMath.RemoveScaling(cropWithDefault, savedMasterSize, scaling))
                                                      }, _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(currentMasterSize, scaling)))


        Dim realCrop = _cropperMath.AddScaling(_cropperMath.AddDefaultCrop(resultingCrop.CropWithBlackBarsWithoutDefault), _cropperMath.AddScaling(_cropperMath.AddDefaultCropSize(resultingCrop.MasterSizeWithoutDefault), scaling), scaling)

        Obs.SetSceneItemProperties(sourceName, realCrop.Top, realCrop.Bottom, realCrop.Left, realCrop.Right)
        If ObsConnectionStatus2 = "Connected" Then
            _obs2.SetSceneItemProperties(sourceName, realCrop.Top, realCrop.Bottom, realCrop.Left, realCrop.Right)
        End If
    End Sub
    Private Sub SetNewNewMath(isRightWindow As Boolean)

        GetCurrentCropSettings(isRightWindow)

        RefreshCropperDefaultCrop()

        If isRightWindow Then
            If _masterHeightRight > 0 And _masterWidthRight > 0 Then
                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropRightGame_Left.Text,
                                                   _txtCropRightGame_Top.Text,
                                                   _txtCropRightGame_Right.Text,
                                                   _txtCropRightGame_Bottom.Text),
                                New Size(_masterWidthRight, _masterHeightRight),
                                New Size(_rSourceWidth, _rSourceHeight),
                                My.Settings.RightGameName,
                                ParsePercent(cbRightScaling.Text)
                        )
                End If

                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropRightTimer_Left.Text,
                                                   _txtCropRightTimer_Top.Text,
                                                   _txtCropRightTimer_Right.Text,
                                                   _txtCropRightTimer_Bottom.Text),
                                New Size(_masterWidthRight, _masterHeightRight),
                                New Size(_rSourceWidth, _rSourceHeight),
                                My.Settings.RightTimerName,
                                ParsePercent(cbRightScaling.Text)
                                )
                End If

            Else
                MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
            End If

        Else
            If _masterHeightLeft > 0 And _masterWidthLeft > 0 Then
                If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropLeftGame_Left.Text,
                                                   _txtCropLeftGame_Top.Text,
                                                   _txtCropLeftGame_Right.Text,
                                                   _txtCropLeftGame_Bottom.Text),
                                New Size(_masterWidthLeft, _masterHeightLeft),
                                New Size(_lSourceWidth, _lSourceHeight),
                                My.Settings.LeftGameName,
                                ParsePercent(cbLeftScaling.Text)
                                )
                End If

                If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropLeftTimer_Left.Text,
                                                   _txtCropLeftTimer_Top.Text,
                                                   _txtCropLeftTimer_Right.Text,
                                                   _txtCropLeftTimer_Bottom.Text),
                                New Size(_masterWidthLeft, _masterHeightLeft),
                                New Size(_lSourceWidth, _lSourceHeight),
                                My.Settings.LeftTimerName,
                                ParsePercent(cbLeftScaling.Text)
                                )
                End If

            Else
                MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
            End If


        End If

    End Sub
#End Region
#Region " Refresh / Set User Info "
    Private Sub RefreshRunnerNames()
        Dim tempLeftRunner As String = cbLeftRunnerName.Text
        Dim tempRightRunner As String = cbRightRunnerName.Text

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.RunnerName}).Distinct().ToList().OrderBy(Function(r) r.RacerName, System.StringComparer.CurrentCultureIgnoreCase)

            cbLeftRunnerName.DataSource = validNames.ToList()
            cbRightRunnerName.DataSource = validNames.ToList()
            cbLeftRunnerName.DisplayMember = "RacerName"
            cbLeftRunnerName.ValueMember = "RacerName"
            cbRightRunnerName.DisplayMember = "RacerName"
            cbRightRunnerName.ValueMember = "RacerName"

        End Using

        cbLeftRunnerName.Text = tempLeftRunner
        cbRightRunnerName.Text = tempRightRunner

    End Sub
    Private Function ParsePercent(percent As String) As Double
        If (String.IsNullOrWhiteSpace(percent)) Then
            Return 1
        End If

        Return Double.Parse(percent.Replace("%",""))/100.0
    End Function

    Private Sub RefreshCropFromData(isRightWindow As Boolean, ByVal RefreshAction As String)
        If Not Obs.IsConnected Then
            Return
        End If

        Dim savedMasterSize As Size
        Dim realMasterSize As Size
        Dim scaling As Double
        Dim savedCrop As Rectangle
        Dim realCrop As Rectangle

        Using context As New CropDbContext
            Dim runnerInfo As Crop

            If (isRightWindow) Then
                scaling = ParsePercent(cbRightScaling.Text)
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.RunnerName = cbRightRunnerName.Text)
                If runnerInfo Is Nothing Then
                    runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.RunnerName = cbRightRunnerName.Text)
                End If
                If runnerInfo Is Nothing Then
                    runnerInfo = New Crop
                    Dim initialSize = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(GetMasterSize(isRightWindow), scaling))
                    runnerInfo.SizeWidth = initialSize.Width
                    runnerInfo.SizeHeight = initialSize.Height

                End If
            Else
                scaling = ParsePercent(cbLeftScaling.Text)
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.RunnerName = cbLeftRunnerName.Text)
                If runnerInfo Is Nothing Then
                    runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.RunnerName = cbLeftRunnerName.Text)
                End If
                If runnerInfo Is Nothing Then
                    runnerInfo = New Crop
                    Dim initialSize = _cropperMath.RemoveDefaultCropSize(_cropperMath.RemoveScaling(GetMasterSize(isRightWindow), scaling))
                    runnerInfo.SizeWidth = initialSize.Width
                    runnerInfo.SizeHeight = initialSize.Height

                End If
            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.TimerCropLeft, runnerInfo.TimerCropTop, runnerInfo.TimerCropRight, runnerInfo.TimerCropBottom)
            realCrop = _cropperMath.AddDefaultCrop(savedCrop)

            savedMasterSize = New Size(runnerInfo.SizeWidth, runnerInfo.SizeHeight)

            If isRightWindow Then
                If RefreshAction = "Both" Or RefreshAction = "Timer" Then
                    realMasterSize = _cropperMath.AddScaling(_cropperMath.AddDefaultCropSize(savedMasterSize), scaling)
                    realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, ParsePercent(cbRightScaling.Text))
                    txtCropRightTimer_Top.Text = realCrop.Top
                    txtCropRightTimer_Bottom.Text = realCrop.Bottom
                    txtCropRightTimer_Left.Text = realCrop.Left
                    txtCropRightTimer_Right.Text = realCrop.Right
                End If
            Else
                If RefreshAction = "Both" Or RefreshAction = "Timer" Then
                    realMasterSize = _cropperMath.AddScaling(_cropperMath.AddDefaultCropSize(savedMasterSize), scaling)
                    realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, ParsePercent(cbLeftScaling.Text))
                    txtCropLeftTimer_Top.Text = realCrop.Top
                    txtCropLeftTimer_Bottom.Text = realCrop.Bottom
                    txtCropLeftTimer_Left.Text = realCrop.Left
                    txtCropLeftTimer_Right.Text = realCrop.Right
                End If
            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.GameCropLeft, runnerInfo.GameCropTop, runnerInfo.GameCropRight, runnerInfo.GameCropBottom)
            realCrop = _cropperMath.AddDefaultCrop(savedCrop)

            If isRightWindow Then
                If RefreshAction = "Both" Or RefreshAction = "Game" Then
                    realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, scaling)
                    txtCropRightGame_Top.Text = realCrop.Top
                    txtCropRightGame_Bottom.Text = realCrop.Bottom
                    txtCropRightGame_Left.Text = realCrop.Left
                    txtCropRightGame_Right.Text = realCrop.Right
                    RightRunnerTwitch = runnerInfo.Runner
                    lblRightRunnerTwitch.Text = "Twitch: " & RightRunnerTwitch
                End If
            Else
                If RefreshAction = "Both" Or RefreshAction = "Game" Then
                    realCrop = _cropperMath.AddScaling(realCrop, realMasterSize, scaling)
                    txtCropLeftGame_Top.Text = realCrop.Top
                    txtCropLeftGame_Bottom.Text = realCrop.Bottom
                    txtCropLeftGame_Left.Text = realCrop.Left
                    txtCropLeftGame_Right.Text = realCrop.Right
                    LeftRunnerTwitch = runnerInfo.Runner
                    lblLeftRunnerTwitch.Text = "Twitch: " & LeftRunnerTwitch
                End If
            End If

            If isRightWindow Then
                _masterWidthRight = realMasterSize.Width
                _masterHeightRight = realMasterSize.Height
                _masterScaleRight = scaling
            Else
                _masterWidthLeft = realMasterSize.Width
                _masterHeightLeft = realMasterSize.Height
                _masterScaleLeft = scaling
            End If
        End Using


        SetHeightLabels()
    End Sub
    Private Sub RefreshOBS()
        Dim lObs = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("obs", True, Globalization.CultureInfo.InvariantCulture)).ToList()

        If lObs.Count > 1 Then
            Timer1.Stop()
            GetIniFile(False, True)
            _check2NdObs = False
        End If
    End Sub
    Private Sub RefreshVLC()

        Dim lVLC = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("vlc", True, Globalization.CultureInfo.InvariantCulture)).ToList()

        Dim TLeftVLC, TRightVLC As String

        If Not String.IsNullOrWhiteSpace(cbRightVLCSource.Text) Then
            TRightVLC = cbRightVLCSource.Text
        Else
            TRightVLC = ""
        End If

        If Not String.IsNullOrWhiteSpace(cbLeftVLCSource.Text) Then
            TLeftVLC = cbLeftVLCSource.Text
        Else
            TLeftVLC = ""
        End If

        _vlcListLeft.Clear()
        _vlcListRight.Clear()

        Dim x As Integer
        For x = 0 To lVLC.Count - 1
            Dim dr As DataRow
            dr = _vlcListLeft.Tables("Processes").NewRow
            dr.Item("VLCName") = lVLC.Item(x).MainWindowTitle
            _vlcListLeft.Tables("Processes").Rows.Add(dr)

        Next
        _vlcListRight = _vlcListLeft.Copy

        cbLeftVLCSource.DataSource = _vlcListLeft.Tables("Processes")
        cbLeftVLCSource.DisplayMember = "VLCName"
        cbLeftVLCSource.ValueMember = "VLCName"

        cbRightVLCSource.DataSource = _vlcListRight.Tables("Processes")
        cbRightVLCSource.DisplayMember = "VLCName"
        cbRightVLCSource.ValueMember = "VLCName"

        cbRightVLCSource.Text = ""
        cbLeftVLCSource.Text = ""

        If Not String.IsNullOrWhiteSpace(lblLeftRunnerTwitch.Text) Then
            Dim row As DataRow = _vlcListLeft.Tables("Processes").Select("VLCName like '%" & lblLeftRunnerTwitch.Text.ToLower.Remove(0, 8) & "%'").FirstOrDefault()

            If Not row Is Nothing Then
                cbLeftVLCSource.Text = row.Item(0).ToString
            End If
        End If


        If Not String.IsNullOrWhiteSpace(lblRightRunnerTwitch.Text) Then
            Dim row As DataRow = _vlcListRight.Tables("Processes").Select("VLCName like '%" & lblRightRunnerTwitch.Text.ToLower.Remove(0, 8) & "%'").FirstOrDefault()

            If Not row Is Nothing Then
                cbRightVLCSource.Text = row.Item(0).ToString
            End If
        End If


    End Sub
    Private Sub ClearTextBoxes(isRightWindow As Boolean, ByVal RefreshAction As String)
        If isRightWindow = True Then
            If RefreshAction = "Both" Or RefreshAction = "Game" Then
                txtCropRightGame_Bottom.Text = ""
                txtCropRightGame_Left.Text = ""
                txtCropRightGame_Right.Text = ""
                txtCropRightGame_Top.Text = ""
            ElseIf RefreshAction = "Both" Or RefreshAction = "Timer" Then
                txtCropRightTimer_Bottom.Text = ""
                txtCropRightTimer_Left.Text = ""
                txtCropRightTimer_Right.Text = ""
                txtCropRightTimer_Top.Text = ""
            End If
        Else
            If RefreshAction = "Both" Or RefreshAction = "Game" Then
                txtCropLeftGame_Bottom.Text = ""
                txtCropLeftGame_Left.Text = ""
                txtCropLeftGame_Right.Text = ""
                txtCropLeftGame_Top.Text = ""
            ElseIf RefreshAction = "Both" Or RefreshAction = "Timer" Then
                txtCropLeftTimer_Bottom.Text = ""
                txtCropLeftTimer_Left.Text = ""
                txtCropLeftTimer_Right.Text = ""
                txtCropLeftTimer_Top.Text = ""
            End If
        End If
    End Sub
    Private Sub FillCurrentCropInfoFromObs(isRightWindow As Boolean)
        SetMasterSourceDimensions()

        If isRightWindow = True Then

            If _rightRunnerTimerSceneInfo IsNot Nothing Then
                txtCropRightTimer_Top.Text = _rightRunnerTimerSceneInfo.Crop.Top
                txtCropRightTimer_Bottom.Text = _rightRunnerTimerSceneInfo.Crop.Bottom
                txtCropRightTimer_Left.Text = _rightRunnerTimerSceneInfo.Crop.Left
                txtCropRightTimer_Right.Text = _rightRunnerTimerSceneInfo.Crop.Right
            End If

            If _rightRunnerGameSceneInfo IsNot Nothing Then
                txtCropRightGame_Top.Text = _rightRunnerGameSceneInfo.Crop.Top
                txtCropRightGame_Bottom.Text = _rightRunnerGameSceneInfo.Crop.Bottom
                txtCropRightGame_Left.Text = _rightRunnerGameSceneInfo.Crop.Left
                txtCropRightGame_Right.Text = _rightRunnerGameSceneInfo.Crop.Right
            End If
        Else
            If _leftRunnerTimerSceneInfo IsNot Nothing Then
                txtCropLeftTimer_Top.Text = _leftRunnerTimerSceneInfo.Crop.Top
                txtCropLeftTimer_Bottom.Text = _leftRunnerTimerSceneInfo.Crop.Bottom
                txtCropLeftTimer_Left.Text = _leftRunnerTimerSceneInfo.Crop.Left
                txtCropLeftTimer_Right.Text = _leftRunnerTimerSceneInfo.Crop.Right
            End If

            If _leftRunnerGameSceneInfo IsNot Nothing Then
                txtCropLeftGame_Top.Text = _leftRunnerGameSceneInfo.Crop.Top
                txtCropLeftGame_Bottom.Text = _leftRunnerGameSceneInfo.Crop.Bottom
                txtCropLeftGame_Left.Text = _leftRunnerGameSceneInfo.Crop.Left
                txtCropLeftGame_Right.Text = _leftRunnerGameSceneInfo.Crop.Right

            End If
        End If



    End Sub
#End Region
#Region " Block crop text boxes / key presses "
    Private Sub txtCropRightTimer_Top_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightTimer_Top.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightTimer_Right_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightTimer_Right.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightTimer_Left_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightTimer_Left.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightTimer_Bottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightTimer_Bottom.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightGame_Top_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightGame_Top.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightGame_Right_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightGame_Right.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightGame_Left_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightGame_Left.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropRightGame_Bottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropRightGame_Bottom.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftTimer_Top_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftTimer_Top.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftTimer_Right_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftTimer_Right.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftTimer_Left_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftTimer_Left.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftTimer_Bottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftTimer_Bottom.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftGame_Top_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftGame_Top.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftGame_Right_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftGame_Right.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftGame_Left_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftGame_Left.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtCropLeftGame_Bottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCropLeftGame_Bottom.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Public Function CheckIfKeyAllowed(keyChar As String) As Boolean
        If Not _approvedChars.Contains(keyChar) And keyChar <> vbBack Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region " Runner Drop Downs "
    Private Sub cbLeftRunner_KeyUp(sender As Object, e As KeyEventArgs) Handles cbLeftRunnerName.KeyUp
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
        actual = cbLeftRunnerName.Text

        ' Find the first match for the typed value.
        index = cbLeftRunnerName.FindString(actual)

        ' Get the text of the first match.
        If (index > -1) Then
            found = cbLeftRunnerName.Items(index).ToString()

            ' Select this item from the list.
            cbLeftRunnerName.SelectedIndex = index

            ' Select the portion of the text that was automatically
            ' added so that additional typing will replace it.
            cbLeftRunnerName.SelectionStart = actual.Length
            cbLeftRunnerName.SelectionLength = found.Length
        End If
    End Sub
    Private Sub cbRightRunner_KeyUp(sender As Object, e As KeyEventArgs) Handles cbRightRunnerName.KeyUp
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
        actual = cbRightRunnerName.Text

        ' Find the first match for the typed value.
        index = cbRightRunnerName.FindString(actual)

        ' Get the text of the first match.
        If (index > -1) Then
            found = cbRightRunnerName.Items(index).ToString()

            ' Select this item from the list.
            cbRightRunnerName.SelectedIndex = index

            ' Select the portion of the text that was automatically
            ' added so that additional typing will replace it.
            cbRightRunnerName.SelectionStart = actual.Length
            cbRightRunnerName.SelectionLength = found.Length
        End If
    End Sub
    Private Sub cbRightRunner_TextChanged(sender As Object, e As EventArgs) Handles cbRightRunnerName.TextChanged
        If ReuseInfo = True Then
            ClearTextBoxes(True, "Both")
            RefreshCropFromData(True, "Both")
        End If
    End Sub
    Private Sub cbLeftRunner_TextChanged(sender As Object, e As EventArgs) Handles cbLeftRunnerName.TextChanged
        If ReuseInfo = True Then
            ClearTextBoxes(False, "Both")
            RefreshCropFromData(False, "Both")
        End If
    End Sub
#End Region

#Region " Misc Functions "
    Private Sub EnableButtons(isConnected As Boolean)
        btnSetLeftCrop.Enabled = isConnected
        btnSetRightCrop.Enabled = isConnected
        btnSetTrackCommNames.Enabled = isConnected
        btnSyncWithServer.Enabled = isConnected
        btnGetLeftCrop.Enabled = isConnected
        btnGetRightCrop.Enabled = isConnected
        btnSaveLeftCrop.Enabled = isConnected
        btnSaveRightCrop.Enabled = isConnected
        btnSetLeftVLC.Enabled = isConnected
        btnSetRightVLC.Enabled = isConnected
        btnGetProcesses.Enabled = isConnected
        btn2ndOBS.Enabled = isConnected
        btnConnectOBS2.Enabled = isConnected
        btnNewLeftRunner.Enabled = isConnected
        btnNewRightRunner.Enabled = isConnected

        gbTrackerComms.Enabled = isConnected
        gbLeftGameWindow.Enabled = isConnected
        gbRightGameWindow.Enabled = isConnected
        gbLeftTimerWindow.Enabled = isConnected
        gbRightTimerWindow.Enabled = isConnected

        cbLeftRunnerName.Enabled = isConnected
        cbRightRunnerName.Enabled = isConnected
        cbRightVLCSource.Enabled = isConnected
        cbLeftVLCSource.Enabled = isConnected


        lblLeftVOD.Enabled = isConnected
        lblRightVOD.Enabled = isConnected
        lblViewRightOnTwitch.Enabled = isConnected
        lblViewLeftOnTwitch.Enabled = isConnected
        lblLeftStreamlink.Enabled = isConnected
        lblRightStreamlink.Enabled = isConnected
    End Sub
    Private Sub OBSWebScocketCropper_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.UpgradeRequired = True Then
            My.Settings.Upgrade()
            My.Settings.UpgradeRequired = False
            My.Settings.Save()
        End If

        ProgramLoaded = False
        ReuseInfo = True

        ConnectionString = My.Settings.ConnectionString1 & ":" & My.Settings.ConnectionPort1

        lblOBS1ConnectedStatus.Text = "Not Connected"
        lblOBS2ConnectedStatus.Text = "Not Connected"

        lblLeftStreamlink.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        lblRightStreamlink.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        lblLeftScaling.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        cbLeftScaling.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        lblRightScaling.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        cbRightScaling.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        chkAlwaysOnTop.DataBindings.Add("Checked", My.Settings, NameOf(My.Settings.AlwaysOnTop), False, DataSourceUpdateMode.OnPropertyChanged)

        CreateNewSourceTable()

        If My.Settings.HasFinishedWelcome = False Then
            Dim uSettings As New UserSettings

            UserSettings.ShowVLCOption = True
            uSettings.ShowDialog(Me)

            If My.Settings.HasFinishedWelcome = False Then
                MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
                Close()
            End If

            CheckUnusedFields()

            If OBSSettingsResult = "VLC" Then
                VlcSettings.ShowDialog(Me)

            End If

            RefreshRunnerNames()
        Else
            EnableButtons(False)
            ResetHeightWidthLabels()

            RefreshRunnerNames()

            RefreshCropperDefaultCrop()

            CheckUnusedFields()
        End If

        ExpertModeToolStripMenuItem.Checked = My.Settings.ExpertMode

        RefreshExpertSettings()

        ProgramLoaded = True

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

        RefreshExpertSettings()
    End Sub
    Private Sub ChangeUserSettingsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangeUserSettingsToolStripMenuItem.Click
        Dim uSettings As New UserSettings

        UserSettings.ShowVLCOption = False
        uSettings.ShowDialog(Me)

        If My.Settings.HasFinishedWelcome = False Then
            MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
            Close()

        Else
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
                    validGuids.Add(crop.Id)
                    Dim matchingItem = If(existingCrops.FirstOrDefault(Function(x) x.Id = crop.Id),
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
                        matchingItem.Id = crop.Id
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
                            'MsgBox(Value, MsgBoxStyle.OkOnly)
                            If resetWebSocketPort = True Then
                                IniParser.WritePrivateProfileStringW(sectionName, valueName, My.Settings.ConnectionPort1, fileName)

                            Else
                                IniParser.WritePrivateProfileStringW(sectionName, valueName, My.Settings.ConnectionPort2, fileName)
                                MsgBox("Try opening a 2nd instance of OBS", MsgBoxStyle.OkOnly, ProgramName)
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
    Private Sub RefreshCropperDefaultCrop()
        _cropperMath.DefaultCrop = Rectangle.FromLTRB(0, My.Settings.DefaultCropTop, 0, My.Settings.DefaultCropBottom)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _lastUpdate = _lastUpdate + 1

        If _lastUpdate > 30 Then
            _lastUpdate = 0
            If _check2NdObs = True Then
                RefreshOBS()
            End If
        End If
    End Sub
    Private Sub ConnectToObs2()
        Cursor = Cursors.WaitCursor

        Try


            ConnectionString2 = My.Settings.ConnectionString2 & ":" & My.Settings.ConnectionPort2

            Dim PortOpen As Boolean = _obs2.IsPortOpen(ConnectionString2)

            If PortOpen = False Then
                MsgBox("OBS2 WebSocket is not running.  Please make sure the OBS2 WebSocket is enabled before continuing!", MsgBoxStyle.OkOnly, ProgramName)
            Else
                If _obs2.IsConnected = False Then
                    _obs2.Connect(ConnectionString2, My.Settings.Password2)
                Else
                    If MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                        _obs2.Disconnect()
                        ObsConnectionStatus2 = "Not Connected"
                        lblOBS2ConnectedStatus.Text = ObsConnectionStatus2
                    End If

                End If



                If _obs2.IsConnected = True Then
                    ObsConnectionStatus2 = "Connected"
                    lblOBS2ConnectedStatus.Text = ObsConnectionStatus2

                Else
                    lblOBS2ConnectedStatus.Text = "Not Connected"
                End If
            End If
        Finally

            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub ConnectToObs()
        Cursor = Cursors.WaitCursor

        Try

            ConnectionString = My.Settings.ConnectionString1 & ":" & My.Settings.ConnectionPort1

            Dim PortOpen As Boolean = Obs.IsPortOpen(ConnectionString)

            If PortOpen = False Then
                MsgBox("OBS WebSocket is not running.  Please make sure the OBS WebSocket is enabled before continuing!", MsgBoxStyle.OkOnly, ProgramName)
            Else
                If Obs.IsConnected = False Then
                    Obs.Connect(ConnectionString, My.Settings.Password1)
                Else
                    If MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                        Obs.Disconnect()
                        ObsConnectionStatus = "Not Connected"
                        lblOBS1ConnectedStatus.Text = ObsConnectionStatus
                        EnableButtons(False)
                    End If
                End If


                If Obs.IsConnected = True Then
                    ObsConnectionStatus = "Connected"
                    lblOBS1ConnectedStatus.Text = ObsConnectionStatus

                    EnableButtons(True)

                    RefreshVLC()
                Else
                    lblOBS1ConnectedStatus.Text = "Not Connected"

                End If
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub CheckUnusedFields()
        Dim visComms, visLeftRunner, visRightRunner,
        visLeftTracker, visRightTracker, visLeftTimer, visLeftGame,
        visRightTimer, visRightGame As Boolean

        visComms = Not String.IsNullOrWhiteSpace(My.Settings.CommentaryOBS)
        txtCommentaryNames.Visible = visComms
        lblCommentary.Visible = visComms


        visLeftRunner = Not String.IsNullOrWhiteSpace(My.Settings.LeftRunnerOBS) OrElse
            Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) OrElse
            Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName)
        cbLeftRunnerName.Visible = visLeftRunner
        lblLeftRunner.Visible = visLeftRunner

        visRightRunner = Not String.IsNullOrWhiteSpace(My.Settings.RightRunnerOBS) OrElse
            Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) OrElse
            Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName)
        cbRightRunnerName.Visible = visRightRunner
        lblRightRunner.Visible = visRightRunner

        visLeftTracker = Not String.IsNullOrWhiteSpace(My.Settings.LeftTrackerOBS)
        txtLeftTrackerURL.Visible = visLeftTracker
        lblLeftTracker.Visible = visLeftTracker

        visRightTracker = Not String.IsNullOrWhiteSpace(My.Settings.RightTrackerOBS)
        txtRightTrackerURL.Visible = visRightTracker
        lblRightTracker.Visible = visRightTracker

        visLeftTimer = Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName)
        gbLeftTimerWindow.Visible = visLeftTimer

        visLeftGame = Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName)
        gbLeftGameWindow.Visible = visLeftGame

        visRightTimer = Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName)
        gbRightTimerWindow.Visible = visRightTimer

        visRightGame = Not String.IsNullOrWhiteSpace(My.Settings.RightGameName)
        gbRightGameWindow.Visible = visRightGame

        If visRightGame = False And visRightTimer = False Then
            btnSaveRightCrop.Visible = False
            btnGetRightCrop.Visible = False
            btnSetRightCrop.Visible = False
            btnSetRightVLC.Visible = False
            lblRightVLC.Visible = False
            cbRightVLCSource.Visible = False
        Else
            btnSaveRightCrop.Visible = True
            btnGetRightCrop.Visible = True
            btnSetRightCrop.Visible = True
            btnSetRightVLC.Visible = True
            lblRightVLC.Visible = True
            cbRightVLCSource.Visible = True
        End If

        If visLeftGame = False And visLeftTimer = False Then
            btnSaveLeftCrop.Visible = False
            btnGetLeftCrop.Visible = False
            btnSetLeftCrop.Visible = False
            btnSetLeftVLC.Visible = False
            lblLeftVLC.Visible = False
            cbLeftVLCSource.Visible = False
        Else
            btnSaveLeftCrop.Visible = True
            btnGetLeftCrop.Visible = True
            btnSetLeftCrop.Visible = True
            btnSetLeftVLC.Visible = True
            lblLeftVLC.Visible = True
            cbLeftVLCSource.Visible = True
        End If
    End Sub
    Private Sub OBSWebSocketCropper_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            SyncWithServer()
        ElseIf (e.KeyCode = Keys.Q AndAlso e.Modifiers = Keys.Control) Then
            Try
                GetCurrentSceneInfo(False)
                SetNewNewMath(False)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
            Try
                GetCurrentSceneInfo(False)
                FillCurrentCropInfoFromObs(False)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control) Then
            Try
                SaveRunnerCrop(False)
                RefreshRunnerNames()
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control) Then
            Try
                GetCurrentSceneInfo(True)
                SetNewNewMath(True)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.T AndAlso e.Modifiers = Keys.Control) Then
            Try
                GetCurrentSceneInfo(True)
                FillCurrentCropInfoFromObs(True)
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        ElseIf (e.KeyCode = Keys.Y AndAlso e.Modifiers = Keys.Control) Then
            Try
                SaveRunnerCrop(True)
                RefreshRunnerNames()
            Catch ex As ErrorResponseException
                MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
            End Try
        End If
    End Sub
    Private Sub chkAlwaysOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlwaysOnTop.CheckedChanged
        Me.TopMost = chkAlwaysOnTop.Checked

    End Sub
    Private Sub AddNewRunner(ByVal isRightWindow As Boolean)
        NewRunnerName = ""
        NewRunnerTwitch = ""
        GetOBSInfo = False
        ReuseInfo = True

        Dim dResult As New DialogResult
        dResult = NewRunner.ShowDialog(Me)

        If dResult = DialogResult.OK Then
            If isRightWindow = True Then
                If Not String.IsNullOrWhiteSpace(NewRunnerName) Then
                    cbRightRunnerName.Text = NewRunnerName
                End If

                If Not String.IsNullOrWhiteSpace(NewRunnerTwitch) Then
                    RightRunnerTwitch = NewRunnerTwitch
                Else
                    RightRunnerTwitch = NewRunnerName
                End If

                lblRightRunnerTwitch.Text = "Twitch: " & RightRunnerTwitch

                If GetOBSInfo = True Then
                    If _masterHeightLeft = 0 Then
                        SetMasterSourceDimensions()
                    End If

                    Try
                        GetCurrentSceneInfo(False)
                        SetNewNewMath(False)
                    Catch ex As ErrorResponseException
                        MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
                    End Try
                End If
            Else
                If Not String.IsNullOrWhiteSpace(NewRunnerName) Then
                    cbLeftRunnerName.Text = NewRunnerName
                End If

                If Not String.IsNullOrWhiteSpace(NewRunnerTwitch) Then
                    LeftRunnerTwitch = NewRunnerTwitch
                Else
                    LeftRunnerTwitch = NewRunnerName
                End If

                lblLeftRunnerTwitch.Text = "Twitch: " & LeftRunnerTwitch

                If GetOBSInfo = True Then
                    If _masterHeightLeft = 0 Then
                        SetMasterSourceDimensions()
                    End If

                    Try
                        GetCurrentSceneInfo(True)
                        SetNewNewMath(True)
                    Catch ex As ErrorResponseException
                        MessageBox.Show(Me, "Error while getting information from OBS. Are you sure you are on the correct scene?")
                    End Try
                End If
            End If
        End If

        GetOBSInfo = False
        ReuseInfo = True
    End Sub
    Private Sub lblViewLeftOnTwitch_Click(sender As Object, e As EventArgs) Handles lblViewLeftOnTwitch.Click
        If Not String.IsNullOrWhiteSpace(LeftRunnerTwitch) Then
            Process.Start("https://twitch.tv/" & LeftRunnerTwitch)
        End If
    End Sub
    Private Sub lblViewRightOnTwitch_Click(sender As Object, e As EventArgs) Handles lblViewRightOnTwitch.Click
        If Not String.IsNullOrWhiteSpace(RightRunnerTwitch) Then
            Process.Start("https://twitch.tv/" & RightRunnerTwitch)
        End If
    End Sub
    Private Sub lblLeftVOD_Click(sender As Object, e As EventArgs) Handles lblLeftVOD.Click
        If Not String.IsNullOrWhiteSpace(LeftRunnerTwitch) Then
            Process.Start("https://twitch.tv/" & LeftRunnerTwitch & "/videos/all")
        End If
    End Sub
    Private Sub lblRightVOD_Click(sender As Object, e As EventArgs) Handles lblRightVOD.Click
        If Not String.IsNullOrWhiteSpace(RightRunnerTwitch) Then
            Process.Start("https://twitch.tv/" & RightRunnerTwitch & "/videos/all")
        End If
    End Sub
    Private Sub RefreshExpertSettings()
        chkAlwaysOnTop.Visible = My.Settings.ExpertMode
        lblLeftVOD.Visible = My.Settings.ExpertMode
        lblRightVOD.Visible = My.Settings.ExpertMode
        lblViewLeftOnTwitch.Visible = My.Settings.ExpertMode
        lblViewRightOnTwitch.Visible = My.Settings.ExpertMode
        lblOBS2ConnectedStatus.Visible = My.Settings.ExpertMode
        btnConnectOBS2.Visible = My.Settings.ExpertMode
        btn2ndOBS.Visible = My.Settings.ExpertMode
        btnLeftGameDB.Visible = My.Settings.ExpertMode
        btnLeftTimerDB.Visible = My.Settings.ExpertMode
        btnRightTimerDB.Visible = My.Settings.ExpertMode
        btnRightGameDB.Visible = My.Settings.ExpertMode
    End Sub
    Private Sub StartStreamlink(twitch As String, isRightWindow As Boolean)
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

        Dim StreamLinkArguments As String = $"--player-args=""--file-caching 2000 --no-one-instance --network-caching 2000 --input-title-format {twitch} {{filename}}"" https://www.twitch.tv/{twitch} best --player-continuous-http --player-no-close"

        If isRightWindow = True Then
            If Not String.IsNullOrWhiteSpace(My.Settings.RightStreamlinkVlcParams) Then
                StreamLinkArguments = My.Settings.RightStreamlinkVlcParams
            End If
        Else
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftStreamlinkVlcParams) Then
                StreamLinkArguments = My.Settings.LeftStreamlinkVlcParams
            End If
        End If

        Dim myProcess = New Process
        myProcess.StartInfo = New ProcessStartInfo With {
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .FileName = replacedPath,
            .Arguments = StreamLinkArguments,
        .RedirectStandardError = False,
            .RedirectStandardOutput = True
                        }

        myProcess.Start()
    End Sub
    Private Sub lblLeftStreamlink_Click(sender As Object, e As EventArgs) Handles lblLeftStreamlink.Click
        If Not String.IsNullOrWhiteSpace(LeftRunnerTwitch) Then
            StartStreamlink(LeftRunnerTwitch, False)
        Else
            MsgBox("No Runner selected, cannot continue.")
        End If
    End Sub
    Private Sub lblRightStreamlink_Click(sender As Object, e As EventArgs) Handles lblRightStreamlink.Click
        If Not String.IsNullOrWhiteSpace(RightRunnerTwitch) Then
            StartStreamlink(RightRunnerTwitch, True)
        Else
            MsgBox("No Runner selected, cannot continue.")
        End If
    End Sub
    Private Sub btnTestSourceSettings_Click(sender As Object, e As EventArgs) Handles btnTestSourceSettings.Click
        Dim RightGameSourceInfo As SourceSettings
        Dim CommentarySizeInfo As SceneItemProperties
        Dim CommentaryFontInfo As TextGDI
        Dim MicIconInfo As SceneItemProperties


        MicIconInfo = Obs.GetSceneItemProperties("", "MicIcon")
        CommentarySizeInfo = Obs.GetSceneItemProperties("", My.Settings.CommentaryOBS)
        RightGameSourceInfo = Obs.GetSourceSettings(My.Settings.CommentaryOBS)
        CommentaryFontInfo = Obs.GetTextGDIProperties(My.Settings.CommentaryOBS)


        If CommentaryFontInfo Is Nothing = False Then
            Dim TextString As String
            Dim FontSize As Integer
            Dim FontName As String

            FontName = CommentaryFontInfo.FontFace
            FontSize = CommentaryFontInfo.FontSize

            Dim TextFont As New Font(FontName, FontSize)

            TextString = CommentaryFontInfo.text

            Dim ComSize As Size = TextRenderer.MeasureText(TextString, TextFont)

            Dim sizeOfString As New SizeF
            Dim g As Graphics = Me.CreateGraphics
            sizeOfString = g.MeasureString(TextString, TextFont)

            Dim MicX As Integer = (CommentarySizeInfo.PositionX - (sizeOfString.Width / 3))

            Obs.SetSceneItemPosition("MicIcon", MicX, MicIconInfo.PositionY)

        End If
    End Sub
    Private Sub MeasureStringMin(e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F,
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black,
        New PointF(0, 0))

    End Sub
    Function ConnectionIsActive() As Boolean
        If Obs.WSConnection.IsAlive = True Then
            Return True
        Else
            Obs.Disconnect()
            MsgBox("It looks like OBS was closed before disconnecting.  Please try re-connecting before doing any action.", MsgBoxStyle.OkOnly, ProgramName)
            ObsConnectionStatus = "Not Connected"
            lblOBS1ConnectedStatus.Text = ObsConnectionStatus
            EnableButtons(False)
            Return False
        End If
    End Function

    Private Function TransScale(rect As Rectangle, originalSize As Size, originalScaling As Double, newSize As Size, newScaling As Double) As Rectangle
        Return _cropperMath.AddScaling(_cropperMath.RemoveScaling(rect, originalSize, originalScaling), newSize, newScaling)
    End Function

    Private Sub cbLeftScaling_TextChanged(sender As Object, e As EventArgs) Handles cbLeftScaling.TextChanged

        Dim newScale = ParsePercent(cbLeftScaling.Text)
        If Math.Abs(newScale - _masterScaleLeft) < 0.0001 Or _masterScaleLeft = 0 Then
            Exit Sub
        End If
        Dim newSize = _cropperMath.AddScaling(_cropperMath.RemoveScaling(New Size(_masterWidthLeft, _masterHeightLeft), _masterScaleLeft), newScale)
        Dim newValuesGame = TransScale(
            Rectangle.FromLTRB(txtCropLeftGame_Left.Text,
                               txtCropLeftGame_Top.Text,
                               txtCropLeftGame_Right.Text,
                               txtCropLeftGame_Bottom.Text),
            New Size(_masterWidthLeft, _masterHeightLeft),
            _masterScaleLeft,
            newSize,
            newScale
            )

        txtCropLeftGame_Left.Text = newValuesGame.Left
        txtCropLeftGame_Right.Text = newValuesGame.Right
        txtCropLeftGame_Top.Text = newValuesGame.Top
        txtCropLeftGame_Bottom.Text = newValuesGame.Bottom

        Dim newValuesTimer = TransScale(
            Rectangle.FromLTRB(txtCropLeftTimer_Left.Text,
                               txtCropLeftTimer_Top.Text,
                               txtCropLeftTimer_Right.Text,
                               txtCropLeftTimer_Bottom.Text),
            New Size(_masterWidthLeft, _masterHeightLeft),
            _masterScaleLeft,
            newSize,
            newScale
            )

        txtCropLeftTimer_Left.Text = newValuesTimer.Left
        txtCropLeftTimer_Right.Text = newValuesTimer.Right
        txtCropLeftTimer_Top.Text = newValuesTimer.Top
        txtCropLeftTimer_Bottom.Text = newValuesTimer.Bottom

        _masterWidthLeft = newSize.Width
        _masterHeightLeft = newSize.Height
        _masterScaleLeft = newScale
    End Sub
    Private Sub cbRightScaling_TextChanged(sender As Object, e As EventArgs) Handles cbRightScaling.TextChanged

        Dim newScale = ParsePercent(cbRightScaling.Text)
        If Math.Abs(newScale - _masterScaleRight) < 0.0001 Or _masterScaleRight = 0 Then
            Exit Sub
        End If
        Dim newSize = _cropperMath.AddScaling(_cropperMath.RemoveScaling(New Size(_masterWidthRight, _masterHeightRight), _masterScaleRight), newScale)
        Dim newValuesGame = TransScale(
            Rectangle.FromLTRB(txtCropRightGame_Left.Text,
                               txtCropRightGame_Top.Text,
                               txtCropRightGame_Right.Text,
                               txtCropRightGame_Bottom.Text),
            New Size(_masterWidthRight, _masterHeightRight),
            _masterScaleRight,
            newSize,
            newScale
            )

        txtCropRightGame_Left.Text = newValuesGame.Left
        txtCropRightGame_Right.Text = newValuesGame.Right
        txtCropRightGame_Top.Text = newValuesGame.Top
        txtCropRightGame_Bottom.Text = newValuesGame.Bottom


        Dim newValuesTimer = TransScale(
            Rectangle.FromLTRB(txtCropRightTimer_Left.Text,
                               txtCropRightTimer_Top.Text,
                               txtCropRightTimer_Right.Text,
                               txtCropRightTimer_Bottom.Text),
            New Size(_masterWidthRight, _masterHeightRight),
            _masterScaleRight,
            newSize,
            newScale
            )

        txtCropRightTimer_Left.Text = newValuesTimer.Left
        txtCropRightTimer_Right.Text = newValuesTimer.Right
        txtCropRightTimer_Top.Text = newValuesTimer.Top
        txtCropRightTimer_Bottom.Text = newValuesTimer.Bottom

        _masterWidthRight = newSize.Width
        _masterHeightRight = newSize.Height
        _masterScaleRight = newScale
    End Sub
    Private Sub Uncrop(ByVal sourceName As String)
        Obs.SetSceneItemProperties(sourceName, 0 + My.Settings.DefaultCropTop, 0 + My.Settings.DefaultCropBottom, 0, 0)
        If ObsConnectionStatus2 = "Connected" Then
            _obs2.SetSceneItemProperties(sourceName, 0 + My.Settings.DefaultCropTop, 0 + My.Settings.DefaultCropBottom, 0, 0)
        End If
    End Sub

#End Region
End Class
