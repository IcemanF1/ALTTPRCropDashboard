Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports OBSWebsocketDotNet
Imports System.IO
Imports ALTTPRCropDashboard.Data
Imports ALTTPRCropDashboard.DB
Imports Newtonsoft.Json.Linq


Public Class OBSWebSocketCropper

    Public _obs As New OBSWebSocketPlus
    Public OBSConnectionStatus As String
    Public OBSConnectionStatus2 As String

    Dim _obs2 As New OBSWebSocketPlus
    Public ConnectionString As String
    Public ConnectionString2 As String

    Dim RSourceHeight As Integer
    Dim RSourceWidth As Integer

    Dim LSourceHeight As Integer
    Dim LSourceWidth As Integer

    Dim CropApi As CropApi

    Dim MasterWidthRight As Integer
    Dim MasterHeightRight As Integer

    Dim MasterWidthLeft As Integer
    Dim MasterHeightLeft As Integer

    Dim VLCListLeft As New DataSet
    Dim VLCListRight As New DataSet

    Dim LeftRunnerGameSceneInfo As SceneItemProperties
    Dim RightRunnerGameSceneInfo As SceneItemProperties
    Dim LeftRunnerTimerSceneInfo As SceneItemProperties
    Dim RightRunnerTimerSceneInfo As SceneItemProperties

    Dim CropperMath As New CropperMath

    Public ProgramName As String = "OBS WebSocket Cropper"

    Dim ApprovedChars As String = "0123456789"

    Dim ProgramLoaded As Boolean
    Dim Check2ndOBS As Boolean = False
    Dim LastUpdate As Integer

    Public Shared OBSSettingsResult As String

#Region " Create New Tables "
    Private Sub CreateNewSourceTable()
        If VLCListLeft.Tables.Count = 0 Then
            VLCListLeft.Tables.Add("Processes")
            VLCListLeft.Tables("Processes").Columns.Add("VLCName")
        Else
            VLCListLeft.Tables("Processes").Clear()
        End If

        If VLCListRight.Tables.Count = 0 Then
            VLCListRight.Tables.Add("Processes")
            VLCListRight.Tables("Processes").Columns.Add("VLCName")
        Else
            VLCListRight.Tables("Processes").Clear()
        End If

    End Sub

#End Region
#Region " Button Clicks "
    Private Sub btnSetRightCrop_Click(sender As Object, e As EventArgs) Handles btnSetRightCrop.Click
        If MasterHeightLeft = 0 Then
            SetMasterSourceDimensions(True)
        End If

        GetCurrentSceneInfo(True)


        SetNewNewMath(True)
    End Sub
    Private Sub btnConnectOBS1_Click(sender As Object, e As EventArgs) Handles btnConnectOBS1.Click
        ConnectToOBS()
    End Sub
    Private Sub btnGetCrop_Click(sender As Object, e As EventArgs) Handles btnGetCrop.Click
        GetCurrentCropSettings(True)
        GetCurrentCropSettings(False)
    End Sub
    Private Sub btnGetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnGetLeftCrop.Click
        GetCurrentSceneInfo(False)

        If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
            FillCurrentCropInfoFromOBS(False)
        End If

    End Sub
    Private Sub btnGetRightCrop_Click(sender As Object, e As EventArgs) Handles btnGetRightCrop.Click
        GetCurrentSceneInfo(True)

        If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
            FillCurrentCropInfoFromOBS(True)
        End If
    End Sub
    Private Sub btnSetMaster_Click(sender As Object, e As EventArgs) Handles btnSetMaster.Click
        SetMasterSourceDimensions(True)
        SetMasterSourceDimensions(False)
    End Sub
    Private Sub btnSetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSetLeftCrop.Click
        If MasterHeightLeft = 0 Then
            SetMasterSourceDimensions(False)
        End If

        GetCurrentSceneInfo(False)

        SetNewNewMath(False)
    End Sub
    Private Sub btnSetTrackCommNames_Click(sender As Object, e As EventArgs) Handles btnSetTrackCommNames.Click
        If Not String.IsNullOrWhiteSpace(My.Settings.LeftRunnerOBS) Then
            If cbLeftRunnerName.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(My.Settings.LeftRunnerOBS, cbLeftRunnerName.Text)
                If OBSConnectionStatus2 = "Connected" Then
                    _obs2.SetTextGDI(My.Settings.LeftRunnerOBS, cbLeftRunnerName.Text)
                End If
            End If
        End If
        If Not String.IsNullOrWhiteSpace(My.Settings.RightRunnerOBS) Then
            If cbRightRunnerName.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(My.Settings.RightRunnerOBS, cbRightRunnerName.Text)
                If OBSConnectionStatus2 = "Connected" Then
                    _obs2.SetTextGDI(My.Settings.RightRunnerOBS, cbRightRunnerName.Text)
                End If
            End If
        End If
        If Not String.IsNullOrWhiteSpace(My.Settings.CommentaryOBS) Then
            If txtCommentaryNames.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(My.Settings.CommentaryOBS, txtCommentaryNames.Text)
                If OBSConnectionStatus2 = "Connected" Then
                    _obs2.SetTextGDI(My.Settings.CommentaryOBS, txtCommentaryNames.Text)
                End If
            End If
        End If
        If Not String.IsNullOrWhiteSpace(My.Settings.LeftTrackerOBS) Then
            If txtLeftTrackerURL.Text.Trim.Length > 0 Then
                _obs.SetBrowserSource(My.Settings.LeftTrackerOBS, txtLeftTrackerURL.Text)
                If OBSConnectionStatus2 = "Connected" Then
                    _obs2.SetBrowserSource(My.Settings.LeftTrackerOBS, txtLeftTrackerURL.Text)
                End If
            End If
        End If
        If Not String.IsNullOrWhiteSpace(My.Settings.RightTrackerOBS) Then
            If txtRightTrackerURL.Text.Trim.Length > 0 Then
                _obs.SetBrowserSource(My.Settings.RightTrackerOBS, txtRightTrackerURL.Text)
                If OBSConnectionStatus2 = "Connected" Then
                    _obs2.SetBrowserSource(My.Settings.RightTrackerOBS, txtRightTrackerURL.Text)
                End If
            End If
        End If
    End Sub
    Private Sub btnSaveLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSaveLeftCrop.Click
        SaveRunnerCrop(False)

        RefreshRunnerNames()
    End Sub
    Private Sub btnSaveRightCrop_Click(sender As Object, e As EventArgs) Handles btnSaveRightCrop.Click
        SaveRunnerCrop(True)

        RefreshRunnerNames()
    End Sub
    Private Sub btnSyncWithServer_Click(sender As Object, e As EventArgs) Handles btnSyncWithServer.Click
        SyncWithServer()
    End Sub
    Private Sub SyncWithServer()
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings("ServerURL")) Then
                CropApi = New CropApi(ConfigurationManager.AppSettings("ServerURL"))

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
        SetVLCWindows(False)
    End Sub
    Private Sub SetVLCWindows(ByVal isRightWindow As Boolean)
        Dim VLCString As String

        If isRightWindow = False Then
            If Not String.IsNullOrWhiteSpace(cbLeftVLCSource.Text) Then
                VLCString = cbLeftVLCSource.Text.Replace(":", "#3A") & ":QWidget:vlc.exe"

                If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                    _obs.SetSourceSettings(My.Settings.LeftGameName, False, VLCString, 1)
                    If OBSConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.LeftGameName, False, VLCString, 1)
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
                    _obs.SetSourceSettings(My.Settings.LeftTimerName, False, VLCString, 1)
                    If OBSConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.LeftTimerName, False, VLCString, 1)
                    End If
                End If
            End If
        Else
            If Not String.IsNullOrWhiteSpace(cbRightVLCSource.Text) Then
                VLCString = cbRightVLCSource.Text.Replace(":", "#3A") & ":QWidget:vlc.exe"

                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    _obs.SetSourceSettings(My.Settings.RightGameName, False, VLCString, 1)
                    If OBSConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.RightGameName, False, VLCString, 1)
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName) Then
                    _obs.SetSourceSettings(My.Settings.RightTimerName, False, VLCString, 1)
                    If OBSConnectionStatus2 = "Connected" Then
                        _obs2.SetSourceSettings(My.Settings.RightTimerName, False, VLCString, 1)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btn2ndOBS_Click(sender As Object, e As EventArgs) Handles btn2ndOBS.Click
        GetINIFile(False, False)

        Check2ndOBS = True
        Timer1.Start()
    End Sub
    Private Sub btnConnectOBS2_Click(sender As Object, e As EventArgs) Handles btnConnectOBS2.Click
        ConnectToOBS2()
    End Sub
    Private Sub btnSetRightVLC_Click(sender As Object, e As EventArgs) Handles btnSetRightVLC.Click
        SetVLCWindows(True)
    End Sub
#End Region
#Region " Crop Math / Crop Settings "
    Private Sub GetCurrentCropSettings(ByVal IsRightWindow As Boolean)
        Dim scenes = _obs.ListScenes()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim Node As New TreeNode(scenes(x).Name)
            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                Dim ItemName As String
                ItemName = scenes(x).Items(y).SourceName
                If IsRightWindow = True Then
                    If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                        If ItemName.ToLower = My.Settings.RightGameName.ToLower Then
                            RSourceHeight = scenes(x).Items(y).SourceHeight
                            RSourceWidth = scenes(x).Items(y).SourceWidth
                        End If
                    End If

                Else
                    If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                        If ItemName.ToLower = My.Settings.LeftGameName.ToLower Then
                            LSourceHeight = scenes(x).Items(y).SourceHeight
                            LSourceWidth = scenes(x).Items(y).SourceWidth
                        End If
                    End If

                End If


            Next

        Next

        SetHeightLabels()
    End Sub
    Private Sub SaveRunnerCrop(ByVal isRightWindow As Boolean)
        SetMasterSourceDimensions(isRightWindow)

        Dim DefaultTopCrop, DefaultBottomCrop As Integer


        DefaultTopCrop = My.Settings.DefaultCropTop
        DefaultBottomCrop = My.Settings.DefaultCropBottom

        Dim savedMasterSize As New Size
        Dim cropWithDefault As New Rectangle
        Dim submitterName = My.Settings.TwitchChannel

        If isRightWindow = True Then
            GetCurrentCropSettings(True)

            savedMasterSize = New Size(MasterWidthRight, MasterHeightRight)

            Dim MasterSizeWithoutDefault_Right As Size = CropperMath.RemoveDefaultCropSize(savedMasterSize)

            cropWithDefault = Rectangle.FromLTRB(_txtCropRightGame_Left.Text,
                                   _txtCropRightGame_Top.Text,
                                   _txtCropRightGame_Right.Text,
                                   _txtCropRightGame_Bottom.Text)

            Dim CropWithoutDefault_RightGame As Rectangle = CropperMath.RemoveDefaultCrop(cropWithDefault)

            cropWithDefault = Rectangle.FromLTRB(_txtCropRightTimer_Left.Text,
                                                 _txtCropRightTimer_Top.Text,
                                                 _txtCropRightTimer_Right.Text,
                                                 _txtCropRightTimer_Bottom.Text)

            Dim CropWithoutDefault_RightTimer As Rectangle = CropperMath.RemoveDefaultCrop(cropWithDefault)

            Using context As New CropDbContext
                If Not String.IsNullOrWhiteSpace(cbRightRunnerName.Text) Then
                    Dim rightRunner = context.Crops.FirstOrDefault(Function(x) x.Submitter = submitterName AndAlso x.Runner = cbRightRunnerName.Text)

                    If rightRunner Is Nothing Then
                        rightRunner = New Crop With {
                                .Submitter = submitterName,
                                .Runner = cbRightRunnerName.Text,
                                .Id = Guid.NewGuid()
                            }
                        context.Crops.Add(rightRunner)
                    End If

                    rightRunner.GameCropTop = CropWithoutDefault_RightGame.Top
                    rightRunner.GameCropBottom = CropWithoutDefault_RightGame.Bottom
                    rightRunner.GameCropRight = CropWithoutDefault_RightGame.Right
                    rightRunner.GameCropLeft = CropWithoutDefault_RightGame.Left
                    rightRunner.TimerCropTop = CropWithoutDefault_RightTimer.Top
                    rightRunner.TimerCropBottom = CropWithoutDefault_RightTimer.Bottom
                    rightRunner.TimerCropRight = CropWithoutDefault_RightTimer.Right
                    rightRunner.TimerCropLeft = CropWithoutDefault_RightTimer.Left
                    rightRunner.SizeHeight = MasterSizeWithoutDefault_Right.Height
                    rightRunner.SizeWidth = MasterSizeWithoutDefault_Right.Width
                    rightRunner.SubmittedOn = Nothing
                End If

                context.SaveChanges()
            End Using
        Else
            GetCurrentCropSettings(False)

            savedMasterSize = New Size(MasterWidthLeft, MasterHeightLeft)

            Dim MasterSizeWithoutDefault_Left As Size = CropperMath.RemoveDefaultCropSize(savedMasterSize)

            cropWithDefault = Rectangle.FromLTRB(_txtCropLeftGame_Left.Text,
                                     _txtCropLeftGame_Top.Text,
                                     _txtCropLeftGame_Right.Text,
                                     _txtCropLeftGame_Bottom.Text)

            Dim CropWithoutDefault_LeftGame As Rectangle = CropperMath.RemoveDefaultCrop(cropWithDefault)

            cropWithDefault = Rectangle.FromLTRB(_txtCropLeftTimer_Left.Text,
                                                 _txtCropLeftTimer_Top.Text,
                                                 _txtCropLeftTimer_Right.Text,
                                                 _txtCropLeftTimer_Bottom.Text)


            Dim CropWithoutDefault_LeftTimer As Rectangle = CropperMath.RemoveDefaultCrop(cropWithDefault)

            Using context As New CropDbContext
                If Not String.IsNullOrWhiteSpace(cbLeftRunnerName.Text) Then
                    Dim leftRunner = context.Crops.FirstOrDefault(Function(x) x.Submitter = submitterName AndAlso x.Runner = cbLeftRunnerName.Text)

                    If leftRunner Is Nothing Then
                        leftRunner = New Crop With {
                            .Submitter = submitterName,
                            .Runner = cbLeftRunnerName.Text,
                            .Id = Guid.NewGuid()
                            }
                        context.Crops.Add(leftRunner)
                    End If

                    leftRunner.GameCropTop = CropWithoutDefault_LeftGame.Top
                    leftRunner.GameCropBottom = CropWithoutDefault_LeftGame.Bottom
                    leftRunner.GameCropRight = CropWithoutDefault_LeftGame.Right
                    leftRunner.GameCropLeft = CropWithoutDefault_LeftGame.Left
                    leftRunner.TimerCropTop = CropWithoutDefault_LeftTimer.Top
                    leftRunner.TimerCropBottom = CropWithoutDefault_LeftTimer.Bottom
                    leftRunner.TimerCropRight = CropWithoutDefault_LeftTimer.Right
                    leftRunner.TimerCropLeft = CropWithoutDefault_LeftTimer.Left
                    leftRunner.SizeHeight = MasterSizeWithoutDefault_Left.Height
                    leftRunner.SizeWidth = MasterSizeWithoutDefault_Left.Width
                    leftRunner.SubmittedOn = Nothing
                End If

                context.SaveChanges()
            End Using
        End If


    End Sub
    Private Sub SetMasterSourceDimensions(ByVal isRightWindow As Boolean)
        Dim scenes = _obs.ListScenes()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim Node As New TreeNode(scenes(x).Name)
            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                Dim ItemName As String
                ItemName = scenes(x).Items(y).SourceName
                If isRightWindow = True Then
                    If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                        If ItemName.ToLower = My.Settings.RightGameName.ToLower Then
                            MasterHeightRight = scenes(x).Items(y).SourceHeight
                            MasterWidthRight = scenes(x).Items(y).SourceWidth
                        End If
                    End If
                Else
                    If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                        If ItemName.ToLower = My.Settings.LeftGameName.ToLower Then
                            MasterHeightLeft = scenes(x).Items(y).SourceHeight
                            MasterWidthLeft = scenes(x).Items(y).SourceWidth
                        End If
                    End If
                End If
            Next

        Next

        SetHeightLabels()
    End Sub
    Private Sub ResetHeightWidthLabels()
        lblLMasterHeight.Text = "Master Height: 0"
        lblLMasterWidth.Text = "Master Width: 0"
        lblLSourceHeight.Text = "Source Height: 0"
        lblLSourceWidth.Text = "Master Width: 0"

        lblRMasterHeight.Text = "Master Height: 0"
        lblRMasterWidth.Text = "Master Width: 0"
        lblRSourceHeight.Text = "Source Height: 0"
        lblRSourceWidth.Text = "Master Width: 0"
    End Sub
    Private Sub SetHeightLabels()
        lblLMasterHeight.Text = "Master Height: " & MasterHeightLeft
        lblLMasterWidth.Text = "Master Width: " & MasterWidthLeft
        lblLSourceHeight.Text = "Source Height: " & LSourceHeight
        lblLSourceWidth.Text = "Master Width: " & LSourceWidth

        lblRMasterHeight.Text = "Master Height: " & MasterHeightRight
        lblRMasterWidth.Text = "Master Width: " & MasterWidthRight
        lblRSourceHeight.Text = "Source Height: " & RSourceHeight
        lblRSourceWidth.Text = "Master Width: " & RSourceWidth
    End Sub
    Private Sub GetCurrentSceneInfo(ByVal isRightWindow As Boolean)
        If isRightWindow = False Then
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftGameName) Then
                LeftRunnerGameSceneInfo = _obs.GetSceneItemProperties("", My.Settings.LeftGameName)
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.LeftTimerName) Then
                LeftRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", My.Settings.LeftTimerName)
            End If
        Else
            If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                RightRunnerGameSceneInfo = _obs.GetSceneItemProperties("", My.Settings.RightGameName)
            End If
            If Not String.IsNullOrWhiteSpace(My.Settings.RightTimerName) Then
                RightRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", My.Settings.RightTimerName)
            End If
        End If
    End Sub
    Private Sub ProcessCrop(cropWithDefault As Rectangle, savedMasterSize As Size, currentMasterSize As Size, sourceName As String)
        Dim resultingCrop = CropperMath.AdjustCrop(New CropInfo With {
                                                      .MasterSizeWithoutDefault = CropperMath.RemoveDefaultCropSize(savedMasterSize),
                                                      .CropWithoutDefault = CropperMath.RemoveDefaultCrop(cropWithDefault)
                                                      }, CropperMath.RemoveDefaultCropSize(currentMasterSize))


        Dim realCrop = CropperMath.AddDefaultCrop(resultingCrop.CropWithBlackBarsWithoutDefault)
        _obs.SetSceneItemCrop(sourceName, New SceneItemCropInfo With {.Top = realCrop.Top, .Bottom = realCrop.Bottom, .Left = realCrop.Left, .Right = realCrop.Right})
        If OBSConnectionStatus2 = "Connected" Then
            _obs2.SetSceneItemCrop(sourceName, New SceneItemCropInfo With {.Top = realCrop.Top, .Bottom = realCrop.Bottom, .Left = realCrop.Left, .Right = realCrop.Right})
        End If
    End Sub
    Private Sub SetNewNewMath(isRightWindow As Boolean)

        GetCurrentCropSettings(isRightWindow)

        RefreshCropperDefaultCrop()

        If isRightWindow Then
            If MasterHeightRight > 0 And MasterWidthRight > 0 Then
                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropRightGame_Left.Text,
                                                   _txtCropRightGame_Top.Text,
                                                   _txtCropRightGame_Right.Text,
                                                   _txtCropRightGame_Bottom.Text),
                                New Size(MasterWidthRight, MasterHeightRight),
                                New Size(RSourceWidth, RSourceHeight),
                                My.Settings.RightGameName
                        )
                End If

                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropRightTimer_Left.Text,
                                                   _txtCropRightTimer_Top.Text,
                                                   _txtCropRightTimer_Right.Text,
                                                   _txtCropRightTimer_Bottom.Text),
                                New Size(MasterWidthRight, MasterHeightRight),
                                New Size(RSourceWidth, RSourceHeight),
                                My.Settings.RightTimerName
                                )
                End If

            Else
                MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
            End If

        Else
            If MasterHeightLeft > 0 And MasterWidthLeft > 0 Then
                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropLeftGame_Left.Text,
                                                   _txtCropLeftGame_Top.Text,
                                                   _txtCropLeftGame_Right.Text,
                                                   _txtCropLeftGame_Bottom.Text),
                                New Size(MasterWidthLeft, MasterHeightLeft),
                                New Size(LSourceWidth, LSourceHeight),
                                My.Settings.LeftGameName
                                )
                End If

                If Not String.IsNullOrWhiteSpace(My.Settings.RightGameName) Then
                    ProcessCrop(Rectangle.FromLTRB(_txtCropLeftTimer_Left.Text,
                                                   _txtCropLeftTimer_Top.Text,
                                                   _txtCropLeftTimer_Right.Text,
                                                   _txtCropLeftTimer_Bottom.Text),
                                New Size(MasterWidthLeft, MasterHeightLeft),
                                New Size(LSourceWidth, LSourceHeight),
                                My.Settings.LeftTimerName
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
        Dim TempLeftRunner As String = cbLeftRunnerName.Text
        Dim TempRightRunner As String = cbRightRunnerName.Text

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.Runner}).Distinct().ToList()

            cbLeftRunnerName.DataSource = validNames.ToList()
            cbRightRunnerName.DataSource = validNames.ToList()
            cbLeftRunnerName.DisplayMember = "RacerName"
            cbLeftRunnerName.ValueMember = "RacerName"
            cbRightRunnerName.DisplayMember = "RacerName"
            cbRightRunnerName.ValueMember = "RacerName"

        End Using

        cbLeftRunnerName.Text = TempLeftRunner
        cbRightRunnerName.Text = TempRightRunner

    End Sub
    Private Sub RefreshCropFromData(ByVal isRightWindow As Boolean)
        Dim DefaultCropBottom, DefaultCropTop As Integer

        DefaultCropTop = My.Settings.DefaultCropTop
        DefaultCropBottom = My.Settings.DefaultCropBottom

        Dim savedMasterSize As New Size
        Dim realMasterSize As New Size
        Dim savedCrop As New Rectangle
        Dim realCrop As New Rectangle

        Using context As New CropDbContext
            Dim runnerInfo As Crop

            If (isRightWindow) Then
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.Runner = cbRightRunnerName.Text)
                If runnerInfo Is Nothing Then
                    runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.Runner = cbRightRunnerName.Text)
                End If
                If runnerInfo Is Nothing Then
                    runnerInfo = New Crop
                End If
            Else
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Submitter = My.Settings.TwitchChannel AndAlso r.Runner = cbLeftRunnerName.Text)
                If runnerInfo Is Nothing Then
                    runnerInfo = context.Crops.OrderByDescending(Function(r) r.SubmittedOn).FirstOrDefault(Function(r) r.Runner = cbLeftRunnerName.Text)
                End If
                If runnerInfo Is Nothing Then
                    runnerInfo = New Crop
                End If
            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.TimerCropLeft, runnerInfo.TimerCropTop, runnerInfo.TimerCropRight, runnerInfo.TimerCropBottom)
            realCrop = CropperMath.AddDefaultCrop(savedCrop)

            If isRightWindow Then
                txtCropRightTimer_Top.Text = realCrop.Top
                txtCropRightTimer_Bottom.Text = realCrop.Bottom
                txtCropRightTimer_Left.Text = realCrop.Left
                txtCropRightTimer_Right.Text = realCrop.Right
            Else
                txtCropLeftTimer_Top.Text = realCrop.Top
                txtCropLeftTimer_Bottom.Text = realCrop.Bottom
                txtCropLeftTimer_Left.Text = realCrop.Left
                txtCropLeftTimer_Right.Text = realCrop.Right
            End If

            savedCrop = Rectangle.FromLTRB(runnerInfo.GameCropLeft, runnerInfo.GameCropTop, runnerInfo.GameCropRight, runnerInfo.GameCropBottom)
            realCrop = CropperMath.AddDefaultCrop(savedCrop)

            If isRightWindow Then
                txtCropRightGame_Top.Text = realCrop.Top
                txtCropRightGame_Bottom.Text = realCrop.Bottom
                txtCropRightGame_Left.Text = realCrop.Left
                txtCropRightGame_Right.Text = realCrop.Right
            Else
                txtCropLeftGame_Top.Text = realCrop.Top
                txtCropLeftGame_Bottom.Text = realCrop.Bottom
                txtCropLeftGame_Left.Text = realCrop.Left
                txtCropLeftGame_Right.Text = realCrop.Right
            End If

            savedMasterSize = New Size(runnerInfo.SizeWidth, runnerInfo.SizeHeight)
            realMasterSize = CropperMath.AddDefaultCropSize(savedMasterSize)

            If isRightWindow Then
                MasterWidthRight = realMasterSize.Width
                MasterHeightRight = realMasterSize.Height
            Else
                MasterWidthLeft = realMasterSize.Width
                MasterHeightLeft = realMasterSize.Height
            End If
        End Using


        SetHeightLabels()
    End Sub
    Private Sub RefreshOBS()
        Dim lObs = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("obs", True, Globalization.CultureInfo.InvariantCulture)).ToList()

        If lObs.Count > 1 Then
            Timer1.Stop()
            GetINIFile(False, True)
            Check2ndOBS = False
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

        VLCListLeft.Clear()
        VLCListRight.Clear()

        Dim x As Integer
        For x = 0 To lVLC.Count - 1
            Dim dr As DataRow
            dr = VLCListLeft.Tables("Processes").NewRow
            dr.Item("VLCName") = lVLC.Item(x).MainWindowTitle
            VLCListLeft.Tables("Processes").Rows.Add(dr)
        Next
        VLCListRight = VLCListLeft.Copy

        cbLeftVLCSource.DataSource = VLCListLeft.Tables("Processes")
        cbLeftVLCSource.DisplayMember = "VLCName"
        cbLeftVLCSource.ValueMember = "VLCName"

        cbRightVLCSource.DataSource = VLCListRight.Tables("Processes")
        cbRightVLCSource.DisplayMember = "VLCName"
        cbRightVLCSource.ValueMember = "VLCName"

        cbRightVLCSource.Text = TRightVLC
        cbLeftVLCSource.Text = TLeftVLC

    End Sub
    Private Sub ClearTextBoxes(ByVal isRightWindow As Boolean)
        If isRightWindow = True Then
            txtCropRightGame_Bottom.Text = ""
            txtCropRightGame_Left.Text = ""
            txtCropRightGame_Right.Text = ""
            txtCropRightGame_Top.Text = ""
            txtCropRightTimer_Bottom.Text = ""
            txtCropRightTimer_Left.Text = ""
            txtCropRightTimer_Right.Text = ""
            txtCropRightTimer_Top.Text = ""
        Else
            txtCropLeftGame_Bottom.Text = ""
            txtCropLeftGame_Left.Text = ""
            txtCropLeftGame_Right.Text = ""
            txtCropLeftGame_Top.Text = ""
            txtCropLeftTimer_Bottom.Text = ""
            txtCropLeftTimer_Left.Text = ""
            txtCropLeftTimer_Right.Text = ""
            txtCropLeftTimer_Top.Text = ""
        End If
    End Sub
    Private Sub FillCurrentCropInfoFromOBS(ByVal isRightWindow As Boolean)
        If isRightWindow = True Then
            If RightRunnerTimerSceneInfo IsNot Nothing Then
                txtCropRightTimer_Top.Text = RightRunnerTimerSceneInfo.Crop.Top
                txtCropRightTimer_Bottom.Text = RightRunnerTimerSceneInfo.Crop.Bottom
                txtCropRightTimer_Left.Text = RightRunnerTimerSceneInfo.Crop.Left
                txtCropRightTimer_Right.Text = RightRunnerTimerSceneInfo.Crop.Right
            End If

            If RightRunnerGameSceneInfo IsNot Nothing Then
                txtCropRightGame_Top.Text = RightRunnerGameSceneInfo.Crop.Top
                txtCropRightGame_Bottom.Text = RightRunnerGameSceneInfo.Crop.Bottom
                txtCropRightGame_Left.Text = RightRunnerGameSceneInfo.Crop.Left
                txtCropRightGame_Right.Text = RightRunnerGameSceneInfo.Crop.Right
            End If
        Else
            If LeftRunnerTimerSceneInfo IsNot Nothing Then
                txtCropLeftTimer_Top.Text = LeftRunnerTimerSceneInfo.Crop.Top
                txtCropLeftTimer_Bottom.Text = LeftRunnerTimerSceneInfo.Crop.Bottom
                txtCropLeftTimer_Left.Text = LeftRunnerTimerSceneInfo.Crop.Left
                txtCropLeftTimer_Right.Text = LeftRunnerTimerSceneInfo.Crop.Right
            End If

            If LeftRunnerGameSceneInfo IsNot Nothing Then
                txtCropLeftGame_Top.Text = LeftRunnerGameSceneInfo.Crop.Top
                txtCropLeftGame_Bottom.Text = LeftRunnerGameSceneInfo.Crop.Bottom
                txtCropLeftGame_Left.Text = LeftRunnerGameSceneInfo.Crop.Left
                txtCropLeftGame_Right.Text = LeftRunnerGameSceneInfo.Crop.Right
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
    Public Function CheckIfKeyAllowed(ByVal KeyChar As String) As Boolean
        If Not ApprovedChars.Contains(KeyChar) And KeyChar <> vbBack Then
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
        ClearTextBoxes(True)
        RefreshCropFromData(True)
    End Sub
    Private Sub cbLeftRunner_TextChanged(sender As Object, e As EventArgs) Handles cbLeftRunnerName.TextChanged
        ClearTextBoxes(False)
        RefreshCropFromData(False)
    End Sub
#End Region

#Region " Misc Functions "
    Private Sub EnableButtons(ByVal isConnected As Boolean)
        btnGetCrop.Enabled = isConnected
        btnSetLeftCrop.Enabled = isConnected
        btnSetMaster.Enabled = isConnected
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

        gbTrackerComms.Enabled = isConnected
        gbLeftGameWindow.Enabled = isConnected
        gbRightGameWindow.Enabled = isConnected
        gbLeftTimerWindow.Enabled = isConnected
        gbRightTimerWindow.Enabled = isConnected

        cbLeftRunnerName.Enabled = isConnected
        cbRightRunnerName.Enabled = isConnected
        cbRightVLCSource.Enabled = isConnected
        cbLeftVLCSource.Enabled = isConnected

    End Sub
    Private Sub OBSWebScocketCropper_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.UpgradeRequired = True Then
            My.Settings.Upgrade()
            My.Settings.UpgradeRequired = False
            My.Settings.Save()
        End If


        ProgramLoaded = False

        ConnectionString = My.Settings.ConnectionString1 & ":" & My.Settings.ConnectionPort1

        CreateNewSourceTable()

        If My.Settings.HasFinishedWelcome = False Then
            Dim USettings As New UserSettings

            UserSettings.ShowVLCOption = True
            USettings.ShowDialog()

            If My.Settings.HasFinishedWelcome = False Then
                MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
                Me.Close()
            End If

            CheckUnusedFields()

            If OBSSettingsResult = "VLC" Then
                VLCSettings.ShowDialog()
            End If

            RefreshRunnerNames()
        Else
            EnableButtons(False)
            ResetHeightWidthLabels()

            RefreshRunnerNames()

            RefreshCropperDefaultCrop()

            CheckUnusedFields()
        End If

        chkAlwaysOnTop.Visible = My.Settings.ExpertMode
        chkAlwaysOnTop.Checked = My.Settings.AlwaysOnTop

        ProgramLoaded = True
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub GetSyncFromServer()

        Dim cropList As IEnumerable(Of RunnerInfo)
        Try
            cropList = CropApi.GetCrops()

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
    Private Sub GetINIFile(ByVal Python As Boolean, ByVal ResetWebSocketPort As Boolean)

        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        Dim FileName As String = appDataPath & "\obs-studio\global.ini"

        Dim IniContents As Dictionary(Of String, Dictionary(Of String, String)) = IniParser.ParseFile(FileName)

        For Each SectionName As String In IniContents.Keys
            For Each ValueName As String In IniContents(SectionName).Keys
                Dim Value As String = IniContents(SectionName)(ValueName)

                '[SectionName]
                'ValueName=Value
                'ValueName=Value
                '
                'SectionName: The name of the current section (ex: Jones).
                'ValueName  : The name of the current value   (ex: Email).
                'Value      : The value of [ValueName]        (ex: josh.jones@gmail.com).

                If Python = True Then
                    If SectionName.ToLower = "python" Then
                        If ValueName.ToLower = "path64bit" Then

                        End If
                    End If
                Else
                    If SectionName.ToLower = "websocketapi" Then
                        If ValueName.ToLower = "serverport" Then
                            If ResetWebSocketPort = True Then
                                IniParser.WritePrivateProfileStringW(SectionName, ValueName, My.Settings.ConnectionPort1, FileName)
                            Else
                                IniParser.WritePrivateProfileStringW(SectionName, ValueName, My.Settings.ConnectionPort2, FileName)
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
                            .Submitter = localRunner.Submitter,
                            .Id = localRunner.Id
                            }

                    CropApi.UpdateCrop(runner)
                    localRunner.SubmittedOn = runner.SubmittedOn

                Next
            Finally
                'save any changes already made, hopefully all of them.
                context.SaveChanges()
            End Try

        End Using

    End Sub
    Private Sub RefreshCropperDefaultCrop()
        CropperMath.DefaultCrop = Rectangle.FromLTRB(0, My.Settings.DefaultCropTop, 0, My.Settings.DefaultCropBottom)
    End Sub
    Private Sub ChangeUserSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserSettingsToolStripMenuItem.Click
        Dim USettings As New UserSettings

        USettings.ShowVLCOption = False
        USettings.ShowDialog()

        If My.Settings.HasFinishedWelcome = False Then
            MsgBox("There are no default settings loaded.  Program will close.  Please change and then save some settings before continuing.", MsgBoxStyle.OkOnly, ProgramName)
            Me.Close()

        Else
            RefreshRunnerNames()
            RefreshCropperDefaultCrop()
            CheckUnusedFields()
        End If
    End Sub
    Private Sub ChangeVLCSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeVLCSettingsToolStripMenuItem.Click
        VLCSettings.ShowDialog()

        RefreshCropperDefaultCrop()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LastUpdate = LastUpdate + 1

        If LastUpdate > 30 Then
            LastUpdate = 0
            If Check2ndOBS = True Then
                RefreshOBS()
            End If
        End If
    End Sub
    Public Sub ConnectToOBS2()
        Me.Cursor = Cursors.WaitCursor

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
                        OBSConnectionStatus2 = "Not Connected"
                        lblOBS2ConnectedStatus.Text = OBSConnectionStatus2
                    End If
                End If


                If _obs2.IsConnected = True Then
                    OBSConnectionStatus2 = "Connected"
                    lblOBS2ConnectedStatus.Text = OBSConnectionStatus2

                Else
                    lblOBS2ConnectedStatus.Text = "Not Connected"
                End If
            End If
        Finally

            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub ConnectToOBS()
        Me.Cursor = Cursors.WaitCursor

        Try


            ConnectionString = My.Settings.ConnectionString1 & ":" & My.Settings.ConnectionPort1

            Dim PortOpen As Boolean = _obs.IsPortOpen(ConnectionString)

            If PortOpen = False Then
                MsgBox("OBS WebSocket is not running.  Please make sure the OBS WebSocket is enabled before continuing!", MsgBoxStyle.OkOnly, ProgramName)
            Else
                If _obs.IsConnected = False Then
                    _obs.Connect(ConnectionString, My.Settings.Password1)
                Else
                    If MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                        _obs.Disconnect()
                        OBSConnectionStatus = "Not Connected"
                        lblOBS1ConnectedStatus.Text = OBSConnectionStatus
                    End If
                End If


                If _obs.IsConnected = True Then
                    OBSConnectionStatus = "Connected"
                    lblOBS1ConnectedStatus.Text = OBSConnectionStatus

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
            GetCurrentSceneInfo(False)
            SetNewNewMath(False)
        ElseIf (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
            GetCurrentSceneInfo(False)
            FillCurrentCropInfoFromOBS(False)
        ElseIf (e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control) Then
            SaveRunnerCrop(False)
            RefreshRunnerNames()
        ElseIf (e.KeyCode = Keys.T AndAlso e.Modifiers = Keys.Control) Then
            GetCurrentSceneInfo(True)
            SetNewNewMath(True)
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control) Then
            GetCurrentSceneInfo(True)
            FillCurrentCropInfoFromOBS(True)
        ElseIf (e.KeyCode = Keys.Y AndAlso e.Modifiers = Keys.Control) Then
            SaveRunnerCrop(True)
            RefreshRunnerNames()
        End If
    End Sub

    Private Sub chkAlwaysOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlwaysOnTop.CheckedChanged
        Me.TopMost = chkAlwaysOnTop.Checked
    End Sub


#End Region
End Class
