

Public Class XPhotoSetClassification
    Private _AssignedDate As Date
    Public Property AssignedDate() As Date
        Get
            Return _AssignedDate
        End Get
        Set(ByVal value As Date)
            _AssignedDate = value
        End Set
    End Property

    Private _LevelSet As XLevelSet
    Public Property LevelSet() As XLevelSet
        Get
            Return _LevelSet
        End Get
        Set(ByVal value As XLevelSet)
            _LevelSet = value
        End Set
    End Property

    Private Const MAX_LEVELS As Integer = 5
    Private MainPhotoSet As XPhotoSet
    Private AssignedLevels() As String

    Public Sub New()
        MainPhotoSet = New XPhotoSet()
        AssignedLevels = New String(MAX_LEVELS) {}
    End Sub

    Public Function hasAssignedLevels() As Boolean
        Dim blnRet As Boolean
        Dim i As Integer

        blnRet = False
        i = 1
        While i < MAX_LEVELS
            If AssignedLevels(i) <> "" Then
                blnRet = True
            End If
            i += 1
        End While

        Return blnRet
    End Function

    Public Function isMissingLevel() As Boolean
        Dim blnRet As Boolean
        Dim i As Integer
        Dim intMaxDepth As Integer

        intMaxDepth = AppOptions.getLevelDepth
        blnRet = False
        i = 1

        While i <= intMaxDepth
            If AssignedLevels(i) = "" Then
                blnRet = True
            End If
            i += 1
        End While

        Return blnRet
    End Function

    Public Sub dateToLevels()
        Dim dteCurrent As Date
        Dim i As Integer
        Dim strLevelType As String
        Dim strLevelName As String

        dteCurrent = AssignedDate
        i = 1
        While i < MAX_LEVELS
            strLevelType = AppOptions.getOption(AppOptions.getLevelOptionName(i))
            strLevelName = MainSorter.LevelFolderName(strLevelType, dteCurrent, "")

            If strLevelName <> "" Then
                setAssignedLevel(i, strLevelName)
            End If

            i += 1
        End While

    End Sub

    Public Sub setAssignedLevel(intLevelNum As Integer, strLevelName As String)
        If intLevelNum < 0 Or intLevelNum > 5 Then
            Throw New PFException("Invalid level number specified", "INVALID_LEVEL_NUM", PFException.eType.InternalError)
        End If
        AssignedLevels(intLevelNum) = strLevelName
    End Sub

    Public Function getAssignedLevel(intLevelNum As Integer) As String
        If intLevelNum < 0 Or intLevelNum > 5 Then
            Throw New PFException("Invalid level number specified", "INVALID_LEVEL_NUM", PFException.eType.InternalError)
        End If
        Return AssignedLevels(intLevelNum)
    End Function

    Public Sub addFileInfo(fiAdd As XFileInfo)
        MainPhotoSet.addFileInfo(fiAdd)
    End Sub

    Public Sub addPhotoFile(pfAdd As XPhotoFile)
        MainPhotoSet.addPhotoFile(pfAdd)
    End Sub

    Public Function getPhotoSet() As XPhotoSet
        Return MainPhotoSet
    End Function

    Public Function getPhotoCount() As Integer
        Return MainPhotoSet.getPhotoCount()
    End Function



End Class
