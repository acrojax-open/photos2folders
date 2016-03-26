Public Class XLevelSet
    Private LevelNames As String()
    Private Const MAX_LEVELS As Integer = 10

    Private Sub New()
        LevelNames = New String(MAX_LEVELS) {}
    End Sub

    Public Sub setLevelName(intLevelNumber As Integer, strLevelName As String)
        If intLevelNumber < MAX_LEVELS Then
            LevelNames(intLevelNumber) = strLevelName
        Else
            Throw New PFException("Invalid level number specified when setting level name", "INVALID_LEVEL_NUMBER", PFException.eType.InternalError)
        End If
    End Sub

    Public Function getLevelName(intLevelNumber) As String
        Dim strRet As String

        If intLevelNumber < MAX_LEVELS Then
            strRet = LevelNames(intLevelNumber)
        Else
            Throw New PFException("Invalid level number specified when getting level name", "INVALID_LEVEL_NUMBER", PFException.eType.InternalError)
        End If
        Return strRet
    End Function

End Class
