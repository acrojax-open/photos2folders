<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.pnlSortOptions = New System.Windows.Forms.Panel()
        Me.ContainerTabOptions = New System.Windows.Forms.TabControl()
        Me.tabOptionsFolders = New System.Windows.Forms.TabPage()
        Me.lblExampleLevelPath = New System.Windows.Forms.Label()
        Me.cmbOptLevel4 = New System.Windows.Forms.ComboBox()
        Me.lblOptLevel4 = New System.Windows.Forms.Label()
        Me.cmbOptLevel3 = New System.Windows.Forms.ComboBox()
        Me.lblOptLevel3 = New System.Windows.Forms.Label()
        Me.cmbOptLevel2 = New System.Windows.Forms.ComboBox()
        Me.lblOptLevel2 = New System.Windows.Forms.Label()
        Me.lblOptLevel1 = New System.Windows.Forms.Label()
        Me.cmbOptLevel1 = New System.Windows.Forms.ComboBox()
        Me.tabOptionsFilters = New System.Windows.Forms.TabPage()
        Me.chkOptionMoveFiles = New System.Windows.Forms.CheckBox()
        Me.lblOptionDuplicate = New System.Windows.Forms.Label()
        Me.cmbDuplicate = New System.Windows.Forms.ComboBox()
        Me.chkOptionIgnoreDotStart = New System.Windows.Forms.CheckBox()
        Me.chkOptionDateTaken = New System.Windows.Forms.CheckBox()
        Me.lblStep1 = New System.Windows.Forms.Label()
        Me.lblStep1Desc = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.cmdBrowseSource = New System.Windows.Forms.Button()
        Me.cmdBrowseDest = New System.Windows.Forms.Button()
        Me.lblDest = New System.Windows.Forms.Label()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pnlSortOptions.SuspendLayout()
        Me.ContainerTabOptions.SuspendLayout()
        Me.tabOptionsFolders.SuspendLayout()
        Me.tabOptionsFilters.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSortOptions
        '
        Me.pnlSortOptions.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlSortOptions.BackColor = System.Drawing.SystemColors.Window
        Me.pnlSortOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSortOptions.Controls.Add(Me.ContainerTabOptions)
        Me.pnlSortOptions.Controls.Add(Me.lblStep1)
        Me.pnlSortOptions.Controls.Add(Me.lblStep1Desc)
        Me.pnlSortOptions.Controls.Add(Me.lblSource)
        Me.pnlSortOptions.Controls.Add(Me.txtSource)
        Me.pnlSortOptions.Controls.Add(Me.cmdBrowseSource)
        Me.pnlSortOptions.Controls.Add(Me.cmdBrowseDest)
        Me.pnlSortOptions.Controls.Add(Me.lblDest)
        Me.pnlSortOptions.Controls.Add(Me.cmdStart)
        Me.pnlSortOptions.Controls.Add(Me.txtDest)
        Me.pnlSortOptions.Location = New System.Drawing.Point(50, 50)
        Me.pnlSortOptions.Name = "pnlSortOptions"
        Me.pnlSortOptions.Size = New System.Drawing.Size(968, 582)
        Me.pnlSortOptions.TabIndex = 4
        '
        'ContainerTabOptions
        '
        Me.ContainerTabOptions.Controls.Add(Me.tabOptionsFolders)
        Me.ContainerTabOptions.Controls.Add(Me.tabOptionsFilters)
        Me.ContainerTabOptions.Location = New System.Drawing.Point(18, 260)
        Me.ContainerTabOptions.Name = "ContainerTabOptions"
        Me.ContainerTabOptions.SelectedIndex = 0
        Me.ContainerTabOptions.Size = New System.Drawing.Size(924, 257)
        Me.ContainerTabOptions.TabIndex = 15
        '
        'tabOptionsFolders
        '
        Me.tabOptionsFolders.Controls.Add(Me.lblExampleLevelPath)
        Me.tabOptionsFolders.Controls.Add(Me.cmbOptLevel4)
        Me.tabOptionsFolders.Controls.Add(Me.lblOptLevel4)
        Me.tabOptionsFolders.Controls.Add(Me.cmbOptLevel3)
        Me.tabOptionsFolders.Controls.Add(Me.lblOptLevel3)
        Me.tabOptionsFolders.Controls.Add(Me.cmbOptLevel2)
        Me.tabOptionsFolders.Controls.Add(Me.lblOptLevel2)
        Me.tabOptionsFolders.Controls.Add(Me.lblOptLevel1)
        Me.tabOptionsFolders.Controls.Add(Me.cmbOptLevel1)
        Me.tabOptionsFolders.Location = New System.Drawing.Point(4, 29)
        Me.tabOptionsFolders.Name = "tabOptionsFolders"
        Me.tabOptionsFolders.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOptionsFolders.Size = New System.Drawing.Size(916, 224)
        Me.tabOptionsFolders.TabIndex = 0
        Me.tabOptionsFolders.Text = "Folders"
        Me.tabOptionsFolders.UseVisualStyleBackColor = True
        '
        'lblExampleLevelPath
        '
        Me.lblExampleLevelPath.AutoSize = True
        Me.lblExampleLevelPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExampleLevelPath.Location = New System.Drawing.Point(6, 12)
        Me.lblExampleLevelPath.Name = "lblExampleLevelPath"
        Me.lblExampleLevelPath.Size = New System.Drawing.Size(339, 20)
        Me.lblExampleLevelPath.TabIndex = 8
        Me.lblExampleLevelPath.Text = "Example Folder: C:\2012\02-Feb\Birthday Party"
        '
        'cmbOptLevel4
        '
        Me.cmbOptLevel4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptLevel4.FormattingEnabled = True
        Me.cmbOptLevel4.Items.AddRange(New Object() {"Event Name", "Year", "Month", "Day", "(None)"})
        Me.cmbOptLevel4.Location = New System.Drawing.Point(123, 165)
        Me.cmbOptLevel4.Name = "cmbOptLevel4"
        Me.cmbOptLevel4.Size = New System.Drawing.Size(223, 28)
        Me.cmbOptLevel4.TabIndex = 7
        '
        'lblOptLevel4
        '
        Me.lblOptLevel4.AutoSize = True
        Me.lblOptLevel4.Location = New System.Drawing.Point(6, 169)
        Me.lblOptLevel4.Name = "lblOptLevel4"
        Me.lblOptLevel4.Size = New System.Drawing.Size(112, 20)
        Me.lblOptLevel4.TabIndex = 6
        Me.lblOptLevel4.Text = "Level 4 Folder:"
        '
        'cmbOptLevel3
        '
        Me.cmbOptLevel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptLevel3.FormattingEnabled = True
        Me.cmbOptLevel3.Items.AddRange(New Object() {"Event Name", "Year", "Month", "Day", "(None)"})
        Me.cmbOptLevel3.Location = New System.Drawing.Point(123, 128)
        Me.cmbOptLevel3.Name = "cmbOptLevel3"
        Me.cmbOptLevel3.Size = New System.Drawing.Size(223, 28)
        Me.cmbOptLevel3.TabIndex = 5
        '
        'lblOptLevel3
        '
        Me.lblOptLevel3.AutoSize = True
        Me.lblOptLevel3.Location = New System.Drawing.Point(6, 131)
        Me.lblOptLevel3.Name = "lblOptLevel3"
        Me.lblOptLevel3.Size = New System.Drawing.Size(112, 20)
        Me.lblOptLevel3.TabIndex = 4
        Me.lblOptLevel3.Text = "Level 3 Folder:"
        '
        'cmbOptLevel2
        '
        Me.cmbOptLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptLevel2.FormattingEnabled = True
        Me.cmbOptLevel2.Items.AddRange(New Object() {"Event Name", "Year", "Month", "Day", "(None)"})
        Me.cmbOptLevel2.Location = New System.Drawing.Point(123, 89)
        Me.cmbOptLevel2.Name = "cmbOptLevel2"
        Me.cmbOptLevel2.Size = New System.Drawing.Size(223, 28)
        Me.cmbOptLevel2.TabIndex = 3
        '
        'lblOptLevel2
        '
        Me.lblOptLevel2.AutoSize = True
        Me.lblOptLevel2.Location = New System.Drawing.Point(6, 92)
        Me.lblOptLevel2.Name = "lblOptLevel2"
        Me.lblOptLevel2.Size = New System.Drawing.Size(112, 20)
        Me.lblOptLevel2.TabIndex = 2
        Me.lblOptLevel2.Text = "Level 2 Folder:"
        '
        'lblOptLevel1
        '
        Me.lblOptLevel1.AutoSize = True
        Me.lblOptLevel1.Location = New System.Drawing.Point(6, 55)
        Me.lblOptLevel1.Name = "lblOptLevel1"
        Me.lblOptLevel1.Size = New System.Drawing.Size(112, 20)
        Me.lblOptLevel1.TabIndex = 1
        Me.lblOptLevel1.Text = "Level 1 Folder:"
        '
        'cmbOptLevel1
        '
        Me.cmbOptLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptLevel1.FormattingEnabled = True
        Me.cmbOptLevel1.Items.AddRange(New Object() {"Event Name", "Year", "Month", "Day"})
        Me.cmbOptLevel1.Location = New System.Drawing.Point(123, 51)
        Me.cmbOptLevel1.Name = "cmbOptLevel1"
        Me.cmbOptLevel1.Size = New System.Drawing.Size(223, 28)
        Me.cmbOptLevel1.TabIndex = 0
        '
        'tabOptionsFilters
        '
        Me.tabOptionsFilters.Controls.Add(Me.chkOptionMoveFiles)
        Me.tabOptionsFilters.Controls.Add(Me.lblOptionDuplicate)
        Me.tabOptionsFilters.Controls.Add(Me.cmbDuplicate)
        Me.tabOptionsFilters.Controls.Add(Me.chkOptionIgnoreDotStart)
        Me.tabOptionsFilters.Controls.Add(Me.chkOptionDateTaken)
        Me.tabOptionsFilters.Location = New System.Drawing.Point(4, 29)
        Me.tabOptionsFilters.Name = "tabOptionsFilters"
        Me.tabOptionsFilters.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOptionsFilters.Size = New System.Drawing.Size(916, 224)
        Me.tabOptionsFilters.TabIndex = 1
        Me.tabOptionsFilters.Text = "Image Options"
        Me.tabOptionsFilters.UseVisualStyleBackColor = True
        '
        'chkOptionMoveFiles
        '
        Me.chkOptionMoveFiles.AutoSize = True
        Me.chkOptionMoveFiles.Location = New System.Drawing.Point(16, 78)
        Me.chkOptionMoveFiles.Name = "chkOptionMoveFiles"
        Me.chkOptionMoveFiles.Size = New System.Drawing.Size(237, 24)
        Me.chkOptionMoveFiles.TabIndex = 4
        Me.chkOptionMoveFiles.Text = "Move files instead of copying"
        Me.chkOptionMoveFiles.UseVisualStyleBackColor = True
        '
        'lblOptionDuplicate
        '
        Me.lblOptionDuplicate.AutoSize = True
        Me.lblOptionDuplicate.Location = New System.Drawing.Point(411, 15)
        Me.lblOptionDuplicate.Name = "lblOptionDuplicate"
        Me.lblOptionDuplicate.Size = New System.Drawing.Size(195, 20)
        Me.lblOptionDuplicate.TabIndex = 3
        Me.lblOptionDuplicate.Text = "If the photo is a duplicate: "
        '
        'cmbDuplicate
        '
        Me.cmbDuplicate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuplicate.FormattingEnabled = True
        Me.cmbDuplicate.Items.AddRange(New Object() {"Copy anyways", "Move to 'Duplicates' folder", "Skip duplicates (do nothing)"})
        Me.cmbDuplicate.Location = New System.Drawing.Point(615, 11)
        Me.cmbDuplicate.Name = "cmbDuplicate"
        Me.cmbDuplicate.Size = New System.Drawing.Size(276, 28)
        Me.cmbDuplicate.TabIndex = 2
        '
        'chkOptionIgnoreDotStart
        '
        Me.chkOptionIgnoreDotStart.AutoSize = True
        Me.chkOptionIgnoreDotStart.Location = New System.Drawing.Point(16, 46)
        Me.chkOptionIgnoreDotStart.Name = "chkOptionIgnoreDotStart"
        Me.chkOptionIgnoreDotStart.Size = New System.Drawing.Size(356, 24)
        Me.chkOptionIgnoreDotStart.TabIndex = 1
        Me.chkOptionIgnoreDotStart.Text = "Ignore files whose filename start with a period"
        Me.chkOptionIgnoreDotStart.UseVisualStyleBackColor = True
        '
        'chkOptionDateTaken
        '
        Me.chkOptionDateTaken.AutoSize = True
        Me.chkOptionDateTaken.Location = New System.Drawing.Point(16, 14)
        Me.chkOptionDateTaken.Name = "chkOptionDateTaken"
        Me.chkOptionDateTaken.Size = New System.Drawing.Size(270, 24)
        Me.chkOptionDateTaken.TabIndex = 0
        Me.chkOptionDateTaken.Text = "Use 'Date Taken' for JPG images"
        Me.chkOptionDateTaken.UseVisualStyleBackColor = True
        '
        'lblStep1
        '
        Me.lblStep1.AutoSize = True
        Me.lblStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep1.Location = New System.Drawing.Point(14, 86)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.Size = New System.Drawing.Size(452, 29)
        Me.lblStep1.TabIndex = 13
        Me.lblStep1.Text = "Step 1 - Choose your Photo Locations"
        '
        'lblStep1Desc
        '
        Me.lblStep1Desc.AutoSize = True
        Me.lblStep1Desc.Location = New System.Drawing.Point(15, 126)
        Me.lblStep1Desc.Name = "lblStep1Desc"
        Me.lblStep1Desc.Size = New System.Drawing.Size(920, 40)
        Me.lblStep1Desc.TabIndex = 14
        Me.lblStep1Desc.Text = resources.GetString("lblStep1Desc.Text")
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(15, 185)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(285, 20)
        Me.lblSource.TabIndex = 2
        Me.lblSource.Text = "These are the photos I want organized:"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(309, 182)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(592, 26)
        Me.txtSource.TabIndex = 1
        '
        'cmdBrowseSource
        '
        Me.cmdBrowseSource.BackColor = System.Drawing.SystemColors.Window
        Me.cmdBrowseSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdBrowseSource.Image = CType(resources.GetObject("cmdBrowseSource.Image"), System.Drawing.Image)
        Me.cmdBrowseSource.Location = New System.Drawing.Point(908, 178)
        Me.cmdBrowseSource.Name = "cmdBrowseSource"
        Me.cmdBrowseSource.Size = New System.Drawing.Size(34, 29)
        Me.cmdBrowseSource.TabIndex = 7
        Me.cmdBrowseSource.UseVisualStyleBackColor = False
        '
        'cmdBrowseDest
        '
        Me.cmdBrowseDest.BackColor = System.Drawing.SystemColors.Window
        Me.cmdBrowseDest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdBrowseDest.Image = Global.Photos2Folders.My.Resources.Resources.folder_horizontal_open
        Me.cmdBrowseDest.Location = New System.Drawing.Point(908, 215)
        Me.cmdBrowseDest.Name = "cmdBrowseDest"
        Me.cmdBrowseDest.Size = New System.Drawing.Size(34, 29)
        Me.cmdBrowseDest.TabIndex = 12
        Me.cmdBrowseDest.UseVisualStyleBackColor = False
        '
        'lblDest
        '
        Me.lblDest.AutoSize = True
        Me.lblDest.Location = New System.Drawing.Point(15, 220)
        Me.lblDest.Name = "lblDest"
        Me.lblDest.Size = New System.Drawing.Size(286, 20)
        Me.lblDest.TabIndex = 4
        Me.lblDest.Text = "I want the organized photos to go here:"
        '
        'cmdStart
        '
        Me.cmdStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Window
        Me.cmdStart.Image = Global.Photos2Folders.My.Resources.Resources.images
        Me.cmdStart.Location = New System.Drawing.Point(18, 526)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Padding = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.cmdStart.Size = New System.Drawing.Size(147, 37)
        Me.cmdStart.TabIndex = 11
        Me.cmdStart.Text = "Start Sorting"
        Me.cmdStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdStart.UseVisualStyleBackColor = False
        '
        'txtDest
        '
        Me.txtDest.Location = New System.Drawing.Point(309, 215)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(592, 26)
        Me.txtDest.TabIndex = 3
        '
        'pbLogo
        '
        Me.pbLogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbLogo.BackColor = System.Drawing.Color.White
        Me.pbLogo.BackgroundImage = CType(resources.GetObject("pbLogo.BackgroundImage"), System.Drawing.Image)
        Me.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLogo.Location = New System.Drawing.Point(18, 18)
        Me.pbLogo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(473, 99)
        Me.pbLogo.TabIndex = 16
        Me.pbLogo.TabStop = False
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1068, 669)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.pnlSortOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmStart"
        Me.Text = "Photos2Folders - Start"
        Me.pnlSortOptions.ResumeLayout(False)
        Me.pnlSortOptions.PerformLayout()
        Me.ContainerTabOptions.ResumeLayout(False)
        Me.tabOptionsFolders.ResumeLayout(False)
        Me.tabOptionsFolders.PerformLayout()
        Me.tabOptionsFilters.ResumeLayout(False)
        Me.tabOptionsFilters.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSortOptions As System.Windows.Forms.Panel
    Friend WithEvents ContainerTabOptions As System.Windows.Forms.TabControl
    Friend WithEvents tabOptionsFolders As System.Windows.Forms.TabPage
    Friend WithEvents lblExampleLevelPath As System.Windows.Forms.Label
    Friend WithEvents cmbOptLevel4 As System.Windows.Forms.ComboBox
    Friend WithEvents lblOptLevel4 As System.Windows.Forms.Label
    Friend WithEvents cmbOptLevel3 As System.Windows.Forms.ComboBox
    Friend WithEvents lblOptLevel3 As System.Windows.Forms.Label
    Friend WithEvents cmbOptLevel2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblOptLevel2 As System.Windows.Forms.Label
    Friend WithEvents lblOptLevel1 As System.Windows.Forms.Label
    Friend WithEvents cmbOptLevel1 As System.Windows.Forms.ComboBox
    Friend WithEvents tabOptionsFilters As System.Windows.Forms.TabPage
    Friend WithEvents lblOptionDuplicate As System.Windows.Forms.Label
    Friend WithEvents cmbDuplicate As System.Windows.Forms.ComboBox
    Friend WithEvents chkOptionIgnoreDotStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkOptionDateTaken As System.Windows.Forms.CheckBox
    Friend WithEvents lblStep1Desc As System.Windows.Forms.Label
    Friend WithEvents lblStep1 As System.Windows.Forms.Label
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowseSource As System.Windows.Forms.Button
    Friend WithEvents cmdBrowseDest As System.Windows.Forms.Button
    Friend WithEvents lblDest As System.Windows.Forms.Label
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents chkOptionMoveFiles As System.Windows.Forms.CheckBox
End Class
