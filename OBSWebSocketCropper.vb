Imports System
Imports System.Windows.Forms
Imports OBSWebsocketDotNet
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class OBSWebSocketCropper
    'Dim _obs As New OBSWebsocket
    'Dim _obs2 As New OBSWebsocket

    Dim _obs As New OBSWebSocketPlus
    Dim _obs2 As New OBSWebSocketPlus
    'Dim ConnectionString As String = "ws://127.0.0.1:4444"
    'Dim ConnectionString2 As String = "ws://127.0.0.1:4443"

    Dim RSourceHeight As Integer
    Dim RSourceWidth As Integer

    Dim LSourceHeight As Integer
    Dim LSourceWidth As Integer

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

    Dim UserCropList As New DataSet
    Dim UserSettings As New DataSet

    Dim LeftRunnerGameSceneInfo As SceneItemProperties
    Dim RightRunnerGameSceneInfo As SceneItemProperties
    Dim LeftRunnerTimerSceneInfo As SceneItemProperties
    Dim RightRunnerTimerSceneInfo As SceneItemProperties

    Dim ProgramName As String = "OBS WebSocket Cropper"

    Dim ApprovedChars As String = "0123456789"
#Region " Create New Tables "
    Private Sub CreateUserSettingsTable()
        If UserSettings.Tables.Count = 0 Then
            UserSettings.Tables.Add("UserSettings")
            UserSettings.Tables("UserSettings").Columns.Add("DefaultCropTop", System.Type.GetType("System.Int32"))
            UserSettings.Tables("UserSettings").Columns.Add("DefaultCropBottom", System.Type.GetType("System.Int32"))
            UserSettings.Tables("UserSettings").Columns.Add("LeftTimerName")
            UserSettings.Tables("UserSettings").Columns.Add("LeftGameName")
            UserSettings.Tables("UserSettings").Columns.Add("RightTimerName")
            UserSettings.Tables("UserSettings").Columns.Add("RightGameName")
            UserSettings.Tables("UserSettings").Columns.Add("ConnectionString1")
            UserSettings.Tables("UserSettings").Columns.Add("ConnectionString2")
            UserSettings.Tables("UserSettings").Columns.Add("Password1")
            UserSettings.Tables("UserSettings").Columns.Add("Password2")
            UserSettings.Tables("UserSettings").Columns.Add("LeftRunnerOBS")
            UserSettings.Tables("UserSettings").Columns.Add("RightRunnerOBS")
            UserSettings.Tables("UserSettings").Columns.Add("LeftTrackerOBS")
            UserSettings.Tables("UserSettings").Columns.Add("RightTrackerOBS")
            UserSettings.Tables("UserSettings").Columns.Add("CommentaryOBS")
        Else
            UserCropList.Tables("UserSettings").Clear()
        End If

        If File.Exists(Application.StartupPath & "\UserSettings.xml") = True Then
            UserSettings.ReadXml(Application.StartupPath & "\UserSettings.xml", XmlReadMode.ReadSchema)
        End If
    End Sub
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
    Private Sub CreateUserCropTable()
        If UserCropList.Tables.Count = 0 Then
            UserCropList.Tables.Add("CropList")
            UserCropList.Tables("CropList").Columns.Add("RacerName")
            UserCropList.Tables("CropList").Columns.Add("StreamerName")
            UserCropList.Tables("CropList").Columns.Add("isRightWindow", System.Type.GetType("System.Boolean"))
            UserCropList.Tables("CropList").Columns.Add("isGameWindow", System.Type.GetType("System.Boolean"))
            UserCropList.Tables("CropList").Columns.Add("CropTop", System.Type.GetType("System.Decimal"))
            UserCropList.Tables("CropList").Columns.Add("CropBottom", System.Type.GetType("System.Decimal"))
            UserCropList.Tables("CropList").Columns.Add("CropRight", System.Type.GetType("System.Decimal"))
            UserCropList.Tables("CropList").Columns.Add("CropLeft", System.Type.GetType("System.Decimal"))
            UserCropList.Tables("CropList").Columns.Add("MasterHeight", System.Type.GetType("System.Int32"))
            UserCropList.Tables("CropList").Columns.Add("MasterWidth", System.Type.GetType("System.Int32"))
        Else
            UserCropList.Tables("CropList").Clear()
        End If

        If File.Exists(Application.StartupPath & "\CropList.xml") = True Then
            UserCropList.ReadXml(Application.StartupPath & "\CropList.xml", XmlReadMode.ReadSchema)

            RefreshRunnerNames()
        End If
    End Sub

#End Region
#Region " Button Clicks "
    Private Sub btnSetRightCrop_Click(sender As Object, e As EventArgs) Handles btnSetRightCrop.Click
        GetCurrentSceneInfo(True)
        If chkNewNewMath.Checked = True Then
            SetNewNewMath(True)
        Else
            If chkOldMath.Checked = False Then
                SetCropNewMath(True)
            Else
                SetCrop(True)
            End If
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
    End Sub
    Private Sub btnSetMaster_Click(sender As Object, e As EventArgs) Handles btnSetMaster.Click
        SetMasterSourceDimensions()
    End Sub
    Private Sub btnSetLeftCrop_Click(sender As Object, e As EventArgs) Handles btnSetLeftCrop.Click
        GetCurrentSceneInfo(False)

        If chkNewNewMath.Checked = True Then
            SetNewNewMath(False)
        Else
            If chkOldMath.Checked = False Then
                SetCropNewMath(False)
            Else
                SetCrop(False)
            End If
        End If

    End Sub
    Private Sub btnSaveRunnerCrop_Click(sender As Object, e As EventArgs) Handles btnSaveRunnerCrop.Click
        Dim dr As DataRow

        SetMasterSourceDimensions()

        GetCurrentCropSettings(True)
        GetCurrentCropSettings(False)

        Dim DefaultTopCrop, DefaultBottomCrop As Integer

        If txtDefaultCropTop.Text.Trim.Length > 0 Then
            DefaultTopCrop = 0
        Else
            DefaultTopCrop = 0
        End If

        If txtDefaultCropBottom.Text.Trim.Length > 0 Then
            DefaultBottomCrop = 0
        Else
            DefaultBottomCrop = 0
        End If

        Dim x As Integer

        Dim MatchedRow As Boolean = False

        For x = 0 To UserCropList.Tables("CropList").Rows.Count - 1
            If UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower = cbRightRunnerName.Text.ToLower Then
                If UserCropList.Tables("CropList").Rows(x)("isRightWindow") = True Then
                    If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = True Then
                        UserCropList.Tables("CropList").Rows(x)("CropTop") = IIf((txtCropRightGame_Top.Text - DefaultTopCrop) > 0, (txtCropRightGame_Top.Text - DefaultTopCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropBottom") = IIf((txtCropRightGame_Bottom.Text - DefaultBottomCrop) > 0, (txtCropRightGame_Bottom.Text - DefaultBottomCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropRight") = txtCropRightGame_Right.Text
                        UserCropList.Tables("CropList").Rows(x)("CropLeft") = txtCropRightGame_Left.Text
                        UserCropList.Tables("CropList").Rows(x)("MasterHeight") = RSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                        UserCropList.Tables("CropList").Rows(x)("MasterWidth") = RSourceWidth
                        MatchedRow = True
                        Exit For
                    End If
                End If
            End If
        Next

        If MatchedRow = False Then
            If txtCropRightGame_Left.Text.Trim.Length > 0 Then
                dr = UserCropList.Tables("CropList").NewRow
                dr.Item("RacerName") = cbRightRunnerName.Text
                dr.Item("StreamerName") = "Iceman_F1"
                dr.Item("isRightWindow") = True
                dr.Item("isGameWindow") = True
                dr.Item("CropTop") = IIf((txtCropRightGame_Top.Text - DefaultTopCrop) > 0, (txtCropRightGame_Top.Text - DefaultTopCrop), 0)
                dr.Item("CropBottom") = IIf((txtCropRightGame_Bottom.Text - DefaultBottomCrop) > 0, (txtCropRightGame_Bottom.Text - DefaultBottomCrop), 0)
                dr.Item("CropRight") = txtCropRightGame_Right.Text
                dr.Item("CropLeft") = txtCropRightGame_Left.Text
                dr.Item("MasterHeight") = RSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                dr.Item("MasterWidth") = RSourceWidth
                UserCropList.Tables("CropList").Rows.Add(dr)
            End If
        End If

        MatchedRow = False
        For x = 0 To UserCropList.Tables("CropList").Rows.Count - 1
            If UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower = cbRightRunnerName.Text.ToLower Then
                If UserCropList.Tables("CropList").Rows(x)("isRightWindow") = True Then
                    If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = False Then
                        UserCropList.Tables("CropList").Rows(x)("CropTop") = IIf((txtCropRightTimer_Top.Text - DefaultTopCrop) > 0, (txtCropRightTimer_Top.Text - DefaultTopCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropBottom") = IIf((txtCropRightTimer_Bottom.Text - DefaultBottomCrop) > 0, (txtCropRightTimer_Bottom.Text - DefaultBottomCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropRight") = txtCropRightTimer_Right.Text
                        UserCropList.Tables("CropList").Rows(x)("CropLeft") = txtCropRightTimer_Left.Text
                        UserCropList.Tables("CropList").Rows(x)("MasterHeight") = RSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                        UserCropList.Tables("CropList").Rows(x)("MasterWidth") = RSourceWidth
                        MatchedRow = True
                        Exit For
                    End If
                End If
            End If
        Next

        If MatchedRow = False Then
            If txtCropRightTimer_Left.Text.Trim.Length > 0 Then
                dr = UserCropList.Tables("CropList").NewRow
                dr.Item("RacerName") = cbRightRunnerName.Text
                dr.Item("StreamerName") = "Iceman_F1"
                dr.Item("isRightWindow") = True
                dr.Item("isGameWindow") = False
                dr.Item("CropTop") = IIf((txtCropRightTimer_Top.Text - DefaultTopCrop) > 0, (txtCropRightTimer_Top.Text - DefaultTopCrop), 0)
                dr.Item("CropBottom") = IIf((txtCropRightTimer_Bottom.Text - DefaultBottomCrop) > 0, (txtCropRightTimer_Bottom.Text - DefaultBottomCrop), 0)
                dr.Item("CropRight") = txtCropRightTimer_Right.Text
                dr.Item("CropLeft") = txtCropRightTimer_Left.Text
                dr.Item("MasterHeight") = RSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                dr.Item("MasterWidth") = RSourceWidth
                UserCropList.Tables("CropList").Rows.Add(dr)
            End If
        End If

        MatchedRow = False
        For x = 0 To UserCropList.Tables("CropList").Rows.Count - 1
            If UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower = cbLeftRunnerName.Text.ToLower Then
                If UserCropList.Tables("CropList").Rows(x)("isRightWindow") = False Then
                    If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = True Then
                        UserCropList.Tables("CropList").Rows(x)("CropTop") = IIf((txtCropLeftGame_Top.Text - DefaultTopCrop) > 0, (txtCropLeftGame_Top.Text - DefaultTopCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropBottom") = IIf((txtCropLeftGame_Bottom.Text - DefaultBottomCrop) > 0, (txtCropLeftGame_Bottom.Text - DefaultBottomCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropRight") = txtCropLeftGame_Right.Text
                        UserCropList.Tables("CropList").Rows(x)("CropLeft") = txtCropLeftGame_Left.Text
                        UserCropList.Tables("CropList").Rows(x)("MasterHeight") = LSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                        UserCropList.Tables("CropList").Rows(x)("MasterWidth") = LSourceWidth
                        MatchedRow = True
                        Exit For
                    End If
                End If
            End If
        Next

        If MatchedRow = False Then
            If txtCropLeftGame_Left.Text.Trim.Length > 0 Then
                dr = UserCropList.Tables("CropList").NewRow
                dr.Item("RacerName") = cbLeftRunnerName.Text
                dr.Item("StreamerName") = "Iceman_F1"
                dr.Item("isRightWindow") = False
                dr.Item("isGameWindow") = True
                dr.Item("CropTop") = IIf((txtCropLeftGame_Top.Text - DefaultTopCrop) > 0, (txtCropLeftGame_Top.Text - DefaultTopCrop), 0)
                dr.Item("CropBottom") = IIf((txtCropLeftGame_Bottom.Text - DefaultBottomCrop) > 0, (txtCropLeftGame_Bottom.Text - DefaultBottomCrop), 0)
                dr.Item("CropRight") = txtCropLeftGame_Right.Text
                dr.Item("CropLeft") = txtCropLeftGame_Left.Text
                dr.Item("MasterHeight") = LSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                dr.Item("MasterWidth") = LSourceWidth
                UserCropList.Tables("CropList").Rows.Add(dr)
            End If
        End If

        MatchedRow = False
        For x = 0 To UserCropList.Tables("CropList").Rows.Count - 1
            If UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower = cbLeftRunnerName.Text.ToLower Then
                If UserCropList.Tables("CropList").Rows(x)("isRightWindow") = False Then
                    If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = False Then
                        UserCropList.Tables("CropList").Rows(x)("CropTop") = IIf((txtCropLeftTimer_Top.Text - DefaultTopCrop) > 0, (txtCropLeftTimer_Top.Text - DefaultTopCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropBottom") = IIf((txtCropLeftTimer_Bottom.Text - DefaultBottomCrop) > 0, (txtCropLeftTimer_Bottom.Text - DefaultBottomCrop), 0)
                        UserCropList.Tables("CropList").Rows(x)("CropRight") = txtCropLeftTimer_Right.Text
                        UserCropList.Tables("CropList").Rows(x)("CropLeft") = txtCropLeftTimer_Left.Text
                        UserCropList.Tables("CropList").Rows(x)("MasterHeight") = LSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                        UserCropList.Tables("CropList").Rows(x)("MasterWidth") = LSourceWidth
                        MatchedRow = True
                        Exit For
                    End If
                End If
            End If
        Next

        If MatchedRow = False Then
            If txtCropLeftTimer_Left.Text.Trim.Length > 0 Then
                dr = UserCropList.Tables("CropList").NewRow
                dr.Item("RacerName") = cbLeftRunnerName.Text
                dr.Item("StreamerName") = "Iceman_F1"
                dr.Item("isRightWindow") = False
                dr.Item("isGameWindow") = False
                dr.Item("CropTop") = IIf((txtCropLeftTimer_Top.Text - DefaultTopCrop) > 0, (txtCropLeftTimer_Top.Text - DefaultTopCrop), 0)
                dr.Item("CropBottom") = IIf((txtCropLeftTimer_Bottom.Text - DefaultBottomCrop) > 0, (txtCropLeftTimer_Bottom.Text - DefaultBottomCrop), 0)
                dr.Item("CropRight") = txtCropLeftTimer_Right.Text
                dr.Item("CropLeft") = txtCropLeftTimer_Left.Text
                dr.Item("MasterHeight") = LSourceHeight - (DefaultTopCrop + DefaultBottomCrop)
                dr.Item("MasterWidth") = LSourceWidth
                UserCropList.Tables("CropList").Rows.Add(dr)
            End If
        End If


        UserCropList.WriteXml(Application.StartupPath & "\CropList.xml", XmlWriteMode.WriteSchema)

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

        If UserSettings.Tables(0).Rows.Count = 0 Then
            Dim dr As DataRow
            dr = UserSettings.Tables("UserSettings").NewRow


            dr.Item("DefaultCropBottom") = DefaultCropBottom
            dr.Item("DefaultCropTop") = DefaultCropTop
            dr.Item("LeftTimerName") = cbLeftTimerWindow.Text
            dr.Item("LeftGameName") = cbLeftGameWindow.Text
            dr.Item("RightTimerName") = cbRightTimerWindow.Text
            dr.Item("RightGameName") = cbRightGameWindow.Text
            dr.Item("ConnectionString1") = txtConnectionString1.Text
            dr.Item("ConnectionString2") = txtConnectionString2.Text
            dr.Item("Password1") = txtPassword1.Text
            dr.Item("Password2") = txtPassword2.Text
            dr.Item("LeftRunnerOBS") = cbLeftRunnerOBS.Text
            dr.Item("RightRunnerOBS") = cbRightRunnerOBS.Text
            dr.Item("LeftTrackerOBS") = cbLeftTrackerOBS.Text
            dr.Item("RightTrackerOBS") = cbRightTrackerOBS.Text
            dr.Item("CommentaryOBS") = cbCommentaryOBS.Text
            UserSettings.Tables("UserSettings").Rows.Add(dr)

        Else
            UserSettings.Tables("UserSettings").Rows(0)("DefaultCropBottom") = DefaultCropBottom
            UserSettings.Tables("UserSettings").Rows(0)("DefaultCropTop") = DefaultCropTop
            UserSettings.Tables("UserSettings").Rows(0)("LeftTimerName") = cbLeftTimerWindow.Text
            UserSettings.Tables("UserSettings").Rows(0)("LeftGameName") = cbLeftGameWindow.Text
            UserSettings.Tables("UserSettings").Rows(0)("RightTimerName") = cbRightTimerWindow.Text
            UserSettings.Tables("UserSettings").Rows(0)("RightGameName") = cbRightGameWindow.Text
            UserSettings.Tables("UserSettings").Rows(0)("ConnectionString1") = txtConnectionString1.Text
            UserSettings.Tables("UserSettings").Rows(0)("ConnectionString2") = txtConnectionString2.Text
            UserSettings.Tables("UserSettings").Rows(0)("Password1") = txtPassword1.Text
            UserSettings.Tables("UserSettings").Rows(0)("Password2") = txtPassword2.Text
            UserSettings.Tables("UserSettings").Rows(0)("LeftRunnerOBS") = cbLeftRunnerOBS.Text
            UserSettings.Tables("UserSettings").Rows(0)("RightRunnerOBS") = cbRightRunnerOBS.Text
            UserSettings.Tables("UserSettings").Rows(0)("LeftTrackerOBS") = cbLeftTrackerOBS.Text
            UserSettings.Tables("UserSettings").Rows(0)("RightTrackerOBS") = cbRightTrackerOBS.Text
            UserSettings.Tables("UserSettings").Rows(0)("CommentaryOBS") = cbCommentaryOBS.Text
        End If

        UserSettings.WriteXml(Application.StartupPath & "\UserSettings.xml", XmlWriteMode.WriteSchema)
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

#End Region
#Region " Crop Math / Crop Settings "
    Private Sub SetCropNewMath(ByVal isRightWindow As Boolean)
        Dim NCropTopTimer, NCropBottomTimer, NCropLeftTimer, NCropRightTimer,
            NCropTopGame, NCropBottomGame, NCropLeftGame, NCropRightGame As Integer

        GetCurrentCropSettings(isRightWindow)

        Dim DefaultTopCrop, DefaultBottomCrop As Integer

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
        Else
            NCropTopTimer = txtCropLeftTimer_Top.Text - DefaultTopCrop
            NCropBottomTimer = txtCropLeftTimer_Bottom.Text - DefaultBottomCrop
            NCropLeftTimer = txtCropLeftTimer_Left.Text
            NCropRightTimer = txtCropLeftTimer_Right.Text

            NCropTopGame = txtCropLeftGame_Top.Text - DefaultTopCrop
            NCropBottomGame = txtCropLeftGame_Bottom.Text - DefaultBottomCrop
            NCropLeftGame = txtCropLeftGame_Left.Text
            NCropRightGame = txtCropLeftGame_Right.Text
        End If

        Dim NHeight, NWidth, NMasterHeight, NMasterWidth As Integer

        If isRightWindow = True Then
            NHeight = RSourceHeight '- (DefaultTopCrop + DefaultBottomCrop)
            NWidth = RSourceWidth
            NMasterHeight = MasterHeightRight
            NMasterWidth = MasterWidthRight
        Else
            NHeight = LSourceHeight '- (DefaultTopCrop + DefaultBottomCrop)
            NWidth = LSourceWidth
            NMasterHeight = MasterHeightLeft
            NMasterWidth = MasterWidthLeft
        End If

        Dim AspectRatioHeight, AspectRatioWidth As Decimal
        Dim AbsAspectRatioHeight, AbsAspectRatioWidth As Decimal


        AspectRatioHeight = NHeight / NMasterHeight
        AbsAspectRatioHeight = Math.Max(NHeight, NMasterHeight) / Math.Min(NHeight, NMasterHeight)

        AspectRatioWidth = NWidth / NMasterWidth
        AbsAspectRatioWidth = Math.Max(NWidth, NMasterWidth) / Math.Min(NWidth, NMasterWidth)

        Dim SavedScaleChange As Decimal = 1

        If (AspectRatioHeight > AbsAspectRatioWidth) Then
            SavedScaleChange = AspectRatioHeight
        ElseIf (AspectRatioHeight < AbsAspectRatioWidth) Then
            SavedScaleChange = AbsAspectRatioWidth
        End If

        Dim scale As Decimal

        scale = SavedScaleChange

        Dim USHeight, USWidth As Decimal
        USHeight = NMasterHeight * SavedScaleChange
        USWidth = NMasterWidth * SavedScaleChange

        Dim BBHeight, BBWidth As Decimal

        'BBHeight = Math.Abs(USHeight - NHeight)
        'BBWidth = Math.Abs(USWidth - NWidth)

        BBWidth = Math.Abs(USHeight - NHeight)
        BBHeight = Math.Abs(USWidth - NWidth)

        Dim ACTGame, ACBGame, ACLGame, ACRGame,
            ACTTimer, ACBTimer, ACLTimer, ACRTimer,
            BBTop, BBBottom, BBLeft, BBRight As Integer

        ACTGame = NCropTopGame * scale
        ACBGame = NCropBottomGame * scale
        ACLGame = NCropLeftGame * scale
        ACRGame = NCropRightGame * scale

        ACTTimer = NCropTopTimer * scale
        ACBTimer = NCropBottomTimer * scale
        ACLTimer = NCropLeftTimer * scale
        ACRTimer = NCropRightTimer * scale

        BBTop = BBHeight / 2
        BBBottom = BBHeight / 2
        BBLeft = BBWidth / 2
        BBRight = BBWidth / 2

        Dim CropGame As New SceneItemCropInfo
        Dim CropTimer As New SceneItemCropInfo

        CropGame.Top = ACTGame + BBTop + DefaultTopCrop
        CropGame.Bottom = ACBGame + BBBottom + DefaultBottomCrop
        CropGame.Left = ACLGame + BBLeft
        CropGame.Right = ACRGame + BBRight

        CropTimer.Top = ACTTimer + BBTop + DefaultTopCrop
        CropTimer.Bottom = ACBTimer + BBBottom + DefaultBottomCrop
        CropTimer.Left = ACLTimer + BBLeft
        CropTimer.Right = ACRTimer + BBRight

        If isRightWindow = True Then
            _obs.SetSceneItemCrop(cbRightGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbRightTimerWindow.Text, CropTimer)
        Else
            _obs.SetSceneItemCrop(cbLeftGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbLeftTimerWindow.Text, CropTimer)
        End If
    End Sub
    Private Sub SetCrop(ByVal isRightWindow As Boolean)
        Dim CropGame As New SceneItemCropInfo
        Dim CropTimer As New SceneItemCropInfo

        GetCurrentCropSettings(isRightWindow)

        Dim MasterHeight, MasterWidth As Integer

        If isRightWindow = True Then
            MasterHeight = MasterHeightRight
            MasterWidth = MasterWidthRight
        Else
            MasterHeight = MasterHeightLeft
            MasterWidth = MasterWidthLeft
        End If

        Dim SourceWidth, SourceHeight As Integer
        If isRightWindow = True Then
            SourceWidth = RSourceWidth
        Else
            SourceWidth = LSourceWidth
        End If
        If isRightWindow = True Then
            SourceHeight = RSourceHeight
        Else
            SourceHeight = LSourceHeight
        End If


        Dim PercWidth, PercHeight, PercTotal As Decimal

        PercWidth = SourceWidth / MasterWidth
        PercHeight = SourceHeight / MasterHeight

        PercTotal = Math.Max(PercWidth, PercHeight)

        Dim tempHeight, tempWidth As Integer

        tempHeight = SourceHeight / PercTotal
        tempWidth = SourceWidth / PercTotal

        Dim NHeight As Integer
        NHeight = (MasterHeight / MasterWidth) * SourceWidth

        If NHeight < SourceHeight Then

        ElseIf NHeight = SourceHeight Then

        Else

        End If

        If SourceWidth <> MasterWidth Then
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


            Dim LPercentGame, RPercentGame, TPercentGame, BPercentGame,
                LPercentTimer, RPercentTimer, TPercentTimer, BPercentTimer As Decimal

            LPercentGame = CLeftGame / MasterWidth
            RPercentGame = CRightGame / MasterWidth
            TPercentGame = (CTopGame - 22) / MasterHeight
            BPercentGame = (CBottomGame - 109) / MasterHeight

            LPercentTimer = CLeftTimer / MasterWidth
            RPercentTimer = CRightTimer / MasterWidth
            TPercentTimer = CTopTimer / MasterHeight
            BPercentTimer = CBottomTimer / MasterHeight

            If (SourceHeight * TPercentGame) > 0 Then
                'If ((SourceHeight * TPercentGame) - 23) < CTopGame Then
                'CropGame.Top = CTopGame
                'Else
                CropGame.Top = (SourceHeight * TPercentGame) + 22
                'End If
            Else
                CropGame.Top = 0
            End If

            Dim AddPix As Integer

            If tempWidth > SourceWidth Then
                AddPix = (tempWidth - SourceWidth) / 2
            Else
                AddPix = (SourceWidth - tempWidth) / 2
            End If

            If (SourceHeight * TPercentTimer) > 0 Then
                CropTimer.Top = SourceHeight * TPercentTimer
            Else
                CropTimer.Top = 0
            End If

            If (SourceHeight * BPercentGame) > 0 Then
                'If ((SourceHeight * BPercentGame) - 110) < CBottomGame Then
                'CropGame.Bottom = CBottomGame
                'Else
                CropGame.Bottom = (SourceHeight * BPercentGame) + 109
                'End If

            Else
                CropGame.Bottom = 0
            End If

            If (SourceHeight * BPercentTimer) > 0 Then
                CropTimer.Bottom = SourceHeight * BPercentTimer
            Else
                CropTimer.Bottom = 0
            End If

            If (SourceWidth * LPercentGame) > 0 Then
                CropGame.Left = (SourceWidth * LPercentGame) + AddPix
            Else
                CropGame.Left = 0
            End If

            If (SourceWidth * LPercentTimer) > 0 Then
                CropTimer.Left = SourceWidth * LPercentTimer
            Else
                CropTimer.Left = 0
            End If

            If (SourceWidth * RPercentGame) > 0 Then
                CropGame.Right = (SourceWidth * RPercentGame) + AddPix
            Else
                CropGame.Right = 0 + AddPix
            End If

            If (SourceWidth * RPercentTimer) > 0 Then
                CropTimer.Right = SourceWidth * RPercentTimer
            Else
                CropTimer.Right = 0
            End If
        Else
            If isRightWindow = True Then
                If txtCropRightGame_Top.Text.Trim.Length > 0 Then
                    CropGame.Top = txtCropRightGame_Top.Text
                    CropGame.Bottom = txtCropRightGame_Bottom.Text
                    CropGame.Left = txtCropRightGame_Left.Text
                    CropGame.Right = txtCropRightGame_Right.Text
                Else
                    CropGame.Top = 0
                    CropGame.Bottom = 0
                    CropGame.Left = 0
                    CropGame.Right = 0
                End If

                If txtCropRightTimer_Top.Text.Trim.Length > 0 Then
                    CropTimer.Top = txtCropRightTimer_Top.Text
                    CropTimer.Bottom = txtCropRightTimer_Bottom.Text
                    CropTimer.Left = txtCropRightTimer_Left.Text
                    CropTimer.Right = txtCropRightTimer_Right.Text
                Else
                    CropTimer.Top = 0
                    CropTimer.Bottom = 0
                    CropTimer.Left = 0
                    CropTimer.Right = 0
                End If
            Else
                If txtCropLeftGame_Top.Text.Trim.Length > 0 Then
                    CropGame.Top = txtCropLeftGame_Top.Text
                    CropGame.Bottom = txtCropLeftGame_Bottom.Text
                    CropGame.Left = txtCropLeftGame_Left.Text
                    CropGame.Right = txtCropLeftGame_Right.Text
                Else
                    CropGame.Top = 0
                    CropGame.Bottom = 0
                    CropGame.Left = 0
                    CropGame.Right = 0
                End If

                If txtCropLeftTimer_Top.Text.Trim.Length > 0 Then
                    CropTimer.Top = txtCropLeftTimer_Top.Text
                    CropTimer.Bottom = txtCropLeftTimer_Bottom.Text
                    CropTimer.Left = txtCropLeftTimer_Left.Text
                    CropTimer.Right = txtCropLeftTimer_Right.Text
                Else
                    CropTimer.Top = 0
                    CropTimer.Bottom = 0
                    CropTimer.Left = 0
                    CropTimer.Right = 0
                End If
            End If

        End If

        If isRightWindow = True Then
            _obs.SetSceneItemCrop(cbRightGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbRightTimerWindow.Text, CropTimer)
        Else
            _obs.SetSceneItemCrop(cbLeftGameWindow.Text, CropGame)
            _obs.SetSceneItemCrop(cbLeftTimerWindow.Text, CropTimer)
        End If

        '_obs2.SetSceneItemCrop("RightRunnerGame", crop)
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
            LeftRunnerGameSceneInfo = _obs.GetSceneItemProperties("", cbLeftGameWindow.Text)
            LeftRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", cbLeftTimerWindow.Text)
        Else
            RightRunnerGameSceneInfo = _obs.GetSceneItemProperties("", cbRightGameWindow.Text)
            RightRunnerTimerSceneInfo = _obs.GetSceneItemProperties("", cbRightTimerWindow.Text)
        End If
    End Sub
    Private Sub SetNewNewMath(ByVal isRightWindow As Boolean)
        Dim CTop, CBottom, CLeft, CRight As Integer
        Dim ItemName As String

        If isRightWindow = True Then
            ItemName = cbRightGameWindow.Text

            If txtCropRightGame_Left.Text.Trim.Length > 0 Then
                CTop = txtCropRightGame_Top.Text
                CBottom = txtCropRightGame_Bottom.Text
                CLeft = txtCropRightGame_Left.Text
                CRight = txtCropRightGame_Right.Text
            End If
        Else
            ItemName = cbLeftGameWindow.Text

            If txtCropLeftGame_Left.Text.Trim.Length > 0 Then
                CTop = txtCropLeftGame_Top.Text
                CBottom = txtCropLeftGame_Bottom.Text
                CLeft = txtCropLeftGame_Left.Text
                CRight = txtCropLeftGame_Right.Text
            End If
        End If

        'OBSWebSocketPlus.SetSceneItemProperties(ItemName, CTop, CBottom, CLeft, CRight, True)
        _obs.SetSceneItemProperties(ItemName, CTop, CBottom, CLeft, CRight)
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
    End Sub
    Private Sub RefreshRunnerNames()
        Dim TempLeftRunner As String = cbLeftRunnerName.Text
        Dim TempRightRunner As String = cbRightRunnerName.Text

        Dim LeftRunnerName As New DataSet
        Dim RightRunnerName As New DataSet

        LeftRunnerName.Clear()
        RightRunnerName.Clear()

        LeftRunnerName.Tables.Add("CropList")
        LeftRunnerName.Tables("CropList").Columns.Add("RacerName")

        RightRunnerName.Tables.Add("CropList")
        RightRunnerName.Tables("CropList").Columns.Add("RacerName")

        Dim x As Integer
        For x = 0 To UserCropList.Tables(0).Rows.Count - 1
            Dim dr, dr2 As DataRow

            Dim MatchedName As Boolean = False


            Dim y As Integer
            For y = 0 To LeftRunnerName.Tables(0).Rows.Count - 1
                If UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower = LeftRunnerName.Tables("CropList").Rows(y)("RacerName").ToString.ToLower Then
                    MatchedName = True
                    Exit For
                End If
            Next

            If MatchedName = False Then
                dr = LeftRunnerName.Tables("CropList").NewRow
                dr.Item("RacerName") = UserCropList.Tables("CropList").Rows(x)("RacerName")
                LeftRunnerName.Tables("CropList").Rows.Add(dr)

                dr2 = RightRunnerName.Tables("CropList").NewRow
                dr2.Item("RacerName") = UserCropList.Tables("CropList").Rows(x)("RacerName")
                RightRunnerName.Tables("CropList").Rows.Add(dr2)
            End If
        Next

        cbLeftRunnerName.DataSource = LeftRunnerName.Tables("CropList")
        cbLeftRunnerName.DisplayMember = "RacerName"
        cbLeftRunnerName.ValueMember = "RacerName"

        cbRightRunnerName.DataSource = RightRunnerName.Tables("CropList")
        cbRightRunnerName.DisplayMember = "RacerName"
        cbRightRunnerName.ValueMember = "RacerName"

        cbLeftRunnerName.Text = TempLeftRunner
        cbRightRunnerName.Text = TempRightRunner
    End Sub
    Private Sub RefreshCropFromData(ByVal isRightWindow As Boolean)
        If UserCropList.Tables.Count > 0 Then
            If UserCropList.Tables("CropList").Rows.Count > 0 Then
                Dim x As Integer
                For x = 0 To UserCropList.Tables("CropList").Rows.Count - 1
                    If isRightWindow = True Then
                        If cbRightRunnerName.Text.ToLower = UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower Then

                            If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = False Then
                                txtCropRightTimer_Top.Text = UserCropList.Tables("CropList").Rows(x)("CropTop")
                                txtCropRightTimer_Bottom.Text = UserCropList.Tables("CropList").Rows(x)("CropBottom")
                                txtCropRightTimer_Left.Text = UserCropList.Tables("CropList").Rows(x)("CropLeft")
                                txtCropRightTimer_Right.Text = UserCropList.Tables("CropList").Rows(x)("CropRight")
                            End If

                            If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = True Then
                                txtCropRightGame_Top.Text = UserCropList.Tables("CropList").Rows(x)("CropTop")
                                txtCropRightGame_Bottom.Text = UserCropList.Tables("CropList").Rows(x)("CropBottom")
                                txtCropRightGame_Left.Text = UserCropList.Tables("CropList").Rows(x)("CropLeft")
                                txtCropRightGame_Right.Text = UserCropList.Tables("CropList").Rows(x)("CropRight")
                            End If


                            MasterWidthRight = UserCropList.Tables("CropList").Rows(x)("MasterWidth")
                            MasterHeightRight = UserCropList.Tables("CropList").Rows(x)("MasterHeight")
                        End If
                    Else
                        If cbLeftRunnerName.Text.ToLower = UserCropList.Tables("CropList").Rows(x)("RacerName").ToString.ToLower Then

                            If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = False Then
                                txtCropLeftTimer_Top.Text = UserCropList.Tables("CropList").Rows(x)("CropTop")
                                txtCropLeftTimer_Bottom.Text = UserCropList.Tables("CropList").Rows(x)("CropBottom")
                                txtCropLeftTimer_Left.Text = UserCropList.Tables("CropList").Rows(x)("CropLeft")
                                txtCropLeftTimer_Right.Text = UserCropList.Tables("CropList").Rows(x)("CropRight")
                            End If


                            If UserCropList.Tables("CropList").Rows(x)("isGameWindow") = True Then
                                txtCropLeftGame_Top.Text = UserCropList.Tables("CropList").Rows(x)("CropTop")
                                txtCropLeftGame_Bottom.Text = UserCropList.Tables("CropList").Rows(x)("CropBottom")
                                txtCropLeftGame_Left.Text = UserCropList.Tables("CropList").Rows(x)("CropLeft")
                                txtCropLeftGame_Right.Text = UserCropList.Tables("CropList").Rows(x)("CropRight")
                            End If


                            MasterWidthLeft = UserCropList.Tables("CropList").Rows(x)("MasterWidth")
                            MasterHeightLeft = UserCropList.Tables("CropList").Rows(x)("MasterHeight")
                        End If
                    End If

                Next
            End If
        End If

        SetHeightLabels()
    End Sub
    Private Sub SetUserSettings()
        If UserSettings.Tables("UserSettings").Rows.Count > 0 Then
            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("DefaultCropTop")) = False Then
                txtDefaultCropTop.Text = UserSettings.Tables("UserSettings").Rows(0)("DefaultCropTop")
            Else
                txtDefaultCropTop.Text = 0
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("DefaultCropBottom")) = False Then
                txtDefaultCropBottom.Text = UserSettings.Tables("UserSettings").Rows(0)("DefaultCropBottom")
            Else
                txtDefaultCropBottom.Text = 0
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("LeftTimerName")) = False Then
                cbLeftTimerWindow.Text = UserSettings.Tables("UserSettings").Rows(0)("LeftTimerName")
            Else
                cbLeftTimerWindow.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("LeftGameName")) = False Then
                cbLeftGameWindow.Text = UserSettings.Tables("UserSettings").Rows(0)("LeftGameName")
            Else
                cbLeftGameWindow.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("RightTimerName")) = False Then
                cbRightTimerWindow.Text = UserSettings.Tables("UserSettings").Rows(0)("RightTimerName")
            Else
                cbRightTimerWindow.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("RightGameName")) = False Then
                cbRightGameWindow.Text = UserSettings.Tables("UserSettings").Rows(0)("RightGameName")
            Else
                cbRightGameWindow.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("LeftRunnerOBS")) = False Then
                cbLeftRunnerOBS.Text = UserSettings.Tables("UserSettings").Rows(0)("LeftRunnerOBS")
            Else
                cbLeftRunnerOBS.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("RightRunnerOBS")) = False Then
                cbRightRunnerOBS.Text = UserSettings.Tables("UserSettings").Rows(0)("RightRunnerOBS")
            Else
                cbRightRunnerOBS.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("LeftTrackerOBS")) = False Then
                cbLeftTrackerOBS.Text = UserSettings.Tables("UserSettings").Rows(0)("LeftTrackerOBS")
            Else
                cbLeftTrackerOBS.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("RightTrackerOBS")) = False Then
                cbRightTrackerOBS.Text = UserSettings.Tables("UserSettings").Rows(0)("RightTrackerOBS")
            Else
                cbRightTrackerOBS.Text = ""
            End If

            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("CommentaryOBS")) = False Then
                cbCommentaryOBS.Text = UserSettings.Tables("UserSettings").Rows(0)("CommentaryOBS")
            Else
                cbCommentaryOBS.Text = ""
            End If
        End If
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
#Region " Block crop text boxes "
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
    End Sub
    Private Sub OBSWebScocketCropper_Load(sender As Object, e As EventArgs) Handles Me.Load
        EnableButtons(False)
        ResetHeightWidthLabels()

        CreateUserCropTable()
        CreateUserSettingsTable()

        If UserSettings.Tables(0).Rows.Count > 0 Then
            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("ConnectionString1")) = False Then
                txtConnectionString1.Text = UserSettings.Tables("UserSettings").Rows(0)("ConnectionString1")
            Else
                txtConnectionString1.Text = "ws://127.0.0.1:4444"
            End If
            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("ConnectionString2")) = False Then
                txtConnectionString2.Text = UserSettings.Tables("UserSettings").Rows(0)("ConnectionString2")
            Else
                txtConnectionString2.Text = "ws://127.0.0.1:4443"
            End If
            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("Password1")) = False Then
                txtPassword1.Text = UserSettings.Tables("UserSettings").Rows(0)("Password1")
            Else
                txtPassword1.Text = ""
            End If
            If IsDBNull(UserSettings.Tables("UserSettings").Rows(0)("Password2")) = False Then
                txtPassword2.Text = UserSettings.Tables("UserSettings").Rows(0)("Password2")
            Else
                txtPassword2.Text = ""
            End If
        Else
            txtConnectionString1.Text = "ws://127.0.0.1:4444"
            txtConnectionString2.Text = "ws://127.0.0.1:4443"
            txtPassword1.Text = ""
            txtPassword2.Text = ""
        End If

    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("This program was created by Iceman_F1 with the help and ideas from Hancin and various other members of the ALTTPR community." & vbCrLf & vbCrLf &
            "The initial goal of this program was to make restream setup faster.  While it is still in the beginning phases, and is very much a work in progress, it is slowly evolving into the tool it is meant to be.",
             MsgBoxStyle.OkOnly, ProgramName)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
#End Region
End Class
