Public Class Salon
    Private _nom As String
    Private _id As String
    Private _users As List(Of User)

    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            _nom = value
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

    Public Property Users As List(Of User)
        Get
            Return _users
        End Get
        Set(value As List(Of User))
            _users = value
        End Set
    End Property

    Sub New(ByVal nom As String, ByVal id As String)
        _nom = nom
        _id = id
    End Sub
End Class
