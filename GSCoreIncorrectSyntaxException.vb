Public Class GSCoreIncorrectSyntaxException
    Inherits Exception

    Public Sub New()
        MyBase.New("[GameShardsCore Exception]: Command or Expression syntax is incorrect.")
    End Sub

    Public Sub New(message As String)
        MyBase.New("[GameShardsCore Exception]: " + message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New("[GameShardsCore Exception]: " + message, inner)
    End Sub
End Class
