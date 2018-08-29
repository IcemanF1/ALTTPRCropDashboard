<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ObsWebSocketCropper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObsWebSocketCropper))
        Me.btnConnectOBS1 = New System.Windows.Forms.Button()
        Me.lblCommentary = New System.Windows.Forms.Label()
        Me.txtCommentaryNames = New System.Windows.Forms.TextBox()
        Me.btnSetTrackCommNames = New System.Windows.Forms.Button()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeUserSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeVLCSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadConfigFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpertModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttMainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSyncWithServer = New System.Windows.Forms.Button()
        Me.btnGetProcesses = New System.Windows.Forms.Button()
        Me.btn2ndOBS = New System.Windows.Forms.Button()
        Me.btnConnectOBS2 = New System.Windows.Forms.Button()
        Me.btnTestSourceSettings = New System.Windows.Forms.Button()
        Me.gbTrackerComms = New System.Windows.Forms.GroupBox()
        Me.lblGameSettings = New System.Windows.Forms.Label()
        Me.txtGameSettings = New System.Windows.Forms.TextBox()
        Me.lblOBS1ConnectedStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblOBS2ConnectedStatus = New System.Windows.Forms.Label()
        Me.chkAlwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.btnResetDatabase = New System.Windows.Forms.Button()
        Me.ofdOpenConfig = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rb4Runner = New System.Windows.Forms.RadioButton()
        Me.rb3Runner = New System.Windows.Forms.RadioButton()
        Me.rb2Runner = New System.Windows.Forms.RadioButton()
        Me.rb1Runner = New System.Windows.Forms.RadioButton()
        Me.lblConfigFile = New System.Windows.Forms.Label()
        Me.mnuMainMenu.SuspendLayout()
        Me.gbTrackerComms.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnectOBS1
        '
        Me.btnConnectOBS1.Location = New System.Drawing.Point(7, 27)
        Me.btnConnectOBS1.Name = "btnConnectOBS1"
        Me.btnConnectOBS1.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS1.TabIndex = 11
        Me.btnConnectOBS1.Text = "Connect OBS 1"
        Me.ttMainToolTip.SetToolTip(Me.btnConnectOBS1, "Attempt to connect to the OBS Websocket based off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the connection string and pass" &
        "word")
        Me.btnConnectOBS1.UseVisualStyleBackColor = True
        '
        'lblCommentary
        '
        Me.lblCommentary.AutoSize = True
        Me.lblCommentary.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblCommentary.Location = New System.Drawing.Point(8, 19)
        Me.lblCommentary.Name = "lblCommentary"
        Me.lblCommentary.Size = New System.Drawing.Size(101, 13)
        Me.lblCommentary.TabIndex = 54
        Me.lblCommentary.Text = "Commentary Names"
        '
        'txtCommentaryNames
        '
        Me.txtCommentaryNames.Location = New System.Drawing.Point(117, 18)
        Me.txtCommentaryNames.Name = "txtCommentaryNames"
        Me.txtCommentaryNames.Size = New System.Drawing.Size(280, 20)
        Me.txtCommentaryNames.TabIndex = 53
        '
        'btnSetTrackCommNames
        '
        Me.btnSetTrackCommNames.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btnSetTrackCommNames.Location = New System.Drawing.Point(7, 101)
        Me.btnSetTrackCommNames.Name = "btnSetTrackCommNames"
        Me.btnSetTrackCommNames.Size = New System.Drawing.Size(142, 23)
        Me.btnSetTrackCommNames.TabIndex = 55
        Me.btnSetTrackCommNames.Text = "Set Track/Comms/Names"
        Me.ttMainToolTip.SetToolTip(Me.btnSetTrackCommNames, "Sends the current text settings to OBS if there is text entered into the form." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Tracker URL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Runner Names" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Commentary Names")
        Me.btnSetTrackCommNames.UseVisualStyleBackColor = False
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(626, 24)
        Me.mnuMainMenu.TabIndex = 57
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeUserSettingsToolStripMenuItem, Me.ChangeVLCSettingsToolStripMenuItem, Me.ConfigEditorToolStripMenuItem, Me.LoadConfigFileToolStripMenuItem, Me.ExpertModeToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ChangeUserSettingsToolStripMenuItem
        '
        Me.ChangeUserSettingsToolStripMenuItem.Name = "ChangeUserSettingsToolStripMenuItem"
        Me.ChangeUserSettingsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ChangeUserSettingsToolStripMenuItem.Text = "Change User Settings"
        '
        'ChangeVLCSettingsToolStripMenuItem
        '
        Me.ChangeVLCSettingsToolStripMenuItem.Name = "ChangeVLCSettingsToolStripMenuItem"
        Me.ChangeVLCSettingsToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ChangeVLCSettingsToolStripMenuItem.Text = "Change VLC Settings"
        '
        'ConfigEditorToolStripMenuItem
        '
        Me.ConfigEditorToolStripMenuItem.Name = "ConfigEditorToolStripMenuItem"
        Me.ConfigEditorToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ConfigEditorToolStripMenuItem.Text = "Config Editor"
        '
        'LoadConfigFileToolStripMenuItem
        '
        Me.LoadConfigFileToolStripMenuItem.Name = "LoadConfigFileToolStripMenuItem"
        Me.LoadConfigFileToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.LoadConfigFileToolStripMenuItem.Text = "Load Config File"
        '
        'ExpertModeToolStripMenuItem
        '
        Me.ExpertModeToolStripMenuItem.CheckOnClick = True
        Me.ExpertModeToolStripMenuItem.Name = "ExpertModeToolStripMenuItem"
        Me.ExpertModeToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ExpertModeToolStripMenuItem.Text = "Expert Mode"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'btnSyncWithServer
        '
        Me.btnSyncWithServer.Location = New System.Drawing.Point(7, 257)
        Me.btnSyncWithServer.Name = "btnSyncWithServer"
        Me.btnSyncWithServer.Size = New System.Drawing.Size(142, 23)
        Me.btnSyncWithServer.TabIndex = 60
        Me.btnSyncWithServer.Text = "Sync With Server"
        Me.ttMainToolTip.SetToolTip(Me.btnSyncWithServer, "Syncs the online database with the local database")
        Me.btnSyncWithServer.UseVisualStyleBackColor = True
        '
        'btnGetProcesses
        '
        Me.btnGetProcesses.Location = New System.Drawing.Point(12, 167)
        Me.btnGetProcesses.Name = "btnGetProcesses"
        Me.btnGetProcesses.Size = New System.Drawing.Size(114, 23)
        Me.btnGetProcesses.TabIndex = 65
        Me.btnGetProcesses.Text = "Get Processes"
        Me.ttMainToolTip.SetToolTip(Me.btnGetProcesses, "Gets the currently running VLC processes and fills the dropdowns")
        Me.btnGetProcesses.UseVisualStyleBackColor = True
        '
        'btn2ndOBS
        '
        Me.btn2ndOBS.Location = New System.Drawing.Point(7, 72)
        Me.btn2ndOBS.Name = "btn2ndOBS"
        Me.btn2ndOBS.Size = New System.Drawing.Size(117, 23)
        Me.btn2ndOBS.TabIndex = 71
        Me.btn2ndOBS.Text = "2nd OBS"
        Me.ttMainToolTip.SetToolTip(Me.btn2ndOBS, "To help bypass the connection port error when loading a 2nd OBS")
        Me.btn2ndOBS.UseVisualStyleBackColor = True
        '
        'btnConnectOBS2
        '
        Me.btnConnectOBS2.Location = New System.Drawing.Point(12, 336)
        Me.btnConnectOBS2.Name = "btnConnectOBS2"
        Me.btnConnectOBS2.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS2.TabIndex = 73
        Me.btnConnectOBS2.Text = "Connect OBS 2"
        Me.ttMainToolTip.SetToolTip(Me.btnConnectOBS2, "Attempt to connect to the OBS Websocket based off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the connection string and pass" &
        "word")
        Me.btnConnectOBS2.UseVisualStyleBackColor = True
        '
        'btnTestSourceSettings
        '
        Me.btnTestSourceSettings.Location = New System.Drawing.Point(12, 388)
        Me.btnTestSourceSettings.Name = "btnTestSourceSettings"
        Me.btnTestSourceSettings.Size = New System.Drawing.Size(137, 23)
        Me.btnTestSourceSettings.TabIndex = 84
        Me.btnTestSourceSettings.Text = "Test Source Settings"
        Me.ttMainToolTip.SetToolTip(Me.btnTestSourceSettings, "Testing stuff.  Nothing to see here.")
        Me.btnTestSourceSettings.UseVisualStyleBackColor = True
        Me.btnTestSourceSettings.Visible = False
        '
        'gbTrackerComms
        '
        Me.gbTrackerComms.BackColor = System.Drawing.Color.PaleTurquoise
        Me.gbTrackerComms.Controls.Add(Me.lblGameSettings)
        Me.gbTrackerComms.Controls.Add(Me.txtGameSettings)
        Me.gbTrackerComms.Controls.Add(Me.lblCommentary)
        Me.gbTrackerComms.Controls.Add(Me.txtCommentaryNames)
        Me.gbTrackerComms.Location = New System.Drawing.Point(169, 15)
        Me.gbTrackerComms.Name = "gbTrackerComms"
        Me.gbTrackerComms.Size = New System.Drawing.Size(420, 87)
        Me.gbTrackerComms.TabIndex = 58
        Me.gbTrackerComms.TabStop = False
        Me.gbTrackerComms.Text = "Tracker / Comms info"
        '
        'lblGameSettings
        '
        Me.lblGameSettings.AutoSize = True
        Me.lblGameSettings.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblGameSettings.Location = New System.Drawing.Point(8, 51)
        Me.lblGameSettings.Name = "lblGameSettings"
        Me.lblGameSettings.Size = New System.Drawing.Size(76, 13)
        Me.lblGameSettings.TabIndex = 56
        Me.lblGameSettings.Text = "Game Settings"
        '
        'txtGameSettings
        '
        Me.txtGameSettings.Location = New System.Drawing.Point(117, 50)
        Me.txtGameSettings.Name = "txtGameSettings"
        Me.txtGameSettings.Size = New System.Drawing.Size(280, 20)
        Me.txtGameSettings.TabIndex = 55
        '
        'lblOBS1ConnectedStatus
        '
        Me.lblOBS1ConnectedStatus.AutoSize = True
        Me.lblOBS1ConnectedStatus.Location = New System.Drawing.Point(32, 53)
        Me.lblOBS1ConnectedStatus.Name = "lblOBS1ConnectedStatus"
        Me.lblOBS1ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS1ConnectedStatus.TabIndex = 25
        Me.lblOBS1ConnectedStatus.Text = "Connected Status"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lblOBS2ConnectedStatus
        '
        Me.lblOBS2ConnectedStatus.AutoSize = True
        Me.lblOBS2ConnectedStatus.Location = New System.Drawing.Point(25, 320)
        Me.lblOBS2ConnectedStatus.Name = "lblOBS2ConnectedStatus"
        Me.lblOBS2ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS2ConnectedStatus.TabIndex = 72
        Me.lblOBS2ConnectedStatus.Text = "Connected Status"
        '
        'chkAlwaysOnTop
        '
        Me.chkAlwaysOnTop.AutoSize = True
        Me.chkAlwaysOnTop.Location = New System.Drawing.Point(7, 130)
        Me.chkAlwaysOnTop.Name = "chkAlwaysOnTop"
        Me.chkAlwaysOnTop.Size = New System.Drawing.Size(98, 17)
        Me.chkAlwaysOnTop.TabIndex = 75
        Me.chkAlwaysOnTop.Text = "Always On Top"
        Me.chkAlwaysOnTop.UseVisualStyleBackColor = True
        '
        'btnResetDatabase
        '
        Me.btnResetDatabase.Location = New System.Drawing.Point(12, 208)
        Me.btnResetDatabase.Name = "btnResetDatabase"
        Me.btnResetDatabase.Size = New System.Drawing.Size(112, 23)
        Me.btnResetDatabase.TabIndex = 87
        Me.btnResetDatabase.Text = "Reset Database"
        Me.btnResetDatabase.UseVisualStyleBackColor = True
        '
        'ofdOpenConfig
        '
        Me.ofdOpenConfig.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rb4Runner)
        Me.Panel1.Controls.Add(Me.rb3Runner)
        Me.Panel1.Controls.Add(Me.rb2Runner)
        Me.Panel1.Controls.Add(Me.rb1Runner)
        Me.Panel1.Location = New System.Drawing.Point(13, 417)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(92, 114)
        Me.Panel1.TabIndex = 122
        '
        'rb4Runner
        '
        Me.rb4Runner.AutoSize = True
        Me.rb4Runner.Location = New System.Drawing.Point(15, 82)
        Me.rb4Runner.Name = "rb4Runner"
        Me.rb4Runner.Size = New System.Drawing.Size(74, 17)
        Me.rb4Runner.TabIndex = 3
        Me.rb4Runner.TabStop = True
        Me.rb4Runner.Text = "4 Runners"
        Me.rb4Runner.UseVisualStyleBackColor = True
        '
        'rb3Runner
        '
        Me.rb3Runner.AutoSize = True
        Me.rb3Runner.Location = New System.Drawing.Point(15, 59)
        Me.rb3Runner.Name = "rb3Runner"
        Me.rb3Runner.Size = New System.Drawing.Size(74, 17)
        Me.rb3Runner.TabIndex = 2
        Me.rb3Runner.TabStop = True
        Me.rb3Runner.Text = "3 Runners"
        Me.rb3Runner.UseVisualStyleBackColor = True
        '
        'rb2Runner
        '
        Me.rb2Runner.AutoSize = True
        Me.rb2Runner.Location = New System.Drawing.Point(15, 36)
        Me.rb2Runner.Name = "rb2Runner"
        Me.rb2Runner.Size = New System.Drawing.Size(74, 17)
        Me.rb2Runner.TabIndex = 1
        Me.rb2Runner.TabStop = True
        Me.rb2Runner.Text = "2 Runners"
        Me.rb2Runner.UseVisualStyleBackColor = True
        '
        'rb1Runner
        '
        Me.rb1Runner.AutoSize = True
        Me.rb1Runner.Location = New System.Drawing.Point(15, 13)
        Me.rb1Runner.Name = "rb1Runner"
        Me.rb1Runner.Size = New System.Drawing.Size(69, 17)
        Me.rb1Runner.TabIndex = 0
        Me.rb1Runner.TabStop = True
        Me.rb1Runner.Text = "1 Runner"
        Me.rb1Runner.UseVisualStyleBackColor = True
        '
        'lblConfigFile
        '
        Me.lblConfigFile.AutoSize = True
        Me.lblConfigFile.Location = New System.Drawing.Point(5, 582)
        Me.lblConfigFile.Name = "lblConfigFile"
        Me.lblConfigFile.Size = New System.Drawing.Size(0, 13)
        Me.lblConfigFile.TabIndex = 123
        '
        'ObsWebSocketCropper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 604)
        Me.Controls.Add(Me.lblConfigFile)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnResetDatabase)
        Me.Controls.Add(Me.btnTestSourceSettings)
        Me.Controls.Add(Me.chkAlwaysOnTop)
        Me.Controls.Add(Me.btnConnectOBS2)
        Me.Controls.Add(Me.lblOBS2ConnectedStatus)
        Me.Controls.Add(Me.btn2ndOBS)
        Me.Controls.Add(Me.btnGetProcesses)
        Me.Controls.Add(Me.btnConnectOBS1)
        Me.Controls.Add(Me.lblOBS1ConnectedStatus)
        Me.Controls.Add(Me.btnSyncWithServer)
        Me.Controls.Add(Me.gbTrackerComms)
        Me.Controls.Add(Me.btnSetTrackCommNames)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "ObsWebSocketCropper"
        Me.Text = "OBS Websocket Cropper"
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.gbTrackerComms.ResumeLayout(False)
        Me.gbTrackerComms.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnectOBS1 As Button
    Friend WithEvents lblCommentary As Label
    Friend WithEvents txtCommentaryNames As TextBox
    Friend WithEvents btnSetTrackCommNames As Button
    Friend WithEvents mnuMainMenu As MenuStrip
    Friend WithEvents ttMainToolTip As ToolTip
    Friend WithEvents gbTrackerComms As GroupBox
    Friend WithEvents btnSyncWithServer As Button
    Friend WithEvents lblOBS1ConnectedStatus As Label
    Friend WithEvents btnGetProcesses As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn2ndOBS As Button
    Friend WithEvents lblOBS2ConnectedStatus As Label
    Friend WithEvents btnConnectOBS2 As Button
    Friend WithEvents chkAlwaysOnTop As CheckBox
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeUserSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeVLCSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpertModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTestSourceSettings As Button
    Friend WithEvents lblGameSettings As Label
    Friend WithEvents txtGameSettings As TextBox
    Friend WithEvents btnResetDatabase As Button
    Friend WithEvents ConfigEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadConfigFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ofdOpenConfig As OpenFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rb4Runner As RadioButton
    Friend WithEvents rb3Runner As RadioButton
    Friend WithEvents rb2Runner As RadioButton
    Friend WithEvents rb1Runner As RadioButton
    Friend WithEvents lblConfigFile As Label
End Class
