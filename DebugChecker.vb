Public Class DebugChecker

    'Provides methods to check is DebugMode is active. May expand this class to include more (generic integer/double, ecc changes)

    Public _DebugMode As Boolean
    Public Event ValueChanged(ByVal value As Boolean)
    Public Event ValueUnchanged(ByVal value As Boolean)
    Public Event ValueSet(ByVal value As Boolean)
    Public Event ValueRequest(ByVal value As ValueType)

    ''' <summary>
    ''' Initializes a start value without raising any event
    ''' </summary>
    ''' <param name="startValue"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal startValue As Boolean)
        _DebugMode = startValue
    End Sub

    ''' <summary>
    ''' sets the value of DebugMode
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DebugMode() As Boolean
        Get
            Return _DebugMode
            RaiseEvent ValueRequest(_DebugMode)
        End Get
        Set(value As Boolean)
            If _DebugMode = value Then
                RaiseEvent ValueUnchanged(_DebugMode)
            Else
                RaiseEvent ValueChanged(_DebugMode)
            End If
            _DebugMode = value
            RaiseEvent ValueSet(_DebugMode)
        End Set
    End Property

End Class
