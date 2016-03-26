Imports System.IO

Public Class FolderBuilder
    Private Classifications As XFileGrouper
    Private CurrentPhotoNum As Long
    Private TotalPhotos As Long

    Public Event FileSetProgress(lngItem As Long, lngTotal As Long)
    Public Event ProgressMessage(strMessage As String)

    Public Sub setClassifications(newClassifications As XFileGrouper)
        Classifications = newClassifications
    End Sub

    Public Sub Start()
        ValidateFolders()
        performBuild()
    End Sub

    Private Sub performBuild()
        CurrentPhotoNum = 1
        TotalPhotos = Classifications.getSourcePhotoSetCount
        For Each pscCurrent As XPhotoSetClassification In Classifications
            processPSC(pscCurrent)
        Next

    End Sub

    Private Sub processPSC(pscCurrent As XPhotoSetClassification)
        Dim intLevelDepth As Integer
        Dim i As Integer
        Dim strCurrentPath As String
        Dim strCurrentFolder As String
        Dim psPhotoSet As XPhotoSet

        intLevelDepth = AppOptions.getLevelDepth()
        strCurrentPath = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_DEST)

        i = 1
        While i <= intLevelDepth
            strCurrentFolder = pscCurrent.getAssignedLevel(i)
            If strCurrentFolder <> "" Then
                strCurrentPath = strCurrentPath & "\" & strCurrentFolder
            Else
                Throw New PFException("Empty folder name found while processing", "EMPTY_FOLDER_NAME", PFException.eType.InternalError)
            End If
            i += 1
        End While

        ' Create the folder if it doesn't exist
        CreateFolder(strCurrentPath)

        ' Get the set of photos we are copying
        psPhotoSet = pscCurrent.getPhotoSet

        ' Copy/move the photos to the new folders
        copyPhotos(psPhotoSet, strCurrentPath)

    End Sub

    Private Sub copyPhotos(psList As XPhotoSet, strDestination As String)
        Dim strSourceFilePath As String
        Dim strDestFilePath As String
        Dim strDestFolderPath As String
        Dim strAction As String
        Dim dlgError As dlgFileError
        Dim drResult As DialogResult
        Dim i As Integer
        Dim blnRetry As Boolean

        strAction = "copy"

        ' Loop through all files
        For Each pCurrent As XPhotoFile In psList
            ' Raise an event to update the progress bar
            RaiseEvent FileSetProgress(CurrentPhotoNum, TotalPhotos)
            CurrentPhotoNum += 1
            strSourceFilePath = pCurrent.FilePath

            ' Check if this file is a duplicate. If it is, take the apprpriate action based on the
            ' application settings.
            If pCurrent.DuplicateFlag = True Then
                Select Case AppOptions.getOption(ApplicationOptions.OPT_DUPLICATE_ACTION)
                    Case ApplicationOptions.DUPLICATE_ACTION_COPY_ANYWAYS
                        strDestFolderPath = strDestination
                    Case ApplicationOptions.DUPLICATE_ACTION_COPY_TO_DUP_FOLDER
                        strDestFolderPath = AppOptions.getDuplicateFolder
                        Try
                            CreateFolder(strDestFolderPath)
                        Catch ex As Exception
                            Throw New PFException("Failed to create 'Duplicates' folder.  Make sure you have permission and try again.", "FAILED_CREATE_DUP_FOLDER", PFException.eType.IOError)
                        End Try
                    Case ApplicationOptions.DUPLICATE_ACTION_SKIP
                        strDestFolderPath = ""
                    Case Else
                        Throw New PFException("Invalid duplicate file action found (" &
                                              AppOptions.getOption(ApplicationOptions.OPT_DUPLICATE_ACTION) & ")",
                                              "INVALID_DUP_ACTION", PFException.eType.InternalError)
                End Select
            Else
                strDestFolderPath = strDestination
            End If

            ' Check if we are skipping this file
            If strDestFolderPath <> "" Then
                ' Build the destination file path
                strDestFilePath = strDestFolderPath & "\" & pCurrent.FileName

                ' Check if the file already exists, if so create a new name by appending a 
                ' number to the end until we find a file name that does not exist
                i = 1
                While File.Exists(strDestFilePath)
                    strDestFilePath = strDestFolderPath & "\" & addNumberToFilename(pCurrent.FileName, i)
                    i += 1
                End While

                blnretry = True
                While blnRetry
                    Try
                        ' Check if we are moving or copying and do the appropriate action
                        If AppOptions.getOptionBoolean(ApplicationOptions.OPT_MOVE_FILES) = False Then
                            strAction = "copy"
                            copyFile(strSourceFilePath, strDestFilePath)
                        Else
                            strAction = "move"
                            moveFile(strSourceFilePath, strDestFilePath)
                        End If
                        blnRetry = False
                    Catch ex As Exception
                        dlgError = New dlgFileError()
                        dlgError.setMessage("Uh oh! There seems to be a problem accessing the photo '" & pCurrent.FileName & "'. " &
                        "The system returned the following error when trying to " & strAction & " this file." & vbCr & vbCr &
                        ex.Message & vbCr & vbCr &
                        "How would you like to proceed?", "Problem trying to " & strAction & " photo")
                        drResult = dlgError.ShowDialog()
                        Select drResult
                            Case DialogResult.Abort
                                Throw New PFException("The organizing process has been cancelled. We recommend closing the application and starting again to avoid any duplicate photos being copied.", "PROCESS_CANCELLED", PFException.eType.UserInputError)
                                Exit For
                            Case DialogResult.Ignore
                                blnRetry = False
                            Case DialogResult.Retry
                                blnRetry = True
                            Case Else
                                Throw New PFException("Invalid dialog result returned in file error handler", "INVALID_DIALOG", PFException.eType.InternalError)
                        End Select
                    End Try
                End While
            End If
        Next

    End Sub

    Private Sub CreateFolder(strPath As String)
        If Directory.Exists(strPath) = False Then
            Directory.CreateDirectory(strPath)
        End If
    End Sub

    Private Sub copyFile(strSource As String, strDest As String)
        File.Copy(strSource, strDest)
    End Sub

    Private Sub moveFile(strSource As String, strDest As String)
        File.Move(strSource, strDest)
    End Sub

    Private Function addNumberToFilename(strFilename As String, intFileNum As Integer)
        Dim strFileParts() As String
        Dim strRetFile As String

        strFileParts = strFilename.Split(New Char() {"."c})

        strRetFile = ""

        For Each strPart As String In strFileParts
            If strRetFile = "" Then
                strRetFile = strPart & "_" & intFileNum
            Else
                strRetFile = strRetFile & "." & strPart
            End If
        Next

        Return strRetFile
    End Function

    Private Sub ValidateFolders()
        For Each pscCurrent As XPhotoSetClassification In Classifications
            If pscCurrent.isMissingLevel Then
                Throw New PFException("One or more photo sets do not have a folder assigned.  Click through all groups and assign a folder before clicking 'Done Sorting'.", "MISSING_FOLDER", PFException.eType.UserInputError)
            End If
        Next
    End Sub


End Class
