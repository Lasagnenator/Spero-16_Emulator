'This executes code in a shared state.
Public Class Executor
    Public Shared Registers(16) As UInt16
    Public Shared Memory(65536) As UInt16
    Public Shared PeripheralBus(65536) As UInt16
    Public Shared Code() As UInt16 'Array of addresses
    Public Shared State As States = States.Idle

    Shared Sub Reset()
        'Set to zeros
        ReDim Registers(16)
        ReDim Memory(65536)
        ReDim PeripheralBus(65536)
    End Sub

    Shared Sub PowerOn()
        Array.Copy(Code, Memory, Code.Length)
    End Sub

    Shared Sub PowerOff()

    End Sub

    Shared Sub Pause()

    End Sub

    Shared Sub ExecutionLoop() 'ONLY RUN FROM THREAD!
        Dim Word As UInt16
        Dim OpCode As Byte
        Dim Field1 As Byte
        Dim Field2 As Byte
        Dim Field3 As Byte
        Dim Data As UInt16
        While State = States.Executing
            Word = GetWord()
            OpCode = (Word And CType(&HF000, UInt16)) >> 12
            Field1 = (Word And CType(&HF00, UInt16)) >> 8
            Field2 = (Word And CType(&HF0, UInt16)) >> 4
            Field3 = (Word And CType(&HF, UInt16))

            If (OpCode = &H0) Or (OpCode = &H1) Or (OpCode = &H3) Or (OpCode = &HA) Then
                Registers(16) += 1

            End If

            Select Case OpCode
                Case 0 'Load immediate

                Case 1

                Case Else

            End Select
        End While
    End Sub

    Shared Function GetWord() As UInt16
        Return Memory(Registers(16))
    End Function
End Class

Public Enum States
    Idle
    Executing
    Paused

End Enum

Public Enum OpCodes
    LOAD

End Enum
