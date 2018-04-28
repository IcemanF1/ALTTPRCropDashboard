<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OBSWebSocketCropper
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
        Me.components = New System.ComponentModel.Container()
        Me.cbRightGameWindow = New System.Windows.Forms.ComboBox()
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
        Me.btnGetCrop = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRefreshScenes = New System.Windows.Forms.Button()
        Me.btnSetMaster = New System.Windows.Forms.Button()
        Me.gbRightGameWindow = New System.Windows.Forms.GroupBox()
        Me.gbRightTimerWindow = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbRightTimerWindow = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Top = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Left = New System.Windows.Forms.TextBox()
        Me.txtCropRightTimer_Bottom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCropRightTimer_Right = New System.Windows.Forms.TextBox()
        Me.gbLeftTimerWindow = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbLeftTimerWindow = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Top = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Left = New System.Windows.Forms.TextBox()
        Me.txtCropLeftTimer_Bottom = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCropLeftTimer_Right = New System.Windows.Forms.TextBox()
        Me.gbLeftGameWindow = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbLeftGameWindow = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Top = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Left = New System.Windows.Forms.TextBox()
        Me.txtCropLeftGame_Bottom = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCropLeftGame_Right = New System.Windows.Forms.TextBox()
        Me.btnSetLeftCrop = New System.Windows.Forms.Button()
        Me.btnSaveRunnerCrop = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtDefaultCropTop = New System.Windows.Forms.TextBox()
        Me.txtDefaultCropBottom = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.lblOBS1ConnectedStatus = New System.Windows.Forms.Label()
        Me.cbLeftRunnerName = New System.Windows.Forms.ComboBox()
        Me.cbRightRunnerName = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtConnectionString1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPassword1 = New System.Windows.Forms.TextBox()
        Me.gbConnection1 = New System.Windows.Forms.GroupBox()
        Me.gbConnection2 = New System.Windows.Forms.GroupBox()
        Me.btnConnectOBS2 = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblOBS2ConnectedStatus = New System.Windows.Forms.Label()
        Me.txtPassword2 = New System.Windows.Forms.TextBox()
        Me.txtConnectionString2 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnGetCropFromOBS = New System.Windows.Forms.Button()
        Me.lblLMasterHeight = New System.Windows.Forms.Label()
        Me.lblLMasterWidth = New System.Windows.Forms.Label()
        Me.lblLSourceHeight = New System.Windows.Forms.Label()
        Me.lblLSourceWidth = New System.Windows.Forms.Label()
        Me.lblRSourceWidth = New System.Windows.Forms.Label()
        Me.lblRSourceHeight = New System.Windows.Forms.Label()
        Me.lblRMasterWidth = New System.Windows.Forms.Label()
        Me.lblRMasterHeight = New System.Windows.Forms.Label()
        Me.chkOldMath = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbRightRunnerOBS = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cbRightTrackerOBS = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cbLeftTrackerOBS = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbLeftRunnerOBS = New System.Windows.Forms.ComboBox()
        Me.txtLeftTrackerURL = New System.Windows.Forms.TextBox()
        Me.txtRightTrackerURL = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cbCommentaryOBS = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtCommentaryNames = New System.Windows.Forms.TextBox()
        Me.btnSetTrackCommNames = New System.Windows.Forms.Button()
        Me.chkNewNewMath = New System.Windows.Forms.CheckBox()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadOBSINIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttMainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbTrackerComms = New System.Windows.Forms.GroupBox()
        Me.chkDifferentMath = New System.Windows.Forms.CheckBox()
        Me.gbRightGameWindow.SuspendLayout()
        Me.gbRightTimerWindow.SuspendLayout()
        Me.gbLeftTimerWindow.SuspendLayout()
        Me.gbLeftGameWindow.SuspendLayout()
        Me.gbConnection1.SuspendLayout()
        Me.gbConnection2.SuspendLayout()
        Me.mnuMainMenu.SuspendLayout()
        Me.gbTrackerComms.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbRightGameWindow
        '
        Me.cbRightGameWindow.FormattingEnabled = True
        Me.cbRightGameWindow.Location = New System.Drawing.Point(175, 13)
        Me.cbRightGameWindow.Name = "cbRightGameWindow"
        Me.cbRightGameWindow.Size = New System.Drawing.Size(121, 21)
        Me.cbRightGameWindow.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Top"
        '
        'btnSetRightCrop
        '
        Me.btnSetRightCrop.Location = New System.Drawing.Point(702, 591)
        Me.btnSetRightCrop.Name = "btnSetRightCrop"
        Me.btnSetRightCrop.Size = New System.Drawing.Size(116, 23)
        Me.btnSetRightCrop.TabIndex = 6
        Me.btnSetRightCrop.Text = "Set Right Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetRightCrop, "Set the crop for the right side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetRightCrop.UseVisualStyleBackColor = True
        '
        'txtCropRightGame_Top
        '
        Me.txtCropRightGame_Top.Location = New System.Drawing.Point(39, 73)
        Me.txtCropRightGame_Top.Name = "txtCropRightGame_Top"
        Me.txtCropRightGame_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Top.TabIndex = 7
        '
        'txtCropRightGame_Left
        '
        Me.txtCropRightGame_Left.Location = New System.Drawing.Point(39, 37)
        Me.txtCropRightGame_Left.Name = "txtCropRightGame_Left"
        Me.txtCropRightGame_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Left.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Left"
        '
        'txtCropRightGame_Right
        '
        Me.txtCropRightGame_Right.Location = New System.Drawing.Point(196, 40)
        Me.txtCropRightGame_Right.Name = "txtCropRightGame_Right"
        Me.txtCropRightGame_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Right.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Right"
        '
        'txtCropRightGame_Bottom
        '
        Me.txtCropRightGame_Bottom.Location = New System.Drawing.Point(196, 76)
        Me.txtCropRightGame_Bottom.Name = "txtCropRightGame_Bottom"
        Me.txtCropRightGame_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightGame_Bottom.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Bottom"
        '
        'btnConnectOBS1
        '
        Me.btnConnectOBS1.Location = New System.Drawing.Point(10, 19)
        Me.btnConnectOBS1.Name = "btnConnectOBS1"
        Me.btnConnectOBS1.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS1.TabIndex = 11
        Me.btnConnectOBS1.Text = "Connect OBS 1"
        Me.ttMainToolTip.SetToolTip(Me.btnConnectOBS1, "Attempt to connect to the OBS Websocket based off" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the connection string and pass" &
        "word")
        Me.btnConnectOBS1.UseVisualStyleBackColor = True
        '
        'btnGetCrop
        '
        Me.btnGetCrop.Location = New System.Drawing.Point(74, 214)
        Me.btnGetCrop.Name = "btnGetCrop"
        Me.btnGetCrop.Size = New System.Drawing.Size(75, 23)
        Me.btnGetCrop.TabIndex = 12
        Me.btnGetCrop.Text = "Get Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnGetCrop, "Gets the current height/width of the game scenes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and sets the source height/widt" &
        "h as that.")
        Me.btnGetCrop.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Right Game Window OBS Source"
        '
        'btnRefreshScenes
        '
        Me.btnRefreshScenes.Location = New System.Drawing.Point(28, 156)
        Me.btnRefreshScenes.Name = "btnRefreshScenes"
        Me.btnRefreshScenes.Size = New System.Drawing.Size(121, 23)
        Me.btnRefreshScenes.TabIndex = 14
        Me.btnRefreshScenes.Text = "Refresh Scenes"
        Me.ttMainToolTip.SetToolTip(Me.btnRefreshScenes, "Updates the OBS drop downs with new scenes/scene names")
        Me.btnRefreshScenes.UseVisualStyleBackColor = True
        '
        'btnSetMaster
        '
        Me.btnSetMaster.Location = New System.Drawing.Point(74, 185)
        Me.btnSetMaster.Name = "btnSetMaster"
        Me.btnSetMaster.Size = New System.Drawing.Size(75, 23)
        Me.btnSetMaster.TabIndex = 15
        Me.btnSetMaster.Text = "Set Master"
        Me.ttMainToolTip.SetToolTip(Me.btnSetMaster, "Grabs the current height/width from the game windows" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and sets that as the master" &
        " height/width.")
        Me.btnSetMaster.UseVisualStyleBackColor = True
        '
        'gbRightGameWindow
        '
        Me.gbRightGameWindow.Controls.Add(Me.Label5)
        Me.gbRightGameWindow.Controls.Add(Me.cbRightGameWindow)
        Me.gbRightGameWindow.Controls.Add(Me.Label1)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Top)
        Me.gbRightGameWindow.Controls.Add(Me.Label2)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Left)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Bottom)
        Me.gbRightGameWindow.Controls.Add(Me.Label3)
        Me.gbRightGameWindow.Controls.Add(Me.Label4)
        Me.gbRightGameWindow.Controls.Add(Me.txtCropRightGame_Right)
        Me.gbRightGameWindow.Location = New System.Drawing.Point(511, 467)
        Me.gbRightGameWindow.Name = "gbRightGameWindow"
        Me.gbRightGameWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbRightGameWindow.TabIndex = 5
        Me.gbRightGameWindow.TabStop = False
        Me.gbRightGameWindow.Text = "Right Game Window"
        '
        'gbRightTimerWindow
        '
        Me.gbRightTimerWindow.Controls.Add(Me.Label6)
        Me.gbRightTimerWindow.Controls.Add(Me.cbRightTimerWindow)
        Me.gbRightTimerWindow.Controls.Add(Me.Label7)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Top)
        Me.gbRightTimerWindow.Controls.Add(Me.Label8)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Left)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Bottom)
        Me.gbRightTimerWindow.Controls.Add(Me.Label9)
        Me.gbRightTimerWindow.Controls.Add(Me.Label10)
        Me.gbRightTimerWindow.Controls.Add(Me.txtCropRightTimer_Right)
        Me.gbRightTimerWindow.Location = New System.Drawing.Point(512, 345)
        Me.gbRightTimerWindow.Name = "gbRightTimerWindow"
        Me.gbRightTimerWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbRightTimerWindow.TabIndex = 4
        Me.gbRightTimerWindow.TabStop = False
        Me.gbRightTimerWindow.Text = "Right Timer Window"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Right Timer Window OBS Source"
        '
        'cbRightTimerWindow
        '
        Me.cbRightTimerWindow.FormattingEnabled = True
        Me.cbRightTimerWindow.Location = New System.Drawing.Point(175, 13)
        Me.cbRightTimerWindow.Name = "cbRightTimerWindow"
        Me.cbRightTimerWindow.Size = New System.Drawing.Size(121, 21)
        Me.cbRightTimerWindow.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Top"
        '
        'txtCropRightTimer_Top
        '
        Me.txtCropRightTimer_Top.Location = New System.Drawing.Point(39, 73)
        Me.txtCropRightTimer_Top.Name = "txtCropRightTimer_Top"
        Me.txtCropRightTimer_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Top.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Left"
        '
        'txtCropRightTimer_Left
        '
        Me.txtCropRightTimer_Left.Location = New System.Drawing.Point(39, 37)
        Me.txtCropRightTimer_Left.Name = "txtCropRightTimer_Left"
        Me.txtCropRightTimer_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Left.TabIndex = 3
        '
        'txtCropRightTimer_Bottom
        '
        Me.txtCropRightTimer_Bottom.Location = New System.Drawing.Point(196, 76)
        Me.txtCropRightTimer_Bottom.Name = "txtCropRightTimer_Bottom"
        Me.txtCropRightTimer_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Bottom.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(158, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Right"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(158, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Bottom"
        '
        'txtCropRightTimer_Right
        '
        Me.txtCropRightTimer_Right.Location = New System.Drawing.Point(196, 40)
        Me.txtCropRightTimer_Right.Name = "txtCropRightTimer_Right"
        Me.txtCropRightTimer_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropRightTimer_Right.TabIndex = 5
        '
        'gbLeftTimerWindow
        '
        Me.gbLeftTimerWindow.Controls.Add(Me.Label11)
        Me.gbLeftTimerWindow.Controls.Add(Me.cbLeftTimerWindow)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label12)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Top)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label13)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Left)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Bottom)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label14)
        Me.gbLeftTimerWindow.Controls.Add(Me.Label15)
        Me.gbLeftTimerWindow.Controls.Add(Me.txtCropLeftTimer_Right)
        Me.gbLeftTimerWindow.Location = New System.Drawing.Point(169, 344)
        Me.gbLeftTimerWindow.Name = "gbLeftTimerWindow"
        Me.gbLeftTimerWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftTimerWindow.TabIndex = 1
        Me.gbLeftTimerWindow.TabStop = False
        Me.gbLeftTimerWindow.Text = "Left Timer Window"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(158, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Left Timer Window OBS Source"
        '
        'cbLeftTimerWindow
        '
        Me.cbLeftTimerWindow.FormattingEnabled = True
        Me.cbLeftTimerWindow.Location = New System.Drawing.Point(175, 13)
        Me.cbLeftTimerWindow.Name = "cbLeftTimerWindow"
        Me.cbLeftTimerWindow.Size = New System.Drawing.Size(121, 21)
        Me.cbLeftTimerWindow.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Top"
        '
        'txtCropLeftTimer_Top
        '
        Me.txtCropLeftTimer_Top.Location = New System.Drawing.Point(39, 73)
        Me.txtCropLeftTimer_Top.Name = "txtCropLeftTimer_Top"
        Me.txtCropLeftTimer_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Top.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Left"
        '
        'txtCropLeftTimer_Left
        '
        Me.txtCropLeftTimer_Left.Location = New System.Drawing.Point(39, 37)
        Me.txtCropLeftTimer_Left.Name = "txtCropLeftTimer_Left"
        Me.txtCropLeftTimer_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Left.TabIndex = 3
        '
        'txtCropLeftTimer_Bottom
        '
        Me.txtCropLeftTimer_Bottom.Location = New System.Drawing.Point(196, 76)
        Me.txtCropLeftTimer_Bottom.Name = "txtCropLeftTimer_Bottom"
        Me.txtCropLeftTimer_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Bottom.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(158, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Right"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(158, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Bottom"
        '
        'txtCropLeftTimer_Right
        '
        Me.txtCropLeftTimer_Right.Location = New System.Drawing.Point(196, 40)
        Me.txtCropLeftTimer_Right.Name = "txtCropLeftTimer_Right"
        Me.txtCropLeftTimer_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftTimer_Right.TabIndex = 5
        '
        'gbLeftGameWindow
        '
        Me.gbLeftGameWindow.Controls.Add(Me.Label16)
        Me.gbLeftGameWindow.Controls.Add(Me.cbLeftGameWindow)
        Me.gbLeftGameWindow.Controls.Add(Me.Label17)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Top)
        Me.gbLeftGameWindow.Controls.Add(Me.Label18)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Left)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Bottom)
        Me.gbLeftGameWindow.Controls.Add(Me.Label19)
        Me.gbLeftGameWindow.Controls.Add(Me.Label20)
        Me.gbLeftGameWindow.Controls.Add(Me.txtCropLeftGame_Right)
        Me.gbLeftGameWindow.Location = New System.Drawing.Point(168, 466)
        Me.gbLeftGameWindow.Name = "gbLeftGameWindow"
        Me.gbLeftGameWindow.Size = New System.Drawing.Size(307, 118)
        Me.gbLeftGameWindow.TabIndex = 2
        Me.gbLeftGameWindow.TabStop = False
        Me.gbLeftGameWindow.Text = "Left Game Window"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(160, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Left Game Window OBS Source"
        '
        'cbLeftGameWindow
        '
        Me.cbLeftGameWindow.FormattingEnabled = True
        Me.cbLeftGameWindow.Location = New System.Drawing.Point(175, 13)
        Me.cbLeftGameWindow.Name = "cbLeftGameWindow"
        Me.cbLeftGameWindow.Size = New System.Drawing.Size(121, 21)
        Me.cbLeftGameWindow.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Top"
        '
        'txtCropLeftGame_Top
        '
        Me.txtCropLeftGame_Top.Location = New System.Drawing.Point(39, 73)
        Me.txtCropLeftGame_Top.Name = "txtCropLeftGame_Top"
        Me.txtCropLeftGame_Top.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Top.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Left"
        '
        'txtCropLeftGame_Left
        '
        Me.txtCropLeftGame_Left.Location = New System.Drawing.Point(39, 37)
        Me.txtCropLeftGame_Left.Name = "txtCropLeftGame_Left"
        Me.txtCropLeftGame_Left.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Left.TabIndex = 3
        '
        'txtCropLeftGame_Bottom
        '
        Me.txtCropLeftGame_Bottom.Location = New System.Drawing.Point(196, 76)
        Me.txtCropLeftGame_Bottom.Name = "txtCropLeftGame_Bottom"
        Me.txtCropLeftGame_Bottom.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Bottom.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(158, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Right"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(158, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Bottom"
        '
        'txtCropLeftGame_Right
        '
        Me.txtCropLeftGame_Right.Location = New System.Drawing.Point(196, 40)
        Me.txtCropLeftGame_Right.Name = "txtCropLeftGame_Right"
        Me.txtCropLeftGame_Right.Size = New System.Drawing.Size(100, 20)
        Me.txtCropLeftGame_Right.TabIndex = 5
        '
        'btnSetLeftCrop
        '
        Me.btnSetLeftCrop.Location = New System.Drawing.Point(359, 590)
        Me.btnSetLeftCrop.Name = "btnSetLeftCrop"
        Me.btnSetLeftCrop.Size = New System.Drawing.Size(116, 23)
        Me.btnSetLeftCrop.TabIndex = 3
        Me.btnSetLeftCrop.Text = "Set Left Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSetLeftCrop, "Set the crop for the left side (timer and game) based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "off the math.")
        Me.btnSetLeftCrop.UseVisualStyleBackColor = True
        '
        'btnSaveRunnerCrop
        '
        Me.btnSaveRunnerCrop.Location = New System.Drawing.Point(7, 243)
        Me.btnSaveRunnerCrop.Name = "btnSaveRunnerCrop"
        Me.btnSaveRunnerCrop.Size = New System.Drawing.Size(142, 23)
        Me.btnSaveRunnerCrop.TabIndex = 21
        Me.btnSaveRunnerCrop.Text = "Save Runner Crop"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveRunnerCrop, "Saves the runner timer/game crop settings to a local" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file (for now).")
        Me.btnSaveRunnerCrop.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(176, 321)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Left Runner"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(512, 325)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Right Runner"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 30)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(26, 13)
        Me.Label23.TabIndex = 14
        Me.Label23.Text = "Top"
        '
        'txtDefaultCropTop
        '
        Me.txtDefaultCropTop.Location = New System.Drawing.Point(49, 27)
        Me.txtDefaultCropTop.Name = "txtDefaultCropTop"
        Me.txtDefaultCropTop.Size = New System.Drawing.Size(100, 20)
        Me.txtDefaultCropTop.TabIndex = 15
        '
        'txtDefaultCropBottom
        '
        Me.txtDefaultCropBottom.Location = New System.Drawing.Point(49, 53)
        Me.txtDefaultCropBottom.Name = "txtDefaultCropBottom"
        Me.txtDefaultCropBottom.Size = New System.Drawing.Size(100, 20)
        Me.txtDefaultCropBottom.TabIndex = 15
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 56)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "Bottom"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(12, 77)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(137, 23)
        Me.btnSaveSettings.TabIndex = 24
        Me.btnSaveSettings.Text = "Save Settings"
        Me.ttMainToolTip.SetToolTip(Me.btnSaveSettings, "Save the current user settings " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-Top/Bottom Crop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Connection Settings" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- OBS" &
        " Scene Names for runners/trackers/commentary")
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'lblOBS1ConnectedStatus
        '
        Me.lblOBS1ConnectedStatus.AutoSize = True
        Me.lblOBS1ConnectedStatus.Location = New System.Drawing.Point(7, 45)
        Me.lblOBS1ConnectedStatus.Name = "lblOBS1ConnectedStatus"
        Me.lblOBS1ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS1ConnectedStatus.TabIndex = 25
        Me.lblOBS1ConnectedStatus.Text = "Connected Status"
        '
        'cbLeftRunnerName
        '
        Me.cbLeftRunnerName.FormattingEnabled = True
        Me.cbLeftRunnerName.Location = New System.Drawing.Point(248, 317)
        Me.cbLeftRunnerName.Name = "cbLeftRunnerName"
        Me.cbLeftRunnerName.Size = New System.Drawing.Size(228, 21)
        Me.cbLeftRunnerName.TabIndex = 14
        '
        'cbRightRunnerName
        '
        Me.cbRightRunnerName.FormattingEnabled = True
        Me.cbRightRunnerName.Location = New System.Drawing.Point(591, 322)
        Me.cbRightRunnerName.Name = "cbRightRunnerName"
        Me.cbRightRunnerName.Size = New System.Drawing.Size(228, 21)
        Me.cbRightRunnerName.TabIndex = 26
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(133, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(91, 13)
        Me.Label25.TabIndex = 27
        Me.Label25.Text = "Connection String"
        '
        'txtConnectionString1
        '
        Me.txtConnectionString1.Location = New System.Drawing.Point(230, 19)
        Me.txtConnectionString1.Name = "txtConnectionString1"
        Me.txtConnectionString1.Size = New System.Drawing.Size(160, 20)
        Me.txtConnectionString1.TabIndex = 28
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(397, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Password"
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(456, 19)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.Size = New System.Drawing.Size(160, 20)
        Me.txtPassword1.TabIndex = 30
        '
        'gbConnection1
        '
        Me.gbConnection1.Controls.Add(Me.btnConnectOBS1)
        Me.gbConnection1.Controls.Add(Me.Label26)
        Me.gbConnection1.Controls.Add(Me.lblOBS1ConnectedStatus)
        Me.gbConnection1.Controls.Add(Me.txtPassword1)
        Me.gbConnection1.Controls.Add(Me.txtConnectionString1)
        Me.gbConnection1.Controls.Add(Me.Label25)
        Me.gbConnection1.Location = New System.Drawing.Point(173, 27)
        Me.gbConnection1.Name = "gbConnection1"
        Me.gbConnection1.Size = New System.Drawing.Size(620, 71)
        Me.gbConnection1.TabIndex = 31
        Me.gbConnection1.TabStop = False
        Me.gbConnection1.Text = "Connection 1"
        '
        'gbConnection2
        '
        Me.gbConnection2.Controls.Add(Me.btnConnectOBS2)
        Me.gbConnection2.Controls.Add(Me.Label27)
        Me.gbConnection2.Controls.Add(Me.lblOBS2ConnectedStatus)
        Me.gbConnection2.Controls.Add(Me.txtPassword2)
        Me.gbConnection2.Controls.Add(Me.txtConnectionString2)
        Me.gbConnection2.Controls.Add(Me.Label29)
        Me.gbConnection2.Location = New System.Drawing.Point(173, 108)
        Me.gbConnection2.Name = "gbConnection2"
        Me.gbConnection2.Size = New System.Drawing.Size(620, 71)
        Me.gbConnection2.TabIndex = 32
        Me.gbConnection2.TabStop = False
        Me.gbConnection2.Text = "Connection 2"
        '
        'btnConnectOBS2
        '
        Me.btnConnectOBS2.Location = New System.Drawing.Point(10, 19)
        Me.btnConnectOBS2.Name = "btnConnectOBS2"
        Me.btnConnectOBS2.Size = New System.Drawing.Size(117, 23)
        Me.btnConnectOBS2.TabIndex = 11
        Me.btnConnectOBS2.Text = "Connect OBS 2"
        Me.btnConnectOBS2.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(397, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 13)
        Me.Label27.TabIndex = 29
        Me.Label27.Text = "Password"
        '
        'lblOBS2ConnectedStatus
        '
        Me.lblOBS2ConnectedStatus.AutoSize = True
        Me.lblOBS2ConnectedStatus.Location = New System.Drawing.Point(7, 45)
        Me.lblOBS2ConnectedStatus.Name = "lblOBS2ConnectedStatus"
        Me.lblOBS2ConnectedStatus.Size = New System.Drawing.Size(92, 13)
        Me.lblOBS2ConnectedStatus.TabIndex = 25
        Me.lblOBS2ConnectedStatus.Text = "Connected Status"
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(456, 19)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.Size = New System.Drawing.Size(160, 20)
        Me.txtPassword2.TabIndex = 30
        '
        'txtConnectionString2
        '
        Me.txtConnectionString2.Location = New System.Drawing.Point(230, 19)
        Me.txtConnectionString2.Name = "txtConnectionString2"
        Me.txtConnectionString2.Size = New System.Drawing.Size(160, 20)
        Me.txtConnectionString2.TabIndex = 28
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(133, 24)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(91, 13)
        Me.Label29.TabIndex = 27
        Me.Label29.Text = "Connection String"
        '
        'btnGetCropFromOBS
        '
        Me.btnGetCropFromOBS.Location = New System.Drawing.Point(28, 129)
        Me.btnGetCropFromOBS.Name = "btnGetCropFromOBS"
        Me.btnGetCropFromOBS.Size = New System.Drawing.Size(121, 23)
        Me.btnGetCropFromOBS.TabIndex = 33
        Me.btnGetCropFromOBS.Text = "Get Crop From OBS"
        Me.ttMainToolTip.SetToolTip(Me.btnGetCropFromOBS, "Gets the current Timer/Game crops from OBS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WARNING!  Clicking YES to the messa" &
        "ge will overwrite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the current crop numbers in there!")
        Me.btnGetCropFromOBS.UseVisualStyleBackColor = True
        '
        'lblLMasterHeight
        '
        Me.lblLMasterHeight.AutoSize = True
        Me.lblLMasterHeight.Location = New System.Drawing.Point(165, 587)
        Me.lblLMasterHeight.Name = "lblLMasterHeight"
        Me.lblLMasterHeight.Size = New System.Drawing.Size(73, 13)
        Me.lblLMasterHeight.TabIndex = 34
        Me.lblLMasterHeight.Text = "Master Height"
        '
        'lblLMasterWidth
        '
        Me.lblLMasterWidth.AutoSize = True
        Me.lblLMasterWidth.Location = New System.Drawing.Point(165, 608)
        Me.lblLMasterWidth.Name = "lblLMasterWidth"
        Me.lblLMasterWidth.Size = New System.Drawing.Size(70, 13)
        Me.lblLMasterWidth.TabIndex = 35
        Me.lblLMasterWidth.Text = "Master Width"
        '
        'lblLSourceHeight
        '
        Me.lblLSourceHeight.AutoSize = True
        Me.lblLSourceHeight.Location = New System.Drawing.Point(165, 628)
        Me.lblLSourceHeight.Name = "lblLSourceHeight"
        Me.lblLSourceHeight.Size = New System.Drawing.Size(75, 13)
        Me.lblLSourceHeight.TabIndex = 36
        Me.lblLSourceHeight.Text = "Source Height"
        '
        'lblLSourceWidth
        '
        Me.lblLSourceWidth.AutoSize = True
        Me.lblLSourceWidth.Location = New System.Drawing.Point(165, 649)
        Me.lblLSourceWidth.Name = "lblLSourceWidth"
        Me.lblLSourceWidth.Size = New System.Drawing.Size(72, 13)
        Me.lblLSourceWidth.TabIndex = 37
        Me.lblLSourceWidth.Text = "Source Width"
        '
        'lblRSourceWidth
        '
        Me.lblRSourceWidth.AutoSize = True
        Me.lblRSourceWidth.Location = New System.Drawing.Point(508, 652)
        Me.lblRSourceWidth.Name = "lblRSourceWidth"
        Me.lblRSourceWidth.Size = New System.Drawing.Size(72, 13)
        Me.lblRSourceWidth.TabIndex = 41
        Me.lblRSourceWidth.Text = "Source Width"
        '
        'lblRSourceHeight
        '
        Me.lblRSourceHeight.AutoSize = True
        Me.lblRSourceHeight.Location = New System.Drawing.Point(508, 631)
        Me.lblRSourceHeight.Name = "lblRSourceHeight"
        Me.lblRSourceHeight.Size = New System.Drawing.Size(75, 13)
        Me.lblRSourceHeight.TabIndex = 40
        Me.lblRSourceHeight.Text = "Source Height"
        '
        'lblRMasterWidth
        '
        Me.lblRMasterWidth.AutoSize = True
        Me.lblRMasterWidth.Location = New System.Drawing.Point(508, 611)
        Me.lblRMasterWidth.Name = "lblRMasterWidth"
        Me.lblRMasterWidth.Size = New System.Drawing.Size(70, 13)
        Me.lblRMasterWidth.TabIndex = 39
        Me.lblRMasterWidth.Text = "Master Width"
        '
        'lblRMasterHeight
        '
        Me.lblRMasterHeight.AutoSize = True
        Me.lblRMasterHeight.Location = New System.Drawing.Point(508, 590)
        Me.lblRMasterHeight.Name = "lblRMasterHeight"
        Me.lblRMasterHeight.Size = New System.Drawing.Size(73, 13)
        Me.lblRMasterHeight.TabIndex = 38
        Me.lblRMasterHeight.Text = "Master Height"
        '
        'chkOldMath
        '
        Me.chkOldMath.AutoSize = True
        Me.chkOldMath.Location = New System.Drawing.Point(7, 319)
        Me.chkOldMath.Name = "chkOldMath"
        Me.chkOldMath.Size = New System.Drawing.Size(88, 17)
        Me.chkOldMath.TabIndex = 31
        Me.chkOldMath.Text = "Original Math"
        Me.ttMainToolTip.SetToolTip(Me.chkOldMath, "Check this to check the original cropping math.")
        Me.chkOldMath.UseVisualStyleBackColor = True
        Me.chkOldMath.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(518, 300)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 13)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "Right Runner Name"
        '
        'cbRightRunnerOBS
        '
        Me.cbRightRunnerOBS.FormattingEnabled = True
        Me.cbRightRunnerOBS.Location = New System.Drawing.Point(629, 297)
        Me.cbRightRunnerOBS.Name = "cbRightRunnerOBS"
        Me.cbRightRunnerOBS.Size = New System.Drawing.Size(121, 21)
        Me.cbRightRunnerOBS.TabIndex = 14
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(350, 50)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(165, 13)
        Me.Label30.TabIndex = 43
        Me.Label30.Text = "Right Tracker Name OBS Source"
        '
        'cbRightTrackerOBS
        '
        Me.cbRightTrackerOBS.FormattingEnabled = True
        Me.cbRightTrackerOBS.Location = New System.Drawing.Point(517, 45)
        Me.cbRightTrackerOBS.Name = "cbRightTrackerOBS"
        Me.cbRightTrackerOBS.Size = New System.Drawing.Size(132, 21)
        Me.cbRightTrackerOBS.TabIndex = 42
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 45)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(158, 13)
        Me.Label31.TabIndex = 45
        Me.Label31.Text = "Left Tracker Name OBS Source"
        '
        'cbLeftTrackerOBS
        '
        Me.cbLeftTrackerOBS.FormattingEnabled = True
        Me.cbLeftTrackerOBS.Location = New System.Drawing.Point(170, 42)
        Me.cbLeftTrackerOBS.Name = "cbLeftTrackerOBS"
        Me.cbLeftTrackerOBS.Size = New System.Drawing.Size(137, 21)
        Me.cbLeftTrackerOBS.TabIndex = 44
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(174, 295)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 13)
        Me.Label32.TabIndex = 47
        Me.Label32.Text = "Left Runner Name"
        '
        'cbLeftRunnerOBS
        '
        Me.cbLeftRunnerOBS.FormattingEnabled = True
        Me.cbLeftRunnerOBS.Location = New System.Drawing.Point(285, 292)
        Me.cbLeftRunnerOBS.Name = "cbLeftRunnerOBS"
        Me.cbLeftRunnerOBS.Size = New System.Drawing.Size(121, 21)
        Me.cbLeftRunnerOBS.TabIndex = 46
        '
        'txtLeftTrackerURL
        '
        Me.txtLeftTrackerURL.Location = New System.Drawing.Point(117, 69)
        Me.txtLeftTrackerURL.Name = "txtLeftTrackerURL"
        Me.txtLeftTrackerURL.Size = New System.Drawing.Size(190, 20)
        Me.txtLeftTrackerURL.TabIndex = 31
        '
        'txtRightTrackerURL
        '
        Me.txtRightTrackerURL.Location = New System.Drawing.Point(461, 73)
        Me.txtRightTrackerURL.Name = "txtRightTrackerURL"
        Me.txtRightTrackerURL.Size = New System.Drawing.Size(189, 20)
        Me.txtRightTrackerURL.TabIndex = 48
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(8, 76)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(90, 13)
        Me.Label33.TabIndex = 49
        Me.Label33.Text = "Left Tracker URL"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(350, 76)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(97, 13)
        Me.Label34.TabIndex = 50
        Me.Label34.Text = "Right Tracker URL"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(124, 13)
        Me.Label35.TabIndex = 52
        Me.Label35.Text = "Commentary OBS Souce"
        '
        'cbCommentaryOBS
        '
        Me.cbCommentaryOBS.FormattingEnabled = True
        Me.cbCommentaryOBS.Location = New System.Drawing.Point(136, 16)
        Me.cbCommentaryOBS.Name = "cbCommentaryOBS"
        Me.cbCommentaryOBS.Size = New System.Drawing.Size(121, 21)
        Me.cbCommentaryOBS.TabIndex = 51
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(263, 19)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(101, 13)
        Me.Label36.TabIndex = 54
        Me.Label36.Text = "Commentary Names"
        '
        'txtCommentaryNames
        '
        Me.txtCommentaryNames.Location = New System.Drawing.Point(370, 16)
        Me.txtCommentaryNames.Name = "txtCommentaryNames"
        Me.txtCommentaryNames.Size = New System.Drawing.Size(280, 20)
        Me.txtCommentaryNames.TabIndex = 53
        '
        'btnSetTrackCommNames
        '
        Me.btnSetTrackCommNames.Location = New System.Drawing.Point(7, 103)
        Me.btnSetTrackCommNames.Name = "btnSetTrackCommNames"
        Me.btnSetTrackCommNames.Size = New System.Drawing.Size(142, 23)
        Me.btnSetTrackCommNames.TabIndex = 55
        Me.btnSetTrackCommNames.Text = "Set Track/Comms/Names"
        Me.ttMainToolTip.SetToolTip(Me.btnSetTrackCommNames, "Sends the current text settings to OBS if there is text entered into the form." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Tracker URL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Runner Names" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Commentary Names")
        Me.btnSetTrackCommNames.UseVisualStyleBackColor = True
        '
        'chkNewNewMath
        '
        Me.chkNewNewMath.AutoSize = True
        Me.chkNewNewMath.Location = New System.Drawing.Point(7, 296)
        Me.chkNewNewMath.Name = "chkNewNewMath"
        Me.chkNewNewMath.Size = New System.Drawing.Size(75, 17)
        Me.chkNewNewMath.TabIndex = 56
        Me.chkNewNewMath.Text = "New Math"
        Me.ttMainToolTip.SetToolTip(Me.chkNewNewMath, "This checks the 2nd version of the math trying" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to account for the black bars in " &
        "VLC")
        Me.chkNewNewMath.UseVisualStyleBackColor = True
        Me.chkNewNewMath.Visible = False
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(847, 24)
        Me.mnuMainMenu.TabIndex = 57
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadOBSINIToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ReadOBSINIToolStripMenuItem
        '
        Me.ReadOBSINIToolStripMenuItem.Name = "ReadOBSINIToolStripMenuItem"
        Me.ReadOBSINIToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ReadOBSINIToolStripMenuItem.Text = "Read OBS INI"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
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
        'gbTrackerComms
        '
        Me.gbTrackerComms.Controls.Add(Me.Label35)
        Me.gbTrackerComms.Controls.Add(Me.cbRightTrackerOBS)
        Me.gbTrackerComms.Controls.Add(Me.Label30)
        Me.gbTrackerComms.Controls.Add(Me.Label36)
        Me.gbTrackerComms.Controls.Add(Me.cbLeftTrackerOBS)
        Me.gbTrackerComms.Controls.Add(Me.txtCommentaryNames)
        Me.gbTrackerComms.Controls.Add(Me.Label31)
        Me.gbTrackerComms.Controls.Add(Me.txtLeftTrackerURL)
        Me.gbTrackerComms.Controls.Add(Me.cbCommentaryOBS)
        Me.gbTrackerComms.Controls.Add(Me.txtRightTrackerURL)
        Me.gbTrackerComms.Controls.Add(Me.Label34)
        Me.gbTrackerComms.Controls.Add(Me.Label33)
        Me.gbTrackerComms.Location = New System.Drawing.Point(168, 184)
        Me.gbTrackerComms.Name = "gbTrackerComms"
        Me.gbTrackerComms.Size = New System.Drawing.Size(658, 100)
        Me.gbTrackerComms.TabIndex = 58
        Me.gbTrackerComms.TabStop = False
        Me.gbTrackerComms.Text = "Tracker / Comms info"
        '
        'chkDifferentMath
        '
        Me.chkDifferentMath.AutoSize = True
        Me.chkDifferentMath.Location = New System.Drawing.Point(7, 272)
        Me.chkDifferentMath.Name = "chkDifferentMath"
        Me.chkDifferentMath.Size = New System.Drawing.Size(95, 17)
        Me.chkDifferentMath.TabIndex = 59
        Me.chkDifferentMath.Text = "View Old Math"
        Me.ttMainToolTip.SetToolTip(Me.chkDifferentMath, "Check this to enable looking at the obsolete math" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "that was left in for informati" &
        "onal purposes.")
        Me.chkDifferentMath.UseVisualStyleBackColor = True
        '
        'OBSWebSocketCropper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 665)
        Me.Controls.Add(Me.chkDifferentMath)
        Me.Controls.Add(Me.gbTrackerComms)
        Me.Controls.Add(Me.chkNewNewMath)
        Me.Controls.Add(Me.btnSetTrackCommNames)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.cbLeftRunnerOBS)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.chkOldMath)
        Me.Controls.Add(Me.cbRightRunnerOBS)
        Me.Controls.Add(Me.lblRSourceWidth)
        Me.Controls.Add(Me.lblRSourceHeight)
        Me.Controls.Add(Me.lblRMasterWidth)
        Me.Controls.Add(Me.lblRMasterHeight)
        Me.Controls.Add(Me.lblLSourceWidth)
        Me.Controls.Add(Me.lblLSourceHeight)
        Me.Controls.Add(Me.lblLMasterWidth)
        Me.Controls.Add(Me.lblLMasterHeight)
        Me.Controls.Add(Me.btnGetCropFromOBS)
        Me.Controls.Add(Me.gbConnection2)
        Me.Controls.Add(Me.gbConnection1)
        Me.Controls.Add(Me.cbRightRunnerName)
        Me.Controls.Add(Me.cbLeftRunnerName)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.txtDefaultCropBottom)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtDefaultCropTop)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnSaveRunnerCrop)
        Me.Controls.Add(Me.btnSetLeftCrop)
        Me.Controls.Add(Me.gbLeftTimerWindow)
        Me.Controls.Add(Me.gbLeftGameWindow)
        Me.Controls.Add(Me.gbRightTimerWindow)
        Me.Controls.Add(Me.gbRightGameWindow)
        Me.Controls.Add(Me.btnSetMaster)
        Me.Controls.Add(Me.btnRefreshScenes)
        Me.Controls.Add(Me.btnSetRightCrop)
        Me.Controls.Add(Me.btnGetCrop)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.Name = "OBSWebSocketCropper"
        Me.Text = "OBS Websocket Cropper"
        Me.gbRightGameWindow.ResumeLayout(False)
        Me.gbRightGameWindow.PerformLayout()
        Me.gbRightTimerWindow.ResumeLayout(False)
        Me.gbRightTimerWindow.PerformLayout()
        Me.gbLeftTimerWindow.ResumeLayout(False)
        Me.gbLeftTimerWindow.PerformLayout()
        Me.gbLeftGameWindow.ResumeLayout(False)
        Me.gbLeftGameWindow.PerformLayout()
        Me.gbConnection1.ResumeLayout(False)
        Me.gbConnection1.PerformLayout()
        Me.gbConnection2.ResumeLayout(False)
        Me.gbConnection2.PerformLayout()
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.gbTrackerComms.ResumeLayout(False)
        Me.gbTrackerComms.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbRightGameWindow As ComboBox
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
    Friend WithEvents btnGetCrop As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnRefreshScenes As Button
    Friend WithEvents btnSetMaster As Button
    Friend WithEvents gbRightGameWindow As GroupBox
    Friend WithEvents gbRightTimerWindow As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbRightTimerWindow As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCropRightTimer_Top As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCropRightTimer_Left As TextBox
    Friend WithEvents txtCropRightTimer_Bottom As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCropRightTimer_Right As TextBox
    Friend WithEvents gbLeftTimerWindow As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbLeftTimerWindow As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCropLeftTimer_Top As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCropLeftTimer_Left As TextBox
    Friend WithEvents txtCropLeftTimer_Bottom As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCropLeftTimer_Right As TextBox
    Friend WithEvents gbLeftGameWindow As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbLeftGameWindow As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCropLeftGame_Top As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCropLeftGame_Left As TextBox
    Friend WithEvents txtCropLeftGame_Bottom As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtCropLeftGame_Right As TextBox
    Friend WithEvents btnSetLeftCrop As Button
    Friend WithEvents btnSaveRunnerCrop As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtDefaultCropTop As TextBox
    Friend WithEvents txtDefaultCropBottom As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents lblOBS1ConnectedStatus As Label
    Friend WithEvents cbLeftRunnerName As ComboBox
    Friend WithEvents cbRightRunnerName As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtConnectionString1 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtPassword1 As TextBox
    Friend WithEvents gbConnection1 As GroupBox
    Friend WithEvents gbConnection2 As GroupBox
    Friend WithEvents btnConnectOBS2 As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents lblOBS2ConnectedStatus As Label
    Friend WithEvents txtPassword2 As TextBox
    Friend WithEvents txtConnectionString2 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents btnGetCropFromOBS As Button
    Friend WithEvents lblLMasterHeight As Label
    Friend WithEvents lblLMasterWidth As Label
    Friend WithEvents lblLSourceHeight As Label
    Friend WithEvents lblLSourceWidth As Label
    Friend WithEvents lblRSourceWidth As Label
    Friend WithEvents lblRSourceHeight As Label
    Friend WithEvents lblRMasterWidth As Label
    Friend WithEvents lblRMasterHeight As Label
    Friend WithEvents chkOldMath As CheckBox
    Friend WithEvents Label28 As Label
    Friend WithEvents cbRightRunnerOBS As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents cbRightTrackerOBS As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents cbLeftTrackerOBS As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents cbLeftRunnerOBS As ComboBox
    Friend WithEvents txtLeftTrackerURL As TextBox
    Friend WithEvents txtRightTrackerURL As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents cbCommentaryOBS As ComboBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtCommentaryNames As TextBox
    Friend WithEvents btnSetTrackCommNames As Button
    Friend WithEvents chkNewNewMath As CheckBox
    Friend WithEvents mnuMainMenu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ttMainToolTip As ToolTip
    Friend WithEvents ReadOBSINIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents gbTrackerComms As GroupBox
    Friend WithEvents chkDifferentMath As CheckBox
End Class
