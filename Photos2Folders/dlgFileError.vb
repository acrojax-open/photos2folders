Public Class dlgFileError

    Public Sub setMessage(strMessage As String, strWindowTitle As String)
        lblMessage.Text = strMessage
        Me.Text = strWindowTitle
        resizeForm()
    End Sub

    Private Sub resizeForm()
        Me.Height = lblMessage.Height + (cmdTryAgain.Height * 2)
        cmdTryAgain.Top = lblMessage.Top + lblMessage.Height + (cmdTryAgain.Height / 2)
        cmdSkip.Top = lblMessage.Top + lblMessage.Height + (cmdSkip.Height / 2)
        cmdStop.Top = lblMessage.Top + lblMessage.Height + (cmdStop.Height / 2)
    End Sub

    Private Sub cmdSkip_Click(sender As Object, e As EventArgs) Handles cmdSkip.Click
        Me.DialogResult = Windows.Forms.DialogResult.Ignore
    End Sub

    Private Sub cmdTryAgain_Click(sender As Object, e As EventArgs) Handles cmdTryAgain.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
    End Sub

    Private Sub dlgFileError_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class