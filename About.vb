
Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "Version: " & Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly.GetName.Version())
    End Sub
End Class