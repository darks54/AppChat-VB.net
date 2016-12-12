Imports System.Net

Public Class User

    Private _pseudo As String
    Private _id As String
    Private _ip As IPAddress


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

    Public Property Ip As IPAddress
        Get
            Return _ip
        End Get
        Set(value As IPAddress)
            _ip = value
        End Set
    End Property

    Sub New(ByVal pseudo As String, ByVal id As String, ByVal ip As IPAddress)
        _pseudo = pseudo
        _id = id
        _ip = ip
    End Sub
End Class
