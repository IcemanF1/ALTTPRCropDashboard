Public Class ConfigEditor
    Private _configInfo As New DataSet
    Private Const ApprovedChars As String = "0123456789"

    Private isLoaded As Boolean
    Private SavedConfigFileName As String

    Private Sub ValidateKeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles txtBoundingSizeHeightTimerTwoPlayer.KeyPress, txtBoundingSizeWidthTimerTwoPlayer.KeyPress,
                txtBoundingSizeHeightGameTwoPlayer.KeyPress, txtBoundingSizeWidthGameTwoPlayer.KeyPress,
                txtPositionXTimerRightTwoPlayer.KeyPress, txtPositionYTimerRightTwoPlayer.KeyPress,
                txtPositionXTimerLeftTwoPlayer.KeyPress, txtPositionYTimerLeftTwoPlayer.KeyPress,
                txtPositionXGameRightTwoPlayer.KeyPress, txtPositionYGameRightTwoPlayer.KeyPress,
                txtPositionXGameLeftTwoPlayer.KeyPress, txtPositionYGameLeftTwoPlayer.KeyPress,
                txtBoundingSizeHeightTimerFourPlayer.KeyPress, txtBoundingSizeWidthTimerFourPlayer.KeyPress,
                txtBoundingSizeHeightGameFourPlayer.KeyPress, txtBoundingSizeWidthGameFourPlayer.KeyPress,
                txtPositionXTimerTopLeftFourPlayer.KeyPress, txtPositionYTimerTopLeftFourPlayer.KeyPress,
                txtPositionXTimerTopRightFourPlayer.KeyPress, txtPositionYTimerTopRightFourPlayer.KeyPress,
                txtPositionXTimerBottomLeftFourPlayer.KeyPress, txtPositionYTimerBottomLeftFourPlayer.KeyPress,
                txtPositionXTimerBottomRightFourPlayer.KeyPress, txtPositionYTimerBottomRightFourPlayer.KeyPress,
                txtPositionXGameTopLeftFourPlayer.KeyPress, txtPositionYGameTopLeftFourPlayer.KeyPress,
                txtPositionXGameTopRightFourPlayer.KeyPress, txtPositionYGameTopRightFourPlayer.KeyPress,
                txtPositionXGameBottomLeftFourPlayer.KeyPress, txtPositionYGameBottomLeftFourPlayer.KeyPress,
                txtPositionXGameBottomRightFourPlayer.KeyPress, txtPositionYGameBottomRightFourPlayer.KeyPress

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
        My.Settings.PositionYGameBottomLeftFourPlayer = CInt(txtPositionYGameBottomLeftFourPlayer.Text)
        My.Settings.PositionXGameBottomLeftFourPlayer = CInt(txtPositionXGameBottomLeftFourPlayer.Text)

        My.Settings.PositionYGameTopLeftFourPlayer = CInt(txtPositionYGameTopLeftFourPlayer.Text)
        My.Settings.PositionXGameTopLeftFourPlayer = CInt(txtPositionXGameTopLeftFourPlayer.Text)

        My.Settings.PositionYGameBottomRightFourPlayer = CInt(txtPositionYGameBottomRightFourPlayer.Text)
        My.Settings.PositionXGameBottomRightFourPlayer = CInt(txtPositionXGameBottomRightFourPlayer.Text)

        My.Settings.PositionYGameTopRightFourPlayer = CInt(txtPositionYGameTopRightFourPlayer.Text)
        My.Settings.PositionXGameTopRightFourPlayer = CInt(txtPositionXGameTopRightFourPlayer.Text)

        My.Settings.PositionYTimerBottomLeftFourPlayer = CInt(txtPositionYTimerBottomLeftFourPlayer.Text)
        My.Settings.PositionXTimerBottomLeftFourPlayer = CInt(txtPositionXTimerBottomLeftFourPlayer.Text)

        My.Settings.PositionYTimerTopLeftFourPlayer = CInt(txtPositionYTimerTopLeftFourPlayer.Text)
        My.Settings.PositionXTimerTopLeftFourPlayer = CInt(txtPositionXTimerTopLeftFourPlayer.Text)

        My.Settings.PositionYTimerBottomRightFourPlayer = CInt(txtPositionYTimerBottomRightFourPlayer.Text)
        My.Settings.PositionXTimerBottomRightFourPlayer = CInt(txtPositionXTimerBottomRightFourPlayer.Text)

        My.Settings.PositionYTimerTopRightFourPlayer = CInt(txtPositionYTimerTopRightFourPlayer.Text)
        My.Settings.PositionXTimerTopRightFourPlayer = CInt(txtPositionXTimerTopRightFourPlayer.Text)

        My.Settings.PositionYTimerRightTwoPlayer = CInt(txtPositionYTimerRightTwoPlayer.Text)
        My.Settings.PositionXTimerRightTwoPlayer = CInt(txtPositionXTimerRightTwoPlayer.Text)

        My.Settings.PositionYTimerLeftTwoPlayer = CInt(txtPositionYTimerLeftTwoPlayer.Text)
        My.Settings.PositionXTimerLeftTwoPlayer = CInt(txtPositionXTimerLeftTwoPlayer.Text)

        My.Settings.PositionYGameRightTwoPlayer = CInt(txtPositionYGameRightTwoPlayer.Text)
        My.Settings.PositionXGameRightTwoPlayer = CInt(txtPositionXGameRightTwoPlayer.Text)

        My.Settings.PositionYGameLeftTwoPlayer = CInt(txtPositionYGameLeftTwoPlayer.Text)
        My.Settings.PositionXGameLeftTwoPlayer = CInt(txtPositionXGameLeftTwoPlayer.Text)

        My.Settings.BoundingSizeHeightGameFourPlayer = CInt(txtBoundingSizeHeightGameFourPlayer.Text)
        My.Settings.BoundingSizeWidthGameFourPlayer = CInt(txtBoundingSizeWidthGameFourPlayer.Text)

        My.Settings.BoundingSizeHeightTimerFourPlayer = CInt(txtBoundingSizeHeightTimerFourPlayer.Text)
        My.Settings.BoundingSizeWidthTimerFourPlayer = CInt(txtBoundingSizeWidthTimerFourPlayer.Text)

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

        dr.Item("PositionYGameBottomLeftFourPlayer") = txtPositionYGameBottomLeftFourPlayer.Text
        dr.Item("PositionXGameBottomLeftFourPlayer") = txtPositionXGameBottomLeftFourPlayer.Text

        dr.Item("PositionYGameTopLeftFourPlayer") = txtPositionYGameTopLeftFourPlayer.Text
        dr.Item("PositionXGameTopLeftFourPlayer") = txtPositionXGameTopLeftFourPlayer.Text

        dr.Item("PositionYGameBottomRightFourPlayer") = txtPositionYGameBottomRightFourPlayer.Text
        dr.Item("PositionXGameBottomRightFourPlayer") = txtPositionXGameBottomRightFourPlayer.Text

        dr.Item("PositionYGameTopRightFourPlayer") = txtPositionYGameTopRightFourPlayer.Text
        dr.Item("PositionXGameTopRightFourPlayer") = txtPositionXGameTopRightFourPlayer.Text

        dr.Item("PositionYTimerBottomLeftFourPlayer") = txtPositionYTimerBottomLeftFourPlayer.Text
        dr.Item("PositionXTimerBottomLeftFourPlayer") = txtPositionXTimerBottomLeftFourPlayer.Text

        dr.Item("PositionYTimerTopLeftFourPlayer") = txtPositionYTimerTopLeftFourPlayer.Text
        dr.Item("PositionXTimerTopLeftFourPlayer") = txtPositionXTimerTopLeftFourPlayer.Text

        dr.Item("PositionYTimerBottomRightFourPlayer") = txtPositionYTimerBottomRightFourPlayer.Text
        dr.Item("PositionXTimerBottomRightFourPlayer") = txtPositionXTimerBottomRightFourPlayer.Text

        dr.Item("PositionYTimerTopRightFourPlayer") = txtPositionYTimerTopRightFourPlayer.Text
        dr.Item("PositionXTimerTopRightFourPlayer") = txtPositionXTimerTopRightFourPlayer.Text

        dr.Item("PositionYTimerRightTwoPlayer") = txtPositionYTimerRightTwoPlayer.Text
        dr.Item("PositionXTimerRightTwoPlayer") = txtPositionXTimerRightTwoPlayer.Text

        dr.Item("PositionYTimerLeftTwoPlayer") = txtPositionYTimerLeftTwoPlayer.Text
        dr.Item("PositionXTimerLeftTwoPlayer") = txtPositionXTimerLeftTwoPlayer.Text

        dr.Item("PositionYGameRightTwoPlayer") = txtPositionYGameRightTwoPlayer.Text
        dr.Item("PositionXGameRightTwoPlayer") = txtPositionXGameRightTwoPlayer.Text

        dr.Item("PositionYGameLeftTwoPlayer") = txtPositionYGameLeftTwoPlayer.Text
        dr.Item("PositionXGameLeftTwoPlayer") = txtPositionXGameLeftTwoPlayer.Text

        dr.Item("BoundingSizeHeightGameFourPlayer") = txtBoundingSizeHeightGameFourPlayer.Text
        dr.Item("BoundingSizeWidthGameFourPlayer") = txtBoundingSizeWidthGameFourPlayer.Text

        dr.Item("BoundingSizeHeightTimerFourPlayer") = txtBoundingSizeHeightTimerFourPlayer.Text
        dr.Item("BoundingSizeWidthTimerFourPlayer") = txtBoundingSizeWidthTimerFourPlayer.Text

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
            txtPositionYGameBottomLeftFourPlayer.Text = My.Settings.PositionYGameBottomLeftFourPlayer.ToString
            txtPositionXGameBottomLeftFourPlayer.Text = My.Settings.PositionXGameBottomLeftFourPlayer.ToString

            txtPositionYGameTopLeftFourPlayer.Text = My.Settings.PositionYGameTopLeftFourPlayer.ToString
            txtPositionXGameTopLeftFourPlayer.Text = My.Settings.PositionXGameTopLeftFourPlayer.ToString

            txtPositionYGameBottomRightFourPlayer.Text = My.Settings.PositionYGameBottomRightFourPlayer.ToString
            txtPositionXGameBottomRightFourPlayer.Text = My.Settings.PositionXGameBottomRightFourPlayer.ToString

            txtPositionYGameTopRightFourPlayer.Text = My.Settings.PositionYGameTopRightFourPlayer.ToString
            txtPositionXGameTopRightFourPlayer.Text = My.Settings.PositionXGameTopRightFourPlayer.ToString

            txtPositionYTimerBottomLeftFourPlayer.Text = My.Settings.PositionYTimerBottomLeftFourPlayer.ToString
            txtPositionXTimerBottomLeftFourPlayer.Text = My.Settings.PositionXTimerBottomLeftFourPlayer.ToString

            txtPositionYTimerTopLeftFourPlayer.Text = My.Settings.PositionYTimerTopLeftFourPlayer.ToString
            txtPositionXTimerTopLeftFourPlayer.Text = My.Settings.PositionXTimerTopLeftFourPlayer.ToString

            txtPositionYTimerBottomRightFourPlayer.Text = My.Settings.PositionYTimerBottomRightFourPlayer.ToString
            txtPositionXTimerBottomRightFourPlayer.Text = My.Settings.PositionXTimerBottomRightFourPlayer.ToString

            txtPositionYTimerTopRightFourPlayer.Text = My.Settings.PositionYTimerTopRightFourPlayer.ToString
            txtPositionXTimerTopRightFourPlayer.Text = My.Settings.PositionXTimerTopRightFourPlayer.ToString

            txtPositionYTimerRightTwoPlayer.Text = My.Settings.PositionYTimerRightTwoPlayer.ToString
            txtPositionXTimerRightTwoPlayer.Text = My.Settings.PositionXTimerRightTwoPlayer.ToString

            txtPositionYTimerLeftTwoPlayer.Text = My.Settings.PositionYTimerLeftTwoPlayer.ToString
            txtPositionXTimerLeftTwoPlayer.Text = My.Settings.PositionXTimerLeftTwoPlayer.ToString

            txtPositionYGameRightTwoPlayer.Text = My.Settings.PositionYGameRightTwoPlayer.ToString
            txtPositionXGameRightTwoPlayer.Text = My.Settings.PositionXGameRightTwoPlayer.ToString

            txtPositionYGameLeftTwoPlayer.Text = My.Settings.PositionYGameLeftTwoPlayer.ToString
            txtPositionXGameLeftTwoPlayer.Text = My.Settings.PositionXGameLeftTwoPlayer.ToString

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
                        txtPositionYGameBottomLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomLeftFourPlayer").ToString
                        txtPositionXGameBottomLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomLeftFourPlayer").ToString

                        txtPositionYGameTopLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopLeftFourPlayer").ToString
                        txtPositionXGameTopLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopLeftFourPlayer").ToString

                        txtPositionYGameBottomRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameBottomRightFourPlayer").ToString
                        txtPositionXGameBottomRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameBottomRightFourPlayer").ToString

                        txtPositionYGameTopRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameTopRightFourPlayer").ToString
                        txtPositionXGameTopRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameTopRightFourPlayer").ToString

                        txtPositionYTimerBottomLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomLeftFourPlayer").ToString
                        txtPositionXTimerBottomLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomLeftFourPlayer").ToString

                        txtPositionYTimerTopLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopLeftFourPlayer").ToString
                        txtPositionXTimerTopLeftFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopLeftFourPlayer").ToString

                        txtPositionYTimerBottomRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerBottomRightFourPlayer").ToString
                        txtPositionXTimerBottomRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerBottomRightFourPlayer").ToString

                        txtPositionYTimerTopRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerTopRightFourPlayer").ToString
                        txtPositionXTimerTopRightFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerTopRightFourPlayer").ToString

                        txtPositionYTimerRightTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerRightTwoPlayer").ToString
                        txtPositionXTimerRightTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerRightTwoPlayer").ToString

                        txtPositionYTimerLeftTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYTimerLeftTwoPlayer").ToString
                        txtPositionXTimerLeftTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXTimerLeftTwoPlayer").ToString

                        txtPositionYGameRightTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameRightTwoPlayer").ToString
                        txtPositionXGameRightTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameRightTwoPlayer").ToString

                        txtPositionYGameLeftTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionYGameLeftTwoPlayer").ToString
                        txtPositionXGameLeftTwoPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("PositionXGameLeftTwoPlayer").ToString

                        txtBoundingSizeHeightGameFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightGameFourPlayer").ToString
                        txtBoundingSizeWidthGameFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthGameFourPlayer").ToString

                        txtBoundingSizeHeightTimerFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeHeightTimerFourPlayer").ToString
                        txtBoundingSizeWidthTimerFourPlayer.Text = _configInfo.Tables("ConfigInfo").Rows(0)("BoundingSizeWidthTimerFourPlayer").ToString

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
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameBottomLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameBottomLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameTopLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameTopLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameBottomRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameBottomRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameTopRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameTopRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerBottomLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerBottomLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerTopLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerTopLeftFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerBottomRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerBottomRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerTopRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerTopRightFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerRightTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerRightTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYTimerLeftTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXTimerLeftTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameRightTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameRightTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionYGameLeftTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("PositionXGameLeftTwoPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightGameFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthGameFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeHeightTimerFourPlayer")
            _configInfo.Tables("ConfigInfo").Columns.Add("BoundingSizeWidthTimerFourPlayer")
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