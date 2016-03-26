Public Class frmProgressBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        AddHandler MainSorter.ProgressFileSet, AddressOf MainSorter_ProgressFileSet
        AddHandler MainSorter.ProgressMessage, AddressOf MainSorter_ProgressMessage

    End Sub

    Private Function ToPercentage(lngAmount As Long, lngTotal As Long) As Integer
        Dim intRet As Integer
        If lngTotal = 0 Then
            intRet = 100
        Else
            intRet = (lngAmount / lngTotal) * 100
        End If
        Return intRet
    End Function

    Private Sub MainSorter_ProgressFileSet(lngCount As Long, lngTotal As Long)
        pgsSet.Value = ToPercentage(lngCount, lngTotal)
    End Sub

    Private Sub MainSorter_ProgressMessage(strMessage As String)
        lblJobStatus.Text = strMessage
        Application.DoEvents()
    End Sub

    Private Sub frmProgressBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class