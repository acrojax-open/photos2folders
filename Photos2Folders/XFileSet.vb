Option Strict Off

Imports System.Runtime.InteropServices
Imports System.IO

Public Class XFileSet
    Implements IEnumerable(Of XFileInfo)
    Implements IDisposable

    Private AbortScan As Boolean
    Private FileCount As Long
    Private _RootDir As String
    Private eScanType As New ScanType()
    Private FileList As List(Of XFileInfo)
    Private IndexBySHA1 As Hashtable
    Private IndexBySize As Hashtable
    Private IndexByDirectory As Hashtable
    Private HashIndexed As Boolean
    Private ScanNum As Long
    Private FileTypes As List(Of String)
    Private SkipDotFiles As Boolean

    Private WithEvents ProcessingFileInfo As XFileInfo

    Public Event FileHashProgress(lngPosition As Long, lngFileSize As Long)
    Public Event ScanProgress(strPath As String, ScanNumber As Long)
    Public Event SetHashProgress(strFileName As String, lngFileNumber As Long, lngFileCount As Long)

    Private Sub FileInfoHashProgressHandler(lngPosition As Long, lngFileSize As Long) Handles ProcessingFileInfo.HashProgress
        RaiseEvent FileHashProgress(lngPosition, lngFileSize)
    End Sub

    Public Property RootDir() As String
        Get
            Return _RootDir
        End Get
        Set(ByVal value As String)
            _RootDir = value
        End Set
    End Property

    Public Enum ScanType
        Native = 0
        WinApi = 1
    End Enum

    Public Sub SetFileTypesImages()
        FileTypes.Add("png")
        FileTypes.Add("jpg")
        FileTypes.Add("gif")
        FileTypes.Add("tif")
        FileTypes.Add("jpeg")
    End Sub

    Public Delegate Sub FileFound_Delegate(sFileInfo As XFileInfo)

    Sub New()
        Reset()
    End Sub

    Sub New(RootDirectory As String)
        Reset()
        RootDir = RootDirectory
    End Sub

    Public Sub Reset()
        ClearList()
        RootDir = ""
        SkipDotFiles = False
        FileTypes = New List(Of String)
        HashIndexed = False
        eScanType = ScanType.WinApi
    End Sub

    Public Sub SkipDotFilesOn()
        SkipDotFiles = True
    End Sub

    Public Sub ClearList()
        FileCount = 0
        FileList = New List(Of XFileInfo)
        ClearIndexes()
        AbortScan = False
    End Sub

    Public Function getFilePathsList() As List(Of String)
        Dim lstFilePaths As New List(Of String)

        For Each fiItem As XFileInfo In FileList
            lstFilePaths.Add(fiItem.FilePath)
        Next

        Return lstFilePaths
    End Function

    Public Property ScanMethod() As ScanType
        Get
            Return eScanType
        End Get
        Set(ByVal value As ScanType)
            eScanType = value
        End Set
    End Property

    'API Declaration
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Public Shared Function FindFirstFileW(lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATAW) As IntPtr
    End Function

    'API Declaration
    <DllImport("kernel32.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function FindNextFile(hFindFile As IntPtr, ByRef lpFindFileData As WIN32_FIND_DATAW) As Boolean
    End Function

    'API Declaration
    <DllImport("kernel32.dll")> _
    Public Shared Function FindClose(hFindFile As IntPtr) As Boolean
    End Function

    'API Declaration
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Public Structure WIN32_FIND_DATAW
        Public dwFileAttributes As FileAttributes
        Friend ftCreationTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Friend ftLastAccessTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Friend ftLastWriteTime As System.Runtime.InteropServices.ComTypes.FILETIME
        Public nFileSizeHigh As UInteger
        Public nFileSizeLow As UInteger
        Public dwReserved0 As UInteger
        Public dwReserved1 As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public cFileName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> _
        Public cAlternateFileName As String
    End Structure



    ''' <summary>
    ''' Save File Information in CSV Format to Disk
    ''' </summary>
    ''' <param name="TargetFile">CSV File Name to Save File List</param>
    ''' <remarks></remarks>
    Public Sub SaveToDisk(TargetFile As String)
        Dim StrList As New List(Of String)

        If File.Exists(TargetFile) Then
            File.Delete(TargetFile)
        End If

        For i As Int32 = 0 To FileList.Count - 1

            StrList.Add(FileList(i).FileName & "," &
                        FileList(i).FilePath & "," &
                        FileList(i).FileExt & "," &
                        FileList(i).FileSize & "," &
                        FileList(i).FileSHA1Hash & "," &
                        FileList(i).File1024SHA1Hash)

        Next
        File.AppendAllLines(TargetFile, StrList)
    End Sub
    ''' <summary>
    ''' Load File List from Disk
    ''' </summary>
    ''' <param name="SourceFile">CSV File Name to Load File List in Application</param>
    ''' <remarks></remarks>
    Public Sub LoadFromDisk(SourceFile As String)

        Dim strList As String() = File.ReadAllLines(SourceFile)
        Dim Str1 As String()

        FileList.Clear()

        For i As Int32 = 0 To strList.Count - 1

            Str1 = strList(i).Split(",")

            Dim oFileinfo As New XFileInfo()

            oFileinfo.FileName = Str1(0)
            oFileinfo.FileDirectory = Str1(1)
            oFileinfo.FileExt = Str1(2)
            oFileinfo.FileSize = Str1(3)
            oFileinfo.FileSHA1Hash = Str1(4)
            oFileinfo.File1024SHA1Hash = Str1(5)
            FileList.Add(oFileinfo)
        Next
    End Sub

    Public Function isCorrectFileType(fiFile As XFileInfo) As Boolean
        Dim blnRet As Boolean

        If FileTypes.Count > 0 Then
            blnRet = FileTypes.Contains(fiFile.FileExt)
        Else
            blnRet = True
        End If

        Return blnRet
    End Function


    ''' <summary>
    ''' Rescan the File List and Update Infomation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Scan()
        AbortScan = False
        If eScanType = ScanType.Native Then
            FindAllFiles(RootDir)
        ElseIf eScanType = ScanType.WinApi Then
            FindAllFilesWinApi(RootDir)
        End If
        RaiseEvent ScanProgress("Complete", 100)
    End Sub

    Public Sub HashAll()
        Dim strHash As String
        Dim lngFileCount As Long
        Dim lngCurrentFile As Long

        lngFileCount = FileList.Count
        lngCurrentFile = 1

        For Each fiEntry As XFileInfo In FileList
            ProcessingFileInfo = fiEntry
            RaiseEvent SetHashProgress(ProcessingFileInfo.FileName, lngCurrentFile, lngFileCount)
            strHash = ProcessingFileInfo.FileSHA1Hash
            Application.DoEvents()
            lngCurrentFile += 1
        Next
        RaiseEvent SetHashProgress("Complete", 0, 0)
    End Sub

    Public Sub AddFileInfo(fiNew As XFileInfo)
        ' First make sure it's the right kind of file
        If isCorrectFileType(fiNew) Then
            ' Determine if we want to skip files that start with a dot
            If SkipDotFiles = False Or (SkipDotFiles = True And fiNew.FileName.StartsWith(".") = False) Then
                FileCount += 1
                FileList.Add(fiNew)
                ProcessingFileInfo = fiNew
                IndexFileInfo(fiNew)
            End If
        End If
    End Sub

    Private Shared Sub IndexAdd(value As Object, fiItem As XFileInfo, htIndex As Hashtable)
        Dim lstBucket As List(Of XFileInfo)
        If htIndex.Contains(value) Then
            ' We've already indexed something with this value, so we get the
            ' list from the hashtable and add an entry to the existing list
            lstBucket = htIndex(value)
            lstBucket.Add(fiItem)
        Else
            ' Nothing has been indexed with this value so we create a new
            ' list, add the element, and put it in the hash table
            lstBucket = New List(Of XFileInfo)
            lstBucket.Add(fiItem)
            htIndex.Add(value, lstBucket)
        End If
    End Sub

    Private Shared Function IndexContains(value As Object, htIndex As Hashtable) As Boolean
        Return htIndex.Contains(value)
    End Function

    Private Shared Function IndexRetrieve(value As Object, htIndex As Hashtable) As List(Of XFileInfo)
        Dim lstBucket As List(Of XFileInfo)

        If htIndex.Contains(value) Then
            lstBucket = htIndex(value)
        Else
            lstBucket = New List(Of XFileInfo)
        End If

        Return lstBucket
    End Function

    Private Sub ScanStep(strPath As String)
        ScanNum += 1

        If ScanNum Mod 500 = 1 Then
            RaiseEvent ScanProgress(strPath, ScanNum)
        End If
        Application.DoEvents()
    End Sub

    Private Sub FindAllFilesWinApi(directory As String)
        Dim INVALID_HANDLE_VALUE As New IntPtr(-1)
        Dim findData As WIN32_FIND_DATAW
        Dim findHandle As IntPtr = INVALID_HANDLE_VALUE

        findData = New WIN32_FIND_DATAW
        ScanStep(directory)


        Try
            findHandle = FindFirstFileW(directory & "\*", findData)
            If findHandle <> INVALID_HANDLE_VALUE Then

                Do
                    If findData.cFileName = "." OrElse findData.cFileName = ".." Then
                        Continue Do
                    End If

                    Dim strFullPath As String = (directory & (If(directory.EndsWith("\"), "", "\"))) + findData.cFileName

                    Dim isDir As Boolean = False

                    If (findData.dwFileAttributes And FileAttributes.Directory) <> 0 Then
                        isDir = True
                        FindAllFilesWinApi(strFullPath)
                    End If

                    If isDir = False Then

                        Dim fiFound As New XFileInfo()
                        Dim lngFileSize, lngFileSizeHigh, lngFileSizeLow, lngMaxInt As Long

                        ' Convert all the values to longs so we don't overflow
                        lngFileSizeHigh = findData.nFileSizeHigh
                        lngFileSizeLow = findData.nFileSizeLow
                        lngMaxInt = UInteger.MaxValue

                        ' Calculate the file size based on the high/low 32-bit integers representing
                        ' a 64-bit value
                        lngFileSize = (lngFileSizeHigh * lngMaxInt) + lngFileSizeLow

                        fiFound.FileName = findData.cFileName
                        fiFound.FileDirectory = strFullPath.Replace(fiFound.FileName, "")
                        fiFound.FileSize = lngFileSize
                        fiFound.FileExt = XFileInfo.GetFileExtension(strFullPath)

                        ScanStep(directory)

                        AddFileInfo(fiFound)
                    End If

                Loop While FindNextFile(findHandle, findData)
            End If
        Finally
            If findHandle <> INVALID_HANDLE_VALUE Then
                FindClose(findHandle)
            End If
        End Try
    End Sub

    Public Event ScanError(strPath As String, strMessage As String, ByRef bAbort As Boolean)

    Private Sub FindAllFiles(ByRef sSearchPath As String)
        Dim oRootDI As IO.DirectoryInfo
        Dim oFI As IO.FileInfo
        Dim oDI As IO.DirectoryInfo
        Dim oFileInfo As New XFileInfo()

        ScanStep(sSearchPath)

        ' Get info for this path
        Try
            oRootDI = New IO.DirectoryInfo(sSearchPath)

            ' Dont try to scan reparse points
            If Not oRootDI.Attributes.HasFlag(IO.FileAttributes.ReparsePoint) Then

                ' Attempt to get the directories, certain protected folders will not allow this
                Try
                    For Each oDI In oRootDI.GetDirectories
                        ' Recurse into this folder
                        FindAllFiles(oDI.FullName)
                    Next
                Catch ex As Exception
                    RaiseEvent ScanError(sSearchPath, "Unable to enter Folder.  Details : " & ex.Message, AbortScan)
                End Try

                ' Attempt to get the files, certain protected folders will not allow this
                Try
                    For Each oFI In oRootDI.GetFiles
                        oFileInfo = New XFileInfo()

                        oFileInfo.FileName = oFI.Name
                        oFileInfo.FileDirectory = oFI.DirectoryName
                        oFileInfo.FileSize = oFI.Length
                        oFileInfo.FileExt = oFI.Extension.Replace(".", "")

                        AddFileInfo(oFileInfo)

                        ScanStep(sSearchPath)
                    Next

                Catch ex As Exception
                    Dim Err As String
                    Err = ex.ToString()
                End Try
            End If

        Catch ex As Exception
            RaiseEvent ScanError(sSearchPath, "Could not scan files.  Reason : " & ex.Message, AbortScan)
        End Try

        oRootDI = Nothing
    End Sub


    Private Shared Function ConvertStringToByteArray(data As String) As Byte()
        Return (New System.Text.UnicodeEncoding()).GetBytes(data)
    End Function

    Private Sub IndexFileInfo(fiIndexMe As XFileInfo)
        If HashIndexed Then
            IndexAdd(fiIndexMe.FileSHA1Hash.ToUpper, fiIndexMe, IndexBySHA1)
        End If

        IndexAdd(fiIndexMe.FileSize, fiIndexMe, IndexBySize)
        IndexAdd(fiIndexMe.FileDirectory, fiIndexMe, IndexByDirectory)
    End Sub

    Private Sub ClearIndexes()
        IndexBySHA1 = New Hashtable
        IndexBySize = New Hashtable
        IndexByDirectory = New Hashtable
    End Sub

    Private Sub ReIndexAll()
        ClearIndexes()
        For Each fiItem As XFileInfo In FileList
            IndexFileInfo(fiItem)
        Next
    End Sub

    Public Sub HashIndexOn()
        HashIndexed = True
        ReIndexAll()
    End Sub

    Public Sub HashIndexOff()
        HashIndexed = False
        ClearIndexes()
    End Sub

    Public Function ToDataTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("FileName")
        dt.Columns.Add("FileSize", GetType(Long))
        dt.Columns.Add("FilePath")
        dt.Columns.Add("FileExt")
        dt.Columns.Add("FileSHA1Hash")
        dt.Columns.Add("File1024SHA1Hash")

        For i As Int32 = 0 To FileList.Count - 1
            dt.Rows.Add(New Object() {FileList(i).FileName, FileList(i).FileSize, FileList(i).FilePath, FileList(i).FileExt, FileList(i).FileSHA1Hash, FileList(i).File1024SHA1Hash})
        Next
        Return (dt)
    End Function

    Private Shared Function RemoveTrailingSlash(strPath As String)
        Dim strReturn As String
        If strPath.EndsWith("\") Then
            strReturn = strPath.Substring(0, strPath.Length - 1)
        Else
            strReturn = strPath
        End If
        Return strReturn
    End Function

    Public Function getFileInfoByDirectory(strDirectory As String) As List(Of XFileInfo)
        Dim lstReturn As List(Of XFileInfo)
        Dim strIndex As String

        strIndex = RemoveTrailingSlash(strDirectory.ToLower)

        lstReturn = IndexRetrieve(strIndex, IndexByDirectory)

        Return lstReturn
    End Function

    Public Function getFileInfoBySize(lngFileSize As Long) As List(Of XFileInfo)
        Dim lstReturn As List(Of XFileInfo)

        lstReturn = IndexRetrieve(lngFileSize, IndexBySize)

        Return lstReturn
    End Function

    Public Function getFileInfoBySHA1(strSHA1 As String) As List(Of XFileInfo)
        Dim lstReturn As List(Of XFileInfo)

        lstReturn = IndexRetrieve(strSHA1.ToUpper, IndexBySHA1)

        Return lstReturn
    End Function

    Public Function CheckForDuplicate(fiCheck As XFileInfo) As Boolean
        Dim lstSameSize As List(Of XFileInfo)
        Dim blnRet As Boolean

        blnRet = False

        lstSameSize = getFileInfoBySize(fiCheck.FileSize)

        For Each fiCurrent As XFileInfo In lstSameSize
            If fiCurrent.File1024SHA1Hash = fiCheck.File1024SHA1Hash Then
                If fiCurrent.FileSHA1Hash = fiCheck.FileSHA1Hash Then
                    blnRet = True
                End If
            End If
        Next

        Return blnRet
    End Function

#Region "IEnumerable Support"
    Public Function getEnumerator() As IEnumerator(Of XFileInfo) Implements IEnumerable(Of XFileInfo).GetEnumerator
        Return FileList.GetEnumerator
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
                ' Dispose managed objects
                FileList.Clear()
                FileList = Nothing
            End If
            ' Dispose unmanaged objects
            ' No unmanaged objects at the moment
        End If
        Me.disposedValue = True
    End Sub

    ' Keeping this here in case it is needed later
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
