Imports System.IO
Imports System.Globalization

Public Class XPhotoFile
    Private fiCurrent As XFileInfo
    Private Const THUMBNAIL_DATA As Integer = 20507

    Public Property FileName As String
        Get
            Return fiCurrent.FileName
        End Get
        Set(ByVal value As String)
            fiCurrent.FileName = value
        End Set
    End Property

    Public ReadOnly Property FilePath As String
        Get
            Return fiCurrent.FilePath
        End Get
    End Property

    Private _PhotoDate As DateTime
    Public Property PhotoDate As DateTime
        Get
            If _PhotoDate.Year = 1900 Then
                fetchPhotoDate()
            End If
            Return _PhotoDate
        End Get
        Set(ByVal value As DateTime)
            _PhotoDate = value
        End Set
    End Property

    Private _ThumbnailImage As Image = Nothing
    Public Property Thumbnail As Image
        Get
            Return _ThumbnailImage
        End Get
        Set(ByVal value As Image)
            _ThumbnailImage = value
        End Set
    End Property

    Private _FetchingThumbnail As Boolean = False
    Public Property FetchingThumbnail As Boolean
        Get
            Return _FetchingThumbnail
        End Get
        Set(ByVal value As Boolean)
            _FetchingThumbnail = value
        End Set
    End Property

    Private _ThumbnailRectangle As New Rectangle(0, 0, 1, 1)
    Public Property Bounds As Rectangle
        Get
            Return _ThumbnailRectangle
        End Get
        Set(ByVal value As Rectangle)
            _ThumbnailRectangle = value
        End Set
    End Property

    Public Property DuplicateFlag() As String
        Get
            Return fiCurrent.DuplicateFlag
        End Get
        Set(ByVal value As String)
            fiCurrent.DuplicateFlag = value
        End Set
    End Property

    Private _DestLevel1 As String
    Public Property DestLevel1() As String
        Get
            Return _DestLevel1
        End Get
        Set(ByVal value As String)
            _DestLevel1 = value
        End Set
    End Property

    Private _DestLevel2 As String
    Public Property DestLevel2() As String
        Get
            Return _DestLevel2
        End Get
        Set(ByVal value As String)
            _DestLevel2 = value
        End Set
    End Property

    Private _DestLevel3 As String
    Public Property DestLevel3() As String
        Get
            Return _DestLevel3
        End Get
        Set(ByVal value As String)
            _DestLevel3 = value
        End Set
    End Property

    Private _DestLevel4 As String
    Public Property DestLevel4() As String
        Get
            Return _DestLevel4
        End Get
        Set(ByVal value As String)
            _DestLevel4 = value
        End Set
    End Property

    Public Function getThumbnailCaption() As String
        Dim strReturn As String = FileName

        Return strReturn
    End Function

    Private Sub Initialize()
        PhotoDate = DateTime.ParseExact("1900-12-25 12:00:00", "yyyy-MM-dd HH:mm:ss", Nothing)
    End Sub

    Private Function ImageToThumbnail(strImagePath As String) As Image
        Dim imgThumb As Image
        Dim intThumbHeight, intThumbWidth, intScale As Integer

        intScale = 200

        Dim funcCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

        Try

            Using imgFull As Image = Image.FromFile(strImagePath)

                If imgFull.Width > imgFull.Height Then
                    intThumbWidth = intScale
                    intThumbHeight = (imgFull.Height / imgFull.Width) * intScale
                Else
                    intThumbHeight = intScale
                    intThumbWidth = (imgFull.Width / imgFull.Height) * intScale
                End If

                imgThumb = imgFull.GetThumbnailImage(intThumbWidth, intThumbHeight, funcCallback, IntPtr.Zero)
            End Using
        Catch ex As Exception
            imgThumb = CType(My.Resources.ResourceManager.GetObject("no_image"), Image)
        End Try

        Return (imgThumb)
    End Function

    ' Used by the thumbnail generator code
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function


    Public Sub fetchThumbnail()
        If FetchingThumbnail = False Then
            FetchingThumbnail = True
            Thumbnail = ImageToThumbnail(FilePath)
        End If
    End Sub

    Public Shared Function fetchUInt16(bReader As BinaryReader, blnSwapByteOrder As Boolean)
        Dim intRet As UInt16

        intRet = bReader.ReadUInt16()
        If blnSwapByteOrder Then
            intRet = (intRet << 8) + (intRet >> 8)
        End If

        Return intRet
    End Function

    Public Shared Sub validateUInt16(bReader As BinaryReader, intExpected As UInt16, blnSwapByteOrder As Boolean, strError As String)
        If fetchUInt16(bReader, blnSwapByteOrder) <> intExpected Then
            Throw New PFException("Error parsing file. " & strError & ".", "BINARY_PARSE_FAIL", PFException.eType.ParseError)
        End If
    End Sub

    Public Shared Function fetchUInt32(bReader As BinaryReader, blnSwapByteOrder As Boolean) As UInt32
        Dim intRet As UInt32

        intRet = bReader.ReadUInt32()
        If blnSwapByteOrder Then
            intRet = ((intRet And &HFF) << 24) + ((intRet And &HFF00) << 8) + ((intRet And &HFF0000) >> 8) + ((intRet And &HFF000000) >> 24)
        End If

        Return intRet
    End Function

    ' Function to parse a JPG file header and extract tag data as a string
    Public Shared Function fetchJPGHeaderTag(strPath As String, intTagNumber As UInt16) As String
        Dim intOffset As Integer
        Dim intNextSection As UInt32
        Dim intSectionSize As UInt16
        Dim intNumTags As UInt16
        Dim bytArray(4096) As Byte
        Dim i As UInt32
        Dim intTagID As UInt16
        Dim intTagDataType As UInt16
        Dim intComponentCount As UInt32
        Dim intTempBig As UInt32
        Dim lngFileSize As Long
        Dim blnSwapByteOrder As Boolean = True
        Dim tagRecords As Hashtable
        Dim strTemp As String
        Dim strParts As String()
        Dim strReturn As String

        strReturn = ""

        Using fStream As FileStream = File.Open(strPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Using bReader As New BinaryReader(fStream)
                lngFileSize = bReader.BaseStream.Length - 4
                Try
                    ' Retrieve and validate the header for the image
                    validateUInt16(bReader, &HFFD8, blnSwapByteOrder, "First two bytes are not valid for JPG")
                    validateUInt16(bReader, &HFFE1, blnSwapByteOrder, "APP1 marker not found")
                    intSectionSize = fetchUInt16(bReader, blnSwapByteOrder)
                    validateUInt16(bReader, &H4578, blnSwapByteOrder, "Exif marker not found (part 1)")
                    validateUInt16(bReader, &H6966, blnSwapByteOrder, "Exif marker not found (part 2)")
                    validateUInt16(bReader, 0, blnSwapByteOrder, "Exif marker zero bytes not found")
                    If fetchUInt16(bReader, blnSwapByteOrder) = &H4949 Then
                        blnSwapByteOrder = False
                    End If
                    validateUInt16(bReader, &H2A, blnSwapByteOrder, "Exif TIFF start marker not found")
                    intOffset = 8
                    ' Get the offset for the main IFD
                    intNextSection = fetchUInt32(bReader, blnSwapByteOrder)

                    ' Move to the main IFD
                    While intOffset < intNextSection
                        bReader.ReadByte()
                        intOffset += 1
                    End While

                    intNumTags = fetchUInt16(bReader, blnSwapByteOrder)
                    intOffset += 2
                    i = 0

                    ' Loop through the main IFD records until finding the 0x8769 tag which gives us the
                    ' offset to the Exif Sub IFD
                    While i < intNumTags
                        intTagID = fetchUInt16(bReader, blnSwapByteOrder)
                        intTagDataType = fetchUInt16(bReader, blnSwapByteOrder)
                        If intTagID = &H8769 Then
                            intComponentCount = fetchUInt32(bReader, blnSwapByteOrder)
                            intNextSection = fetchUInt32(bReader, blnSwapByteOrder)
                        Else
                            intTempBig = fetchUInt32(bReader, blnSwapByteOrder)
                            intTempBig = fetchUInt32(bReader, blnSwapByteOrder)
                        End If
                        intOffset += 12
                        i += 1
                    End While

                    ' Move to the Exif Sub IFD
                    While intOffset < intNextSection
                        bReader.ReadByte()
                        intOffset += 1
                    End While

                    ' Get the number of Exif tags
                    intNumTags = fetchUInt16(bReader, blnSwapByteOrder)
                    intOffset += 2
                    i = 0

                    'Initialize the hashtable holding the tags
                    tagRecords = New Hashtable

                    ' Loop through the Exif Sub IFD tags and record their types, sizes, and offsets
                    While i < intNumTags
                        intTagID = fetchUInt16(bReader, blnSwapByteOrder)
                        intTagDataType = fetchUInt16(bReader, blnSwapByteOrder)
                        intComponentCount = fetchUInt32(bReader, blnSwapByteOrder)
                        intNextSection = fetchUInt32(bReader, blnSwapByteOrder)
                        tagRecords("TAG" & intTagID.ToString("X")) = intTagDataType & ":" & intComponentCount & ":" & intNextSection
                        intOffset += 12
                        i += 1
                    End While

                    ' Get the requested tag info
                    If tagRecords.Contains("TAG" & intTagNumber.ToString("X")) Then
                        strTemp = tagRecords("TAG" & intTagNumber.ToString("X"))
                        strParts = strTemp.Split(New Char() {":"c})
                        intTagDataType = UInt16.Parse(strParts(0))
                        intComponentCount = UInt32.Parse(strParts(1))
                        intNextSection = UInt32.Parse(strParts(2))

                        ' Move to the location of the date string
                        While intOffset < intNextSection
                            bReader.ReadByte()
                            intOffset += 1
                        End While

                        ' Parse the data depending on the tag type
                        If (intTagDataType = 2) Then
                            i = 0
                            strTemp = ""

                            ' Get the characters
                            While i < intComponentCount
                                strTemp = strTemp & Chr(bReader.ReadByte())
                                intOffset += 1
                                i += 1
                            End While

                            strReturn = strTemp
                        End If
                    End If
                Catch ex As Exception
                    strReturn = ""
                End Try
            End Using
        End Using
        Return strReturn
    End Function

    Public Sub fetchPhotoDate()
        Dim dteRet As DateTime

        dteRet = fetchDateTaken()
        If dteRet.Year = 1900 Then
            dteRet = fetchDateCreated(FilePath)
        End If

        PhotoDate = dteRet
    End Sub

    Public Function fetchDateTaken() As DateTime
        Dim dteFailed As DateTime
        Dim ciProvider As CultureInfo = CultureInfo.InvariantCulture
        Dim dteReturnDate As DateTime
        Dim strDateTaken As String

        dteFailed = DateTime.ParseExact("1900-12-25 12:00:00", "yyyy-MM-dd HH:mm:ss", ciProvider)

        Try
            ' Get the JPG header 9003 which is the date taken tag
            strDateTaken = fetchJPGHeaderTag(FilePath, &H9003)

            If strDateTaken <> "" Then
                ' Parse the string date to a date type
                dteReturnDate = DateTime.ParseExact(strDateTaken.Substring(0, 19), "yyyy:MM:dd HH:mm:ss", ciProvider)
            Else
                dteReturnDate = dteFailed
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            dteReturnDate = dteFailed
        End Try

        Return dteReturnDate
    End Function

    Public Shared Function fetchDateCreated(strImagePath As String) As DateTime
        Dim dteDateCreated As DateTime
        Dim fiFile As FileInfo

        Try
            fiFile = New FileInfo(strImagePath)
            dteDateCreated = fiFile.CreationTime
            fiFile = Nothing
        Catch ex As Exception
            dteDateCreated = DateTime.Today
        End Try

        Return dteDateCreated
    End Function

    Public Sub New(fiNew As XFileInfo)
        Initialize()
        fiCurrent = fiNew
    End Sub

End Class
