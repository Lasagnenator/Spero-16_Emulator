<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeripheralBusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CurrentStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OffButton = New System.Windows.Forms.Button()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.OnButton = New System.Windows.Forms.Button()
        Me.ResetButtom = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistersToolStripMenuItem, Me.MemoryToolStripMenuItem, Me.PeripheralBusToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'RegistersToolStripMenuItem
        '
        Me.RegistersToolStripMenuItem.Name = "RegistersToolStripMenuItem"
        Me.RegistersToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RegistersToolStripMenuItem.Text = "Registers"
        '
        'MemoryToolStripMenuItem
        '
        Me.MemoryToolStripMenuItem.Name = "MemoryToolStripMenuItem"
        Me.MemoryToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MemoryToolStripMenuItem.Text = "Memory"
        '
        'PeripheralBusToolStripMenuItem
        '
        Me.PeripheralBusToolStripMenuItem.Name = "PeripheralBusToolStripMenuItem"
        Me.PeripheralBusToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.PeripheralBusToolStripMenuItem.Text = "Peripheral Bus"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.CurrentStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel1.Text = "Current Status: "
        '
        'CurrentStatus
        '
        Me.CurrentStatus.Name = "CurrentStatus"
        Me.CurrentStatus.Size = New System.Drawing.Size(26, 17)
        Me.CurrentStatus.Text = "Idle"
        '
        'OffButton
        '
        Me.OffButton.Location = New System.Drawing.Point(93, 27)
        Me.OffButton.Name = "OffButton"
        Me.OffButton.Size = New System.Drawing.Size(75, 23)
        Me.OffButton.TabIndex = 3
        Me.OffButton.Text = "Power Off"
        Me.OffButton.UseVisualStyleBackColor = True
        '
        'PauseButton
        '
        Me.PauseButton.Location = New System.Drawing.Point(174, 27)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(75, 23)
        Me.PauseButton.TabIndex = 4
        Me.PauseButton.Text = "Pause"
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'OnButton
        '
        Me.OnButton.Location = New System.Drawing.Point(12, 27)
        Me.OnButton.Name = "OnButton"
        Me.OnButton.Size = New System.Drawing.Size(75, 23)
        Me.OnButton.TabIndex = 5
        Me.OnButton.Text = "Power on"
        Me.OnButton.UseVisualStyleBackColor = True
        '
        'ResetButtom
        '
        Me.ResetButtom.Location = New System.Drawing.Point(255, 27)
        Me.ResetButtom.Name = "ResetButtom"
        Me.ResetButtom.Size = New System.Drawing.Size(75, 23)
        Me.ResetButtom.TabIndex = 9
        Me.ResetButtom.Text = "Reset"
        Me.ResetButtom.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Current selected file: "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(124, 118)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 11
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ResetButtom)
        Me.Controls.Add(Me.OnButton)
        Me.Controls.Add(Me.PauseButton)
        Me.Controls.Add(Me.OffButton)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Main"
        Me.Text = "RISC 16 Simulator"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MemoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeripheralBusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CurrentStatus As ToolStripStatusLabel
    Friend WithEvents OffButton As Button
    Friend WithEvents PauseButton As Button
    Friend WithEvents OnButton As Button
    Friend WithEvents ResetButtom As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
