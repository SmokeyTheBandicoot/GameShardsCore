Public Class Crasher

    Public Sub CrashByOverflowException()
        Dim a, b As Byte
        a = Byte.MaxValue
        b = Byte.MaxValue
        a += b
    End Sub

    Public Sub CrashByIndexOutOfRangeException()
        Dim a(0) As Integer
        a(1) = 5
    End Sub

    Public Sub CrashByDivisionBy0Exception()
        Dim a As Integer
        a = CInt(a / 0)
    End Sub
End Class
