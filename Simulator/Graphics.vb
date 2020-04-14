Public Class Graphics
    '64 x 64 screen
    Public screen(64, 64) As Boolean
    Public bit As Bitmap
    Public CurrentImage As Image

    Public Sub Init()
        GraphicsDisplay.DrawToBitmap(bit, New Rectangle(0, 0, 64, 64))
    End Sub

    Public Sub ReadDataBus(Data As UInt16)

    End Sub

    Public Sub UpdateScreen()
        For index = 1 To screen.GetLength(0)

        Next
        GraphicsDisplay.Image = bit
        GraphicsDisplay.DrawToBitmap(bit, New Rectangle(0, 0, 64, 64))
    End Sub
End Class