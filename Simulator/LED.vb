Public Class LED
    Public LEDs As RadioButton() = {RadioButton1, RadioButton2, RadioButton3, RadioButton4, RadioButton5, RadioButton6, RadioButton7, RadioButton8}
    Public Shared Value As UInt16 = 0

    Public Sub DataIn(data As UInt16)
        Dim flag As UInt16 = 1
        For Each item In LEDs
            If data And flag = 1 Then
                item.Checked = True
            Else
                item.Checked = False
            End If
            data >>= 1
        Next
    End Sub

    Shared Function DataOut() As UInt16
        Return Value
    End Function

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged, RadioButton7.CheckedChanged, RadioButton6.CheckedChanged, RadioButton5.CheckedChanged, RadioButton4.CheckedChanged, RadioButton3.CheckedChanged, RadioButton2.CheckedChanged, RadioButton1.CheckedChanged
        Dim flag As UInt16 = 1
        Value = 0
        For Each item In LEDs
            If item.Checked Then
                Value = Value Or flag
            End If
            flag <<= 1 'Left shift for next bit
        Next
    End Sub
End Class