Imports System.IO

Public Class GlobalParam
    Public Shared _configList As New DataSet
    Public Shared ConfigFilePath As String = "C:\ALTTPRFiles\"
    Public Shared UpdateVersion As String

    Public Shared BoundingSizeGame As Rectangle
    Public Shared BoundingSizeTimer As Rectangle

    Public Shared PositionXTimer_Runner1 As Integer
    Public Shared PositionXTimer_Runner2 As Integer
    Public Shared PositionXTimer_Runner3 As Integer
    Public Shared PositionXTimer_Runner4 As Integer

    Public Shared PositionYTimer_Runner1 As Integer
    Public Shared PositionYTimer_Runner2 As Integer
    Public Shared PositionYTimer_Runner3 As Integer
    Public Shared PositionYTimer_Runner4 As Integer

    Public Shared PositionYGame_Runner1 As Integer
    Public Shared PositionYGame_Runner2 As Integer
    Public Shared PositionYGame_Runner3 As Integer
    Public Shared PositionYGame_Runner4 As Integer

    Public Shared positionXGame_Runner1 As Integer
    Public Shared positionXGame_Runner2 As Integer
    Public Shared positionXGame_Runner3 As Integer
    Public Shared positionXGame_Runner4 As Integer

    Public Shared gameSource_Runner1 As String
    Public Shared timerSource_Runner1 As String
    Public Shared streamLinkParams_Runner1 As String
    Public Shared runnerNameSource_Runner1 As String
    Public Shared trackerSource_Runner1 As String

    Public Shared gameSource_Runner2 As String
    Public Shared timerSource_Runner2 As String
    Public Shared streamLinkParams_Runner2 As String
    Public Shared runnerNameSource_Runner2 As String
    Public Shared trackerSource_Runner2 As String

    Public Shared gameSource_Runner3 As String
    Public Shared timerSource_Runner3 As String
    Public Shared streamLinkParams_Runner3 As String
    Public Shared runnerNameSource_Runner3 As String
    Public Shared trackerSource_Runner3 As String

    Public Shared gameSource_Runner4 As String
    Public Shared timerSource_Runner4 As String
    Public Shared streamLinkParams_Runner4 As String
    Public Shared runnerNameSource_Runner4 As String
    Public Shared trackerSource_Runner4 As String

    Public Shared Sub RefreshConfigList()
        If Directory.Exists(ConfigFilePath) = False Then
            Directory.CreateDirectory(ConfigFilePath)
        End If

        If _configList.Tables.Count = 0 Then
            _configList.Tables.Add("ConfigFiles")
            _configList.Tables("ConfigFiles").Columns.Add("ConfigName")
            _configList.Tables("ConfigFiles").Columns.Add("ConfigPath")
        Else
            _configList.Tables("ConfigFiles").Clear()
        End If

        Dim dr As DataRow

        dr = _configList.Tables("ConfigFiles").NewRow

        dr.Item("ConfigName") = "Default"
        dr.Item("ConfigPath") = "Default"

        _configList.Tables("ConfigFiles").Rows.Add(dr)

        For Each strItem In Directory.GetFiles(ConfigFilePath)
            If strItem.EndsWith(".xml") Then
                Dim FName As String = strItem.Remove(0, strItem.LastIndexOf("\") + 1)

                dr = _configList.Tables("ConfigFiles").NewRow

                dr.Item("ConfigName") = FName
                dr.Item("ConfigPath") = strItem

                _configList.Tables("ConfigFiles").Rows.Add(dr)
            End If
        Next
    End Sub
    Public Shared Function GetGameSource(runnerNumber As Integer) As String
        Select Case runnerNumber
            Case 1
                Return gameSource_Runner1
            Case 2

                Return gameSource_Runner2
            Case 3
                Return gameSource_Runner3
            Case 4
                Return gameSource_Runner4
        End Select

        Return ""
    End Function
    Public Shared Function GetTimerSource(runnerNumber As Integer) As String
        Select Case runnerNumber
            Case 1
                Return timerSource_Runner1
            Case 2
                Return timerSource_Runner2
            Case 3
                Return timerSource_Runner3
            Case 4
                Return timerSource_Runner4
        End Select

        Return ""
    End Function
    Public Shared Function GetNameSource(runnerNumber As Integer) As String
        Select Case runnerNumber
            Case 1
                Return runnerNameSource_Runner1
            Case 2
                Return runnerNameSource_Runner2
            Case 3
                Return runnerNameSource_Runner3
            Case 4
                Return runnerNameSource_Runner4
        End Select

        Return ""
    End Function
    Public Shared Function GetTrackerSource(runnerNumber As Integer) As String
        Select Case runnerNumber
            Case 1
                Return trackerSource_Runner1
            Case 2
                Return trackerSource_Runner2
            Case 3
                Return trackerSource_Runner3
            Case 4
                Return trackerSource_Runner4
        End Select

        Return ""
    End Function

End Class
