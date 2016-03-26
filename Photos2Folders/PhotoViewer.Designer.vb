<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhotoViewer
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPan = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSmoothMove = New System.Windows.Forms.Timer(Me.components)
        Me.pnlThumbnails = New Photos2Folders.CustomPanel()
        Me.pnlPanRight = New System.Windows.Forms.Panel()
        Me.pnlPanLeft = New System.Windows.Forms.Panel()
        Me.pnlThumbnails.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        Me.tmrRefresh.Interval = 500
        '
        'tmrPan
        '
        Me.tmrPan.Interval = 300
        '
        'tmrSmoothMove
        '
        Me.tmrSmoothMove.Interval = 40
        '
        'pnlThumbnails
        '
        Me.pnlThumbnails.Controls.Add(Me.pnlPanRight)
        Me.pnlThumbnails.Controls.Add(Me.pnlPanLeft)
        Me.pnlThumbnails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlThumbnails.Location = New System.Drawing.Point(0, 0)
        Me.pnlThumbnails.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlThumbnails.Name = "pnlThumbnails"
        Me.pnlThumbnails.Size = New System.Drawing.Size(635, 193)
        Me.pnlThumbnails.TabIndex = 1
        '
        'pnlPanRight
        '
        Me.pnlPanRight.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPanRight.BackgroundImage = Global.Photos2Folders.My.Resources.Resources.arrow_small_right
        Me.pnlPanRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlPanRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPanRight.Location = New System.Drawing.Point(591, 0)
        Me.pnlPanRight.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlPanRight.Name = "pnlPanRight"
        Me.pnlPanRight.Size = New System.Drawing.Size(44, 193)
        Me.pnlPanRight.TabIndex = 1
        '
        'pnlPanLeft
        '
        Me.pnlPanLeft.BackgroundImage = Global.Photos2Folders.My.Resources.Resources.arrow_small_left
        Me.pnlPanLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlPanLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPanLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlPanLeft.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlPanLeft.Name = "pnlPanLeft"
        Me.pnlPanLeft.Size = New System.Drawing.Size(44, 193)
        Me.pnlPanLeft.TabIndex = 0
        '
        'PhotoViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlThumbnails)
        Me.Name = "PhotoViewer"
        Me.Size = New System.Drawing.Size(635, 193)
        Me.pnlThumbnails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents pnlThumbnails As Photos2Folders.CustomPanel
    Friend WithEvents tmrPan As System.Windows.Forms.Timer
    Friend WithEvents tmrSmoothMove As System.Windows.Forms.Timer
    Friend WithEvents pnlPanLeft As System.Windows.Forms.Panel
    Friend WithEvents pnlPanRight As System.Windows.Forms.Panel

End Class
