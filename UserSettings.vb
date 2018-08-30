'﻿Imports System.Configuration

Public Class UserSettings
    Dim _obsCommentary As New DataSet
    Dim _obsGameSettings As New DataSet
    Dim CorrectMessage As String = "Correct Source Type"
    Dim IncorrectMessage As String = "Incorrect Source Type"

    Dim CorrectColour As Color = Color.Green
    Dim InCorrectColour As Color = Color.Red

    Dim FourPlayer As Boolean

    Friend WithEvents rSettings1 As New RunnerSettings
    Friend WithEvents rSettings2 As New RunnerSettings
    Friend WithEvents rSettings3 As New RunnerSettings
    Friend WithEvents rSettings4 As New RunnerSettings

    Public Shared ShowVLCOption As Boolean

    Function VerifySettings() As Boolean
        If String.IsNullOrWhiteSpace(txtTwitchChannel.Text) Then
            MsgBox("You must enter a twitch channel.", MsgBoxStyle.OkOnly, OBSWebSocketCropper.ProgramName)
            Return False
        End If

        Dim match As Boolean = False

        If String.IsNullOrWhiteSpace(rSettings1.gameSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings1.timerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings1.trackerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings1.runnerNameSource) And match = False Then
            match = True
        End If

        If String.IsNullOrWhiteSpace(rSettings2.gameSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings2.timerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings2.trackerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings2.runnerNameSource) And match = False Then
            match = True
        End If

        If String.IsNullOrWhiteSpace(rSettings3.gameSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings3.timerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings3.trackerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings3.runnerNameSource) And match = False Then
            match = True
        End If

        If String.IsNullOrWhiteSpace(rSettings4.gameSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings4.timerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings4.trackerSource) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(rSettings4.runnerNameSource) And match = False Then
            match = True
        End If

        If String.IsNullOrWhiteSpace(cbCommentaryOBS.Text) And match = False Then
            match = True
        End If
        If String.IsNullOrWhiteSpace(cbGameSettings.Text) And match = False Then
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

            Dim FullyValid As Boolean

            FullyValid = CheckFullyValid("window_capture", rSettings1.timerSource)
            If FullyValid = True Then
                My.Settings.TimerName_Runner1 = rSettings1.timerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings1.gameSource)
            If FullyValid = True Then
                My.Settings.GameName_Runner1 = rSettings1.gameSource
            End If

            FullyValid = CheckFullyValid("text_gdiplus", rSettings1.runnerNameSource)
            If FullyValid = True Then
                My.Settings.RunnerOBS_Runner1 = rSettings1.runnerNameSource
            End If

            FullyValid = CheckFullyValid("browser_source", rSettings1.trackerSource)
            If FullyValid = True Then
                My.Settings.TrackerOBS_Runner1 = rSettings1.trackerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings2.timerSource)
            If FullyValid = True Then
                My.Settings.TimerName_Runner2 = rSettings2.timerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings2.gameSource)
            If FullyValid = True Then
                My.Settings.GameName_Runner2 = rSettings2.gameSource
            End If

            FullyValid = CheckFullyValid("text_gdiplus", rSettings2.runnerNameSource)
            If FullyValid = True Then
                My.Settings.RunnerOBS_Runner2 = rSettings2.runnerNameSource
            End If

            FullyValid = CheckFullyValid("browser_source", rSettings2.trackerSource)
            If FullyValid = True Then
                My.Settings.TrackerOBS_Runner2 = rSettings2.trackerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings3.timerSource)
            If FullyValid = True Then
                My.Settings.TimerName_Runner3 = rSettings3.timerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings3.gameSource)
            If FullyValid = True Then
                My.Settings.GameName_Runner3 = rSettings3.gameSource
            End If

            FullyValid = CheckFullyValid("text_gdiplus", rSettings3.runnerNameSource)
            If FullyValid = True Then
                My.Settings.RunnerOBS_Runner3 = rSettings3.runnerNameSource
            End If

            FullyValid = CheckFullyValid("browser_source", rSettings3.trackerSource)
            If FullyValid = True Then
                My.Settings.TrackerOBS_Runner3 = rSettings3.trackerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings4.timerSource)
            If FullyValid = True Then
                My.Settings.TimerName_Runner4 = rSettings4.timerSource
            End If

            FullyValid = CheckFullyValid("window_capture", rSettings4.gameSource)
            If FullyValid = True Then
                My.Settings.GameName_Runner4 = rSettings4.gameSource
            End If

            FullyValid = CheckFullyValid("text_gdiplus", rSettings4.runnerNameSource)
            If FullyValid = True Then
                My.Settings.RunnerOBS_Runner4 = rSettings4.runnerNameSource
            End If

            FullyValid = CheckFullyValid("browser_source", rSettings4.trackerSource)
            If FullyValid = True Then
                My.Settings.TrackerOBS_Runner4 = rSettings4.trackerSource
            End If

            FullyValid = CheckFullyValid("text_gdiplus", cbCommentaryOBS.Text)
            If FullyValid = True Then
                My.Settings.CommentaryOBS = cbCommentaryOBS.Text
            End If

            FullyValid = CheckFullyValid("text_gdiplus", cbGameSettings.Text)
            If FullyValid = True Then
                My.Settings.GameSettings = cbGameSettings.Text
            End If

            If Not continueToVlc Then
                My.Settings.DefaultCropBottom = 53
                My.Settings.DefaultCropTop = 22
            End If

            My.Settings.ConnectionString1 = txtConnectionString1.Text
            My.Settings.Password1 = txtPassword1.Text
            My.Settings.ConnectionPort1 = CInt(txtConnectionPort.Text)
            My.Settings.TwitchChannel = txtTwitchChannel.Text
            My.Settings.DefaultConnection = roDefault.Checked
            My.Settings.HasFinishedWelcome = True
            My.Settings.ExpertMode = My.Settings.ExpertMode
            My.Settings.AlwaysOnTop = My.Settings.AlwaysOnTop

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
        If _obsCommentary.Tables.Count = 0 Then
            _obsCommentary.Tables.Add("Sources")
            _obsCommentary.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsCommentary.Tables("Sources").Clear()
        End If

        If _obsGameSettings.Tables.Count = 0 Then
            _obsGameSettings.Tables.Add("Sources")
            _obsGameSettings.Tables("Sources").Columns.Add("SourceName")
        Else
            _obsGameSettings.Tables("Sources").Clear()
        End If
    End Sub

    Private Sub SetUserSettings()
        If My.Settings.HasFinishedWelcome = False Then

        Else
            rSettings1.runnerNameSource = My.Settings.RunnerOBS_Runner1
            rSettings1.gameSource = My.Settings.GameName_Runner1
            rSettings1.timerSource = My.Settings.TimerName_Runner1
            rSettings1.trackerSource = My.Settings.TrackerOBS_Runner1

            rSettings2.runnerNameSource = My.Settings.RunnerOBS_Runner2
            rSettings2.gameSource = My.Settings.GameName_Runner2
            rSettings2.timerSource = My.Settings.TimerName_Runner2
            rSettings2.trackerSource = My.Settings.TrackerOBS_Runner2

            rSettings3.runnerNameSource = My.Settings.RunnerOBS_Runner3
            rSettings3.gameSource = My.Settings.GameName_Runner3
            rSettings3.timerSource = My.Settings.TimerName_Runner3
            rSettings3.trackerSource = My.Settings.TrackerOBS_Runner3

            rSettings4.runnerNameSource = My.Settings.RunnerOBS_Runner4
            rSettings4.gameSource = My.Settings.GameName_Runner4
            rSettings4.timerSource = My.Settings.TimerName_Runner4
            rSettings4.trackerSource = My.Settings.TrackerOBS_Runner4

            cbCommentaryOBS.Text = My.Settings.CommentaryOBS
            cbGameSettings.Text = My.Settings.GameSettings

        End If
    End Sub
    Private Sub AddUserControls()
        Dim sHori, sVert As Integer

        sHori = 19
        sVert = 6

        rSettings1.Location = New System.Drawing.Point(sVert, sHori)
        rSettings1.Name = "rSettings1"
        gbRunner1.Controls.Add(rSettings1)

        rSettings2.Location = New System.Drawing.Point(sVert, sHori)
        rSettings2.Name = "rSettings2"
        gbRunner2.Controls.Add(rSettings2)

        rSettings3.Location = New System.Drawing.Point(sVert, sHori)
        rSettings3.Name = "rSettings3"
        gbRunner3.Controls.Add(rSettings3)

        rSettings4.Location = New System.Drawing.Point(sVert, sHori)
        rSettings4.Name = "rSettings4"
        gbRunner4.Controls.Add(rSettings4)
    End Sub
    Private Sub btnRefreshScenes_Click(sender As Object, e As EventArgs) Handles btnRefreshScenes.Click
        RefreshScenes()
        SetUserSettings()
    End Sub
    Private Sub SaveConnectionForTest()
        My.Settings.ConnectionString1 = txtConnectionString1.Text
        My.Settings.Password1 = txtPassword1.Text
        My.Settings.ConnectionPort1 = CInt(txtConnectionPort.Text)

        My.Settings.Save()
    End Sub
    Private Sub UserSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtConnectionString1.Text = My.Settings.ConnectionString1
        txtConnectionPort.Text = My.Settings.ConnectionPort1.ToString
        txtPassword1.Text = My.Settings.Password1

        AddUserControls()

        panOBS.Visible = False
        btnRefreshScenes.Visible = False

        txtTwitchChannel.Text = My.Settings.TwitchChannel

        gbConnection1.Visible = False

        roDefault.Checked = My.Settings.DefaultConnection

        btnSaveThenVLC.Visible = ShowVLCOption

        CreateNewSourceTable()

        CheckObsPort()

        AddHandlers()
    End Sub
    Private Sub RefreshScenes()
        Dim scenes = OBSWebSocketCropper.Obs.ListScenes()

        _obsCommentary.Clear()
        _obsGameSettings.Clear()

        Dim x As Integer
        For x = 0 To scenes.Count - 1
            Dim dr As DataRow

            Dim y As Integer
            For y = 0 To scenes(x).Items.Count - 1
                dr = _obsCommentary.Tables("Sources").NewRow
                dr.Item("SourceName") = scenes(x).Items(y).SourceName
                _obsCommentary.Tables("Sources").Rows.Add(dr)
            Next

        Next

        _obsGameSettings = _obsCommentary.Copy

        cbCommentaryOBS.DataSource = _obsCommentary.Tables("Sources")
        cbCommentaryOBS.DisplayMember = "SourceName"
        cbCommentaryOBS.ValueMember = "SourceName"

        cbGameSettings.DataSource = _obsGameSettings.Tables("Sources")
        cbGameSettings.DisplayMember = "SourceName"
        cbGameSettings.ValueMember = "SourceName"

        RefreshUserControlDropdowns()

        SetBlankDropdowns()
    End Sub
    Private Sub RefreshUserControlDropdowns()
        rSettings1.SetComboBoxData(_obsCommentary, rSettings1.cbGameWindow)
        rSettings1.SetComboBoxData(_obsCommentary, rSettings1.cbTimerWindow)
        rSettings1.SetComboBoxData(_obsCommentary, rSettings1.cbTrackerOBS)
        rSettings1.SetComboBoxData(_obsCommentary, rSettings1.cbRunnerOBS)

        rSettings2.SetComboBoxData(_obsCommentary, rSettings2.cbGameWindow)
        rSettings2.SetComboBoxData(_obsCommentary, rSettings2.cbTimerWindow)
        rSettings2.SetComboBoxData(_obsCommentary, rSettings2.cbTrackerOBS)
        rSettings2.SetComboBoxData(_obsCommentary, rSettings2.cbRunnerOBS)

        rSettings3.SetComboBoxData(_obsCommentary, rSettings3.cbGameWindow)
        rSettings3.SetComboBoxData(_obsCommentary, rSettings3.cbTimerWindow)
        rSettings3.SetComboBoxData(_obsCommentary, rSettings3.cbTrackerOBS)
        rSettings3.SetComboBoxData(_obsCommentary, rSettings3.cbRunnerOBS)

        rSettings4.SetComboBoxData(_obsCommentary, rSettings4.cbGameWindow)
        rSettings4.SetComboBoxData(_obsCommentary, rSettings4.cbTimerWindow)
        rSettings4.SetComboBoxData(_obsCommentary, rSettings4.cbTrackerOBS)
        rSettings4.SetComboBoxData(_obsCommentary, rSettings4.cbRunnerOBS)

    End Sub
    Private Sub SetBlankDropdowns()
        rSettings1.timerSource = ""
        rSettings1.gameSource = ""
        rSettings1.trackerSource = ""
        rSettings1.runnerNameSource = ""

        rSettings2.timerSource = ""
        rSettings2.gameSource = ""
        rSettings2.trackerSource = ""
        rSettings2.runnerNameSource = ""

        rSettings3.timerSource = ""
        rSettings3.gameSource = ""
        rSettings3.trackerSource = ""
        rSettings3.runnerNameSource = ""

        rSettings4.timerSource = ""
        rSettings4.gameSource = ""
        rSettings4.trackerSource = ""
        rSettings4.runnerNameSource = ""

        cbCommentaryOBS.Text = ""
        cbGameSettings.Text = ""
    End Sub

    Private Sub CheckObsPort()

        Dim portOpen As Boolean = OBSWebSocketCropper.Obs.IsPortOpen(OBSWebSocketCropper.ConnectionString)

        If PortOpen = False Then
            MsgBox("The OBS connection is not open.  Please connect to OBS before doing anything else!", MsgBoxStyle.OkOnly, OBSWebSocketCropper.ProgramName)
        Else
            If ObsWebSocketCropper.Obs.IsConnected Then
                panOBS.Visible = True
                btnRefreshScenes.Visible = True
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

        lblOBS1ConnectedStatus.Text = OBSWebSocketCropper.ObsConnectionStatus

        If ObsWebSocketCropper.Obs.IsConnected Then
            panOBS.Visible = True
            btnSaveSettings.Enabled = True
            btnSaveThenVLC.Enabled = True
            btnRefreshScenes.Visible = True
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
        e.Handled = ObsWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub btnSaveThenVLC_Click(sender As Object, e As EventArgs) Handles btnSaveThenVLC.Click
        SaveSettings(True)
    End Sub
    Function CheckForValidSourceTypes(ByVal ExpectedSourceType As String, ByVal SourceName As String) As Boolean
        Dim sSettings As Boolean

        'SourceName = cbLeftRunnerOBS.Text
        If SourceName <> "System.Data.DataRowView" Then
            sSettings = ObsWebSocketCropper.Obs.ConfirmSourceType(ExpectedSourceType, SourceName)
        End If

        Return sSettings
    End Function
    Function CheckItemInList(ByVal ListValue As String) As Boolean
        Dim x As Integer
        Dim MatchedValue As Boolean
        If _obsCommentary.Tables.Count > 0 Then
            For x = 0 To _obsCommentary.Tables("Sources").Rows.Count - 1
                If ListValue = _obsCommentary.Tables("Sources").Rows(x)("SourceName")?.ToString() Then
                    MatchedValue = True
                    Exit For
                End If
            Next
        End If

        Return MatchedValue
    End Function
    Private Sub AddHandlers()
        AddHandler rSettings1.cbGameWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings1.cbTimerWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings1.cbTrackerOBS.TextChanged, AddressOf browserSource_TextChanged
        AddHandler rSettings1.cbRunnerOBS.TextChanged, AddressOf textSource_TextChanged

        AddHandler rSettings2.cbGameWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings2.cbTimerWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings2.cbTrackerOBS.TextChanged, AddressOf browserSource_TextChanged
        AddHandler rSettings2.cbRunnerOBS.TextChanged, AddressOf textSource_TextChanged

        AddHandler rSettings3.cbGameWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings3.cbTimerWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings3.cbTrackerOBS.TextChanged, AddressOf browserSource_TextChanged
        AddHandler rSettings3.cbRunnerOBS.TextChanged, AddressOf textSource_TextChanged

        AddHandler rSettings4.cbGameWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings4.cbTimerWindow.TextChanged, AddressOf windowSource_TextChanged
        AddHandler rSettings4.cbTrackerOBS.TextChanged, AddressOf browserSource_TextChanged
        AddHandler rSettings4.cbRunnerOBS.TextChanged, AddressOf textSource_TextChanged
    End Sub

    Function getParentControlName(sender As Object) As String
        Dim ctl As Control = CType(sender, Control)

        Return ctl.Parent.Name.ToString
    End Function
    Function getControlName(sender As Object) As String
        Dim ctl As Control = CType(sender, Control)

        Return ctl.Name.ToString
    End Function
    Protected Sub textSource_TextChanged(sender As Object, e As System.EventArgs)
        Dim senderParent As String = getParentControlName(sender)
        Dim senderName As String = getControlName(sender)

        checkUserControlField("text_gdiplus", senderName, senderParent)
    End Sub
    Protected Sub browserSource_TextChanged(sender As Object, e As System.EventArgs)
        Dim senderParent As String = getParentControlName(sender)
        Dim senderName As String = getControlName(sender)

        checkUserControlField("browser_source", senderName, senderParent)
    End Sub
    Protected Sub windowSource_TextChanged(sender As Object, e As System.EventArgs)
        Dim senderParent As String = getParentControlName(sender)
        Dim senderName As String = getControlName(sender)

        checkUserControlField("window_capture", senderName, senderParent)
    End Sub
    Private Sub checkUserControlField(expectedSourceType As String, sourceName As String, senderParent As String)
        Dim cbName As ComboBox
        Dim statusLabel As Label

        If senderParent = "rSettings1" Then
            If sourceName = "cbGameWindow" Then
                cbName = rSettings1.cbGameWindow
                statusLabel = rSettings1.lblGameStatus
            ElseIf sourceName = "cbRunnerOBS" Then
                cbName = rSettings1.cbRunnerOBS
                statusLabel = rSettings1.lblRunnerNameStatus
            ElseIf sourceName = "cbTimerWindow" Then
                cbName = rSettings1.cbTimerWindow
                statusLabel = rSettings1.lblTimerStatus
            ElseIf sourceName = "cbTrackerOBS" Then
                cbName = rSettings1.cbTrackerOBS
                statusLabel = rSettings1.lblTrackerStatus
            End If
        ElseIf senderParent = "rSettings2" Then
            If sourceName = "cbGameWindow" Then
                cbName = rSettings2.cbGameWindow
                statusLabel = rSettings2.lblGameStatus
            ElseIf sourceName = "cbRunnerOBS" Then
                cbName = rSettings2.cbRunnerOBS
                statusLabel = rSettings2.lblRunnerNameStatus
            ElseIf sourceName = "cbTimerWindow" Then
                cbName = rSettings2.cbTimerWindow
                statusLabel = rSettings2.lblTimerStatus
            ElseIf sourceName = "cbTrackerOBS" Then
                cbName = rSettings2.cbTrackerOBS
                statusLabel = rSettings2.lblTrackerStatus
            End If
        ElseIf senderParent = "rSettings3" Then
            If sourceName = "cbGameWindow" Then
                cbName = rSettings3.cbGameWindow
                statusLabel = rSettings3.lblGameStatus
            ElseIf sourceName = "cbRunnerOBS" Then
                cbName = rSettings3.cbRunnerOBS
                statusLabel = rSettings3.lblRunnerNameStatus
            ElseIf sourceName = "cbTimerWindow" Then
                cbName = rSettings3.cbTimerWindow
                statusLabel = rSettings3.lblTimerStatus
            ElseIf sourceName = "cbTrackerOBS" Then
                cbName = rSettings3.cbTrackerOBS
                statusLabel = rSettings3.lblTrackerStatus
            End If
        ElseIf senderParent = "rSettings4" Then
            If sourceName = "cbGameWindow" Then
                cbName = rSettings4.cbGameWindow
                statusLabel = rSettings4.lblGameStatus
            ElseIf sourceName = "cbRunnerOBS" Then
                cbName = rSettings4.cbRunnerOBS
                statusLabel = rSettings4.lblRunnerNameStatus
            ElseIf sourceName = "cbTimerWindow" Then
                cbName = rSettings4.cbTimerWindow
                statusLabel = rSettings4.lblTimerStatus
            ElseIf sourceName = "cbTrackerOBS" Then
                cbName = rSettings4.cbTrackerOBS
                statusLabel = rSettings4.lblTrackerStatus
            End If
        End If

        If Not String.IsNullOrWhiteSpace(cbName.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbName.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes(expectedSourceType, cbName.Text)

                statusLabel.Visible = True

                If sSettings = True Then
                    statusLabel.Text = CorrectMessage
                    statusLabel.ForeColor = CorrectColour
                Else
                    statusLabel.Text = IncorrectMessage
                    statusLabel.ForeColor = InCorrectColour
                End If
            Else
                statusLabel.Visible = False
            End If
        Else
            statusLabel.Visible = False
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
    Private Sub cbGameSettings_TextChanged(sender As Object, e As EventArgs) Handles cbGameSettings.TextChanged
        If Not String.IsNullOrWhiteSpace(cbGameSettings.Text) Then
            Dim MatchedValue As Boolean = CheckItemInList(cbGameSettings.Text)

            If MatchedValue = True Then
                Dim sSettings As Boolean = CheckForValidSourceTypes("text_gdiplus", cbGameSettings.Text)

                If FourPlayer Then
                    lblGameSettingsStatus.Visible = False
                Else
                    lblGameSettingsStatus.Visible = True
                End If


                If sSettings = True Then
                    lblGameSettingsStatus.Text = CorrectMessage
                    lblGameSettingsStatus.ForeColor = CorrectColour
                Else
                    lblGameSettingsStatus.Text = IncorrectMessage
                    lblGameSettingsStatus.ForeColor = InCorrectColour
                End If
            Else
                lblGameSettingsStatus.Visible = False
            End If
        Else
            lblGameSettingsStatus.Visible = False
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

