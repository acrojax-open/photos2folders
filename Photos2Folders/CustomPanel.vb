Imports System.ComponentModel
Imports System.ComponentModel.Design

<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design")> _
Public Class CustomPanel
    Inherits System.Windows.Forms.Panel

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.Selectable, True)
    End Sub

End Class
