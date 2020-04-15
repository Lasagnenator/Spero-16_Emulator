Public Class Peripheral0
    'Everything here is done with events as Executor is run from a separate thread when running
    'When in a separate thread, UI elements cannot be updated (can with difficulty).
    Public Shared Event FromProgram(data As UInt16)
    Public Shared Event ToProgram()
    Public Shared Value As UInt16 = 0

    Private Sub DataFromRegisterHandler(data As UInt16)

    End Sub

    Shared Sub DataFromRegister(data As UInt16)
        RaiseEvent FromProgram(data)
    End Sub

    Private Sub DataToRegisterHandler()

    End Sub

    Shared Function DataToRegister() As UInt16
        RaiseEvent ToProgram()
        Return Value
    End Function

    Private Sub Peripheral0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler FromProgram, AddressOf DataFromRegisterHandler
        AddHandler ToProgram, AddressOf DataToRegisterHandler
    End Sub
End Class
