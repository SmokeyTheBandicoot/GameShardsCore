Imports System.Drawing

Public Class SimpleRectangle
    Public _rect As Rectangle

    Public Sub New(ByVal rectangle As Rectangle)
        Rect = rectangle
    End Sub

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Checks if the rectangle is a square
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsSquare() As Boolean
        Get
            If rect.Width = rect.Height Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


    ''' <summary>
    ''' returns the area of the rectangle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Area() As Integer
        Get
            Return rect.Width * rect.Height
        End Get
    End Property

    ''' <summary>
    ''' returns the ratio between width and height (W/H)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Ratio() As Double
        Get
            Return rect.Width / rect.Height
        End Get
    End Property

    Public Property Rect() As Rectangle
        Get
            Return _rect
        End Get
        Set(value As Rectangle)
            _rect = value
        End Set
    End Property
End Class
