<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressBox
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
        Me.pgsSet = New System.Windows.Forms.ProgressBar()
        Me.lblJobStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pgsSet
        '
        Me.pgsSet.Location = New System.Drawing.Point(24, 31)
        Me.pgsSet.Margin = New System.Windows.Forms.Padding(2)
        Me.pgsSet.Name = "pgsSet"
        Me.pgsSet.Size = New System.Drawing.Size(471, 19)
        Me.pgsSet.TabIndex = 10
        '
        'lblJobStatus
        '
        Me.lblJobStatus.AutoSize = True
        Me.lblJobStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblJobStatus.Location = New System.Drawing.Point(23, 12)
        Me.lblJobStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblJobStatus.Name = "lblJobStatus"
        Me.lblJobStatus.Size = New System.Drawing.Size(52, 13)
        Me.lblJobStatus.TabIndex = 11
        Me.lblJobStatus.Text = "Waiting..."
        Me.lblJobStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmProgressBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 63)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblJobStatus)
        Me.Controls.Add(Me.pgsSet)
        Me.Name = "frmProgressBox"
        Me.Text = "Just one second... this shouldn't take long"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pgsSet As System.Windows.Forms.ProgressBar
    Friend WithEvents lblJobStatus As System.Windows.Forms.Label
End Class
