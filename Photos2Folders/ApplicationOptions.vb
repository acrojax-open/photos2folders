Imports System.Globalization
Imports Microsoft.Win32

Public Class ApplicationOptions

#Region "Option Constants"
    Public Const OPT_FOLDER_LEVEL_1 As String = "FolderLevel1"
    Public Const OPT_FOLDER_LEVEL_2 As String = "FolderLevel2"
    Public Const OPT_FOLDER_LEVEL_3 As String = "FolderLevel3"
    Public Const OPT_FOLDER_LEVEL_4 As String = "FolderLevel4"

    Public Const OPT_IGNORE_DOT_FILES As String = "IgnoreDotFiles"
    Public Const OPT_USE_DATE_TAKEN As String = "UseDateTaken"
    Public Const OPT_DUPLICATE_ACTION As String = "DuplicateFileAction"
    Public Const OPT_MOVE_FILES As String = "MoveFiles"

    Public Const OPT_FOLDER_SOURCE As String = "FolderSource"
    Public Const OPT_FOLDER_DEST As String = "FolderDest"

    Public Const FOLDER_LEVEL_YEAR As String = "Year"
    Public Const FOLDER_LEVEL_MONTH As String = "Month"
    Public Const FOLDER_LEVEL_EVENT As String = "Event Name"
    Public Const FOLDER_LEVEL_DAY As String = "Day"
    Public Const FOLDER_LEVEL_NONE As String = "(None)"

    Public Const DUPLICATE_ACTION_COPY_ANYWAYS = "0"
    Public Const DUPLICATE_ACTION_COPY_TO_DUP_FOLDER = "1"
    Public Const DUPLICATE_ACTION_SKIP = "2"

#End Region

    Private OptionList As Dictionary(Of String, String)
    Private AllLists As Dictionary(Of String, List(Of String))

#Region "Singleton Implementation"
    Private Shared _Instance As ApplicationOptions
    Private Shared ReadOnly _InstanceLock As Object = New Object()

    Public Shared ReadOnly Property Instance() As ApplicationOptions
        Get
            SyncLock _InstanceLock
                If (_Instance Is Nothing) Then
                    _Instance = New ApplicationOptions()
                End If
            End SyncLock

            Return _Instance
        End Get

    End Property
#End Region

    Private Sub New()
        OptionList = New Dictionary(Of String, String)
        AllLists = New Dictionary(Of String, List(Of String))
        setDefaultValues()
        EnsureExistsRegKey("SOFTWARE", Application.ProductName)
        EnsureExistsRegKey("SOFTWARE\" & Application.ProductName, "Lists")
        loadFromReg()
        loadAllListsFromReg()
    End Sub

    Private Sub setDefaultValues()
        OptionList(OPT_USE_DATE_TAKEN) = "true"
        OptionList(OPT_IGNORE_DOT_FILES) = "true"
        OptionList(OPT_MOVE_FILES) = "true"
        OptionList(OPT_DUPLICATE_ACTION) = DUPLICATE_ACTION_COPY_TO_DUP_FOLDER
        OptionList(OPT_FOLDER_LEVEL_1) = FOLDER_LEVEL_YEAR
        OptionList(OPT_FOLDER_LEVEL_2) = FOLDER_LEVEL_MONTH
        OptionList(OPT_FOLDER_LEVEL_3) = FOLDER_LEVEL_EVENT
        OptionList(OPT_FOLDER_LEVEL_4) = FOLDER_LEVEL_NONE
    End Sub

    Public Sub setOption(strOptionName As String, strOptionValue As String)
        OptionList(strOptionName) = strOptionValue
        saveOptionReg(strOptionName, strOptionValue)
    End Sub

    Public Function getOption(strOptionName As String) As String
        If hasOption(strOptionName) Then
            Return OptionList(strOptionName)
        Else
            Return ""
        End If
    End Function

    Public Function hasOption(strOptionName As String) As Boolean
        If OptionList.ContainsKey(strOptionName) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub setOptionInt(strOptionName As String, intOptionValue As Integer)
        setOption(strOptionName, intOptionValue.ToString())
    End Sub

    Public Function getOptionInt(strOptionName As String) As Integer
        Dim intReturn As Integer

        Try
            intReturn = Integer.Parse(getOption(strOptionName))
        Catch ex As Exception
            intReturn = 0
        End Try

        Return intReturn
    End Function

    Public Function hasOptionInt(strOptionName As String) As Boolean
        Dim blnRet As Boolean
        Dim intVal As Integer
        Try
            blnRet = hasOption(strOptionName)
            If blnRet Then
                intVal = Integer.Parse(getOption(strOptionName))
            End If
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    Public Function getOptionDate(strOptionName As String) As DateTime
        Dim ciProvider As CultureInfo = CultureInfo.InvariantCulture
        Dim dteReturnDate As DateTime

        Try
            If hasOptionDate(strOptionName) Then
                dteReturnDate = DateTime.ParseExact(getOption(strOptionName), "yyyy-MM-dd HH:mm:ss", ciProvider)
            Else
                dteReturnDate = DateTime.ParseExact("1900-01-01 12:00:00", "yyyy-MM-dd HH:mm:ss", ciProvider)
            End If
        Catch ex As Exception
            dteReturnDate = DateTime.ParseExact("1900-01-01 12:00:00", "yyyy-MM-dd HH:mm:ss", ciProvider)
        End Try

        Return (dteReturnDate)
    End Function

    Public Sub setOptionDate(strOptionName As String, dteDateValue As DateTime)
        Dim strFormatValue As String

        strFormatValue = dteDateValue.ToString("yyyy-MM-dd HH:mm:ss")
        setOption(strOptionName, strFormatValue)
    End Sub

    Public Function hasOptionDate(strOptionName As String) As Boolean
        Dim blnRet As Boolean
        Dim ciProvider As CultureInfo = CultureInfo.InvariantCulture
        Dim dteReturnDate As DateTime

        Try
            blnRet = hasOption(strOptionName)
            If blnRet Then
                dteReturnDate = DateTime.ParseExact(getOption(strOptionName), "yyyy-MM-dd HH:mm:ss", ciProvider)
            End If
        Catch ex As Exception
            blnRet = False
        End Try
        Return blnRet
    End Function

    Public Function getOptionBoolean(strOptionName As String) As Boolean
        Dim blnRet As Boolean
        Dim strValue As String

        strValue = getOption(strOptionName)

        If strValue = "true" Then
            blnRet = True
        Else
            blnRet = False
        End If

        Return blnRet
    End Function

    Public Sub setOptionBoolean(strOptionName As String, blnValue As Boolean)
        If blnValue Then
            setOption(strOptionName, "true")
        Else
            setOption(strOptionName, "false")
        End If
    End Sub

    Public Function getDuplicateFolder() As String
        Dim strRet As String
        strRet = getOption(OPT_FOLDER_DEST)
        strRet = strRet & "\Duplicates"
        Return strRet
    End Function

    Private Sub EnsureExistsRegKey(strKeyParent As String, strCheckKey As String)
        Dim reg As RegistryKey
        Dim strKeys As String()
        Dim blnHasKey As Boolean

        blnHasKey = False

        reg = Registry.CurrentUser.OpenSubKey(strKeyParent, True)
        strKeys = reg.GetSubKeyNames

        For Each strKeyName As String In strKeys
            If strKeyName = strCheckKey Then
                blnHasKey = True
            End If
        Next

        If blnHasKey = False Then
            reg.CreateSubKey(strCheckKey)
        End If

        reg.Close()
        reg.Dispose()
    End Sub


    Private Sub loadFromReg()
        Dim reg As RegistryKey
        Dim strValueNames As String()
        Dim strValue As String

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName, True)
        strValueNames = reg.GetValueNames()
        For Each strValueName As String In strValueNames
            strValue = reg.GetValue(strValueName)
            setOption(strValueName, strValue)
        Next

        reg.Close()
        reg.Dispose()
    End Sub

    Private Sub loadAllListsFromReg()
        Dim reg As RegistryKey
        Dim strSubKeys As String()

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName & "\Lists", True)

        strSubKeys = reg.GetSubKeyNames()

        For Each strKey As String In strSubKeys
            loadListFromReg(strKey)
        Next

        reg.Close()
        reg.Dispose()
    End Sub

    Private Sub loadListFromReg(strListName As String)
        Dim reg As RegistryKey
        Dim intEntryCount As Integer
        Dim intEntryNum As Integer
        Dim lstList As List(Of String)
        Dim strEntry As String

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName & "\Lists\" & strListName, True)

        intEntryCount = reg.GetValue("EntryCount")
        intEntryNum = 1

        lstList = New List(Of String)()

        While intEntryNum <= intEntryCount
            strEntry = reg.GetValue("Entry_" & intEntryNum)
            lstList.Add(strEntry)
            intEntryNum += 1
        End While

        setList(strListName, lstList)

        reg.Close()
        reg.Dispose()
    End Sub

    Private Sub saveOptionReg(strName As String, strValue As String)
        Dim reg As RegistryKey

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName, True)

        reg.SetValue(strName, strValue)

        reg.Close()
        reg.Dispose()

    End Sub

    Public Function getLevelDepth()
        Dim intRet As Integer
        Dim i As Integer

        intRet = 0
        i = 1
        While i <= 4
            If getOption(getLevelOptionName(i)) = ApplicationOptions.FOLDER_LEVEL_NONE Then
                intRet = i - 1
                i = 5
            End If
            i += 1
        End While

        If intRet = 0 Then
            intRet = 4
        End If

        Return intRet
    End Function

    Public Function getLevelOptionName(intLevelNum As Integer) As String
        Dim strReturn As String
        Select Case intLevelNum
            Case 1
                strReturn = ApplicationOptions.OPT_FOLDER_LEVEL_1
            Case 2
                strReturn = ApplicationOptions.OPT_FOLDER_LEVEL_2
            Case 3
                strReturn = ApplicationOptions.OPT_FOLDER_LEVEL_3
            Case 4
                strReturn = ApplicationOptions.OPT_FOLDER_LEVEL_4
            Case Else
                Throw New PFException("Invalid folder level specified for option  name", "INVALID_FOLDER_LEVEL", PFException.eType.InternalError)
        End Select
        Return strReturn
    End Function

    Private Function hasList(strListName As String) As Boolean
        Dim blnRet As Boolean

        If AllLists.ContainsKey(strListName) Then
            blnRet = True
        Else
            blnRet = False
        End If

        Return blnRet
    End Function

    Private Sub createList(strListName As String)
        Dim reg As RegistryKey

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName & "\Lists", True)
        reg.CreateSubKey(strListName)
        AllLists.Add(strListName, New List(Of String))

    End Sub

    Public Sub addListEntry(strListName As String, strNewEntry As String)
        Dim lstList As List(Of String)

        If hasList(strListName) = False Then
            createList(strListName)
        End If

        lstList = getList(strListName)
        lstList.Add(strNewEntry)

    End Sub

    Public Sub addMRUListEntry(strListName As String, strNewEntry As String, intMaxSize As Integer)
        Dim lstList As List(Of String)
        Dim lstNewList As List(Of String)

        If hasList(strListName) = False Then
            createList(strListName)
        End If

        ' Get the existing list and add
        lstList = getList(strListName)
        lstNewList = New List(Of String)

        ' Add this entry at the start of the list
        lstNewList.Add(strNewEntry)

        ' Loop through the previous list and add all items which aren't equal to the one already added
        ' and limit the size to "Max Size"
        For Each strEntry As String In lstList
            If strEntry <> strNewEntry Then
                If lstNewList.Count < intMaxSize Then
                    lstNewList.Add(strEntry)
                End If
            End If
        Next

        ' Save the new list
        setList(strListName, lstNewList)

    End Sub

    Public Sub saveListToReg(strListName As String)
        Dim lstSave As List(Of String)
        Dim reg As RegistryKey
        Dim intEntryNum As Integer

        If hasList(strListName) Then
            lstSave = getList(strListName)
        Else
            lstSave = New List(Of String)
        End If

        reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\" & Application.ProductName & "\Lists\" & strListName, True)

        reg.SetValue("EntryCount", lstSave.Count)

        intEntryNum = 1

        For Each strEntry As String In lstSave
            reg.SetValue("Entry_" & intEntryNum, strEntry)
            intEntryNum += 1
        Next

        reg.Close()
    End Sub

    Public Sub setList(strListName As String, lstSet As List(Of String))
        AllLists.Item(strListName) = lstSet
        saveListToReg(strListName)
    End Sub

    Public Function getList(strListName As String) As List(Of String)
        Dim lstRet As List(Of String)

        If hasList(strListName) Then
            lstRet = AllLists.Item(strListName)
        Else
            lstRet = New List(Of String)
        End If

        Return lstRet
    End Function

End Class
