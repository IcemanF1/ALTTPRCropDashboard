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
    Dim CorrectMessage As String = "Correct Source Type"
    Dim IncorrectMessage As String = "Incorrect Source Type"

    Dim CorrectColour As Color = Color.Green
    Dim InCorrectColour As Color = Color.Red

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

            Dim FullyValid As Boolean

            FullyValid = CheckFullyValid("window_capture", cbLeftTimerWindow.Text)
            If FullyValid = True Then
                My.Settings.LeftTimerName = cbLeftTimerWindow.Text
            End If

            FullyValid = CheckFullyValid("window_capture", cbLeftGameWindow.Text)
            If FullyValid = True Then
                My.Settings.LeftGameName = cbLeftGameWindow.Text
            End If

            FullyValid = CheckFullyValid("window_capture", cbRightTimerWindow.Text)
            If FullyValid = True Then
                My.Settings.RightTimerName = cbRightTimerWindow.Text
            End If

            FullyValid = CheckFullyValid("window_capture", cbRightGameWindow.Text)
            If FullyValid = True Then
                My.Settings.RightGameName = cbRightGameWindow.Text
            End If

            FullyValid = CheckFullyValid("text_gdiplus", cbLeftRunnerOBS.Text)
            If FullyValid = True Then
                My.Settings.LeftRunnerOBS = cbLeftRunnerOBS.Text
            End If

            FullyValid = CheckFullyValid("text_gdiplus", cbRightRunnerOBS.Text)
            If FullyValid = True Then
                My.Settings.RightRunnerOBS = cbRightRunnerOBS.Text
            End If

            FullyValid = CheckFullyValid("browser_source", cbLeftTrackerOBS.Text)
            If FullyValid = True Then
                My.Settings.LeftTrackerOBS = cbLeftTrackerOBS.Text
            End If

            FullyValid = CheckFullyValid("browser_source", cbRightTrackerOBS.Text)
            If FullyValid = True Then
                My.Settings.RightTrackerOBS = cbRightTrackerOBS.Text
            End If

            FullyValid = CheckFullyValid("text_gdiplus", cbCommentaryOBS.Text)
            If FullyValid = True Then
                My.Settings.CommentaryOBS = cbCommentaryOBS.Text
            End If

            My.Settings.ConnectionString1 = txtConnectionString1.Text
            My.Settings.Password1 = txtPassword1.Text
            My.Settings.ConnectionPort1 = txtConnectionPort.Text
            My.Settings.TwitchChannel = txtTwitchChannel.Text
            My.Settings.DefaultConnection = roDefault.Checked
            My.Settings.HasFinishedWelcome = True

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
            My.Settings.UpgradeRequired = False
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
    Function CheckForValidSourceTypes(ByVal ExpectedSourceType As String, ByVal SourceName As String) As Boolean
        Dim sSettings As Boolean

        'SourceName = cbLeftRunnerOBS.Text
        If SourceName <> "System.Data.DataRowView" Then
            sSettings = OBSWebSocketCropper._obs.ConfirmSourceType(ExpectedSourceType, SourceName)
        End If

        Return sSettings
    End Function

    Function CheckItemInList(ByVal ListValue As String) As Boolean
        Dim x As Integer
        Dim MatchedValue As Boolean
        For x = 0 To OBSSourceListLeftGame.Tables("Sources").Rows.Count - 1
            If ListValue = OBSSourceListLeftGame.Tables("Sources").Rows(x)("SourceName") Then
                MatchedValue = True
                Exit For
            End If
        Next

        Return MatchedValue

    End Function

    Private Sub cbLeftRunnerOBS_TextChanged(sender As Object, e As EventArgs) Handles cbLeftRunnerOBS.TextChanged
        If Not String.IsNullOrWhiteSpace(cbLeftRunnerOBS.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbLeftRunnerOBS.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("text_gdiplus", cbLeftRunnerOBS.Text)

                lblLeftRunnerStatus.Visible = True

                If sSettings = True Then
                    lblLeftRunnerStatus.Text = CorrectMessage
                    lblLeftRunnerStatus.ForeColor = CorrectColour
                Else
                    lblLeftRunnerStatus.Text = IncorrectMessage
                    lblLeftRunnerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblLeftRunnerStatus.Visible = False
            End If
        Else
            lblLeftRunnerStatus.Visible = False
        End If
    End Sub
    Private Sub cbRightRunnerOBS_TextChanged(sender As Object, e As EventArgs) Handles cbRightRunnerOBS.TextChanged
        If Not String.IsNullOrWhiteSpace(cbRightRunnerOBS.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbRightRunnerOBS.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("text_gdiplus", cbRightRunnerOBS.Text)

                lblRightRunnerStatus.Visible = True

                If sSettings = True Then
                    lblRightRunnerStatus.Text = CorrectMessage
                    lblRightRunnerStatus.ForeColor = CorrectColour
                Else
                    lblRightRunnerStatus.Text = IncorrectMessage
                    lblRightRunnerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblRightRunnerStatus.Visible = False
            End If
        Else
            lblRightRunnerStatus.Visible = False
        End If
    End Sub
    Private Sub cbLeftTimerWindow_TextChanged(sender As Object, e As EventArgs) Handles cbLeftTimerWindow.TextChanged
        If Not String.IsNullOrWhiteSpace(cbLeftTimerWindow.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbLeftTimerWindow.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("window_capture", cbLeftTimerWindow.Text)

                lblLeftTimerStatus.Visible = True

                If sSettings = True Then
                    lblLeftTimerStatus.Text = CorrectMessage
                    lblLeftTimerStatus.ForeColor = CorrectColour
                Else
                    lblLeftTimerStatus.Text = IncorrectMessage
                    lblLeftTimerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblLeftTimerStatus.Visible = False
            End If
        Else
            lblLeftTimerStatus.Visible = False
        End If
    End Sub
    Private Sub cbRightTimerWindow_TextChanged(sender As Object, e As EventArgs) Handles cbRightTimerWindow.TextChanged
        If Not String.IsNullOrWhiteSpace(cbRightTimerWindow.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbRightTimerWindow.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("window_capture", cbRightTimerWindow.Text)

                lblRightTimerStatus.Visible = True

                If sSettings = True Then
                    lblRightTimerStatus.Text = CorrectMessage
                    lblRightTimerStatus.ForeColor = CorrectColour
                Else
                    lblRightTimerStatus.Text = IncorrectMessage
                    lblRightTimerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblRightTimerStatus.Visible = False
            End If
        Else
            lblRightTimerStatus.Visible = False
        End If
    End Sub
    Private Sub cbLeftGameWindow_TextChanged(sender As Object, e As EventArgs) Handles cbLeftGameWindow.TextChanged
        If Not String.IsNullOrWhiteSpace(cbLeftGameWindow.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbLeftGameWindow.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("window_capture", cbLeftGameWindow.Text)

                lblLeftGameStatus.Visible = True

                If sSettings = True Then
                    lblLeftGameStatus.Text = CorrectMessage
                    lblLeftGameStatus.ForeColor = CorrectColour
                Else
                    lblLeftGameStatus.Text = IncorrectMessage
                    lblLeftGameStatus.ForeColor = InCorrectColour
                End If
            Else
                lblLeftGameStatus.Visible = False
            End If
        Else
            lblLeftGameStatus.Visible = False
        End If
    End Sub
    Private Sub cbRightGameWindow_TextChanged(sender As Object, e As EventArgs) Handles cbRightGameWindow.TextChanged
        If Not String.IsNullOrWhiteSpace(cbRightGameWindow.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbRightGameWindow.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("window_capture", cbRightGameWindow.Text)

                lblRightGameStatus.Visible = True

                If sSettings = True Then
                    lblRightGameStatus.Text = CorrectMessage
                    lblRightGameStatus.ForeColor = CorrectColour
                Else
                    lblRightGameStatus.Text = IncorrectMessage
                    lblRightGameStatus.ForeColor = InCorrectColour
                End If
            Else
                lblRightGameStatus.Visible = False
            End If
        Else
            lblRightGameStatus.Visible = False
        End If
    End Sub
    Private Sub cbLeftTrackerOBS_TextChanged(sender As Object, e As EventArgs) Handles cbLeftTrackerOBS.TextChanged
        If Not String.IsNullOrWhiteSpace(cbLeftTrackerOBS.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbLeftTrackerOBS.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("browser_source", cbLeftTrackerOBS.Text)

                lblLeftTrackerStatus.Visible = True

                If sSettings = True Then
                    lblLeftTrackerStatus.Text = CorrectMessage
                    lblLeftTrackerStatus.ForeColor = CorrectColour
                Else
                    lblLeftTrackerStatus.Text = IncorrectMessage
                    lblLeftTrackerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblLeftTrackerStatus.Visible = False
            End If
        Else
            lblLeftTrackerStatus.Visible = False
        End If
    End Sub
    Private Sub cbRightTrackerOBS_TextChanged(sender As Object, e As EventArgs) Handles cbRightTrackerOBS.TextChanged
        If Not String.IsNullOrWhiteSpace(cbRightTrackerOBS.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbRightTrackerOBS.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("browser_source", cbRightTrackerOBS.Text)

                lblRightTrackerStatus.Visible = True

                If sSettings = True Then
                    lblRightTrackerStatus.Text = CorrectMessage
                    lblRightTrackerStatus.ForeColor = CorrectColour
                Else
                    lblRightTrackerStatus.Text = IncorrectMessage
                    lblRightTrackerStatus.ForeColor = InCorrectColour
                End If
            Else
                lblRightTrackerStatus.Visible = False
            End If
        Else
            lblRightTrackerStatus.Visible = False
        End If
    End Sub
    Private Sub cbCommentaryOBS_TextChanged(sender As Object, e As EventArgs) Handles cbCommentaryOBS.TextChanged
        If Not String.IsNullOrWhiteSpace(cbCommentaryOBS.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbCommentaryOBS.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("text_gdiplus", cbCommentaryOBS.Text)

                lblCommentaryStatus.Visible = True

                If sSettings = True Then
                    lblCommentaryStatus.Text = CorrectMessage
                    lblCommentaryStatus.ForeColor = CorrectColour
                Else
                    lblCommentaryStatus.Text = IncorrectMessage
                    lblCommentaryStatus.ForeColor = InCorrectColour
                End If
            Else
                lblCommentaryStatus.Visible = False
            End If
        Else
            lblCommentaryStatus.Visible = False
        End If
    End Sub
    Function CheckFullyValid(ByVal ExpectedSourceType As String, ByVal SourceName As String) As Boolean
        Dim FullyValid As Boolean = False

        If Not String.IsNullOrWhiteSpace(SourceName) Then
            Dim MatchedValue As Boolean = CheckItemInList(SourceName)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes(ExpectedSourceType, SourceName)

                lblCommentaryStatus.Visible = True

                FullyValid = sSettings

            End If
        Else
            FullyValid = True
        End If

        Return FullyValid
    End Function
End Class
