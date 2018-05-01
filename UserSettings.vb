Imports System.Configuration

Public Class UserSettings
    Dim OBSSourceListLeftGame As New DataSet
    Dim OBSSourceListRightGame As New DataSet
    Dim OBSSourceListLeftTimer As New DataSet
    Dim OBSSourceListRightTimer As New DataSet
    Dim OBSSourceListLeftRunner As New DataSet
    Dim OBSSourceListRightRunner As New DataSet
    Dim OBSSourceListLeftTracker As New DataSet
    Dim OBSSourceListRightTracker As New DataSet
    Dim OBSCommentary As New DataSet

    Public Shared ShowVLCOption As Boolean

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
    Private Sub SaveSettings(ByVal ContinueToVLC As Boolean)
        Dim SettingsVerified As Boolean = VerifySettings()

        If SettingsVerified = True Then

            My.Settings.LeftTimerName = cbLeftTimerWindow.Text
            My.Settings.LeftGameName = cbLeftGameWindow.Text
            My.Settings.RightTimerName = cbRightTimerWindow.Text
            My.Settings.RightGameName = cbRightGameWindow.Text
            My.Settings.ConnectionString1 = txtConnectionString1.Text
            My.Settings.Password1 = txtPassword1.Text
            My.Settings.LeftRunnerOBS = cbLeftRunnerOBS.Text
            My.Settings.RightRunnerOBS = cbRightRunnerOBS.Text
            My.Settings.LeftTrackerOBS = cbLeftTrackerOBS.Text
            My.Settings.RightTrackerOBS = cbRightTrackerOBS.Text
            My.Settings.CommentaryOBS = cbCommentaryOBS.Text
            My.Settings.TwitchChannel = txtTwitchChannel.Text
            My.Settings.DefaultConnection = roDefault.Checked
            My.Settings.HasFinishedWelcome = True
            My.Settings.ConnectionPort1 = txtConnectionPort.Text

            My.Settings.Save()

            If ContinueToVLC = True Then
                OBSWebSocketCropper.OBSSettingsResult = "VLC"
            Else
                OBSWebSocketCropper.OBSSettingsResult = "Closed"
            End If

            Me.Close()
        End If
    End Sub
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        SaveSettings(False)
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
        Dim scenes = OBSWebSocketCropper._obs.ListScenes()

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
    Private Sub CheckOBSPort()

        Dim PortOpen As Boolean = OBSWebSocketCropper._obs.IsPortOpen(OBSWebSocketCropper.ConnectionString)

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