Imports GameShardsCore

Public Class IOExtended
    Dim GBase As New GameShardsCore.Charset
    ''' <summary>
    ''' Renames a file (for example: Rename("C:\\GameShardsSoftware\dummy.pdf", "test.pdf"), will rename the file "dummy.pdf" in "C:\\GameShardsSoftware" to "test.pdf")
    ''' </summary>
    ''' <param name="OldPath"></param>
    ''' Full file path (for example: C:\\GameShardsSoftware\dummy.pdf)
    ''' <param name="NewName"></param>
    ''' <remarks></remarks>
    Public Sub FileRename(ByVal OldPath As String, ByVal NewName As String)
        If Not IO.File.Exists(OldPath) Then
            Throw New IO.FileNotFoundException
            Exit Sub
        End If

        For x = 0 To GBase.ReservedChars.Count - 1
            If NewName.Contains(GBase.ReservedChars(x)) Then
                Throw New InvalidOperationException("OldPath or NewName contain invalid (reserved) chars. For a list of reserved chars please refer to BaseGameShardsCoreBETA.ReservedChars")
                Exit Sub
            End If
        Next

        Dim tmp() As String = Split(OldPath, "\")
        ReDim Preserve tmp(tmp.Count - 2)
        Rename(OldPath, String.Join("\", tmp) + "\" + NewName)
    End Sub


    ''' <summary>
    ''' [WIP] -doesn't do nothing
    ''' </summary>
    ''' <param name="OldPath"></param>
    ''' <param name="NewName"></param>
    ''' <remarks></remarks>
    Public Sub FileFullRename(ByVal OldPath As String, ByVal NewName As String)

    End Sub

    ''' <summary>
    ''' [WIP] -doesn't do nothing
    ''' </summary>
    ''' <param name="File1"></param>
    ''' <param name="File2"></param>
    ''' <param name="TempPath"></param>
    ''' <param name="TempPathIsFolder"></param>
    ''' <remarks></remarks>
    Public Sub FileSwapName(ByVal File1 As String, ByVal File2 As String, Optional ByVal TempPath As String = "C:\\GameShardsSoftware\Temp", Optional ByVal TempPathIsFolder As Boolean = True)
        If Not IO.File.Exists(File1) OrElse Not IO.File.Exists(File2) Then
            Throw New IO.FileNotFoundException("At least one between File1 and File2 does not exist")
            Exit Sub
        End If

        If TempPathIsFolder Then
            TempPath &= Split(File1, "\").Last
        End If


    End Sub

End Class
