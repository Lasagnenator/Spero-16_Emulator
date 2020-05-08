Imports System.Collections.Concurrent

Public Class Graphics
    'I set the refresh rate to 60Hz but this could easily be increased
    '128x128 screen
    Public Shared bit As Bitmap = New Bitmap(128, 128)

    Public Shared XPos As Byte = 0
    Public Shared YPos As Byte = 0
    Public Shared Colour As Color = Color.Empty

    Public Shared Buffer As ConcurrentQueue(Of BufferItem) = New ConcurrentQueue(Of BufferItem)()
    'Using queue system as executor is usually in a separate thread
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
        Colour = Color.FromArgb(R / 31 * 255, G / 63 * 255, B / 31 * 255)

        Dim item As BufferItem = New BufferItem(XPos, YPos, Colour)
        Buffer.Enqueue(item)
    End Sub

    Public Sub UpdateScreen() Handles Timer1.Tick
        While Buffer.Count > 0
            Dim Item As BufferItem
            Dim flag As Boolean = Buffer.TryDequeue(Item)
            If flag Then
                'Read was successful (Not sure if it is possible for an invalid read)
                bit.SetPixel(Item.X, Item.Y, Item.C)
            End If
        End While
        GraphicsDisplay.Image = bit
        GraphicsDisplay.Refresh()
    End Sub

    Private Sub Graphics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Dim a As Drawing.Graphics = GraphicsDisplay.CreateGraphics()
        a.InterpolationMode = Drawing2D.InterpolationMode.Low
        a.Dispose()
    End Sub

    Public Sub Reset()
        bit = New Bitmap(128, 128)
    End Sub

    Public Structure BufferItem
        Public ReadOnly X As Byte
        Public ReadOnly Y As Byte
        Public ReadOnly C As Color
        Public Sub New(XPos As Byte, YPos As Byte, Colour As Color)
            X = XPos
            Y = YPos
            C = Colour
        End Sub
    End Structure
End Class

