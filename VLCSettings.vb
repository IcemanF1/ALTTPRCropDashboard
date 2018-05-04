Public Class VlcSettings
    Dim _defaultTopValue As Integer
    Dim _defaultBottomValue As Integer

    Dim _defaultStatusBar As Integer = 22
    Dim _defaultMenuBar As Integer = 22
    Dim _defaultPlayPause As Integer = 53

    Private Sub SaveVlcSettings()
        Dim defaultCropTop, defaultCropBottom As Integer

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

        My.Settings.DefaultCropBottom = DefaultCropBottom
        My.Settings.DefaultCropTop = DefaultCropTop

        My.Settings.VLCOverrideDefault = chkOverrideDefault.Checked
        My.Settings.VLCPlayPauseControls = chkPlayPauseControls.Checked
        My.Settings.VLCMenuBar = chkMenuBar.Checked
        My.Settings.VLCStatusBar = chkStatusBar.Checked

        My.Settings.Save()

        Close()
    End Sub
    Private Sub RefreshSettings()
        txtDefaultCropTop.Text = My.Settings.DefaultCropTop
        txtDefaultCropBottom.Text = My.Settings.DefaultCropBottom
        chkOverrideDefault.Checked = My.Settings.VLCOverrideDefault
        chkPlayPauseControls.Checked = My.Settings.VLCPlayPauseControls
        chkMenuBar.Checked = My.Settings.VLCMenuBar
        chkStatusBar.Checked = My.Settings.VLCStatusBar

        ShowOverrideSettings(My.Settings.VLCOverrideDefault)
    End Sub
    Private Sub VLCSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshSettings()
    End Sub
    Private Sub chkMenuBar_CheckedChanged(sender As Object, e As EventArgs) Handles chkMenuBar.CheckedChanged
        If chkMenuBar.Checked = True Then
            _defaultTopValue = _defaultMenuBar
        Else
            _defaultTopValue = 0
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub chkStatusBar_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatusBar.CheckedChanged
        If chkStatusBar.Checked = True Then
            _defaultBottomValue = _defaultBottomValue + _defaultStatusBar
        Else
            _defaultBottomValue = _defaultBottomValue - _defaultStatusBar
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub chkPlayPauseControls_CheckedChanged(sender As Object, e As EventArgs) Handles chkPlayPauseControls.CheckedChanged
        If chkPlayPauseControls.Checked = True Then
            _defaultBottomValue = _defaultBottomValue + _defaultPlayPause
        Else
            _defaultBottomValue = _defaultBottomValue - _defaultPlayPause
        End If

        CheckPersonalValuesAgainstStandard()
    End Sub
    Private Sub chkOverrideDefault_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverrideDefault.CheckedChanged
        ShowOverrideSettings(chkOverrideDefault.Checked)
    End Sub

    Private Sub CheckPersonalValuesAgainstStandard()
        If chkOverrideDefault.Checked = False Then
            txtDefaultCropTop.Text = _defaultTopValue

            If _defaultBottomValue < 0 Then
                txtDefaultCropBottom.Text = 0
            Else
                txtDefaultCropBottom.Text = _defaultBottomValue
            End If
        End If

    End Sub
    Private Sub ShowOverrideSettings(showSetting As Boolean)
        lblWarning.Visible = showSetting
        lblTop.Visible = showSetting
        lblBottom.Visible = showSetting
        txtDefaultCropBottom.Visible = showSetting
        txtDefaultCropTop.Visible = showSetting

        If showSetting = False Then
            CheckPersonalValuesAgainstStandard()
        End If
    End Sub
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        SaveVLCSettings()
    End Sub

    Private Sub txtDefaultCropTop_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDefaultCropTop.KeyPress
        e.Handled = OBSWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub txtDefaultCropBottom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDefaultCropBottom.KeyPress
        e.Handled = OBSWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub

End Class