Public Class Charset
    Private _Chars As List(Of Char)
    Public Property Chars() As List(Of Char)
        Get
            Return _Chars
        End Get
        Set(value As List(Of Char))
            _Chars = value
        End Set
    End Property
End Class
