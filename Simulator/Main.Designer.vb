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
        Me.components = New System.ComponentModel.Container()
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
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ClockSpeedStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OffButton = New System.Windows.Forms.Button()
        Me.PauseButton = New System.Windows.Forms.Button()
        Me.OnButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SelectedFile = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ResumeButton = New System.Windows.Forms.Button()
        Me.StepButton = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(340, 24)
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
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.CurrentStatus, Me.ToolStripStatusLabel2, Me.ClockSpeedStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 150)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(340, 22)
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "Clock speed:"
        '
        'ClockSpeedStatus
        '
        Me.ClockSpeedStatus.Name = "ClockSpeedStatus"
        Me.ClockSpeedStatus.Size = New System.Drawing.Size(27, 17)
        Me.ClockSpeedStatus.Text = "0Hz"
        '
        'OffButton
        '
        Me.OffButton.Enabled = False
        Me.OffButton.Location = New System.Drawing.Point(93, 27)
        Me.OffButton.Name = "OffButton"
        Me.OffButton.Size = New System.Drawing.Size(75, 23)
        Me.OffButton.TabIndex = 3
        Me.OffButton.Text = "Power Off"
        Me.OffButton.UseVisualStyleBackColor = True
        '
        'PauseButton
        '
        Me.PauseButton.Enabled = False
        Me.PauseButton.Location = New System.Drawing.Point(174, 27)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(75, 23)
        Me.PauseButton.TabIndex = 4
        Me.PauseButton.Text = "Pause"
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'OnButton
        '
        Me.OnButton.Enabled = False
        Me.OnButton.Location = New System.Drawing.Point(12, 27)
        Me.OnButton.Name = "OnButton"
        Me.OnButton.Size = New System.Drawing.Size(75, 23)
        Me.OnButton.TabIndex = 5
        Me.OnButton.Text = "Power on"
        Me.OnButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Enabled = False
        Me.ResetButton.Location = New System.Drawing.Point(255, 27)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 23)
        Me.ResetButton.TabIndex = 9
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Current selected file: "
        '
        'SelectedFile
        '
        Me.SelectedFile.Location = New System.Drawing.Point(12, 98)
        Me.SelectedFile.Name = "SelectedFile"
        Me.SelectedFile.ReadOnly = True
        Me.SelectedFile.Size = New System.Drawing.Size(316, 20)
        Me.SelectedFile.TabIndex = 11
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "RISC Binary Files|*.r16.bin"
        Me.OpenFileDialog1.InitialDirectory = "."
        Me.OpenFileDialog1.SupportMultiDottedExtensions = True
        Me.OpenFileDialog1.Title = "Open Code File"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ResumeButton
        '
        Me.ResumeButton.Enabled = False
        Me.ResumeButton.Location = New System.Drawing.Point(174, 56)
        Me.ResumeButton.Name = "ResumeButton"
        Me.ResumeButton.Size = New System.Drawing.Size(75, 23)
        Me.ResumeButton.TabIndex = 12
        Me.ResumeButton.Text = "Resume"
        Me.ResumeButton.UseVisualStyleBackColor = True
        '
        'StepButton
        '
        Me.StepButton.Enabled = False
        Me.StepButton.Location = New System.Drawing.Point(93, 56)
        Me.StepButton.Name = "StepButton"
        Me.StepButton.Size = New System.Drawing.Size(75, 23)
        Me.StepButton.TabIndex = 13
        Me.StepButton.Text = "Step"
        Me.StepButton.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 172)
        Me.Controls.Add(Me.StepButton)
        Me.Controls.Add(Me.ResumeButton)
        Me.Controls.Add(Me.SelectedFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ResetButton)
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
    Friend WithEvents ResetButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents SelectedFile As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ClockSpeedStatus As ToolStripStatusLabel
    Friend WithEvents ResumeButton As Button
    Friend WithEvents StepButton As Button
End Class
