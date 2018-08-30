Public Class RunnerSettings
    Public Property runnerNameSource As String
        Get
            Return cbRunnerOBS.Text
        End Get
        Set(value As String)
            cbRunnerOBS.Text = value
        End Set
    End Property
    Public Property trackerSource As String
        Get
            Return cbTrackerOBS.Text
        End Get
        Set(value As String)
            cbTrackerOBS.Text = value
        End Set
    End Property
    Public Property timerSource As String
        Get
            Return cbTimerWindow.Text
        End Get
        Set(value As String)
            cbTimerWindow.Text = value
        End Set
    End Property
    Public Property gameSource As String
        Get
            Return cbGameWindow.Text
        End Get
        Set(value As String)
            cbGameWindow.Text = value
        End Set
    End Property
    Public Sub SetComboBoxData(sourceData As DataSet, sourceName As ComboBox)
        sourceName.DataSource = sourceData.Tables("Sources").Copy
        sourceName.DisplayMember = "SourceName"
        sourceName.ValueMember = "SourceName"
    End Sub
End Class
