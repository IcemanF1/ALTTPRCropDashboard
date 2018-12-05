
Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "Version: " & Convert.ToString(Application.ProductVersion)
        lblNewVersion.Text = Convert.ToString(GlobalParam.UpdateVersion)
    End Sub
End Class