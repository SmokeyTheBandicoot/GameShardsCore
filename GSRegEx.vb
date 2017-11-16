Option Strict On
Option Explicit On

Imports GameShardsCore.StringManagerExtended


''' <summary>
''' GSRegEx syntax:
''' Operators in priority order:
''' 
''' --------Groups: 
''' 
''' $[X1-X2]            Evaluates groups of chars.     
''' for example "$[A-K]" means every letter from A to K. $[1-7] means every char number from 1 to 7. X1 and X2 are chars
''' 
''' ${X1-X2}            Evaluates groups of numbers.   
''' for example "$[1-60]" means every number from 1 to 60.
''' for example "$[01-60]" means every number from 01 to 60. 
''' 
''' NOTE: Use ! in groups to negate or exclude extremes
''' 
''' for example "l$[!l]" will match "slam" but not "call" (because of the double l. It will look for a "l" not followed by another "l" char)
''' for example "m$[!n-!r]" will match every word which contains a "m" followed by a char that is not a letter from N to R (N and R excluded)
''' for example "f$![a-z]" will match every word which does not contain lower case any letter
''' 
''' NOTE: GROUPS CANNOT CONTAIN * OR $ CHARS!
''' 
''' 
''' --------Functions:
''' 
''' $Matches(Str)       Exact match. 
''' for example "$Matches(hello)" only matches the string "hello", not " hello", "hello guys" or "hello."
''' 
''' $ContainsW(Str)     Matches the string if it contains Str. A word is a string that finisces with a space, a period or a newline char
''' for example "$ContainsW("hello")" matches "hello", " hello", "hello." but not "sayhello"
''' 
''' $StartsWith(Str)    Mathces the string if it starts with Str. This means that Str must be at the start or the string
''' for example "$StartsWith("hello")" mathces "hello guys", "helloguys" but not "hi, hello guys"
''' 
''' $StartsWithW(Str)   Mathces the string if it starts with Str after a space. This means it will match any word that starts with Str
''' for example "$StartsWithW("hello")" mathces "hello guys", "helloguys", "hi, hello guys" but not "hi,hello guys"
''' 
''' $EndsWith(Str)      Mathces the string if it ends with Str. This means that Str must be at the end or the string
''' for example "$EndsWith("guys")" mathces "hello guys", "helloguys" but not "hi, hello guys."
''' 
''' $EndsWithW(Str)      Mathces the string if it ends with a space before Str. This means that Str must be the last word of the string
''' for example "$EndsWithW("guys")" mathces "hello guys", "guys" but not "helloguys"
''' 
''' $ContainsAfter(Str1-Str2)
'''                      Matches all words which contain Str2 only after Str1
''' for example "$ContainsAfter(aa-bb) matches "aaccbb" but not "bbccaa"      
'''  
''' $MinLen(Int)         Matches all entries which contain at least MinLen characters
''' 
''' $MinWLen(Int)        Matches all entries which contain at least one word with at least MinLen characters
''' 
''' $MaxLen(Int)         Matches all entries which contain at most MaxLen characters
''' 
''' $MaxWLen(Int)        Matches all entries which contain at least one word with at most MaxLen characters
''' 
''' NOTE: use ! to negate. 
''' for example "$!EndsWith(Str)" matches all entries whose last word doesn't end with Str
''' 
''' 
''' 
''' --------Logic Operators
''' 
''' $Not EX1            Evaluates an expression and returns all strings that did not match it
''' 
''' $! EX1              Same as $Not
''' 
''' EX1 $And EX2        Evaluates two expressions and intersects the results. It will return the strings that match both expressions
''' 
''' EX1 $& EX2          Same as $And
''' 
''' EX1 $Or EX2         Evaluates two expressions and returns the strings that matched AT LEAST one of the expressions
''' 
''' EX1 $/EX2          Same as $Or
''' 
''' EX1 $XOr EX2       Evaluates two expressions and returns the strings that matched ONLY ONE expression, not both or none
''' 
''' EX1 $# EX2          Same as $XOr
''' 
''' 
''' --------Unknowns:   
''' 
''' *                   Puts every SINGLE ASCII char in place of ONE every *
''' for example "a*c" will give results for "abc", "acc", "a1c", and every char that can stay in place of the *
''' for example "a**c" gives out any combination matching the char "a", followed by 2 any chars, and followed by "c" ("a1kc", "a22c", etc)
''' 
''' $?[X1-X2]            Puts from X1 to X2 times any ASCII character.
''' for example "a?[1-3]c" matches "abc", "abkc", "a123c"
''' 
''' $%[Char-X1-X2]       Puts from X1 to X2 times the char "Char"
''' for example "a%[K-0-4]c" matches "ac", "aKc", "aKKc", "aKKKc", "aKKKKc" but not "aKKKKKc"
''' 
''' 
''' 
''' NOTES:
''' 
''' $ AND * ARE RESERVED CHARS: * AND ? WON?T BE REPLACED BY $ INSTANCES TO AVOID RECURSION AND ERRORS/UNINTENDED BEHAVIOUR!!!.
''' 
''' You can use shortcuts to represent classes of chars:
''' 
''' :alphab:
''' :digit:
''' :alphnum:
''' :symb:
''' :upper:
''' :lower:
''' :esadigit:
''' 
''' 
''' 
''' </summary>
Public Class GSRegEx

    Private _StringExpression As String
    Private _CaseSensitive As Boolean
    Private _ASCIICap As Byte

    Public Sub New()
        StringExpression = ""
        CaseSensitive = True
        ASCIICap = 127
    End Sub

    Public Sub New(StringExpression As String)
        Me.StringExpression = StringExpression
        CaseSensitive = True
        ASCIICap = 127
    End Sub

    Public Sub New(StringExpression As String, CaseSensitive As Boolean, ASCIICap As Byte)
        Me.StringExpression = StringExpression
        Me.CaseSensitive = CaseSensitive
        Me.ASCIICap = ASCIICap
    End Sub

    Public Property StringExpression As String
        Get
            Return _StringExpression
        End Get
        Set(value As String)
            _StringExpression = value
        End Set
    End Property

    Public Property CaseSensitive As Boolean
        Get
            Return _CaseSensitive
        End Get
        Set(value As Boolean)
            _CaseSensitive = value
        End Set
    End Property

    Public Property ASCIICap As Byte
        Get
            Return _ASCIICap
        End Get
        Set(value As Byte)
            _ASCIICap = value
        End Set
    End Property

End Class

Public Class Register
    Public Lists As New List(Of String)
    Public Keys As New List(Of String)

    Public Sub New(_lists As List(Of String), _keys As List(Of String))
        Lists = New List(Of String)
        Lists = _lists
        Keys = New List(Of String)
        Keys = _keys
    End Sub

    Public Sub PrintRegister()
        Dim s As String = ""

        For x = 0 To Keys.Count - 1
            s += Lists(x) + "---" + Keys(x) + vbNewLine
        Next

        MsgBox(s)
    End Sub
End Class



Public Class GSRegExEvaluator

    Dim _ThrowExceptions As Boolean = False

    Public Property ThrowExceptions As Boolean
        Get
            Return _ThrowExceptions
        End Get
        Set(value As Boolean)
            _ThrowExceptions = value
        End Set
    End Property

    Public Shared Function Evaluate(ByVal expression As GSRegEx, ByVal register As Register, ByRef Results As List(Of String), Optional ByVal ThrowExceptions As Boolean = True, Optional ByVal PartialEvaluation As Boolean = False) As List(Of String)

        'Dim l As New List(Of String)
        'Dim finalregister As New List(Of String)

        If expression.StringExpression.Length > 0 Then

            If expression.StringExpression.Length > 2 AndAlso expression.StringExpression.Contains("$*") Then
                If ThrowExceptions Then
                    Throw New GSCoreIncorrectSyntaxException("[GSCore exception] - The expression cannot have the * operator after a $ operator due to unintended behaviours and eventual crashes.")
                End If
                Return {"Error01 - The expression cannot have the * operator after a $ operator"}.ToList
            End If




#Region "LogicOperators"
            If (GetFirstOccurrence(expression.StringExpression, "$And") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$And") = expression.StringExpression.Length - 4) Then

                'The expression contains an AND operator, the registers must be intersected
                Dim spl As String() = SplitAtIndex(expression.StringExpression, GetFirstOccurrence(expression.StringExpression, "$And"))
                spl(1) = spl(1).Remove(0, 2) 'Removes the first $& from the string

                Dim r1 As New List(Of String)
                Dim r2 As New List(Of String)

                r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register, New List(Of String), ThrowExceptions, True)
                r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register, New List(Of String), ThrowExceptions, True)

                For h As Integer = 0 To r1.Count - 1
                    For j As Integer = 0 To r2.Count - 1
                        If r1(h) = r2(j) Then
                            Results.Add(r1(h))
                        End If
                    Next
                Next

            End If


            If (GetFirstOccurrence(expression.StringExpression, "$&") > 0) AndAlso Not expression.StringExpression.EndsWith("$&") Then '(Not GetFirstOccurrence(expression.StringExpression, "$&") = expression.StringExpression.Length - 2) Then

                'The expression contains an AND operator (short version), the registers must be intersected
                Dim spl As String() = SplitAtIndex(expression.StringExpression, GetFirstOccurrence(expression.StringExpression, "$&"))
                spl(1) = spl(1).Remove(0, 2) 'Removes the first $& from the string

                Dim r1 As New List(Of String)
                Dim r2 As New List(Of String)

                r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register, New List(Of String), ThrowExceptions, True)
                r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register, New List(Of String), ThrowExceptions, True)

                If r1.Count > 0 AndAlso r2.Count > 0 Then

                    For h As Integer = 0 To r1.Count - 1
                        For j As Integer = 0 To r2.Count - 1
                            If r1(h) = r2(j) Then
                                Results.Add(r1(h))
                            End If
                        Next
                    Next
                End If
            End If


            If (GetFirstOccurrence(expression.StringExpression, "$Or") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$Or") = expression.StringExpression.Length - 3) Then

                'The expression contains an OR operator, the registers must be intersected
                Dim spl As String() = Split(expression.StringExpression, "$Or")

                'PUT OR IN CHAINS. CURRENTLY SPLIT GIVES THE RESULTS OF THE FIRST TWO AND INGORES THE OTHERS

                Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register, Results)
                Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register, Results)

            End If


            If (GetFirstOccurrence(expression.StringExpression, "$/") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$/") = expression.StringExpression.Length - 2) Then

                'The expression contains an OR operator (short version), the registers must be intersected
                Dim spl As String() = Split(expression.StringExpression, "$/")

                'PUT OR IN CHAINS. CURRENTLY SPLIT GIVES THE RESULTS OF THE FIRST TWO AND INGORES THE OTHERS

                Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register, Results)
                Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register, Results)

            End If

            If (GetFirstOccurrence(expression.StringExpression, "$Not") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$/") = expression.StringExpression.Length - 2) Then

                Dim pos As Integer = GetFirstOccurrence(expression.StringExpression, "$Not")

                'If (GetFirstOccurrence(expression.StringExpression, "$Not$") < 1) OrElse (GetFirstOccurrence(expression.StringExpression, "$Not*") > 0) Then
                '    If ThrowExceptions Then
                '        Throw New GSCoreIncorrectSyntaxException("The NOT operator cannot be follower by $ or * chars, (Char position:" + pos.ToString + ").")
                '    End If
                'End If

                If (GetFirstOccurrence(expression.StringExpression, "$Not") <> 0) OrElse (GetFirstOccurrence(expression.StringExpression, "$Not") <> 0) Then
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("The NOT operator must be at the beginning of the expression, (Char position:" + pos.ToString + ").")
                    End If
                End If

                'The expression contains an OR operator (short version), the registers must be intersected
                Dim spl As String() = Split(expression.StringExpression, "$Not")

                'PUT OR IN CHAINS. CURRENTLY SPLIT GIVES THE RESULTS OF THE FIRST TWO AND INGORES THE OTHERS

                Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register, Results)
                Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register, Results)

            End If
#End Region

#Region "Unknowns"

            ' * OPERATOR
            If Not (GetFirstOccurrence(expression.StringExpression, "*") = -1) Then
                'The string contains at least one *
                Dim pos As Integer = GetFirstOccurrence(expression.StringExpression, "*") 'placeholder

                Dim firstpart As String = SplitAtIndex(expression.StringExpression, pos)(0)

                expression.StringExpression = expression.StringExpression.Remove(pos, 1)
                'MsgBox(expression.StringExpression)

                For x As Integer = 0 To register.Keys.Count - 1

                    If register.Keys(x).Length = 1 Then
                        register.Keys(x) = ""  '-Invalidates the key: it doesn't contain enough characters
                    End If

                    If GetFirstOccurrence(register.Keys(x), firstpart) <> -1 Then
                        'MsgBox(register.Keys(x))
                        register.Keys(x) = register.Keys(x).Remove(GetFirstOccurrence(register.Keys(x), firstpart) + firstpart.Length, 1)
                        'MsgBox(register.Keys(x))
                    End If
                Next

                'register.PrintRegister()
                'Evaluate(New GSRegEx(expression.StringExpression, expression.CaseSensitive, expression.ASCIICap), register, New List(Of String), ThrowExceptions)
                Evaluate(expression, register, New List(Of String), ThrowExceptions)
            End If


            ' ? OPERATOR
            If Not GetFirstOccurrence(expression.StringExpression, "$?") = -1 And (GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False) IsNot Nothing) Then

                'The string contains at least one $?

                'Checking syntax: $?[<min>-<max>]
                Dim pos As Integer = GetFirstOccurrence(expression.StringExpression, "$?")
                Dim comm As String = GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False)
                Dim ph As Integer = GetFirstOccurrence(expression.StringExpression, "$?") 'placeholder
                Dim min, max As Integer 'the params
                Dim minmax As String() = Split(comm.Remove(0, 1).Remove(comm.Length - 2, 1), "-")
                Dim s As String

                If String.IsNullOrEmpty(comm) OrElse GetFirstOccurrence(expression.StringExpression, comm) <> pos + 2 Then
                    'the string does not contain any "[<something>]" or it is in a different position. Conclusion: syntax for this command is not correct
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot find Square parenthesis after ""$?"", (Char position:" + pos.ToString + ").")
                    End If

                End If
                'MsgBox(String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)))

                'If Not (String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)) OrElse (Not GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False).Contains("]$?"))) Then
                '    'the user entered two $? one next to each other: syntax is invalid
                '    Throw New GSCoreIncorrectSyntaxException("You can't put two ""$?"" commands next to each other: syntax is invalid, (Char position:" + pos.ToString + ").")
                'End If

                If minmax.Count <> 2 Then
                    'The user has entered invalid string into the square parenthesis, such as "$?[lol]" or "-1-" or "1--2"
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot decode the params in the square parenthesis. Use only positive integers, (Char position:" + pos.ToString + ").")
                    End If
                End If

                If Not (Integer.TryParse(minmax(0), min) And Integer.TryParse(minmax(1), max)) Then
                    'The user has entered invalid params, such as letters or too big numbers
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot transform parenthesis' params into positive integers. The numbers may be too big (max: 32), (Char position:" + pos.ToString + ").")
                    End If
                End If

                If min > max Then
                    'Min cannot be greater than max
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Min (" + min.ToString + ") cannot be greater than Max (" + max.ToString + "), (Char position:" + pos.ToString + ").")
                    End If
                End If

                'remove the command from the string
                s = expression.StringExpression.Remove(pos, comm.Length + 2)

                For x As Integer = min To max
                    s = s.Insert(pos, "*") 'Any ? may be converted into some number of "*"
                    expression.StringExpression = s
                    MsgBox(s)
                    Evaluate(expression, register, Results, ThrowExceptions)
                Next

            End If


            ' % OPERATOR  - TOTEST!!!!!!!!! IT IS NOT TESTED!!!!!!!!!!!!!
            If Not GetFirstOccurrence(expression.StringExpression, "$%") = -1 And (GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False) IsNot Nothing) Then

                'The string contains at least one $?

                'Checking syntax: $?[<min>-<max>]
                Dim pos As Integer = GetFirstOccurrence(expression.StringExpression, "$%")
                Dim comm As String = GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False)
                Dim min, max As Integer 'the params
                Dim ch As Char
                Dim params As String() = Split(comm.Remove(0, 1).Remove(comm.Length - 2, 1), "-")
                Dim s As String

                If String.IsNullOrEmpty(comm) OrElse GetFirstOccurrence(expression.StringExpression, comm) <> pos + 2 Then
                    'the string does not contain any "[<something>]" or it is in a different position. Conclusion: syntax for this command is not correct
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot find Square parenthesis after ""$%"", (Char position:" + pos.ToString + ").")
                    End If

                End If
                'MsgBox(String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)))

                'If Not (String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)) OrElse (Not GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False).Contains("]$?"))) Then
                '    'the user entered two $? one next to each other: syntax is invalid
                '    Throw New GSCoreIncorrectSyntaxException("You can't put two ""$?"" commands next to each other: syntax is invalid, (Char position:" + pos.ToString + ").")
                'End If

                If params.Count <> 3 Then
                    'The user has entered invalid string into the square parenthesis, such as "$?[lol]" or "-1-" or "1--2"
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot decode the params in the square parenthesis. Use only positive integers, (Char position:" + pos.ToString + ").")
                    End If
                End If

                If Not (Char.TryParse(params(0), ch) AndAlso Integer.TryParse(params(1), min)) AndAlso Integer.TryParse(params(2), max) Then
                    'The user has entered invalid params, such as letters or too big numbers
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Cannot transform parenthesis' params into a char and two positive integers. The numbers may be too big (max: 32), (Char position:" + pos.ToString + ").")
                    End If
                End If

                If min > max Then
                    'Min cannot be greater than max
                    If ThrowExceptions Then
                        Throw New GSCoreIncorrectSyntaxException("Min (" + min.ToString + ") cannot be greater than Max (" + max.ToString + "), (Char position:" + pos.ToString + ").")
                    End If
                End If

                'remove the command from the string
                s = expression.StringExpression.Remove(pos, comm.Length + 2)

                For x As Integer = min To max
                    s = s.Insert(pos, ch) 'will put from min to max times the char ch in the specified position (in place of $%)
                    expression.StringExpression = s
                    MsgBox(s)
                    Evaluate(expression, register, New List(Of String), ThrowExceptions)
                Next

            End If
#End Region


            'FINAL:      the expression does Not contain any operator. can return registry
            'l = GetSearches(expression.StringExpression, register)
            'For j = 0 To l.Count - 1
            '    Results.Add(l(j))
            'Next

            'Results.AddRange(GetSearches(expression.StringExpression, register))
            If Not PartialEvaluation Then

                For k As Integer = 0 To register.Lists.Count - 1
                    If register.Keys(k).Contains(expression.StringExpression) Then
                        Results.Add(register.Lists(k))
                    End If
                Next

            Else

                Dim tempres As New List(Of String)
                For k As Integer = 0 To register.Lists.Count - 1
                    If register.Keys(k).Contains(expression.StringExpression) Then
                        tempres.Add(register.Lists(k))
                    End If
                Next

                Return tempres

            End If
            'finalregister.Add("lol")

            Return Results

        End If

    End Function

    'Public Function Evaluate(ByVal expression As GSRegEx, ByVal register As List(Of String)) As List(Of String)

    '    Dim l As New List(Of String)
    '    Dim finalregister As New List(Of String)

    '    If expression.StringExpression.Length > 0 Then

    '        'If expression.StringExpression.Contains("$*") Then
    '        '    If ThrowExceptions Then
    '        '        Throw New GSCoreIncorrectSyntaxException("[GSCore exception] - The expression cannot have the * Operator after a $ Operator due To unintended behaviours And eventual crashes.")
    '        '    End If
    '        '    Return {"Error01 - The expression cannot have the * Operator after a $ Operator"}.ToList
    '        'End If


    '        If Not (GetFirstOccurrence(expression.StringExpression, "*") = -1) Then
    '            'The string contains at least one *
    '            Dim ph As Integer = GetFirstOccurrence(expression.StringExpression, "*") 'placeholder
    '            For x As Integer = 0 To expression.ASCIICap
    '                If Not (x = 36 Or x = 42 Or (x < 32) Or x = 127) Then '$ and * chars respectively, with control characters removed
    '                    'Since the characters of a string are immutable (readonly), I have to use this method:
    '                    'MsgBox(expression.StringExpression.Remove(ph, 1).Insert(ph, Chr(x)))
    '                    'register.Add(expression.StringExpression.Remove(ph, 1).Insert(ph, Chr(x)))
    '                    finalregister.AddRange(Evaluate(New GSRegEx(expression.StringExpression.Remove(ph, 1).Insert(ph, Chr(x)), expression.CaseSensitive, expression.ASCIICap), register))
    '                End If
    '            Next
    '        End If

    '        If Not GetFirstOccurrence(expression.StringExpression, "$?") = -1 And (GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False) IsNot Nothing) Then

    '            'The string contains at least one $?

    '            'Checking syntax: $?[<min>-<max>]
    '            Dim pos As Integer = GetFirstOccurrence(expression.StringExpression, "$?")
    '            Dim comm As String = GetStringPortion(expression.StringExpression, CChar("["), CChar("]"), True, False)
    '            Dim ph As Integer = GetFirstOccurrence(expression.StringExpression, "$?") 'placeholder
    '            Dim min, max As Integer 'the params
    '            Dim minmax As String() = Split(comm.Remove(0, 1).Remove(comm.Length - 2, 1), "-")
    '            Dim s As String

    '            If String.IsNullOrEmpty(comm) OrElse GetFirstOccurrence(expression.StringExpression, comm) <> pos + 2 Then
    '                'the string does not contain any "[<something>]" or it is in a different position. Conclusion: syntax for this command is not correct
    '                If ThrowExceptions Then
    '                    Throw New GSCoreIncorrectSyntaxException("Cannot find Square parenthesis after ""$?"", (Char position:" + pos.ToString + ").")
    '                End If

    '            End If
    '            'MsgBox(String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)))

    '            'If Not (String.IsNullOrEmpty(GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False)) OrElse (Not GetStringPortion(expression.StringExpression, CChar("["), CChar("?"), False, False).Contains("]$?"))) Then
    '            '    'the user entered two $? one next to each other: syntax is invalid
    '            '    Throw New GSCoreIncorrectSyntaxException("You can't put two ""$?"" commands next to each other: syntax is invalid, (Char position:" + pos.ToString + ").")
    '            'End If

    '            If minmax.Count <> 2 Then
    '                'The user has entered invalid string into the square parenthesis, such as "$?[lol]" or "-1-" or "1--2"
    '                If ThrowExceptions Then
    '                    Throw New GSCoreIncorrectSyntaxException("Cannot decode the params in the square parenthesis. Use only positive integers, (Char position:" + pos.ToString + ").")
    '                End If
    '            End If

    '            If Not (Integer.TryParse(minmax(0), min) And Integer.TryParse(minmax(1), max)) Then
    '                'The user has entered invalid params, such as letters or too big numbers
    '                If ThrowExceptions Then
    '                    Throw New GSCoreIncorrectSyntaxException("Cannot transform parenthesis' params into positive integers. The numbers may be too big (max: 32), (Char position:" + pos.ToString + ").")
    '                End If
    '            End If

    '            If min > max Then
    '                'Min cannot be greater than max
    '                If ThrowExceptions Then
    '                    Throw New GSCoreIncorrectSyntaxException("Min (" + min.ToString + ") cannot be greater than Max (" + max.ToString + "), (Char position:" + pos.ToString + ").")
    '                End If
    '            End If

    '            'remove the command from the string
    '            s = expression.StringExpression.Remove(pos, comm.Length + 2)

    '            For x As Integer = min To max
    '                s = s.Insert(pos, "*") 'Any ? may be converted into some number of "*"
    '                MsgBox(s)
    '                finalregister.AddRange(Evaluate(New GSRegEx(s, expression.CaseSensitive, expression.ASCIICap), register))
    '            Next

    '        End If


    '        If (GetFirstOccurrence(expression.StringExpression, "$And") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$And") = expression.StringExpression.Length - 4) Then

    '            'The expression contains an AND operator, the registers must be intersected
    '            Dim spl As String() = SplitAtIndex(expression.StringExpression, GetFirstOccurrence(expression.StringExpression, "$And"))
    '            spl(1) = spl(1).Remove(0, 2) 'Removes the first $& from the string

    '            Dim r1 As New List(Of String)
    '            Dim r2 As New List(Of String)

    '            r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register)
    '            r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register)

    '            For h As Integer = 0 To r1.Count - 1
    '                For j As Integer = 0 To r2.Count - 1
    '                    If r1(h) = r2(j) Then
    '                        finalregister.Add(r1(h))
    '                    End If
    '                Next
    '            Next

    '            'Dim spl As String() = Split(expression.StringExpression, "$And")
    '            'Dim reg As New List(Of List(Of String))

    '            'For x As Integer = 0 To spl.Count - 1
    '            '    reg.Add(Evaluate(New GSRegEx(spl(x), expression.CaseSensitive, expression.ASCIICap), register))
    '            'Next

    '            'For x As Integer = 0 To reg.Count - 1
    '            '    For y As Integer = 0 To reg(x).Count - 1
    '            '        For z As Integer = 0 To reg.Count - 1
    '            '            If Not (z = x) Then
    '            '                For w As Integer = 0 To reg(z).Count - 1
    '            '                    If reg(x)(y) = reg(z)(w) Then
    '            '                        finalregister.Add(reg(x)(y))
    '            '                    End If
    '            '                Next
    '            '            End If
    '            '        Next
    '            '    Next
    '            'Next

    '        End If


    '        If (GetFirstOccurrence(expression.StringExpression, "$&") > 0) AndAlso Not expression.StringExpression.EndsWith("$&") Then '(Not GetFirstOccurrence(expression.StringExpression, "$&") = expression.StringExpression.Length - 2) Then

    '            'The expression contains an AND operator (short version), the registers must be intersected
    '            Dim spl As String() = SplitAtIndex(expression.StringExpression, GetFirstOccurrence(expression.StringExpression, "$&"))
    '            spl(1) = spl(1).Remove(0, 2) 'Removes the first $& from the string

    '            Dim r1 As New List(Of String)
    '            Dim r2 As New List(Of String)

    '            r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register)
    '            r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register)

    '            For h As Integer = 0 To r1.Count - 1
    '                For j As Integer = 0 To r2.Count - 1
    '                    If r1(h) = r2(j) Then
    '                        finalregister.Add(r1(h))
    '                    End If
    '                Next
    '            Next

    '        End If


    '        If (GetFirstOccurrence(expression.StringExpression, "$Or") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$Or") = expression.StringExpression.Length - 3) Then

    '            'The expression contains an OR operator, the registers must be intersected
    '            Dim spl As String() = Split(expression.StringExpression, "$Or")

    '            'PUT OR IN CHAINS. CURRENTLY SPLIT GIVES THE RESULTS OF THE FIRST TWO AND INGORES THE OTHERS


    '            Dim r1 As New List(Of String)
    '            Dim r2 As New List(Of String)

    '            r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register)
    '            r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register)

    '            For h As Integer = 0 To r1.Count - 1
    '                finalregister.Add(r1(h))
    '            Next
    '            For j As Integer = 0 To r2.Count - 1
    '                finalregister.Add(r2(j))
    '            Next

    '        End If


    '        If (GetFirstOccurrence(expression.StringExpression, "$/") > 0) AndAlso (Not GetFirstOccurrence(expression.StringExpression, "$/") = expression.StringExpression.Length - 2) Then

    '            'The expression contains an OR operator (short version), the registers must be intersected
    '            Dim spl As String() = Split(expression.StringExpression, "$/")

    '            Dim r1 As New List(Of String)
    '            Dim r2 As New List(Of String)

    '            r1 = Evaluate(New GSRegEx(spl(0), expression.CaseSensitive, expression.ASCIICap), register)
    '            r2 = Evaluate(New GSRegEx(spl(1), expression.CaseSensitive, expression.ASCIICap), register)

    '            For h As Integer = 0 To r1.Count - 1
    '                finalregister.Add(r1(h))
    '            Next
    '            For j As Integer = 0 To r2.Count - 1
    '                finalregister.Add(r2(j))
    '            Next

    '        End If



    '        'FINAL:      the expression does Not contain any operator. can return registry
    '        l = GetSearches(expression.StringExpression, register)
    '        For j = 0 To l.Count - 1
    '            finalregister.Add(l(j))
    '        Next

    '        'finalregister.Add("lol")

    '        Return finalregister

    '    End If



    'End Function


    'PRIORITY:
    '-Unknowns (* (unknown char, known number of chars), ?[N1, N2](unknown both char type and number from N1 to N2 (N1, N2 belong to N)))
    '-Groups (A-Z), [1-3]
    '-Function (Contains, ContainsW, StartsWith, StartsWithW, EndsWith, EndsWithW, Match, 
    '-Not
    '-And
    '-Or
    '-Xor

    'Public Shared Function GetSearches(ExpressionString As String, ByVal Reg As Register) As List(Of String)
    '    Dim f As New List(Of String)

    '    For k As Integer = 0 To Reg.Lists.Count - 1
    '        If Reg.Keys(k).Contains(ExpressionString) Then
    '            f.Add(Reg.Lists(k))
    '            'MsgBox(Reg.Lists(k) + " ___ " + Reg.Keys(k))
    '        End If
    '    Next

    '    Return f

    'End Function
End Class

