Public Class TmrCnt
    Public Shared Value As UInt16 = 0
    Public Shared WithEvents Timer1 As Timer
    Public Shared Function DataOut() As UShort
        Return Value
    End Function

    Public Shared Sub Load()
        Timer1 = New Timer()
        Timer1.Interval = 100
        Timer1.Enabled = True
    End Sub

    Private Shared Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Value += 1
    End Sub
End Class
