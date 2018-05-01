<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.gbConnection1 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPassword1 = New System.Windows.Forms.TextBox()
        Me.txtConnectionString1 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblOBS1ConnectedStatus = New System.Windows.Forms.Label()
        Me.btnConnectOBS1 = New System.Windows.Forms.Button()
        Me.btnRefreshScenes = New System.Windows.Forms.Button()
        Me.btnResetSettings = New System.Windows.Forms.Button()
        Me.panOBS = New System.Windows.Forms.Panel()
        Me.cbCommentaryOBS = New System.Windows.Forms.ComboBox()
        Me.cbRightTrackerOBS = New System.Windows.Forms.ComboBox()
        Me.cbRightRunnerOBS = New System.Windows.Forms.ComboBox()
        Me.cbLeftTrackerOBS = New System.Windows.Forms.ComboBox()
        Me.cbLeftRunnerOBS = New System.Windows.Forms.ComboBox()
        Me.cbRightGameWindow = New System.Windows.Forms.ComboBox()
        Me.cbLeftTimerWindow = New System.Windows.Forms.ComboBox()
        Me.cbRightTimerWindow = New System.Windows.Forms.ComboBox()
        Me.cbLeftGameWindow = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTwitchChannel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.roDefault = New System.Windows.Forms.RadioButton()
        Me.roCustom = New System.Windows.Forms.RadioButton()
        Me.btnSaveThenVLC = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConnectionPort = New System.Windows.Forms.TextBox()
        Me.gbConnection1.SuspendLayout()
        Me.panOBS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(591, 733)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(137, 39)
        Me.btnSaveSettings.TabIndex = 73
        Me.btnSaveSettings.Text = "Save OBS Settings and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Continue to Program"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'gbConnection1
        '
        Me.gbConnection1.Controls.Add(Me.Label3)
        Me.gbConnection1.Controls.Add(Me.txtConnectionPort)
        Me.gbConnection1.Controls.Add(Me.Label26)
        Me.gbConnection1.Controls.Add(Me.txtPassword1)
        Me.gbConnection1.Controls.Add(Me.txtConnectionString1)
        Me.gbConnection1.Controls.Add(Me.Label25)
        Me.gbConnection1.Location = New System.Drawing.Point(511, 12)
        Me.gbConnection1.Name = "gbConnection1"
        Me.gbConnection1.Size = New System.Drawing.Size(390, 71)
        Me.gbConnection1.TabIndex = 92
        Me.gbConnection1.TabStop = False
        Me.gbConnection1.Text = "Connection Settings"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(51, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Password"
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(110, 43)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.Size = New System.Drawing.Size(160, 20)
        Me.txtPassword1.TabIndex = 30
        '
        'txtConnectionString1
        '
        Me.txtConnectionString1.Location = New System.Drawing.Point(110, 19)
        Me.txtConnectionString1.Name = "txtConnectionString1"
        Me.txtConnectionString1.Size = New System.Drawing.Size(160, 20)
        Me.txtConnectionString1.TabIndex = 28
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 13)
        Me.Label25.TabIndex = 27
        Me.Label25.Text = "Connection String"
        '
        'lblOBS1ConnectedStatus
        '
        Me.lblOBS1ConnectedStatus.AutoSize = True
        Me.lblOBS1ConnectedStatus.Location = New System.Drawing.Point(159, 62)
        Me.lblOBS1ConnectedStatus.Name = "lblOBS1ConnectedStatus"
        Me.lblOBS1ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS1ConnectedStatus.TabIndex = 94
        Me.lblOBS1ConnectedStatus.Text = "Connected Status"
        '
        'btnConnectOBS1
        '
        Me.btnConnectOBS1.Location = New System.Drawing.Point(169, 34)
        Me.btnConnectOBS1.Name = "btnConnectOBS1"
        Me.btnConnectOBS1.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS1.TabIndex = 93
        Me.btnConnectOBS1.Text = "Verify / Connect"
        Me.btnConnectOBS1.UseVisualStyleBackColor = True
        '
        'btnRefreshScenes
        '
        Me.btnRefreshScenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshScenes.Location = New System.Drawing.Point(401, 375)
        Me.btnRefreshScenes.Name = "btnRefreshScenes"
        Me.btnRefreshScenes.Size = New System.Drawing.Size(187, 56)
        Me.btnRefreshScenes.TabIndex = 31
        Me.btnRefreshScenes.Text = "Refresh OBS Scenes"
        Me.btnRefreshScenes.UseVisualStyleBackColor = True
        '
        'btnResetSettings
        '
        Me.btnResetSettings.Location = New System.Drawing.Point(26, 746)
        Me.btnResetSettings.Name = "btnResetSettings"
        Me.btnResetSettings.Size = New System.Drawing.Size(121, 23)
        Me.btnResetSettings.TabIndex = 93
        Me.btnResetSettings.Text = "Reset Settings"
        Me.btnResetSettings.UseVisualStyleBackColor = True
        '
        'panOBS
        '
        Me.panOBS.BackgroundImage = Global.ALTTPRCropDashboard.My.Resources.Resources.Settings_Background_Resized
        Me.panOBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panOBS.Controls.Add(Me.cbCommentaryOBS)
        Me.panOBS.Controls.Add(Me.cbRightTrackerOBS)
        Me.panOBS.Controls.Add(Me.cbRightRunnerOBS)
        Me.panOBS.Controls.Add(Me.cbLeftTrackerOBS)
        Me.panOBS.Controls.Add(Me.cbLeftRunnerOBS)
        Me.panOBS.Controls.Add(Me.cbRightGameWindow)
        Me.panOBS.Controls.Add(Me.cbLeftTimerWindow)
        Me.panOBS.Controls.Add(Me.cbRightTimerWindow)
        Me.panOBS.Controls.Add(Me.cbLeftGameWindow)
        Me.panOBS.Controls.Add(Me.btnRefreshScenes)
        Me.panOBS.Location = New System.Drawing.Point(0, 89)
        Me.panOBS.Name = "panOBS"
        Me.panOBS.Size = New System.Drawing.Size(1008, 635)
        Me.panOBS.TabIndex = 94
        '
        'cbCommentaryOBS
        '
        Me.cbCommentaryOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCommentaryOBS.FormattingEnabled = True
        Me.cbCommentaryOBS.Location = New System.Drawing.Point(427, 581)
        Me.cbCommentaryOBS.Name = "cbCommentaryOBS"
        Me.cbCommentaryOBS.Size = New System.Drawing.Size(301, 25)
        Me.cbCommentaryOBS.TabIndex = 90
        '
        'cbRightTrackerOBS
        '
        Me.cbRightTrackerOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightTrackerOBS.FormattingEnabled = True
        Me.cbRightTrackerOBS.Location = New System.Drawing.Point(764, 535)
        Me.cbRightTrackerOBS.Name = "cbRightTrackerOBS"
        Me.cbRightTrackerOBS.Size = New System.Drawing.Size(224, 25)
        Me.cbRightTrackerOBS.TabIndex = 86
        '
        'cbRightRunnerOBS
        '
        Me.cbRightRunnerOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightRunnerOBS.FormattingEnabled = True
        Me.cbRightRunnerOBS.Location = New System.Drawing.Point(557, 53)
        Me.cbRightRunnerOBS.Name = "cbRightRunnerOBS"
        Me.cbRightRunnerOBS.Size = New System.Drawing.Size(302, 25)
        Me.cbRightRunnerOBS.TabIndex = 74
        '
        'cbLeftTrackerOBS
        '
        Me.cbLeftTrackerOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftTrackerOBS.FormattingEnabled = True
        Me.cbLeftTrackerOBS.Location = New System.Drawing.Point(26, 547)
        Me.cbLeftTrackerOBS.Name = "cbLeftTrackerOBS"
        Me.cbLeftTrackerOBS.Size = New System.Drawing.Size(231, 25)
        Me.cbLeftTrackerOBS.TabIndex = 88
        '
        'cbLeftRunnerOBS
        '
        Me.cbLeftRunnerOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftRunnerOBS.FormattingEnabled = True
        Me.cbLeftRunnerOBS.Location = New System.Drawing.Point(197, 53)
        Me.cbLeftRunnerOBS.Name = "cbLeftRunnerOBS"
        Me.cbLeftRunnerOBS.Size = New System.Drawing.Size(253, 25)
        Me.cbLeftRunnerOBS.TabIndex = 76
        '
        'cbRightGameWindow
        '
        Me.cbRightGameWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightGameWindow.FormattingEnabled = True
        Me.cbRightGameWindow.Location = New System.Drawing.Point(607, 248)
        Me.cbRightGameWindow.Name = "cbRightGameWindow"
        Me.cbRightGameWindow.Size = New System.Drawing.Size(338, 25)
        Me.cbRightGameWindow.TabIndex = 78
        '
        'cbLeftTimerWindow
        '
        Me.cbLeftTimerWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftTimerWindow.FormattingEnabled = True
        Me.cbLeftTimerWindow.Location = New System.Drawing.Point(15, 43)
        Me.cbLeftTimerWindow.Name = "cbLeftTimerWindow"
        Me.cbLeftTimerWindow.Size = New System.Drawing.Size(121, 25)
        Me.cbLeftTimerWindow.TabIndex = 84
        '
        'cbRightTimerWindow
        '
        Me.cbRightTimerWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightTimerWindow.FormattingEnabled = True
        Me.cbRightTimerWindow.Location = New System.Drawing.Point(879, 43)
        Me.cbRightTimerWindow.Name = "cbRightTimerWindow"
        Me.cbRightTimerWindow.Size = New System.Drawing.Size(121, 25)
        Me.cbRightTimerWindow.TabIndex = 80
        '
        'cbLeftGameWindow
        '
        Me.cbLeftGameWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftGameWindow.FormattingEnabled = True
        Me.cbLeftGameWindow.Location = New System.Drawing.Point(43, 248)
        Me.cbLeftGameWindow.Name = "cbLeftGameWindow"
        Me.cbLeftGameWindow.Size = New System.Drawing.Size(360, 25)
        Me.cbLeftGameWindow.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Twitch Channel"
        '
        'txtTwitchChannel
        '
        Me.txtTwitchChannel.Location = New System.Drawing.Point(99, 6)
        Me.txtTwitchChannel.Name = "txtTwitchChannel"
        Me.txtTwitchChannel.Size = New System.Drawing.Size(160, 20)
        Me.txtTwitchChannel.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "We need this to allow you to save your settings."
        '
        'roDefault
        '
        Me.roDefault.AutoSize = True
        Me.roDefault.Location = New System.Drawing.Point(33, 38)
        Me.roDefault.Name = "roDefault"
        Me.roDefault.Size = New System.Drawing.Size(59, 17)
        Me.roDefault.TabIndex = 98
        Me.roDefault.TabStop = True
        Me.roDefault.Text = "Default"
        Me.roDefault.UseVisualStyleBackColor = True
        '
        'roCustom
        '
        Me.roCustom.AutoSize = True
        Me.roCustom.Location = New System.Drawing.Point(103, 37)
        Me.roCustom.Name = "roCustom"
        Me.roCustom.Size = New System.Drawing.Size(60, 17)
        Me.roCustom.TabIndex = 99
        Me.roCustom.TabStop = True
        Me.roCustom.Text = "Custom"
        Me.roCustom.UseVisualStyleBackColor = True
        '
        'btnSaveThenVLC
        '
        Me.btnSaveThenVLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveThenVLC.Location = New System.Drawing.Point(756, 724)
        Me.btnSaveThenVLC.Name = "btnSaveThenVLC"
        Me.btnSaveThenVLC.Size = New System.Drawing.Size(252, 54)
        Me.btnSaveThenVLC.TabIndex = 100
        Me.btnSaveThenVLC.Text = "Save OBS Settings and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Continue to VLC Settings"
        Me.btnSaveThenVLC.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Port"
        '
        'txtConnectionPort
        '
        Me.txtConnectionPort.Location = New System.Drawing.Point(304, 21)
        Me.txtConnectionPort.Name = "txtConnectionPort"
        Me.txtConnectionPort.Size = New System.Drawing.Size(68, 20)
        Me.txtConnectionPort.TabIndex = 32
        '
        'UserSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 781)
        Me.Controls.Add(Me.btnSaveThenVLC)
        Me.Controls.Add(Me.lblOBS1ConnectedStatus)
        Me.Controls.Add(Me.roCustom)
        Me.Controls.Add(Me.btnConnectOBS1)
        Me.Controls.Add(Me.roDefault)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panOBS)
        Me.Controls.Add(Me.txtTwitchChannel)
        Me.Controls.Add(Me.btnResetSettings)
        Me.Controls.Add(Me.gbConnection1)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Name = "UserSettings"
        Me.Text = "User Settings"
        Me.gbConnection1.ResumeLayout(False)
        Me.gbConnection1.PerformLayout()
        Me.panOBS.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents cbLeftRunnerOBS As ComboBox
    Friend WithEvents cbRightRunnerOBS As ComboBox
    Friend WithEvents cbRightGameWindow As ComboBox
    Friend WithEvents cbRightTimerWindow As ComboBox
    Friend WithEvents cbLeftGameWindow As ComboBox
    Friend WithEvents cbLeftTimerWindow As ComboBox
    Friend WithEvents cbRightTrackerOBS As ComboBox
    Friend WithEvents cbLeftTrackerOBS As ComboBox
    Friend WithEvents cbCommentaryOBS As ComboBox
    Friend WithEvents gbConnection1 As GroupBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtPassword1 As TextBox
    Friend WithEvents txtConnectionString1 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents btnRefreshScenes As Button
    Friend WithEvents btnConnectOBS1 As Button
    Friend WithEvents lblOBS1ConnectedStatus As Label
    Friend WithEvents btnResetSettings As Button
    Friend WithEvents panOBS As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTwitchChannel As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents roDefault As RadioButton
    Friend WithEvents roCustom As RadioButton
    Friend WithEvents btnSaveThenVLC As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConnectionPort As TextBox
End Class
