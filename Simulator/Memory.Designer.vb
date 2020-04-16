<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Memory
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
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AddressBox = New System.Windows.Forms.NumericUpDown()
        Me.GotoButton = New System.Windows.Forms.Button()
        CType(Me.AddressBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Items.AddRange(New Object() {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"})
        Me.ListBox2.Location = New System.Drawing.Point(118, 12)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.ScrollAlwaysVisible = True
        Me.ListBox2.Size = New System.Drawing.Size(118, 407)
        Me.ListBox2.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"})
        Me.ListBox1.Location = New System.Drawing.Point(0, 12)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(118, 407)
        Me.ListBox1.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, -1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Addresses"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, -1)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Values"
        '
        'AddressBox
        '
        Me.AddressBox.Hexadecimal = True
        Me.AddressBox.Location = New System.Drawing.Point(0, 419)
        Me.AddressBox.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.AddressBox.Name = "AddressBox"
        Me.AddressBox.Size = New System.Drawing.Size(118, 20)
        Me.AddressBox.TabIndex = 6
        '
        'GotoButton
        '
        Me.GotoButton.Location = New System.Drawing.Point(118, 419)
        Me.GotoButton.Name = "GotoButton"
        Me.GotoButton.Size = New System.Drawing.Size(118, 23)
        Me.GotoButton.TabIndex = 7
        Me.GotoButton.Text = "Goto address"
        Me.GotoButton.UseVisualStyleBackColor = True
        '
        'Memory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(236, 444)
        Me.Controls.Add(Me.GotoButton)
        Me.Controls.Add(Me.AddressBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Memory"
        Me.Text = "Memory"
        CType(Me.AddressBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents AddressBox As NumericUpDown
    Friend WithEvents GotoButton As Button
End Class
