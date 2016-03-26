Public Class PhotoFolder
    Private SubFolderNameIndex As Hashtable
    Private SubFolders As List(Of PhotoFolder)

    Private _FolderName As String
    Public Property FolderName() As String
        Get
            Return _FolderName
        End Get
        Set(ByVal value As String)
            _FolderName = value
        End Set
    End Property

    Private _ParentFolderString As String
    Public Property ParentFolderPath() As String
        Get
            If hasParentFolderObject() Then
                Return _ParentFolderObject.FolderPath
            Else
                Return _ParentFolderString
            End If
        End Get
        Set(ByVal value As String)
            _ParentFolderString = value
            _ParentFolderObject = Nothing
        End Set
    End Property

    Private _ParentFolderObject As PhotoFolder
    Public Property NewProperty() As PhotoFolder
        Get
            If hasParentFolderObject() = False Then
                Throw New Exception("Internal Error: Folder has no parent object")
            End If
            Return _ParentFolderObject
        End Get
        Set(ByVal value As PhotoFolder)
            _ParentFolderObject = value
            _ParentFolderString = ""
        End Set
    End Property

    Public ReadOnly Property FolderPath() As String
        Get
            Return ParentFolderPath & "\" & FolderName
        End Get
    End Property

    Private Shared Function RemoveTrailingSlash(strPath As String)
        Dim strReturn As String
        If strPath.EndsWith("\") Then
            strReturn = strPath.Substring(0, strPath.Length - 1)
        Else
            strReturn = strPath
        End If
        Return strReturn
    End Function

    Private Function hasParentFolderObject() As Boolean
        If _ParentFolderObject Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub AddFolder(pfSubfolder As PhotoFolder)
        SubFolders.Add(pfSubfolder)
        SubFolderNameIndex.Add(pfSubfolder.FolderName.ToLower, pfSubfolder)
    End Sub


End Class
