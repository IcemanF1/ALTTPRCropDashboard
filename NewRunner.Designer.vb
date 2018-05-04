<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewRunner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewRunner))
        Me.lblCommentary = New System.Windows.Forms.Label()
        Me.txtTwitchName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRunnerName = New System.Windows.Forms.TextBox()
        Me.chkAdjustInOBS = New System.Windows.Forms.CheckBox()
        Me.chkReuseInfo = New System.Windows.Forms.CheckBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCommentary
        '
        Me.lblCommentary.AutoSize = True
        Me.lblCommentary.BackColor = System.Drawing.Color.Transparent
        Me.lblCommentary.Location = New System.Drawing.Point(12, 13)
        Me.lblCommentary.Name = "lblCommentary"
        Me.lblCommentary.Size = New System.Drawing.Size(70, 13)
        Me.lblCommentary.TabIndex = 56
        Me.lblCommentary.Text = "Twitch Name"
        '
        'txtTwitchName
        '
        Me.txtTwitchName.Location = New System.Drawing.Point(88, 10)
        Me.txtTwitchName.Name = "txtTwitchName"
        Me.txtTwitchName.Size = New System.Drawing.Size(280, 20)
        Me.txtTwitchName.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Runner Name"
        '
        'txtRunnerName
        '
        Me.txtRunnerName.Location = New System.Drawing.Point(88, 45)
        Me.txtRunnerName.Name = "txtRunnerName"
        Me.txtRunnerName.Size = New System.Drawing.Size(280, 20)
        Me.txtRunnerName.TabIndex = 57
        '
        'chkAdjustInOBS
        '
        Me.chkAdjustInOBS.AutoSize = True
        Me.chkAdjustInOBS.Location = New System.Drawing.Point(15, 98)
        Me.chkAdjustInOBS.Name = "chkAdjustInOBS"
        Me.chkAdjustInOBS.Size = New System.Drawing.Size(115, 17)
        Me.chkAdjustInOBS.TabIndex = 59
        Me.chkAdjustInOBS.Text = "&Adjust crop in OBS"
        Me.chkAdjustInOBS.UseVisualStyleBackColor = True
        '
        'chkReuseInfo
        '
        Me.chkReuseInfo.AutoSize = True
        Me.chkReuseInfo.Location = New System.Drawing.Point(15, 132)
        Me.chkReuseInfo.Name = "chkReuseInfo"
        Me.chkReuseInfo.Size = New System.Drawing.Size(293, 17)
        Me.chkReuseInfo.TabIndex = 60
        Me.chkReuseInfo.Text = "&Reuse information if the runner is already in the database"
        Me.chkReuseInfo.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(293, 183)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 61
        Me.btnGo.Text = "&Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'NewRunner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 218)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.chkReuseInfo)
        Me.Controls.Add(Me.chkAdjustInOBS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRunnerName)
        Me.Controls.Add(Me.lblCommentary)
        Me.Controls.Add(Me.txtTwitchName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewRunner"
        Me.Text = "New Runner"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCommentary As Label
    Friend WithEvents txtTwitchName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtRunnerName As TextBox
    Friend WithEvents chkAdjustInOBS As CheckBox
    Friend WithEvents chkReuseInfo As CheckBox
    Friend WithEvents btnGo As Button
End Class
