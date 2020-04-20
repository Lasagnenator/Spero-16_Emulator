Public Class Graphics
    '64 x 64 screen
    Public Shared bit As Bitmap = New Bitmap(128, 128)
    Public Shared Value As UInt16 = 0

    Public Shared XPos As Byte = 0
    Public Shared YPos As Byte = 0
    Public Shared Colour As Color = Color.Empty
    'Using event system as executor is usually in a separate thread
    'UI elements cannot be updated from outside the main thread.

    Shared Sub XPosIn(data As UInt16)
        XPos = data Mod 128
    End Sub

    Shared Sub YPosIn(data As UInt16)
        YPos = data Mod 128
    End Sub

    Shared Sub CIn(data As UInt16)
        Dim R As Byte
        Dim G As Byte
        Dim B As Byte

        R = (data And CType(&B11111, UInt16)) 'Masks to get only the red part
        G = (data And CType(&B11111100000, UInt16)) >> 5   'Masks to get only the green part
        B = (data And CType(&B1111100000000000, UInt16)) >> 11    'Masks to get only the blue part
        Colour = Color.FromArgb(R, G, B)
        bit.SetPixel(XPos, YPos, Colour)
    End Sub

    Public Sub UpdateScreen() Handles Timer1.Tick
        GraphicsDisplay.Image = bit
        GraphicsDisplay.Refresh()
    End Sub

    Private Sub Graphics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
End Class