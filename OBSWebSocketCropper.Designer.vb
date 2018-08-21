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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSetRightCrop = New System.Windows.Forms.Button()
        Me.txtCropRightGame_Top = New System.Windows.Forms.TextBox()
        Me.txtCropRightGame_Left = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCropRightGame_Right = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCropRightGame_Bottom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnConnectOBS1 = New System.Windows.Forms.Button()
        Me.gbRightGameWindow = New System.Windows.Forms.GroupBox()
        Me.btnRightGameUncrop = New System.Windows.Forms.Button()
        Me.btnRightGameDB = New System.Windows.Forms.Button()
        Me.gbRightTimerWindow = New System.Windows.Forms.GroupBox()
        Me.btnRightTimerUncrop = New System.Windows.Forms.Button()
        Me.btnRightTimerDB = New System.Windows.Forms.Button()
        Me.cbRightScaling = New System.Windows.Forms.ComboBox()
        Me.lblRightScaling = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Top = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Left = New System.Windows.Forms.TextBox()
        Me.txtCropRightTimer_Bottom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Right = New System.Windows.Forms.TextBox()
        Me.gbLeftTimerWindow = New System.Windows.Forms.GroupBox()
        Me.btnLeftTimerUncrop = New System.Windows.Forms.Button()
        Me.btnLeftTimerDB = New System.Windows.Forms.Button()
        Me.cbLeftScaling = New System.Windows.Forms.ComboBox()
        Me.lblLeftScaling = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Top = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Left = New System.Windows.Forms.TextBox()
        Me.txtCropLeftTimer_Bottom = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Right = New System.Windows.Forms.TextBox()
        Me.gbLeftGameWindow = New System.Windows.Forms.GroupBox()
        Me.btnLeftGameUncrop = New System.Windows.Forms.Button()
        Me.btnLeftGameDB = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Top = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Left = New System.Windows.Forms.TextBox()
        Me.txtCropLeftGame_Bottom = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Right = New System.Windows.Forms.TextBox()
        Me.btnSetLeftCrop = New System.Windows.Forms.Button()
        Me.lblLeftRunner = New System.Windows.Forms.Label()
        Me.lblRightRunner = New System.Windows.Forms.Label()
        Me.cbLeftRunnerName = New System.Windows.Forms.ComboBox()
        Me.cbRightRunnerName = New System.Windows.Forms.ComboBox()
        Me.lblLMasterHeight = New System.Windows.Forms.Label()
        Me.lblLMasterWidth = New System.Windows.Forms.Label()
        Me.lblLSourceHeight = New System.Windows.Forms.Label()
        Me.lblLSourceWidth = New System.Windows.Forms.Label()
        Me.lblRSourceWidth = New System.Windows.Forms.Label()
        Me.lblRSourceHeight = New System.Windows.Forms.Label()
        Me.lblRMasterWidth = New System.Windows.Forms.Label()
        Me.lblRMasterHeight = New System.Windows.Forms.Label()
        Me.txtLeftTrackerURL = New System.Windows.Forms.TextBox()
        Me.txtRightTrackerURL = New System.Windows.Forms.TextBox()
        Me.lblLeftTracker = New System.Windows.Forms.Label()
        Me.lblRightTracker = New System.Windows.Forms.Label()
        Me.lblCommentary = New System.Windows.Forms.Label()
        Me.txtCommentaryNames = New System.Windows.Forms.TextBox()
        Me.btnSetTrackCommNames = New System.Windows.Forms.Button()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeUserSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeVLCSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpertModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttMainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSyncWithServer = New System.Windows.Forms.Button()
        Me.btnGetLeftCrop = New System.Windows.Forms.Button()
        Me.btnGetRightCrop = New System.Windows.Forms.Button()
        Me.btnSaveLeftCrop = New System.Windows.Forms.Button()
        Me.btnSaveRightCrop = New System.Windows.Forms.Button()
        Me.btnGetProcesses = New System.Windows.Forms.Button()
        Me.btnSetLeftVLC = New System.Windows.Forms.Button()
        Me.btn2ndOBS = New System.Windows.Forms.Button()
        Me.btnConnectOBS2 = New System.Windows.Forms.Button()
        Me.btnSetRightVLC = New System.Windows.Forms.Button()
        Me.btnNewLeftRunner = New System.Windows.Forms.Button()
        Me.btnNewRightRunner = New System.Windows.Forms.Button()
        Me.btnTestSourceSettings = New System.Windows.Forms.Button()
        Me.btnNewRightRunner_Bottom = New System.Windows.Forms.Button()
        Me.btnNewLeftRunner_Bottom = New System.Windows.Forms.Button()
        Me.btnSetRightVLC_Bottom = New System.Windows.Forms.Button()
        Me.btnSetLeftVLC_Bottom = New System.Windows.Forms.Button()
        Me.btnSaveRightCrop_Bottom = New System.Windows.Forms.Button()
        Me.btnSaveLeftCrop_Bottom = New System.Windows.Forms.Button()
        Me.btnGetRightCrop_Bottom = New System.Windows.Forms.Button()
        Me.btnGetLeftCrop_Bottom = New System.Windows.Forms.Button()
        Me.btnSetLeftCrop_Bottom = New System.Windows.Forms.Button()
        Me.btnLeftTimerUncrop_Bottom = New System.Windows.Forms.Button()
        Me.btnLeftTimerDB_Bottom = New System.Windows.Forms.Button()
        Me.btnLeftGameUncrop_Bottom = New System.Windows.Forms.Button()
        Me.btnLeftGameDB_Bottom = New System.Windows.Forms.Button()
        Me.btnRightTimerUncrop_Bottom = New System.Windows.Forms.Button()
        Me.btnRightTimerDB_Bottom = New System.Windows.Forms.Button()
        Me.btnRightGameUncrop_Bottom = New System.Windows.Forms.Button()
        Me.btnRightGameDB_Bottom = New System.Windows.Forms.Button()
        Me.btnSetRightCrop_Bottom = New System.Windows.Forms.Button()
        Me.gbTrackerComms = New System.Windows.Forms.GroupBox()
        Me.txtLeftTrackerURL_Bottom = New System.Windows.Forms.TextBox()
        Me.txtRightTrackerURL_Bottom = New System.Windows.Forms.TextBox()
        Me.lblRightTracker_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftTracker_Bottom = New System.Windows.Forms.Label()
        Me.lblGameSettings = New System.Windows.Forms.Label()
        Me.txtGameSettings = New System.Windows.Forms.TextBox()
        Me.lblOBS1ConnectedStatus = New System.Windows.Forms.Label()
        Me.cbRightVLCSource = New System.Windows.Forms.ComboBox()
        Me.cbLeftVLCSource = New System.Windows.Forms.ComboBox()
        Me.lblRightVLC = New System.Windows.Forms.Label()
        Me.lblLeftVLC = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblOBS2ConnectedStatus = New System.Windows.Forms.Label()
        Me.chkAlwaysOnTop = New System.Windows.Forms.CheckBox()
        Me.lblViewLeftOnTwitch = New System.Windows.Forms.Label()
        Me.lblLeftVOD = New System.Windows.Forms.Label()
        Me.lblViewRightOnTwitch = New System.Windows.Forms.Label()
        Me.lblRightVOD = New System.Windows.Forms.Label()
        Me.lblLeftStreamlink = New System.Windows.Forms.Label()
        Me.lblRightStreamlink = New System.Windows.Forms.Label()
        Me.lblLeftRunnerTwitch = New System.Windows.Forms.Label()
        Me.lblRightRunnerTwitch = New System.Windows.Forms.Label()
        Me.btnResetDatabase = New System.Windows.Forms.Button()
        Me.lblRightRunnerTwitch_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftRunnerTwitch_Bottom = New System.Windows.Forms.Label()
        Me.lblRightStreamlink_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftStreamlink_Bottom = New System.Windows.Forms.Label()
        Me.lblRightVOD_Bottom = New System.Windows.Forms.Label()
        Me.lblViewRightOnTwitch_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftVOD_Bottom = New System.Windows.Forms.Label()
        Me.lblViewLeftOnTwitch_Bottom = New System.Windows.Forms.Label()
        Me.cbRightVLCSource_Bottom = New System.Windows.Forms.ComboBox()
        Me.cbLeftVLCSource_Bottom = New System.Windows.Forms.ComboBox()
        Me.lblRightVLC_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftVLC_Bottom = New System.Windows.Forms.Label()
        Me.cbRightRunnerName_Bottom = New System.Windows.Forms.ComboBox()
        Me.cbLeftRunnerName_Bottom = New System.Windows.Forms.ComboBox()
        Me.lblRightRunner_Bottom = New System.Windows.Forms.Label()
        Me.lblLeftRunner_Bottom = New System.Windows.Forms.Label()
        Me.gbLeftTimerWindow_Bottom = New System.Windows.Forms.GroupBox()
        Me.cbLeftScaling_Bottom = New System.Windows.Forms.ComboBox()
        Me.lblLeftScaling_Bottom = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Top_BR = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Left_BR = New System.Windows.Forms.TextBox()
        Me.txtCropLeftTimer_Bottom_BR = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Right_BR = New System.Windows.Forms.TextBox()
        Me.gbLeftGameWindow_Bottom = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Top_BR = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Left_BR = New System.Windows.Forms.TextBox()
        Me.txtCropLeftGame_Bottom_BR = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Right_BR = New System.Windows.Forms.TextBox()
        Me.gbRightTimerWindow_Bottom = New System.Windows.Forms.GroupBox()
        Me.cbRightScaling_Bottom = New System.Windows.Forms.ComboBox()
        Me.lblRightScaling_Bottom = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Top_BR = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Left_BR = New System.Windows.Forms.TextBox()
        Me.txtCropRightTimer_Bottom_BR = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Right_BR = New System.Windows.Forms.TextBox()
        Me.gbRightGameWindow_Bottom = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtCropRightGame_Top_BR = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtCropRightGame_Left_BR = New System.Windows.Forms.TextBox()
        Me.txtCropRightGame_Bottom_BR = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtCropRightGame_Right_BR = New System.Windows.Forms.TextBox()
        Me.pnlFourPlayer = New System.Windows.Forms.Panel()
        Me.pnlFourPlayerTracker = New System.Windows.Forms.Panel()
        Me.gbRightGameWindow.SuspendLayout()
        Me.gbRightTimerWindow.SuspendLayout()
        Me.gbLeftTimerWindow.SuspendLayout()
        Me.gbLeftGameWindow.SuspendLayout()
        Me.mnuMainMenu.SuspendLayout()
        Me.gbTrackerComms.SuspendLayout()
        Me.gbLeftTimerWindow_Bottom.SuspendLayout()
        Me.gbLeftGameWindow_Bottom.SuspendLayout()
        Me.gbRightTimerWindow_Bottom.SuspendLayout()
        Me.gbRightGameWindow_Bottom.SuspendLayout()
        Me.pnlFourPlayer.SuspendLayout()
        Me.pnlFourPlayerTracker.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Top"
        '
        'btnSetRightCrop
        '
        Me.btnSetRightCrop.BackColor = System.Drawing.Color.MistyRose
        Me.btnSetRightCrop.Location = New System.Drawing.Point(509, 537)
        Me.btnSetRightCrop.Name = "btnSetRightCrop"
        Me.btnSetRightCrop.Size = New System.Drawing.Size(123, 23)
        Me.btnSetRightCrop.TabIndex = 6
        Me.btnSetRightCrop.Text = "Set Right Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetRightCrop, "Set the crop for the right side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetRightCrop.UseVisualStyleBackColor = False
        '
        'txtCropRightGame_Top
        '
        Me.txtCropRightGame_Top.Location = New System.Drawing.Point(39, 91)
        Me.txtCropRightGame_Top.Name = "txtCropRightGame_Top"
        Me.txtCropRightGame_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Top.TabIndex = 7
        '
        'txtCropRightGame_Left
        '
        Me.txtCropRightGame_Left.Location = New System.Drawing.Point(39, 55)
        Me.txtCropRightGame_Left.Name = "txtCropRightGame_Left"
        Me.txtCropRightGame_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Left.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Left"
        '
        'txtCropRightGame_Right
        '
        Me.txtCropRightGame_Right.Location = New System.Drawing.Point(196, 58)
        Me.txtCropRightGame_Right.Name = "txtCropRightGame_Right"
        Me.txtCropRightGame_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Right.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Right"
        '
        'txtCropRightGame_Bottom
        '
        Me.txtCropRightGame_Bottom.Location = New System.Drawing.Point(196, 94)
        Me.txtCropRightGame_Bottom.Name = "txtCropRightGame_Bottom"
        Me.txtCropRightGame_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Bottom.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Bottom"
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
        'gbRightGameWindow
        '
        Me.gbRightGameWindow.BackColor = System.Drawing.Color.MistyRose
        Me.gbRightGameWindow.Controls.Add(Me.btnRightGameUncrop)
        Me.gbRightGameWindow.Controls.Add(Me.btnRightGameDB)
        Me.gbRightGameWindow.Controls.Add(Me.Label1)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Top)
        Me.gbRightGameWindow.Controls.Add(Me.Label2)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Left)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Bottom)
        Me.gbRightGameWindow.Controls.Add(Me.Label3)
        Me.gbRightGameWindow.Controls.Add(Me.Label4)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Right)
        Me.gbRightGameWindow.Location = New System.Drawing.Point(509, 413)
        Me.gbRightGameWindow.Name = "gbRightGameWindow"
        Me.gbRightGameWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbRightGameWindow.TabIndex = 5
        Me.gbRightGameWindow.TabStop = False
        Me.gbRightGameWindow.Text = "Right Game Window"
        '
        'btnRightGameUncrop
        '
        Me.btnRightGameUncrop.Location = New System.Drawing.Point(145, 19)
        Me.btnRightGameUncrop.Name = "btnRightGameUncrop"
        Me.btnRightGameUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnRightGameUncrop.TabIndex = 93
        Me.btnRightGameUncrop.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnRightGameUncrop, "Sets OBS to 0 crop for the game")
        Me.btnRightGameUncrop.UseVisualStyleBackColor = True
        '
        'btnRightGameDB
        '
        Me.btnRightGameDB.Location = New System.Drawing.Point(40, 19)
        Me.btnRightGameDB.Name = "btnRightGameDB"
        Me.btnRightGameDB.Size = New System.Drawing.Size(52, 23)
        Me.btnRightGameDB.TabIndex = 88
        Me.btnRightGameDB.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnRightGameDB, "Resets the game data to what the current DB has")
        Me.btnRightGameDB.UseVisualStyleBackColor = True
        '
        'gbRightTimerWindow
        '
        Me.gbRightTimerWindow.BackColor = System.Drawing.Color.MistyRose
        Me.gbRightTimerWindow.Controls.Add(Me.btnRightTimerUncrop)
        Me.gbRightTimerWindow.Controls.Add(Me.btnRightTimerDB)
        Me.gbRightTimerWindow.Controls.Add(Me.cbRightScaling)
        Me.gbRightTimerWindow.Controls.Add(Me.lblRightScaling)
        Me.gbRightTimerWindow.Controls.Add(Me.Label7)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Top)
        Me.gbRightTimerWindow.Controls.Add(Me.Label8)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Left)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Bottom)
        Me.gbRightTimerWindow.Controls.Add(Me.Label9)
        Me.gbRightTimerWindow.Controls.Add(Me.Label10)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Right)
        Me.gbRightTimerWindow.Location = New System.Drawing.Point(509, 287)
        Me.gbRightTimerWindow.Name = "gbRightTimerWindow"
        Me.gbRightTimerWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbRightTimerWindow.TabIndex = 4
        Me.gbRightTimerWindow.TabStop = False
        Me.gbRightTimerWindow.Text = "Right Timer Window"
        '
        'btnRightTimerUncrop
        '
        Me.btnRightTimerUncrop.Location = New System.Drawing.Point(145, 20)
        Me.btnRightTimerUncrop.Name = "btnRightTimerUncrop"
        Me.btnRightTimerUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnRightTimerUncrop.TabIndex = 92
        Me.btnRightTimerUncrop.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnRightTimerUncrop, "Sets OBS to 0 crop for the timer")
        Me.btnRightTimerUncrop.UseVisualStyleBackColor = True
        '
        'btnRightTimerDB
        '
        Me.btnRightTimerDB.Location = New System.Drawing.Point(39, 19)
        Me.btnRightTimerDB.Name = "btnRightTimerDB"
        Me.btnRightTimerDB.Size = New System.Drawing.Size(52, 23)
        Me.btnRightTimerDB.TabIndex = 91
        Me.btnRightTimerDB.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnRightTimerDB, "Resets the timer data to what the current DB has")
        Me.btnRightTimerDB.UseVisualStyleBackColor = True
        '
        'cbRightScaling
        '
        Me.cbRightScaling.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightScaling.FormattingEnabled = True
        Me.cbRightScaling.Items.AddRange(New Object() {"100%", "125%", "150%", "175%", "200%", "225%", "250%", "275%", "300%"})
        Me.cbRightScaling.Location = New System.Drawing.Point(242, 0)
        Me.cbRightScaling.Name = "cbRightScaling"
        Me.cbRightScaling.Size = New System.Drawing.Size(54, 23)
        Me.cbRightScaling.TabIndex = 90
        Me.cbRightScaling.Text = "100%"
        '
        'lblRightScaling
        '
        Me.lblRightScaling.AutoSize = True
        Me.lblRightScaling.Location = New System.Drawing.Point(193, 4)
        Me.lblRightScaling.Name = "lblRightScaling"
        Me.lblRightScaling.Size = New System.Drawing.Size(45, 13)
        Me.lblRightScaling.TabIndex = 89
        Me.lblRightScaling.Text = "Scaling:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Top"
        '
        'txtCropRightTimer_Top
        '
        Me.txtCropRightTimer_Top.Location = New System.Drawing.Point(39, 82)
        Me.txtCropRightTimer_Top.Name = "txtCropRightTimer_Top"
        Me.txtCropRightTimer_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Top.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Left"
        '
        'txtCropRightTimer_Left
        '
        Me.txtCropRightTimer_Left.Location = New System.Drawing.Point(39, 46)
        Me.txtCropRightTimer_Left.Name = "txtCropRightTimer_Left"
        Me.txtCropRightTimer_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Left.TabIndex = 3
        '
        'txtCropRightTimer_Bottom
        '
        Me.txtCropRightTimer_Bottom.Location = New System.Drawing.Point(196, 85)
        Me.txtCropRightTimer_Bottom.Name = "txtCropRightTimer_Bottom"
        Me.txtCropRightTimer_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Bottom.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(158, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Right"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(158, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Bottom"
        '
        'txtCropRightTimer_Right
        '
        Me.txtCropRightTimer_Right.Location = New System.Drawing.Point(196, 49)
        Me.txtCropRightTimer_Right.Name = "txtCropRightTimer_Right"
        Me.txtCropRightTimer_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Right.TabIndex = 5
        '
        'gbLeftTimerWindow
        '
        Me.gbLeftTimerWindow.BackColor = System.Drawing.Color.PaleGreen
        Me.gbLeftTimerWindow.Controls.Add(Me.btnLeftTimerUncrop)
        Me.gbLeftTimerWindow.Controls.Add(Me.btnLeftTimerDB)
        Me.gbLeftTimerWindow.Controls.Add(Me.cbLeftScaling)
        Me.gbLeftTimerWindow.Controls.Add(Me.lblLeftScaling)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label12)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Top)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label13)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Left)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Bottom)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label14)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label15)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Right)
        Me.gbLeftTimerWindow.Location = New System.Drawing.Point(169, 287)
        Me.gbLeftTimerWindow.Name = "gbLeftTimerWindow"
        Me.gbLeftTimerWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftTimerWindow.TabIndex = 1
        Me.gbLeftTimerWindow.TabStop = False
        Me.gbLeftTimerWindow.Text = "Left Timer Window"
        '
        'btnLeftTimerUncrop
        '
        Me.btnLeftTimerUncrop.Location = New System.Drawing.Point(145, 17)
        Me.btnLeftTimerUncrop.Name = "btnLeftTimerUncrop"
        Me.btnLeftTimerUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnLeftTimerUncrop.TabIndex = 91
        Me.btnLeftTimerUncrop.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftTimerUncrop, "Sets OBS to 0 crop for the timer")
        Me.btnLeftTimerUncrop.UseVisualStyleBackColor = True
        '
        'btnLeftTimerDB
        '
        Me.btnLeftTimerDB.Location = New System.Drawing.Point(39, 19)
        Me.btnLeftTimerDB.Name = "btnLeftTimerDB"
        Me.btnLeftTimerDB.Size = New System.Drawing.Size(52, 23)
        Me.btnLeftTimerDB.TabIndex = 87
        Me.btnLeftTimerDB.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftTimerDB, "Resets the timer data to what the current DB has")
        Me.btnLeftTimerDB.UseVisualStyleBackColor = True
        '
        'cbLeftScaling
        '
        Me.cbLeftScaling.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftScaling.FormattingEnabled = True
        Me.cbLeftScaling.Items.AddRange(New Object() {"100%", "125%", "150%", "175%", "200%", "225%", "250%", "275%", "300%"})
        Me.cbLeftScaling.Location = New System.Drawing.Point(242, 0)
        Me.cbLeftScaling.Name = "cbLeftScaling"
        Me.cbLeftScaling.Size = New System.Drawing.Size(54, 23)
        Me.cbLeftScaling.TabIndex = 88
        Me.cbLeftScaling.Text = "100%"
        '
        'lblLeftScaling
        '
        Me.lblLeftScaling.AutoSize = True
        Me.lblLeftScaling.Location = New System.Drawing.Point(193, 4)
        Me.lblLeftScaling.Name = "lblLeftScaling"
        Me.lblLeftScaling.Size = New System.Drawing.Size(45, 13)
        Me.lblLeftScaling.TabIndex = 87
        Me.lblLeftScaling.Text = "Scaling:"
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
        'txtCropLeftTimer_Top
        '
        Me.txtCropLeftTimer_Top.Location = New System.Drawing.Point(39, 79)
        Me.txtCropLeftTimer_Top.Name = "txtCropLeftTimer_Top"
        Me.txtCropLeftTimer_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Top.TabIndex = 7
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
        'txtCropLeftTimer_Left
        '
        Me.txtCropLeftTimer_Left.Location = New System.Drawing.Point(39, 43)
        Me.txtCropLeftTimer_Left.Name = "txtCropLeftTimer_Left"
        Me.txtCropLeftTimer_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Left.TabIndex = 3
        '
        'txtCropLeftTimer_Bottom
        '
        Me.txtCropLeftTimer_Bottom.Location = New System.Drawing.Point(196, 82)
        Me.txtCropLeftTimer_Bottom.Name = "txtCropLeftTimer_Bottom"
        Me.txtCropLeftTimer_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Bottom.TabIndex = 9
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
        'txtCropLeftTimer_Right
        '
        Me.txtCropLeftTimer_Right.Location = New System.Drawing.Point(196, 46)
        Me.txtCropLeftTimer_Right.Name = "txtCropLeftTimer_Right"
        Me.txtCropLeftTimer_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Right.TabIndex = 5
        '
        'gbLeftGameWindow
        '
        Me.gbLeftGameWindow.BackColor = System.Drawing.Color.PaleGreen
        Me.gbLeftGameWindow.Controls.Add(Me.btnLeftGameUncrop)
        Me.gbLeftGameWindow.Controls.Add(Me.btnLeftGameDB)
        Me.gbLeftGameWindow.Controls.Add(Me.Label17)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Top)
        Me.gbLeftGameWindow.Controls.Add(Me.Label18)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Left)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Bottom)
        Me.gbLeftGameWindow.Controls.Add(Me.Label19)
        Me.gbLeftGameWindow.Controls.Add(Me.Label20)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Right)
        Me.gbLeftGameWindow.Location = New System.Drawing.Point(169, 413)
        Me.gbLeftGameWindow.Name = "gbLeftGameWindow"
        Me.gbLeftGameWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftGameWindow.TabIndex = 2
        Me.gbLeftGameWindow.TabStop = False
        Me.gbLeftGameWindow.Text = "Left Game Window"
        '
        'btnLeftGameUncrop
        '
        Me.btnLeftGameUncrop.Location = New System.Drawing.Point(145, 19)
        Me.btnLeftGameUncrop.Name = "btnLeftGameUncrop"
        Me.btnLeftGameUncrop.Size = New System.Drawing.Size(53, 23)
        Me.btnLeftGameUncrop.TabIndex = 90
        Me.btnLeftGameUncrop.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftGameUncrop, "Sets OBS to 0 crop for the game")
        Me.btnLeftGameUncrop.UseVisualStyleBackColor = True
        '
        'btnLeftGameDB
        '
        Me.btnLeftGameDB.Location = New System.Drawing.Point(39, 19)
        Me.btnLeftGameDB.Name = "btnLeftGameDB"
        Me.btnLeftGameDB.Size = New System.Drawing.Size(52, 23)
        Me.btnLeftGameDB.TabIndex = 89
        Me.btnLeftGameDB.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftGameDB, "Resets the game data to what the current DB has")
        Me.btnLeftGameDB.UseVisualStyleBackColor = True
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
        'txtCropLeftGame_Top
        '
        Me.txtCropLeftGame_Top.Location = New System.Drawing.Point(39, 94)
        Me.txtCropLeftGame_Top.Name = "txtCropLeftGame_Top"
        Me.txtCropLeftGame_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Top.TabIndex = 7
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
        'txtCropLeftGame_Left
        '
        Me.txtCropLeftGame_Left.Location = New System.Drawing.Point(39, 58)
        Me.txtCropLeftGame_Left.Name = "txtCropLeftGame_Left"
        Me.txtCropLeftGame_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Left.TabIndex = 3
        '
        'txtCropLeftGame_Bottom
        '
        Me.txtCropLeftGame_Bottom.Location = New System.Drawing.Point(196, 97)
        Me.txtCropLeftGame_Bottom.Name = "txtCropLeftGame_Bottom"
        Me.txtCropLeftGame_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Bottom.TabIndex = 9
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
        'txtCropLeftGame_Right
        '
        Me.txtCropLeftGame_Right.Location = New System.Drawing.Point(196, 61)
        Me.txtCropLeftGame_Right.Name = "txtCropLeftGame_Right"
        Me.txtCropLeftGame_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Right.TabIndex = 5
        '
        'btnSetLeftCrop
        '
        Me.btnSetLeftCrop.BackColor = System.Drawing.Color.PaleGreen
        Me.btnSetLeftCrop.Location = New System.Drawing.Point(169, 537)
        Me.btnSetLeftCrop.Name = "btnSetLeftCrop"
        Me.btnSetLeftCrop.Size = New System.Drawing.Size(116, 23)
        Me.btnSetLeftCrop.TabIndex = 3
        Me.btnSetLeftCrop.Text = "Set Left Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetLeftCrop, "Set the crop for the left side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetLeftCrop.UseVisualStyleBackColor = False
        '
        'lblLeftRunner
        '
        Me.lblLeftRunner.AutoSize = True
        Me.lblLeftRunner.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblLeftRunner.Location = New System.Drawing.Point(153, 143)
        Me.lblLeftRunner.Name = "lblLeftRunner"
        Me.lblLeftRunner.Size = New System.Drawing.Size(94, 13)
        Me.lblLeftRunner.TabIndex = 14
        Me.lblLeftRunner.Text = "Left Runner Name"
        '
        'lblRightRunner
        '
        Me.lblRightRunner.AutoSize = True
        Me.lblRightRunner.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblRightRunner.Location = New System.Drawing.Point(487, 143)
        Me.lblRightRunner.Name = "lblRightRunner"
        Me.lblRightRunner.Size = New System.Drawing.Size(101, 13)
        Me.lblRightRunner.TabIndex = 22
        Me.lblRightRunner.Text = "Right Runner Name"
        '
        'cbLeftRunnerName
        '
        Me.cbLeftRunnerName.DisplayMember = "RacerName"
        Me.cbLeftRunnerName.FormattingEnabled = True
        Me.cbLeftRunnerName.Location = New System.Drawing.Point(246, 140)
        Me.cbLeftRunnerName.Name = "cbLeftRunnerName"
        Me.cbLeftRunnerName.Size = New System.Drawing.Size(228, 21)
        Me.cbLeftRunnerName.TabIndex = 14
        Me.cbLeftRunnerName.ValueMember = "RacerName"
        '
        'cbRightRunnerName
        '
        Me.cbRightRunnerName.DisplayMember = "RacerName"
        Me.cbRightRunnerName.FormattingEnabled = True
        Me.cbRightRunnerName.Location = New System.Drawing.Point(588, 140)
        Me.cbRightRunnerName.Name = "cbRightRunnerName"
        Me.cbRightRunnerName.Size = New System.Drawing.Size(228, 21)
        Me.cbRightRunnerName.TabIndex = 26
        Me.cbRightRunnerName.ValueMember = "RacerName"
        '
        'lblLMasterHeight
        '
        Me.lblLMasterHeight.AutoSize = True
        Me.lblLMasterHeight.Location = New System.Drawing.Point(4, 423)
        Me.lblLMasterHeight.Name = "lblLMasterHeight"
        Me.lblLMasterHeight.Size = New System.Drawing.Size(73, 13)
        Me.lblLMasterHeight.TabIndex = 34
        Me.lblLMasterHeight.Text = "Master Height"
        Me.lblLMasterHeight.Visible = False
        '
        'lblLMasterWidth
        '
        Me.lblLMasterWidth.AutoSize = True
        Me.lblLMasterWidth.Location = New System.Drawing.Point(4, 444)
        Me.lblLMasterWidth.Name = "lblLMasterWidth"
        Me.lblLMasterWidth.Size = New System.Drawing.Size(70, 13)
        Me.lblLMasterWidth.TabIndex = 35
        Me.lblLMasterWidth.Text = "Master Width"
        Me.lblLMasterWidth.Visible = False
        '
        'lblLSourceHeight
        '
        Me.lblLSourceHeight.AutoSize = True
        Me.lblLSourceHeight.Location = New System.Drawing.Point(4, 464)
        Me.lblLSourceHeight.Name = "lblLSourceHeight"
        Me.lblLSourceHeight.Size = New System.Drawing.Size(75, 13)
        Me.lblLSourceHeight.TabIndex = 36
        Me.lblLSourceHeight.Text = "Source Height"
        Me.lblLSourceHeight.Visible = False
        '
        'lblLSourceWidth
        '
        Me.lblLSourceWidth.AutoSize = True
        Me.lblLSourceWidth.Location = New System.Drawing.Point(4, 485)
        Me.lblLSourceWidth.Name = "lblLSourceWidth"
        Me.lblLSourceWidth.Size = New System.Drawing.Size(72, 13)
        Me.lblLSourceWidth.TabIndex = 37
        Me.lblLSourceWidth.Text = "Source Width"
        Me.lblLSourceWidth.Visible = False
        '
        'lblRSourceWidth
        '
        Me.lblRSourceWidth.AutoSize = True
        Me.lblRSourceWidth.Location = New System.Drawing.Point(90, 485)
        Me.lblRSourceWidth.Name = "lblRSourceWidth"
        Me.lblRSourceWidth.Size = New System.Drawing.Size(72, 13)
        Me.lblRSourceWidth.TabIndex = 41
        Me.lblRSourceWidth.Text = "Source Width"
        Me.lblRSourceWidth.Visible = False
        '
        'lblRSourceHeight
        '
        Me.lblRSourceHeight.AutoSize = True
        Me.lblRSourceHeight.Location = New System.Drawing.Point(90, 487)
        Me.lblRSourceHeight.Name = "lblRSourceHeight"
        Me.lblRSourceHeight.Size = New System.Drawing.Size(75, 13)
        Me.lblRSourceHeight.TabIndex = 40
        Me.lblRSourceHeight.Text = "Source Height"
        Me.lblRSourceHeight.Visible = False
        '
        'lblRMasterWidth
        '
        Me.lblRMasterWidth.AutoSize = True
        Me.lblRMasterWidth.Location = New System.Drawing.Point(90, 444)
        Me.lblRMasterWidth.Name = "lblRMasterWidth"
        Me.lblRMasterWidth.Size = New System.Drawing.Size(70, 13)
        Me.lblRMasterWidth.TabIndex = 39
        Me.lblRMasterWidth.Text = "Master Width"
        Me.lblRMasterWidth.Visible = False
        '
        'lblRMasterHeight
        '
        Me.lblRMasterHeight.AutoSize = True
        Me.lblRMasterHeight.Location = New System.Drawing.Point(90, 446)
        Me.lblRMasterHeight.Name = "lblRMasterHeight"
        Me.lblRMasterHeight.Size = New System.Drawing.Size(73, 13)
        Me.lblRMasterHeight.TabIndex = 38
        Me.lblRMasterHeight.Text = "Master Height"
        Me.lblRMasterHeight.Visible = False
        '
        'txtLeftTrackerURL
        '
        Me.txtLeftTrackerURL.Location = New System.Drawing.Point(117, 76)
        Me.txtLeftTrackerURL.Name = "txtLeftTrackerURL"
        Me.txtLeftTrackerURL.Size = New System.Drawing.Size(190, 20)
        Me.txtLeftTrackerURL.TabIndex = 31
        '
        'txtRightTrackerURL
        '
        Me.txtRightTrackerURL.Location = New System.Drawing.Point(442, 76)
        Me.txtRightTrackerURL.Name = "txtRightTrackerURL"
        Me.txtRightTrackerURL.Size = New System.Drawing.Size(189, 20)
        Me.txtRightTrackerURL.TabIndex = 48
        '
        'lblLeftTracker
        '
        Me.lblLeftTracker.AutoSize = True
        Me.lblLeftTracker.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblLeftTracker.Location = New System.Drawing.Point(9, 79)
        Me.lblLeftTracker.Name = "lblLeftTracker"
        Me.lblLeftTracker.Size = New System.Drawing.Size(90, 13)
        Me.lblLeftTracker.TabIndex = 49
        Me.lblLeftTracker.Text = "Left Tracker URL"
        '
        'lblRightTracker
        '
        Me.lblRightTracker.AutoSize = True
        Me.lblRightTracker.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblRightTracker.Location = New System.Drawing.Point(339, 79)
        Me.lblRightTracker.Name = "lblRightTracker"
        Me.lblRightTracker.Size = New System.Drawing.Size(97, 13)
        Me.lblRightTracker.TabIndex = 50
        Me.lblRightTracker.Text = "Right Tracker URL"
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
        Me.mnuMainMenu.Size = New System.Drawing.Size(1507, 24)
        Me.mnuMainMenu.TabIndex = 57
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeUserSettingsToolStripMenuItem, Me.ChangeVLCSettingsToolStripMenuItem, Me.ExpertModeToolStripMenuItem, Me.PlayersToolStripMenuItem, Me.ExitToolStripMenuItem})
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
        'ExpertModeToolStripMenuItem
        '
        Me.ExpertModeToolStripMenuItem.CheckOnClick = True
        Me.ExpertModeToolStripMenuItem.Name = "ExpertModeToolStripMenuItem"
        Me.ExpertModeToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ExpertModeToolStripMenuItem.Text = "Expert Mode"
        '
        'PlayersToolStripMenuItem
        '
        Me.PlayersToolStripMenuItem.CheckOnClick = True
        Me.PlayersToolStripMenuItem.Name = "PlayersToolStripMenuItem"
        Me.PlayersToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.PlayersToolStripMenuItem.Text = "4 Players"
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
        'btnGetLeftCrop
        '
        Me.btnGetLeftCrop.Location = New System.Drawing.Point(295, 537)
        Me.btnGetLeftCrop.Name = "btnGetLeftCrop"
        Me.btnGetLeftCrop.Size = New System.Drawing.Size(79, 23)
        Me.btnGetLeftCrop.TabIndex = 61
        Me.btnGetLeftCrop.Text = "Get Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnGetLeftCrop, "Get the current OBS crop settings for the left side")
        Me.btnGetLeftCrop.UseVisualStyleBackColor = True
        '
        'btnGetRightCrop
        '
        Me.btnGetRightCrop.Location = New System.Drawing.Point(638, 537)
        Me.btnGetRightCrop.Name = "btnGetRightCrop"
        Me.btnGetRightCrop.Size = New System.Drawing.Size(76, 23)
        Me.btnGetRightCrop.TabIndex = 62
        Me.btnGetRightCrop.Text = "Get Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnGetRightCrop, "Get the current OBS crop settings for the right side")
        Me.btnGetRightCrop.UseVisualStyleBackColor = True
        '
        'btnSaveLeftCrop
        '
        Me.btnSaveLeftCrop.Location = New System.Drawing.Point(380, 537)
        Me.btnSaveLeftCrop.Name = "btnSaveLeftCrop"
        Me.btnSaveLeftCrop.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveLeftCrop.TabIndex = 63
        Me.btnSaveLeftCrop.Text = "Save Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveLeftCrop, "Saves the current crop numbers to the database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the left side")
        Me.btnSaveLeftCrop.UseVisualStyleBackColor = True
        '
        'btnSaveRightCrop
        '
        Me.btnSaveRightCrop.Location = New System.Drawing.Point(720, 537)
        Me.btnSaveRightCrop.Name = "btnSaveRightCrop"
        Me.btnSaveRightCrop.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveRightCrop.TabIndex = 64
        Me.btnSaveRightCrop.Text = "Save Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveRightCrop, "Saves the current crop numbers to the database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the right side")
        Me.btnSaveRightCrop.UseVisualStyleBackColor = True
        '
        'btnGetProcesses
        '
        Me.btnGetProcesses.Location = New System.Drawing.Point(342, 242)
        Me.btnGetProcesses.Name = "btnGetProcesses"
        Me.btnGetProcesses.Size = New System.Drawing.Size(114, 23)
        Me.btnGetProcesses.TabIndex = 65
        Me.btnGetProcesses.Text = "Get Processes"
        Me.ttMainToolTip.SetToolTip(Me.btnGetProcesses, "Gets the currently running VLC processes and fills the dropdowns")
        Me.btnGetProcesses.UseVisualStyleBackColor = True
        '
        'btnSetLeftVLC
        '
        Me.btnSetLeftVLC.BackColor = System.Drawing.Color.GreenYellow
        Me.btnSetLeftVLC.Location = New System.Drawing.Point(167, 242)
        Me.btnSetLeftVLC.Name = "btnSetLeftVLC"
        Me.btnSetLeftVLC.Size = New System.Drawing.Size(116, 23)
        Me.btnSetLeftVLC.TabIndex = 70
        Me.btnSetLeftVLC.Text = "Set Left VLC"
        Me.ttMainToolTip.SetToolTip(Me.btnSetLeftVLC, "Sets the left game/timer window VLC to the above dropdown")
        Me.btnSetLeftVLC.UseVisualStyleBackColor = False
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
        'btnSetRightVLC
        '
        Me.btnSetRightVLC.BackColor = System.Drawing.Color.PeachPuff
        Me.btnSetRightVLC.Location = New System.Drawing.Point(485, 242)
        Me.btnSetRightVLC.Name = "btnSetRightVLC"
        Me.btnSetRightVLC.Size = New System.Drawing.Size(116, 23)
        Me.btnSetRightVLC.TabIndex = 74
        Me.btnSetRightVLC.Text = "Set Right VLC"
        Me.ttMainToolTip.SetToolTip(Me.btnSetRightVLC, "Sets the left game/timer window VLC to the above dropdown")
        Me.btnSetRightVLC.UseVisualStyleBackColor = False
        '
        'btnNewLeftRunner
        '
        Me.btnNewLeftRunner.Location = New System.Drawing.Point(362, 181)
        Me.btnNewLeftRunner.Name = "btnNewLeftRunner"
        Me.btnNewLeftRunner.Size = New System.Drawing.Size(114, 23)
        Me.btnNewLeftRunner.TabIndex = 76
        Me.btnNewLeftRunner.Text = "New Runner"
        Me.ttMainToolTip.SetToolTip(Me.btnNewLeftRunner, "Pop-up form to easily add the runner information")
        Me.btnNewLeftRunner.UseVisualStyleBackColor = True
        '
        'btnNewRightRunner
        '
        Me.btnNewRightRunner.Location = New System.Drawing.Point(702, 186)
        Me.btnNewRightRunner.Name = "btnNewRightRunner"
        Me.btnNewRightRunner.Size = New System.Drawing.Size(114, 23)
        Me.btnNewRightRunner.TabIndex = 77
        Me.btnNewRightRunner.Text = "New Runner"
        Me.ttMainToolTip.SetToolTip(Me.btnNewRightRunner, "Pop-up form to easily add the runner information")
        Me.btnNewRightRunner.UseVisualStyleBackColor = True
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
        'btnNewRightRunner_Bottom
        '
        Me.btnNewRightRunner_Bottom.Location = New System.Drawing.Point(556, 47)
        Me.btnNewRightRunner_Bottom.Name = "btnNewRightRunner_Bottom"
        Me.btnNewRightRunner_Bottom.Size = New System.Drawing.Size(114, 23)
        Me.btnNewRightRunner_Bottom.TabIndex = 110
        Me.btnNewRightRunner_Bottom.Text = "New Runner"
        Me.ttMainToolTip.SetToolTip(Me.btnNewRightRunner_Bottom, "Pop-up form to easily add the runner information")
        Me.btnNewRightRunner_Bottom.UseVisualStyleBackColor = True
        '
        'btnNewLeftRunner_Bottom
        '
        Me.btnNewLeftRunner_Bottom.Location = New System.Drawing.Point(216, 42)
        Me.btnNewLeftRunner_Bottom.Name = "btnNewLeftRunner_Bottom"
        Me.btnNewLeftRunner_Bottom.Size = New System.Drawing.Size(114, 23)
        Me.btnNewLeftRunner_Bottom.TabIndex = 109
        Me.btnNewLeftRunner_Bottom.Text = "New Runner"
        Me.ttMainToolTip.SetToolTip(Me.btnNewLeftRunner_Bottom, "Pop-up form to easily add the runner information")
        Me.btnNewLeftRunner_Bottom.UseVisualStyleBackColor = True
        '
        'btnSetRightVLC_Bottom
        '
        Me.btnSetRightVLC_Bottom.BackColor = System.Drawing.Color.PeachPuff
        Me.btnSetRightVLC_Bottom.Location = New System.Drawing.Point(339, 103)
        Me.btnSetRightVLC_Bottom.Name = "btnSetRightVLC_Bottom"
        Me.btnSetRightVLC_Bottom.Size = New System.Drawing.Size(116, 23)
        Me.btnSetRightVLC_Bottom.TabIndex = 108
        Me.btnSetRightVLC_Bottom.Text = "Set Right VLC"
        Me.ttMainToolTip.SetToolTip(Me.btnSetRightVLC_Bottom, "Sets the left game/timer window VLC to the above dropdown")
        Me.btnSetRightVLC_Bottom.UseVisualStyleBackColor = False
        '
        'btnSetLeftVLC_Bottom
        '
        Me.btnSetLeftVLC_Bottom.BackColor = System.Drawing.Color.GreenYellow
        Me.btnSetLeftVLC_Bottom.Location = New System.Drawing.Point(21, 103)
        Me.btnSetLeftVLC_Bottom.Name = "btnSetLeftVLC_Bottom"
        Me.btnSetLeftVLC_Bottom.Size = New System.Drawing.Size(116, 23)
        Me.btnSetLeftVLC_Bottom.TabIndex = 107
        Me.btnSetLeftVLC_Bottom.Text = "Set Left VLC"
        Me.ttMainToolTip.SetToolTip(Me.btnSetLeftVLC_Bottom, "Sets the left game/timer window VLC to the above dropdown")
        Me.btnSetLeftVLC_Bottom.UseVisualStyleBackColor = False
        '
        'btnSaveRightCrop_Bottom
        '
        Me.btnSaveRightCrop_Bottom.Location = New System.Drawing.Point(574, 398)
        Me.btnSaveRightCrop_Bottom.Name = "btnSaveRightCrop_Bottom"
        Me.btnSaveRightCrop_Bottom.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveRightCrop_Bottom.TabIndex = 101
        Me.btnSaveRightCrop_Bottom.Text = "Save Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveRightCrop_Bottom, "Saves the current crop numbers to the database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the right side")
        Me.btnSaveRightCrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnSaveLeftCrop_Bottom
        '
        Me.btnSaveLeftCrop_Bottom.Location = New System.Drawing.Point(234, 398)
        Me.btnSaveLeftCrop_Bottom.Name = "btnSaveLeftCrop_Bottom"
        Me.btnSaveLeftCrop_Bottom.Size = New System.Drawing.Size(96, 23)
        Me.btnSaveLeftCrop_Bottom.TabIndex = 100
        Me.btnSaveLeftCrop_Bottom.Text = "Save Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveLeftCrop_Bottom, "Saves the current crop numbers to the database" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the left side")
        Me.btnSaveLeftCrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnGetRightCrop_Bottom
        '
        Me.btnGetRightCrop_Bottom.Location = New System.Drawing.Point(492, 398)
        Me.btnGetRightCrop_Bottom.Name = "btnGetRightCrop_Bottom"
        Me.btnGetRightCrop_Bottom.Size = New System.Drawing.Size(76, 23)
        Me.btnGetRightCrop_Bottom.TabIndex = 99
        Me.btnGetRightCrop_Bottom.Text = "Get Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnGetRightCrop_Bottom, "Get the current OBS crop settings for the right side")
        Me.btnGetRightCrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnGetLeftCrop_Bottom
        '
        Me.btnGetLeftCrop_Bottom.Location = New System.Drawing.Point(149, 398)
        Me.btnGetLeftCrop_Bottom.Name = "btnGetLeftCrop_Bottom"
        Me.btnGetLeftCrop_Bottom.Size = New System.Drawing.Size(79, 23)
        Me.btnGetLeftCrop_Bottom.TabIndex = 98
        Me.btnGetLeftCrop_Bottom.Text = "Get Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnGetLeftCrop_Bottom, "Get the current OBS crop settings for the left side")
        Me.btnGetLeftCrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnSetLeftCrop_Bottom
        '
        Me.btnSetLeftCrop_Bottom.BackColor = System.Drawing.Color.PaleGreen
        Me.btnSetLeftCrop_Bottom.Location = New System.Drawing.Point(23, 398)
        Me.btnSetLeftCrop_Bottom.Name = "btnSetLeftCrop_Bottom"
        Me.btnSetLeftCrop_Bottom.Size = New System.Drawing.Size(116, 23)
        Me.btnSetLeftCrop_Bottom.TabIndex = 90
        Me.btnSetLeftCrop_Bottom.Text = "Set Left Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetLeftCrop_Bottom, "Set the crop for the left side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetLeftCrop_Bottom.UseVisualStyleBackColor = False
        '
        'btnLeftTimerUncrop_Bottom
        '
        Me.btnLeftTimerUncrop_Bottom.Location = New System.Drawing.Point(145, 17)
        Me.btnLeftTimerUncrop_Bottom.Name = "btnLeftTimerUncrop_Bottom"
        Me.btnLeftTimerUncrop_Bottom.Size = New System.Drawing.Size(53, 23)
        Me.btnLeftTimerUncrop_Bottom.TabIndex = 91
        Me.btnLeftTimerUncrop_Bottom.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftTimerUncrop_Bottom, "Sets OBS to 0 crop for the timer")
        Me.btnLeftTimerUncrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnLeftTimerDB_Bottom
        '
        Me.btnLeftTimerDB_Bottom.Location = New System.Drawing.Point(39, 19)
        Me.btnLeftTimerDB_Bottom.Name = "btnLeftTimerDB_Bottom"
        Me.btnLeftTimerDB_Bottom.Size = New System.Drawing.Size(52, 23)
        Me.btnLeftTimerDB_Bottom.TabIndex = 87
        Me.btnLeftTimerDB_Bottom.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftTimerDB_Bottom, "Resets the timer data to what the current DB has")
        Me.btnLeftTimerDB_Bottom.UseVisualStyleBackColor = True
        '
        'btnLeftGameUncrop_Bottom
        '
        Me.btnLeftGameUncrop_Bottom.Location = New System.Drawing.Point(145, 19)
        Me.btnLeftGameUncrop_Bottom.Name = "btnLeftGameUncrop_Bottom"
        Me.btnLeftGameUncrop_Bottom.Size = New System.Drawing.Size(53, 23)
        Me.btnLeftGameUncrop_Bottom.TabIndex = 90
        Me.btnLeftGameUncrop_Bottom.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftGameUncrop_Bottom, "Sets OBS to 0 crop for the game")
        Me.btnLeftGameUncrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnLeftGameDB_Bottom
        '
        Me.btnLeftGameDB_Bottom.Location = New System.Drawing.Point(39, 19)
        Me.btnLeftGameDB_Bottom.Name = "btnLeftGameDB_Bottom"
        Me.btnLeftGameDB_Bottom.Size = New System.Drawing.Size(52, 23)
        Me.btnLeftGameDB_Bottom.TabIndex = 89
        Me.btnLeftGameDB_Bottom.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnLeftGameDB_Bottom, "Resets the game data to what the current DB has")
        Me.btnLeftGameDB_Bottom.UseVisualStyleBackColor = True
        '
        'btnRightTimerUncrop_Bottom
        '
        Me.btnRightTimerUncrop_Bottom.Location = New System.Drawing.Point(145, 20)
        Me.btnRightTimerUncrop_Bottom.Name = "btnRightTimerUncrop_Bottom"
        Me.btnRightTimerUncrop_Bottom.Size = New System.Drawing.Size(53, 23)
        Me.btnRightTimerUncrop_Bottom.TabIndex = 92
        Me.btnRightTimerUncrop_Bottom.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnRightTimerUncrop_Bottom, "Sets OBS to 0 crop for the timer")
        Me.btnRightTimerUncrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnRightTimerDB_Bottom
        '
        Me.btnRightTimerDB_Bottom.Location = New System.Drawing.Point(39, 19)
        Me.btnRightTimerDB_Bottom.Name = "btnRightTimerDB_Bottom"
        Me.btnRightTimerDB_Bottom.Size = New System.Drawing.Size(52, 23)
        Me.btnRightTimerDB_Bottom.TabIndex = 91
        Me.btnRightTimerDB_Bottom.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnRightTimerDB_Bottom, "Resets the timer data to what the current DB has")
        Me.btnRightTimerDB_Bottom.UseVisualStyleBackColor = True
        '
        'btnRightGameUncrop_Bottom
        '
        Me.btnRightGameUncrop_Bottom.Location = New System.Drawing.Point(145, 19)
        Me.btnRightGameUncrop_Bottom.Name = "btnRightGameUncrop_Bottom"
        Me.btnRightGameUncrop_Bottom.Size = New System.Drawing.Size(53, 23)
        Me.btnRightGameUncrop_Bottom.TabIndex = 93
        Me.btnRightGameUncrop_Bottom.Text = "Uncrop"
        Me.ttMainToolTip.SetToolTip(Me.btnRightGameUncrop_Bottom, "Sets OBS to 0 crop for the game")
        Me.btnRightGameUncrop_Bottom.UseVisualStyleBackColor = True
        '
        'btnRightGameDB_Bottom
        '
        Me.btnRightGameDB_Bottom.Location = New System.Drawing.Point(40, 19)
        Me.btnRightGameDB_Bottom.Name = "btnRightGameDB_Bottom"
        Me.btnRightGameDB_Bottom.Size = New System.Drawing.Size(52, 23)
        Me.btnRightGameDB_Bottom.TabIndex = 88
        Me.btnRightGameDB_Bottom.Text = "Reset"
        Me.ttMainToolTip.SetToolTip(Me.btnRightGameDB_Bottom, "Resets the game data to what the current DB has")
        Me.btnRightGameDB_Bottom.UseVisualStyleBackColor = True
        '
        'btnSetRightCrop_Bottom
        '
        Me.btnSetRightCrop_Bottom.BackColor = System.Drawing.Color.MistyRose
        Me.btnSetRightCrop_Bottom.Location = New System.Drawing.Point(363, 398)
        Me.btnSetRightCrop_Bottom.Name = "btnSetRightCrop_Bottom"
        Me.btnSetRightCrop_Bottom.Size = New System.Drawing.Size(123, 23)
        Me.btnSetRightCrop_Bottom.TabIndex = 93
        Me.btnSetRightCrop_Bottom.Text = "Set Right Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetRightCrop_Bottom, "Set the crop for the right side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetRightCrop_Bottom.UseVisualStyleBackColor = False
        '
        'gbTrackerComms
        '
        Me.gbTrackerComms.BackColor = System.Drawing.Color.PaleTurquoise
        Me.gbTrackerComms.Controls.Add(Me.pnlFourPlayerTracker)
        Me.gbTrackerComms.Controls.Add(Me.lblGameSettings)
        Me.gbTrackerComms.Controls.Add(Me.txtGameSettings)
        Me.gbTrackerComms.Controls.Add(Me.lblCommentary)
        Me.gbTrackerComms.Controls.Add(Me.txtCommentaryNames)
        Me.gbTrackerComms.Controls.Add(Me.txtLeftTrackerURL)
        Me.gbTrackerComms.Controls.Add(Me.txtRightTrackerURL)
        Me.gbTrackerComms.Controls.Add(Me.lblRightTracker)
        Me.gbTrackerComms.Controls.Add(Me.lblLeftTracker)
        Me.gbTrackerComms.Location = New System.Drawing.Point(169, 12)
        Me.gbTrackerComms.Name = "gbTrackerComms"
        Me.gbTrackerComms.Size = New System.Drawing.Size(1338, 112)
        Me.gbTrackerComms.TabIndex = 58
        Me.gbTrackerComms.TabStop = False
        Me.gbTrackerComms.Text = "Tracker / Comms info"
        '
        'txtLeftTrackerURL_Bottom
        '
        Me.txtLeftTrackerURL_Bottom.Location = New System.Drawing.Point(117, 13)
        Me.txtLeftTrackerURL_Bottom.Name = "txtLeftTrackerURL_Bottom"
        Me.txtLeftTrackerURL_Bottom.Size = New System.Drawing.Size(190, 20)
        Me.txtLeftTrackerURL_Bottom.TabIndex = 57
        '
        'txtRightTrackerURL_Bottom
        '
        Me.txtRightTrackerURL_Bottom.Location = New System.Drawing.Point(442, 13)
        Me.txtRightTrackerURL_Bottom.Name = "txtRightTrackerURL_Bottom"
        Me.txtRightTrackerURL_Bottom.Size = New System.Drawing.Size(189, 20)
        Me.txtRightTrackerURL_Bottom.TabIndex = 58
        '
        'lblRightTracker_Bottom
        '
        Me.lblRightTracker_Bottom.AutoSize = True
        Me.lblRightTracker_Bottom.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblRightTracker_Bottom.Location = New System.Drawing.Point(339, 16)
        Me.lblRightTracker_Bottom.Name = "lblRightTracker_Bottom"
        Me.lblRightTracker_Bottom.Size = New System.Drawing.Size(97, 13)
        Me.lblRightTracker_Bottom.TabIndex = 60
        Me.lblRightTracker_Bottom.Text = "Right Tracker URL"
        '
        'lblLeftTracker_Bottom
        '
        Me.lblLeftTracker_Bottom.AutoSize = True
        Me.lblLeftTracker_Bottom.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblLeftTracker_Bottom.Location = New System.Drawing.Point(9, 16)
        Me.lblLeftTracker_Bottom.Name = "lblLeftTracker_Bottom"
        Me.lblLeftTracker_Bottom.Size = New System.Drawing.Size(90, 13)
        Me.lblLeftTracker_Bottom.TabIndex = 59
        Me.lblLeftTracker_Bottom.Text = "Left Tracker URL"
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
        'cbRightVLCSource
        '
        Me.cbRightVLCSource.FormattingEnabled = True
        Me.cbRightVLCSource.Location = New System.Drawing.Point(588, 215)
        Me.cbRightVLCSource.Name = "cbRightVLCSource"
        Me.cbRightVLCSource.Size = New System.Drawing.Size(228, 21)
        Me.cbRightVLCSource.TabIndex = 69
        '
        'cbLeftVLCSource
        '
        Me.cbLeftVLCSource.FormattingEnabled = True
        Me.cbLeftVLCSource.Location = New System.Drawing.Point(244, 213)
        Me.cbLeftVLCSource.Name = "cbLeftVLCSource"
        Me.cbLeftVLCSource.Size = New System.Drawing.Size(228, 21)
        Me.cbLeftVLCSource.TabIndex = 66
        '
        'lblRightVLC
        '
        Me.lblRightVLC.AutoSize = True
        Me.lblRightVLC.BackColor = System.Drawing.Color.PeachPuff
        Me.lblRightVLC.Location = New System.Drawing.Point(487, 218)
        Me.lblRightVLC.Name = "lblRightVLC"
        Me.lblRightVLC.Size = New System.Drawing.Size(95, 13)
        Me.lblRightVLC.TabIndex = 68
        Me.lblRightVLC.Text = "Right VLC  Source"
        '
        'lblLeftVLC
        '
        Me.lblLeftVLC.AutoSize = True
        Me.lblLeftVLC.BackColor = System.Drawing.Color.GreenYellow
        Me.lblLeftVLC.Location = New System.Drawing.Point(155, 219)
        Me.lblLeftVLC.Name = "lblLeftVLC"
        Me.lblLeftVLC.Size = New System.Drawing.Size(85, 13)
        Me.lblLeftVLC.TabIndex = 67
        Me.lblLeftVLC.Text = "Left VLC Source"
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
        'lblViewLeftOnTwitch
        '
        Me.lblViewLeftOnTwitch.AutoSize = True
        Me.lblViewLeftOnTwitch.BackColor = System.Drawing.Color.Transparent
        Me.lblViewLeftOnTwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewLeftOnTwitch.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblViewLeftOnTwitch.Location = New System.Drawing.Point(153, 187)
        Me.lblViewLeftOnTwitch.Name = "lblViewLeftOnTwitch"
        Me.lblViewLeftOnTwitch.Size = New System.Drawing.Size(76, 13)
        Me.lblViewLeftOnTwitch.TabIndex = 78
        Me.lblViewLeftOnTwitch.Text = "View on twitch"
        '
        'lblLeftVOD
        '
        Me.lblLeftVOD.AutoSize = True
        Me.lblLeftVOD.BackColor = System.Drawing.Color.Transparent
        Me.lblLeftVOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftVOD.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLeftVOD.Location = New System.Drawing.Point(235, 187)
        Me.lblLeftVOD.Name = "lblLeftVOD"
        Me.lblLeftVOD.Size = New System.Drawing.Size(61, 13)
        Me.lblLeftVOD.TabIndex = 79
        Me.lblLeftVOD.Text = "View VODs"
        '
        'lblViewRightOnTwitch
        '
        Me.lblViewRightOnTwitch.AutoSize = True
        Me.lblViewRightOnTwitch.BackColor = System.Drawing.Color.Transparent
        Me.lblViewRightOnTwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewRightOnTwitch.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblViewRightOnTwitch.Location = New System.Drawing.Point(488, 191)
        Me.lblViewRightOnTwitch.Name = "lblViewRightOnTwitch"
        Me.lblViewRightOnTwitch.Size = New System.Drawing.Size(76, 13)
        Me.lblViewRightOnTwitch.TabIndex = 80
        Me.lblViewRightOnTwitch.Text = "View on twitch"
        '
        'lblRightVOD
        '
        Me.lblRightVOD.AutoSize = True
        Me.lblRightVOD.BackColor = System.Drawing.Color.Transparent
        Me.lblRightVOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRightVOD.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblRightVOD.Location = New System.Drawing.Point(572, 191)
        Me.lblRightVOD.Name = "lblRightVOD"
        Me.lblRightVOD.Size = New System.Drawing.Size(61, 13)
        Me.lblRightVOD.TabIndex = 81
        Me.lblRightVOD.Text = "View VODs"
        '
        'lblLeftStreamlink
        '
        Me.lblLeftStreamlink.AutoSize = True
        Me.lblLeftStreamlink.BackColor = System.Drawing.Color.Transparent
        Me.lblLeftStreamlink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftStreamlink.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLeftStreamlink.Location = New System.Drawing.Point(298, 187)
        Me.lblLeftStreamlink.Name = "lblLeftStreamlink"
        Me.lblLeftStreamlink.Size = New System.Drawing.Size(56, 13)
        Me.lblLeftStreamlink.TabIndex = 82
        Me.lblLeftStreamlink.Text = "Open VLC"
        '
        'lblRightStreamlink
        '
        Me.lblRightStreamlink.AutoSize = True
        Me.lblRightStreamlink.BackColor = System.Drawing.Color.Transparent
        Me.lblRightStreamlink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRightStreamlink.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblRightStreamlink.Location = New System.Drawing.Point(639, 191)
        Me.lblRightStreamlink.Name = "lblRightStreamlink"
        Me.lblRightStreamlink.Size = New System.Drawing.Size(56, 13)
        Me.lblRightStreamlink.TabIndex = 83
        Me.lblRightStreamlink.Text = "Open VLC"
        '
        'lblLeftRunnerTwitch
        '
        Me.lblLeftRunnerTwitch.AutoSize = True
        Me.lblLeftRunnerTwitch.Location = New System.Drawing.Point(155, 167)
        Me.lblLeftRunnerTwitch.Name = "lblLeftRunnerTwitch"
        Me.lblLeftRunnerTwitch.Size = New System.Drawing.Size(77, 13)
        Me.lblLeftRunnerTwitch.TabIndex = 85
        Me.lblLeftRunnerTwitch.Text = "Runner Twitch"
        '
        'lblRightRunnerTwitch
        '
        Me.lblRightRunnerTwitch.AutoSize = True
        Me.lblRightRunnerTwitch.Location = New System.Drawing.Point(488, 167)
        Me.lblRightRunnerTwitch.Name = "lblRightRunnerTwitch"
        Me.lblRightRunnerTwitch.Size = New System.Drawing.Size(77, 13)
        Me.lblRightRunnerTwitch.TabIndex = 86
        Me.lblRightRunnerTwitch.Text = "Runner Twitch"
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
        'lblRightRunnerTwitch_Bottom
        '
        Me.lblRightRunnerTwitch_Bottom.AutoSize = True
        Me.lblRightRunnerTwitch_Bottom.Location = New System.Drawing.Point(342, 28)
        Me.lblRightRunnerTwitch_Bottom.Name = "lblRightRunnerTwitch_Bottom"
        Me.lblRightRunnerTwitch_Bottom.Size = New System.Drawing.Size(77, 13)
        Me.lblRightRunnerTwitch_Bottom.TabIndex = 118
        Me.lblRightRunnerTwitch_Bottom.Text = "Runner Twitch"
        '
        'lblLeftRunnerTwitch_Bottom
        '
        Me.lblLeftRunnerTwitch_Bottom.AutoSize = True
        Me.lblLeftRunnerTwitch_Bottom.Location = New System.Drawing.Point(9, 28)
        Me.lblLeftRunnerTwitch_Bottom.Name = "lblLeftRunnerTwitch_Bottom"
        Me.lblLeftRunnerTwitch_Bottom.Size = New System.Drawing.Size(77, 13)
        Me.lblLeftRunnerTwitch_Bottom.TabIndex = 117
        Me.lblLeftRunnerTwitch_Bottom.Text = "Runner Twitch"
        '
        'lblRightStreamlink_Bottom
        '
        Me.lblRightStreamlink_Bottom.AutoSize = True
        Me.lblRightStreamlink_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblRightStreamlink_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRightStreamlink_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblRightStreamlink_Bottom.Location = New System.Drawing.Point(493, 52)
        Me.lblRightStreamlink_Bottom.Name = "lblRightStreamlink_Bottom"
        Me.lblRightStreamlink_Bottom.Size = New System.Drawing.Size(56, 13)
        Me.lblRightStreamlink_Bottom.TabIndex = 116
        Me.lblRightStreamlink_Bottom.Text = "Open VLC"
        '
        'lblLeftStreamlink_Bottom
        '
        Me.lblLeftStreamlink_Bottom.AutoSize = True
        Me.lblLeftStreamlink_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblLeftStreamlink_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftStreamlink_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLeftStreamlink_Bottom.Location = New System.Drawing.Point(152, 48)
        Me.lblLeftStreamlink_Bottom.Name = "lblLeftStreamlink_Bottom"
        Me.lblLeftStreamlink_Bottom.Size = New System.Drawing.Size(56, 13)
        Me.lblLeftStreamlink_Bottom.TabIndex = 115
        Me.lblLeftStreamlink_Bottom.Text = "Open VLC"
        '
        'lblRightVOD_Bottom
        '
        Me.lblRightVOD_Bottom.AutoSize = True
        Me.lblRightVOD_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblRightVOD_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRightVOD_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblRightVOD_Bottom.Location = New System.Drawing.Point(426, 52)
        Me.lblRightVOD_Bottom.Name = "lblRightVOD_Bottom"
        Me.lblRightVOD_Bottom.Size = New System.Drawing.Size(61, 13)
        Me.lblRightVOD_Bottom.TabIndex = 114
        Me.lblRightVOD_Bottom.Text = "View VODs"
        '
        'lblViewRightOnTwitch_Bottom
        '
        Me.lblViewRightOnTwitch_Bottom.AutoSize = True
        Me.lblViewRightOnTwitch_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblViewRightOnTwitch_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewRightOnTwitch_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblViewRightOnTwitch_Bottom.Location = New System.Drawing.Point(342, 52)
        Me.lblViewRightOnTwitch_Bottom.Name = "lblViewRightOnTwitch_Bottom"
        Me.lblViewRightOnTwitch_Bottom.Size = New System.Drawing.Size(76, 13)
        Me.lblViewRightOnTwitch_Bottom.TabIndex = 113
        Me.lblViewRightOnTwitch_Bottom.Text = "View on twitch"
        '
        'lblLeftVOD_Bottom
        '
        Me.lblLeftVOD_Bottom.AutoSize = True
        Me.lblLeftVOD_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblLeftVOD_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeftVOD_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblLeftVOD_Bottom.Location = New System.Drawing.Point(89, 48)
        Me.lblLeftVOD_Bottom.Name = "lblLeftVOD_Bottom"
        Me.lblLeftVOD_Bottom.Size = New System.Drawing.Size(61, 13)
        Me.lblLeftVOD_Bottom.TabIndex = 112
        Me.lblLeftVOD_Bottom.Text = "View VODs"
        '
        'lblViewLeftOnTwitch_Bottom
        '
        Me.lblViewLeftOnTwitch_Bottom.AutoSize = True
        Me.lblViewLeftOnTwitch_Bottom.BackColor = System.Drawing.Color.Transparent
        Me.lblViewLeftOnTwitch_Bottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewLeftOnTwitch_Bottom.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblViewLeftOnTwitch_Bottom.Location = New System.Drawing.Point(7, 48)
        Me.lblViewLeftOnTwitch_Bottom.Name = "lblViewLeftOnTwitch_Bottom"
        Me.lblViewLeftOnTwitch_Bottom.Size = New System.Drawing.Size(76, 13)
        Me.lblViewLeftOnTwitch_Bottom.TabIndex = 111
        Me.lblViewLeftOnTwitch_Bottom.Text = "View on twitch"
        '
        'cbRightVLCSource_Bottom
        '
        Me.cbRightVLCSource_Bottom.FormattingEnabled = True
        Me.cbRightVLCSource_Bottom.Location = New System.Drawing.Point(442, 76)
        Me.cbRightVLCSource_Bottom.Name = "cbRightVLCSource_Bottom"
        Me.cbRightVLCSource_Bottom.Size = New System.Drawing.Size(228, 21)
        Me.cbRightVLCSource_Bottom.TabIndex = 106
        '
        'cbLeftVLCSource_Bottom
        '
        Me.cbLeftVLCSource_Bottom.FormattingEnabled = True
        Me.cbLeftVLCSource_Bottom.Location = New System.Drawing.Point(98, 74)
        Me.cbLeftVLCSource_Bottom.Name = "cbLeftVLCSource_Bottom"
        Me.cbLeftVLCSource_Bottom.Size = New System.Drawing.Size(228, 21)
        Me.cbLeftVLCSource_Bottom.TabIndex = 103
        '
        'lblRightVLC_Bottom
        '
        Me.lblRightVLC_Bottom.AutoSize = True
        Me.lblRightVLC_Bottom.BackColor = System.Drawing.Color.PeachPuff
        Me.lblRightVLC_Bottom.Location = New System.Drawing.Point(341, 79)
        Me.lblRightVLC_Bottom.Name = "lblRightVLC_Bottom"
        Me.lblRightVLC_Bottom.Size = New System.Drawing.Size(95, 13)
        Me.lblRightVLC_Bottom.TabIndex = 105
        Me.lblRightVLC_Bottom.Text = "Right VLC  Source"
        '
        'lblLeftVLC_Bottom
        '
        Me.lblLeftVLC_Bottom.AutoSize = True
        Me.lblLeftVLC_Bottom.BackColor = System.Drawing.Color.GreenYellow
        Me.lblLeftVLC_Bottom.Location = New System.Drawing.Point(9, 80)
        Me.lblLeftVLC_Bottom.Name = "lblLeftVLC_Bottom"
        Me.lblLeftVLC_Bottom.Size = New System.Drawing.Size(85, 13)
        Me.lblLeftVLC_Bottom.TabIndex = 104
        Me.lblLeftVLC_Bottom.Text = "Left VLC Source"
        '
        'cbRightRunnerName_Bottom
        '
        Me.cbRightRunnerName_Bottom.DisplayMember = "RacerName"
        Me.cbRightRunnerName_Bottom.FormattingEnabled = True
        Me.cbRightRunnerName_Bottom.Location = New System.Drawing.Point(442, 1)
        Me.cbRightRunnerName_Bottom.Name = "cbRightRunnerName_Bottom"
        Me.cbRightRunnerName_Bottom.Size = New System.Drawing.Size(228, 21)
        Me.cbRightRunnerName_Bottom.TabIndex = 97
        Me.cbRightRunnerName_Bottom.ValueMember = "RacerName"
        '
        'cbLeftRunnerName_Bottom
        '
        Me.cbLeftRunnerName_Bottom.DisplayMember = "RacerName"
        Me.cbLeftRunnerName_Bottom.FormattingEnabled = True
        Me.cbLeftRunnerName_Bottom.Location = New System.Drawing.Point(100, 1)
        Me.cbLeftRunnerName_Bottom.Name = "cbLeftRunnerName_Bottom"
        Me.cbLeftRunnerName_Bottom.Size = New System.Drawing.Size(228, 21)
        Me.cbLeftRunnerName_Bottom.TabIndex = 95
        Me.cbLeftRunnerName_Bottom.ValueMember = "RacerName"
        '
        'lblRightRunner_Bottom
        '
        Me.lblRightRunner_Bottom.AutoSize = True
        Me.lblRightRunner_Bottom.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblRightRunner_Bottom.Location = New System.Drawing.Point(341, 4)
        Me.lblRightRunner_Bottom.Name = "lblRightRunner_Bottom"
        Me.lblRightRunner_Bottom.Size = New System.Drawing.Size(101, 13)
        Me.lblRightRunner_Bottom.TabIndex = 96
        Me.lblRightRunner_Bottom.Text = "Right Runner Name"
        '
        'lblLeftRunner_Bottom
        '
        Me.lblLeftRunner_Bottom.AutoSize = True
        Me.lblLeftRunner_Bottom.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblLeftRunner_Bottom.Location = New System.Drawing.Point(7, 4)
        Me.lblLeftRunner_Bottom.Name = "lblLeftRunner_Bottom"
        Me.lblLeftRunner_Bottom.Size = New System.Drawing.Size(94, 13)
        Me.lblLeftRunner_Bottom.TabIndex = 94
        Me.lblLeftRunner_Bottom.Text = "Left Runner Name"
        '
        'gbLeftTimerWindow_Bottom
        '
        Me.gbLeftTimerWindow_Bottom.BackColor = System.Drawing.Color.PaleGreen
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.btnLeftTimerUncrop_Bottom)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.btnLeftTimerDB_Bottom)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.cbLeftScaling_Bottom)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.lblLeftScaling_Bottom)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.Label30)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.txtCropLeftTimer_Top_BR)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.Label31)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.txtCropLeftTimer_Left_BR)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.txtCropLeftTimer_Bottom_BR)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.Label32)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.Label33)
        Me.gbLeftTimerWindow_Bottom.Controls.Add(Me.txtCropLeftTimer_Right_BR)
        Me.gbLeftTimerWindow_Bottom.Location = New System.Drawing.Point(23, 148)
        Me.gbLeftTimerWindow_Bottom.Name = "gbLeftTimerWindow_Bottom"
        Me.gbLeftTimerWindow_Bottom.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftTimerWindow_Bottom.TabIndex = 88
        Me.gbLeftTimerWindow_Bottom.TabStop = False
        Me.gbLeftTimerWindow_Bottom.Text = "Left Timer Window"
        '
        'cbLeftScaling_Bottom
        '
        Me.cbLeftScaling_Bottom.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLeftScaling_Bottom.FormattingEnabled = True
        Me.cbLeftScaling_Bottom.Items.AddRange(New Object() {"100%", "125%", "150%", "175%", "200%", "225%", "250%", "275%", "300%"})
        Me.cbLeftScaling_Bottom.Location = New System.Drawing.Point(242, 0)
        Me.cbLeftScaling_Bottom.Name = "cbLeftScaling_Bottom"
        Me.cbLeftScaling_Bottom.Size = New System.Drawing.Size(54, 23)
        Me.cbLeftScaling_Bottom.TabIndex = 88
        Me.cbLeftScaling_Bottom.Text = "100%"
        '
        'lblLeftScaling_Bottom
        '
        Me.lblLeftScaling_Bottom.AutoSize = True
        Me.lblLeftScaling_Bottom.Location = New System.Drawing.Point(193, 4)
        Me.lblLeftScaling_Bottom.Name = "lblLeftScaling_Bottom"
        Me.lblLeftScaling_Bottom.Size = New System.Drawing.Size(45, 13)
        Me.lblLeftScaling_Bottom.TabIndex = 87
        Me.lblLeftScaling_Bottom.Text = "Scaling:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(7, 82)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(26, 13)
        Me.Label30.TabIndex = 1
        Me.Label30.Text = "Top"
        '
        'txtCropLeftTimer_Top_BR
        '
        Me.txtCropLeftTimer_Top_BR.Location = New System.Drawing.Point(39, 79)
        Me.txtCropLeftTimer_Top_BR.Name = "txtCropLeftTimer_Top_BR"
        Me.txtCropLeftTimer_Top_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Top_BR.TabIndex = 7
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(7, 46)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(25, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "Left"
        '
        'txtCropLeftTimer_Left_BR
        '
        Me.txtCropLeftTimer_Left_BR.Location = New System.Drawing.Point(39, 43)
        Me.txtCropLeftTimer_Left_BR.Name = "txtCropLeftTimer_Left_BR"
        Me.txtCropLeftTimer_Left_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Left_BR.TabIndex = 3
        '
        'txtCropLeftTimer_Bottom_BR
        '
        Me.txtCropLeftTimer_Bottom_BR.Location = New System.Drawing.Point(196, 82)
        Me.txtCropLeftTimer_Bottom_BR.Name = "txtCropLeftTimer_Bottom_BR"
        Me.txtCropLeftTimer_Bottom_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Bottom_BR.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(158, 49)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(32, 13)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "Right"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(158, 85)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(40, 13)
        Me.Label33.TabIndex = 8
        Me.Label33.Text = "Bottom"
        '
        'txtCropLeftTimer_Right_BR
        '
        Me.txtCropLeftTimer_Right_BR.Location = New System.Drawing.Point(196, 46)
        Me.txtCropLeftTimer_Right_BR.Name = "txtCropLeftTimer_Right_BR"
        Me.txtCropLeftTimer_Right_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Right_BR.TabIndex = 5
        '
        'gbLeftGameWindow_Bottom
        '
        Me.gbLeftGameWindow_Bottom.BackColor = System.Drawing.Color.PaleGreen
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.btnLeftGameUncrop_Bottom)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.btnLeftGameDB_Bottom)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.Label34)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.txtCropLeftGame_Top_BR)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.Label35)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.txtCropLeftGame_Left_BR)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.txtCropLeftGame_Bottom_BR)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.Label36)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.Label37)
        Me.gbLeftGameWindow_Bottom.Controls.Add(Me.txtCropLeftGame_Right_BR)
        Me.gbLeftGameWindow_Bottom.Location = New System.Drawing.Point(23, 274)
        Me.gbLeftGameWindow_Bottom.Name = "gbLeftGameWindow_Bottom"
        Me.gbLeftGameWindow_Bottom.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftGameWindow_Bottom.TabIndex = 89
        Me.gbLeftGameWindow_Bottom.TabStop = False
        Me.gbLeftGameWindow_Bottom.Text = "Left Game Window"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(7, 97)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(26, 13)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Top"
        '
        'txtCropLeftGame_Top_BR
        '
        Me.txtCropLeftGame_Top_BR.Location = New System.Drawing.Point(39, 94)
        Me.txtCropLeftGame_Top_BR.Name = "txtCropLeftGame_Top_BR"
        Me.txtCropLeftGame_Top_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Top_BR.TabIndex = 7
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(7, 61)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(25, 13)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "Left"
        '
        'txtCropLeftGame_Left_BR
        '
        Me.txtCropLeftGame_Left_BR.Location = New System.Drawing.Point(39, 58)
        Me.txtCropLeftGame_Left_BR.Name = "txtCropLeftGame_Left_BR"
        Me.txtCropLeftGame_Left_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Left_BR.TabIndex = 3
        '
        'txtCropLeftGame_Bottom_BR
        '
        Me.txtCropLeftGame_Bottom_BR.Location = New System.Drawing.Point(196, 97)
        Me.txtCropLeftGame_Bottom_BR.Name = "txtCropLeftGame_Bottom_BR"
        Me.txtCropLeftGame_Bottom_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Bottom_BR.TabIndex = 9
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(158, 64)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(32, 13)
        Me.Label36.TabIndex = 6
        Me.Label36.Text = "Right"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(158, 100)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(40, 13)
        Me.Label37.TabIndex = 8
        Me.Label37.Text = "Bottom"
        '
        'txtCropLeftGame_Right_BR
        '
        Me.txtCropLeftGame_Right_BR.Location = New System.Drawing.Point(196, 61)
        Me.txtCropLeftGame_Right_BR.Name = "txtCropLeftGame_Right_BR"
        Me.txtCropLeftGame_Right_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Right_BR.TabIndex = 5
        '
        'gbRightTimerWindow_Bottom
        '
        Me.gbRightTimerWindow_Bottom.BackColor = System.Drawing.Color.MistyRose
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.btnRightTimerUncrop_Bottom)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.btnRightTimerDB_Bottom)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.cbRightScaling_Bottom)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.lblRightScaling_Bottom)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.Label39)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.txtCropRightTimer_Top_BR)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.Label40)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.txtCropRightTimer_Left_BR)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.txtCropRightTimer_Bottom_BR)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.Label41)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.Label42)
        Me.gbRightTimerWindow_Bottom.Controls.Add(Me.txtCropRightTimer_Right_BR)
        Me.gbRightTimerWindow_Bottom.Location = New System.Drawing.Point(363, 148)
        Me.gbRightTimerWindow_Bottom.Name = "gbRightTimerWindow_Bottom"
        Me.gbRightTimerWindow_Bottom.Size = New System.Drawing.Size(307, 118)
        Me.gbRightTimerWindow_Bottom.TabIndex = 91
        Me.gbRightTimerWindow_Bottom.TabStop = False
        Me.gbRightTimerWindow_Bottom.Text = "Right Timer Window"
        '
        'cbRightScaling_Bottom
        '
        Me.cbRightScaling_Bottom.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRightScaling_Bottom.FormattingEnabled = True
        Me.cbRightScaling_Bottom.Items.AddRange(New Object() {"100%", "125%", "150%", "175%", "200%", "225%", "250%", "275%", "300%"})
        Me.cbRightScaling_Bottom.Location = New System.Drawing.Point(242, 0)
        Me.cbRightScaling_Bottom.Name = "cbRightScaling_Bottom"
        Me.cbRightScaling_Bottom.Size = New System.Drawing.Size(54, 23)
        Me.cbRightScaling_Bottom.TabIndex = 90
        Me.cbRightScaling_Bottom.Text = "100%"
        '
        'lblRightScaling_Bottom
        '
        Me.lblRightScaling_Bottom.AutoSize = True
        Me.lblRightScaling_Bottom.Location = New System.Drawing.Point(193, 4)
        Me.lblRightScaling_Bottom.Name = "lblRightScaling_Bottom"
        Me.lblRightScaling_Bottom.Size = New System.Drawing.Size(45, 13)
        Me.lblRightScaling_Bottom.TabIndex = 89
        Me.lblRightScaling_Bottom.Text = "Scaling:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(7, 85)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(26, 13)
        Me.Label39.TabIndex = 1
        Me.Label39.Text = "Top"
        '
        'txtCropRightTimer_Top_BR
        '
        Me.txtCropRightTimer_Top_BR.Location = New System.Drawing.Point(39, 82)
        Me.txtCropRightTimer_Top_BR.Name = "txtCropRightTimer_Top_BR"
        Me.txtCropRightTimer_Top_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Top_BR.TabIndex = 7
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(7, 49)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(25, 13)
        Me.Label40.TabIndex = 4
        Me.Label40.Text = "Left"
        '
        'txtCropRightTimer_Left_BR
        '
        Me.txtCropRightTimer_Left_BR.Location = New System.Drawing.Point(39, 46)
        Me.txtCropRightTimer_Left_BR.Name = "txtCropRightTimer_Left_BR"
        Me.txtCropRightTimer_Left_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Left_BR.TabIndex = 3
        '
        'txtCropRightTimer_Bottom_BR
        '
        Me.txtCropRightTimer_Bottom_BR.Location = New System.Drawing.Point(196, 85)
        Me.txtCropRightTimer_Bottom_BR.Name = "txtCropRightTimer_Bottom_BR"
        Me.txtCropRightTimer_Bottom_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Bottom_BR.TabIndex = 9
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(158, 52)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(32, 13)
        Me.Label41.TabIndex = 6
        Me.Label41.Text = "Right"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(158, 88)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(40, 13)
        Me.Label42.TabIndex = 8
        Me.Label42.Text = "Bottom"
        '
        'txtCropRightTimer_Right_BR
        '
        Me.txtCropRightTimer_Right_BR.Location = New System.Drawing.Point(196, 49)
        Me.txtCropRightTimer_Right_BR.Name = "txtCropRightTimer_Right_BR"
        Me.txtCropRightTimer_Right_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Right_BR.TabIndex = 5
        '
        'gbRightGameWindow_Bottom
        '
        Me.gbRightGameWindow_Bottom.BackColor = System.Drawing.Color.MistyRose
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.btnRightGameUncrop_Bottom)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.btnRightGameDB_Bottom)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.Label43)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.txtCropRightGame_Top_BR)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.Label44)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.txtCropRightGame_Left_BR)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.txtCropRightGame_Bottom_BR)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.Label45)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.Label46)
        Me.gbRightGameWindow_Bottom.Controls.Add(Me.txtCropRightGame_Right_BR)
        Me.gbRightGameWindow_Bottom.Location = New System.Drawing.Point(363, 274)
        Me.gbRightGameWindow_Bottom.Name = "gbRightGameWindow_Bottom"
        Me.gbRightGameWindow_Bottom.Size = New System.Drawing.Size(307, 118)
        Me.gbRightGameWindow_Bottom.TabIndex = 92
        Me.gbRightGameWindow_Bottom.TabStop = False
        Me.gbRightGameWindow_Bottom.Text = "Right Game Window"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(7, 94)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(26, 13)
        Me.Label43.TabIndex = 1
        Me.Label43.Text = "Top"
        '
        'txtCropRightGame_Top_BR
        '
        Me.txtCropRightGame_Top_BR.Location = New System.Drawing.Point(39, 91)
        Me.txtCropRightGame_Top_BR.Name = "txtCropRightGame_Top_BR"
        Me.txtCropRightGame_Top_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Top_BR.TabIndex = 7
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(7, 58)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(25, 13)
        Me.Label44.TabIndex = 4
        Me.Label44.Text = "Left"
        '
        'txtCropRightGame_Left_BR
        '
        Me.txtCropRightGame_Left_BR.Location = New System.Drawing.Point(39, 55)
        Me.txtCropRightGame_Left_BR.Name = "txtCropRightGame_Left_BR"
        Me.txtCropRightGame_Left_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Left_BR.TabIndex = 3
        '
        'txtCropRightGame_Bottom_BR
        '
        Me.txtCropRightGame_Bottom_BR.Location = New System.Drawing.Point(196, 94)
        Me.txtCropRightGame_Bottom_BR.Name = "txtCropRightGame_Bottom_BR"
        Me.txtCropRightGame_Bottom_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Bottom_BR.TabIndex = 9
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(158, 61)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(32, 13)
        Me.Label45.TabIndex = 6
        Me.Label45.Text = "Right"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(158, 97)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(40, 13)
        Me.Label46.TabIndex = 8
        Me.Label46.Text = "Bottom"
        '
        'txtCropRightGame_Right_BR
        '
        Me.txtCropRightGame_Right_BR.Location = New System.Drawing.Point(196, 58)
        Me.txtCropRightGame_Right_BR.Name = "txtCropRightGame_Right_BR"
        Me.txtCropRightGame_Right_BR.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Right_BR.TabIndex = 5
        '
        'pnlFourPlayer
        '
        Me.pnlFourPlayer.Controls.Add(Me.cbRightRunnerName_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.cbLeftRunnerName_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblLeftRunner_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblRightRunnerTwitch_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSetRightCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblLeftRunnerTwitch_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.gbRightGameWindow_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblRightStreamlink_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.gbRightTimerWindow_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblLeftStreamlink_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.gbLeftGameWindow_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblRightVOD_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.gbLeftTimerWindow_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblViewRightOnTwitch_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSetLeftCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblLeftVOD_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblRightRunner_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblViewLeftOnTwitch_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnNewRightRunner_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnNewLeftRunner_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnGetLeftCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSetRightVLC_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnGetRightCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSetLeftVLC_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSaveLeftCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.cbRightVLCSource_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.btnSaveRightCrop_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.cbLeftVLCSource_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblLeftVLC_Bottom)
        Me.pnlFourPlayer.Controls.Add(Me.lblRightVLC_Bottom)
        Me.pnlFourPlayer.Location = New System.Drawing.Point(822, 136)
        Me.pnlFourPlayer.Name = "pnlFourPlayer"
        Me.pnlFourPlayer.Size = New System.Drawing.Size(685, 435)
        Me.pnlFourPlayer.TabIndex = 119
        '
        'pnlFourPlayerTracker
        '
        Me.pnlFourPlayerTracker.Controls.Add(Me.lblLeftTracker_Bottom)
        Me.pnlFourPlayerTracker.Controls.Add(Me.txtLeftTrackerURL_Bottom)
        Me.pnlFourPlayerTracker.Controls.Add(Me.lblRightTracker_Bottom)
        Me.pnlFourPlayerTracker.Controls.Add(Me.txtRightTrackerURL_Bottom)
        Me.pnlFourPlayerTracker.Location = New System.Drawing.Point(668, 60)
        Me.pnlFourPlayerTracker.Name = "pnlFourPlayerTracker"
        Me.pnlFourPlayerTracker.Size = New System.Drawing.Size(644, 39)
        Me.pnlFourPlayerTracker.TabIndex = 61
        '
        'ObsWebSocketCropper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1507, 571)
        Me.Controls.Add(Me.pnlFourPlayer)
        Me.Controls.Add(Me.btnResetDatabase)
        Me.Controls.Add(Me.lblRightRunnerTwitch)
        Me.Controls.Add(Me.lblLeftRunnerTwitch)
        Me.Controls.Add(Me.btnTestSourceSettings)
        Me.Controls.Add(Me.lblRightStreamlink)
        Me.Controls.Add(Me.lblLeftStreamlink)
        Me.Controls.Add(Me.lblRightVOD)
        Me.Controls.Add(Me.lblViewRightOnTwitch)
        Me.Controls.Add(Me.lblLeftVOD)
        Me.Controls.Add(Me.lblViewLeftOnTwitch)
        Me.Controls.Add(Me.btnNewRightRunner)
        Me.Controls.Add(Me.btnNewLeftRunner)
        Me.Controls.Add(Me.chkAlwaysOnTop)
        Me.Controls.Add(Me.btnSetRightVLC)
        Me.Controls.Add(Me.btnConnectOBS2)
        Me.Controls.Add(Me.lblOBS2ConnectedStatus)
        Me.Controls.Add(Me.btn2ndOBS)
        Me.Controls.Add(Me.btnSetLeftVLC)
        Me.Controls.Add(Me.cbRightVLCSource)
        Me.Controls.Add(Me.cbLeftVLCSource)
        Me.Controls.Add(Me.lblRightVLC)
        Me.Controls.Add(Me.lblLeftVLC)
        Me.Controls.Add(Me.btnGetProcesses)
        Me.Controls.Add(Me.btnSaveRightCrop)
        Me.Controls.Add(Me.btnSaveLeftCrop)
        Me.Controls.Add(Me.btnGetRightCrop)
        Me.Controls.Add(Me.btnGetLeftCrop)
        Me.Controls.Add(Me.btnConnectOBS1)
        Me.Controls.Add(Me.lblOBS1ConnectedStatus)
        Me.Controls.Add(Me.btnSyncWithServer)
        Me.Controls.Add(Me.gbTrackerComms)
        Me.Controls.Add(Me.btnSetTrackCommNames)
        Me.Controls.Add(Me.lblRSourceWidth)
        Me.Controls.Add(Me.lblRSourceHeight)
        Me.Controls.Add(Me.lblRMasterWidth)
        Me.Controls.Add(Me.lblRMasterHeight)
        Me.Controls.Add(Me.lblLSourceWidth)
        Me.Controls.Add(Me.lblLSourceHeight)
        Me.Controls.Add(Me.lblLMasterWidth)
        Me.Controls.Add(Me.lblLMasterHeight)
        Me.Controls.Add(Me.cbRightRunnerName)
        Me.Controls.Add(Me.cbLeftRunnerName)
        Me.Controls.Add(Me.lblRightRunner)
        Me.Controls.Add(Me.lblLeftRunner)
        Me.Controls.Add(Me.btnSetLeftCrop)
        Me.Controls.Add(Me.gbLeftTimerWindow)
        Me.Controls.Add(Me.gbLeftGameWindow)
        Me.Controls.Add(Me.gbRightTimerWindow)
        Me.Controls.Add(Me.gbRightGameWindow)
        Me.Controls.Add(Me.btnSetRightCrop)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "ObsWebSocketCropper"
        Me.Text = "OBS Websocket Cropper"
        Me.gbRightGameWindow.ResumeLayout(False)
        Me.gbRightGameWindow.PerformLayout()
        Me.gbRightTimerWindow.ResumeLayout(False)
        Me.gbRightTimerWindow.PerformLayout()
        Me.gbLeftTimerWindow.ResumeLayout(False)
        Me.gbLeftTimerWindow.PerformLayout()
        Me.gbLeftGameWindow.ResumeLayout(False)
        Me.gbLeftGameWindow.PerformLayout()
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.gbTrackerComms.ResumeLayout(False)
        Me.gbTrackerComms.PerformLayout()
        Me.gbLeftTimerWindow_Bottom.ResumeLayout(False)
        Me.gbLeftTimerWindow_Bottom.PerformLayout()
        Me.gbLeftGameWindow_Bottom.ResumeLayout(False)
        Me.gbLeftGameWindow_Bottom.PerformLayout()
        Me.gbRightTimerWindow_Bottom.ResumeLayout(False)
        Me.gbRightTimerWindow_Bottom.PerformLayout()
        Me.gbRightGameWindow_Bottom.ResumeLayout(False)
        Me.gbRightGameWindow_Bottom.PerformLayout()
        Me.pnlFourPlayer.ResumeLayout(False)
        Me.pnlFourPlayer.PerformLayout()
        Me.pnlFourPlayerTracker.ResumeLayout(False)
        Me.pnlFourPlayerTracker.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSetRightCrop As Button
    Friend WithEvents txtCropRightGame_Top As TextBox
    Friend WithEvents txtCropRightGame_Left As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCropRightGame_Right As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCropRightGame_Bottom As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnConnectOBS1 As Button
    Friend WithEvents gbRightGameWindow As GroupBox
    Friend WithEvents gbRightTimerWindow As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCropRightTimer_Top As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCropRightTimer_Left As TextBox
    Friend WithEvents txtCropRightTimer_Bottom As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCropRightTimer_Right As TextBox
    Friend WithEvents gbLeftTimerWindow As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCropLeftTimer_Top As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCropLeftTimer_Left As TextBox
    Friend WithEvents txtCropLeftTimer_Bottom As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCropLeftTimer_Right As TextBox
    Friend WithEvents gbLeftGameWindow As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCropLeftGame_Top As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCropLeftGame_Left As TextBox
    Friend WithEvents txtCropLeftGame_Bottom As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtCropLeftGame_Right As TextBox
    Friend WithEvents btnSetLeftCrop As Button
    Friend WithEvents lblLeftRunner As Label
    Friend WithEvents lblRightRunner As Label
    Friend WithEvents cbLeftRunnerName As ComboBox
    Friend WithEvents cbRightRunnerName As ComboBox
    Friend WithEvents lblLMasterHeight As Label
    Friend WithEvents lblLMasterWidth As Label
    Friend WithEvents lblLSourceHeight As Label
    Friend WithEvents lblLSourceWidth As Label
    Friend WithEvents lblRSourceWidth As Label
    Friend WithEvents lblRSourceHeight As Label
    Friend WithEvents lblRMasterWidth As Label
    Friend WithEvents lblRMasterHeight As Label
    Friend WithEvents txtLeftTrackerURL As TextBox
    Friend WithEvents txtRightTrackerURL As TextBox
    Friend WithEvents lblLeftTracker As Label
    Friend WithEvents lblRightTracker As Label
    Friend WithEvents lblCommentary As Label
    Friend WithEvents txtCommentaryNames As TextBox
    Friend WithEvents btnSetTrackCommNames As Button
    Friend WithEvents mnuMainMenu As MenuStrip
    Friend WithEvents ttMainToolTip As ToolTip
    Friend WithEvents gbTrackerComms As GroupBox
    Friend WithEvents btnSyncWithServer As Button
    Friend WithEvents lblOBS1ConnectedStatus As Label
    Friend WithEvents btnGetLeftCrop As Button
    Friend WithEvents btnGetRightCrop As Button
    Friend WithEvents btnSaveLeftCrop As Button
    Friend WithEvents btnSaveRightCrop As Button
    Friend WithEvents btnGetProcesses As Button
    Friend WithEvents cbRightVLCSource As ComboBox
    Friend WithEvents cbLeftVLCSource As ComboBox
    Friend WithEvents lblRightVLC As Label
    Friend WithEvents lblLeftVLC As Label
    Friend WithEvents btnSetLeftVLC As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn2ndOBS As Button
    Friend WithEvents lblOBS2ConnectedStatus As Label
    Friend WithEvents btnConnectOBS2 As Button
    Friend WithEvents btnSetRightVLC As Button
    Friend WithEvents chkAlwaysOnTop As CheckBox
    Friend WithEvents btnNewLeftRunner As Button
    Friend WithEvents btnNewRightRunner As Button
    Friend WithEvents lblViewLeftOnTwitch As Label
    Friend WithEvents lblLeftVOD As Label
    Friend WithEvents lblViewRightOnTwitch As Label
    Friend WithEvents lblRightVOD As Label
    Friend WithEvents lblLeftStreamlink As Label
    Friend WithEvents lblRightStreamlink As Label
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeUserSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeVLCSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExpertModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTestSourceSettings As Button
    Friend WithEvents lblLeftRunnerTwitch As Label
    Friend WithEvents lblRightRunnerTwitch As Label
    Friend WithEvents lblLeftScaling As Label
    Friend WithEvents cbRightScaling As ComboBox
    Friend WithEvents lblRightScaling As Label
    Friend WithEvents cbLeftScaling As ComboBox
    Friend WithEvents btnRightGameDB As Button
    Friend WithEvents btnRightTimerDB As Button
    Friend WithEvents btnLeftTimerDB As Button
    Friend WithEvents btnLeftGameDB As Button
    Friend WithEvents btnRightGameUncrop As Button
    Friend WithEvents btnRightTimerUncrop As Button
    Friend WithEvents btnLeftTimerUncrop As Button
    Friend WithEvents btnLeftGameUncrop As Button
    Friend WithEvents lblGameSettings As Label
    Friend WithEvents txtGameSettings As TextBox
    Friend WithEvents btnResetDatabase As Button
    Friend WithEvents lblRightRunnerTwitch_Bottom As Label
    Friend WithEvents lblLeftRunnerTwitch_Bottom As Label
    Friend WithEvents lblRightStreamlink_Bottom As Label
    Friend WithEvents lblLeftStreamlink_Bottom As Label
    Friend WithEvents lblRightVOD_Bottom As Label
    Friend WithEvents lblViewRightOnTwitch_Bottom As Label
    Friend WithEvents lblLeftVOD_Bottom As Label
    Friend WithEvents lblViewLeftOnTwitch_Bottom As Label
    Friend WithEvents btnNewRightRunner_Bottom As Button
    Friend WithEvents btnNewLeftRunner_Bottom As Button
    Friend WithEvents btnSetRightVLC_Bottom As Button
    Friend WithEvents btnSetLeftVLC_Bottom As Button
    Friend WithEvents cbRightVLCSource_Bottom As ComboBox
    Friend WithEvents cbLeftVLCSource_Bottom As ComboBox
    Friend WithEvents lblRightVLC_Bottom As Label
    Friend WithEvents lblLeftVLC_Bottom As Label
    Friend WithEvents btnSaveRightCrop_Bottom As Button
    Friend WithEvents btnSaveLeftCrop_Bottom As Button
    Friend WithEvents btnGetRightCrop_Bottom As Button
    Friend WithEvents btnGetLeftCrop_Bottom As Button
    Friend WithEvents cbRightRunnerName_Bottom As ComboBox
    Friend WithEvents cbLeftRunnerName_Bottom As ComboBox
    Friend WithEvents lblRightRunner_Bottom As Label
    Friend WithEvents lblLeftRunner_Bottom As Label
    Friend WithEvents btnSetLeftCrop_Bottom As Button
    Friend WithEvents gbLeftTimerWindow_Bottom As GroupBox
    Friend WithEvents btnLeftTimerUncrop_Bottom As Button
    Friend WithEvents btnLeftTimerDB_Bottom As Button
    Friend WithEvents cbLeftScaling_Bottom As ComboBox
    Friend WithEvents lblLeftScaling_Bottom As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtCropLeftTimer_Top_BR As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtCropLeftTimer_Left_BR As TextBox
    Friend WithEvents txtCropLeftTimer_Bottom_BR As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents txtCropLeftTimer_Right_BR As TextBox
    Friend WithEvents gbLeftGameWindow_Bottom As GroupBox
    Friend WithEvents btnLeftGameUncrop_Bottom As Button
    Friend WithEvents btnLeftGameDB_Bottom As Button
    Friend WithEvents Label34 As Label
    Friend WithEvents txtCropLeftGame_Top_BR As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtCropLeftGame_Left_BR As TextBox
    Friend WithEvents txtCropLeftGame_Bottom_BR As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtCropLeftGame_Right_BR As TextBox
    Friend WithEvents gbRightTimerWindow_Bottom As GroupBox
    Friend WithEvents btnRightTimerUncrop_Bottom As Button
    Friend WithEvents btnRightTimerDB_Bottom As Button
    Friend WithEvents cbRightScaling_Bottom As ComboBox
    Friend WithEvents lblRightScaling_Bottom As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents txtCropRightTimer_Top_BR As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents txtCropRightTimer_Left_BR As TextBox
    Friend WithEvents txtCropRightTimer_Bottom_BR As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents txtCropRightTimer_Right_BR As TextBox
    Friend WithEvents gbRightGameWindow_Bottom As GroupBox
    Friend WithEvents btnRightGameUncrop_Bottom As Button
    Friend WithEvents btnRightGameDB_Bottom As Button
    Friend WithEvents Label43 As Label
    Friend WithEvents txtCropRightGame_Top_BR As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents txtCropRightGame_Left_BR As TextBox
    Friend WithEvents txtCropRightGame_Bottom_BR As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents txtCropRightGame_Right_BR As TextBox
    Friend WithEvents btnSetRightCrop_Bottom As Button
    Friend WithEvents txtLeftTrackerURL_Bottom As TextBox
    Friend WithEvents txtRightTrackerURL_Bottom As TextBox
    Friend WithEvents lblRightTracker_Bottom As Label
    Friend WithEvents lblLeftTracker_Bottom As Label
    Friend WithEvents PlayersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlFourPlayer As Panel
    Friend WithEvents pnlFourPlayerTracker As Panel
End Class
