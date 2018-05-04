Public Class NewRunner
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        OBSWebSocketCropper.NewRunnerName = txtRunnerName.Text
        OBSWebSocketCropper.NewRunnerTwitch = txtTwitchName.Text
        OBSWebSocketCropper.GetOBSInfo = chkAdjustInOBS.Checked
        OBSWebSocketCropper.ReuseInfo = chkReuseInfo.Checked

        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub NewRunner_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtRunnerName.Text = ""
        txtTwitchName.Text = ""

        txtTwitchName.Focus()
    End Sub
End Class