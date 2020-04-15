Public Class Parser
    Public Shared Function Parse(Code As String) As UInt16()
        Dim CodeArr As List(Of String) = New List(Of String)
        For i = 0 To (Code.Length \ 4) - 1 'Backslash means integer division which we want
            CodeArr.Add(Code.Substring(i * 4, 4))
        Next

        Dim Arr(65535) As UInt16
        Dim temp = CodeArr.ConvertAll(Of UInt16)(Function(str) Int32.Parse(str, Globalization.NumberStyles.AllowHexSpecifier))
        Array.Copy(temp.ToArray(), Arr, temp.ToArray().Length)

        Return Arr
    End Function

End Class
