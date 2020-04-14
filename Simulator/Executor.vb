'This executes code in a shared state.
Public Class Executor
    Public Shared Registers(15) As UInt16
    Public Shared Memory(65535) As UInt16
    Public Shared PeripheralBus(65535) As UInt16
    Public Shared Code() As UInt16 'Array of integers that are the instructions
    Public Shared State As States = States.Idle
    Public Shared Cycles As Integer = 0

    Shared Sub Reset()
        'Set to zeros
        ReDim Registers(15)
        ReDim Memory(65535)
        ReDim PeripheralBus(65535)
        State = States.Idle
    End Sub

    Shared Sub PowerOn()
        Reset()
        Array.Copy(Code, Memory, Code.Length)
        State = States.Executing
    End Sub

    Shared Sub PowerOff()
        State = States.Idle
    End Sub

    Shared Sub Pause()
        State = States.Paused
    End Sub

    Shared Sub ResumeEx()
        State = States.Executing
    End Sub

    Shared Sub ExecutionLoop()
        'ONLY RUN FROM THREAD!
        Dim Word As UInt16
        Dim OpCode As Byte
        Dim Field1 As Byte
        Dim Field2 As Byte
        Dim Field3 As Byte
        Dim Data As UInt16
        While True
            While State <> States.Executing 'Save on cpu resources when paused etc
                Threading.Thread.Sleep(100)
            End While

            Word = GetWord()
            OpCode = (Word And CType(&HF000, UInt16)) >> 12
            Field1 = (Word And CType(&HF00, UInt16)) >> 8
            Field2 = (Word And CType(&HF0, UInt16)) >> 4
            Field3 = (Word And CType(&HF, UInt16))

            If (OpCode = &H0) Or (OpCode = &H1) Or (OpCode = &H3) Or (OpCode = &HA) Then 'Load data (next word) if needed
                IncrementPC()
                Data = GetWord()
            End If

            Select Case OpCode
                    Case OpCodes.LOADIMM
                        Registers(Field1) = Data
                        IncrementPC()
                    Case OpCodes.LOAD
                        Registers(Field1) = Memory(Data)
                        IncrementPC()
                    Case OpCodes.LOADIDX
                        Registers(Field1) = Memory(Registers(Field2))
                        IncrementPC()
                    Case OpCodes.STORE
                        Memory(Data) = Registers(Field1)
                        IncrementPC()
                    Case OpCodes.STOREIDX
                        Memory(Registers(Field2)) = Registers(Field1)
                        IncrementPC()
                    Case OpCodes.ADD
                        Dim temp = Registers(Field1)
                        Registers(Field1) = Registers(Field1) + Registers(Field2) + (Registers(Field3) And CType(1, UInt16))
                        Registers(Field3) = If(Registers(Field1) > temp, 0, 1)
                        IncrementPC()
                    Case OpCodes.SUBTRACT
                        Dim temp = Registers(Field1)
                        Registers(Field1) = Registers(Field1) - Registers(Field2) - (Registers(Field3) And CType(1, UInt16))
                        Registers(Field3) = If(Registers(Field1) > temp, 1, 0)
                        IncrementPC()
                    Case OpCodes.BITAND
                        Registers(Field1) = Registers(Field2) And Registers(Field3)
                        IncrementPC()
                    Case OpCodes.BITOR
                        Registers(Field1) = Registers(Field2) Or Registers(Field3)
                        IncrementPC()
                    Case OpCodes.SHIFTR
                        Dim Temp As Int16 = Registers(Field1) 'This is a signed shift so conversion is needed
                        Registers(Field3) = Registers(Field1) And CType(1, UInt16)
                        Registers(Field1) = Temp \ CType(2, Int16)
                        IncrementPC()
                    Case OpCodes.JUMP
                        Select Case Field3
                            Case JumpCC.AL
                                Registers(15) = Data
                            Case JumpCC.LT
                                Dim Rn As Int16 = Registers(Field1)
                                Dim Rm As Int16 = Registers(Field2)
                                If Rn < Rm Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case JumpCC.GT
                                Dim Rn As Int16 = Registers(Field1)
                                Dim Rm As Int16 = Registers(Field2)
                                If Rn > Rm Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case JumpCC.EQ
                                If Registers(Field1) = Registers(Field2) Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case JumpCC.NV
                                IncrementPC()
                            Case JumpCC.BL
                                If Registers(Field1) < Registers(Field2) Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case JumpCC.AB
                                If Registers(Field1) > Registers(Field2) Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case JumpCC.NE
                                If Registers(Field1) <> Registers(Field2) Then
                                    Registers(15) = Data
                                Else
                                    IncrementPC()
                                End If
                            Case Else 'Illegal case. Just skip over.
                                IncrementPC()
                        End Select
                    Case OpCodes.JUMPIDX
                        Registers(15) = Registers(Field1)
                    Case OpCodes.READIO
                        IncrementPC()
                    Case OpCodes.WRITEIO
                        IncrementPC()
                    Case Else 'Unknown instruction. Skip over.
                        IncrementPC()
                End Select

            Registers(0) = 0 'Register zero is always zero.
            Cycles += 1

        End While
    End Sub

    Shared Sub StepOnce()
        State = States.Stepping
        Dim Word As UInt16
        Dim OpCode As Byte
        Dim Field1 As Byte
        Dim Field2 As Byte
        Dim Field3 As Byte
        Dim Data As UInt16
        Word = GetWord()
        OpCode = (Word And CType(&HF000, UInt16)) >> 12
        Field1 = (Word And CType(&HF00, UInt16)) >> 8
        Field2 = (Word And CType(&HF0, UInt16)) >> 4
        Field3 = (Word And CType(&HF, UInt16))

        If (OpCode = &H0) Or (OpCode = &H1) Or (OpCode = &H3) Or (OpCode = &HA) Then 'Load data (next word) if needed
            IncrementPC()
            Data = GetWord()
        End If

        Select Case OpCode
            Case OpCodes.LOADIMM
                Registers(Field1) = Data
                IncrementPC()
            Case OpCodes.LOAD
                Registers(Field1) = Memory(Data)
                IncrementPC()
            Case OpCodes.LOADIDX
                Registers(Field1) = Memory(Registers(Field2))
                IncrementPC()
            Case OpCodes.STORE
                Memory(Data) = Registers(Field1)
                IncrementPC()
            Case OpCodes.STOREIDX
                Memory(Registers(Field2)) = Registers(Field1)
                IncrementPC()
            Case OpCodes.ADD
                Dim temp = Registers(Field1)
                Registers(Field1) = Registers(Field1) + Registers(Field2) + (Registers(Field3) And CType(1, UInt16))
                Registers(Field3) = If(Registers(Field1) > temp, 0, 1)
                IncrementPC()
            Case OpCodes.SUBTRACT
                Dim temp = Registers(Field1)
                Registers(Field1) = Registers(Field1) - Registers(Field2) - (Registers(Field3) And CType(1, UInt16))
                Registers(Field3) = If(Registers(Field1) > temp, 1, 0)
                IncrementPC()
            Case OpCodes.BITAND
                Registers(Field1) = Registers(Field2) And Registers(Field3)
                IncrementPC()
            Case OpCodes.BITOR
                Registers(Field1) = Registers(Field2) Or Registers(Field3)
                IncrementPC()
            Case OpCodes.SHIFTR
                Dim Temp As Int16 = Registers(Field1) 'This is a signed shift so conversion is needed
                Registers(Field3) = Registers(Field1) And CType(1, UInt16)
                Registers(Field1) = Temp \ CType(2, Int16)
                IncrementPC()
            Case OpCodes.JUMP
                Select Case Field3
                    Case JumpCC.AL
                        Registers(15) = Data
                    Case JumpCC.LT
                        Dim Rn As Int16 = Registers(Field1)
                        Dim Rm As Int16 = Registers(Field2)
                        If Rn < Rm Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case JumpCC.GT
                        Dim Rn As Int16 = Registers(Field1)
                        Dim Rm As Int16 = Registers(Field2)
                        If Rn > Rm Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case JumpCC.EQ
                        If Registers(Field1) = Registers(Field2) Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case JumpCC.NV
                        IncrementPC()
                    Case JumpCC.BL
                        If Registers(Field1) < Registers(Field2) Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case JumpCC.AB
                        If Registers(Field1) > Registers(Field2) Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case JumpCC.NE
                        If Registers(Field1) <> Registers(Field2) Then
                            Registers(15) = Data
                        Else
                            IncrementPC()
                        End If
                    Case Else 'Illegal case. Just skip over.
                        IncrementPC()
                End Select
            Case OpCodes.JUMPIDX
                Registers(15) = Registers(Field1)
            Case OpCodes.READIO
                IncrementPC()
            Case OpCodes.WRITEIO
                IncrementPC()
            Case Else 'Unknown instruction. Skip over.
                IncrementPC()
        End Select

        Registers(0) = 0 'Register zero is always zero.
        Cycles += 1
    End Sub

    Shared Function GetWord() As UInt16
        Return Memory(Registers(15))
    End Function

    Shared Sub IncrementPC()
        Registers(15) += 1
    End Sub
End Class

Public Enum States
    Idle
    Executing
    Paused
    Stepping
End Enum

Public Enum OpCodes
    LOADIMM
    LOAD
    LOADIDX
    STORE
    STOREIDX
    ADD
    SUBTRACT
    BITAND
    BITOR
    SHIFTR
    JUMP
    JUMPIDX
    UNDEFINED1
    UNDEFINED2
    READIO
    WRITEIO
End Enum

Public Enum JumpCC
    AL
    LT
    GT
    EQ
    NV
    BL
    AB
    NE
End Enum
