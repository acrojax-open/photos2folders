Imports System.Globalization
Imports System.IO


Public Class ImageFunctions
    Public Shared Function getDateCreated(strImagePath As String) As DateTime
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

    ''' <summary>
    ''' Return the "date taken" meta tag from the image
    ''' </summary>
    ''' <param name="strImagePath">Filename of the image</param>
    ''' <returns>Date taken</returns>
    ''' <remarks></remarks>
    Public Shared Function getDateTaken(ByVal strImagePath As String) As DateTime
        Dim DateTakenPropertyNumber As Integer = 36867
        Dim ciProvider As CultureInfo = CultureInfo.InvariantCulture
        Dim dteReturnDate As DateTime
        Dim strDateTaken As String
        Dim imgCurrent As Image = Nothing
        Dim fs As FileStream = Nothing
        Dim dteFailed As DateTime

        dteFailed = DateTime.ParseExact("1900-12-25 12:00:00", "yyyy-MM-dd HH:mm:ss", ciProvider)

        Try
            fs = New FileStream(strImagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            'Get image from file path
            imgCurrent = Image.FromStream(fs)

            'Get date taken based on PropertyItem
            strDateTaken = System.Text.Encoding.ASCII.GetString(imgCurrent.GetPropertyItem(DateTakenPropertyNumber).Value)

            ' Parse the string date to a date type
            dteReturnDate = DateTime.ParseExact(strDateTaken.Substring(0, 19), "yyyy:MM:dd HH:mm:ss", ciProvider)

            ' Make sure the date is not older than 1900 (probably not correct)
            If dteReturnDate < dteFailed Then
                Throw New Exception("Date in date taken tag appears too old to be valid")
            End If
        Catch ex As Exception
            dteReturnDate = dteFailed
        Finally
            If imgCurrent IsNot Nothing Then
                imgCurrent.Dispose()
            End If
            If fs IsNot Nothing Then
                fs.Close()
            End If
        End Try
        Return dteReturnDate
    End Function

    Public Shared Function getDateTakenOrCreated(strImagePath As String) As DateTime
        Dim dteReturn As DateTime

        dteReturn = ImageFunctions.getDateTaken(strImagePath)

        If dteReturn.Year = 1900 Then
            dteReturn = ImageFunctions.getDateCreated(strImagePath)
        End If

        Return dteReturn
    End Function

    Public Shared Function ZeroTime(dteZero As Date) As Date
        Dim dteReturn As Date

        dteReturn = DateTime.ParseExact(dteZero.ToString("MM dd yyyy") & " 0:0:0", "MM dd yyyy H:m:s", CultureInfo.InvariantCulture)

        Return dteReturn
    End Function

End Class
