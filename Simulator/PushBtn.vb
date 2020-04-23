Public Class PushBtn
    Public Value As UInt16 = 0
    Public Btns As CheckBox() = {CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5, CheckBox6, CheckBox7, CheckBox8}

    Public Function GetBtn() As UInt16
        Return Value
    End Function

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox3.CheckedChanged, CheckBox2.CheckedChanged, CheckBox8.CheckedChanged, CheckBox7.CheckedChanged, CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged
        Dim flag As UInt16 = 1
        Dim temp As UInt16 = 0
        For Each item In Btns
            If item.Checked Then
                temp = temp Or flag
            End If
            flag <<= 1 'Left shift for next bit
        Next
        Value = temp
    End Sub
End Class