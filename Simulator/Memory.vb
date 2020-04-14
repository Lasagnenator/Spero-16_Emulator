Public Class Memory
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Values = Executor.Memory
        'ListBox2.Items.Clear()
        For i = 0 To 65535
            ListBox2.Items(i) = Hex(Values(i)) 'Pad with zeros
        Next
    End Sub

    Private Sub Memory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialise the arrays
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        For i = 0 To 65535
            ListBox1.Items.Add(Hex(i))
            ListBox2.Items.Add("0")
        Next
        Timer1.Enabled = True
    End Sub
End Class