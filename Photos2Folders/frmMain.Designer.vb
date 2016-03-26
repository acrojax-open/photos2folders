<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ContainerHorizSplit = New System.Windows.Forms.SplitContainer()
        Me.ContainerTopVertSplit = New System.Windows.Forms.SplitContainer()
        Me.pnlMainSection = New System.Windows.Forms.Panel()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.CurrentGroupBox = New System.Windows.Forms.GroupBox()
        Me.lblGroupNumberVal = New System.Windows.Forms.Label()
        Me.lblGroupNumber = New System.Windows.Forms.Label()
        Me.lblPhotosInGroup = New System.Windows.Forms.Label()
        Me.lblPhotosInGroupNum = New System.Windows.Forms.Label()
        Me.lblGroupDateVal = New System.Windows.Forms.Label()
        Me.lblGroupDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSlash3 = New System.Windows.Forms.Label()
        Me.lblFolder1 = New System.Windows.Forms.Label()
        Me.lblFolder2 = New System.Windows.Forms.Label()
        Me.lblSlash2 = New System.Windows.Forms.Label()
        Me.lblFolder3 = New System.Windows.Forms.Label()
        Me.lblFolder4 = New System.Windows.Forms.Label()
        Me.lblSlash1 = New System.Windows.Forms.Label()
        Me.AllPhotosBox = New System.Windows.Forms.GroupBox()
        Me.lblPhotosInDestination = New System.Windows.Forms.Label()
        Me.lblPhotosInSource = New System.Windows.Forms.Label()
        Me.lblPhotosInSourceNum = New System.Windows.Forms.Label()
        Me.lblSourcePhotoGroups = New System.Windows.Forms.Label()
        Me.lblSourcePhotoGroupsNum = New System.Windows.Forms.Label()
        Me.lblDuplicatePhotos = New System.Windows.Forms.Label()
        Me.lblDuplicatePhotosNum = New System.Windows.Forms.Label()
        Me.lblPhotosInDestinationNum = New System.Windows.Forms.Label()
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.cmdNextGroup = New System.Windows.Forms.Button()
        Me.ContainerTabsLevels = New System.Windows.Forms.TabControl()
        Me.tabLevel1 = New System.Windows.Forms.TabPage()
        Me.cmdLevel1Add = New System.Windows.Forms.Button()
        Me.txtLevel1New = New System.Windows.Forms.TextBox()
        Me.tabLevel2 = New System.Windows.Forms.TabPage()
        Me.cmdLevel2Add = New System.Windows.Forms.Button()
        Me.txtLevel2New = New System.Windows.Forms.TextBox()
        Me.tabLevel3 = New System.Windows.Forms.TabPage()
        Me.cmdLevel3Add = New System.Windows.Forms.Button()
        Me.txtLevel3New = New System.Windows.Forms.TextBox()
        Me.tabLevel4 = New System.Windows.Forms.TabPage()
        Me.cmdLevel4Add = New System.Windows.Forms.Button()
        Me.txtLevel4New = New System.Windows.Forms.TextBox()
        Me.cmdPrevGroup = New System.Windows.Forms.Button()
        Me.ImagePreviewPane = New Photos2Folders.CustomPanel()
        Me.PhotoViewer = New Photos2Folders.PhotoViewer()
        CType(Me.ContainerHorizSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContainerHorizSplit.Panel1.SuspendLayout()
        Me.ContainerHorizSplit.Panel2.SuspendLayout()
        Me.ContainerHorizSplit.SuspendLayout()
        CType(Me.ContainerTopVertSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContainerTopVertSplit.Panel1.SuspendLayout()
        Me.ContainerTopVertSplit.Panel2.SuspendLayout()
        Me.ContainerTopVertSplit.SuspendLayout()
        Me.pnlMainSection.SuspendLayout()
        Me.CurrentGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.AllPhotosBox.SuspendLayout()
        Me.ContainerTabsLevels.SuspendLayout()
        Me.tabLevel1.SuspendLayout()
        Me.tabLevel2.SuspendLayout()
        Me.tabLevel3.SuspendLayout()
        Me.tabLevel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContainerHorizSplit
        '
        Me.ContainerHorizSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContainerHorizSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContainerHorizSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.ContainerHorizSplit.Location = New System.Drawing.Point(0, 0)
        Me.ContainerHorizSplit.Name = "ContainerHorizSplit"
        Me.ContainerHorizSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ContainerHorizSplit.Panel1
        '
        Me.ContainerHorizSplit.Panel1.Controls.Add(Me.ContainerTopVertSplit)
        '
        'ContainerHorizSplit.Panel2
        '
        Me.ContainerHorizSplit.Panel2.Controls.Add(Me.PhotoViewer)
        Me.ContainerHorizSplit.Size = New System.Drawing.Size(1482, 822)
        Me.ContainerHorizSplit.SplitterDistance = 656
        Me.ContainerHorizSplit.SplitterWidth = 5
        Me.ContainerHorizSplit.TabIndex = 1
        '
        'ContainerTopVertSplit
        '
        Me.ContainerTopVertSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContainerTopVertSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContainerTopVertSplit.Location = New System.Drawing.Point(0, 0)
        Me.ContainerTopVertSplit.Name = "ContainerTopVertSplit"
        '
        'ContainerTopVertSplit.Panel1
        '
        Me.ContainerTopVertSplit.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ContainerTopVertSplit.Panel1.Controls.Add(Me.pnlMainSection)
        Me.ContainerTopVertSplit.Panel1MinSize = 700
        '
        'ContainerTopVertSplit.Panel2
        '
        Me.ContainerTopVertSplit.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ContainerTopVertSplit.Panel2.Controls.Add(Me.ImagePreviewPane)
        Me.ContainerTopVertSplit.Panel2.Padding = New System.Windows.Forms.Padding(22, 25, 22, 25)
        Me.ContainerTopVertSplit.Size = New System.Drawing.Size(1482, 656)
        Me.ContainerTopVertSplit.SplitterDistance = 1050
        Me.ContainerTopVertSplit.TabIndex = 0
        '
        'pnlMainSection
        '
        Me.pnlMainSection.Controls.Add(Me.cmdProcess)
        Me.pnlMainSection.Controls.Add(Me.CurrentGroupBox)
        Me.pnlMainSection.Controls.Add(Me.GroupBox1)
        Me.pnlMainSection.Controls.Add(Me.AllPhotosBox)
        Me.pnlMainSection.Controls.Add(Me.pnlLogo)
        Me.pnlMainSection.Controls.Add(Me.cmdNextGroup)
        Me.pnlMainSection.Controls.Add(Me.ContainerTabsLevels)
        Me.pnlMainSection.Controls.Add(Me.cmdPrevGroup)
        Me.pnlMainSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainSection.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainSection.Name = "pnlMainSection"
        Me.pnlMainSection.Size = New System.Drawing.Size(1048, 654)
        Me.pnlMainSection.TabIndex = 45
        '
        'cmdProcess
        '
        Me.cmdProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProcess.BackColor = System.Drawing.SystemColors.Window
        Me.cmdProcess.Location = New System.Drawing.Point(858, 613)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.cmdProcess.Size = New System.Drawing.Size(156, 33)
        Me.cmdProcess.TabIndex = 44
        Me.cmdProcess.Text = "Done Sorting"
        Me.cmdProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdProcess.UseVisualStyleBackColor = False
        '
        'CurrentGroupBox
        '
        Me.CurrentGroupBox.Controls.Add(Me.lblGroupNumberVal)
        Me.CurrentGroupBox.Controls.Add(Me.lblGroupNumber)
        Me.CurrentGroupBox.Controls.Add(Me.lblPhotosInGroup)
        Me.CurrentGroupBox.Controls.Add(Me.lblPhotosInGroupNum)
        Me.CurrentGroupBox.Controls.Add(Me.lblGroupDateVal)
        Me.CurrentGroupBox.Controls.Add(Me.lblGroupDate)
        Me.CurrentGroupBox.Location = New System.Drawing.Point(511, 105)
        Me.CurrentGroupBox.Name = "CurrentGroupBox"
        Me.CurrentGroupBox.Size = New System.Drawing.Size(504, 70)
        Me.CurrentGroupBox.TabIndex = 34
        Me.CurrentGroupBox.TabStop = False
        Me.CurrentGroupBox.Text = "Current Photo Group"
        '
        'lblGroupNumberVal
        '
        Me.lblGroupNumberVal.AutoSize = True
        Me.lblGroupNumberVal.Location = New System.Drawing.Point(156, 45)
        Me.lblGroupNumberVal.Name = "lblGroupNumberVal"
        Me.lblGroupNumberVal.Size = New System.Drawing.Size(18, 20)
        Me.lblGroupNumberVal.TabIndex = 34
        Me.lblGroupNumberVal.Text = "0"
        '
        'lblGroupNumber
        '
        Me.lblGroupNumber.AutoSize = True
        Me.lblGroupNumber.Location = New System.Drawing.Point(6, 45)
        Me.lblGroupNumber.Name = "lblGroupNumber"
        Me.lblGroupNumber.Size = New System.Drawing.Size(118, 20)
        Me.lblGroupNumber.TabIndex = 33
        Me.lblGroupNumber.Text = "Group Number:"
        '
        'lblPhotosInGroup
        '
        Me.lblPhotosInGroup.AutoSize = True
        Me.lblPhotosInGroup.Location = New System.Drawing.Point(6, 23)
        Me.lblPhotosInGroup.Name = "lblPhotosInGroup"
        Me.lblPhotosInGroup.Size = New System.Drawing.Size(128, 20)
        Me.lblPhotosInGroup.TabIndex = 29
        Me.lblPhotosInGroup.Text = "Photos in Group:"
        '
        'lblPhotosInGroupNum
        '
        Me.lblPhotosInGroupNum.AutoSize = True
        Me.lblPhotosInGroupNum.Location = New System.Drawing.Point(156, 23)
        Me.lblPhotosInGroupNum.Name = "lblPhotosInGroupNum"
        Me.lblPhotosInGroupNum.Size = New System.Drawing.Size(18, 20)
        Me.lblPhotosInGroupNum.TabIndex = 30
        Me.lblPhotosInGroupNum.Text = "0"
        '
        'lblGroupDateVal
        '
        Me.lblGroupDateVal.AutoSize = True
        Me.lblGroupDateVal.Location = New System.Drawing.Point(368, 23)
        Me.lblGroupDateVal.Name = "lblGroupDateVal"
        Me.lblGroupDateVal.Size = New System.Drawing.Size(88, 20)
        Me.lblGroupDateVal.TabIndex = 32
        Me.lblGroupDateVal.Text = "Jan 1 2013"
        '
        'lblGroupDate
        '
        Me.lblGroupDate.AutoSize = True
        Me.lblGroupDate.Location = New System.Drawing.Point(238, 23)
        Me.lblGroupDate.Name = "lblGroupDate"
        Me.lblGroupDate.Size = New System.Drawing.Size(97, 20)
        Me.lblGroupDate.TabIndex = 31
        Me.lblGroupDate.Text = "Group Date:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSlash3)
        Me.GroupBox1.Controls.Add(Me.lblFolder1)
        Me.GroupBox1.Controls.Add(Me.lblFolder2)
        Me.GroupBox1.Controls.Add(Me.lblSlash2)
        Me.GroupBox1.Controls.Add(Me.lblFolder3)
        Me.GroupBox1.Controls.Add(Me.lblFolder4)
        Me.GroupBox1.Controls.Add(Me.lblSlash1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 186)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 81)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assigned Folder"
        '
        'lblSlash3
        '
        Me.lblSlash3.AutoSize = True
        Me.lblSlash3.Location = New System.Drawing.Point(722, 38)
        Me.lblSlash3.Name = "lblSlash3"
        Me.lblSlash3.Size = New System.Drawing.Size(13, 20)
        Me.lblSlash3.TabIndex = 42
        Me.lblSlash3.Text = "\"
        '
        'lblFolder1
        '
        Me.lblFolder1.BackColor = System.Drawing.Color.PaleGreen
        Me.lblFolder1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFolder1.Location = New System.Drawing.Point(22, 32)
        Me.lblFolder1.Name = "lblFolder1"
        Me.lblFolder1.Size = New System.Drawing.Size(209, 30)
        Me.lblFolder1.TabIndex = 36
        Me.lblFolder1.Text = "Folder1"
        Me.lblFolder1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolder2
        '
        Me.lblFolder2.BackColor = System.Drawing.Color.PaleGreen
        Me.lblFolder2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFolder2.Location = New System.Drawing.Point(262, 32)
        Me.lblFolder2.Name = "lblFolder2"
        Me.lblFolder2.Size = New System.Drawing.Size(209, 30)
        Me.lblFolder2.TabIndex = 37
        Me.lblFolder2.Text = "Folder2"
        Me.lblFolder2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSlash2
        '
        Me.lblSlash2.AutoSize = True
        Me.lblSlash2.Location = New System.Drawing.Point(480, 38)
        Me.lblSlash2.Name = "lblSlash2"
        Me.lblSlash2.Size = New System.Drawing.Size(13, 20)
        Me.lblSlash2.TabIndex = 41
        Me.lblSlash2.Text = "\"
        '
        'lblFolder3
        '
        Me.lblFolder3.BackColor = System.Drawing.Color.PaleGreen
        Me.lblFolder3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFolder3.Location = New System.Drawing.Point(504, 32)
        Me.lblFolder3.Name = "lblFolder3"
        Me.lblFolder3.Size = New System.Drawing.Size(209, 30)
        Me.lblFolder3.TabIndex = 38
        Me.lblFolder3.Text = "Folder3"
        Me.lblFolder3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolder4
        '
        Me.lblFolder4.BackColor = System.Drawing.Color.PapayaWhip
        Me.lblFolder4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFolder4.Location = New System.Drawing.Point(747, 32)
        Me.lblFolder4.Name = "lblFolder4"
        Me.lblFolder4.Size = New System.Drawing.Size(209, 30)
        Me.lblFolder4.TabIndex = 39
        Me.lblFolder4.Text = "Folder4"
        Me.lblFolder4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSlash1
        '
        Me.lblSlash1.AutoSize = True
        Me.lblSlash1.Location = New System.Drawing.Point(238, 38)
        Me.lblSlash1.Name = "lblSlash1"
        Me.lblSlash1.Size = New System.Drawing.Size(13, 20)
        Me.lblSlash1.TabIndex = 40
        Me.lblSlash1.Text = "\"
        '
        'AllPhotosBox
        '
        Me.AllPhotosBox.Controls.Add(Me.lblPhotosInDestination)
        Me.AllPhotosBox.Controls.Add(Me.lblPhotosInSource)
        Me.AllPhotosBox.Controls.Add(Me.lblPhotosInSourceNum)
        Me.AllPhotosBox.Controls.Add(Me.lblSourcePhotoGroups)
        Me.AllPhotosBox.Controls.Add(Me.lblSourcePhotoGroupsNum)
        Me.AllPhotosBox.Controls.Add(Me.lblDuplicatePhotos)
        Me.AllPhotosBox.Controls.Add(Me.lblDuplicatePhotosNum)
        Me.AllPhotosBox.Controls.Add(Me.lblPhotosInDestinationNum)
        Me.AllPhotosBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AllPhotosBox.Location = New System.Drawing.Point(13, 98)
        Me.AllPhotosBox.Name = "AllPhotosBox"
        Me.AllPhotosBox.Size = New System.Drawing.Size(478, 76)
        Me.AllPhotosBox.TabIndex = 33
        Me.AllPhotosBox.TabStop = False
        Me.AllPhotosBox.Text = "All Photos"
        '
        'lblPhotosInDestination
        '
        Me.lblPhotosInDestination.AutoSize = True
        Me.lblPhotosInDestination.Location = New System.Drawing.Point(238, 25)
        Me.lblPhotosInDestination.Name = "lblPhotosInDestination"
        Me.lblPhotosInDestination.Size = New System.Drawing.Size(164, 20)
        Me.lblPhotosInDestination.TabIndex = 25
        Me.lblPhotosInDestination.Text = "Photos in Destination:"
        '
        'lblPhotosInSource
        '
        Me.lblPhotosInSource.AutoSize = True
        Me.lblPhotosInSource.Location = New System.Drawing.Point(6, 25)
        Me.lblPhotosInSource.Name = "lblPhotosInSource"
        Me.lblPhotosInSource.Size = New System.Drawing.Size(134, 20)
        Me.lblPhotosInSource.TabIndex = 19
        Me.lblPhotosInSource.Text = "Photos in Source:"
        '
        'lblPhotosInSourceNum
        '
        Me.lblPhotosInSourceNum.AutoSize = True
        Me.lblPhotosInSourceNum.Location = New System.Drawing.Point(156, 25)
        Me.lblPhotosInSourceNum.Name = "lblPhotosInSourceNum"
        Me.lblPhotosInSourceNum.Size = New System.Drawing.Size(18, 20)
        Me.lblPhotosInSourceNum.TabIndex = 20
        Me.lblPhotosInSourceNum.Text = "0"
        '
        'lblSourcePhotoGroups
        '
        Me.lblSourcePhotoGroups.AutoSize = True
        Me.lblSourcePhotoGroups.Location = New System.Drawing.Point(6, 46)
        Me.lblSourcePhotoGroups.Name = "lblSourcePhotoGroups"
        Me.lblSourcePhotoGroups.Size = New System.Drawing.Size(116, 20)
        Me.lblSourcePhotoGroups.TabIndex = 21
        Me.lblSourcePhotoGroups.Text = "Groups Found:"
        '
        'lblSourcePhotoGroupsNum
        '
        Me.lblSourcePhotoGroupsNum.AutoSize = True
        Me.lblSourcePhotoGroupsNum.Location = New System.Drawing.Point(156, 46)
        Me.lblSourcePhotoGroupsNum.Name = "lblSourcePhotoGroupsNum"
        Me.lblSourcePhotoGroupsNum.Size = New System.Drawing.Size(18, 20)
        Me.lblSourcePhotoGroupsNum.TabIndex = 22
        Me.lblSourcePhotoGroupsNum.Text = "0"
        '
        'lblDuplicatePhotos
        '
        Me.lblDuplicatePhotos.AutoSize = True
        Me.lblDuplicatePhotos.Location = New System.Drawing.Point(238, 46)
        Me.lblDuplicatePhotos.Name = "lblDuplicatePhotos"
        Me.lblDuplicatePhotos.Size = New System.Drawing.Size(134, 20)
        Me.lblDuplicatePhotos.TabIndex = 23
        Me.lblDuplicatePhotos.Text = "Duplicate Photos:"
        '
        'lblDuplicatePhotosNum
        '
        Me.lblDuplicatePhotosNum.AutoSize = True
        Me.lblDuplicatePhotosNum.Location = New System.Drawing.Point(418, 46)
        Me.lblDuplicatePhotosNum.Name = "lblDuplicatePhotosNum"
        Me.lblDuplicatePhotosNum.Size = New System.Drawing.Size(18, 20)
        Me.lblDuplicatePhotosNum.TabIndex = 24
        Me.lblDuplicatePhotosNum.Text = "0"
        '
        'lblPhotosInDestinationNum
        '
        Me.lblPhotosInDestinationNum.AutoSize = True
        Me.lblPhotosInDestinationNum.Location = New System.Drawing.Point(418, 25)
        Me.lblPhotosInDestinationNum.Name = "lblPhotosInDestinationNum"
        Me.lblPhotosInDestinationNum.Size = New System.Drawing.Size(18, 20)
        Me.lblPhotosInDestinationNum.TabIndex = 26
        Me.lblPhotosInDestinationNum.Text = "0"
        '
        'pnlLogo
        '
        Me.pnlLogo.BackgroundImage = CType(resources.GetObject("pnlLogo.BackgroundImage"), System.Drawing.Image)
        Me.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlLogo.Location = New System.Drawing.Point(11, 9)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(451, 79)
        Me.pnlLogo.TabIndex = 0
        '
        'cmdNextGroup
        '
        Me.cmdNextGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdNextGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cmdNextGroup.Location = New System.Drawing.Point(209, 613)
        Me.cmdNextGroup.Name = "cmdNextGroup"
        Me.cmdNextGroup.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.cmdNextGroup.Size = New System.Drawing.Size(170, 33)
        Me.cmdNextGroup.TabIndex = 15
        Me.cmdNextGroup.Text = "Next Group >>"
        Me.cmdNextGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNextGroup.UseVisualStyleBackColor = False
        '
        'ContainerTabsLevels
        '
        Me.ContainerTabsLevels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContainerTabsLevels.Controls.Add(Me.tabLevel1)
        Me.ContainerTabsLevels.Controls.Add(Me.tabLevel2)
        Me.ContainerTabsLevels.Controls.Add(Me.tabLevel3)
        Me.ContainerTabsLevels.Controls.Add(Me.tabLevel4)
        Me.ContainerTabsLevels.Location = New System.Drawing.Point(15, 286)
        Me.ContainerTabsLevels.Name = "ContainerTabsLevels"
        Me.ContainerTabsLevels.SelectedIndex = 0
        Me.ContainerTabsLevels.Size = New System.Drawing.Size(1001, 309)
        Me.ContainerTabsLevels.TabIndex = 15
        '
        'tabLevel1
        '
        Me.tabLevel1.AutoScroll = True
        Me.tabLevel1.BackColor = System.Drawing.Color.White
        Me.tabLevel1.Controls.Add(Me.cmdLevel1Add)
        Me.tabLevel1.Controls.Add(Me.txtLevel1New)
        Me.tabLevel1.Location = New System.Drawing.Point(4, 29)
        Me.tabLevel1.Name = "tabLevel1"
        Me.tabLevel1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLevel1.Size = New System.Drawing.Size(993, 276)
        Me.tabLevel1.TabIndex = 0
        Me.tabLevel1.Text = "Level 1 Folders"
        '
        'cmdLevel1Add
        '
        Me.cmdLevel1Add.BackColor = System.Drawing.Color.White
        Me.cmdLevel1Add.Location = New System.Drawing.Point(366, 12)
        Me.cmdLevel1Add.Name = "cmdLevel1Add"
        Me.cmdLevel1Add.Size = New System.Drawing.Size(153, 29)
        Me.cmdLevel1Add.TabIndex = 1
        Me.cmdLevel1Add.Text = "Add Folder Name"
        Me.cmdLevel1Add.UseVisualStyleBackColor = False
        '
        'txtLevel1New
        '
        Me.txtLevel1New.Location = New System.Drawing.Point(9, 12)
        Me.txtLevel1New.Name = "txtLevel1New"
        Me.txtLevel1New.Size = New System.Drawing.Size(344, 26)
        Me.txtLevel1New.TabIndex = 0
        '
        'tabLevel2
        '
        Me.tabLevel2.BackColor = System.Drawing.Color.White
        Me.tabLevel2.Controls.Add(Me.cmdLevel2Add)
        Me.tabLevel2.Controls.Add(Me.txtLevel2New)
        Me.tabLevel2.Location = New System.Drawing.Point(4, 29)
        Me.tabLevel2.Name = "tabLevel2"
        Me.tabLevel2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLevel2.Size = New System.Drawing.Size(989, 273)
        Me.tabLevel2.TabIndex = 1
        Me.tabLevel2.Text = "Level 2 Folders"
        '
        'cmdLevel2Add
        '
        Me.cmdLevel2Add.BackColor = System.Drawing.Color.White
        Me.cmdLevel2Add.Location = New System.Drawing.Point(366, 12)
        Me.cmdLevel2Add.Name = "cmdLevel2Add"
        Me.cmdLevel2Add.Size = New System.Drawing.Size(153, 29)
        Me.cmdLevel2Add.TabIndex = 3
        Me.cmdLevel2Add.Text = "Add Folder Name"
        Me.cmdLevel2Add.UseVisualStyleBackColor = False
        '
        'txtLevel2New
        '
        Me.txtLevel2New.Location = New System.Drawing.Point(9, 12)
        Me.txtLevel2New.Name = "txtLevel2New"
        Me.txtLevel2New.Size = New System.Drawing.Size(344, 26)
        Me.txtLevel2New.TabIndex = 2
        '
        'tabLevel3
        '
        Me.tabLevel3.BackColor = System.Drawing.Color.White
        Me.tabLevel3.Controls.Add(Me.cmdLevel3Add)
        Me.tabLevel3.Controls.Add(Me.txtLevel3New)
        Me.tabLevel3.Location = New System.Drawing.Point(4, 29)
        Me.tabLevel3.Name = "tabLevel3"
        Me.tabLevel3.Size = New System.Drawing.Size(989, 273)
        Me.tabLevel3.TabIndex = 2
        Me.tabLevel3.Text = "Level 3 Folders"
        '
        'cmdLevel3Add
        '
        Me.cmdLevel3Add.BackColor = System.Drawing.Color.White
        Me.cmdLevel3Add.Location = New System.Drawing.Point(366, 12)
        Me.cmdLevel3Add.Name = "cmdLevel3Add"
        Me.cmdLevel3Add.Size = New System.Drawing.Size(153, 29)
        Me.cmdLevel3Add.TabIndex = 5
        Me.cmdLevel3Add.Text = "Add Folder Name"
        Me.cmdLevel3Add.UseVisualStyleBackColor = False
        '
        'txtLevel3New
        '
        Me.txtLevel3New.Location = New System.Drawing.Point(10, 12)
        Me.txtLevel3New.Name = "txtLevel3New"
        Me.txtLevel3New.Size = New System.Drawing.Size(344, 26)
        Me.txtLevel3New.TabIndex = 4
        '
        'tabLevel4
        '
        Me.tabLevel4.BackColor = System.Drawing.Color.White
        Me.tabLevel4.Controls.Add(Me.cmdLevel4Add)
        Me.tabLevel4.Controls.Add(Me.txtLevel4New)
        Me.tabLevel4.Location = New System.Drawing.Point(4, 29)
        Me.tabLevel4.Name = "tabLevel4"
        Me.tabLevel4.Size = New System.Drawing.Size(989, 273)
        Me.tabLevel4.TabIndex = 3
        Me.tabLevel4.Text = "Level 4 Folders"
        '
        'cmdLevel4Add
        '
        Me.cmdLevel4Add.BackColor = System.Drawing.Color.White
        Me.cmdLevel4Add.Location = New System.Drawing.Point(366, 12)
        Me.cmdLevel4Add.Name = "cmdLevel4Add"
        Me.cmdLevel4Add.Size = New System.Drawing.Size(153, 29)
        Me.cmdLevel4Add.TabIndex = 5
        Me.cmdLevel4Add.Text = "Add Folder Name"
        Me.cmdLevel4Add.UseVisualStyleBackColor = False
        '
        'txtLevel4New
        '
        Me.txtLevel4New.Location = New System.Drawing.Point(10, 12)
        Me.txtLevel4New.Name = "txtLevel4New"
        Me.txtLevel4New.Size = New System.Drawing.Size(344, 26)
        Me.txtLevel4New.TabIndex = 4
        '
        'cmdPrevGroup
        '
        Me.cmdPrevGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPrevGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cmdPrevGroup.Location = New System.Drawing.Point(16, 613)
        Me.cmdPrevGroup.Name = "cmdPrevGroup"
        Me.cmdPrevGroup.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.cmdPrevGroup.Size = New System.Drawing.Size(169, 33)
        Me.cmdPrevGroup.TabIndex = 16
        Me.cmdPrevGroup.Text = "<< Previous Group"
        Me.cmdPrevGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPrevGroup.UseVisualStyleBackColor = False
        '
        'ImagePreviewPane
        '
        Me.ImagePreviewPane.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ImagePreviewPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ImagePreviewPane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePreviewPane.Location = New System.Drawing.Point(22, 25)
        Me.ImagePreviewPane.Name = "ImagePreviewPane"
        Me.ImagePreviewPane.Padding = New System.Windows.Forms.Padding(3)
        Me.ImagePreviewPane.Size = New System.Drawing.Size(382, 604)
        Me.ImagePreviewPane.TabIndex = 0
        '
        'PhotoViewer
        '
        Me.PhotoViewer.BackColor = System.Drawing.Color.White
        Me.PhotoViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PhotoViewer.Location = New System.Drawing.Point(0, 0)
        Me.PhotoViewer.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.PhotoViewer.Name = "PhotoViewer"
        Me.PhotoViewer.Size = New System.Drawing.Size(1480, 159)
        Me.PhotoViewer.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1482, 822)
        Me.Controls.Add(Me.ContainerHorizSplit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Photos2Folders"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContainerHorizSplit.Panel1.ResumeLayout(False)
        Me.ContainerHorizSplit.Panel2.ResumeLayout(False)
        CType(Me.ContainerHorizSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContainerHorizSplit.ResumeLayout(False)
        Me.ContainerTopVertSplit.Panel1.ResumeLayout(False)
        Me.ContainerTopVertSplit.Panel2.ResumeLayout(False)
        CType(Me.ContainerTopVertSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContainerTopVertSplit.ResumeLayout(False)
        Me.pnlMainSection.ResumeLayout(False)
        Me.CurrentGroupBox.ResumeLayout(False)
        Me.CurrentGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.AllPhotosBox.ResumeLayout(False)
        Me.AllPhotosBox.PerformLayout()
        Me.ContainerTabsLevels.ResumeLayout(False)
        Me.tabLevel1.ResumeLayout(False)
        Me.tabLevel1.PerformLayout()
        Me.tabLevel2.ResumeLayout(False)
        Me.tabLevel2.PerformLayout()
        Me.tabLevel3.ResumeLayout(False)
        Me.tabLevel3.PerformLayout()
        Me.tabLevel4.ResumeLayout(False)
        Me.tabLevel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContainerHorizSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents PhotoViewer As Photos2Folders.PhotoViewer
    Friend WithEvents ContainerTopVertSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents ImagePreviewPane As Photos2Folders.CustomPanel
    Friend WithEvents pnlLogo As System.Windows.Forms.Panel
    Friend WithEvents ContainerTabsLevels As System.Windows.Forms.TabControl
    Friend WithEvents tabLevel1 As System.Windows.Forms.TabPage
    Friend WithEvents tabLevel2 As System.Windows.Forms.TabPage
    Friend WithEvents tabLevel3 As System.Windows.Forms.TabPage
    Friend WithEvents tabLevel4 As System.Windows.Forms.TabPage
    Friend WithEvents cmdNextGroup As System.Windows.Forms.Button
    Friend WithEvents cmdPrevGroup As System.Windows.Forms.Button
    Friend WithEvents lblDuplicatePhotosNum As System.Windows.Forms.Label
    Friend WithEvents lblDuplicatePhotos As System.Windows.Forms.Label
    Friend WithEvents lblSourcePhotoGroupsNum As System.Windows.Forms.Label
    Friend WithEvents lblSourcePhotoGroups As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInSourceNum As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInSource As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInDestination As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInDestinationNum As System.Windows.Forms.Label
    Friend WithEvents AllPhotosBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblGroupDateVal As System.Windows.Forms.Label
    Friend WithEvents lblGroupDate As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInGroupNum As System.Windows.Forms.Label
    Friend WithEvents lblPhotosInGroup As System.Windows.Forms.Label
    Friend WithEvents CurrentGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblGroupNumberVal As System.Windows.Forms.Label
    Friend WithEvents lblGroupNumber As System.Windows.Forms.Label
    Friend WithEvents lblSlash3 As System.Windows.Forms.Label
    Friend WithEvents lblSlash2 As System.Windows.Forms.Label
    Friend WithEvents lblSlash1 As System.Windows.Forms.Label
    Friend WithEvents lblFolder4 As System.Windows.Forms.Label
    Friend WithEvents lblFolder3 As System.Windows.Forms.Label
    Friend WithEvents lblFolder2 As System.Windows.Forms.Label
    Friend WithEvents lblFolder1 As System.Windows.Forms.Label
    Friend WithEvents txtLevel1New As System.Windows.Forms.TextBox
    Friend WithEvents cmdLevel1Add As System.Windows.Forms.Button
    Friend WithEvents cmdLevel2Add As System.Windows.Forms.Button
    Friend WithEvents txtLevel2New As System.Windows.Forms.TextBox
    Friend WithEvents cmdLevel3Add As System.Windows.Forms.Button
    Friend WithEvents txtLevel3New As System.Windows.Forms.TextBox
    Friend WithEvents cmdLevel4Add As System.Windows.Forms.Button
    Friend WithEvents txtLevel4New As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents pnlMainSection As System.Windows.Forms.Panel

End Class
