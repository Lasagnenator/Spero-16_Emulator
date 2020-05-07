<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LED
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(346, 21)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "0"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(300, 21)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox2.TabIndex = 9
        Me.CheckBox2.Text = "1"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(254, 21)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox3.TabIndex = 10
        Me.CheckBox3.Text = "2"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(208, 21)
        Me.CheckBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox4.TabIndex = 11
        Me.CheckBox4.Text = "3"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox5.Enabled = False
        Me.CheckBox5.Location = New System.Drawing.Point(162, 21)
        Me.CheckBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox5.TabIndex = 12
        Me.CheckBox5.Text = "4"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox6.Enabled = False
        Me.CheckBox6.Location = New System.Drawing.Point(116, 21)
        Me.CheckBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox6.TabIndex = 13
        Me.CheckBox6.Text = "5"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox7.Enabled = False
        Me.CheckBox7.Location = New System.Drawing.Point(70, 21)
        Me.CheckBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox7.TabIndex = 14
        Me.CheckBox7.Text = "6"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CheckBox8.Enabled = False
        Me.CheckBox8.Location = New System.Drawing.Point(22, 21)
        Me.CheckBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(28, 56)
        Me.CheckBox8.TabIndex = 15
        Me.CheckBox8.Text = "7"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'LED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBox8)
        Me.Controls.Add(Me.CheckBox7)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "LED"
        Me.Text = "LED Panel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
End Class
