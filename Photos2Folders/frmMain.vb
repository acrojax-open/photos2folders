Public Class frmMain
    Private FormLoaded As Boolean = False
    Private HiddenTabs() As TabPage

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        InitHiddenTabs()
        LinkLevelContainers()
        LinkLevelLabels()
        HideLevelUI()

        FormLoaded = True
    End Sub

    Private Sub InitHiddenTabs()
        Dim i As Integer

        HiddenTabs = New TabPage(5) {}

        For Each tPage As TabPage In ContainerTabsLevels.TabPages
            HiddenTabs(i) = tPage
            i += 1
        Next
    End Sub

    Private Sub PhotoViewer_ThumbnailClick(strPhotoPath As String) Handles PhotoViewer.ThumbnailClick
        If strPhotoPath <> "" Then
            Dim imgPreview As Image
            Try
                imgPreview = Image.FromFile(strPhotoPath)
            Catch ex As Exception
                imgPreview = My.Resources.ResourceManager.GetObject("image_problem")
            End Try
            If imgPreview.Height > ImagePreviewPane.Height Or imgPreview.Width > ImagePreviewPane.Width Then
                ImagePreviewPane.BackgroundImageLayout = ImageLayout.Zoom
            Else
                ImagePreviewPane.BackgroundImageLayout = ImageLayout.Center
            End If
            ImagePreviewPane.BackgroundImage = imgPreview
        End If
    End Sub

    Private Sub LinkLevelContainers()
        MainSorter.setLevelGroupContainer(1, tabLevel1)
        MainSorter.setLevelGroupContainer(2, tabLevel2)
        MainSorter.setLevelGroupContainer(3, tabLevel3)
        MainSorter.setLevelGroupContainer(4, tabLevel4)
    End Sub

    Private Sub LinkLevelLabels()
        MainSorter.setLevelGroupSelectedLabel(1, lblFolder1)
        MainSorter.setLevelGroupSelectedLabel(2, lblFolder2)
        MainSorter.setLevelGroupSelectedLabel(3, lblFolder3)
        MainSorter.setLevelGroupSelectedLabel(4, lblFolder4)
    End Sub

    Private Sub HideLevelUI()
        Dim i As Integer
        Dim strLevelType As String
        Dim blnVisible As Boolean

        ContainerTabsLevels.TabPages.Clear()

        i = 1
        While i <= 4
            strLevelType = AppOptions.getOption(AppOptions.getLevelOptionName(i))
            If strLevelType = ApplicationOptions.FOLDER_LEVEL_NONE Then
                blnVisible = False
            Else
                blnVisible = True
            End If

            ' Set the if the level labels (and corresponding slash label) are visible or not
            Select Case i
                Case 1
                    lblFolder1.Visible = blnVisible
                Case 2
                    lblFolder2.Visible = blnVisible
                    lblSlash1.Visible = blnVisible
                Case 3
                    lblFolder3.Visible = blnVisible
                    lblSlash2.Visible = blnVisible
                Case 4
                    lblFolder4.Visible = blnVisible
                    lblSlash3.Visible = blnVisible
            End Select

            ' Add the tab to the container so that it is visible (if it should be)
            If blnVisible Then
                HiddenTabs(i - 1).Text = strLevelType
                ContainerTabsLevels.TabPages.Insert(i - 1, HiddenTabs(i - 1))
            End If

            i += 1
        End While
    End Sub

    Private Sub LoadFullStats()
        lblDuplicatePhotosNum.Text = MainSorter.getDuplicateCount()
        lblPhotosInSourceNum.Text = MainSorter.getSourceCount()
        lblPhotosInDestinationNum.Text = MainSorter.getDestinationCount()
        lblSourcePhotoGroupsNum.Text = MainSorter.getGroupTotal
    End Sub

    Private Sub LoadCurrentGroupStats()
        lblPhotosInGroupNum.Text = MainSorter.getGroupCount
        lblGroupDateVal.Text = MainSorter.getGroupDate().ToString("MMM dd yyyy")
        lblGroupNumberVal.Text = MainSorter.getGroupNumber & "/" & MainSorter.getGroupTotal
    End Sub

    Public Sub StartSorting()
        LoadFullStats()
        LoadNextGroup()
    End Sub

    Public Function LoadNextGroup() As Boolean
        Dim blnRet As Boolean
        Dim fscCurrent As XPhotoSetClassification
        Dim pfFiles As XPhotoSet

        Try
            blnRet = MainSorter.NextGroup()
            If blnRet Then
                fscCurrent = MainSorter.Current()
                LoadCurrentGroupStats()
                pfFiles = fscCurrent.getPhotoSet()
                PhotoViewer.LoadPhotos(pfFiles)
                PhotoViewer.ScrollToFirstPhoto()
                PhotoViewer.SelectPhoto(0)
                If MainSorter.getFirstEmptyLevel > 0 Then
                    ContainerTabsLevels.SelectedIndex = MainSorter.getFirstEmptyLevel - 1
                End If
            Else
                If MainSorter.isLastGroup And MainSorter.isCurrentGroupComplete Then
                    ' Looks like we've reached the end, ask if they are done
                    FinishedSorting()
                End If
            End If
            ' Perform garbage collection to keep memory utilization under control
            GC.Collect()
        Catch pex As PFException
            UnhandledPFException(pex)
        Catch ex As Exception
            UnhandledException(ex)
        End Try
        Return blnRet
    End Function

    Public Function LoadPrevGroup() As Boolean
        Dim blnRet As Boolean
        Dim fscCurrent As XPhotoSetClassification
        Dim pfFiles As XPhotoSet

        Try
            blnRet = MainSorter.PrevGroup()
            If blnRet Then
                fscCurrent = MainSorter.Current()
                LoadCurrentGroupStats()
                pfFiles = fscCurrent.getPhotoSet()
                PhotoViewer.LoadPhotos(pfFiles)
                PhotoViewer.ScrollToFirstPhoto()
                PhotoViewer.SelectPhoto(0)
            End If
            ' Perform garbage collection to keep memory utilization under control
            GC.Collect()
        Catch pex As PFException
            UnhandledPFException(pex)
        Catch ex As Exception
            UnhandledException(ex)
        End Try

        Return blnRet
    End Function

    Private Sub cmdNextGroup_Click(sender As Object, e As EventArgs) Handles cmdNextGroup.Click
        LoadNextGroup()
    End Sub

    Private Sub cmdPrevGroup_Click(sender As Object, e As EventArgs) Handles cmdPrevGroup.Click
        LoadPrevGroup()
    End Sub

    Private Sub tabLevel1_Resize(sender As Object, e As EventArgs) Handles tabLevel1.Resize
        If MainSorter IsNot Nothing Then
            MainSorter.LevelRefreshLayout(1)
        End If
    End Sub

    Private Sub tabLevel2_Resize(sender As Object, e As EventArgs) Handles tabLevel2.Resize
        If MainSorter IsNot Nothing Then
            MainSorter.LevelRefreshLayout(2)
        End If
    End Sub

    Private Sub tabLevel3_Resize(sender As Object, e As EventArgs) Handles tabLevel3.Resize
        If MainSorter IsNot Nothing Then
            MainSorter.LevelRefreshLayout(3)
        End If
    End Sub

    Private Sub tabLevel4_Resize(sender As Object, e As EventArgs) Handles tabLevel4.Resize
        If MainSorter IsNot Nothing Then
            MainSorter.LevelRefreshLayout(4)
        End If
    End Sub

    Private Sub cmdLevel3Add_Click(sender As Object, e As EventArgs) Handles cmdLevel3Add.Click
        MainSorter.AddLevelEntry(3, txtLevel3New.Text)
        txtLevel3New.Text = ""
    End Sub

    Private Sub cmdLevel1Add_Click(sender As Object, e As EventArgs) Handles cmdLevel1Add.Click
        MainSorter.AddLevelEntry(1, txtLevel1New.Text)
        txtLevel1New.Text = ""
    End Sub

    Private Sub cmdLevel2Add_Click(sender As Object, e As EventArgs) Handles cmdLevel2Add.Click
        MainSorter.AddLevelEntry(2, txtLevel2New.Text)
        txtLevel2New.Text = ""
    End Sub

    Private Sub cmdLevel4Add_Click(sender As Object, e As EventArgs) Handles cmdLevel4Add.Click
        MainSorter.AddLevelEntry(4, txtLevel4New.Text)
        txtLevel4New.Text = ""
    End Sub

    Private Sub ClearPreviewPane()
        Dim imgCurrent As Image

        imgCurrent = ImagePreviewPane.BackgroundImage
        ImagePreviewPane.BackgroundImage = Nothing
        If imgCurrent IsNot Nothing Then
            imgCurrent.Dispose()
        End If

    End Sub

    Private Sub FinishedSorting()
        Dim strAction As String
        If AppOptions.getOptionBoolean(ApplicationOptions.OPT_MOVE_FILES) Then
            strAction = "moved"
        Else
            strAction = "copied"
        End If

        If MsgBox("Are you sure you are done sorting and are ready to have your photos " & strAction & " into their newly organized folders?", MsgBoxStyle.YesNo, "All Done?") = vbYes Then
            Try
                ClearPreviewPane()
                MainSorter.CopyPhotosToFolders()
                Me.Close()
            Catch pfex As PFException
                If pfex.Type = PFException.eType.UserInputError Then
                    MsgBox(pfex.Message, vbOKOnly, "Oops...")
                Else
                    UnhandledPFException(pfex)
                End If
            Catch ex As Exception
                UnhandledException(ex)
            End Try
        End If
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        FinishedSorting()
    End Sub

    Private Sub txtLevel1New_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLevel1New.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmdLevel1Add_Click(sender, e)
        End If
    End Sub

    Private Sub txtLevel2New_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLevel2New.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmdLevel2Add_Click(sender, e)
        End If
    End Sub

    Private Sub txtLevel3New_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLevel3New.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmdLevel3Add_Click(sender, e)
        End If
    End Sub

    Private Sub txtLevel4New_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLevel4New.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmdLevel4Add_Click(sender, e)
        End If
    End Sub

    Private Sub pnlLogo_DoubleClick(sender As Object, e As EventArgs) Handles pnlLogo.DoubleClick
        AboutMe()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Resize or relocate any elements which are anchored to the bottom based on the
        ' screen scaling in effect
        Try
            cmdNextGroup.Top = pnlMainSection.Height - ((cmdNextGroup.Height * 3) / 2)
            cmdPrevGroup.Top = pnlMainSection.Height - ((cmdPrevGroup.Height * 3) / 2)
            cmdProcess.Top = pnlMainSection.Height - ((cmdProcess.Height * 3) / 2)
            ContainerTabsLevels.Height = cmdNextGroup.Top - ContainerTabsLevels.Top - (cmdNextGroup.Height / 2)
        Catch ex As Exception
            Throw New PFException("Failed to relocate controls based on current display settings", "SCALE_CONTROLS", PFException.eType.InternalError)
        End Try

        ' Resize the top panes such that the image preview is as big as possible
        ContainerTopVertSplit.Panel1MinSize = CurrentGroupBox.Left + CurrentGroupBox.Width + 40
        ContainerTopVertSplit.SplitterDistance = ContainerTopVertSplit.Panel1MinSize
    End Sub

End Class
