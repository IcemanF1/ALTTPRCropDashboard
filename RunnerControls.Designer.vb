<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunnerControls
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblRunnerTwitch = New System.Windows.Forms.Label()
        Me.lblStreamlink = New System.Windows.Forms.Label()
        Me.lblVOD = New System.Windows.Forms.Label()
        Me.lblViewOnTwitch = New System.Windows.Forms.Label()
        Me.btnNewRunner = New System.Windows.Forms.Button()
        Me.btnSetVLC = New System.Windows.Forms.Button()
        Me.cbVLCSource = New System.Windows.Forms.ComboBox()
        Me.lblVLC = New System.Windows.Forms.Label()
        Me.btnSaveCrop = New System.Windows.Forms.Button()
        Me.btnGetCrop = New System.Windows.Forms.Button()
        Me.cbRunnerName = New System.Windows.Forms.ComboBox()
        Me.lblRunner = New System.Windows.Forms.Label()
        Me.btnSetCrop = New System.Windows.Forms.Button()
        Me.gbTimerWindow = New System.Windows.Forms.GroupBox()
        Me.btnTimerUncrop = New System.Windows.Forms.Button()
        Me.btnTimerDB = New System.Windows.Forms.Button()
        Me.cbScaling = New System.Windows.Forms.ComboBox()
        Me.lblScaling = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCropTimer_Top = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCropTimer_Left = New System.Windows.Forms.TextBox()
        Me.txtCropTimer_Bottom = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCropTimer_Right = New System.Windows.Forms.TextBox()
        Me.gbGameWindow = New System.Windows.Forms.GroupBox()
        Me.btnGameUncrop = New System.Windows.Forms.Button()
        Me.btnGameDB = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCropGame_Top = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCropGame_Left = New System.Windows.Forms.TextBox()
        Me.txtCropGame_Bottom = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCropGame_Right = New System.Windows.Forms.TextBox()
        Me.txtTrackerURL = New System.Windows.Forms.TextBox()
        Me.lblTracker = New System.Windows.Forms.Label()
        Me.lblGameSource = New System.Windows.Forms.Label()
        Me.gbTimerWindow.SuspendLayout()
        Me.gbGameWindow.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRunnerTwitch
        '
        Me.lblRunnerTwitch.AutoSize = True
        Me.lblRunnerTwitch.Location = New System.Drawing.Point(24, 68)
        Me.lblRunnerTwitch.Name = "lblRunnerTwitch"
        Me.lblRunnerTwitch.Size = New System.Drawing.Size(77, 13)
        Me.lblRunnerTwitch.TabIndex = 100
        Me.lblRunnerTwitch.Text = "Runner Twitch"
        '
        'lblStreamlink
        '
        Me.lblStreamlink.AutoSize = True
        Me.lblStreamlink.BackColor = System.Drawing.Color.Transparent
        Me.lblStreamlink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStreamlink.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblStreamlink.Location = New System.Drawing.Point(167, 88)
        Me.lblStreamlink.Name = "lblStreamlink"
        Me.lblStreamlink.Size = New System.Drawing.Size(56, 13)
        Me.lblStreamlink.TabIndex = 99
        Me.lblStreamlink.Text = "Open VLC"
        '
        'lblVOD
        '
        Me.lblVOD.AutoSize = True
        Me.lblVOD.BackColor = System.Drawing.Color.Transparent
        Me.lblVOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVOD.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblVOD.Location = New System.Drawing.Point(104, 88)
        Me.lblVOD.Name = "lblVOD"
        Me.lblVOD.Size = New System.Drawing.Size(61, 13)
        Me.lblVOD.TabIndex = 98
        Me.lblVOD.Text = "View VODs"
        '
        'lblViewOnTwitch
        '
        Me.lblViewOnTwitch.AutoSize = True
        Me.lblViewOnTwitch.BackColor = System.Drawing.Color.Transparent
        Me.lblViewOnTwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewOnTwitch.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblViewOnTwitch.Location = New System.Drawing.Point(22, 88)
        Me.lblViewOnTwitch.Name = "lblViewOnTwitch"
        Me.lblViewOnTwitch.Size = New System.Drawing.Size(76, 13)
        Me.lblViewOnTwitch.TabIndex = 97
        Me.lblViewOnTwitch.Text = "View on twitch"
        '
        'btnNewRunner
        '
        Me.btnNewRunner.Location = New System.Drawing.Point(231, 82)
        Me.btnNewRunner.Name = "btnNewRunner"
        Me.btnNewRunner.Size = New System.Drawing.Size(114, 23)
        Me.btnNewRunner.TabIndex = 96
        Me.btnNewRunner.Text = "New Runner"
        Me.btnNewRunner.UseVisualStyleBackColor = True
        '
        'btnSetVLC
        '
        Me.btnSetVLC.BackColor = System.Drawing.Color.GreenYellow
        Me.btnSetVLC.Location = New System.Drawing.Point(36, 143)
        Me.btnSetVLC.Name = "btnSetVLC"
        Me.btnSetVLC.Size = New System.Drawing.Size(116, 23)
        Me.btnSetVLC.TabIndex = 95
        Me.btnSetVLC.Text = "Set VLC"
        Me.btnSetVLC.UseVisualStyleBackColor = False
        '
        'cbVLCSource
        '
        Me.cbVLCSource.FormattingEnabled = True
        Me.cbVLCSource.Location = New System.Drawing.Point(113, 114)
        Me.cbVLCSource.Name = "cbVLCSource"
        Me.cbVLCSource.Size = New System.Drawing.Size(228, 21)
        Me.cbVLCSource.TabIndex = 93
        '
        'lblVLC
        '
        Me.lblVLC.AutoSize = True
        Me.lblVLC.BackColor = System.Drawing.Color.GreenYellow
        Me.lblVLC.Location = New System.Drawing.Point(24, 120)
        Me.lblVLC.Name = "lblVLC"
        Me.lblVLC.Size = New System.Drawing.Size(64, 13)
        Me.lblVLC.TabIndex = 94
        Me.lblVLC.Text = "VLC Source"
        '
        'btnSaveCrop
        '
        Me.btnSaveCrop.Location = New System.Drawing.Point(236, 444)
        Me.btnSaveCrop.Name = "btnSaveCrop"
        Me.btnSaveCrop.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveCrop.TabIndex = 92
        Me.btnSaveCrop.Text = "Save Crop"
        Me.btnSaveCrop.UseVisualStyleBackColor = True
        '
        'btnGetCrop
        '
        Me.btnGetCrop.Location = New System.Drawing.Point(151, 444)
        Me.btnGetCrop.Name = "btnGetCrop"
        Me.btnGetCrop.Size = New System.Drawing.Size(79, 23)
        Me.btnGetCrop.TabIndex = 91
        Me.btnGetCrop.Text = "Get Crop"
        Me.btnGetCrop.UseVisualStyleBackColor = True
        '
        'cbRunnerName
        '
        Me.cbRunnerName.DisplayMember = "RacerName"
        Me.cbRunnerName.FormattingEnabled = True
        Me.cbRunnerName.Location = New System.Drawing.Point(115, 41)
        Me.cbRunnerName.Name = "cbRunnerName"
        Me.cbRunnerName.Size = New System.Drawing.Size(228, 21)
        Me.cbRunnerName.TabIndex = 89
        Me.cbRunnerName.ValueMember = "RacerName"
        '
        'lblRunner
        '
        Me.lblRunner.AutoSize = True
        Me.lblRunner.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblRunner.Location = New System.Drawing.Point(22, 44)
        Me.lblRunner.Name = "lblRunner"
        Me.lblRunner.Size = New System.Drawing.Size(73, 13)
        Me.lblRunner.TabIndex = 90
        Me.lblRunner.Text = "Runner Name"
        '
        'btnSetCrop
        '
        Me.btnSetCrop.BackColor = System.Drawing.Color.PaleGreen
        Me.btnSetCrop.Location = New System.Drawing.Point(25, 444)
        Me.btnSetCrop.Name = "btnSetCrop"
        Me.btnSetCrop.Size = New System.Drawing.Size(116, 23)
        Me.btnSetCrop.TabIndex = 88
        Me.btnSetCrop.Text = "Set Left Crop"
        Me.btnSetCrop.UseVisualStyleBackColor = False
        '
        'gbTimerWindow
        '
        Me.gbTimerWindow.BackColor = System.Drawing.Color.PaleGreen
        Me.gbTimerWindow.Controls.Add(Me.btnTimerUncrop)
        Me.gbTimerWindow.Controls.Add(Me.btnTimerDB)
        Me.gbTimerWindow.Controls.Add(Me.cbScaling)
        Me.gbTimerWindow.Controls.Add(Me.lblScaling)
        Me.gbTimerWindow.Controls.Add(Me.Label12)
        Me.gbTimerWindow.Controls.Add(Me.txtCropTimer_Top)
        Me.gbTimerWindow.Controls.Add(Me.Label13)
        Me.gbTimerWindow.Controls.Add(Me.txtCropTimer_Left)
        Me.gbTimerWindow.Controls.Add(Me.txtCropTimer_Bottom)
        Me.gbTimerWindow.Controls.Add(Me.Label14)
        Me.gbTimerWindow.Controls.Add(Me.Label15)
        Me.gbTimerWindow.Controls.Add(Me.txtCropTimer_Right)
        Me.gbTimerWindow.Location = New System.Drawing.Point(25, 194)
        Me.gbTimerWindow.Name = "gbTimerWindow"
        Me.gbTimerWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbTimerWindow.TabIndex = 86
        Me.gbTimerWindow.TabStop = False
        Me.gbTimerWindow.Text = "Left Timer Window"
        '
        'btnTimerUncrop
        '
        Me.btnTimerUncrop.Location = New System.Drawing.Point(145, 17)
        Me.btnTimerUncrop.Name = "btnTimerUncrop"
        Me.btnTimerUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnTimerUncrop.TabIndex = 91
        Me.btnTimerUncrop.Text = "Uncrop"
        Me.btnTimerUncrop.UseVisualStyleBackColor = True
        '
        'btnTimerDB
        '
        Me.btnTimerDB.Location = New System.Drawing.Point(39, 19)
        Me.btnTimerDB.Name = "btnTimerDB"
        Me.btnTimerDB.Size = New System.Drawing.Size(52, 23)
        Me.btnTimerDB.TabIndex = 87
        Me.btnTimerDB.Text = "Reset"
        Me.btnTimerDB.UseVisualStyleBackColor = True
        '
        'cbScaling
        '
        Me.cbScaling.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbScaling.FormattingEnabled = True
        Me.cbScaling.Items.AddRange(New Object() {"100%", "125%", "150%", "175%", "200%", "225%", "250%", "275%", "300%"})
        Me.cbScaling.Location = New System.Drawing.Point(242, 0)
        Me.cbScaling.Name = "cbScaling"
        Me.cbScaling.Size = New System.Drawing.Size(54, 23)
        Me.cbScaling.TabIndex = 88
        Me.cbScaling.Text = "100%"
        '
        'lblScaling
        '
        Me.lblScaling.AutoSize = True
        Me.lblScaling.Location = New System.Drawing.Point(193, 4)
        Me.lblScaling.Name = "lblScaling"
        Me.lblScaling.Size = New System.Drawing.Size(45, 13)
        Me.lblScaling.TabIndex = 87
        Me.lblScaling.Text = "Scaling:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Top"
        '
        'txtCropTimer_Top
        '
        Me.txtCropTimer_Top.Location = New System.Drawing.Point(39, 79)
        Me.txtCropTimer_Top.Name = "txtCropTimer_Top"
        Me.txtCropTimer_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropTimer_Top.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Left"
        '
        'txtCropTimer_Left
        '
        Me.txtCropTimer_Left.Location = New System.Drawing.Point(39, 43)
        Me.txtCropTimer_Left.Name = "txtCropTimer_Left"
        Me.txtCropTimer_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropTimer_Left.TabIndex = 3
        '
        'txtCropTimer_Bottom
        '
        Me.txtCropTimer_Bottom.Location = New System.Drawing.Point(196, 82)
        Me.txtCropTimer_Bottom.Name = "txtCropTimer_Bottom"
        Me.txtCropTimer_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropTimer_Bottom.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(158, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Right"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(158, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Bottom"
        '
        'txtCropTimer_Right
        '
        Me.txtCropTimer_Right.Location = New System.Drawing.Point(196, 46)
        Me.txtCropTimer_Right.Name = "txtCropTimer_Right"
        Me.txtCropTimer_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropTimer_Right.TabIndex = 5
        '
        'gbGameWindow
        '
        Me.gbGameWindow.BackColor = System.Drawing.Color.PaleGreen
        Me.gbGameWindow.Controls.Add(Me.btnGameUncrop)
        Me.gbGameWindow.Controls.Add(Me.btnGameDB)
        Me.gbGameWindow.Controls.Add(Me.Label17)
        Me.gbGameWindow.Controls.Add(Me.txtCropGame_Top)
        Me.gbGameWindow.Controls.Add(Me.Label18)
        Me.gbGameWindow.Controls.Add(Me.txtCropGame_Left)
        Me.gbGameWindow.Controls.Add(Me.txtCropGame_Bottom)
        Me.gbGameWindow.Controls.Add(Me.Label19)
        Me.gbGameWindow.Controls.Add(Me.Label20)
        Me.gbGameWindow.Controls.Add(Me.txtCropGame_Right)
        Me.gbGameWindow.Location = New System.Drawing.Point(25, 320)
        Me.gbGameWindow.Name = "gbGameWindow"
        Me.gbGameWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbGameWindow.TabIndex = 87
        Me.gbGameWindow.TabStop = False
        Me.gbGameWindow.Text = "Left Game Window"
        '
        'btnGameUncrop
        '
        Me.btnGameUncrop.Location = New System.Drawing.Point(145, 19)
        Me.btnGameUncrop.Name = "btnGameUncrop"
        Me.btnGameUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnGameUncrop.TabIndex = 90
        Me.btnGameUncrop.Text = "Uncrop"
        Me.btnGameUncrop.UseVisualStyleBackColor = True
        '
        'btnGameDB
        '
        Me.btnGameDB.Location = New System.Drawing.Point(39, 19)
        Me.btnGameDB.Name = "btnGameDB"
        Me.btnGameDB.Size = New System.Drawing.Size(52, 23)
        Me.btnGameDB.TabIndex = 89
        Me.btnGameDB.Text = "Reset"
        Me.btnGameDB.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Top"
        '
        'txtCropGame_Top
        '
        Me.txtCropGame_Top.Location = New System.Drawing.Point(39, 94)
        Me.txtCropGame_Top.Name = "txtCropGame_Top"
        Me.txtCropGame_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropGame_Top.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Left"
        '
        'txtCropGame_Left
        '
        Me.txtCropGame_Left.Location = New System.Drawing.Point(39, 58)
        Me.txtCropGame_Left.Name = "txtCropGame_Left"
        Me.txtCropGame_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropGame_Left.TabIndex = 3
        '
        'txtCropGame_Bottom
        '
        Me.txtCropGame_Bottom.Location = New System.Drawing.Point(196, 97)
        Me.txtCropGame_Bottom.Name = "txtCropGame_Bottom"
        Me.txtCropGame_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropGame_Bottom.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(158, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Right"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(158, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Bottom"
        '
        'txtCropGame_Right
        '
        Me.txtCropGame_Right.Location = New System.Drawing.Point(196, 61)
        Me.txtCropGame_Right.Name = "txtCropGame_Right"
        Me.txtCropGame_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropGame_Right.TabIndex = 5
        '
        'txtTrackerURL
        '
        Me.txtTrackerURL.Location = New System.Drawing.Point(115, 15)
        Me.txtTrackerURL.Name = "txtTrackerURL"
        Me.txtTrackerURL.Size = New System.Drawing.Size(190, 20)
        Me.txtTrackerURL.TabIndex = 101
        '
        'lblTracker
        '
        Me.lblTracker.AutoSize = True
        Me.lblTracker.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblTracker.Location = New System.Drawing.Point(26, 18)
        Me.lblTracker.Name = "lblTracker"
        Me.lblTracker.Size = New System.Drawing.Size(69, 13)
        Me.lblTracker.TabIndex = 102
        Me.lblTracker.Text = "Tracker URL"
        '
        'lblGameSource
        '
        Me.lblGameSource.AutoSize = True
        Me.lblGameSource.Location = New System.Drawing.Point(18, 169)
        Me.lblGameSource.Name = "lblGameSource"
        Me.lblGameSource.Size = New System.Drawing.Size(77, 13)
        Me.lblGameSource.TabIndex = 103
        Me.lblGameSource.Text = "Runner Twitch"
        Me.lblGameSource.Visible = False
        '
        'RunnerControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblGameSource)
        Me.Controls.Add(Me.txtTrackerURL)
        Me.Controls.Add(Me.lblTracker)
        Me.Controls.Add(Me.lblRunnerTwitch)
        Me.Controls.Add(Me.lblStreamlink)
        Me.Controls.Add(Me.lblVOD)
        Me.Controls.Add(Me.lblViewOnTwitch)
        Me.Controls.Add(Me.btnNewRunner)
        Me.Controls.Add(Me.btnSetVLC)
        Me.Controls.Add(Me.cbVLCSource)
        Me.Controls.Add(Me.lblVLC)
        Me.Controls.Add(Me.btnSaveCrop)
        Me.Controls.Add(Me.btnGetCrop)
        Me.Controls.Add(Me.cbRunnerName)
        Me.Controls.Add(Me.lblRunner)
        Me.Controls.Add(Me.btnSetCrop)
        Me.Controls.Add(Me.gbTimerWindow)
        Me.Controls.Add(Me.gbGameWindow)
        Me.Name = "RunnerControls"
        Me.Size = New System.Drawing.Size(346, 480)
        Me.gbTimerWindow.ResumeLayout(False)
        Me.gbTimerWindow.PerformLayout()
        Me.gbGameWindow.ResumeLayout(False)
        Me.gbGameWindow.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRunnerTwitch As Label
    Friend WithEvents lblStreamlink As Label
    Friend WithEvents lblVOD As Label
    Friend WithEvents lblViewOnTwitch As Label
    Friend WithEvents btnNewRunner As Button
    Friend WithEvents btnSetVLC As Button
    Friend WithEvents cbVLCSource As ComboBox
    Friend WithEvents lblVLC As Label
    Friend WithEvents btnSaveCrop As Button
    Friend WithEvents btnGetCrop As Button
    Friend WithEvents cbRunnerName As ComboBox
    Friend WithEvents lblRunner As Label
    Friend WithEvents btnSetCrop As Button
    Friend WithEvents gbTimerWindow As GroupBox
    Friend WithEvents btnTimerUncrop As Button
    Friend WithEvents btnTimerDB As Button
    Friend WithEvents cbScaling As ComboBox
    Friend WithEvents lblScaling As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCropTimer_Top As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCropTimer_Left As TextBox
    Friend WithEvents txtCropTimer_Bottom As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCropTimer_Right As TextBox
    Friend WithEvents gbGameWindow As GroupBox
    Friend WithEvents btnGameUncrop As Button
    Friend WithEvents btnGameDB As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCropGame_Top As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCropGame_Left As TextBox
    Friend WithEvents txtCropGame_Bottom As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtCropGame_Right As TextBox
    Friend WithEvents txtTrackerURL As TextBox
    Friend WithEvents lblTracker As Label
    Friend WithEvents lblGameSource As Label
End Class
