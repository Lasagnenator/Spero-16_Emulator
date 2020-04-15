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
            ListBox2.Items(i) = Hex(Values(i)).PadLeft(4, "0") 'Pad with zeros
        Next
    End Sub

    Private Sub Memory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialise the arrays
        'Doing it ths way instead of adding them one by one is a lot more efficient and faster.
        'This is because the built-in Enumerable and Array classes are very fast.
        Dim Addresses() As Integer = Enumerable.Range(0, Definitions.MemorySpace).ToArray()
        Dim AddressesS() As String = Array.ConvertAll(Addresses, Function(x) Hex(x).PadLeft(4, "0"))

        Dim Value() As String = Enumerable.Repeat(Of String)("0000", Definitions.MemorySpace).ToArray()

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox1.Items.AddRange(AddressesS)
        ListBox2.Items.AddRange(Value)

        Timer1.Enabled = True
    End Sub
End Class