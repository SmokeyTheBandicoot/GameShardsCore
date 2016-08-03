Imports System.Drawing
Imports System.Math

Public Class OldVector2D
    Dim _Xcomponent As Single
    Dim _YComponent As Single
    Dim _VectorModule As Single
    Dim _Angle As Single

    Public Sub New(ByVal Lenght As Double, ByVal angle As Single)
        Me.XComponent = CSng(Lenght * Cos(angle))
        Me.YComponent = CSng(Lenght * Sin(angle))
    End Sub

    Public Sub New(ByVal Lenght As Long, ByVal angle As Single)
        Me.XComponent = CSng(Lenght * Cos(angle))
        Me.YComponent = CSng(Lenght * Sin(angle))
    End Sub

    Public Sub New(ByVal XComponent As Double, ByVal YComponent As Double)
        Me.Angle = GetAngle(CSng(YComponent), CSng(XComponent))
        Me.VectorModule = CSng(Sqrt(XComponent ^ 2 + YComponent ^ 2))
    End Sub

    Public Property XComponent As Single
        Get
            Return _Xcomponent
        End Get
        Set(value As Single)
            _Xcomponent = value
            _VectorModule = CSng(Sqrt(_Xcomponent ^ 2 + _YComponent ^ 2))
            _Angle = GetAngle(YComponent, XComponent)
        End Set
    End Property

    Public Property YComponent() As Single
        Get
            Return _YComponent
        End Get
        Set(value As Single)
            _YComponent = value
            _VectorModule = CSng(Sqrt(_Xcomponent ^ 2 + _YComponent ^ 2))
            _Angle = GetAngle(YComponent, XComponent)
        End Set
    End Property

    Public Property VectorModule() As Single
        Get
            Return _VectorModule
        End Get
        Set(value As Single)
            _VectorModule = value
            _Xcomponent = CSng(_VectorModule * Cos(_Angle))
            _YComponent = CSng(_VectorModule * Sin(_Angle))
        End Set
    End Property

    Public Property Angle() As Single
        Get
            Return _Angle
        End Get
        Set(value As Single)
            _Angle = value
            _Xcomponent = CSng(_VectorModule * Cos(_Angle))
            _YComponent = CSng(_VectorModule * Sin(_Angle))
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("Module: {0}. Angle: {1}. X: {2}. Y: {3}", VectorModule, Angle, XComponent, YComponent)
    End Function

    Public Function GetAngle(ByVal x As Single, ByVal y As Single) As Single
        If x > 0 Then
            If y > 0 Then
                'primo quadrante 
                Return CSng(Atan(y / x))
            Else
                'quarto quadrante
                Return CSng(Atan(y / x) - PI / 2)
            End If
        Else
            If y > 0 Then
                'secondo quadrante
                Return CSng(Atan(y / x) + PI / 2)
            Else
                'terzo quadrante
                Return CSng(Atan(y / x) + PI)
            End If
        End If
    End Function
End Class
