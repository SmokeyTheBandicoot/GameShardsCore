Imports System.Drawing
Imports System.Numerics
Imports System.Random
Imports System.Math

Namespace Base
    Public Class ColorManager
        Public Function GetComplementaryColor(ByVal color As Color, Optional ByVal ConsiderTransparency As Boolean = False) As Color
            If ConsiderTransparency Then
                Return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B, 255 - color.A)
            End If
            Return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B)
        End Function
    End Class

    Namespace Geometry
        Public Class Geometry
            Public Function GetDistanceFrom2Points(ByVal point1 As Point, ByVal point2 As Point) As ULong
                Return CULng(System.Math.Sqrt((point1.X - point2.X) ^ 2 + (point1.Y - point2.Y) ^ 2))
            End Function

            Public Function GetAngularCoefficientFrom2Points(ByVal point1 As Point, ByVal point2 As Point) As Single
                Return CSng(((point1.Y - point2.Y) / (point1.X - point2.X)))
            End Function

            Public Function GetAngleFrom2Points(ByVal point1 As Point, ByVal point2 As Point) As Single
                Return CSng(Atan((point1.Y - point2.Y) / (point1.X / point2.X)))
            End Function

            Public Function GetCenterOfRectangle(ByVal rect As Rectangle) As Point
                Dim p As New Point
                p.X = CInt(rect.Left + rect.Width / 2)
                p.Y = CInt(rect.Top + rect.Height / 2)
                Return p
            End Function

            Public Function GetRectangleFromCenterAndSize(ByVal center As Point, ByVal size As Size) As Rectangle
                Dim r As New Rectangle
                r.Location = New Point(CInt(center.X - size.Width / 2), CInt(center.Y - size.Height / 2))
                r.Size = size
                Return r
            End Function

            'Public Function GetVectorialDistanceFrom2Points(ByVal p1 As Point, ByVal p2 As Point) As Vector2D
            '    vect = New Vector2D((math.Abs(p2.X - p1.X)), math.Abs(p2.Y - p1.Y))
            '    Return vect
            'End Function

            Public Function CheckIfRectangleIntersectsPoint(ByVal Rect As Rectangle, ByVal point As Point) As Boolean
                If (point.X > Rect.Left AndAlso point.X < Rect.Right) AndAlso (point.Y > Rect.Top AndAlso point.Y < Rect.Bottom) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class
    End Namespace

    Namespace Math
        Public Class MiscMath
            Public Function GenRandomInt(inMin As Int32, inMax As Int32) As Int32
                Static staticRandomGenerator As New Random
                If inMin > inMax Then Dim t = inMin : inMin = inMax : inMax = t
                If inMax < Int32.MaxValue Then Return staticRandomGenerator.Next(inMin, inMax + 1)
                ' now max = Int32.MaxValue, so we need to work around Microsoft's quirk of an exclusive max parameter.
                If inMin > Int32.MinValue Then Return staticRandomGenerator.Next(inMin - 1, inMax) + 1 ' okay, this was the easy one.
                ' now min and max give full range of integer, but Random.Next() does not give us an option for the full range of integer.
                ' so we need to use Random.NextBytes() to give us 4 random bytes, then convert that to our random int.
                Dim bytes(3) As Byte ' 4 bytes, 0 to 3
                staticRandomGenerator.NextBytes(bytes) ' 4 random bytes
                Return BitConverter.ToInt32(bytes, 0) ' return bytes converted to a random Int32
            End Function

            ''' <summary>
            ''' Avvicinates a number (curvalue) to the goal number (goalvalue) with a difference of (stepnum)
            ''' ........curvalue[.....]STEP[.....]STEP[.....]STEP[...][Goal]........................
            ''' </summary>
            ''' <param name="curvalue"></param>
            ''' <param name="goalvalue"></param>
            ''' <param name="stepnum"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function Advicinate(ByVal curvalue As Integer, ByVal goalvalue As Integer, ByVal stepnum As Integer, Optional ByVal random As Boolean = False) As Integer
                If curvalue = goalvalue Then
                    Return curvalue
                Else
                    If random Then
                        Dim r As Integer = GenRandomInt(0, stepnum)
                        If curvalue < goalvalue Then
                            If curvalue + r > goalvalue Then
                                Return goalvalue
                            Else
                                Return curvalue + r
                            End If
                        Else
                            If curvalue - r < goalvalue Then
                                Return goalvalue
                            Else
                                Return curvalue - r
                            End If
                        End If
                    Else
                        If curvalue < goalvalue Then
                            If curvalue + stepnum > goalvalue Then
                                Return goalvalue
                            Else
                                Return curvalue + stepnum
                            End If
                        Else
                            If curvalue - stepnum < goalvalue Then
                                Return goalvalue
                            Else
                                Return curvalue - stepnum
                            End If
                        End If
                    End If
                End If
            End Function
        End Class

        Public Class Operators
            Public Function Factorial(ByVal number As Integer) As BigInteger
                If number <= 1 Then
                    Return 0
                Else
                    Return number * Factorial(number - 1)
                End If
            End Function

            ''' <summary>
            ''' Gives the number 0 if the value is negative, returns the value itself if the value is positive
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function SmallestPositiveValueINT(ByVal value As Integer) As Integer
                If value < 0 Then
                    Return 0
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' Gives the number 0 if the value is negative, returns the value itself if the value is positive. Forces operation on a double
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function SmallestPositiveValueDBL(ByVal value As Double) As Double
                If value < 0 Then
                    Return 0
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' Gives the number 0 if the value is positive, returns the value itself if the value is negative.
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function HighestNegativeValueINT(ByVal value As Integer) As Integer
                If value > 0 Then
                    Return 0
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' Gives the number 0 if the value is positive, returns the value itself if the value is negative. Forces operation on a double
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function HighestNegativeValueDBL(ByVal value As Double) As Double
                If value > 0 Then
                    Return 0
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' If the number is greater than max, return max, otherwise returns the value
            ''' </summary>
            ''' <param name="value"></param>
            ''' <param name="Max"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function HighestPositiveValue(ByVal value As Integer, ByVal Max As Integer) As Integer
                If value > Max Then
                    Return Max
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' If the number is greater than max, return max, otherwise returns the value
            ''' </summary>
            ''' <param name="value"></param>
            ''' <param name="Max"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function HighestPositiveValue(ByVal value As Double, ByVal Max As Double) As Double
                If value > Max Then
                    Return Max
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' Returns value is Min Less then Value Less than Max. Return min is value is less than min, return Max is value is greater than Max
            ''' </summary>
            ''' <param name="value"></param>
            ''' <param name="Max"></param>
            ''' <param name="Min"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function ValueContained(ByVal value As Integer, ByVal Max As Integer, ByVal Min As Integer, Optional ByRef IsContained As Boolean = True) As Integer
                If Min > Max Then
                    Throw New GSCoreIncompatibleArgumentsException("Max value must be Greater than Min value")
                    Return Nothing
                End If

                If value < Min Then
                    IsContained = False
                    Return Min
                ElseIf value > Max Then
                    IsContained = False
                    Return Max
                Else
                    Return value
                End If
            End Function

            ''' <summary>
            ''' Returns value is Min Less then Value Less than Max. Return min is value is less than min, return Max is value is greater than Max
            ''' </summary>
            ''' <param name="value"></param>
            ''' <param name="Max"></param>
            ''' <param name="Min"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function ValueContained(ByVal value As Double, ByVal Max As Double, ByVal Min As Double, Optional ByRef IsContained As Boolean = True) As Double
                If Min > Max Then
                    Throw New GSCoreIncompatibleArgumentsException("Max value must be Greater than Min value")
                    Return Nothing
                End If

                If value < Min Then
                    IsContained = False
                    Return Min
                ElseIf value > Max Then
                    IsContained = False
                    Return Max
                Else
                    Return value
                End If
            End Function
        End Class

        Public Class BaseConverter
            'Converts a number in base  to a number in base N. Returns Nothing if the conversion failed. Returns 0 if number is 0 or Nothing
            Public Function ConvertBaseNToTen(ByVal number As String, base As Byte) As String
                If (Not CDbl(number) = 0) And (Not number = Nothing) Then
                    Dim chars As New List(Of Char)
                    Dim nums As New List(Of Byte)
                    Dim num As Byte
                    chars = number.ToString.ToCharArray.ToList
                    For x = 0 To chars.Count - 1
                        If Byte.TryParse(chars(x), num) Then
                            nums.Add(num)
                        Else
                            Return Nothing
                            Exit For
                        End If
                    Next
                    Dim result As Long = 0
                    For y = chars.Count - 1 To 0 Step -1
                        result = CLng(result + (nums((nums.Count - 1) - y) * (base ^ y)))
                    Next
                    Return result.ToString
                Else
                    Return "0"
                End If
            End Function

            ''' <summary>
            ''' Converts base 10 to any base, using a custom alphabet. For premade alphabets use AlphabetType.
            ''' Alphabet type "HEX" gives the hex alphabet (0 to 9 + A to F)
            ''' Alphabet type "DNA" gives the DNA alphabet ({A, C, G, T})
            ''' Alphabet type "ALPHABET" gives all the letters of the English Alphabet (A to Z)
            ''' Submit more alphabet types at SmokeyTheBandicoot/GameShardsCore on GitHub
            ''' </summary>
            ''' <param name="number"></param>
            ''' The number to convert
            ''' <param name="Base"></param>
            ''' Te base which the number should be converted to. Can be any non-negative number
            ''' <param name="Alphabet"></param>
            ''' The characters for the alphabet. To use if the base is greater than 10 (for example, hex alphabet is 0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F) or the number should use a custom alphabet (DNA alphabet is A,C,G,T). Defaults to 0 to 9
            ''' <param name="AlphabetType"></param>
            ''' Use this to use premade alphabets. use "HEX" (string) to indicate HEX alphabet (0-9 A-F), DNA ({A,C,G,T}), Alphabet (A-Z), Full (0-9 A-Z), Else defaults to 0-9.
            ''' <param name="MinDigits"></param>
            ''' Minimum number of digits. for example MinDigits=4 and the result is B3. This will change the result to 00B3 (adding whatever number of the first character of the alphabet to reach the minimum number of digits). Use -1 to disable
            ''' <returns></returns>
            ''' Returns a number that from base 10 is converted to another number (returned as string) converted into another base. Can use multiple customization options
            ''' <remarks></remarks>
            Public Function ConvertBaseTenToN(ByVal number As Double, ByVal Base As Byte, Optional ByVal Alphabet() As Char = Nothing, Optional ByVal AlphabetType As String = "Hex", Optional ByVal MinDigits As Integer = -1) As String
                'Sets the alphabet (presets)
                If Alphabet Is Nothing Then
                    If AlphabetType.ToUpper = "HEX" Then
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F")}
                    ElseIf AlphabetType.ToUpper = "DNA" Then
                        Alphabet = {CChar("A"), CChar("C"), CChar("G"), CChar("T")}
                    ElseIf AlphabetType.ToUpper = "ALPHABET" Then
                        Alphabet = {CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F"), CChar("G"), CChar("H"), CChar("I"), CChar("J"), CChar("K"), CChar("L"), CChar("M"), CChar("N"), CChar("O"), CChar("P"), CChar("Q"), CChar("R"), CChar("S"), CChar("T"), CChar("U"), CChar("V"), CChar("W"), CChar("X"), CChar("Y"), CChar("Z")}
                    ElseIf AlphabetType.ToUpper = "FULL" Then
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F"), CChar("G"), CChar("H"), CChar("I"), CChar("J"), CChar("K"), CChar("L"), CChar("M"), CChar("N"), CChar("O"), CChar("P"), CChar("Q"), CChar("R"), CChar("S"), CChar("T"), CChar("U"), CChar("V"), CChar("W"), CChar("X"), CChar("Y"), CChar("Z")}
                    Else
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9")}
                    End If

                End If

                'Throw custom exception if alphabet.count < Base
                If Alphabet.Count < Base Then
                    Throw New GSCoreIncompatibleArgumentsException("Arguments for the functon ""ConvertBaseTenToN"" are not compatible with each other: Alphabet array length must be greater than or equal to the Base. Alphabet Array Length: " + Alphabet.Count.ToString + ". Base: " + Base.ToString)
                    Return "An error occurred"
                End If

                'Calculate result
                Dim result As String = String.Empty
                Dim placeholder As Double = number

                If number = 0 Then
                    result = Alphabet(0)
                Else
                    Do While (Not placeholder = 0)
                        result &= Alphabet(CInt(placeholder Mod Base))
                        placeholder -= placeholder Mod Base
                        placeholder /= Base 'It is \ and not / operator. / is division, \ is INTEGER division - depreciated. integer division doesn't exist in double. So the / operator is used in conjunction with Truncate function
                        'placeholder = Truncate(placeholder)
                    Loop
                End If

                'Adds mindigits

                If result.Length < MinDigits Then
                    For x As Integer = result.Length + 1 To MinDigits
                        result = result + Alphabet(0).ToString
                    Next
                End If

                'returns the result
                Return StrReverse(result)
            End Function

            ''' <summary>
            ''' Converts base 10 to any base, using a custom alphabet. For premade alphabets use AlphabetType.
            ''' Alphabet type "HEX" gives the hex alphabet (0 to 9 + A to F)
            ''' Alphabet type "DNA" gives the DNA alphabet ({A, C, G, T})
            ''' Alphabet type "ALPHABET" gives all the letters of the English Alphabet (A to Z)
            ''' Submit more alphabet types at SmokeyTheBandicoot/GameShardsCore on GitHub
            ''' </summary>
            ''' <param name="number"></param>
            ''' The number to convert
            ''' <param name="Base"></param>
            ''' Te base which the number should be converted to. Can be any non-negative number
            ''' <param name="Alphabet"></param>
            ''' The characters for the alphabet. To use if the base is greater than 10 (for example, hex alphabet is 0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F) or the number should use a custom alphabet (DNA alphabet is A,C,G,T). Defaults to 0 to 9
            ''' <param name="AlphabetType"></param>
            ''' Use this to use premade alphabets. use "HEX" (string) to indicate HEX alphabet (0-9 A-F), DNA ({A,C,G,T}), Alphabet (A-Z), Full (0-9 A-Z), Else defaults to 0-9.
            ''' <param name="MinDigits"></param>
            ''' Minimum number of digits. for example MinDigits=4 and the result is B3. This will change the result to 00B3 (adding whatever number of the first character of the alphabet to reach the minimum number of digits). Use -1 to disable
            ''' <returns></returns>
            ''' Returns a number that from base 10 is converted to another number (returned as string) converted into another base. Can use multiple customization options
            ''' <remarks></remarks>
            Public Function ConvertBaseTenToN(ByVal number As ULong, ByVal Base As ULong, Optional ByVal Alphabet() As Char = Nothing, Optional ByVal AlphabetType As String = "Hex", Optional ByVal MinDigits As Integer = -1) As String
                'Sets the alphabet (presets)
                If Alphabet Is Nothing Then
                    If AlphabetType.ToUpper = "HEX" Then
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F")}
                    ElseIf AlphabetType.ToUpper = "DNA" Then
                        Alphabet = {CChar("A"), CChar("C"), CChar("G"), CChar("T")}
                    ElseIf AlphabetType.ToUpper = "ALPHABET" Then
                        Alphabet = {CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F"), CChar("G"), CChar("H"), CChar("I"), CChar("J"), CChar("K"), CChar("L"), CChar("M"), CChar("N"), CChar("O"), CChar("P"), CChar("Q"), CChar("R"), CChar("S"), CChar("T"), CChar("U"), CChar("V"), CChar("W"), CChar("X"), CChar("Y"), CChar("Z")}
                    ElseIf AlphabetType.ToUpper = "FULL" Then
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9"), CChar("A"), CChar("B"), CChar("C"), CChar("D"), CChar("E"), CChar("F"), CChar("G"), CChar("H"), CChar("I"), CChar("J"), CChar("K"), CChar("L"), CChar("M"), CChar("N"), CChar("O"), CChar("P"), CChar("Q"), CChar("R"), CChar("S"), CChar("T"), CChar("U"), CChar("V"), CChar("W"), CChar("X"), CChar("Y"), CChar("Z")}
                    Else
                        Alphabet = {CChar("0"), CChar("1"), CChar("2"), CChar("3"), CChar("4"), CChar("5"), CChar("6"), CChar("7"), CChar("8"), CChar("9")}
                    End If

                End If

                'Throw custom exception if alphabet.count < Base
                If Alphabet.Count < Base Then
                    Throw New GSCoreIncompatibleArgumentsException("Arguments for the functon ""ConvertBaseTenToN"" are not compatible with each other: Alphabet array length must be greater than or equal to the Base. Alphabet Array Length: " + Alphabet.Count.ToString + ". Base: " + Base.ToString)
                    Return "An error occurred"
                End If

                'Calculate result
                Dim result As String = String.Empty
                Dim placeholder As Double = number

                If number = 0 Then
                    result = Alphabet(0)
                Else
                    Do While (Not placeholder = 0)
                        result &= Alphabet(CInt(placeholder Mod Base))
                        placeholder -= placeholder Mod Base
                        placeholder /= Base 'It is \ and not / operator. / is division, \ is INTEGER division - depreciated. integer division doesn't exist in double. So the / operator is used in conjunction with Truncate function
                        'placeholder = Truncate(placeholder)
                    Loop
                End If

                'Adds mindigits

                If result.Length < MinDigits Then
                    For x As Integer = result.Length + 1 To MinDigits
                        result = result + Alphabet(0).ToString
                    Next
                End If

                'returns the result
                Return StrReverse(result)
            End Function
        End Class
    End Namespace



    Namespace Converter
        Public Class TemperatureConverter
            Public Function ConvertTemperatureCtoF(ByVal Celsius As Single) As Single
                Return CSng(Celsius * 1.8 + 32)
            End Function
            Public Function ConvertTemperatureCtoK(ByVal Celsius As Single) As Single
                Return CSng(Celsius + 273.15)
            End Function
            Public Function ConvertTemperatureCtoR(ByVal Celsius As Single) As Single
                Return CSng((Celsius + 273.15) * 1.8)
            End Function
            Public Function ConvertTemperatureFtoC(ByVal Fahrenheit As Single) As Single
                Return CSng((Fahrenheit - 32) / 1.8)
            End Function
            Public Function ConvertTemperatureFtoK(ByVal Fahrenheit As Single) As Single
                Return CSng((Fahrenheit + 459.67) * (5 / 9))
            End Function
            Public Function ConvertTemperatureFtoR(ByVal Fahrenheit As Single) As Single
                Return CSng(Fahrenheit + 459.67)
            End Function
            Public Function ConvertTemperatureKtoC(ByVal Kelvin As Single) As Single
                Return CSng(Kelvin - 273.15)
            End Function
            Public Function ConvertTemperatureKtoF(ByVal Kelvin As Single) As Single
                Return CSng(Kelvin * 9 / 5 - 459.67)
            End Function
            Public Function ConvertTemperatureKtoR(ByVal Kelvin As Single) As Single
                Return CSng(Kelvin - 273.15)
            End Function
            Public Function ConvertTemperatureRtoC(ByVal Rankine As Single) As Single
                Return CSng((Rankine - 491.67) * 5 / 9)
            End Function
            Public Function ConvertTemperatureRtoK(ByVal Rankine As Single) As Single
                Return Rankine * 5 / 9
            End Function
            Public Function ConvertTemperatureRtoF(ByVal Rankine As Single) As Single
                Return CSng(Rankine - 459.67)
            End Function
        End Class
    End Namespace

    Namespace Science
        Public Class Genetics
            ''' <summary>
            ''' depreciated. It is recommended to use ConvertBaseTenToN and define a custom alphabet (for DNA it is {"C", "T", "G", "A"} or any order)
            ''' </summary>
            ''' <param name="num"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function ConvertBase4ToDNA(ByVal num As String) As String
                num = num.Replace("0", "A")
                num = num.Replace("1", "C")
                num = num.Replace("2", "G")
                num = num.Replace("3", "T")
                Return num
            End Function

            Public Function ConvertDNAtoBase4(ByVal DNA As String) As String
                DNA = DNA.Replace("A", "0")
                DNA = DNA.Replace("C", "1")
                DNA = DNA.Replace("G", "2")
                DNA = DNA.Replace("T", "3")
                Return DNA
            End Function
        End Class
    End Namespace


    Namespace Strings
        Public Class StringManager
            Public Function ReplaceCharsets(ByVal str As String, ByVal chars1 As Charset, ByVal chars2 As Charset) As String
                If str = "" Or str = String.Empty Or str = Nothing Or chars1.Chars.Count = 0 Or chars2.Chars.Count = 0 Then
                    Return str
                Else
                    For x = 0 To (System.Math.Min((chars1.Chars.Count), (chars2.Chars.Count)) - 1)
                        str = str.Replace(chars1.Chars(x), chars2.Chars(x))
                    Next
                    Return str
                End If

            End Function
        End Class
    End Namespace
End Namespace