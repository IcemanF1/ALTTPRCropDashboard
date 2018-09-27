Imports ALTTPRCropDashboard.DB
Imports System.Globalization
Public Class RunnerControls
    Private Sub RunnerControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConfigureDataBindings()
    End Sub
    Public Sub RefreshRunnerNames(isReset As Boolean)
        Dim tempRunner As String = cbRunnerName.Text

        If isReset Then
            tempRunner = ""
        Else
            tempRunner = cbRunnerName.Text
        End If

        ObsWebSocketCropper.ReuseInfo = False

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.RunnerName}).Distinct().ToList().OrderBy(Function(r) r.RacerName, StringComparer.CurrentCultureIgnoreCase).ToList()
            cbRunnerName.DataSource = validNames
        End Using

        cbRunnerName.Text = tempRunner

        ObsWebSocketCropper.ReuseInfo = True

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
    End Sub
    Private Sub ValidateKeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles txtCropTimer_Top.KeyPress, txtCropTimer_Right.KeyPress,
                txtCropTimer_Left.KeyPress, txtCropTimer_Bottom.KeyPress,
                txtCropGame_Top.KeyPress, txtCropGame_Right.KeyPress,
                txtCropGame_Left.KeyPress, txtCropGame_Bottom.KeyPress

        e.Handled = ObsWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Function isRunnerNumValid() As Boolean
        If Not String.IsNullOrWhiteSpace(lblRunnerNumber.Text) Then
            If IsNumeric(lblRunnerNumber.Text) Then
                If CInt(lblRunnerNumber.Text) > 0 Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function
    Public Property twitchName As String
        Get
            Return lblRunnerTwitch.Text
        End Get
        Set(value As String)
            lblRunnerTwitch.Text = value
        End Set
    End Property
    Public Property runnerName As String
        Get
            Return cbRunnerName.Text
        End Get
        Set(value As String)
            cbRunnerName.Text = value
        End Set
    End Property
    Public Sub SetComboBoxMembers()
        cbVLCSource.DisplayMember = "VLCName"
        cbVLCSource.ValueMember = "VLCName"
        cbVLCSource.Text = ""
    End Sub
    Public Sub CheckVLCForRunner()
        Dim data = ObsWebSocketCropper.vlcProcesses.Select(Function(v) New With {.VLCName = v.MainWindowTitle}).ToList()

        cbVLCSource.DataSource = data.ToList()
        SetComboBoxMembers()

        If Not String.IsNullOrWhiteSpace(lblRunnerTwitch.Text) Then
            Dim tempText = lblRunnerTwitch.Text.Remove(0, 8)
            If Not String.IsNullOrWhiteSpace(tempText) Then
                Dim match = data.FirstOrDefault(Function(d) d.VLCName.StartsWith(tempText, True, CultureInfo.InvariantCulture))

                If match IsNot Nothing Then
                    cbVLCSource.Text = match.VLCName
                End If
            End If
        End If
    End Sub
    Function backColourChoice(runnerNumber As Integer, isVLC As Boolean) As String
        If isVLC Then
            Select Case runnerNumber
                Case 1
                    backColourChoice = "GreenYellow"
                Case 2
                    backColourChoice = "LightSalmon"
                Case 3
                    backColourChoice = "LightSkyBlue"
                Case 4
                    backColourChoice = "Violet"
            End Select
        Else
            Select Case runnerNumber
                Case 1
                    backColourChoice = "PaleGreen"
                Case 2
                    backColourChoice = "MistyRose"
                Case 3
                    backColourChoice = "PaleTurquoise"
                Case 4
                    backColourChoice = "Thistle"
            End Select
        End If

    End Function
    Public Sub AdjustVisuals(runnerNumber As Integer)
        lblRunnerControlNumber.Text = "Runner " & runnerNumber

        btnSetVLC.BackColor = Color.FromName(backColourChoice(runnerNumber, True))
        lblVLC.BackColor = Color.FromName(backColourChoice(runnerNumber, True))

        gbTimerWindow.BackColor = Color.FromName(backColourChoice(runnerNumber, False))
        gbGameWindow.BackColor = Color.FromName(backColourChoice(runnerNumber, False))
        btnSetCrop.BackColor = Color.FromName(backColourChoice(runnerNumber, False))

        lblRunner.BackColor = Color.FromName(ObsWebSocketCropper.TrackerRunnerColour)
        lblTracker.BackColor = Color.FromName(ObsWebSocketCropper.TrackerRunnerColour)
    End Sub
    Public Sub SetToolTips(runnerNumber As Integer)
        'Me.ttMainToolTip.SetToolTip(Me.btnConnectOBS1, 
        ' "Attempt to connect to the OBS Websocket based off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the connection string and pass" &
        '"word")

        ttMainToolTip.SetToolTip(txtTrackerURL, "The URL for the tracker for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(cbRunnerName, "The runner name for runner # " & runnerNumber & "." & ChrW(13) & ChrW(10) & "If runner you are looking for is not in the list you will need to add as a new runner.")
        ttMainToolTip.SetToolTip(lblViewOnTwitch, "View the selected runner on twitch on your default browser")
        ttMainToolTip.SetToolTip(lblVOD, "View the selected runner's VODs on twitch on your default browser")
        ttMainToolTip.SetToolTip(lblStreamlink, "Attempt to view the selected runner's twtich on VLC using streamlink." & ChrW(13) & ChrW(10) & "If your streamlink settings weren not entered correctly this may crash.  Use at your own risk.")
        ttMainToolTip.SetToolTip(btnNewRunner, "Add a new runner to the local DB to be able to enter crop info")
        ttMainToolTip.SetToolTip(cbVLCSource, "The current list of running VLC processes")
        ttMainToolTip.SetToolTip(btnSetVLC, "Set the currently selected VLC process to the timer & game windows in OBS for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(cbScaling, "The scaling percent that will be applied to the crop." & ChrW(13) & ChrW(10) & "This is only needed in extreme cases where windows scaling is affecting things.")
        ttMainToolTip.SetToolTip(btnTimerDB, "Reset the current timer crop numbers to what was saved in the DB for runner # " & runnerNumber & "." & ChrW(13) & ChrW(10) & "You will still need to set the crop to apply the values.")
        ttMainToolTip.SetToolTip(btnGameDB, "Reset the current game crop numbers to what was saved in the DB for runner # " & runnerNumber & "." & ChrW(13) & ChrW(10) & "You will still need to set the crop to apply the values.")
        ttMainToolTip.SetToolTip(btnTimerUncrop, "Reset the current timer crop numbers to an uncropped state for runner # " & runnerNumber & "." & ChrW(13) & ChrW(10) & "This will automatically set it in OBS.")
        ttMainToolTip.SetToolTip(btnGameUncrop, "Reset the current game crop numbers to an uncropped state for runner # " & runnerNumber & "." & ChrW(13) & ChrW(10) & "This will automatically set it in OBS.")
        ttMainToolTip.SetToolTip(btnSetCrop, "Sets the current timer & game crops in OBS based on the current values for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(btnGetCrop, "Retrieves the current timer & game crop values in OBS for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(btnSaveCrop, "Saves the current timer & game crops values into the DB for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropGame_Left, "The LEFT crop value for the GAME window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropGame_Right, "The RIGHT crop value for the GAME window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropGame_Top, "The TOP crop value for the GAME window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropGame_Bottom, "The BOTTOM crop value for the GAME window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropTimer_Left, "The LEFT crop value for the TIMER window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropTimer_Right, "The RIGHT crop value for the TIMER window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropTimer_Top, "The TOP crop value for the TIMER window for runner # " & runnerNumber)
        ttMainToolTip.SetToolTip(txtCropTimer_Bottom, "The BOTTOM crop value for the TIMER window for runner # " & runnerNumber)
    End Sub

End Class
