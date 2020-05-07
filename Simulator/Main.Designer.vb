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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CurrentStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ClockSpeedStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(680, 40)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(72, 40)
        Me.FileToolStripMenuItem.Text = "File"
        Me.FileToolStripMenuItem.ToolTipText = "Open a file." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quit the application."
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(294, 44)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(294, 44)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.CurrentStatus, Me.ToolStripStatusLabel2, Me.ClockSpeedStatus, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 289)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 28, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(680, 42)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(178, 32)
        Me.ToolStripStatusLabel1.Text = "Current Status: "
        '
        'CurrentStatus
        '
        Me.CurrentStatus.Name = "CurrentStatus"
        Me.CurrentStatus.Size = New System.Drawing.Size(54, 32)
        Me.CurrentStatus.Text = "Idle"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(149, 32)
        Me.ToolStripStatusLabel2.Text = "Clock speed:"
        '
        'ClockSpeedStatus
        '
        Me.ClockSpeedStatus.Name = "ClockSpeedStatus"
        Me.ClockSpeedStatus.Size = New System.Drawing.Size(56, 32)
        Me.ClockSpeedStatus.Text = "0Hz"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(241, 32)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'OffButton
        '
        Me.OffButton.Enabled = False
        Me.OffButton.Location = New System.Drawing.Point(186, 52)
        Me.OffButton.Margin = New System.Windows.Forms.Padding(6)
        Me.OffButton.Name = "OffButton"
        Me.OffButton.Size = New System.Drawing.Size(150, 44)
        Me.OffButton.TabIndex = 3
        Me.OffButton.Text = "Power Off"
        Me.ToolTip1.SetToolTip(Me.OffButton, "Stop execution from the 'Power On' state." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Does not reset the machine!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.OffButton.UseVisualStyleBackColor = True
        '
        'PauseButton
        '
        Me.PauseButton.Enabled = False
        Me.PauseButton.Location = New System.Drawing.Point(348, 52)
        Me.PauseButton.Margin = New System.Windows.Forms.Padding(6)
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.Size = New System.Drawing.Size(150, 44)
        Me.PauseButton.TabIndex = 4
        Me.PauseButton.Text = "Pause"
        Me.ToolTip1.SetToolTip(Me.PauseButton, "Pauses execution from the 'Power On' state." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Allows the program to be resumed or " &
        "stepped.")
        Me.PauseButton.UseVisualStyleBackColor = True
        '
        'OnButton
        '
        Me.OnButton.Enabled = False
        Me.OnButton.Location = New System.Drawing.Point(24, 52)
        Me.OnButton.Margin = New System.Windows.Forms.Padding(6)
        Me.OnButton.Name = "OnButton"
        Me.OnButton.Size = New System.Drawing.Size(150, 44)
        Me.OnButton.TabIndex = 5
        Me.OnButton.Text = "Power on"
        Me.ToolTip1.SetToolTip(Me.OnButton, "Starts execution of the selected file as fast as possible." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Power Off Stops this." &
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.OnButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Enabled = False
        Me.ResetButton.Location = New System.Drawing.Point(510, 52)
        Me.ResetButton.Margin = New System.Windows.Forms.Padding(6)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(150, 44)
        Me.ResetButton.TabIndex = 9
        Me.ResetButton.Text = "Reset"
        Me.ToolTip1.SetToolTip(Me.ResetButton, "Resets the state of the machine." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clears memory to initial state (original code)." &
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clears all peripheral devices.")
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 158)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Current selected file: "
        Me.ToolTip1.SetToolTip(Me.Label2, "This is the path of the current loaded code file.")
        '
        'SelectedFile
        '
        Me.SelectedFile.Location = New System.Drawing.Point(24, 188)
        Me.SelectedFile.Margin = New System.Windows.Forms.Padding(6)
        Me.SelectedFile.Name = "SelectedFile"
        Me.SelectedFile.ReadOnly = True
        Me.SelectedFile.Size = New System.Drawing.Size(628, 31)
        Me.SelectedFile.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.SelectedFile, "This is the path of the current loaded code file.")
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
        Me.ResumeButton.Location = New System.Drawing.Point(348, 108)
        Me.ResumeButton.Margin = New System.Windows.Forms.Padding(6)
        Me.ResumeButton.Name = "ResumeButton"
        Me.ResumeButton.Size = New System.Drawing.Size(150, 44)
        Me.ResumeButton.TabIndex = 12
        Me.ResumeButton.Text = "Resume"
        Me.ToolTip1.SetToolTip(Me.ResumeButton, "Resumes execution from a 'Paused' state.")
        Me.ResumeButton.UseVisualStyleBackColor = True
        '
        'StepButton
        '
        Me.StepButton.Enabled = False
        Me.StepButton.Location = New System.Drawing.Point(186, 108)
        Me.StepButton.Margin = New System.Windows.Forms.Padding(6)
        Me.StepButton.Name = "StepButton"
        Me.StepButton.Size = New System.Drawing.Size(150, 44)
        Me.StepButton.TabIndex = 13
        Me.StepButton.Text = "Step"
        Me.ToolTip1.SetToolTip(Me.StepButton, "Executes one instruction every click." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Automatically highlights the current progr" &
        "am address.")
        Me.StepButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Help"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(85, 44)
        Me.ToolStripMenuItem1.Text = "Help"
        Me.ToolStripMenuItem1.ToolTipText = "Get embedded help."
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "C:\Users\Matthew\Desktop\school\Y12\SDD\Major project\Simulator\Simulator\Help.ch" &
    "m"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 331)
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
        Me.HelpButton = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HelpProvider1 As HelpProvider
End Class
