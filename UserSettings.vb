Public Class UserSettings
    ReadOnly _obsSourceListLeftGame As New DataSet
    Dim _obsSourceListRightGame As New DataSet
    Dim _obsSourceListLeftTimer As New DataSet
    Dim _obsSourceListRightTimer As New DataSet
    Dim _obsSourceListLeftRunner As New DataSet
    Dim _obsSourceListRightRunner As New DataSet
    Dim _obsSourceListLeftTracker As New DataSet
    Dim _obsSourceListRightTracker As New DataSet
    Dim _obsCommentary As New DataSet

    Public Shared ShowVlcOption As Boolean

    Function VerifySettings() As Boolean
        If String.IsNullOrWhiteSpace(txtTwitchChannel.Text) Then
            MsgBox("You must enter a twitch channel.", MsgBoxStyle.OkOnly, OBSWebSocketCropper.ProgramName)
            Return False
        End If

        Dim match As Boolean = False

        If String.IsNullOrWhiteSpace(cbLeftTimerWindow.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbRightTimerWindow.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbLeftGameWindow.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbRightGameWindow.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbLeftRunnerOBS.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbRightRunnerOBS.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbLeftTrackerOBS.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbRightTrackerOBS.Text) And match = False Then
            match = True
        End If

        If String.IsNullOrWhiteSpace(cbCommentaryOBS.Text) And match = False Then
            match = True
        End If
        If match = True Then
            If MsgBox("Some of the dropdowns are blank.  Are you sure you wish to continue saving?  This may lead to unexpected issues.", MsgBoxStyle.YesNo, OBSWebSocketCropper.ProgramName) = MsgBoxResult.Yes Then

            Else
                Return False
            End If
        Else

        End If

        Return True
    End Function
    Private Sub SaveSettings(continueToVlc As Boolean)
        Dim settingsVerified As Boolean = VerifySettings()

        If settingsVerified = True Then

            My.Settings.LeftTimerName = cbLeftTimerWindow.Text
            My.Settings.LeftGameName = cbLeftGameWindow.Text
            My.Settings.RightTimerName = cbRightTimerWindow.Text
            My.Settings.RightGameName = cbRightGameWindow.Text
            My.Settings.ConnectionString1 = txtConnectionString1.Text
            My.Settings.Password1 = txtPassword1.Text
            My.Settings.ConnectionPort1 = txtConnectionPort.Text
            My.Settings.LeftRunnerOBS = cbLeftRunnerOBS.Text
            My.Settings.RightRunnerOBS = cbRightRunnerOBS.Text
            My.Settings.LeftTrackerOBS = cbLeftTrackerOBS.Text
            My.Settings.RightTrackerOBS = cbRightTrackerOBS.Text
            My.Settings.CommentaryOBS = cbCommentaryOBS.Text
            My.Settings.TwitchChannel = txtTwitchChannel.Text
            My.Settings.DefaultConnection = roDefault.Checked
            My.Settings.HasFinishedWelcome = True


            My.Settings.Save()

            If continueToVlc = True Then
                ObsWebSocketCropper.ObsSettingsResult = "VLC"
            Else
                ObsWebSocketCropper.ObsSettingsResult = "Closed"
            End If

            Close()
        End If
    End Sub
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        SaveSettings(False)
    End Sub
    Private Sub CreateNewSourceTable()
        If _obsSourceListLeftGame.Tables.Count = 0 Then
            _obsSourceListLeftGame.Tables.Add("Sources")
            _obsSourceListLeftGame.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListLeftGame.Tables("Sources").Clear()
        End If

        If _obsSourceListRightGame.Tables.Count = 0 Then
            _obsSourceListRightGame.Tables.Add("Sources")
            _obsSourceListRightGame.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListRightGame.Tables("Sources").Clear()
        End If

        If _obsSourceListLeftTimer.Tables.Count = 0 Then
            _obsSourceListLeftTimer.Tables.Add("Sources")
            _obsSourceListLeftTimer.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListLeftTimer.Tables("Sources").Clear()
        End If

        If _obsSourceListRightTimer.Tables.Count = 0 Then
            _obsSourceListRightTimer.Tables.Add("Sources")
            _obsSourceListRightTimer.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListRightTimer.Tables("Sources").Clear()
        End If

        If _obsSourceListLeftRunner.Tables.Count = 0 Then
            _obsSourceListLeftRunner.Tables.Add("Sources")
            _obsSourceListLeftRunner.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListLeftRunner.Tables("Sources").Clear()
        End If

        If _obsSourceListRightRunner.Tables.Count = 0 Then
            _obsSourceListRightRunner.Tables.Add("Sources")
            _obsSourceListRightRunner.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListRightRunner.Tables("Sources").Clear()
        End If

        If _obsSourceListLeftTracker.Tables.Count = 0 Then
            _obsSourceListLeftTracker.Tables.Add("Sources")
            _obsSourceListLeftTracker.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListLeftTracker.Tables("Sources").Clear()
        End If

        If _obsSourceListRightTracker.Tables.Count = 0 Then
            _obsSourceListRightTracker.Tables.Add("Sources")
            _obsSourceListRightTracker.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsSourceListRightTracker.Tables("Sources").Clear()
        End If
    End Sub

    Private Sub SetUserSettings()
        If My.Settings.HasFinishedWelcome = False Then

        Else
            cbLeftTimerWindow.Text = My.Settings.LeftTimerName
            cbLeftGameWindow.Text = My.Settings.LeftGameName
            cbRightTimerWindow.Text = My.Settings.RightTimerName
            cbRightGameWindow.Text = My.Settings.RightGameName
            cbLeftRunnerOBS.Text = My.Settings.LeftRunnerOBS
            cbRightRunnerOBS.Text = My.Settings.RightRunnerOBS
            cbLeftTrackerOBS.Text = My.Settings.LeftTrackerOBS
            cbRightTrackerOBS.Text = My.Settings.RightTrackerOBS
            cbCommentaryOBS.Text = My.Settings.CommentaryOBS
        End If
    End Sub

    Private Sub btnRefreshScenes_Click(sender As Object, e As EventArgs) Handles btnRefreshScenes.Click
        RefreshScenes()
        SetUserSettings()
    End Sub
    Private Sub SaveConnectionForTest()
        My.Settings.ConnectionString1 = txtConnectionString1.Text
        My.Settings.Password1 = txtPassword1.Text
        My.Settings.ConnectionPort1 = txtConnectionPort.Text

        My.Settings.Save()
    End Sub
    Private Sub UserSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnectionString1.Text = My.Settings.ConnectionString1
        txtConnectionPort.Text = My.Settings.ConnectionPort1
        txtPassword1.Text = My.Settings.Password1

        panOBS.Visible = False

        txtTwitchChannel.Text = My.Settings.TwitchChannel

        gbConnection1.Visible = False

        roDefault.Checked = My.Settings.DefaultConnection

        btnSaveThenVLC.Visible = ShowVLCOption

        CreateNewSourceTable()

        CheckOBSPort()


    End Sub
    Private Sub RefreshScenes()
        Dim scenes = OBSWebSocketCropper.Obs.ListScenes()

        _obsSourceListLeftGame.Clear()
        _obsSourceListLeftTimer.Clear()
        _obsSourceListRightGame.Clear()
        _obsSourceListRightTimer.Clear()
        _obsSourceListLeftRunner.Clear()
        _obsSourceListRightRunner.Clear()
        _obsSourceListLeftTracker.Clear()
        _obsSourceListRightTracker.Clear()
        _obsCommentary.Clear()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim dr As DataRow

            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                dr = _obsSourceListLeftGame.Tables("Sources").NewRow
                dr.Item("SourceName") = scenes(x).Items(y).SourceName
                _obsSourceListLeftGame.Tables("Sources").Rows.Add(dr)
            Next

        Next
        _obsSourceListRightGame = _obsSourceListLeftGame.Copy
        _obsSourceListRightTimer = _obsSourceListLeftGame.Copy
        _obsSourceListLeftTimer = _obsSourceListLeftGame.Copy
        _obsSourceListLeftRunner = _obsSourceListLeftGame.Copy
        _obsSourceListRightRunner = _obsSourceListLeftGame.Copy
        _obsSourceListLeftTracker = _obsSourceListLeftGame.Copy
        _obsSourceListRightTracker = _obsSourceListLeftGame.Copy
        _obsCommentary = _obsSourceListLeftGame.Copy

        cbRightGameWindow.DataSource = _obsSourceListRightGame.Tables("Sources")
        cbRightGameWindow.DisplayMember = "SourceName"
        cbRightGameWindow.ValueMember = "SourceName"

        cbRightTimerWindow.DataSource = _obsSourceListRightTimer.Tables("Sources")
        cbRightTimerWindow.DisplayMember = "SourceName"
        cbRightTimerWindow.ValueMember = "SourceName"

        cbLeftGameWindow.DataSource = _obsSourceListLeftGame.Tables("Sources")
        cbLeftGameWindow.DisplayMember = "SourceName"
        cbLeftGameWindow.ValueMember = "SourceName"

        cbLeftTimerWindow.DataSource = _obsSourceListLeftTimer.Tables("Sources")
        cbLeftTimerWindow.DisplayMember = "SourceName"
        cbLeftTimerWindow.ValueMember = "SourceName"

        cbLeftRunnerOBS.DataSource = _obsSourceListLeftRunner.Tables("Sources")
        cbLeftRunnerOBS.DisplayMember = "SourceName"
        cbLeftRunnerOBS.ValueMember = "SourceName"

        cbRightRunnerOBS.DataSource = _obsSourceListRightRunner.Tables("Sources")
        cbRightRunnerOBS.DisplayMember = "SourceName"
        cbRightRunnerOBS.ValueMember = "SourceName"

        cbLeftTrackerOBS.DataSource = _obsSourceListLeftTracker.Tables("Sources")
        cbLeftTrackerOBS.DisplayMember = "SourceName"
        cbLeftTrackerOBS.ValueMember = "SourceName"

        cbRightTrackerOBS.DataSource = _obsSourceListRightTracker.Tables("Sources")
        cbRightTrackerOBS.DisplayMember = "SourceName"
        cbRightTrackerOBS.ValueMember = "SourceName"

        cbCommentaryOBS.DataSource = _obsCommentary.Tables("Sources")
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
    Private Sub CheckObsPort()

        Dim portOpen As Boolean = OBSWebSocketCropper.Obs.IsPortOpen(OBSWebSocketCropper.ConnectionString)

        If PortOpen = False Then
            MsgBox("The OBS connection is not open.  Please connect to OBS before doing anything else!", MsgBoxStyle.OkOnly, OBSWebSocketCropper.ProgramName)
        Else
            If OBSWebSocketCropper.OBSConnectionStatus = "Connected" Then
                panOBS.Visible = True
                RefreshScenes()
                SetUserSettings()

                btnSaveSettings.Enabled = True
                btnSaveThenVLC.Enabled = True

                btnSaveThenVLC.Visible = ShowVLCOption
            Else
                btnSaveSettings.Enabled = False
                btnSaveThenVLC.Enabled = False
            End If
        End If
    End Sub
    Private Sub btnConnectOBS1_Click(sender As Object, e As EventArgs) Handles btnConnectOBS1.Click
        SaveConnectionForTest()

        OBSWebSocketCropper.ConnectToOBS()

        lblOBS1ConnectedStatus.Text = OBSWebSocketCropper.OBSConnectionStatus

        If OBSWebSocketCropper.OBSConnectionStatus = "Connected" Then
            panOBS.Visible = True
            btnSaveSettings.Enabled = True
            btnSaveThenVLC.Enabled = True
            RefreshScenes()
            SetUserSettings()
        End If
    End Sub
    Private Sub btnResetSettings_Click(sender As Object, e As EventArgs) Handles btnResetSettings.Click
        If MsgBox("Are you sure you wish to reset your settings back to default?", MsgBoxStyle.YesNo, OBSWebSocketCropper.ProgramName) = MsgBoxResult.Yes Then
            My.Settings.Reset()
            My.Settings.Save()
            My.Settings.Reload()

            SetBlankDropdowns()
            SetUserSettings()
        End If

    End Sub

    Private Sub roCustom_CheckedChanged(sender As Object, e As EventArgs) Handles roCustom.CheckedChanged
        If roCustom.Checked = True Then
            gbConnection1.Visible = True
            roDefault.Checked = False
        Else
            gbConnection1.Visible = False
            roDefault.Checked = True
        End If
    End Sub

    Private Sub roDefault_CheckedChanged(sender As Object, e As EventArgs) Handles roDefault.CheckedChanged
        If roDefault.Checked = True Then
            roCustom.Checked = False
        Else
            roCustom.Checked = True
        End If
    End Sub
    Private Sub txtConnectionPort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConnectionPort.KeyPress
        e.Handled = OBSWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub btnSaveThenVLC_Click(sender As Object, e As EventArgs) Handles btnSaveThenVLC.Click
        SaveSettings(True)
    End Sub
End Class