Public Class User

    Private _pseudo As String
    Private _id As String

    Public Property Pseudo As String
        Get
            Return _pseudo
        End Get
        Set(value As String)
            _pseudo = value
        End Set
    End Property

    Public Property Id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Sub New(ByVal pseudo As String, ByVal id As String)
        _pseudo = pseudo
        _id = id
    End Sub
End Class
