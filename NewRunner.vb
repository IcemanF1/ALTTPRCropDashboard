Public Class NewRunner
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If Not String.IsNullOrWhiteSpace(txtTwitchName.Text) Then
            If Not String.IsNullOrWhiteSpace(txtRunnerName.Text) Then
                ObsWebSocketCropper.NewRunnerName = txtRunnerName.Text
            Else
                ObsWebSocketCropper.NewRunnerName = txtTwitchName.Text
            End If

            ObsWebSocketCropper.NewRunnerTwitch = txtTwitchName.Text
            ObsWebSocketCropper.GetOBSInfo = chkAdjustInOBS.Checked
            ObsWebSocketCropper.ReuseInfo = chkReuseInfo.Checked

            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("You must enter at least a twitch name.", MsgBoxStyle.OkOnly, ObsWebSocketCropper.ProgramName)
        End If

    End Sub
    Private Sub NewRunner_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtRunnerName.Text = ""
        txtTwitchName.Text = ""

        txtTwitchName.Focus()
    End Sub
End Class