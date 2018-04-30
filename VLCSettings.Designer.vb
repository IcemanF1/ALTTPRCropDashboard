<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VLCSettings
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
        Me.txtDefaultCropBottom = New System.Windows.Forms.TextBox()
        Me.lblBottom = New System.Windows.Forms.Label()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.txtDefaultCropTop = New System.Windows.Forms.TextBox()
        Me.chkOverrideDefault = New System.Windows.Forms.CheckBox()
        Me.chkStatusBar = New System.Windows.Forms.CheckBox()
        Me.chkPlayPauseControls = New System.Windows.Forms.CheckBox()
        Me.chkMenuBar = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDefaultCropBottom
        '
        Me.txtDefaultCropBottom.Location = New System.Drawing.Point(498, 298)
        Me.txtDefaultCropBottom.Name = "txtDefaultCropBottom"
        Me.txtDefaultCropBottom.Size = New System.Drawing.Size(100, 20)
        Me.txtDefaultCropBottom.TabIndex = 79
        '
        'lblBottom
        '
        Me.lblBottom.AutoSize = True
        Me.lblBottom.Location = New System.Drawing.Point(460, 301)
        Me.lblBottom.Name = "lblBottom"
        Me.lblBottom.Size = New System.Drawing.Size(40, 13)
        Me.lblBottom.TabIndex = 77
        Me.lblBottom.Text = "Bottom"
        '
        'lblTop
        '
        Me.lblTop.AutoSize = True
        Me.lblTop.Location = New System.Drawing.Point(322, 301)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(26, 13)
        Me.lblTop.TabIndex = 78
        Me.lblTop.Text = "Top"
        '
        'txtDefaultCropTop
        '
        Me.txtDefaultCropTop.Location = New System.Drawing.Point(354, 298)
        Me.txtDefaultCropTop.Name = "txtDefaultCropTop"
        Me.txtDefaultCropTop.Size = New System.Drawing.Size(100, 20)
        Me.txtDefaultCropTop.TabIndex = 80
        '
        'chkOverrideDefault
        '
        Me.chkOverrideDefault.AutoSize = True
        Me.chkOverrideDefault.Location = New System.Drawing.Point(3, 300)
        Me.chkOverrideDefault.Name = "chkOverrideDefault"
        Me.chkOverrideDefault.Size = New System.Drawing.Size(313, 17)
        Me.chkOverrideDefault.TabIndex = 76
        Me.chkOverrideDefault.Text = "I would like to Override the default numbers and use my own."
        Me.chkOverrideDefault.UseVisualStyleBackColor = True
        '
        'chkStatusBar
        '
        Me.chkStatusBar.AutoSize = True
        Me.chkStatusBar.BackColor = System.Drawing.Color.Transparent
        Me.chkStatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatusBar.Location = New System.Drawing.Point(549, 256)
        Me.chkStatusBar.Name = "chkStatusBar"
        Me.chkStatusBar.Size = New System.Drawing.Size(144, 21)
        Me.chkStatusBar.TabIndex = 75
        Me.chkStatusBar.Text = "I have a status bar"
        Me.chkStatusBar.UseVisualStyleBackColor = False
        '
        'chkPlayPauseControls
        '
        Me.chkPlayPauseControls.AutoSize = True
        Me.chkPlayPauseControls.BackColor = System.Drawing.Color.Transparent
        Me.chkPlayPauseControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlayPauseControls.Location = New System.Drawing.Point(698, 221)
        Me.chkPlayPauseControls.Name = "chkPlayPauseControls"
        Me.chkPlayPauseControls.Size = New System.Drawing.Size(119, 21)
        Me.chkPlayPauseControls.TabIndex = 74
        Me.chkPlayPauseControls.Text = "I have controls"
        Me.chkPlayPauseControls.UseVisualStyleBackColor = False
        '
        'chkMenuBar
        '
        Me.chkMenuBar.AutoSize = True
        Me.chkMenuBar.BackColor = System.Drawing.Color.Transparent
        Me.chkMenuBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMenuBar.Location = New System.Drawing.Point(609, 51)
        Me.chkMenuBar.Name = "chkMenuBar"
        Me.chkMenuBar.Size = New System.Drawing.Size(141, 21)
        Me.chkMenuBar.TabIndex = 73
        Me.chkMenuBar.Text = "I have a menu bar"
        Me.chkMenuBar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.ALTTPRCropDashboard.My.Resources.Resources.VLC_Settings
        Me.Panel1.Controls.Add(Me.chkStatusBar)
        Me.Panel1.Controls.Add(Me.chkPlayPauseControls)
        Me.Panel1.Controls.Add(Me.chkMenuBar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(846, 291)
        Me.Panel1.TabIndex = 81
        '
        'lblWarning
        '
        Me.lblWarning.AutoSize = True
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(21, 320)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(629, 13)
        Me.lblWarning.TabIndex = 82
        Me.lblWarning.Text = "WARNING:  Please verify your numbers first before setting them.  This could adver" &
    "sely affect the numbers you sync up to the server."
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Location = New System.Drawing.Point(698, 298)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(137, 23)
        Me.btnSaveSettings.TabIndex = 83
        Me.btnSaveSettings.Text = "Save VLC Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'VLCSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 350)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtDefaultCropBottom)
        Me.Controls.Add(Me.lblBottom)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.txtDefaultCropTop)
        Me.Controls.Add(Me.chkOverrideDefault)
        Me.Name = "VLCSettings"
        Me.Text = "VLCSettings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDefaultCropBottom As TextBox
    Friend WithEvents lblBottom As Label
    Friend WithEvents lblTop As Label
    Friend WithEvents txtDefaultCropTop As TextBox
    Friend WithEvents chkOverrideDefault As CheckBox
    Friend WithEvents chkStatusBar As CheckBox
    Friend WithEvents chkPlayPauseControls As CheckBox
    Friend WithEvents chkMenuBar As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblWarning As Label
    Friend WithEvents btnSaveSettings As Button
End Class
