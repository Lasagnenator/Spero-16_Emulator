Public Class Main
    Private FileOpened As Boolean = False
    Private Code As String = ""
    Private Prev As Stopwatch = New Stopwatch()
    Private ThreadMade As Boolean = False

    Private Sub OpenFile(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If Executor.State <> States.Idle Then
            MessageBox.Show("Machine is not idle!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        OpenFileDialog1.ShowDialog()
        Dim path As String = OpenFileDialog1.FileName
        SelectedFile.Text = path

        Code = FileIO.FileSystem.ReadAllText(path)
        Try
            Executor.Code = Parser.Parse(Code)
        Catch er As Exception
            MessageBox.Show("Code file was malformed: " + er.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        FileOpened = True
        OnButton.Enabled = True
        ResetButton.Enabled = True
        OffButton.Enabled = False
        ResumeButton.Enabled = False
        PauseButton.Enabled = False
        StepButton.Enabled = True
    End Sub

    Private Sub Quit(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub RegistersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistersToolStripMenuItem.Click
        Registers.Show()
    End Sub

    Private Sub MemoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemoryToolStripMenuItem.Click
        Memory.Show()
    End Sub

    Private Sub PeripheralBusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeripheralBusToolStripMenuItem.Click
        Graphics.Show()
        LED.Show()
    End Sub

    Private Sub OnButton_Click(sender As Object, e As EventArgs) Handles OnButton.Click
        If Not FileOpened Then
            MessageBox.Show("Binary file not opened yet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        OnButton.Enabled = False
        ResetButton.Enabled = False
        OffButton.Enabled = True
        ResumeButton.Enabled = False
        PauseButton.Enabled = True
        StepButton.Enabled = False

        Executor.PowerOn()
        'Executor.ExecutionLoop()
        If ThreadMade Then 'Don't keep making new threads
            Exit Sub
        End If

        Dim Work As Threading.Thread
        Work = New Threading.Thread(AddressOf Executor.ExecutionLoop)
        Work.Name = "Executor"
        Work.Start()
        ThreadMade = True
    End Sub

    Private Sub OffButton_Click(sender As Object, e As EventArgs) Handles OffButton.Click
        Executor.PowerOff()
        OnButton.Enabled = True
        ResetButton.Enabled = True
        OffButton.Enabled = False
        ResumeButton.Enabled = False
        PauseButton.Enabled = False
        StepButton.Enabled = True
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        Executor.Pause()
        OnButton.Enabled = False
        ResetButton.Enabled = True
        OffButton.Enabled = True
        ResumeButton.Enabled = True
        PauseButton.Enabled = False
        StepButton.Enabled = True
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        Executor.Reset()
        OnButton.Enabled = True
        ResetButton.Enabled = True
        OffButton.Enabled = False
        ResumeButton.Enabled = False
        PauseButton.Enabled = False
        StepButton.Enabled = True
    End Sub

    Private Sub ResumeButton_Click(sender As Object, e As EventArgs) Handles ResumeButton.Click
        Executor.ResumeEx()
        OnButton.Enabled = False
        ResetButton.Enabled = True
        OffButton.Enabled = True
        ResumeButton.Enabled = False
        PauseButton.Enabled = True
        StepButton.Enabled = False
    End Sub

    Private Sub StepButton_Click(sender As Object, e As EventArgs) Handles StepButton.Click
        Executor.StepOnce()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'Triggers every 0.5s +-14ms
        Dim ExecutorStatus As String = "Unknown"
        If Executor.State = States.Idle Then
            ExecutorStatus = "Idle"
        ElseIf Executor.State = States.Executing Then
            ExecutorStatus = "Executing"
        ElseIf Executor.State = States.Paused Then
            ExecutorStatus = "Paused"
        ElseIf Executor.State = States.Stepping Then
            ExecutorStatus = "Stepping"
        End If
        CurrentStatus.Text = ExecutorStatus


        Dim ms As Long = Prev.ElapsedMilliseconds
        Prev.Restart()
        'Using this as a more accurate representation of time elapsed
        'As Timer has a +-14ms range, it is not accurate enough for these high clock speeds

        Dim ClockSpeed As Integer = Executor.Cycles / (ms / 1000)
        Executor.Cycles = 0

        ClockSpeedStatus.Text = ClockSpeed.ToString() + "Hz"
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Executor.State = States.Idle
        Executor.Code = {0}
        Executor.Reset()
        Memory.Value = {0}
        Memory.ListBox1.Items.Clear()
        Memory.ListBox2.Items.Clear()
        Memory.Timer1.Enabled = False
        Return
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Prev.Start()

    End Sub
End Class
