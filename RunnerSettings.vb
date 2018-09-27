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
    Public Function verifyDropdowns() As Boolean
        If String.IsNullOrWhiteSpace(gameSource) Then
            Return True
        End If
        If String.IsNullOrWhiteSpace(timerSource) Then
            Return True
        End If
        If String.IsNullOrWhiteSpace(trackerSource) Then
            Return True
        End If
        If String.IsNullOrWhiteSpace(runnerNameSource) Then
            Return True
        End If

        Return False
    End Function
    Public Sub setBlankDropdowns()
        timerSource = ""
        gameSource = ""
        trackerSource = ""
        runnerNameSource = ""
    End Sub
End Class
