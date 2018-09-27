Public Class ConfigEditor
    Private _configInfo As New DataSet
    Private Const ApprovedChars As String = "0123456789"

    Private isLoaded As Boolean
    Private SavedConfigFileName As String

    Private Sub ValidateKeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtBoundingSizeHeightTimerTwoPlayer.KeyPress, txtBoundingSizeWidthTimerTwoPlayer.KeyPress,
                txtBoundingSizeHeightGameTwoPlayer.KeyPress, txtBoundingSizeWidthGameTwoPlayer.KeyPress,
                txtPositionXTimerTwoPlayer_Runner2.KeyPress, txtPositionYTimerTwoPlayer_Runner2.KeyPress,
                txtPositionXTimerTwoPlayer_Runner1.KeyPress, txtPositionYTimerTwoPlayer_Runner1.KeyPress,
                txtPositionXGameTwoPlayer_Runner2.KeyPress, txtPositionYGameTwoPlayer_Runner2.KeyPress,
                txtPositionXGameTwoPlayer_Runner1.KeyPress, txtPositionYGameTwoPlayer_Runner1.KeyPress,
                txtBoundingSizeHeightTimerFourPlayer.KeyPress, txtBoundingSizeWidthTimerFourPlayer.KeyPress,
                txtBoundingSizeHeightGameFourPlayer.KeyPress, txtBoundingSizeWidthGameFourPlayer.KeyPress,
                txtPositionXTimerFourPlayer_Runner1.KeyPress, txtPositionYTimerFourPlayer_Runner1.KeyPress,
                txtPositionXTimerFourPlayer_Runner2.KeyPress, txtPositionYTimerFourPlayer_Runner2.KeyPress,
                txtPositionXTimerFourPlayer_Runner3.KeyPress, txtPositionYTimerFourPlayer_Runner3.KeyPress,
                txtPositionXTimerFourPlayer_Runner4.KeyPress, txtPositionYTimerFourPlayer_Runner4.KeyPress,
                txtPositionXGameFourPlayer_Runner1.KeyPress, txtPositionYGameFourPlayer_Runner1.KeyPress,
                txtPositionXGameFourPlayer_Runner2.KeyPress, txtPositionYGameFourPlayer_Runner2.KeyPress,
                txtPositionXGameFourPlayer_Runner3.KeyPress, txtPositionYGameFourPlayer_Runner3.KeyPress,
                txtPositionXGameFourPlayer_Runner4.KeyPress, txtPositionYGameFourPlayer_Runner4.KeyPress

        e.Handled = CheckIfKeyAllowed(e.KeyChar)
    End Sub
    Private Sub ConfigEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        isLoaded = False

        GlobalParam.RefreshConfigList()

        cbConfigFiles.DataSource = GlobalParam._configList.Tables(0)

        cbConfigFiles.DisplayMember = "ConfigName"
        cbConfigFiles.ValueMember = "ConfigPath"

        cbConfigFiles.Text = "Default"

        isLoaded = True
    End Sub
    Public Shared Function CheckIfKeyAllowed(keyChar As String) As Boolean
        Return Not ApprovedChars.Contains(keyChar) AndAlso keyChar <> vbBack
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        CheckWhichConfig(True)

        GlobalParam.RefreshConfigList()

        cbConfigFiles.DataSource = GlobalParam._configList.Tables(0)

        cbConfigFiles.DisplayMember = "ConfigName"
        cbConfigFiles.ValueMember = "ConfigPath"
    End Sub
    Private Sub CheckWhichConfig(isSave As Boolean)
        If isSave Then
            Dim msgResult As MsgBoxResult = MsgBox("Is this a new config?", MsgBoxStyle.YesNoCancel, ObsWebSocketCropper.ProgramName)

            If Not String.IsNullOrWhiteSpace(cbConfigFiles.Text) Then
                If cbConfigFiles.Text.Trim.ToLower = "default" Then
                    SaveConfigInfo(True, msgResult)
                Else
                    SaveConfigInfo(False, msgResult)
                End If
            Else
                SaveConfigInfo(True, msgResult)
            End If
        Else
            If Not String.IsNullOrWhiteSpace(cbConfigFiles.Text) Then
                If cbConfigFiles.Text.Trim.ToLower = "default" Then
                    RefreshConfigInfo(True)
                Else
                    RefreshConfigInfo(False)
                End If
            Else
                RefreshConfigInfo(True)
            End If
        End If

    End Sub
    Private Sub SaveToDefault()
        My.Settings.PositionYGameFourPlayer_Runner1 = CInt(txtPositionYGameFourPlayer_Runner1.Text)
        My.Settings.PositionXGameFourPlayer_Runner1 = CInt(txtPositionXGameFourPlayer_Runner1.Text)

        My.Settings.PositionYGameFourPlayer_Runner2 = CInt(txtPositionYGameFourPlayer_Runner2.Text)
        My.Settings.PositionXGameFourPlayer_Runner2 = CInt(txtPositionXGameFourPlayer_Runner2.Text)

        My.Settings.PositionYGameFourPlayer_Runner3 = CInt(txtPositionYGameFourPlayer_Runner3.Text)
        My.Settings.PositionXGameFourPlayer_Runner3 = CInt(txtPositionXGameFourPlayer_Runner3.Text)

        My.Settings.PositionYGameFourPlayer_Runner4 = CInt(txtPositionYGameFourPlayer_Runner4.Text)
        My.Settings.PositionXGameFourPlayer_Runner4 = CInt(txtPositionXGameFourPlayer_Runner4.Text)

        My.Settings.BoundingSizeHeightGameFourPlayer = CInt(txtBoundingSizeHeightGameFourPlayer.Text)
        My.Settings.BoundingSizeWidthGameFourPlayer = CInt(txtBoundingSizeWidthGameFourPlayer.Text)

        My.Settings.BoundingSizeHeightTimerFourPlayer = CInt(txtBoundingSizeHeightTimerFourPlayer.Text)
        My.Settings.BoundingSizeWidthTimerFourPlayer = CInt(txtBoundingSizeWidthTimerFourPlayer.Text)


        My.Settings.PositionYTimerFourPlayer_Runner1 = CInt(txtPositionYTimerFourPlayer_Runner1.Text)
        My.Settings.PositionXTimerFourPlayer_Runner1 = CInt(txtPositionXTimerFourPlayer_Runner1.Text)

        My.Settings.PositionYTimerFourPlayer_Runner2 = CInt(txtPositionYTimerFourPlayer_Runner2.Text)
        My.Settings.PositionXTimerFourPlayer_Runner2 = CInt(txtPositionXTimerFourPlayer_Runner2.Text)

        My.Settings.PositionYTimerFourPlayer_Runner3 = CInt(txtPositionYTimerFourPlayer_Runner3.Text)
        My.Settings.PositionXTimerFourPlayer_Runner3 = CInt(txtPositionXTimerFourPlayer_Runner3.Text)

        My.Settings.PositionYTimerFourPlayer_Runner4 = CInt(txtPositionYTimerFourPlayer_Runner4.Text)
        My.Settings.PositionXTimerFourPlayer_Runner4 = CInt(txtPositionXTimerFourPlayer_Runner4.Text)

        My.Settings.PositionYTimerTwoPlayer_Runner1 = CInt(txtPositionYTimerTwoPlayer_Runner1.Text)
        My.Settings.PositionXTimerTwoPlayer_Runner1 = CInt(txtPositionXTimerTwoPlayer_Runner1.Text)

        My.Settings.PositionYTimerTwoPlayer_Runner2 = CInt(txtPositionYTimerTwoPlayer_Runner2.Text)
        My.Settings.PositionXTimerTwoPlayer_Runner2 = CInt(txtPositionXTimerTwoPlayer_Runner2.Text)

        My.Settings.PositionYGameTwoPlayer_Runner1 = CInt(txtPositionYGameTwoPlayer_Runner1.Text)
        My.Settings.PositionXGameTwoPlayer_Runner1 = CInt(txtPositionXGameTwoPlayer_Runner1.Text)

        My.Settings.PositionYGameTwoPlayer_Runner2 = CInt(txtPositionYGameTwoPlayer_Runner2.Text)
        My.Settings.PositionXGameTwoPlayer_Runner2 = CInt(txtPositionXGameTwoPlayer_Runner2.Text)


        My.Settings.BoundingSizeHeightGameTwoPlayer = CInt(txtBoundingSizeHeightGameTwoPlayer.Text)
        My.Settings.BoundingSizeWidthGameTwoPlayer = CInt(txtBoundingSizeWidthGameTwoPlayer.Text)

        My.Settings.BoundingSizeHeightTimerTwoPlayer = CInt(txtBoundingSizeHeightTimerTwoPlayer.Text)
        My.Settings.BoundingSizeWidthTimerTwoPlayer = CInt(txtBoundingSizeWidthTimerTwoPlayer.Text)

        My.Settings.Save()
    End Sub
    Private Sub SaveToFile(FileName As String)
        LoadNewConfigInfoTable()

        Dim dr As DataRow

        dr = _configInfo.Tables("ConfigInfo").NewRow

        dr.Item("PositionYGameFourPlayer_Runner1") = txtPositionYGameFourPlayer_Runner1.Text
        dr.Item("PositionXGameFourPlayer_Runner1") = txtPositionXGameFourPlayer_Runner1.Text

        dr.Item("PositionYGameFourPlayer_Runner2") = txtPositionYGameFourPlayer_Runner2.Text
        dr.Item("PositionXGameFourPlayer_Runner2") = txtPositionXGameFourPlayer_Runner2.Text

        dr.Item("PositionYGameFourPlayer_Runner3") = txtPositionYGameFourPlayer_Runner3.Text
        dr.Item("PositionXGameFourPlayer_Runner3") = txtPositionXGameFourPlayer_Runner3.Text

        dr.Item("PositionYGameFourPlayer_Runner4") = txtPositionYGameFourPlayer_Runner4.Text
        dr.Item("PositionXGameFourPlayer_Runner4") = txtPositionXGameFourPlayer_Runner4.Text

        dr.Item("PositionYTimerFourPlayer_Runner1") = txtPositionYTimerFourPlayer_Runner1.Text
        dr.Item("PositionXTimerFourPlayer_Runner1") = txtPositionXTimerFourPlayer_Runner1.Text

        dr.Item("PositionYTimerFourPlayer_Runner2") = txtPositionYTimerFourPlayer_Runner2.Text
        dr.Item("PositionXTimerFourPlayer_Runner2") = txtPositionXTimerFourPlayer_Runner2.Text

        dr.Item("PositionYTimerFourPlayer_Runner3") = txtPositionYTimerFourPlayer_Runner3.Text
        dr.Item("PositionXTimerFourPlayer_Runner3") = txtPositionXTimerFourPlayer_Runner3.Text

        dr.Item("PositionYTimerFourPlayer_Runner4") = txtPositionYTimerFourPlayer_Runner4.Text
        dr.Item("PositionXTimerFourPlayer_Runner4") = txtPositionXTimerFourPlayer_Runner4.Text

        dr.Item("BoundingSizeHeightGameFourPlayer") = txtBoundingSizeHeightGameFourPlayer.Text
        dr.Item("BoundingSizeWidthGameFourPlayer") = txtBoundingSizeWidthGameFourPlayer.Text

        dr.Item("BoundingSizeHeightTimerFourPlayer") = txtBoundingSizeHeightTimerFourPlayer.Text
        dr.Item("BoundingSizeWidthTimerFourPlayer") = txtBoundingSizeWidthTimerFourPlayer.Text


        dr.Item("PositionYTimerTwoPlayer_Runner1") = txtPositionYTimerTwoPlayer_Runner1.Text
        dr.Item("PositionXTimerTwoPlayer_Runner1") = txtPositionXTimerTwoPlayer_Runner1.Text

        dr.Item("PositionYTimerTwoPlayer_Runner2") = txtPositionYTimerTwoPlayer_Runner2.Text
        dr.Item("PositionXTimerTwoPlayer_Runner2") = txtPositionXTimerTwoPlayer_Runner2.Text

        dr.Item("PositionYGameTwoPlayer_Runner1") = txtPositionYGameTwoPlayer_Runner1.Text
        dr.Item("PositionXGameTwoPlayer_Runner1") = txtPositionXGameTwoPlayer_Runner1.Text

        dr.Item("PositionYGameTwoPlayer_Runner2") = txtPositionYGameTwoPlayer_Runner2.Text
        dr.Item("PositionXGameTwoPlayer_Runner2") = txtPositionXGameTwoPlayer_Runner2.Text

        dr.Item("BoundingSizeHeightGameTwoPlayer") = txtBoundingSizeHeightGameTwoPlayer.Text
        dr.Item("BoundingSizeWidthGameTwoPlayer") = txtBoundingSizeWidthGameTwoPlayer.Text

        dr.Item("BoundingSizeHeightTimerTwoPlayer") = txtBoundingSizeHeightTimerTwoPlayer.Text
        dr.Item("BoundingSizeWidthTimerTwoPlayer") = txtBoundingSizeWidthTimerTwoPlayer.Text

        _configInfo.Tables("ConfigInfo").Rows.Add(dr)

        _configInfo.WriteXml(FileName, XmlWriteMode.WriteSchema)
    End Sub
    Private Sub SaveConfigInfo(isDefault As Boolean, msgResult As MsgBoxResult)

        If msgResult = MsgBoxResult.Yes Then
            With sfdSaveConfig
                .Reset()
                .FileName = ""
                .DefaultExt = ".xml"
                .Filter = "XML Files|*.xml"
                .RestoreDirectory = True
                .InitialDirectory = GlobalParam.ConfigFilePath

                Select Case .ShowDialog
                    Case DialogResult.OK
                        SaveToFile(.FileName)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End With
        ElseIf msgResult = MsgBoxResult.No Then
            If isDefault Then
                SaveToDefault()
            Else
                SaveToFile(cbConfigFiles.SelectedValue.ToString)
            End If
        End If

    End Sub
    Private Sub RefreshConfigInfo(isDefault As Boolean)
        If isDefault Then
            txtPositionYGameFourPlayer_Runner3.Text = My.Settings.PositionYGameFourPlayer_Runner3.ToString
            txtPositionXGameFourPlayer_Runner3.Text = My.Settings.PositionXGameFourPlayer_Runner3.ToString

            txtPositionYGameFourPlayer_Runner1.Text = My.Settings.PositionYGameFourPlayer_Runner1.ToString
            txtPositionXGameFourPlayer_Runner1.Text = My.Settings.PositionXGameFourPlayer_Runner1.ToString

            txtPositionYGameFourPlayer_Runner4.Text = My.Settings.PositionYGameFourPlayer_Runner4.ToString
            txtPositionXGameFourPlayer_Runner4.Text = My.Settings.PositionXGameFourPlayer_Runner4.ToString

            txtPositionYGameFourPlayer_Runner2.Text = My.Settings.PositionYGameFourPlayer_Runner2.ToString
            txtPositionXGameFourPlayer_Runner2.Text = My.Settings.PositionXGameFourPlayer_Runner2.ToString

            txtPositionYTimerFourPlayer_Runner3.Text = My.Settings.PositionYTimerFourPlayer_Runner3.ToString
            txtPositionXTimerFourPlayer_Runner3.Text = My.Settings.PositionXTimerFourPlayer_Runner3.ToString

            txtPositionYTimerFourPlayer_Runner1.Text = My.Settings.PositionYTimerFourPlayer_Runner1.ToString
            txtPositionXTimerFourPlayer_Runner1.Text = My.Settings.PositionXTimerFourPlayer_Runner1.ToString

            txtPositionYTimerFourPlayer_Runner4.Text = My.Settings.PositionYTimerFourPlayer_Runner4.ToString
            txtPositionXTimerFourPlayer_Runner4.Text = My.Settings.PositionXTimerFourPlayer_Runner4.ToString

            txtPositionYTimerFourPlayer_Runner2.Text = My.Settings.PositionYTimerFourPlayer_Runner2.ToString
            txtPositionXTimerFourPlayer_Runner2.Text = My.Settings.PositionXTimerFourPlayer_Runner2.ToString

            txtPositionYTimerTwoPlayer_Runner2.Text = My.Settings.PositionYTimerTwoPlayer_Runner2.ToString
            txtPositionXTimerTwoPlayer_Runner2.Text = My.Settings.PositionXTimerTwoPlayer_Runner2.ToString

            txtPositionYTimerTwoPlayer_Runner1.Text = My.Settings.PositionYTimerTwoPlayer_Runner1.ToString
            txtPositionXTimerTwoPlayer_Runner1.Text = My.Settings.PositionXTimerTwoPlayer_Runner1.ToString

            txtPositionYGameTwoPlayer_Runner2.Text = My.Settings.PositionYGameTwoPlayer_Runner2.ToString
            txtPositionXGameTwoPlayer_Runner2.Text = My.Settings.PositionXGameTwoPlayer_Runner2.ToString

            txtPositionYGameTwoPlayer_Runner1.Text = My.Settings.PositionYGameTwoPlayer_Runner1.ToString
            txtPositionXGameTwoPlayer_Runner1.Text = My.Settings.PositionXGameTwoPlayer_Runner1.ToString

            txtBoundingSizeHeightGameFourPlayer.Text = My.Settings.BoundingSizeHeightGameFourPlayer.ToString
            txtBoundingSizeWidthGameFourPlayer.Text = My.Settings.BoundingSizeWidthGameFourPlayer.ToString

            txtBoundingSizeHeightTimerFourPlayer.Text = My.Settings.BoundingSizeHeightTimerFourPlayer.ToString
            txtBoundingSizeWidthTimerFourPlayer.Text = My.Settings.BoundingSizeWidthTimerFourPlayer.ToString

            txtBoundingSizeHeightGameTwoPlayer.Text = My.Settings.BoundingSizeHeightGameTwoPlayer.ToString
            txtBoundingSizeWidthGameTwoPlayer.Text = My.Settings.BoundingSizeWidthGameTwoPlayer.ToString

            txtBoundingSizeHeightTimerTwoPlayer.Text = My.Settings.BoundingSizeHeightTimerTwoPlayer.ToString
            txtBoundingSizeWidthTimerTwoPlayer.Text = My.Settings.BoundingSizeWidthTimerTwoPlayer.ToString
        Else
            If isLoaded = True Then
                _configInfo.ReadXml(cbConfigFiles.SelectedValue.ToString)

                If _configInfo.Tables.Count > 0 Then
                    If _configInfo.Tables("ConfigInfo").Rows.Count > 0 Then
                        txtPositionYGameFourPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameFourPlayer_Runner1").ToString
                        txtPositionXGameFourPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameFourPlayer_Runner1").ToString

                        txtPositionYGameFourPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameFourPlayer_Runner2").ToString
                        txtPositionXGameFourPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameFourPlayer_Runner2").ToString

                        txtPositionYGameFourPlayer_Runner3.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameFourPlayer_Runner3").ToString
                        txtPositionXGameFourPlayer_Runner3.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameFourPlayer_Runner3").ToString

                        txtPositionYGameFourPlayer_Runner4.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameFourPlayer_Runner4").ToString
                        txtPositionXGameFourPlayer_Runner4.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameFourPlayer_Runner4").ToString

                        txtPositionYTimerFourPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerFourPlayer_Runner1").ToString
                        txtPositionXTimerFourPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerFourPlayer_Runner1").ToString

                        txtPositionYTimerFourPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerFourPlayer_Runner2").ToString
                        txtPositionXTimerFourPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerFourPlayer_Runner2").ToString

                        txtPositionYTimerFourPlayer_Runner3.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerFourPlayer_Runner3").ToString
                        txtPositionXTimerFourPlayer_Runner3.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerFourPlayer_Runner3").ToString

                        txtPositionYTimerFourPlayer_Runner4.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerFourPlayer_Runner4").ToString
                        txtPositionXTimerFourPlayer_Runner4.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerFourPlayer_Runner4").ToString

                        txtBoundingSizeHeightGameFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameFourPlayer").ToString
                        txtBoundingSizeWidthGameFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameFourPlayer").ToString

                        txtBoundingSizeHeightTimerFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerFourPlayer").ToString
                        txtBoundingSizeWidthTimerFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerFourPlayer").ToString

                        txtPositionYTimerTwoPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTwoPlayer_Runner1").ToString
                        txtPositionXTimerTwoPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTwoPlayer_Runner1").ToString

                        txtPositionYTimerTwoPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTwoPlayer_Runner2").ToString
                        txtPositionXTimerTwoPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTwoPlayer_Runner2").ToString

                        txtPositionYGameTwoPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTwoPlayer_Runner1").ToString
                        txtPositionXGameTwoPlayer_Runner1.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTwoPlayer_Runner1").ToString

                        txtPositionYGameTwoPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTwoPlayer_Runner2").ToString
                        txtPositionXGameTwoPlayer_Runner2.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTwoPlayer_Runner2").ToString

                        txtBoundingSizeHeightGameTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameTwoPlayer").ToString
                        txtBoundingSizeWidthGameTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameTwoPlayer").ToString

                        txtBoundingSizeHeightTimerTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerTwoPlayer").ToString
                        txtBoundingSizeWidthTimerTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerTwoPlayer").ToString
                    End If
                End If
            End If



        End If
    End Sub
    Private Sub LoadNewConfigInfoTable()
        If _configInfo.Tables.Count = 0 Then
            _configInfo.Tables.Add("ConfigInfo")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameFourPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameFourPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameFourPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameFourPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameFourPlayer_Runner3")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameFourPlayer_Runner3")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameFourPlayer_Runner4")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameFourPlayer_Runner4")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerFourPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerFourPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerFourPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerFourPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerFourPlayer_Runner3")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerFourPlayer_Runner3")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerFourPlayer_Runner4")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerFourPlayer_Runner4")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightGameFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthGameFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightTimerFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthTimerFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerTwoPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerTwoPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerTwoPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerTwoPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameTwoPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameTwoPlayer_Runner1")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameTwoPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameTwoPlayer_Runner2")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightGameTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthGameTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightTimerTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthTimerTwoPlayer")
        Else
            _configInfo.Tables("ConfigInfo").Clear()
        End If
    End Sub
    Private Sub cbConfigFiles_KeyUp(sender As Object, e As KeyEventArgs) Handles cbConfigFiles.KeyUp
        Dim index As Integer
        Dim actual As String
        Dim found As String

        If ((e.KeyCode = Keys.Back) Or
    (e.KeyCode = Keys.Left) Or
    (e.KeyCode = Keys.Right) Or
    (e.KeyCode = Keys.Up) Or
    (e.KeyCode = Keys.Delete) Or
    (e.KeyCode = Keys.Down) Or
    (e.KeyCode = Keys.PageUp) Or
    (e.KeyCode = Keys.PageDown) Or
    (e.KeyCode = Keys.Home) Or
    (e.KeyCode = Keys.End)) Then

            Return
        End If

        ' Store the actual text that has been typed.
        actual = cbConfigFiles.Text

        ' Find the first match for the typed value.
        index = cbConfigFiles.FindString(actual)

        ' Get the text of the first match.
        If (index > -1) Then
            found = cbConfigFiles.Items(index).ToString()

            ' Select this item from the list.
            cbConfigFiles.SelectedIndex = index

            ' Select the portion of the text that was automatically
            ' added so that additional typing will replace it.
            cbConfigFiles.SelectionStart = actual.Length
            cbConfigFiles.SelectionLength = found.Length
        End If
    End Sub
    Private Sub cbConfigFiles_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbConfigFiles.SelectedValueChanged
        CheckWhichConfig(False)
    End Sub
End Class