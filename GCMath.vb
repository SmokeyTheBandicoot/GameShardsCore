Imports System.Math
Imports System.Numerics
Public Class GCMathExtended
    Public Function IsPrime(ByVal num As Long) As Boolean
        num = Abs(num)
        For x = 2 To Sqrt(num)
            If num Mod x = 0 Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Public Function AbsBigInt(ByVal BigInteger As BigInteger) As BigInteger
        Return BigInteger * BigInteger.Sign
    End Function

    Public Function NthRoot(ByVal number As Double, ByVal RootIndex As Integer) As Double
        Return number * (1 / RootIndex)
    End Function
End Class
