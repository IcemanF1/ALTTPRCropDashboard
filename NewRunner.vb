Public Class NewRunner
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        OBSWebSocketCropper.NewRunnerName = txtRunnerName.Text
        OBSWebSocketCropper.NewRunnerTwitch = txtTwitchName.Text
        OBSWebSocketCropper.GetOBSInfo = chkAdjustInOBS.Checked

        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub NewRunner_Load(sender As Object, e As EventArgs) Handles Me.Load
        If chkAdjustInOBS.Checked = False Then
            chkReuseInfo.Checked = True
        End If

        txtRunnerName.Text = ""
        txtTwitchName.Text = ""

        txtTwitchName.Focus()
    End Sub
    Private Sub chkAdjustInOBS_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdjustInOBS.CheckedChanged
        If chkAdjustInOBS.Checked = True Then
            chkReuseInfo.Checked = False
        End If
    End Sub
    Private Sub chkReuseInfo_CheckedChanged(sender As Object, e As EventArgs) Handles chkReuseInfo.CheckedChanged
        If chkReuseInfo.Checked = True Then
            chkAdjustInOBS.Checked = False
        End If
    End Sub
End Class