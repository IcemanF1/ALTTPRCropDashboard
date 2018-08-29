Imports ALTTPRCropDashboard.Data.ViewModels
Imports ALTTPRCropDashboard.DB
Imports System.IO
Imports OBSWebsocketDotNet
Imports System.Globalization
Imports System.Configuration

Public Class RunnerControls
    Private _vlcList As New DataSet


#Region " Button Clicks "
    'Private Sub btnGameUncrop_Click(sender As Object, e As EventArgs) Handles btnGameUncrop.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.UncropSource(CInt(lblRunnerNumber.Text), False)
    '    End If
    'End Sub
    'Private Sub btnGameDB_Click(sender As Object, e As EventArgs) Handles btnGameDB.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.ClearTextBoxes("Game", CInt(lblRunnerNumber.Text))
    '        ObsWebSocketCropper.RefreshCropFromData("Game", CInt(lblRunnerNumber.Text), cbRunnerName.Text)
    '    End If
    'End Sub
    'Private Sub btnSaveCrop_Click(sender As Object, e As EventArgs) Handles btnSaveCrop.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.SaveRunnerCrop(CInt(lblRunnerNumber.Text))
    '    End If
    'End Sub
    'Private Sub btnSetCrop_Click(sender As Object, e As EventArgs) Handles btnSetCrop.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.SetCrop(CInt(lblRunnerNumber.Text))
    '    End If
    'End Sub
    'Private Sub btnGetCrop_Click(sender As Object, e As EventArgs) Handles btnGetCrop.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.GetCrop(CInt(lblRunnerNumber.Text))
    '    End If

    'End Sub
    'Private Sub btnNewRunner_Click(sender As Object, e As EventArgs) Handles btnNewRunner.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.AddNewRunner(CInt(lblRunnerNumber.Text), cbRunnerName, lblRunnerTwitch)
    '    End If
    'End Sub
    'Private Sub btnTimerDB_Click(sender As Object, e As EventArgs) Handles btnTimerDB.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.ClearTextBoxes("Timer", CInt(lblRunnerNumber.Text))
    '        ObsWebSocketCropper.RefreshCropFromData("Timer", CInt(lblRunnerNumber.Text), cbRunnerName.Text)
    '    End If
    'End Sub
    'Private Sub btnTimerUncrop_Click(sender As Object, e As EventArgs) Handles btnTimerUncrop.Click
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.UncropSource(CInt(lblRunnerNumber.Text), True)
    '    End If
    'End Sub
    'Private Sub btnSetVLC_Click(sender As Object, e As EventArgs) Handles btnSetVLC.Click
    '    SetVlcWindows()
    'End Sub
#End Region
    '#Region " Runner Drop Downs "

    '#End Region
    '#Region " Label Clicks "
    '    Private Sub lblViewOnTwitch_Click(sender As Object, e As EventArgs) Handles lblViewOnTwitch.Click
    '        If isRunnerNumValid() Then
    '            ObsWebSocketCropper.OpenTwitch(CInt(lblRunnerNumber.Text), False)
    '        End If
    '    End Sub
    '    Private Sub lblStreamlink_Click(sender As Object, e As EventArgs) Handles lblStreamlink.Click
    '        If isRunnerNumValid() Then
    '            ObsWebSocketCropper.StartStreamLink(CInt(lblRunnerNumber.Text))
    '        End If
    '    End Sub
    '    Private Sub lblVOD_Click(sender As Object, e As EventArgs) Handles lblVOD.Click
    '        If isRunnerNumValid() Then
    '            ObsWebSocketCropper.OpenTwitch(CInt(lblRunnerNumber.Text), True)
    '        End If
    '    End Sub

    '#End Region
#Region " Misc Functions "
    Private Sub RunnerControls_Load(sender As Object, e As EventArgs) Handles Me.Load
        CreateNewSourceTable()
        ConfigureDataBindings()
    End Sub
    Public Sub RefreshRunnerNames()
        Dim tempRunner As String = cbRunnerName.Text

        ObsWebSocketCropper.ReuseInfo = False

        Using context As New CropDbContext
            Dim validNames = context.Crops.OrderBy(Function(r) r.Runner).Select(Function(r) New With {.RacerName = r.RunnerName}).Distinct().ToList().OrderBy(Function(r) r.RacerName, StringComparer.CurrentCultureIgnoreCase).ToList()
            cbRunnerName.DataSource = validNames
        End Using

        cbRunnerName.Text = tempRunner

        ObsWebSocketCropper.ReuseInfo = True

    End Sub
    Private Sub RegisterExpertModeFeatures(ParamArray features() As Control)
        For Each control In features
            control.DataBindings.Add("Visible", My.Settings, NameOf(My.Settings.ExpertMode), False, DataSourceUpdateMode.OnPropertyChanged)
        Next
    End Sub
    Public Sub ConfigureDataBindings()
        RegisterExpertModeFeatures(lblViewOnTwitch, lblVOD, lblStreamlink)
        RegisterExpertModeFeatures(btnTimerDB, btnGameDB)
        RegisterExpertModeFeatures(lblScaling, cbScaling)
    End Sub
    'Private Sub SetVlcWindows()
    '    If isRunnerNumValid() Then
    '        ObsWebSocketCropper.SetVlcWindows(CInt(lblRunnerNumber.Text), cbVLCSource.Text)
    '    End If
    'End Sub
    Public Sub RefreshVlc()
        Dim vlcProcesses = Process.GetProcesses().Where(Function(pr) pr.ProcessName.StartsWith("vlc", True, Globalization.CultureInfo.InvariantCulture)).ToList()
        If Not vlcProcesses.Any() Then
            Exit Sub
        End If

        Dim Vlc As String


        If Not String.IsNullOrWhiteSpace(cbVLCSource.Text) Then
            Vlc = cbVLCSource.Text
        Else
            Vlc = ""
        End If

        _vlcList.Clear()

        Dim data = vlcProcesses.Select(Function(v) New With {.VLCName = v.MainWindowTitle}).ToList()

        cbVLCSource.DataSource = data.ToList()
        cbVLCSource.DisplayMember = "VLCName"
        cbVLCSource.ValueMember = "VLCName"

        cbVLCSource.Text = ""


        If Not String.IsNullOrWhiteSpace(lblRunnerTwitch.Text) Then
            Dim tempText = lblRunnerTwitch.Text.Remove(0, 8)
            Dim match = data.FirstOrDefault(Function(d) d.VLCName.StartsWith(tempText, True, CultureInfo.InvariantCulture))

            If match IsNot Nothing Then
                cbVLCSource.Text = match.VLCName
            End If
        End If

    End Sub
    Private Sub CreateNewSourceTable()
        If _vlcList.Tables.Count = 0 Then
            _vlcList.Tables.Add("Processes")
            _vlcList.Tables("Processes").Columns.Add("VLCName")
        Else
            _vlcList.Tables("Processes").Clear()
        End If
    End Sub
    Private Sub ValidateKeyPress(sender As Object, e As KeyPressEventArgs) _
    Handles txtCropTimer_Top.KeyPress, txtCropTimer_Right.KeyPress,
                txtCropTimer_Left.KeyPress, txtCropTimer_Bottom.KeyPress,
                txtCropGame_Top.KeyPress, txtCropGame_Right.KeyPress,
                txtCropGame_Left.KeyPress, txtCropGame_Bottom.KeyPress

        e.Handled = ObsWebSocketCropper.CheckIfKeyAllowed(e.KeyChar)
    End Sub

    Function isRunnerNumValid() As Boolean
        If Not String.IsNullOrWhiteSpace(lblRunnerNumber.Text) Then
            If IsNumeric(lblRunnerNumber.Text) Then
                If CInt(lblRunnerNumber.Text) > 0 Then
                    Return True
                End If
            End If
        End If

        Return False
    End Function

    Public Property twitchName As String
        Get
            Return lblRunnerTwitch.Text
        End Get
        Set(value As String)
            lblRunnerTwitch.Text = value
        End Set
    End Property
    Public Property runnerName As String
        Get
            Return cbRunnerName.Text
        End Get
        Set(value As String)
            cbRunnerName.Text = value
        End Set
    End Property

#End Region

End Class
