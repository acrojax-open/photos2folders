Public Class XErrorLogEntry
    Private _LogDate As Date
    Public Property LogDate() As Date
        Get
            Return _LogDate
        End Get
        Set(ByVal value As Date)
            _LogDate = value
        End Set
    End Property

    Private _Message As String
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property

    Private _MoreDetail As String
    Public Property MoreDetail() As String
        Get
            Return _MoreDetail
        End Get
        Set(ByVal value As String)
            _MoreDetail = value
        End Set
    End Property

    Public ReadOnly Property LogDateString() As String
        Get
            Return _LogDate.ToShortDateString
        End Get
    End Property


    Public ReadOnly Property FulLText() As String
        Get
            Return LogDate
        End Get
    End Property


End Class
