Public Class XPhotoSet
    Implements IEnumerable(Of XPhotoFile)

    Private FileList As List(Of XPhotoFile)

    Public Sub New()
        FileList = New List(Of XPhotoFile)()
    End Sub

    Public Sub addPhotoFile(pfNew As XPhotoFile)
        FileList.Add(pfNew)
    End Sub

    Public Sub addFileInfo(fiNew As XFileInfo)
        Dim pfNew As XPhotoFile
        pfNew = New XPhotoFile(fiNew)
        addPhotoFile(pfNew)
    End Sub

    Public Sub loadFileSet(fsFiles As XFileSet)
        Dim pfNew As XPhotoFile

        For Each fiFile As XFileInfo In fsFiles
            pfNew = New XPhotoFile(fiFile)
            addPhotoFile(pfNew)
        Next

    End Sub

    Public Function getPhotoCount() As Integer
        Return FileList.Count
    End Function

#Region "Support for IEnumerable"
    Public Function GetEnumerator() As IEnumerator(Of XPhotoFile) Implements IEnumerable(Of XPhotoFile).GetEnumerator
        Return FileList.GetEnumerator
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function
#End Region

End Class
