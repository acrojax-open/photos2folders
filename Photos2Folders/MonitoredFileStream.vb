Public Class MonitoredFileStream
    Inherits System.IO.FileStream

    Private nextUpdate As Long
    Private lastUpdate As Long
    Private lastDoEvents As Long
    Private UpdateSize As Long
    Private BigUpdateSize As Long
    Private OneMB As Long

    Public Event UpdateProgress(lngPosition As Long, lngFileSize As Long)

    Sub New(strFilePath As String, fMode As System.IO.FileMode, fAccess As System.IO.FileAccess, fSharing As System.IO.FileShare)
        MyBase.New(strFilePath, fMode, fAccess, fSharing)
        Init()
    End Sub

    Sub New(strFilePath As String, fMode As System.IO.FileMode, fAccess As System.IO.FileAccess)
        MyBase.New(strFilePath, fMode, fAccess)
        Init()
    End Sub

    Private Sub Init()
        nextUpdate = 0L
        lastUpdate = 0L
        OneMB = 1024L * 1024L
        UpdateSize = OneMB * 2
        BigUpdateSize = UpdateSize * 10
    End Sub

    Public Overrides Function ReadByte() As Integer
        CheckProgress()
        Return MyBase.ReadByte()
    End Function

    Public Overrides Function Read(array() As Byte, offset As Integer, count As Integer) As Integer
        CheckProgress()
        Return MyBase.Read(array, offset, count)
    End Function

    Private Sub CheckProgress()
        Try
            If MyBase.Position > nextUpdate Or MyBase.Position < lastUpdate Then
                If MyBase.Length > UpdateSize Then
                    RaiseEvent UpdateProgress(MyBase.Position, MyBase.Length)
                    If (MyBase.Length / 24L) > UpdateSize Then
                        nextUpdate = MyBase.Position + BigUpdateSize
                    Else
                        nextUpdate = MyBase.Position + UpdateSize
                    End If
                    lastUpdate = MyBase.Position
                    lastDoEvents = MyBase.Position
                    Application.DoEvents()
                End If
            End If
            If (lastDoEvents + UpdateSize) < MyBase.Position Then
                lastDoEvents = MyBase.Position
                Application.DoEvents()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
