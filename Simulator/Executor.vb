'This executes code in a shared state.
Public Class Executor
    Public Shared Registers(15) As UInt16
    Public Shared Memory(65535) As UInt16
    Public Shared Code() As UInt16 'Array of integers that are the instructions
    Public Shared State As States = States.Idle
    Public Shared Cycles As Integer = 0

    Shared Sub Reset()
        'Set to zeros
        ReDim Registers(15)
        ReDim Memory(65535)
        'Paste code into memory directly
        Array.Copy(Code, Memory, Code.Length)
        State = States.Idle
    End Sub

    Shared Sub PowerOn()
        Reset()
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
            While State <> States.Executing 'Save on cpu resources when paused, idle, or stepping.
                Threading.Thread.Sleep(100)
            End While

            StepOnce(False, Word, OpCode, Field1, Field2, Field3, Data) 'Send it ByRef to save on time when objects are created/destroyed

            'Application.DoEvents() 'If uncommented, allows for the loop to be called from the main thread. Causes a lot of slowdown.
        End While
    End Sub

    Shared Sub StepOnce(Optional Stepping As Boolean = True, Optional ByRef Word As UInt16 = 0, Optional ByRef OpCode As Byte = 0, Optional ByRef Field1 As Byte = 0,
                        Optional ByRef Field2 As Byte = 0, Optional ByRef Field3 As Byte = 0, Optional ByRef Data As UInt16 = 0)
        If Stepping Then
            State = States.Stepping
        End If

        Word = GetWord()
        OpCode = (Word And CType(&HF000, UInt16)) >> 12 'Masks to get only the first nibble
        Field1 = (Word And CType(&HF00, UInt16)) >> 8   'Masks to get only the second nibble
        Field2 = (Word And CType(&HF0, UInt16)) >> 4    'Masks to get only the 3rd nibble
        Field3 = (Word And CType(&HF, UInt16))          'Masks to get only the 4th nibble

        If (OpCode = OpCodes.LOADIMM) Or (OpCode = OpCodes.LOAD) Or (OpCode = OpCodes.STORE) Or (OpCode = OpCodes.JUMP) Then 'Load data (next word) if needed
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
            Case OpCodes.BITXOR
                Registers(Field1) = Registers(Field2) XOr Registers(Field3)
                IncrementPC()
            Case OpCodes.SHIFTR
                Dim Temp As Int16 = Registers(Field1) 'This is a signed shift so conversion is needed
                Registers(Field1) = Temp >> 1
                Registers(Field3) = Temp And CType(1, UInt16)
                IncrementPC()
            Case OpCodes.JUMP
                Select Case Field3 'CC Field
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
                Select Case Registers(Field2)
                    Case &H10
                        Registers(Field1) = PushBtn.GetBtn()
                    Case &H20
                        Registers(Field1) = LED.DataOut()
                    Case &H50
                        Registers(Field1) = TmrCnt.DataOut()
                    Case Else
                        Registers(Field1) = 0
                End Select
                IncrementPC()
            Case OpCodes.WRITEIO
                Select Case Registers(Field2)
                    Case 0
                        Graphics.XPosIn(Registers(Field1))
                    Case 1
                        Graphics.YPosIn(Registers(Field1))
                    Case 2
                        'Prevent the executor from going too far ahead of graphics
                        If Graphics.Buffer.Count > 16383 Then
                            While Graphics.Buffer.Count <> 0

                            End While
                        End If
                        'While Graphics.Buffer.Count > 100

                        'End While
                        Graphics.CIn(Registers(Field1))
                    Case &H20
                        LED.DataIn(Registers(Field1))
                        'No default case as the write is unused elsewhere
                End Select
                IncrementPC()
            Case Else 'Unknown instruction. Skip over.
                'A real CPU would either continue, stop, lock up, or burn up.
                'Hence why it is vital that only valid instructions occur and random jumps don't happen on real hardware.
                IncrementPC()
        End Select

        'As only one instruction is executed at a time, it is impossible for R0 to be anything besides 0.
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
    BITXOR
    SHIFTR
    JUMP
    JUMPIDX
    UNDEFINED1 'D
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
