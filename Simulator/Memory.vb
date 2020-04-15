Public Class Memory
    Public Value() As String = Enumerable.Repeat(Of String)("0000", 65536).ToArray()

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim index = ListBox2.SelectedIndex
        Dim Min = If(index - 32 < 0, 0, index - 32)
        Dim Max = If(index + 32 > 65535, 65535, index + 32)

        Value = Array.ConvertAll(Executor.Memory, Function(x) Hex(x).PadLeft(4, "0"))
        For i = Min To Max
            ListBox2.Items(i) = Value(i) 'Pad with zeros
        Next
    End Sub

    Private Sub Memory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialise the arrays
        'Doing it ths way instead of adding them one by one is a lot more efficient and faster.
        'This is because the built-in Enumerable and Array classes are very fast.
        Dim Addresses() As Integer = Enumerable.Range(0, 65536).ToArray()
        Dim AddressesS() As String = Array.ConvertAll(Addresses, Function(x) Hex(x).PadLeft(4, "0")) 'Addresses are only generated once

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox1.Items.AddRange(AddressesS)
        ListBox2.Items.AddRange(Value)

        Timer1.Enabled = True
    End Sub

    Private Sub GotoButton_Click(sender As Object, e As EventArgs) Handles GotoButton.Click
        ListBox1.SelectedIndex = CInt(AddressBox.Value)
    End Sub

    Private Sub AddressBox_KeyDown(sender As Object, e As KeyEventArgs) Handles AddressBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            GotoButton_Click(Nothing, Nothing)
        End If
    End Sub
End Class