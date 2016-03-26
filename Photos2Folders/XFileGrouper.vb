

Public Class XFileGrouper
    Implements IEnumerable(Of XPhotoSetClassification)
    Implements IDisposable

    Private CurrentIndex As Integer
    Private FSCGroups As List(Of XPhotoSetClassification)
    Private FSCGroupsByDate As Hashtable

    Public Event GroupingProgress(strFile As String, lngCurrent As Long, lngTotal As Long)

    Private GroupBy As GrouperMethod
    Public Enum GrouperMethod
        ByDate = 1
    End Enum

    Private _OptionByYear As Boolean
    Public Property OptionByYear() As Boolean
        Get
            Return _OptionByYear
        End Get
        Set(ByVal value As Boolean)
            _OptionByYear = value
        End Set
    End Property

    Private _OptionByMonth As Boolean
    Public Property OptionByMonth() As Boolean
        Get
            Return _OptionByMonth
        End Get
        Set(ByVal value As Boolean)
            _OptionByMonth = value
        End Set
    End Property

    Private _OptionByDay As Boolean
    Public Property OptionByDay() As Boolean
        Get
            Return _OptionByDay
        End Get
        Set(ByVal value As Boolean)
            _OptionByDay = value
        End Set
    End Property

    Private SourcePhotoFiles As XPhotoSet

    Public Sub New()
        GroupBy = GrouperMethod.ByDate
    End Sub

    Public Sub setSourcePhotoSet(psSet As XPhotoSet)
        SourcePhotoFiles = psSet
    End Sub

    Public Function getSourcePhotoSetCount() As Integer
        Return SourcePhotoFiles.getPhotoCount
    End Function

    Private Sub ClearGroups()
        If FSCGroups Is Nothing Then
            FSCGroups = New List(Of XPhotoSetClassification)
            FSCGroupsByDate = New Hashtable
        Else
            FSCGroups.Clear()
            FSCGroupsByDate.Clear()
        End If
    End Sub

    Private Sub AddPhotoFileToDateGroup(ByVal dteDate As DateTime, pfAdd As XPhotoFile)
        Dim fscCurrent As XPhotoSetClassification

        dteDate = ImageFunctions.ZeroTime(dteDate)

        If FSCGroupsByDate.Contains(dteDate) Then
            fscCurrent = FSCGroupsByDate(dteDate)
        Else
            fscCurrent = New XPhotoSetClassification()
            fscCurrent.AssignedDate = dteDate
            FSCGroupsByDate.Add(dteDate, fscCurrent)
            FSCGroups.Add(fscCurrent)
        End If

        fscCurrent.addPhotoFile(pfAdd)

    End Sub

    Public Sub Process()
        Dim dteImageDate As Date
        Dim i As Long

        ClearGroups()

        i = 0

        If SourcePhotoFiles IsNot Nothing Then
            If GroupBy = GrouperMethod.ByDate Then
                For Each pfCurrent As XPhotoFile In SourcePhotoFiles
                    'frmMain.Label2.Text = "Getting date..."
                    'Application.DoEvents()
                    RaiseEvent GroupingProgress(pfCurrent.FileName, i, SourcePhotoFiles.Count)
                    dteImageDate = pfCurrent.PhotoDate
                    AddPhotoFileToDateGroup(dteImageDate, pfCurrent)
                    i += 1
                Next
                RaiseEvent GroupingProgress("Complete", 0, 0)
                SortByDate()
            Else
                Throw New PFException("Invalid group by method specified for grouper object", "INVALID_GROUP_BY", PFException.eType.InternalError)
            End If
        Else
            Throw New PFException("Attempt to process prior to setting source file set", "OUT_OF_ORDER_CALLS", PFException.eType.InternalError)
        End If
    End Sub

    Private Sub SortByDate()
        Dim compFSC As New FSCByDateComparer()
        FSCGroups.Sort(compFSC)
    End Sub

#Region "IEnumerable Support"
    Public Function getEnumerator() As IEnumerator(Of XPhotoSetClassification) Implements IEnumerable(Of XPhotoSetClassification).GetEnumerator
        Return FSCGroups.GetEnumerator
    End Function

    Public Function getEnumeratorGeneric() As IEnumerator Implements IEnumerable.GetEnumerator
        Return getEnumerator()
    End Function
#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                FSCGroups.Clear()
                FSCGroups = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "FSCByDateComparer Class"
    Private Class FSCByDateComparer
        Implements IComparer(Of XPhotoSetClassification)

        Public Function Compare(x As XPhotoSetClassification, y As XPhotoSetClassification) As Integer Implements IComparer(Of XPhotoSetClassification).Compare
            Return y.AssignedDate.CompareTo(x.AssignedDate)
        End Function
    End Class
#End Region

End Class


