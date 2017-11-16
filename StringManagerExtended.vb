Option Strict On

Public Class StringManagerExtended
    ''' <summary>
    ''' Returns the portion of the string from the strarting string which starts with startchar and ends with endchar. Returns null if not found.
    ''' For example: GetStringPortion(ABCDEFGHI", "C", "H", True) returns "CDEFGHI", while GetStringPortion(ABCDEFGHI", "C", "H", false) returns "DEFG".
    ''' </summary>
    ''' <param name="expression"></param>
    ''' The string expression where the portion should be derived from
    ''' <param name="startchar"></param>
    ''' The start character of the portion
    ''' <param name="endchar"></param>
    ''' The eventual end char of the portion
    ''' <param name="IncludeExtremes"></param>
    ''' If the portion should include the first startchar and the last endchar
    ''' <param name="EndAsEndchar"></param>
    ''' If startchar is found and endchar not, this specifies wheter to see the last char of the string as the endchar or not 
    ''' (For example, GetStringPortion("ABCDEFGHI", "C", "M", True, True) returns "CDEFGHI" as if "I" is the endchar. If "EndAsEndchar" was false it would have returned null (end not found)
    ''' <param name="FoundEndChar"></param>
    ''' If EndAsEndchar is true, this variable returns true if the last char of the string is EndChar, false if not (end not found)
    ''' <returns></returns>
    ''' 
    Public Shared Function GetStringPortion(ByVal expression As String, ByVal startchar As Char, ByVal endchar As Char, Optional ByVal IncludeExtremes As Boolean = True, Optional ByVal EndAsEndchar As Boolean = False, Optional ByRef FoundEndChar As Boolean = False) As String
        Dim s As String = ""
        Dim startfound As Boolean = False
        Dim endfound As Boolean = False

        For x As Integer = 0 To expression.Length - 1

            If expression(x) = startchar Then
                startfound = True
            End If

            If startfound Then
                'String.Concat(s, expression(x))
                s &= expression(x)
            End If

            If startfound And expression(x) = endchar Then
                endfound = True
                Exit For
            End If

        Next

        'Last operations

        If Not startfound Then
            Return Nothing
        End If

        'MsgBox("start found")

        If Not IncludeExtremes Then
            If s.Count > 1 Then
                s = s.Remove(0, 1).Remove(s.Length - 2, 1)
            Else
                s = ""
            End If

        End If

        'MsgBox("extremes included")
        FoundEndChar = endfound

        If Not endfound Then
            If EndAsEndchar Then
                Return s
            Else
                Return Nothing
            End If
        End If

        'MsgBox("end found")

        'Return values

        Return s

    End Function


    ''' <summary>
    ''' Returns the first occurrence of a string into another. Returns -1 if it can't find any. s.length must be greater than c.length
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Public Shared Function GetFirstOccurrence(ByVal s As String, ByVal c As String) As Integer

        If String.IsNullOrEmpty(c) Or String.IsNullOrEmpty(s) Then
            'Throw New GSCoreIncompatibleArgumentsException("Cannot accept blank or null string as input (both params)")
            Return -1
        End If

        If c.Length > s.Length Then
            'Throw New GSCoreIncompatibleArgumentsException("Length of the string (s param) must be greater than or equal to the length of the target (c param)")
            Return -1
        End If

        Dim r As Integer = -1
        For x As Integer = 0 To s.Length - c.Length
            If s(x) = c(0) Then

                r = x

                For y As Integer = 1 To c.Length - 1

                    'If the first string is too short (should be checked in the for)
                    If x + y > s.Length - 1 Then
                        r = -1
                        Exit For
                    End If

                    'If the first string matches only partially
                    If Not s(x + y) = c(y) Then
                        r = -1
                        Exit For
                    End If

                Next

                If Not r = -1 Then
                    Return r
                End If

            End If
        Next

        Return r 'Here should always be -1

    End Function



    Public Shared Function SplitAtIndex(ByVal s As String, ByVal index As Integer) As String()

        Dim ss As String() = {"", ""}

        If index - 1 > s.Length Then
            Throw New GSCoreIncompatibleArgumentsException("[GSCore Exception] - Index must be less than or equal to the string length")
            Return Nothing
        End If

        For x As Integer = 0 To index - 1
            ss(0) &= s(0)
            s = s.Remove(0, 1)
        Next

        ss(1) = s

        Return ss

    End Function
End Class
