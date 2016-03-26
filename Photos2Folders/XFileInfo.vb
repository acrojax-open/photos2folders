Imports System.IO

Public Class XFileInfo
    Private _FileName As String
    Private _FileSize As Long
    Private _FileDirectory As String
    Private _FileExt As String
    Private _FileSHA1Hash As String
    Private _File1024SHA1Hash As String
    Private WithEvents CurrentFileStream As MonitoredFileStream

    Public Event HashProgress(lngPosition As Long, lngFileSize As Long)

    Public Sub CurrentFileStream_UpdateProgress(lngPosition As Long, lngFileSize As Long) Handles CurrentFileStream.UpdateProgress
        RaiseEvent HashProgress(lngPosition, lngFileSize)

    End Sub

    Public Sub New()
        Reset()
    End Sub

    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            If _FileName <> value Then
                ResetFileProperties()
            End If
            _FileName = value
        End Set
    End Property

    Private _DuplicateFlag As Boolean
    Public Property DuplicateFlag() As Boolean
        Get
            Return _DuplicateFlag
        End Get
        Set(ByVal value As Boolean)
            _DuplicateFlag = value
        End Set
    End Property


    Public Property File1024SHA1Hash() As String
        Get
            If _File1024SHA1Hash = "" Then
                _File1024SHA1Hash = Get1024SHA1Hash(FilePath)
            End If
            Return _File1024SHA1Hash
        End Get
        Set(ByVal value As String)
            _File1024SHA1Hash = value
        End Set
    End Property

    Public Property FileSHA1Hash() As String
        Get
            If _FileSHA1Hash = "" Then
                CurrentFileStream = GetFileStream_ReadOnly(FilePath)
                _FileSHA1Hash = GetSHA1HashFromStream(CurrentFileStream)
                RaiseEvent HashProgress(CurrentFileStream.Length, CurrentFileStream.Length)
                CurrentFileStream.Close()
            End If
            Return _FileSHA1Hash
        End Get
        Set(ByVal value As String)
            _FileSHA1Hash = value
        End Set
    End Property

    Public Property FileExt() As String
        Get
            If _FileExt = "" Then
                _FileExt = GetFileExtension(FilePath).ToLower
            End If
            Return _FileExt
        End Get
        Set(ByVal value As String)
            _FileExt = value.ToLower
        End Set
    End Property

    Public Property FileSize() As Long
        Get
            Return _FileSize
        End Get
        Set(ByVal value As Long)
            _FileSize = value
        End Set
    End Property

    Public Property FileDirectory() As String
        Get
            Return _FileDirectory
        End Get
        Set(ByVal value As String)
            If Right(value, 1) = "\" Then
                value = Left(value, Len(value) - 1)
            End If
            If _FileDirectory <> value Then
                ResetFileProperties()
            End If
            _FileDirectory = value
        End Set
    End Property

    Public ReadOnly Property FilePath() As String
        Get
            Dim strFullPath As String
            strFullPath = Me.FileDirectory & "\" & Me.FileName
            Return strFullPath
        End Get
    End Property

    Public Shared Function GetFileExtension(strFilePath As String) As String
        Dim oFileInfo1 As New System.IO.FileInfo(strFilePath)
        Dim strExtension

        strExtension = oFileInfo1.Extension.Replace(".", "")

        Return strExtension
    End Function

    Public Shared Function GetFileSize(strFilePath As String) As Long
        Dim oFileInfo1 As New System.IO.FileInfo(strFilePath)
        Dim strExtension

        strExtension = oFileInfo1.Extension.Replace(".", "")

        Return strExtension
    End Function

    Public Sub Reset()
        _FileName = ""
        _FileDirectory = ""
        ResetFileProperties()
    End Sub

    Public Sub ResetFileProperties()
        _FileSHA1Hash = ""
        _File1024SHA1Hash = ""
        _FileExt = ""
        _FileSize = 0
    End Sub

    Private Shared Function GetFileStream_ReadOnly(strFilePath) As MonitoredFileStream
        Return (New MonitoredFileStream(strFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
    End Function

    Public Shared Function GetSHA1Hash(strPath As String) As String
        Dim strHash As String
        Dim oFileStream As MonitoredFileStream

        oFileStream = GetFileStream_ReadOnly(strPath)
        strHash = GetSHA1HashFromStream(oFileStream)
        oFileStream.Close()

        Return strHash
    End Function

    Public Shared Function GetSHA1HashFromStream(oFileStream As MonitoredFileStream) As String
        Dim strResult As String = ""
        Dim strHashData As String = ""

        Dim arrbytHashValue As Byte()

        Dim oSHA1Hasher As New System.Security.Cryptography.SHA1CryptoServiceProvider()

        Try
            arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream)
            strHashData = System.BitConverter.ToString(arrbytHashValue)
            strHashData = strHashData.Replace("-", "")
            strResult = strHashData

        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK,
                                                 System.Windows.Forms.MessageBoxIcon.[Error],
                                                 System.Windows.Forms.MessageBoxDefaultButton.Button1)
        End Try

        Return (strResult)
    End Function

    Public Shared Function Get1024SHA1Hash(strFilePath As String) As String

        Dim oBytes(1024) As Byte

        Dim oStream As FileStream = GetFileStream_ReadOnly(strFilePath)
        oStream.Read(oBytes, 0, 1024)

        Dim strResult As String = ""
        Dim strHashData As String = ""

        Dim arrbytHashValue As Byte()

        Dim oSHA1Hasher As New System.Security.Cryptography.SHA1CryptoServiceProvider()

        Try
            arrbytHashValue = oSHA1Hasher.ComputeHash(oBytes)

            strHashData = System.BitConverter.ToString(arrbytHashValue)
            strHashData = strHashData.Replace("-", "")
            strResult = strHashData

        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK,
                                                 System.Windows.Forms.MessageBoxIcon.[Error],
                                                 System.Windows.Forms.MessageBoxDefaultButton.Button1)
        End Try

        Return (strResult)

    End Function

End Class
