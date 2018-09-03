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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSettings))
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.gbConnection1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConnectionPort = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPassword1 = New System.Windows.Forms.TextBox()
        Me.txtConnectionString1 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblOBS1ConnectedStatus = New System.Windows.Forms.Label()
        Me.btnConnectOBS1 = New System.Windows.Forms.Button()
        Me.btnResetSettings = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTwitchChannel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.roDefault = New System.Windows.Forms.RadioButton()
        Me.roCustom = New System.Windows.Forms.RadioButton()
        Me.btnSaveThenVLC = New System.Windows.Forms.Button()
        Me.panOBS = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbRunner4 = New System.Windows.Forms.GroupBox()
        Me.gbRunner3 = New System.Windows.Forms.GroupBox()
        Me.gbRunner2 = New System.Windows.Forms.GroupBox()
        Me.gbRunner1 = New System.Windows.Forms.GroupBox()
        Me.lblGameSettings = New System.Windows.Forms.Label()
        Me.lblGameSettingsStatus = New System.Windows.Forms.Label()
        Me.cbGameSettings = New System.Windows.Forms.ComboBox()
        Me.lblCommentaryStatus = New System.Windows.Forms.Label()
        Me.cbCommentaryOBS = New System.Windows.Forms.ComboBox()
        Me.btnRefreshScenes = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDefaultOBS = New System.Windows.Forms.Button()
        Me.gbConnection1.SuspendLayout()
        Me.panOBS.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(604, 494)
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
        Me.gbConnection1.Location = New System.Drawing.Point(604, 12)
        Me.gbConnection1.Name = "gbConnection1"
        Me.gbConnection1.Size = New System.Drawing.Size(390, 71)
        Me.gbConnection1.TabIndex = 92
        Me.gbConnection1.TabStop = False
        Me.gbConnection1.Text = "Connection Settings"
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
        Me.lblOBS1ConnectedStatus.Location = New System.Drawing.Point(150, 62)
        Me.lblOBS1ConnectedStatus.Name = "lblOBS1ConnectedStatus"
        Me.lblOBS1ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS1ConnectedStatus.TabIndex = 94
        Me.lblOBS1ConnectedStatus.Text = "Connected Status"
        '
        'btnConnectOBS1
        '
        Me.btnConnectOBS1.Location = New System.Drawing.Point(160, 34)
        Me.btnConnectOBS1.Name = "btnConnectOBS1"
        Me.btnConnectOBS1.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS1.TabIndex = 93
        Me.btnConnectOBS1.Text = "Verify / Connect"
        Me.btnConnectOBS1.UseVisualStyleBackColor = True
        '
        'btnResetSettings
        '
        Me.btnResetSettings.Location = New System.Drawing.Point(27, 485)
        Me.btnResetSettings.Name = "btnResetSettings"
        Me.btnResetSettings.Size = New System.Drawing.Size(121, 23)
        Me.btnResetSettings.TabIndex = 93
        Me.btnResetSettings.Text = "Reset Settings"
        Me.btnResetSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Twitch Channel / User Name"
        '
        'txtTwitchChannel
        '
        Me.txtTwitchChannel.Location = New System.Drawing.Point(153, 6)
        Me.txtTwitchChannel.Name = "txtTwitchChannel"
        Me.txtTwitchChannel.Size = New System.Drawing.Size(160, 20)
        Me.txtTwitchChannel.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "We need this to allow you to save your settings."
        '
        'roDefault
        '
        Me.roDefault.AutoSize = True
        Me.roDefault.Location = New System.Drawing.Point(24, 38)
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
        Me.roCustom.Location = New System.Drawing.Point(94, 38)
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
        Me.btnSaveThenVLC.Location = New System.Drawing.Point(756, 485)
        Me.btnSaveThenVLC.Name = "btnSaveThenVLC"
        Me.btnSaveThenVLC.Size = New System.Drawing.Size(252, 54)
        Me.btnSaveThenVLC.TabIndex = 100
        Me.btnSaveThenVLC.Text = "Save OBS Settings and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Continue to VLC Settings"
        Me.btnSaveThenVLC.UseVisualStyleBackColor = True
        '
        'panOBS
        '
        Me.panOBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panOBS.Controls.Add(Me.Label4)
        Me.panOBS.Controls.Add(Me.gbRunner4)
        Me.panOBS.Controls.Add(Me.gbRunner3)
        Me.panOBS.Controls.Add(Me.gbRunner2)
        Me.panOBS.Controls.Add(Me.gbRunner1)
        Me.panOBS.Controls.Add(Me.lblGameSettings)
        Me.panOBS.Controls.Add(Me.lblGameSettingsStatus)
        Me.panOBS.Controls.Add(Me.cbGameSettings)
        Me.panOBS.Controls.Add(Me.lblCommentaryStatus)
        Me.panOBS.Controls.Add(Me.cbCommentaryOBS)
        Me.panOBS.Location = New System.Drawing.Point(6, 89)
        Me.panOBS.Name = "panOBS"
        Me.panOBS.Size = New System.Drawing.Size(1008, 390)
        Me.panOBS.TabIndex = 94
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(523, 349)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Commentary"
        '
        'gbRunner4
        '
        Me.gbRunner4.Location = New System.Drawing.Point(509, 176)
        Me.gbRunner4.Name = "gbRunner4"
        Me.gbRunner4.Size = New System.Drawing.Size(493, 167)
        Me.gbRunner4.TabIndex = 106
        Me.gbRunner4.TabStop = False
        Me.gbRunner4.Text = "Runner 4"
        '
        'gbRunner3
        '
        Me.gbRunner3.Location = New System.Drawing.Point(6, 176)
        Me.gbRunner3.Name = "gbRunner3"
        Me.gbRunner3.Size = New System.Drawing.Size(493, 167)
        Me.gbRunner3.TabIndex = 105
        Me.gbRunner3.TabStop = False
        Me.gbRunner3.Text = "Runner 3"
        '
        'gbRunner2
        '
        Me.gbRunner2.Location = New System.Drawing.Point(509, 3)
        Me.gbRunner2.Name = "gbRunner2"
        Me.gbRunner2.Size = New System.Drawing.Size(493, 167)
        Me.gbRunner2.TabIndex = 104
        Me.gbRunner2.TabStop = False
        Me.gbRunner2.Text = "Runner 2"
        '
        'gbRunner1
        '
        Me.gbRunner1.Location = New System.Drawing.Point(6, 3)
        Me.gbRunner1.Name = "gbRunner1"
        Me.gbRunner1.Size = New System.Drawing.Size(493, 167)
        Me.gbRunner1.TabIndex = 103
        Me.gbRunner1.TabStop = False
        Me.gbRunner1.Text = "Runner 1"
        '
        'lblGameSettings
        '
        Me.lblGameSettings.AutoSize = True
        Me.lblGameSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblGameSettings.Location = New System.Drawing.Point(17, 349)
        Me.lblGameSettings.Name = "lblGameSettings"
        Me.lblGameSettings.Size = New System.Drawing.Size(76, 13)
        Me.lblGameSettings.TabIndex = 102
        Me.lblGameSettings.Text = "Game Settings"
        '
        'lblGameSettingsStatus
        '
        Me.lblGameSettingsStatus.AutoSize = True
        Me.lblGameSettingsStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblGameSettingsStatus.Location = New System.Drawing.Point(364, 355)
        Me.lblGameSettingsStatus.Name = "lblGameSettingsStatus"
        Me.lblGameSettingsStatus.Size = New System.Drawing.Size(109, 13)
        Me.lblGameSettingsStatus.TabIndex = 101
        Me.lblGameSettingsStatus.Text = "Game Settings Status"
        '
        'cbGameSettings
        '
        Me.cbGameSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGameSettings.FormattingEnabled = True
        Me.cbGameSettings.Location = New System.Drawing.Point(99, 349)
        Me.cbGameSettings.Name = "cbGameSettings"
        Me.cbGameSettings.Size = New System.Drawing.Size(257, 25)
        Me.cbGameSettings.TabIndex = 100
        '
        'lblCommentaryStatus
        '
        Me.lblCommentaryStatus.AutoSize = True
        Me.lblCommentaryStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblCommentaryStatus.Location = New System.Drawing.Point(872, 349)
        Me.lblCommentaryStatus.Name = "lblCommentaryStatus"
        Me.lblCommentaryStatus.Size = New System.Drawing.Size(98, 13)
        Me.lblCommentaryStatus.TabIndex = 93
        Me.lblCommentaryStatus.Text = "Commentary Status"
        '
        'cbCommentaryOBS
        '
        Me.cbCommentaryOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCommentaryOBS.FormattingEnabled = True
        Me.cbCommentaryOBS.Location = New System.Drawing.Point(605, 343)
        Me.cbCommentaryOBS.Name = "cbCommentaryOBS"
        Me.cbCommentaryOBS.Size = New System.Drawing.Size(254, 25)
        Me.cbCommentaryOBS.TabIndex = 90
        '
        'btnRefreshScenes
        '
        Me.btnRefreshScenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshScenes.Location = New System.Drawing.Point(373, 27)
        Me.btnRefreshScenes.Name = "btnRefreshScenes"
        Me.btnRefreshScenes.Size = New System.Drawing.Size(187, 56)
        Me.btnRefreshScenes.TabIndex = 31
        Me.btnRefreshScenes.Text = "Refresh OBS Scenes"
        Me.btnRefreshScenes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.btnDefaultOBS)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSaveThenVLC)
        Me.Panel1.Controls.Add(Me.lblOBS1ConnectedStatus)
        Me.Panel1.Controls.Add(Me.btnResetSettings)
        Me.Panel1.Controls.Add(Me.panOBS)
        Me.Panel1.Controls.Add(Me.btnSaveSettings)
        Me.Panel1.Controls.Add(Me.gbConnection1)
        Me.Panel1.Controls.Add(Me.roCustom)
        Me.Panel1.Controls.Add(Me.txtTwitchChannel)
        Me.Panel1.Controls.Add(Me.btnRefreshScenes)
        Me.Panel1.Controls.Add(Me.btnConnectOBS1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.roDefault)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1014, 555)
        Me.Panel1.TabIndex = 101
        '
        'btnDefaultOBS
        '
        Me.btnDefaultOBS.Location = New System.Drawing.Point(457, 494)
        Me.btnDefaultOBS.Name = "btnDefaultOBS"
        Me.btnDefaultOBS.Size = New System.Drawing.Size(137, 39)
        Me.btnDefaultOBS.TabIndex = 101
        Me.btnDefaultOBS.Text = "Use Default OBS Settings"
        Me.btnDefaultOBS.UseVisualStyleBackColor = True
        '
        'UserSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1014, 555)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UserSettings"
        Me.Text = "User Settings"
        Me.gbConnection1.ResumeLayout(False)
        Me.gbConnection1.PerformLayout()
        Me.panOBS.ResumeLayout(False)
        Me.panOBS.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSaveSettings As Button
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblCommentaryStatus As Label
    Friend WithEvents lblGameSettings As Label
    Friend WithEvents lblGameSettingsStatus As Label
    Friend WithEvents cbGameSettings As ComboBox
    Friend WithEvents gbRunner4 As GroupBox
    Friend WithEvents gbRunner3 As GroupBox
    Friend WithEvents gbRunner2 As GroupBox
    Friend WithEvents gbRunner1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnDefaultOBS As Button
End Class
