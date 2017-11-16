Public Class Documentation
    Private Sub TreeView1_AfterSelect(sender As Object, e As Windows.Forms.MouseEventArgs) Handles TreeView1.MouseClick
        Select Case TreeView1.SelectedNode.Index
            Case 0
                t.Text = "Overview:
Name = " + My.Application.Info.ProductName + "
Full name  = " + My.Application.Info.ProductName + " " + My.Application.Info.Description.ToString + " 
Version = " + My.Application.Info.Version.ToString + " 
Dev state = " + My.Application.Info.Description + " 
Framework target = 4.6.1 or superior
CopyRight = " + My.Application.Info.Copyright + " 
Credits = " + My.Application.Info.CompanyName + " 
License = " + My.Application.Info.Trademark + " 
Code = Visible Source
Repository = https://github.com/SmokeyTheBandicoot/GameShardsCore"

            Case 36
                t.Text = "GSRegEx GROUP syntax: 

$[X1-X2]            Evaluates groups of chars.     
for example ""$[A-K]"" means every letter from A to K. $[1-7] means every char number from 1 to 7. X1 and X2 are chars

${X1-X2}            Evaluates groups of numbers.   
for example ""$[1-60]"" means every number from 1 to 60.
for example ""$[01-60]"" means every number from 01 to 60. 

NOTE: Use ! in groups to negate or exclude extremes

for example ""l$[!l]"" will match ""slam"" but not ""call"" (because of the double l. It will look for a ""l"" not followed by another ""l"" char)
for example ""m$[!n-!r]"" will match every word which contains a ""m"" followed by a char that is not a letter from N to R (N and R excluded)
for example ""f$![a-z]"" will match every word which does not contain lower case any letter

NOTE: GROUPS CANNOT CONTAIN * OR $ CHARS!"

            Case 37
                t.Text = "GSRegEx FUNCTION syntax:

$Matches(Str)       Exact match. 
for example ""$Matches(hello)"" only matches the string ""hello"", not "" hello"", ""hello guys"" or ""hello.""

$ContainsW(Str)     Matches the string if it contains Str. A word is a string that finisces with a space, a period or a newline char
for example ""$ContainsW(""hello"")"" matches ""hello"", "" hello"", ""hello."" but not ""sayhello""

$StartsWith(Str)    Mathces the string if it starts with Str. This means that Str must be at the start or the string
for example ""$StartsWith(""hello"")"" mathces ""hello guys"", ""helloguys"" but not ""hi, hello guys""

$StartsWithW(Str)   Mathces the string if it starts with Str after a space. This means it will match any word that starts with Str
for example ""$StartsWithW(""hello"")"" mathces ""hello guys"", ""helloguys"", ""hi, hello guys"" but not ""hi,hello guys""

$EndsWith(Str)      Mathces the string if it ends with Str. This means that Str must be at the end or the string
for example ""$EndsWith(""guys"")"" mathces ""hello guys"", ""helloguys"" but not ""hi, hello guys.""

$EndsWithW(Str)      Mathces the string if it ends with a space before Str. This means that Str must be the last word of the string
for example ""$EndsWithW(""guys"")"" mathces ""hello guys"", ""guys"" but not ""helloguys""

$MinLen(Int)         Matches all entries which contain at least MinLen characters

$MinWLen(Int)        Matches all entries which contain at least one word with at least MinLen characters

$MaxLen(Int)         Matches all entries which contain at most MaxLen characters

$MaxWLen(Int)        Matches all entries which contain at least one word with at most MaxLen characters

NOTE: use ! to negate. 
for example ""$!EndsWith(Str)"" matches all entries whose last word doesn't end with Str



--------Logic Operators

$Not EX1            Evaluates an expression and returns all strings that did not match it

$! EX1              Same as $Not

EX1 $And EX2        Evaluates two expressions and intersects the results. It will return the strings that match both expressions

EX1 $& EX2          Same as $And

EX1 $Or EX2         Evaluates two expressions and returns the strings that matched AT LEAST one of the expressions

EX1 $/EX2          Same as $Or

EX1 $XOr EX2       Evaluates two expressions and returns the strings that matched ONLY ONE expression, not both

EX1 $# EX2          Same as $XOr


--------Unknowns:   

*                   Puts every SINGLE ASCII char in place of ONE every *
for example ""a*c"" will give results for ""abc"", ""acc"", ""a1c"", and every char that can stay in place of the *
for example ""a**c"" gives out any combination matching the char ""a"", followed by 2 any chars, and followed by ""c"" (""a1kc"", ""a22c"", etc)

$?[X1-X2]            Puts from X1 to X2 times any ASCII character.
for example ""a?[1-3]c"" matches ""abc"", ""abkc"", ""a123c""

$%[Char-X1-X2]       Puts from X1 to X2 times the char ""Char""
for example ""a%[K-0-4]c"" matches ""ac"", ""aKc"", ""aKKc"", ""aKKKc"", ""aKKKKc"" but not ""aKKKKKc""



NOTES:

$ AND * ARE RESERVED CHARS: * AND ? WON?T BE REPLACED BY $ INSTANCES TO AVOID RECURSION AND ERRORS/UNINTENDED BEHAVIOUR!!!.

You can use shortcuts to represent classes of chars:

:alphab:
:digit:
:alphnum:
:symb:
:upper:
:lower:
:esadigit:"


            Case Else
                t.Text = ""
        End Select
    End Sub
End Class