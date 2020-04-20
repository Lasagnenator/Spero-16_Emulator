<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graphics
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
        Me.GraphicsDisplay = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GraphicsDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GraphicsDisplay
        '
        Me.GraphicsDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GraphicsDisplay.Location = New System.Drawing.Point(0, 0)
        Me.GraphicsDisplay.Margin = New System.Windows.Forms.Padding(0)
        Me.GraphicsDisplay.Name = "GraphicsDisplay"
        Me.GraphicsDisplay.Size = New System.Drawing.Size(240, 217)
        Me.GraphicsDisplay.TabIndex = 0
        Me.GraphicsDisplay.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 16
        '
        'Graphics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 217)
        Me.Controls.Add(Me.GraphicsDisplay)
        Me.Name = "Graphics"
        Me.Text = "Graphics"
        CType(Me.GraphicsDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GraphicsDisplay As PictureBox
    Friend WithEvents Timer1 As Timer
End Class
