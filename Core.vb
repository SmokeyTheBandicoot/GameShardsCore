Imports System.Diagnostics

Public Class Core

    ''' <summary>
    ''' Gives information about this library's version
    ''' </summary>
    ''' <remarks></remarks>
    Public Version As String = My.Application.Info.Version.ToString

    ''' <summary>
    ''' Gives information about this library's name
    ''' </summary>
    ''' <remarks></remarks>
    Public AssemblyName As String = My.Application.Info.AssemblyName

    ''' <summary>
    ''' Gives information about this library's Framework version
    ''' </summary>
    ''' <remarks></remarks>
    Public FrameWorkVersion As String = "4.0"


    Private _ChangeLog As String

    ''' <summary>
    ''' Returns true when the application (sender) has already an instance funning on this machine
    ''' </summary>
    ''' <param name="sender"></param>
    ''' The application to check. For the application who calls this function should always be "System.Diagnostics.Process.GetCurrentProcess.ProcessName"
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckIfAlreadyRunning(ByVal sender As String) As Boolean
        Return (UBound(Process.GetProcessesByName(sender)) > 0)
    End Function



    Public Property Changelog() As String
        Get
            Return _ChangeLog
        End Get
        Set(value As String)
            _ChangeLog = value
        End Set
    End Property

    Public Function GetDependencies() As List(Of String)
        Dim Dependencies As New List(Of String)

        Dependencies.Add("<Dependent>, <Dependency>")
        Dependencies.Add("DeskTopMagician, GameShardsCore")
        Dependencies.Add("DeskTopMagician, IconExLibrary")
        Dependencies.Add("DeskTopMagician, IconExtractor")
        Dependencies.Add("EvolutionSimulator, GameShardsCore")
        Dependencies.Add("GSCalculator, GameShardsCore")
        Dependencies.Add("ApproxEquationResolutor, GameShardsCore")
        Dependencies.Add("ApproxEquationResolutor, NCalcLib")
        Dependencies.Add("BiT-Test, GameShardsCore")

        Return Dependencies
    End Function

    Public Function GetUsedMethods() As List(Of String)
        Dim UsedSubs As New List(Of String)

        UsedSubs.Add("DeskTopMagician, ConvertBaseTenToN")
        UsedSubs.Add("DeskTopMagician, ExtendedControls.PictureBoxExt")
        UsedSubs.Add("DeskTopMagician, IncompatibleArgumentsException")
        UsedSubs.Add("EvolutionSimulator, DateManager")
        UsedSubs.Add("EvolutionSimulator, Console")
        UsedSubs.Add("EvolutionSimulator, DateManager")
        UsedSubs.Add("GSCalculator, NthRoot")
        UsedSubs.Add("BiT-Test, AccountManager")

        Return UsedSubs
    End Function
End Class
