Public Class LED
    Public LEDs As CheckBox()
    Public Shared Value As UInt16 = 0

    Public Sub DataIn(data As UInt16)
        'Do not need to use a queue here as no past writes are needed to be known
        Value = data
    End Sub

    Shared Function DataOut() As UInt16
        Return Value
    End Function

    Private Sub UpdateScreen(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim temp As UInt16 = Value
        Dim flag As UInt16 = 1
        For Each item In LEDs
            If (temp And flag) = 1 Then
                'Using indeterminate looks nicer
                item.CheckState = CheckState.Indeterminate
            Else
                item.Checked = False
            End If
            temp >>= 1
        Next
    End Sub

    Private Sub LED_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True
        LEDs = {CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5, CheckBox6, CheckBox7, CheckBox8}
    End Sub
End Class