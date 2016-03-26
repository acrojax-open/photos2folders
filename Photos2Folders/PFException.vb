Public Class PFException
    Inherits Exception

    Public Enum eType
        InternalError = 1
        UserInputError = 2
        IOError = 3
        ParseError = 4
    End Enum

    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property

    Private _Type As eType
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    Public Sub New(strMessage As String, strCode As String, petType As eType)
        MyBase.New(strMessage)
        Code = strCode
        Type = petType
    End Sub
End Class
