Imports System.Math
Public Class DateManager
    'You give an hour (for example 16,5 that is 4:30PM), and converts it in the number of minutes that have passed since then, for example 850 minutes
    Public Function GetMinutesFromHour(ByVal Hour As Single) As Single
        Dim t As New TimeSpan(CInt(Hour), 0, 0)
        Return CSng(t.TotalMinutes)
    End Function

    'You give a date (for example 1/6/2016 at 15:30) and it gives the number of hour that have passed in the last day in minutes (for example 15,5 hours, that means that have passed 930 minutes in the last day)
    Public Function GetHourFromDate(ByVal datetoconvert As Date, Optional ByVal KeepTrackOfSeconds As Boolean = False) As Single
        If KeepTrackOfSeconds Then
            Return CSng(((datetoconvert.Hour) + (datetoconvert.Minute / 60) + (datetoconvert.Second / 3600)))
        Else
            Return CSng(((datetoconvert.Hour) + (datetoconvert.Minute / 60)))
        End If
    End Function

    'You give a date and it returns how many minutes have passed since the start of the last day
    Public Function GetMinutesInDay(ByVal datetoconvert As Date) As Single
        Dim t As New TimeSpan(datetoconvert.Hour, datetoconvert.Minute, datetoconvert.Second)
        'MsgBox(String.Format("{0} {1} {2} {3} {4}", t.TotalMinutes, t.Hours, t.Minutes, t.Seconds, datetoconvert.ToString))
        Return CSng(t.TotalMinutes)
    End Function

    Public Function ConvertDecimalHourToMinuteHour(ByVal DecimalHour As Single) As TimeSpan
        Return New TimeSpan(CInt(Truncate(CInt(DecimalHour))), CInt(((DecimalHour - Truncate(DecimalHour)) * 0.6 * 100)), 0)
    End Function
End Class
