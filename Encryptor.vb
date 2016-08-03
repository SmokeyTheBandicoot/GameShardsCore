Public Class Encryptor

    'Translation Encryption
    Public Function TranslationEncrypt(ByVal c1() As Char, ScaleFactor As SByte) As String
        Dim i As Integer = Nothing
        Dim i2 As New List(Of Integer)
        i2.Clear()
        Dim FinalString As String = ""
        Dim c As Char = Nothing
        For x = 0 To c1.Count - 1
            i = Asc(c1(x))
            i2.Add(i + ScaleFactor)
            If i2(x) = 256 Then
                i2(x) = 0
            End If

            Try
                c = Chr(i2(x))
            Catch ex As Exception
                MsgBox("Something gone wrong. To prevent data loss the transformation has been canceled. " & ex.ToString)
                Return c1
            End Try
            FinalString &= c
        Next
        Return FinalString
    End Function

    'Complementary Encryption
    Public Function SymmetryEncrypt(ByVal c1() As Char) As String
        'Dim CharArray1() As Char
        'Dim CharArray2() As Char
        Dim i As Integer = Nothing
        Dim i2 As New List(Of Integer)
        i2.Clear()
        Dim FinalString As String = ""
        Dim c As Char = Nothing
        'CharArray1 = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", ",", ":", ";", "-", "(", ")", "/", "=", "?", "'", "!", "ò", "à", "ù", "è", "é", "ì", "*", "ù", "*", "#", "°", "@", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        'CharArray2 = {"I", "D", "E", "N", "R", "S", "F", "P", "O", "L", "J", "K", "T", "4", "x", "w", "é", "d", "f", "k", "G", "H", "-", "/", "@", "Y", "v", "y", "z", "1", "#", "°", "j", "ì", "i", "?", "'", "!", "5", "2", "3", "(", ",", ")", "m", "n", "o", "Q", "W", "e", "r", "t", "A", "B", "u", ";", ":", "#", "ò", "à", "M", "l", "q", "p", "s", "g", "C", "U", "V", ".", "=", "*", "ù", "è", "a", "X", "Z", "2", "3", "7", "b", "6", "8", "c", "h", "9"}

        For x = 0 To c1.Count - 1
            i = Asc(c1(x))
            i2.Add(255 - i)
            c = Chr(i2(x))
            FinalString &= c
        Next
        Return FinalString
    End Function

    'Positional Encryption
    Public Function PositionalEncrypt(ByVal c1() As Char) As String
        Dim s As String = Nothing
        For x = c1.Count - 1 To 0 Step -1
            s &= c1(x)
        Next
        Return s
    End Function
End Class
