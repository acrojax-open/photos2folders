Public Class frmStart
    Private FormLoaded As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        InitializeApplication()
        LoadOptions()
        FormLoaded = True
        UpdateExampleFolder()
    End Sub


    Private Sub lblStep1_Click(sender As Object, e As EventArgs) Handles lblStep1.Click

    End Sub

    Private Sub txtDest_TextChanged(sender As Object, e As EventArgs) Handles txtDest.TextChanged
        If FormLoaded Then
            AppOptions.setOption(ApplicationOptions.OPT_FOLDER_DEST, txtDest.Text)
            UpdateExampleFolder()
        End If
    End Sub

    Private Sub txtSource_TextChanged(sender As Object, e As EventArgs) Handles txtSource.TextChanged
        If FormLoaded Then
            AppOptions.setOption(ApplicationOptions.OPT_FOLDER_SOURCE, txtSource.Text)
        End If
    End Sub

    Private Sub UpdateExampleFolder()
        Dim strBase As String

        If FormLoaded Then
            If txtDest.Text = "" Then
                strBase = "C:\ExamplePictures\"
            Else
                strBase = txtDest.Text
                If strBase.EndsWith("\") = False Then
                    strBase &= "\"
                End If
            End If

            lblExampleLevelPath.Text = "Example Folder: " & strBase & MainSorter.LevelTypesToExampleFolderPath(cmbOptLevel1.SelectedItem, cmbOptLevel2.SelectedItem, cmbOptLevel3.SelectedItem, cmbOptLevel4.SelectedItem)
        End If
    End Sub

    Private Sub LoadOptions()
        txtSource.Text = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_SOURCE)
        txtDest.Text = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_DEST)
        chkOptionDateTaken.Checked = AppOptions.getOptionBoolean(ApplicationOptions.OPT_USE_DATE_TAKEN)
        chkOptionIgnoreDotStart.Checked = AppOptions.getOptionBoolean(ApplicationOptions.OPT_IGNORE_DOT_FILES)
        chkOptionMoveFiles.Checked = AppOptions.getOptionBoolean(ApplicationOptions.OPT_MOVE_FILES)
        cmbDuplicate.SelectedIndex = AppOptions.getOptionInt(ApplicationOptions.OPT_DUPLICATE_ACTION)
        cmbOptLevel1.SelectedItem = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_LEVEL_1)
        cmbOptLevel2.SelectedItem = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_LEVEL_2)
        cmbOptLevel3.SelectedItem = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_LEVEL_3)
        cmbOptLevel4.SelectedItem = AppOptions.getOption(ApplicationOptions.OPT_FOLDER_LEVEL_4)
        UpdateDuplicateActionList()
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Try
            MainSorter.SourcePath = txtSource.Text
            MainSorter.DestinationPath = txtDest.Text
            Me.Hide()
            frmProgressBox.Show()
            MainSorter.Run()
            frmProgressBox.Close()
            frmMain.Show()
            frmMain.StartSorting()
            Me.Close()
        Catch ex As PFException
            If ex.Code = "DEST_NOT_EXIST" Then
                MsgBox("Destination folder does not exist", MsgBoxStyle.OkOnly, "Oops...")
            Else
                If ex.Type = PFException.eType.UserInputError Then
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Oops... something's not right")
                Else
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Uh oh... something went wrong")
                End If
            End If
            frmProgressBox.Close()
            Me.Show()
        End Try
    End Sub

    Private Sub UpdateDuplicateActionList()
        Dim strAction As String

        If AppOptions.getOptionBoolean(ApplicationOptions.OPT_MOVE_FILES) Then
            strAction = "Move "
        Else
            strAction = "Copy "
        End If

        cmbDuplicate.Items.Item(0) = strAction & " anyways"
        cmbDuplicate.Items.Item(1) = strAction & "to 'Duplicates' folder"
        cmbDuplicate.Items.Item(2) = "Skip duplicates (do nothing)"

    End Sub

    Private Sub cmbDuplicate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDuplicate.SelectedIndexChanged
        AppOptions.setOptionInt(ApplicationOptions.OPT_DUPLICATE_ACTION, cmbDuplicate.SelectedIndex)
    End Sub

    Private Sub chkOptionDateTaken_CheckedChanged(sender As Object, e As EventArgs) Handles chkOptionDateTaken.CheckedChanged
        AppOptions.setOptionBoolean(ApplicationOptions.OPT_USE_DATE_TAKEN, chkOptionDateTaken.Checked)
    End Sub

    Private Sub chkOptionMoveFiles_CheckedChanged(sender As Object, e As EventArgs) Handles chkOptionMoveFiles.CheckedChanged
        AppOptions.setOptionBoolean(ApplicationOptions.OPT_MOVE_FILES, chkOptionMoveFiles.Checked)
        UpdateDuplicateActionList()
    End Sub

    Private Sub chkOptionIgnoreDotStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkOptionIgnoreDotStart.CheckedChanged
        AppOptions.setOptionBoolean(ApplicationOptions.OPT_IGNORE_DOT_FILES, chkOptionIgnoreDotStart.Checked)
    End Sub

    Private Sub cmbOptLevel4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptLevel4.SelectedIndexChanged
        AppOptions.setOption(ApplicationOptions.OPT_FOLDER_LEVEL_4, cmbOptLevel4.SelectedItem)
        UpdateExampleFolder()
    End Sub

    Private Sub cmbOptLevel2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptLevel2.SelectedIndexChanged
        AppOptions.setOption(ApplicationOptions.OPT_FOLDER_LEVEL_2, cmbOptLevel2.SelectedItem)
        UpdateExampleFolder()
    End Sub

    Private Sub cmbOptLevel1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptLevel1.SelectedIndexChanged
        AppOptions.setOption(ApplicationOptions.OPT_FOLDER_LEVEL_1, cmbOptLevel1.SelectedItem)
        UpdateExampleFolder()
    End Sub

    Private Sub cmbOptLevel3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOptLevel3.SelectedIndexChanged
        AppOptions.setOption(ApplicationOptions.OPT_FOLDER_LEVEL_3, cmbOptLevel3.SelectedItem)
        UpdateExampleFolder()
    End Sub

    Private Sub cmdBrowseSource_Click(sender As Object, e As EventArgs) Handles cmdBrowseSource.Click
        Dim fbdFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

        ' Setup the folder browsing control
        fbdFolderBrowser.Description = "Select the folder which contains the photos you want to organize.  All subfolders of the selected folder will be also be searched for pictures."
        'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        If txtSource.Text <> "" Then
            fbdFolderBrowser.SelectedPath = txtSource.Text
        End If
        Dim dlgResult As DialogResult = fbdFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            txtSource.Text = fbdFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub cmdBrowseDest_Click(sender As Object, e As EventArgs) Handles cmdBrowseDest.Click
        Dim fbdFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

        ' Setup the folder browsing control
        fbdFolderBrowser.Description = "Select the folder where you want your organized photos.  You can also select a folder which already contains photos organized by " & Application.ProductName & "."
        If txtDest.Text <> "" Then
            fbdFolderBrowser.SelectedPath = txtDest.Text
        End If
        Dim dlgResult As DialogResult = fbdFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            txtDest.Text = fbdFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub frmStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbLogo.Click

    End Sub

    Private Sub pbLogo_DoubleClick(sender As Object, e As EventArgs) Handles pbLogo.DoubleClick
        AboutMe()
    End Sub

    Private Sub getSystemScaleFactor()
        XMain.ScaleRatio = pnlSortOptions.Left / 50
    End Sub

    Private Sub frmStart_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        getSystemScaleFactor()
    End Sub
End Class