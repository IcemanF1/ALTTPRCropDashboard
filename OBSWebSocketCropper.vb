Imports System
Imports System.Configuration
Imports System.Windows.Forms
Imports OBSWebsocketDotNet
Imports System.IO
Imports ALTTPRCropDashboard.Data
Imports ALTTPRCropDashboard.DB
Imports Newtonsoft.Json.Linq


Public Class OBSWebSocketCropper

    'Dim _obs As New OBSWebsocket
    'Dim _obs2 As New OBSWebsocket

    Dim _obs As New OBSWebSocketPlus
    Dim _obs2 As New OBSWebSocketPlus
    'Dim ConnectionString As String = "ws://127.0.0.1:4444"
    'Dim ConnectionString2 As String = "ws://127.0.0.1:4443"
    Dim DefaultTopValue As Integer
    Dim DefaultBottomValue As Integer

    Dim DefaultStatusBar As Integer = 22
    Dim DefaultMenuBar As Integer = 21
    Dim DefaultPlayPause As Integer = 52

    Dim RSourceHeight As Integer
    Dim RSourceWidth As Integer

    Dim LSourceHeight As Integer
    Dim LSourceWidth As Integer

    Dim CropApi As CropApi

    Dim MasterWidthRight As Integer
    Dim MasterHeightRight As Integer

    Dim MasterWidthLeft As Integer
    Dim MasterHeightLeft As Integer

    Dim OBSSourceListLeftGame As New DataSet
    Dim OBSSourceListRightGame As New DataSet
    Dim OBSSourceListLeftTimer As New DataSet
    Dim OBSSourceListRightTimer As New DataSet
    Dim OBSSourceListLeftRunner As New DataSet
    Dim OBSSourceListRightRunner As New DataSet
    Dim OBSSourceListLeftTracker As New DataSet
    Dim OBSSourceListRightTracker As New DataSet
    Dim OBSCommentary As New DataSet


    Dim LeftRunnerGameSceneInfo As SceneItemProperties
    Dim RightRunnerGameSceneInfo As SceneItemProperties
    Dim LeftRunnerTimerSceneInfo As SceneItemProperties
    Dim RightRunnerTimerSceneInfo As SceneItemProperties

    Dim CropperMath As New CropperMath

    Dim ProgramName As String = "OBS WebSocket Cropper"

    Dim ApprovedChars As String = "0123456789"

    Dim ProgramLoaded As Boolean
#Region " Create New Tables "

    Private Sub CreateNewSourceTable()
        If OBSSourceListLeftGame.Tables.Count = 0 Then
            OBSSourceListLeftGame.Tables.Add("Sources")
            OBSSourceListLeftGame.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListLeftGame.Tables("Sources").Clear()
        End If

        If OBSSourceListRightGame.Tables.Count = 0 Then
            OBSSourceListRightGame.Tables.Add("Sources")
            OBSSourceListRightGame.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListRightGame.Tables("Sources").Clear()
        End If

        If OBSSourceListLeftTimer.Tables.Count = 0 Then
            OBSSourceListLeftTimer.Tables.Add("Sources")
            OBSSourceListLeftTimer.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListLeftTimer.Tables("Sources").Clear()
        End If

        If OBSSourceListRightTimer.Tables.Count = 0 Then
            OBSSourceListRightTimer.Tables.Add("Sources")
            OBSSourceListRightTimer.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListRightTimer.Tables("Sources").Clear()
        End If

        If OBSSourceListLeftRunner.Tables.Count = 0 Then
            OBSSourceListLeftRunner.Tables.Add("Sources")
            OBSSourceListLeftRunner.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListLeftRunner.Tables("Sources").Clear()
        End If

        If OBSSourceListRightRunner.Tables.Count = 0 Then
            OBSSourceListRightRunner.Tables.Add("Sources")
            OBSSourceListRightRunner.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListRightRunner.Tables("Sources").Clear()
        End If

        If OBSSourceListLeftTracker.Tables.Count = 0 Then
            OBSSourceListLeftTracker.Tables.Add("Sources")
            OBSSourceListLeftTracker.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListLeftTracker.Tables("Sources").Clear()
        End If

        If OBSSourceListRightTracker.Tables.Count = 0 Then
            OBSSourceListRightTracker.Tables.Add("Sources")
            OBSSourceListRightTracker.Tables("Sources").Columns.Add("SourceName")
        Else
            OBSSourceListRightTracker.Tables("Sources").Clear()
        End If
    End Sub


#End Region
#Region " Button Clicks "
    Private Sub btnSetRightCrop_Click(sender As Object, e As EventArgs) Handles btnSetRightCrop.Click
        GetCurrentSceneInfo(True)

        If chkDifferentMath.Checked = True Then
            If chkNewNewMath.Checked = True Then
                SetCropNewMath(True)
            End If

            If chkOldMath.Checked = True Then
                SetCrop_OriginalMath(True)
            End If
        Else
            SetNewNewMath(True)
        End If

    End Sub
    Private Sub btnConnectOBS1_Click(sender As Object, e As EventArgs) Handles btnConnectOBS1.Click
        Me.Cursor = Cursors.WaitCursor

        If _obs.IsConnected = False Then
            _obs.Connect(txtConnectionString1.Text, txtPassword1.Text)
        Else
            If MsgBox("This connection is already connected.  Do you wish to disconnect?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
                _obs.Disconnect()
                lblOBS1ConnectedStatus.Text = "Not Connected"
            End If
        End If


        If _obs.IsConnected = True Then
            lblOBS1ConnectedStatus.Text = "Connected"

            CreateNewSourceTable()
            RefreshScenes()
            SetUserSettings()

            EnableButtons(True)
        Else
            lblOBS1ConnectedStatus.Text = "Not Connected"
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnConnectOBS2_Click(sender As Object, e As EventArgs) Handles btnConnectOBS2.Click
        Me.Cursor = Cursors.WaitCursor

        If _obs2.IsConnected = False Then
            _obs2.Connect(txtConnectionString2.Text, txtPassword2.Text)
        Else
            MsgBox("Is already connected.")
        End If

        If _obs2.IsConnected = True Then
            lblOBS2ConnectedStatus.Text = "Connected"
        Else
            lblOBS2ConnectedStatus.Text = "Not Connected"
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnGetCrop_Click(sender As Object, e As EventArgs) Handles btnGetCrop.Click
        GetCurrentCropSettings(True)
        GetCurrentCropSettings(False)
    End Sub
    Private Sub btnRefreshScenes_Click(sender As Object, e As EventArgs) Handles btnRefreshScenes.Click
        RefreshScenes()
        SetUserSettings()
    End Sub
    Private Sub btnSetMaster_Click(sender As Object, e As EventArgs) Handles btnSetMaster.Click
        SetMasterSourceDimensions()
    End Sub
    Private Sub btnSetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSetLeftCrop.Click
        GetCurrentSceneInfo(False)

        If chkDifferentMath.Checked = True Then
            If chkNewNewMath.Checked = True Then
                SetCropNewMath(False)
            End If

            If chkOldMath.Checked = True Then
                SetCrop_OriginalMath(False)
            End If
        Else
            SetNewNewMath(False)
        End If
    End Sub
    Private Sub btnSaveRunnerCrop_Click(sender As Object, e As EventArgs) Handles btnSaveRunnerCrop.Click
        Dim dr As DataRow

        SetMasterSourceDimensions()

        GetCurrentCropSettings(True)
        GetCurrentCropSettings(False)

        Dim DefaultTopCrop, DefaultBottomCrop As Integer

        If txtDefaultCropTop.Text.Trim.Length > 0 Then
            DefaultTopCrop = txtDefaultCropTop.Text
        Else
            DefaultTopCrop = 0
        End If

        If txtDefaultCropBottom.Text.Trim.Length > 0 Then
            DefaultBottomCrop = txtDefaultCropBottom.Text
        Else
            DefaultBottomCrop = 0
        End If

        Dim savedMasterSize As New Size

        savedMasterSize = New Size(MasterWidthRight, MasterHeightRight)

        Dim MasterSizeWithoutDefault_Right As Size = CropperMath.RemoveDefaultCropSize(savedMasterSize)


        savedMasterSize = New Size(MasterWidthLeft, MasterHeightLeft)

        Dim MasterSizeWithoutDefault_Left As Size = CropperMath.RemoveDefaultCropSize(savedMasterSize)

        Dim cropWithDefault As New Rectangle

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

        Dim submitterName = "Iceman_F1"

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


        RefreshRunnerNames()
    End Sub
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Dim DefaultCropTop, DefaultCropBottom As Integer

        If txtDefaultCropTop.Text.Trim.Length > 0 Then
            DefaultCropTop = txtDefaultCropTop.Text
        Else
            DefaultCropTop = 0
        End If

        If txtDefaultCropBottom.Text.Trim.Length > 0 Then
            DefaultCropBottom = txtDefaultCropBottom.Text
        Else
            DefaultCropBottom = 0
        End If

        CropperMath.DefaultCrop = Rectangle.FromLTRB(0, txtDefaultCropTop.Text, 0, txtDefaultCropBottom.Text)

        My.Settings.DefaultCropBottom = DefaultCropBottom
        My.Settings.DefaultCropTop = DefaultCropTop
        My.Settings.LeftTimerName = cbLeftTimerWindow.Text
        My.Settings.LeftGameName = cbLeftGameWindow.Text
        My.Settings.RightTimerName = cbRightTimerWindow.Text
        My.Settings.RightGameName = cbRightGameWindow.Text
        My.Settings.ConnectionString1 = txtConnectionString1.Text
        My.Settings.ConnectionString2 = txtConnectionString2.Text
        My.Settings.Password1 = txtPassword1.Text
        My.Settings.Password2 = txtPassword2.Text
        My.Settings.LeftRunnerOBS = cbLeftRunnerOBS.Text
        My.Settings.RightRunnerOBS = cbRightRunnerOBS.Text
        My.Settings.LeftTrackerOBS = cbLeftTrackerOBS.Text
        My.Settings.RightTrackerOBS = cbRightTrackerOBS.Text
        My.Settings.CommentaryOBS = cbCommentaryOBS.Text
        My.Settings.VLCMenuBar = chkMenuBar.Checked
        My.Settings.VLCPlayPauseControls = chkPlayPauseControls.Checked
        My.Settings.VLCOverrideDefault = chkOverrideDefault.Checked
        My.Settings.VLCStatusBar = chkStatusBar.Checked

        My.Settings.Save()

    End Sub
    Private Sub btnSetTrackCommNames_Click(sender As Object, e As EventArgs) Handles btnSetTrackCommNames.Click
        If cbLeftRunnerOBS.Text.Trim.Length > 0 Then
            If cbLeftRunnerName.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(cbLeftRunnerOBS.Text, cbLeftRunnerName.Text)
            End If
        End If
        If cbRightRunnerOBS.Text.Trim.Length > 0 Then
            If cbRightRunnerName.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(cbRightRunnerOBS.Text, cbRightRunnerName.Text)
            End If
        End If
        If cbCommentaryOBS.Text.Trim.Length > 0 Then
            If txtCommentaryNames.Text.Trim.Length > 0 Then
                _obs.SetTextGDI(cbCommentaryOBS.Text, txtCommentaryNames.Text)
            End If
        End If
        If cbLeftTrackerOBS.Text.Trim.Length > 0 Then
            If txtLeftTrackerURL.Text.Trim.Length > 0 Then
                _obs.SetBrowserSource(cbLeftTrackerOBS.Text, txtLeftTrackerURL.Text)
            End If
        End If
        If cbRightTrackerOBS.Text.Trim.Length > 0 Then
            If txtRightTrackerURL.Text.Trim.Length > 0 Then
                _obs.SetBrowserSource(cbRightTrackerOBS.Text, txtRightTrackerURL.Text)
            End If
        End If
    End Sub
    Private Sub btnGetCropFromOBS_Click(sender As Object, e As EventArgs) Handles btnGetCropFromOBS.Click
        GetCurrentSceneInfo(True)
        GetCurrentSceneInfo(False)

        If MsgBox("This action will overwrite the current crop info for all game/timer windows!  Are you sure you wish to continue?", MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
            FillCurrentCropInfoFromOBS()
        End If
    End Sub
    Private Sub btnSyncWithServer_Click(sender As Object, e As EventArgs) Handles btnSyncWithServer.Click
        Me.Cursor = Cursors.WaitCursor


        WebCalls.WebURL = ConfigurationManager.AppSettings("ServerURL")
        CropApi = New CropApi(ConfigurationManager.AppSettings("ServerURL"))

        SendToServer()
        GetSyncFromServer()
        Me.Cursor = Cursors.Default
    End Sub
#End Region
#Region " Crop Math / Crop Settings "
    Private Sub SetCropNewMath(ByVal isRightWindow As Boolean)
        Dim NCropTopTimer, NCropBottomTimer, NCropLeftTimer, NCropRightTimer,
            NCropTopGame, NCropBottomGame, NCropLeftGame, NCropRightGame As Integer

        GetCurrentCropSettings(isRightWindow)

        Dim DefaultTopCrop, DefaultBottomCrop,
            MasterSourceHeight, MasterSourceWidth,
            SourceHeight, SourceWidth As Integer

        DefaultTopCrop = txtDefaultCropTop.Text
        DefaultBottomCrop = txtDefaultCropBottom.Text

        If isRightWindow = True Then
            NCropTopTimer = txtCropRightTimer_Top.Text - DefaultTopCrop
            NCropBottomTimer = txtCropRightTimer_Bottom.Text - DefaultBottomCrop
            NCropLeftTimer = txtCropRightTimer_Left.Text
            NCropRightTimer = txtCropRightTimer_Right.Text

            NCropTopGame = txtCropRightGame_Top.Text - DefaultTopCrop
            NCropBottomGame = txtCropRightGame_Bottom.Text - DefaultBottomCrop
            NCropLeftGame = txtCropRightGame_Left.Text
            NCropRightGame = txtCropRightGame_Right.Text

            MasterSourceHeight = MasterHeightRight
            MasterSourceWidth = MasterWidthRight
            SourceHeight = RSourceHeight
            SourceWidth = RSourceWidth
        Else
            NCropTopTimer = txtCropLeftTimer_Top.Text - DefaultTopCrop
            NCropBottomTimer = txtCropLeftTimer_Bottom.Text - DefaultBottomCrop
            NCropLeftTimer = txtCropLeftTimer_Left.Text
            NCropRightTimer = txtCropLeftTimer_Right.Text

            NCropTopGame = txtCropLeftGame_Top.Text - DefaultTopCrop
            NCropBottomGame = txtCropLeftGame_Bottom.Text - DefaultBottomCrop
            NCropLeftGame = txtCropLeftGame_Left.Text
            NCropRightGame = txtCropLeftGame_Right.Text

            MasterSourceHeight = MasterHeightLeft
            MasterSourceWidth = MasterWidthLeft
            SourceHeight = LSourceHeight
            SourceWidth = LSourceWidth
        End If

        Dim CropGame As New SceneItemCropInfo
        Dim CropTimer As New SceneItemCropInfo

        CropGame = MathCalcs.SetCropNewMath(NCropTopGame, NCropLeftGame, NCropBottomGame, NCropRightGame,
                                            DefaultTopCrop, DefaultBottomCrop, MasterSourceHeight, MasterSourceWidth,
                                            SourceHeight, SourceWidth)
        CropTimer = MathCalcs.SetCropNewMath(NCropTopTimer, NCropLeftTimer, NCropBottomTimer, NCropRightTimer,
                                            DefaultTopCrop, DefaultBottomCrop, MasterSourceHeight, MasterSourceWidth,
                                            SourceHeight, SourceWidth)

        If isRightWindow = True Then
            _obs.SetSceneItemProperties(cbRightGameWindow.Text, CropGame.Top, CropGame.Bottom, CropGame.Left, CropGame.Right)
            _obs.SetSceneItemProperties(cbRightTimerWindow.Text, CropTimer.Top, CropTimer.Bottom, CropTimer.Left, CropTimer.Right)
        Else
            _obs.SetSceneItemCrop(cbLeftGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbLeftTimerWindow.Text, CropTimer)
        End If
    End Sub
    Private Sub SetCrop_OriginalMath(ByVal isRightWindow As Boolean)
        Dim NCropTopTimer, NCropBottomTimer, NCropLeftTimer, NCropRightTimer,
            NCropTopGame, NCropBottomGame, NCropLeftGame, NCropRightGame As Integer

        GetCurrentCropSettings(isRightWindow)

        Dim DefaultTopCrop, DefaultBottomCrop,
            MasterSourceHeight, MasterSourceWidth,
        SourceWidth, SourceHeight As Integer


        DefaultTopCrop = txtDefaultCropTop.Text
        DefaultBottomCrop = txtDefaultCropBottom.Text

        If isRightWindow = True Then
            MasterSourceHeight = MasterHeightRight
            MasterSourceWidth = MasterWidthRight
            SourceWidth = RSourceWidth
            SourceHeight = RSourceHeight
        Else
            MasterSourceHeight = MasterHeightLeft
            MasterSourceWidth = MasterWidthLeft
            SourceWidth = LSourceWidth
            SourceHeight = LSourceHeight
        End If


        Dim CTopGame, CBottomGame, CLeftGame, CRightGame,
                CTopTimer, CBottomTimer, CLeftTimer, CRightTimer As Integer

        If isRightWindow = True Then
            If txtCropRightGame_Top.Text.Trim.Length > 0 Then
                CTopGame = txtCropRightGame_Top.Text
                CBottomGame = txtCropRightGame_Bottom.Text
                CLeftGame = txtCropRightGame_Left.Text
                CRightGame = txtCropRightGame_Right.Text
            Else
                CTopGame = 0
                CBottomGame = 0
                CLeftGame = 0
                CRightGame = 0
            End If

            If txtCropRightTimer_Top.Text.Trim.Length > 0 Then
                CTopTimer = txtCropRightTimer_Top.Text
                CBottomTimer = txtCropRightTimer_Bottom.Text
                CLeftTimer = txtCropRightTimer_Left.Text
                CRightTimer = txtCropRightTimer_Right.Text
            Else
                CTopTimer = 0
                CBottomTimer = 0
                CLeftTimer = 0
                CRightTimer = 0
            End If
        Else
            If txtCropLeftGame_Top.Text.Trim.Length > 0 Then
                CTopGame = txtCropLeftGame_Top.Text
                CBottomGame = txtCropLeftGame_Bottom.Text
                CLeftGame = txtCropLeftGame_Left.Text
                CRightGame = txtCropLeftGame_Right.Text
            Else
                CTopTimer = 0
                CBottomTimer = 0
                CLeftTimer = 0
                CRightTimer = 0
            End If

            If txtCropLeftTimer_Top.Text.Trim.Length > 0 Then
                CTopTimer = txtCropLeftTimer_Top.Text
                CBottomTimer = txtCropLeftTimer_Bottom.Text
                CLeftTimer = txtCropLeftTimer_Left.Text
                CRightTimer = txtCropLeftTimer_Right.Text
            Else
                CTopTimer = 0
                CBottomTimer = 0
                CLeftTimer = 0
                CRightTimer = 0
            End If
        End If


        Dim CropGame As New SceneItemCropInfo
        Dim CropTimer As New SceneItemCropInfo

        CropGame = MathCalcs.SetCropOriginalMath(NCropTopGame, NCropLeftGame, NCropBottomGame, NCropRightGame,
                                            DefaultTopCrop, DefaultBottomCrop, MasterSourceHeight, MasterSourceWidth,
                                            SourceHeight, SourceWidth)
        CropTimer = MathCalcs.SetCropOriginalMath(NCropTopTimer, NCropLeftTimer, NCropBottomTimer, NCropRightTimer,
                                            DefaultTopCrop, DefaultBottomCrop, MasterSourceHeight, MasterSourceWidth,
                                            SourceHeight, SourceWidth)

        If isRightWindow = True Then
            _obs.SetSceneItemProperties(cbRightGameWindow.Text, CropGame.Top, CropGame.Bottom, CropGame.Left, CropGame.Right)
            _obs.SetSceneItemProperties(cbRightTimerWindow.Text, CropTimer.Top, CropTimer.Bottom, CropTimer.Left, CropTimer.Right)
        Else
            _obs.SetSceneItemCrop(cbLeftGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbLeftTimerWindow.Text, CropTimer)
        End If
    End Sub
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
                    If ItemName.ToLower = cbRightGameWindow.Text.ToLower Then
                        RSourceHeight = scenes(x).Items(y).SourceHeight
                        RSourceWidth = scenes(x).Items(y).SourceWidth
                    End If
                Else
                    If ItemName.ToLower = cbLeftGameWindow.Text.ToLower Then
                        LSourceHeight = scenes(x).Items(y).SourceHeight
                        LSourceWidth = scenes(x).Items(y).SourceWidth
                    End If
                End If


            Next

        Next

        SetHeightLabels()
    End Sub
    Private Sub SetMasterSourceDimensions()
        Dim scenes = _obs.ListScenes()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim Node As New TreeNode(scenes(x).Name)
            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                Dim ItemName As String
                ItemName = scenes(x).Items(y).SourceName
                If ItemName.ToLower = cbRightGameWindow.Text.ToLower Then
                    MasterHeightRight = scenes(x).Items(y).SourceHeight
                    MasterWidthRight = scenes(x).Items(y).SourceWidth
                ElseIf ItemName.ToLower = cbLeftGameWindow.Text.ToLower Then
                    MasterHeightLeft = scenes(x).Items(y).SourceHeight
                    MasterWidthLeft = scenes(x).Items(y).SourceWidth
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
            If cbLeftGameWindow.Text.Trim.Length > 0 Then
                LeftRunnerGameSceneInfo = _obs.GetSceneItemProperties("", cbLeftGameWindow.Text)
            End If
            If cbLeftTimerWindow.Text.Trim.Length > 0 Then
                LeftRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", cbLeftTimerWindow.Text)
            End If
        Else
            If cbRightGameWindow.Text.Trim.Length > 0 Then
                RightRunnerGameSceneInfo = _obs.GetSceneItemProperties("", cbRightGameWindow.Text)
            End If
            If cbRightTimerWindow.Text.Trim.Length > 0 Then
                RightRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", cbRightTimerWindow.Text)
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
    End Sub
    Private Sub SetNewNewMath(isRightWindow As Boolean)

        GetCurrentCropSettings(isRightWindow)

        CropperMath.DefaultCrop = Rectangle.FromLTRB(0, txtDefaultCropTop.Text, 0, txtDefaultCropBottom.Text)

        If isRightWindow Then
            If MasterHeightRight > 0 And MasterWidthRight > 0 Then
                ProcessCrop(Rectangle.FromLTRB(_txtCropRightGame_Left.Text,
                                               _txtCropRightGame_Top.Text,
                                               _txtCropRightGame_Right.Text,
                                               _txtCropRightGame_Bottom.Text),
                            New Size(MasterWidthRight, MasterHeightRight),
                            New Size(RSourceWidth, RSourceHeight),
                            cbRightGameWindow.Text
                    )
                ProcessCrop(Rectangle.FromLTRB(_txtCropRightTimer_Left.Text,
                                               _txtCropRightTimer_Top.Text,
                                               _txtCropRightTimer_Right.Text,
                                               _txtCropRightTimer_Bottom.Text),
                            New Size(MasterWidthRight, MasterHeightRight),
                            New Size(RSourceWidth, RSourceHeight),
                            cbRightTimerWindow.Text
                            )
            Else
                MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
            End If

        Else
            If MasterHeightLeft > 0 And MasterWidthLeft > 0 Then
                ProcessCrop(Rectangle.FromLTRB(_txtCropLeftGame_Left.Text,
                                               _txtCropLeftGame_Top.Text,
                                               _txtCropLeftGame_Right.Text,
                                               _txtCropLeftGame_Bottom.Text),
                            New Size(MasterWidthLeft, MasterHeightLeft),
                            New Size(LSourceWidth, LSourceHeight),
                            cbLeftGameWindow.Text
                            )
                ProcessCrop(Rectangle.FromLTRB(_txtCropLeftTimer_Left.Text,
                                               _txtCropLeftTimer_Top.Text,
                                               _txtCropLeftTimer_Right.Text,
                                               _txtCropLeftTimer_Bottom.Text),
                            New Size(MasterWidthLeft, MasterHeightLeft),
                            New Size(LSourceWidth, LSourceHeight),
                            cbLeftTimerWindow.Text
                            )
            Else
                MsgBox("Master Height/Width is 0.  Can't crop yet.", MsgBoxStyle.OkOnly, ProgramName)
            End If


        End If

    End Sub
#End Region
#Region " Refresh / Set User Info "
    Private Sub RefreshScenes()
        Dim scenes = _obs.ListScenes()

        OBSSourceListLeftGame.Clear()
        OBSSourceListLeftTimer.Clear()
        OBSSourceListRightGame.Clear()
        OBSSourceListRightTimer.Clear()
        OBSSourceListLeftRunner.Clear()
        OBSSourceListRightRunner.Clear()
        OBSSourceListLeftTracker.Clear()
        OBSSourceListRightTracker.Clear()
        OBSCommentary.Clear()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim dr As DataRow

            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                dr = OBSSourceListLeftGame.Tables("Sources").NewRow
                dr.Item("SourceName") = scenes(x).Items(y).SourceName
                OBSSourceListLeftGame.Tables("Sources").Rows.Add(dr)
            Next

        Next
        OBSSourceListRightGame = OBSSourceListLeftGame.Copy
        OBSSourceListRightTimer = OBSSourceListLeftGame.Copy
        OBSSourceListLeftTimer = OBSSourceListLeftGame.Copy
        OBSSourceListLeftRunner = OBSSourceListLeftGame.Copy
        OBSSourceListRightRunner = OBSSourceListLeftGame.Copy
        OBSSourceListLeftTracker = OBSSourceListLeftGame.Copy
        OBSSourceListRightTracker = OBSSourceListLeftGame.Copy
        OBSCommentary = OBSSourceListLeftGame.Copy

        cbRightGameWindow.DataSource = OBSSourceListRightGame.Tables("Sources")
        cbRightGameWindow.DisplayMember = "SourceName"
        cbRightGameWindow.ValueMember = "SourceName"

        cbRightTimerWindow.DataSource = OBSSourceListRightTimer.Tables("Sources")
        cbRightTimerWindow.DisplayMember = "SourceName"
        cbRightTimerWindow.ValueMember = "SourceName"

        cbLeftGameWindow.DataSource = OBSSourceListLeftGame.Tables("Sources")
        cbLeftGameWindow.DisplayMember = "SourceName"
        cbLeftGameWindow.ValueMember = "SourceName"

        cbLeftTimerWindow.DataSource = OBSSourceListLeftTimer.Tables("Sources")
        cbLeftTimerWindow.DisplayMember = "SourceName"
        cbLeftTimerWindow.ValueMember = "SourceName"

        cbLeftRunnerOBS.DataSource = OBSSourceListLeftRunner.Tables("Sources")
        cbLeftRunnerOBS.DisplayMember = "SourceName"
        cbLeftRunnerOBS.ValueMember = "SourceName"

        cbRightRunnerOBS.DataSource = OBSSourceListRightRunner.Tables("Sources")
        cbRightRunnerOBS.DisplayMember = "SourceName"
        cbRightRunnerOBS.ValueMember = "SourceName"

        cbLeftTrackerOBS.DataSource = OBSSourceListLeftTracker.Tables("Sources")
        cbLeftTrackerOBS.DisplayMember = "SourceName"
        cbLeftTrackerOBS.ValueMember = "SourceName"

        cbRightTrackerOBS.DataSource = OBSSourceListRightTracker.Tables("Sources")
        cbRightTrackerOBS.DisplayMember = "SourceName"
        cbRightTrackerOBS.ValueMember = "SourceName"

        cbCommentaryOBS.DataSource = OBSCommentary.Tables("Sources")
        cbCommentaryOBS.DisplayMember = "SourceName"
        cbCommentaryOBS.ValueMember = "SourceName"

        SetBlankDropdowns()
    End Sub
    Private Sub SetBlankDropdowns()
        cbLeftTimerWindow.Text = ""
        cbLeftGameWindow.Text = ""
        cbRightTimerWindow.Text = ""
        cbRightGameWindow.Text = ""
        cbLeftRunnerOBS.Text = ""
        cbRightRunnerOBS.Text = ""
        cbLeftTrackerOBS.Text = ""
        cbRightTrackerOBS.Text = ""
        cbCommentaryOBS.Text = ""
    End Sub
    Private Sub RefreshRunnerNames()
        Dim TempLeftRunner As String = cbLeftRunnerName.Text
        Dim TempRightRunner As String = cbRightRunnerName.Text

        Using context As New CropDbContext
            Dim validNames = context.Crops.Select(Function(r) New With {.RacerName = r.Runner}).Distinct().ToList()

            cbLeftRunnerName.DataSource = validNames
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

        DefaultCropTop = txtDefaultCropTop.Text
        DefaultCropBottom = txtDefaultCropBottom.Text

        Dim savedMasterSize As New Size
        Dim realMasterSize As New Size
        Dim savedCrop As New Rectangle
        Dim realCrop As New Rectangle

        Using context As New CropDbContext
            Dim runnerInfo As Crop

            If (isRightWindow) Then
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Runner = cbRightRunnerName.Text)
                If runnerInfo Is Nothing Then
                    runnerInfo = New Crop
                End If

            Else
                runnerInfo = context.Crops.FirstOrDefault(Function(r) r.Runner = cbLeftRunnerName.Text)
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
    Private Sub SetUserSettings()

        WebCalls.WebURL = ConfigurationManager.AppSettings("ServerURL")
        CropApi = New CropApi(ConfigurationManager.AppSettings("ServerURL"))
        txtDefaultCropTop.Text = My.Settings.DefaultCropTop
        txtDefaultCropBottom.Text = My.Settings.DefaultCropBottom
        cbLeftTimerWindow.Text = My.Settings.LeftTimerName
        cbLeftGameWindow.Text = My.Settings.LeftGameName
        cbRightTimerWindow.Text = My.Settings.RightTimerName
        cbRightGameWindow.Text = My.Settings.RightGameName
        cbLeftRunnerOBS.Text = My.Settings.LeftRunnerOBS
        cbRightRunnerOBS.Text = My.Settings.RightRunnerOBS
        cbLeftTrackerOBS.Text = My.Settings.LeftTrackerOBS
        cbRightTrackerOBS.Text = My.Settings.RightTrackerOBS
        cbCommentaryOBS.Text = My.Settings.CommentaryOBS
        chkOverrideDefault.Checked = My.Settings.VLCOverrideDefault
        chkPlayPauseControls.Checked = My.Settings.VLCPlayPauseControls
        chkMenuBar.Checked = My.Settings.VLCMenuBar
        chkStatusBar.Checked = My.Settings.VLCStatusBar
        CropperMath.DefaultCrop = Rectangle.FromLTRB(0, txtDefaultCropTop.Text, 0, txtDefaultCropBottom.Text)

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
    Private Sub FillCurrentCropInfoFromOBS()
        If RightRunnerTimerSceneInfo Is Nothing = False Then
            txtCropRightTimer_Top.Text = RightRunnerTimerSceneInfo.Crop.Top
            txtCropRightTimer_Bottom.Text = RightRunnerTimerSceneInfo.Crop.Bottom
            txtCropRightTimer_Left.Text = RightRunnerTimerSceneInfo.Crop.Left
            txtCropRightTimer_Right.Text = RightRunnerTimerSceneInfo.Crop.Right
        End If

        If RightRunnerGameSceneInfo Is Nothing = False Then
            txtCropRightGame_Top.Text = RightRunnerGameSceneInfo.Crop.Top
            txtCropRightGame_Bottom.Text = RightRunnerGameSceneInfo.Crop.Bottom
            txtCropRightGame_Left.Text = RightRunnerGameSceneInfo.Crop.Left
            txtCropRightGame_Right.Text = RightRunnerGameSceneInfo.Crop.Right
        End If

        If LeftRunnerTimerSceneInfo Is Nothing = False Then
            txtCropLeftTimer_Top.Text = LeftRunnerTimerSceneInfo.Crop.Top
            txtCropLeftTimer_Bottom.Text = LeftRunnerTimerSceneInfo.Crop.Bottom
            txtCropLeftTimer_Left.Text = LeftRunnerTimerSceneInfo.Crop.Left
            txtCropLeftTimer_Right.Text = LeftRunnerTimerSceneInfo.Crop.Right
        End If

        If LeftRunnerGameSceneInfo Is Nothing = False Then
            txtCropLeftGame_Top.Text = LeftRunnerGameSceneInfo.Crop.Top
            txtCropLeftGame_Bottom.Text = LeftRunnerGameSceneInfo.Crop.Bottom
            txtCropLeftGame_Left.Text = LeftRunnerGameSceneInfo.Crop.Left
            txtCropLeftGame_Right.Text = LeftRunnerGameSceneInfo.Crop.Right
        End If
    End Sub
#End Region
#Region " Block crop text boxes / key presses "
    Private Sub txtDefaultCropTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDefaultCropTop.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtDefaultCropBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDefaultCropBottom.KeyPress
        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
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
    Function CheckIfKeyAllowed(ByVal KeyChar As String) As Boolean
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
        btnConnectOBS2.Enabled = isConnected
        btnGetCrop.Enabled = isConnected
        btnGetCropFromOBS.Enabled = isConnected
        btnRefreshScenes.Enabled = isConnected
        btnSaveRunnerCrop.Enabled = isConnected
        btnSaveSettings.Enabled = isConnected
        btnSetLeftCrop.Enabled = isConnected
        btnSetMaster.Enabled = isConnected
        btnSetRightCrop.Enabled = isConnected
        btnSetTrackCommNames.Enabled = isConnected
        btnSyncWithServer.Enabled = isConnected

        gbConnection2.Enabled = isConnected
        gbTrackerComms.Enabled = isConnected
        gbLeftGameWindow.Enabled = isConnected
        gbRightGameWindow.Enabled = isConnected
        gbLeftTimerWindow.Enabled = isConnected
        gbRightTimerWindow.Enabled = isConnected

        cbLeftRunnerName.Enabled = isConnected
        cbLeftRunnerOBS.Enabled = isConnected
        cbRightRunnerOBS.Enabled = isConnected
        cbRightRunnerName.Enabled = isConnected

        txtDefaultCropBottom.Enabled = isConnected
        txtDefaultCropTop.Enabled = isConnected
    End Sub
    Private Sub OBSWebScocketCropper_Load(sender As Object, e As EventArgs) Handles Me.Load
        ProgramLoaded = False

        txtDefaultCropTop.Text = 0
        txtDefaultCropBottom.Text = 0

        EnableButtons(False)
        ResetHeightWidthLabels()

        RefreshRunnerNames()

        txtConnectionString1.Text = My.Settings.ConnectionString1
        txtConnectionString2.Text = My.Settings.ConnectionString2
        txtPassword1.Text = My.Settings.Password1
        txtPassword2.Text = My.Settings.Password2

        ProgramLoaded = True
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This program was created by Iceman_F1 with the help and ideas from Hancin and various other members of the ALTTPR community." & vbCrLf & vbCrLf &
            "The initial goal of this program was to make restream setup faster.  While it is still in the beginning phases, and is very much a work in progress, it is slowly evolving into the tool it is meant to be.",
             MsgBoxStyle.OkOnly, ProgramName)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ReadOBSINIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadOBSINIToolStripMenuItem.Click
        GetINIFile()
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

    Private Sub GetINIFile()

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

                If SectionName.ToLower = "python" Then
                    If ValueName.ToLower = "path64bit" Then
                        MsgBox(Value, MsgBoxStyle.OkOnly)
                        ''IniParser.WritePrivateProfileStringW(SectionName, ValueName, Value & "_Test", FileName)
                    End If
                End If
                'Console.WriteLine(SectionName & ": " & ValueName & " = " & Value)
            Next
        Next
    End Sub
    Private Sub chkDifferentMath_CheckedChanged(sender As Object, e As EventArgs) Handles chkDifferentMath.CheckedChanged
        If chkDifferentMath.Checked = True Then
            chkOldMath.Visible = True
            chkNewNewMath.Visible = True
        Else
            chkOldMath.Visible = False
            chkNewNewMath.Visible = False
        End If

        If chkNewNewMath.Checked = False And chkOldMath.Checked = False Then
            chkNewNewMath.Checked = True
        End If
    End Sub
    Private Sub chkOldMath_CheckedChanged(sender As Object, e As EventArgs) Handles chkOldMath.CheckedChanged
        If chkOldMath.Checked = True Then
            chkNewNewMath.Checked = False
        Else
            chkNewNewMath.Checked = True
        End If
    End Sub
    Private Sub chkNewNewMath_CheckedChanged(sender As Object, e As EventArgs) Handles chkNewNewMath.CheckedChanged
        If chkNewNewMath.Checked = True Then
            chkOldMath.Checked = False
        Else
            chkOldMath.Checked = True
        End If
    End Sub
    Private Sub txtDefaultCropTop_Leave(sender As Object, e As EventArgs) Handles txtDefaultCropTop.Leave
        If txtDefaultCropTop.Text.Trim.Length = 0 Then
            txtDefaultCropTop.Text = 0
        End If

        If ProgramLoaded = True Then
            CropperMath.DefaultCrop = Rectangle.FromLTRB(0, txtDefaultCropTop.Text, 0, txtDefaultCropBottom.Text)

            RefreshCropFromData(False)
            RefreshCropFromData(True)
        End If
    End Sub
    Private Sub txtDefaultCropBottom_Leave(sender As Object, e As EventArgs) Handles txtDefaultCropBottom.Leave
        If txtDefaultCropBottom.Text.Trim.Length = 0 Then
            txtDefaultCropBottom.Text = 0
        End If

        If ProgramLoaded = True Then
            CropperMath.DefaultCrop = Rectangle.FromLTRB(0, txtDefaultCropTop.Text, 0, txtDefaultCropBottom.Text)

            RefreshCropFromData(False)
            RefreshCropFromData(True)
        End If
    End Sub
    Private Sub chkMenuBar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMenuBar.CheckedChanged
        If chkMenuBar.Checked = True Then
            DefaultTopValue = DefaultMenuBar
        Else
            DefaultTopValue = 0
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub chkStatusBar_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatusBar.CheckedChanged
        If chkStatusBar.Checked = True Then
            DefaultBottomValue = DefaultBottomValue + DefaultStatusBar
        Else
            DefaultBottomValue = DefaultBottomValue - DefaultStatusBar
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub chkPlayPauseControls_CheckedChanged(sender As Object, e As EventArgs) Handles chkPlayPauseControls.CheckedChanged
        If chkPlayPauseControls.Checked = True Then
            DefaultBottomValue = DefaultBottomValue + DefaultPlayPause
        Else
            DefaultBottomValue = DefaultBottomValue - DefaultPlayPause
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub CheckPersonalValuesAgainstStandard()
        If chkOverrideDefault.Checked = False Then
            txtDefaultCropTop.Text = DefaultTopValue

            If DefaultBottomValue < 0 Then
                txtDefaultCropBottom.Text = 0
            Else
                txtDefaultCropBottom.Text = DefaultBottomValue
            End If
        End If

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
#End Region
End Class
