Public Class XLevelGroup
    Implements IEnumerable(Of String)

    Private UI_WIDTH As Integer = 180
    Private UI_HEIGHT As Integer = 30
    Private UI_SPACING_LEFT As Integer = 9
    Private UI_SPACING_TOP As Integer = 9
    Private UI_START_TOP As Integer = 50
    Private UIValuesScaled = False

    Public Const SORT_ASCENDING As String = "ASC"
    Public Const SORT_DESCENDING As String = "DESC"
    Public Const SORT_NONE As String = "NONE"

    Public LABEL_BACKCOLOR_SELECTED As System.Drawing.Color = Color.PaleGreen
    Public LABEL_BACKCOLOR_EMPTY As System.Drawing.Color = Color.Bisque
    Public LABEL_BACKCOLOR_UNSELECTED As System.Drawing.Color = Color.LightYellow

    Private ParentContainer As Control
    Private FullList As List(Of String)
    Private AllLabels As List(Of Label)
    Private OrderedLabels As IEnumerable(Of Label)
    Private SelectedLevelLabel As Label
    Private AppOptions As ApplicationOptions

    Private _SelectedLevel As String
    Public Property SelectedLevel() As String
        Get
            Return _SelectedLevel
        End Get
        Set(ByVal value As String)
            _SelectedLevel = value
            If SelectedLevelLabel IsNot Nothing Then
                SelectedLevelLabel.Text = value
                If value = "" Then
                    SelectedLevelLabel.BackColor = LABEL_BACKCOLOR_EMPTY
                Else
                    SelectedLevelLabel.BackColor = LABEL_BACKCOLOR_SELECTED
                    MarkSelected()
                End If
            End If
        End Set
    End Property

    Private _LevelNumber As Integer
    Public Property LevelNumber() As Integer
        Get
            Return _LevelNumber
        End Get
        Set(ByVal value As Integer)
            _LevelNumber = value
        End Set
    End Property


    Private _LevelDate As DateTime
    Public Property LevelDate() As DateTime
        Get
            Return _LevelDate
        End Get
        Set(ByVal value As DateTime)
            _LevelDate = value
        End Set
    End Property

    Private _SortMethod As String
    Public Property SortMethod() As String
        Get
            Return _SortMethod
        End Get
        Set(ByVal value As String)
            If value = SORT_ASCENDING Or value = SORT_DESCENDING Or value = SORT_NONE Then
                _SortMethod = value
            Else
                Throw New PFException("Invalid sort method specified", "INVALID_SORT_METHOD", PFException.eType.InternalError)
            End If
        End Set
    End Property

    Public Sub New()
        AppOptions = ApplicationOptions.Instance
        SortMethod = SORT_ASCENDING
        LevelDate = DateTime.Now
        LevelNumber = 0
        Clear()
    End Sub

    Private Sub ScaleUIValues()
        If UIValuesScaled = False Then
            Try
                'MsgBox("Scale: " & XMain.ScaleRatio)
                UI_HEIGHT = UI_HEIGHT * XMain.ScaleRatio
                UI_SPACING_LEFT = UI_SPACING_LEFT * XMain.ScaleRatio
                UI_SPACING_TOP = UI_SPACING_TOP * XMain.ScaleRatio
                UI_START_TOP = UI_START_TOP * XMain.ScaleRatio
                UI_WIDTH = UI_WIDTH * XMain.ScaleRatio
                UIValuesScaled = True
            Catch ex As Exception
                Throw New PFException("Unable to adjust display scale for current display settings", "SCALE_ERROR", PFException.eType.InternalError)
            End Try

        End If
    End Sub

    Public Sub Clear()
        ClearList()
        ClearUI()
    End Sub

    Public Sub ClearList()
        If FullList IsNot Nothing Then
            FullList.Clear()
        End If

        FullList = New List(Of String)
    End Sub

    Public Sub Empty()
        ClearList()
        EmptyUI()
    End Sub

    Private Sub EmptyUI()
        If AllLabels IsNot Nothing Then
            For Each lblCurrent As Label In AllLabels
                If hasParentContainer() Then
                    ParentContainer.Controls.Remove(lblCurrent)
                End If
                lblCurrent.Dispose()
            Next
            AllLabels.Clear()
        End If

        AllLabels = New List(Of Label)
    End Sub

    Public Sub ClearUI()
        EmptyUI()
        ParentContainer = Nothing
    End Sub

    Public Sub linkSelectedLevelLabel(lblSet As Label)
        SelectedLevelLabel = lblSet
    End Sub

    Public Function hasParentContainer() As Boolean
        If ParentContainer Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub linkParentContainer(cParent As Control)
        ClearUI()
        ParentContainer = cParent
        addAllLevels()
    End Sub

    Public Sub fillList(lstFill As List(Of String))
        For Each strEntry As String In lstFill
            addLevelName(strEntry)
        Next
        SortLabels()
        RefreshLayout()
    End Sub

    Public Sub fillYears()
        Dim intCount As Integer
        Dim dteCurrent As Date
        Dim strFormat As String

        dteCurrent = Date.Now
        intCount = 0
        strFormat = "yyyy"

        While intCount <= 20
            addLevelName(dteCurrent.ToString(strFormat))
            dteCurrent = DateAdd(DateInterval.Year, -1, dteCurrent)
            intCount += 1
        End While
    End Sub

    Public Sub fillMonths()
        Dim intCount As Integer
        Dim dteCurrent As Date
        Dim strFormat As String

        ' Start the date in January
        dteCurrent = Date.ParseExact("2012-01-01", "yyyy-MM-dd", Nothing)
        intCount = 1
        strFormat = "MM-MMMM"

        ' Iterate through each month, format it, and add it to the list
        While intCount <= 12
            addLevelName(dteCurrent.ToString(strFormat))
            dteCurrent = DateAdd(DateInterval.Month, 1, dteCurrent)
            intCount += 1
        End While
    End Sub

    Public Sub fillDays()
        Dim intCount As Integer
        Dim dteCurrent As Date
        Dim strLevelName As String

        ' Start the date on Jan 1
        dteCurrent = Date.ParseExact("2012-01-01", "yyyy-MM-dd", Nothing)
        intCount = 1

        ' Iterate through each day, format it, and add it to the list
        While intCount <= 31
            strLevelName = MainSorter.LevelFolderName(ApplicationOptions.FOLDER_LEVEL_DAY, dteCurrent, "")
            addLevelName(strLevelName)
            dteCurrent = DateAdd(DateInterval.Day, 1, dteCurrent)
            intCount += 1
        End While
    End Sub

    Private Sub addAllLevels()
        ' Create all the level UIs
        For Each strLevelName As String In FullList
            addLevelUI(strLevelName, False)
        Next
        ' Sort by the specified sort method
        SortLabels()
        ' Adjust the label positions
        RefreshLayout()
    End Sub

    Public Sub MarkSelected()
        For Each lblCurrent As Label In AllLabels
            If lblCurrent.Text = Me.SelectedLevel Then
                lblCurrent.BackColor = LABEL_BACKCOLOR_SELECTED
            Else
                lblCurrent.BackColor = LABEL_BACKCOLOR_UNSELECTED
            End If
        Next
    End Sub

    Public Sub SortLabels()
        Dim iRet As IEnumerable(Of Label)
        '' Sort the labels differently depending on the sort level specified
        Select Case Me.SortMethod
            Case XLevelGroup.SORT_ASCENDING
                ' Re-order the labels in ascending order
                iRet = AllLabels.OrderBy(Function(x) x.Text)
            Case XLevelGroup.SORT_DESCENDING
                ' Re-order the labels in descending order
                iRet = AllLabels.OrderByDescending(Function(x) x.Text)
            Case XLevelGroup.SORT_NONE
                ' Do nothing
                iRet = AllLabels.OrderBy(Function(x) FullList.IndexOf(x.Text))
            Case Else
                Throw New PFException("Invalid sort method specified for level group", "INVALID_SORT_METHOD", PFException.eType.InternalError)
        End Select
        OrderedLabels = iRet
    End Sub

    Private Sub addLevelUI(strLevelName As String, blnDoRefresh As Boolean)
        Dim lblNew As Label

        If ParentContainer IsNot Nothing Then
            lblNew = New Label()

            ' Set the style for the label
            lblNew.Text = strLevelName
            lblNew.BorderStyle = BorderStyle.FixedSingle
            lblNew.BackColor = Color.AliceBlue
            lblNew.AutoSize = False
            lblNew.Width = UI_WIDTH
            lblNew.Height = UI_HEIGHT
            lblNew.TextAlign = ContentAlignment.MiddleCenter
            lblNew.ForeColor = Color.Black

            ' Add a click handler which passes the label object to the function LevelNameClickHandler
            ' This allows us to get the label text and identify the level name which was selected
            AddHandler lblNew.Click, Function(sender, eventsent) (LevelNameClickHandler(lblNew))

            AddHandler lblNew.MouseEnter, Function(sender, eventsent) (LevelNameMouseEnterHandler(lblNew))
            AddHandler lblNew.MouseLeave, Function(sender, eventsent) (LevelNameMouseExitHandler(lblNew))

            ' Add the label to our collection
            AllLabels.Add(lblNew)
            ' Add it to the parent container
            ParentContainer.Controls.Add(lblNew)

            If blnDoRefresh Then
                ' Re-order the labels
                AllLabels.OrderBy(Function(x) x.Text)
                ' Adjust the label positions
                RefreshLayout()
            End If
        End If

    End Sub

    Public Function LevelNameMouseEnterHandler(lblCurrent As Label) As Boolean
        lblCurrent.BackColor = LABEL_BACKCOLOR_SELECTED
        Return True
    End Function

    Public Function LevelNameMouseExitHandler(lblCurrent As Label) As Boolean
        If lblCurrent.Text = SelectedLevel Then
            lblCurrent.BackColor = LABEL_BACKCOLOR_SELECTED
        Else
            lblCurrent.BackColor = LABEL_BACKCOLOR_UNSELECTED
        End If
        Return True
    End Function

    Public Function LevelNameClickHandler(lblClicked As Label) As Boolean
        SelectedLevel = lblClicked.Text
        Return True
    End Function

    Public Sub RefreshLayout()
        Dim intColumnWidth As Integer
        Dim intRowHeight As Integer
        Dim intColumns As Integer
        Dim i As Integer
        Dim j As Integer
        Dim intNewX As Integer
        Dim intNewY As Integer
        Dim blnTryAgain As Boolean

        ScaleUIValues()

        MarkSelected()

        If hasParentContainer() Then
            intColumnWidth = UI_WIDTH + UI_SPACING_LEFT
            intRowHeight = UI_HEIGHT + UI_SPACING_TOP

            intColumns = Math.Floor(ParentContainer.Width / intColumnWidth)

            If intColumns = 0 Then
                intColumns = 1
            End If

            blnTryAgain = True

            ' Loop to retry if an error occurs
            While blnTryAgain
                blnTryAgain = False

                ' Start with row (j) zero and column (i) zero
                i = 0
                j = 0

                If OrderedLabels Is Nothing Then
                    SortLabels()
                End If

                Try
                    ' Loop through all the labels and adjust their positions
                    For Each lblCurrent As Label In OrderedLabels
                        ' Calculate the new position
                        intNewX = (i * intColumnWidth) + UI_SPACING_LEFT
                        intNewY = (j * intRowHeight) + UI_START_TOP
                        ' Set the position
                        lblCurrent.Left = intNewX
                        lblCurrent.Top = intNewY
                        i += 1
                        ' If we've reached the last column, start a new row
                        If i >= intColumns Then
                            i = 0
                            j += 1
                        End If
                    Next
                Catch ex As Exception
                    If ex.Message.Contains("Collection was modified") Then
                        blnTryAgain = True
                    End If
                End Try
            End While
        End If
    End Sub

    Public Sub addLevelName(strEntry As String)
        If FullList.Contains(strEntry) = False Then
            FullList.Add(strEntry)
            addLevelUI(strEntry, True)
        End If
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator
        Return FullList.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function
End Class
