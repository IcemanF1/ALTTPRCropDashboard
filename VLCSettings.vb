Public Class VLCSettings
    Dim DefaultTopValue As Integer
    Dim DefaultBottomValue As Integer

    Dim DefaultStatusBar As Integer = 22
    Dim DefaultMenuBar As Integer = 22
    Dim DefaultPlayPause As Integer = 53

    Private Sub SaveVLCSettings()
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

        My.Settings.DefaultCropBottom = DefaultCropBottom
        My.Settings.DefaultCropTop = DefaultCropTop

        My.Settings.VLCOverrideDefault = chkOverrideDefault.Checked
        My.Settings.VLCPlayPauseControls = chkPlayPauseControls.Checked
        My.Settings.VLCMenuBar = chkMenuBar.Checked
        My.Settings.VLCStatusBar = chkStatusBar.Checked

        My.Settings.Save()

        Me.Close()
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
    Private Sub chkOverrideDefault_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverrideDefault.CheckedChanged
        ShowOverrideSettings(chkOverrideDefault.Checked)
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
    Private Sub ShowOverrideSettings(ByVal ShowSetting As Boolean)
        lblWarning.Visible = ShowSetting
        lblTop.Visible = ShowSetting
        lblBottom.Visible = ShowSetting
        txtDefaultCropBottom.Visible = ShowSetting
        txtDefaultCropTop.Visible = ShowSetting

        If ShowSetting = False Then
            CheckPersonalValuesAgainstStandard()
        End If
    End Sub
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        SaveVLCSettings()
    End Sub

End Class