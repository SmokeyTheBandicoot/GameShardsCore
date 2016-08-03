Public Class GSCoreIncompatibleArgumentsException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New("[GameShardsCore Exception]: " + message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New("[GameShardsCore Exception]: " + message, inner)
    End Sub
End Class
