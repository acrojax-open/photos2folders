Public Class frmFinished

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub


    Private Sub cmdStartAgain_Click(sender As Object, e As EventArgs) Handles cmdStartAgain.Click
        frmStart.Show()
        Me.Close()
    End Sub

    Private Sub lblDone_Click(sender As Object, e As EventArgs) Handles lblDone.Click

    End Sub
End Class