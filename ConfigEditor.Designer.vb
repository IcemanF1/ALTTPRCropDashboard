<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigEditor
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
        Me.gbTwoRunners = New System.Windows.Forms.GroupBox()
        Me.gbGameTwoPlayer = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPositionYGameRightTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeHeightGameTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXGameRightTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeWidthGameTwoPlayer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPositionXGameLeftTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionYGameLeftTwoPlayer = New System.Windows.Forms.TextBox()
        Me.gbTimerTwoPlayer = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerRightTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerRightTwoPlayer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerLeftTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerLeftTwoPlayer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBoundingSizeWidthTimerTwoPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeHeightTimerTwoPlayer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbConfigFiles = New System.Windows.Forms.ComboBox()
        Me.gbFourRunners = New System.Windows.Forms.GroupBox()
        Me.gbGameFourPlayerBottom = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPositionYGameBottomRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXGameBottomRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPositionXGameBottomLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionYGameBottomLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.gbTimerFourPlayerBottom = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerBottomRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerBottomRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerBottomLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerBottomLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.gbGameFourPlayerTop = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPositionYGameTopRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeHeightGameFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXGameTopRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeWidthGameFourPlayer = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPositionXGameTopLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionYGameTopLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.gbTimerFourPlayerTop = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerTopRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerTopRightFourPlayer = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPositionYTimerTopLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtPositionXTimerTopLeftFourPlayer = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtBoundingSizeWidthTimerFourPlayer = New System.Windows.Forms.TextBox()
        Me.txtBoundingSizeHeightTimerFourPlayer = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.sfdSaveConfig = New System.Windows.Forms.SaveFileDialog()
        Me.gbTwoRunners.SuspendLayout()
        Me.gbGameTwoPlayer.SuspendLayout()
        Me.gbTimerTwoPlayer.SuspendLayout()
        Me.gbFourRunners.SuspendLayout()
        Me.gbGameFourPlayerBottom.SuspendLayout()
        Me.gbTimerFourPlayerBottom.SuspendLayout()
        Me.gbGameFourPlayerTop.SuspendLayout()
        Me.gbTimerFourPlayerTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTwoRunners
        '
        Me.gbTwoRunners.Controls.Add(Me.gbGameTwoPlayer)
        Me.gbTwoRunners.Controls.Add(Me.gbTimerTwoPlayer)
        Me.gbTwoRunners.Location = New System.Drawing.Point(12, 41)
        Me.gbTwoRunners.Name = "gbTwoRunners"
        Me.gbTwoRunners.Size = New System.Drawing.Size(848, 131)
        Me.gbTwoRunners.TabIndex = 0
        Me.gbTwoRunners.TabStop = False
        Me.gbTwoRunners.Text = "2 Runners"
        '
        'gbGameTwoPlayer
        '
        Me.gbGameTwoPlayer.Controls.Add(Me.Label10)
        Me.gbGameTwoPlayer.Controls.Add(Me.Label4)
        Me.gbGameTwoPlayer.Controls.Add(Me.Label11)
        Me.gbGameTwoPlayer.Controls.Add(Me.Label5)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtPositionYGameRightTwoPlayer)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtBoundingSizeHeightGameTwoPlayer)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtPositionXGameRightTwoPlayer)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtBoundingSizeWidthGameTwoPlayer)
        Me.gbGameTwoPlayer.Controls.Add(Me.Label12)
        Me.gbGameTwoPlayer.Controls.Add(Me.Label13)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtPositionXGameLeftTwoPlayer)
        Me.gbGameTwoPlayer.Controls.Add(Me.txtPositionYGameLeftTwoPlayer)
        Me.gbGameTwoPlayer.Location = New System.Drawing.Point(407, 19)
        Me.gbGameTwoPlayer.Name = "gbGameTwoPlayer"
        Me.gbGameTwoPlayer.Size = New System.Drawing.Size(409, 100)
        Me.gbGameTwoPlayer.TabIndex = 1
        Me.gbGameTwoPlayer.TabStop = False
        Me.gbGameTwoPlayer.Text = "Game Info"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(195, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Position Y Right Runner"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(195, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Bounding Box Width"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Position X Right Runner"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Bounding Box Height"
        '
        'txtPositionYGameRightTwoPlayer
        '
        Me.txtPositionYGameRightTwoPlayer.Location = New System.Drawing.Point(318, 66)
        Me.txtPositionYGameRightTwoPlayer.Name = "txtPositionYGameRightTwoPlayer"
        Me.txtPositionYGameRightTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameRightTwoPlayer.TabIndex = 21
        '
        'txtBoundingSizeHeightGameTwoPlayer
        '
        Me.txtBoundingSizeHeightGameTwoPlayer.Location = New System.Drawing.Point(128, 13)
        Me.txtBoundingSizeHeightGameTwoPlayer.Name = "txtBoundingSizeHeightGameTwoPlayer"
        Me.txtBoundingSizeHeightGameTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeHeightGameTwoPlayer.TabIndex = 7
        '
        'txtPositionXGameRightTwoPlayer
        '
        Me.txtPositionXGameRightTwoPlayer.Location = New System.Drawing.Point(128, 66)
        Me.txtPositionXGameRightTwoPlayer.Name = "txtPositionXGameRightTwoPlayer"
        Me.txtPositionXGameRightTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameRightTwoPlayer.TabIndex = 19
        '
        'txtBoundingSizeWidthGameTwoPlayer
        '
        Me.txtBoundingSizeWidthGameTwoPlayer.Location = New System.Drawing.Point(318, 13)
        Me.txtBoundingSizeWidthGameTwoPlayer.Name = "txtBoundingSizeWidthGameTwoPlayer"
        Me.txtBoundingSizeWidthGameTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeWidthGameTwoPlayer.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(195, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Position Y Left Runner"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Position X Left Runner"
        '
        'txtPositionXGameLeftTwoPlayer
        '
        Me.txtPositionXGameLeftTwoPlayer.Location = New System.Drawing.Point(128, 40)
        Me.txtPositionXGameLeftTwoPlayer.Name = "txtPositionXGameLeftTwoPlayer"
        Me.txtPositionXGameLeftTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameLeftTwoPlayer.TabIndex = 15
        '
        'txtPositionYGameLeftTwoPlayer
        '
        Me.txtPositionYGameLeftTwoPlayer.Location = New System.Drawing.Point(318, 40)
        Me.txtPositionYGameLeftTwoPlayer.Name = "txtPositionYGameLeftTwoPlayer"
        Me.txtPositionYGameLeftTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameLeftTwoPlayer.TabIndex = 17
        '
        'gbTimerTwoPlayer
        '
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label8)
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label111)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtPositionYTimerRightTwoPlayer)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtPositionXTimerRightTwoPlayer)
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label6)
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label7)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtPositionYTimerLeftTwoPlayer)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtPositionXTimerLeftTwoPlayer)
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label3)
        Me.gbTimerTwoPlayer.Controls.Add(Me.Label2)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtBoundingSizeWidthTimerTwoPlayer)
        Me.gbTimerTwoPlayer.Controls.Add(Me.txtBoundingSizeHeightTimerTwoPlayer)
        Me.gbTimerTwoPlayer.Location = New System.Drawing.Point(6, 19)
        Me.gbTimerTwoPlayer.Name = "gbTimerTwoPlayer"
        Me.gbTimerTwoPlayer.Size = New System.Drawing.Size(395, 100)
        Me.gbTimerTwoPlayer.TabIndex = 0
        Me.gbTimerTwoPlayer.TabStop = False
        Me.gbTimerTwoPlayer.Text = "Timer Info"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(195, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Position Y Right Runner"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(6, 69)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(120, 13)
        Me.Label111.TabIndex = 12
        Me.Label111.Text = "Position X Right Runner"
        '
        'txtPositionYTimerRightTwoPlayer
        '
        Me.txtPositionYTimerRightTwoPlayer.Location = New System.Drawing.Point(318, 66)
        Me.txtPositionYTimerRightTwoPlayer.Name = "txtPositionYTimerRightTwoPlayer"
        Me.txtPositionYTimerRightTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerRightTwoPlayer.TabIndex = 13
        '
        'txtPositionXTimerRightTwoPlayer
        '
        Me.txtPositionXTimerRightTwoPlayer.Location = New System.Drawing.Point(128, 66)
        Me.txtPositionXTimerRightTwoPlayer.Name = "txtPositionXTimerRightTwoPlayer"
        Me.txtPositionXTimerRightTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerRightTwoPlayer.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(195, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Position Y Left Runner"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Position X Left Runner"
        '
        'txtPositionYTimerLeftTwoPlayer
        '
        Me.txtPositionYTimerLeftTwoPlayer.Location = New System.Drawing.Point(318, 40)
        Me.txtPositionYTimerLeftTwoPlayer.Name = "txtPositionYTimerLeftTwoPlayer"
        Me.txtPositionYTimerLeftTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerLeftTwoPlayer.TabIndex = 9
        '
        'txtPositionXTimerLeftTwoPlayer
        '
        Me.txtPositionXTimerLeftTwoPlayer.Location = New System.Drawing.Point(128, 40)
        Me.txtPositionXTimerLeftTwoPlayer.Name = "txtPositionXTimerLeftTwoPlayer"
        Me.txtPositionXTimerLeftTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerLeftTwoPlayer.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Bounding Box Width"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Bounding Box Height"
        '
        'txtBoundingSizeWidthTimerTwoPlayer
        '
        Me.txtBoundingSizeWidthTimerTwoPlayer.Location = New System.Drawing.Point(318, 13)
        Me.txtBoundingSizeWidthTimerTwoPlayer.Name = "txtBoundingSizeWidthTimerTwoPlayer"
        Me.txtBoundingSizeWidthTimerTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeWidthTimerTwoPlayer.TabIndex = 5
        '
        'txtBoundingSizeHeightTimerTwoPlayer
        '
        Me.txtBoundingSizeHeightTimerTwoPlayer.Location = New System.Drawing.Point(128, 13)
        Me.txtBoundingSizeHeightTimerTwoPlayer.Name = "txtBoundingSizeHeightTimerTwoPlayer"
        Me.txtBoundingSizeHeightTimerTwoPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeHeightTimerTwoPlayer.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Config File"
        '
        'cbConfigFiles
        '
        Me.cbConfigFiles.FormattingEnabled = True
        Me.cbConfigFiles.Location = New System.Drawing.Point(74, 6)
        Me.cbConfigFiles.Name = "cbConfigFiles"
        Me.cbConfigFiles.Size = New System.Drawing.Size(217, 21)
        Me.cbConfigFiles.TabIndex = 2
        '
        'gbFourRunners
        '
        Me.gbFourRunners.Controls.Add(Me.gbGameFourPlayerBottom)
        Me.gbFourRunners.Controls.Add(Me.gbTimerFourPlayerBottom)
        Me.gbFourRunners.Controls.Add(Me.gbGameFourPlayerTop)
        Me.gbFourRunners.Controls.Add(Me.gbTimerFourPlayerTop)
        Me.gbFourRunners.Location = New System.Drawing.Point(12, 160)
        Me.gbFourRunners.Name = "gbFourRunners"
        Me.gbFourRunners.Size = New System.Drawing.Size(848, 216)
        Me.gbFourRunners.TabIndex = 3
        Me.gbFourRunners.TabStop = False
        Me.gbFourRunners.Text = "4 Runners"
        '
        'gbGameFourPlayerBottom
        '
        Me.gbGameFourPlayerBottom.Controls.Add(Me.Label25)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.Label27)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.txtPositionYGameBottomRightFourPlayer)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.txtPositionXGameBottomRightFourPlayer)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.Label29)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.Label30)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.txtPositionXGameBottomLeftFourPlayer)
        Me.gbGameFourPlayerBottom.Controls.Add(Me.txtPositionYGameBottomLeftFourPlayer)
        Me.gbGameFourPlayerBottom.Location = New System.Drawing.Point(407, 125)
        Me.gbGameFourPlayerBottom.Name = "gbGameFourPlayerBottom"
        Me.gbGameFourPlayerBottom.Size = New System.Drawing.Size(409, 77)
        Me.gbGameFourPlayerBottom.TabIndex = 16
        Me.gbGameFourPlayerBottom.TabStop = False
        Me.gbGameFourPlayerBottom.Text = "Game Info - Bottom"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(195, 48)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 13)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "Position Y Right Runner"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 48)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(120, 13)
        Me.Label27.TabIndex = 20
        Me.Label27.Text = "Position X Right Runner"
        '
        'txtPositionYGameBottomRightFourPlayer
        '
        Me.txtPositionYGameBottomRightFourPlayer.Location = New System.Drawing.Point(318, 45)
        Me.txtPositionYGameBottomRightFourPlayer.Name = "txtPositionYGameBottomRightFourPlayer"
        Me.txtPositionYGameBottomRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameBottomRightFourPlayer.TabIndex = 21
        '
        'txtPositionXGameBottomRightFourPlayer
        '
        Me.txtPositionXGameBottomRightFourPlayer.Location = New System.Drawing.Point(128, 45)
        Me.txtPositionXGameBottomRightFourPlayer.Name = "txtPositionXGameBottomRightFourPlayer"
        Me.txtPositionXGameBottomRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameBottomRightFourPlayer.TabIndex = 19
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(195, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "Position Y Left Runner"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(113, 13)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "Position X Left Runner"
        '
        'txtPositionXGameBottomLeftFourPlayer
        '
        Me.txtPositionXGameBottomLeftFourPlayer.Location = New System.Drawing.Point(128, 19)
        Me.txtPositionXGameBottomLeftFourPlayer.Name = "txtPositionXGameBottomLeftFourPlayer"
        Me.txtPositionXGameBottomLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameBottomLeftFourPlayer.TabIndex = 15
        '
        'txtPositionYGameBottomLeftFourPlayer
        '
        Me.txtPositionYGameBottomLeftFourPlayer.Location = New System.Drawing.Point(318, 19)
        Me.txtPositionYGameBottomLeftFourPlayer.Name = "txtPositionYGameBottomLeftFourPlayer"
        Me.txtPositionYGameBottomLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameBottomLeftFourPlayer.TabIndex = 17
        '
        'gbTimerFourPlayerBottom
        '
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.Label31)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.Label32)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.txtPositionYTimerBottomRightFourPlayer)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.txtPositionXTimerBottomRightFourPlayer)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.Label33)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.Label34)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.txtPositionYTimerBottomLeftFourPlayer)
        Me.gbTimerFourPlayerBottom.Controls.Add(Me.txtPositionXTimerBottomLeftFourPlayer)
        Me.gbTimerFourPlayerBottom.Location = New System.Drawing.Point(6, 125)
        Me.gbTimerFourPlayerBottom.Name = "gbTimerFourPlayerBottom"
        Me.gbTimerFourPlayerBottom.Size = New System.Drawing.Size(395, 77)
        Me.gbTimerFourPlayerBottom.TabIndex = 15
        Me.gbTimerFourPlayerBottom.TabStop = False
        Me.gbTimerFourPlayerBottom.Text = "Timer Info - Bottom"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(195, 48)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Position Y Right Runner"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 48)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(120, 13)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Position X Right Runner"
        '
        'txtPositionYTimerBottomRightFourPlayer
        '
        Me.txtPositionYTimerBottomRightFourPlayer.Location = New System.Drawing.Point(318, 45)
        Me.txtPositionYTimerBottomRightFourPlayer.Name = "txtPositionYTimerBottomRightFourPlayer"
        Me.txtPositionYTimerBottomRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerBottomRightFourPlayer.TabIndex = 13
        '
        'txtPositionXTimerBottomRightFourPlayer
        '
        Me.txtPositionXTimerBottomRightFourPlayer.Location = New System.Drawing.Point(128, 45)
        Me.txtPositionXTimerBottomRightFourPlayer.Name = "txtPositionXTimerBottomRightFourPlayer"
        Me.txtPositionXTimerBottomRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerBottomRightFourPlayer.TabIndex = 11
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(195, 22)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 13)
        Me.Label33.TabIndex = 10
        Me.Label33.Text = "Position Y Left Runner"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 22)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(113, 13)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Position X Left Runner"
        '
        'txtPositionYTimerBottomLeftFourPlayer
        '
        Me.txtPositionYTimerBottomLeftFourPlayer.Location = New System.Drawing.Point(318, 19)
        Me.txtPositionYTimerBottomLeftFourPlayer.Name = "txtPositionYTimerBottomLeftFourPlayer"
        Me.txtPositionYTimerBottomLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerBottomLeftFourPlayer.TabIndex = 9
        '
        'txtPositionXTimerBottomLeftFourPlayer
        '
        Me.txtPositionXTimerBottomLeftFourPlayer.Location = New System.Drawing.Point(128, 19)
        Me.txtPositionXTimerBottomLeftFourPlayer.Name = "txtPositionXTimerBottomLeftFourPlayer"
        Me.txtPositionXTimerBottomLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerBottomLeftFourPlayer.TabIndex = 7
        '
        'gbGameFourPlayerTop
        '
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label9)
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label14)
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label15)
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label16)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtPositionYGameTopRightFourPlayer)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtBoundingSizeHeightGameFourPlayer)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtPositionXGameTopRightFourPlayer)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtBoundingSizeWidthGameFourPlayer)
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label17)
        Me.gbGameFourPlayerTop.Controls.Add(Me.Label18)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtPositionXGameTopLeftFourPlayer)
        Me.gbGameFourPlayerTop.Controls.Add(Me.txtPositionYGameTopLeftFourPlayer)
        Me.gbGameFourPlayerTop.Location = New System.Drawing.Point(407, 19)
        Me.gbGameFourPlayerTop.Name = "gbGameFourPlayerTop"
        Me.gbGameFourPlayerTop.Size = New System.Drawing.Size(409, 100)
        Me.gbGameFourPlayerTop.TabIndex = 1
        Me.gbGameFourPlayerTop.TabStop = False
        Me.gbGameFourPlayerTop.Text = "Game Info - Top"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(195, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Position Y Right Runner"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(195, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Bounding Box Width"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Position X Right Runner"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Bounding Box Height"
        '
        'txtPositionYGameTopRightFourPlayer
        '
        Me.txtPositionYGameTopRightFourPlayer.Location = New System.Drawing.Point(318, 66)
        Me.txtPositionYGameTopRightFourPlayer.Name = "txtPositionYGameTopRightFourPlayer"
        Me.txtPositionYGameTopRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameTopRightFourPlayer.TabIndex = 21
        '
        'txtBoundingSizeHeightGameFourPlayer
        '
        Me.txtBoundingSizeHeightGameFourPlayer.Location = New System.Drawing.Point(128, 13)
        Me.txtBoundingSizeHeightGameFourPlayer.Name = "txtBoundingSizeHeightGameFourPlayer"
        Me.txtBoundingSizeHeightGameFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeHeightGameFourPlayer.TabIndex = 7
        '
        'txtPositionXGameTopRightFourPlayer
        '
        Me.txtPositionXGameTopRightFourPlayer.Location = New System.Drawing.Point(128, 66)
        Me.txtPositionXGameTopRightFourPlayer.Name = "txtPositionXGameTopRightFourPlayer"
        Me.txtPositionXGameTopRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameTopRightFourPlayer.TabIndex = 19
        '
        'txtBoundingSizeWidthGameFourPlayer
        '
        Me.txtBoundingSizeWidthGameFourPlayer.Location = New System.Drawing.Point(318, 13)
        Me.txtBoundingSizeWidthGameFourPlayer.Name = "txtBoundingSizeWidthGameFourPlayer"
        Me.txtBoundingSizeWidthGameFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeWidthGameFourPlayer.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(195, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Position Y Left Runner"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 43)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 13)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "Position X Left Runner"
        '
        'txtPositionXGameTopLeftFourPlayer
        '
        Me.txtPositionXGameTopLeftFourPlayer.Location = New System.Drawing.Point(128, 40)
        Me.txtPositionXGameTopLeftFourPlayer.Name = "txtPositionXGameTopLeftFourPlayer"
        Me.txtPositionXGameTopLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXGameTopLeftFourPlayer.TabIndex = 15
        '
        'txtPositionYGameTopLeftFourPlayer
        '
        Me.txtPositionYGameTopLeftFourPlayer.Location = New System.Drawing.Point(318, 40)
        Me.txtPositionYGameTopLeftFourPlayer.Name = "txtPositionYGameTopLeftFourPlayer"
        Me.txtPositionYGameTopLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYGameTopLeftFourPlayer.TabIndex = 17
        '
        'gbTimerFourPlayerTop
        '
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label19)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label20)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtPositionYTimerTopRightFourPlayer)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtPositionXTimerTopRightFourPlayer)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label21)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label22)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtPositionYTimerTopLeftFourPlayer)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtPositionXTimerTopLeftFourPlayer)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label23)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.Label24)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtBoundingSizeWidthTimerFourPlayer)
        Me.gbTimerFourPlayerTop.Controls.Add(Me.txtBoundingSizeHeightTimerFourPlayer)
        Me.gbTimerFourPlayerTop.Location = New System.Drawing.Point(6, 19)
        Me.gbTimerFourPlayerTop.Name = "gbTimerFourPlayerTop"
        Me.gbTimerFourPlayerTop.Size = New System.Drawing.Size(395, 100)
        Me.gbTimerFourPlayerTop.TabIndex = 0
        Me.gbTimerFourPlayerTop.TabStop = False
        Me.gbTimerFourPlayerTop.Text = "Timer Info - Top"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(195, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Position Y Right Runner"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 13)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "Position X Right Runner"
        '
        'txtPositionYTimerTopRightFourPlayer
        '
        Me.txtPositionYTimerTopRightFourPlayer.Location = New System.Drawing.Point(318, 66)
        Me.txtPositionYTimerTopRightFourPlayer.Name = "txtPositionYTimerTopRightFourPlayer"
        Me.txtPositionYTimerTopRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerTopRightFourPlayer.TabIndex = 13
        '
        'txtPositionXTimerTopRightFourPlayer
        '
        Me.txtPositionXTimerTopRightFourPlayer.Location = New System.Drawing.Point(128, 66)
        Me.txtPositionXTimerTopRightFourPlayer.Name = "txtPositionXTimerTopRightFourPlayer"
        Me.txtPositionXTimerTopRightFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerTopRightFourPlayer.TabIndex = 11
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(195, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Position Y Left Runner"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(113, 13)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Position X Left Runner"
        '
        'txtPositionYTimerTopLeftFourPlayer
        '
        Me.txtPositionYTimerTopLeftFourPlayer.Location = New System.Drawing.Point(318, 40)
        Me.txtPositionYTimerTopLeftFourPlayer.Name = "txtPositionYTimerTopLeftFourPlayer"
        Me.txtPositionYTimerTopLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionYTimerTopLeftFourPlayer.TabIndex = 9
        '
        'txtPositionXTimerTopLeftFourPlayer
        '
        Me.txtPositionXTimerTopLeftFourPlayer.Location = New System.Drawing.Point(128, 40)
        Me.txtPositionXTimerTopLeftFourPlayer.Name = "txtPositionXTimerTopLeftFourPlayer"
        Me.txtPositionXTimerTopLeftFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtPositionXTimerTopLeftFourPlayer.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(195, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 13)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Bounding Box Width"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(107, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Bounding Box Height"
        '
        'txtBoundingSizeWidthTimerFourPlayer
        '
        Me.txtBoundingSizeWidthTimerFourPlayer.Location = New System.Drawing.Point(318, 13)
        Me.txtBoundingSizeWidthTimerFourPlayer.Name = "txtBoundingSizeWidthTimerFourPlayer"
        Me.txtBoundingSizeWidthTimerFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeWidthTimerFourPlayer.TabIndex = 5
        '
        'txtBoundingSizeHeightTimerFourPlayer
        '
        Me.txtBoundingSizeHeightTimerFourPlayer.Location = New System.Drawing.Point(128, 13)
        Me.txtBoundingSizeHeightTimerFourPlayer.Name = "txtBoundingSizeHeightTimerFourPlayer"
        Me.txtBoundingSizeHeightTimerFourPlayer.Size = New System.Drawing.Size(61, 20)
        Me.txtBoundingSizeHeightTimerFourPlayer.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(297, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save Config"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ConfigEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 450)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbFourRunners)
        Me.Controls.Add(Me.cbConfigFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbTwoRunners)
        Me.Name = "ConfigEditor"
        Me.Text = "Config Editor"
        Me.gbTwoRunners.ResumeLayout(False)
        Me.gbGameTwoPlayer.ResumeLayout(False)
        Me.gbGameTwoPlayer.PerformLayout()
        Me.gbTimerTwoPlayer.ResumeLayout(False)
        Me.gbTimerTwoPlayer.PerformLayout()
        Me.gbFourRunners.ResumeLayout(False)
        Me.gbGameFourPlayerBottom.ResumeLayout(False)
        Me.gbGameFourPlayerBottom.PerformLayout()
        Me.gbTimerFourPlayerBottom.ResumeLayout(False)
        Me.gbTimerFourPlayerBottom.PerformLayout()
        Me.gbGameFourPlayerTop.ResumeLayout(False)
        Me.gbGameFourPlayerTop.PerformLayout()
        Me.gbTimerFourPlayerTop.ResumeLayout(False)
        Me.gbTimerFourPlayerTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbTwoRunners As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbConfigFiles As ComboBox
    Friend WithEvents gbGameTwoPlayer As GroupBox
    Friend WithEvents gbTimerTwoPlayer As GroupBox
    Friend WithEvents txtBoundingSizeHeightTimerTwoPlayer As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBoundingSizeWidthTimerTwoPlayer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBoundingSizeHeightGameTwoPlayer As TextBox
    Friend WithEvents txtBoundingSizeWidthGameTwoPlayer As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label111 As Label
    Friend WithEvents txtPositionYTimerRightTwoPlayer As TextBox
    Friend WithEvents txtPositionXTimerRightTwoPlayer As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPositionYTimerLeftTwoPlayer As TextBox
    Friend WithEvents txtPositionXTimerLeftTwoPlayer As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPositionYGameRightTwoPlayer As TextBox
    Friend WithEvents txtPositionXGameRightTwoPlayer As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPositionXGameLeftTwoPlayer As TextBox
    Friend WithEvents txtPositionYGameLeftTwoPlayer As TextBox
    Friend WithEvents gbFourRunners As GroupBox
    Friend WithEvents gbGameFourPlayerBottom As GroupBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtPositionYGameBottomRightFourPlayer As TextBox
    Friend WithEvents txtPositionXGameBottomRightFourPlayer As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtPositionXGameBottomLeftFourPlayer As TextBox
    Friend WithEvents txtPositionYGameBottomLeftFourPlayer As TextBox
    Friend WithEvents gbTimerFourPlayerBottom As GroupBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents txtPositionYTimerBottomRightFourPlayer As TextBox
    Friend WithEvents txtPositionXTimerBottomRightFourPlayer As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtPositionYTimerBottomLeftFourPlayer As TextBox
    Friend WithEvents txtPositionXTimerBottomLeftFourPlayer As TextBox
    Friend WithEvents gbGameFourPlayerTop As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPositionYGameTopRightFourPlayer As TextBox
    Friend WithEvents txtBoundingSizeHeightGameFourPlayer As TextBox
    Friend WithEvents txtPositionXGameTopRightFourPlayer As TextBox
    Friend WithEvents txtBoundingSizeWidthGameFourPlayer As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPositionXGameTopLeftFourPlayer As TextBox
    Friend WithEvents txtPositionYGameTopLeftFourPlayer As TextBox
    Friend WithEvents gbTimerFourPlayerTop As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtPositionYTimerTopRightFourPlayer As TextBox
    Friend WithEvents txtPositionXTimerTopRightFourPlayer As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtPositionYTimerTopLeftFourPlayer As TextBox
    Friend WithEvents txtPositionXTimerTopLeftFourPlayer As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtBoundingSizeWidthTimerFourPlayer As TextBox
    Friend WithEvents txtBoundingSizeHeightTimerFourPlayer As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents sfdSaveConfig As SaveFileDialog
End Class
