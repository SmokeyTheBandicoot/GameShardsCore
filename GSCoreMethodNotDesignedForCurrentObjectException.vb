Public Class GSCoreMethodNotDesignedForCurrentObjectException
    Inherits Exception

    Public Sub New()
        MyBase.New("[GameShardsCore Exception]: The called procedure or function is inherited from a class or implemented from an interface for another class, and has no function in the current class (object)")
    End Sub

    Public Sub New(message As String)
        MyBase.New("[GameShardsCore Exception]: " + message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New("[GameShardsCore Exception]: " + message, inner)
    End Sub
End Class
