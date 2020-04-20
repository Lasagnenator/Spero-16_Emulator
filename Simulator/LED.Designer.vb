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
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Location = New System.Drawing.Point(173, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Location = New System.Drawing.Point(150, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton3.Enabled = False
        Me.RadioButton3.Location = New System.Drawing.Point(127, 12)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton4.Enabled = False
        Me.RadioButton4.Location = New System.Drawing.Point(104, 12)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "4"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton5.Enabled = False
        Me.RadioButton5.Location = New System.Drawing.Point(81, 12)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "5"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton6.Enabled = False
        Me.RadioButton6.Location = New System.Drawing.Point(58, 12)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton6.TabIndex = 5
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "6"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton7.Enabled = False
        Me.RadioButton7.Location = New System.Drawing.Point(35, 12)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton7.TabIndex = 6
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "7"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RadioButton8.Enabled = False
        Me.RadioButton8.Location = New System.Drawing.Point(12, 12)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(17, 30)
        Me.RadioButton8.TabIndex = 7
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "8"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'LED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(201, 56)
        Me.Controls.Add(Me.RadioButton8)
        Me.Controls.Add(Me.RadioButton7)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Name = "LED"
        Me.Text = "LED Panel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents RadioButton8 As RadioButton
End Class
