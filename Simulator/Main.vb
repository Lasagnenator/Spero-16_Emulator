﻿Public Class Main
    Private Sub OpenFile(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub Quit(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub RegistersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistersToolStripMenuItem.Click

    End Sub

    Private Sub MemoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemoryToolStripMenuItem.Click

    End Sub

    Private Sub PeripheralBusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeripheralBusToolStripMenuItem.Click

    End Sub

    Private Sub OnButton_Click(sender As Object, e As EventArgs) Handles OnButton.Click
        Executor.PowerOn()
    End Sub

    Private Sub OffButton_Click(sender As Object, e As EventArgs) Handles OffButton.Click
        Executor.PowerOff()
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        Executor.Pause()
    End Sub

    Private Sub ResetButtom_Click(sender As Object, e As EventArgs) Handles ResetButtom.Click
        Executor.Reset()
    End Sub
End Class