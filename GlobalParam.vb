Imports System.IO

Public Class GlobalParam
    Public Shared _configList As New DataSet
    Public Shared ConfigFilePath As String = "C:\ALTTPRFiles\"

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
End Class
