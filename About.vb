
Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "Version: " & Convert.ToString(Application.ProductVersion)
    End Sub
End Class