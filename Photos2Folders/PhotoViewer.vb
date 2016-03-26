Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Reflection
Imports System.IO
Imports System.Threading
Imports System.Drawing.Drawing2D
Imports System.Globalization

Public Class PhotoViewer

#Region " Private variables"

    Private photoList As New List(Of XPhotoFile)         'Current list of photos in the control
    Private intPhotoIndex As Integer = 0            'Current visible photo in the list
    Private objSelectedPhoto As XPhotoFile = Nothing     'The selected photo in the list
    Private bolPanLeft As Boolean                   ' If true, pan left, if false, pan right
    Private bolAutoPan As Boolean                   ' If set to true, will continue to pan automatically
    Private intStartLeft As Integer                 ' Used to animate the scrolling
    Private imgDuplicateOverlay As Image

#End Region

    Public Event ThumbnailClick(strPhotoPath As String)

#Region "Photo Class"

#End Region

    ''' <summary>
    ''' Initialize the control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.Selectable, True)

        intStartLeft = 5
        imgDuplicateOverlay = My.Resources.ResourceManager.GetObject("overlay_duplicate")

    End Sub

    ''' <summary>
    ''' Load the current photo list in the thumbnail panel
    ''' </summary>
    ''' <param name="photoFiles">List of photos to load in the thumbnail view</param>
    ''' <remarks></remarks>
    Public Sub LoadPhotos(photoFiles As XPhotoSet)

        photoList = New List(Of XPhotoFile)

        For Each pfFile As XPhotoFile In photoFiles
            AddPhoto(pfFile)
        Next

    End Sub

    Public Sub AddPhoto(pfPhoto As XPhotoFile)
        '*** Add it to the list
        photoList.Add(pfPhoto)
    End Sub

    Public Sub ScrollToFirstPhoto()
        Dim intIndex As Integer
        If photoList.Count > 0 Then
            intIndex = (getPhotoCountWidth() / 2) - 2
            If intIndex > (photoList.Count / 2) Then
                intIndex = (photoList.Count / 2) - 1
            End If
            intPhotoIndex = intIndex
        End If
    End Sub

    Public Sub SelectPhoto(intSelectIndex As Integer)
        If photoList.Count > intSelectIndex Then
            objSelectedPhoto = photoList.Item(intSelectIndex)
            RaiseEvent ThumbnailClick(objSelectedPhoto.FilePath)
        End If
    End Sub

    ''' <summary>
    ''' When the panel is clicked, check if a photo should be selected or if the control should be scrolled left/right
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlThumbnails_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlThumbnails.MouseClick

        ' If they click on the far left, we pan the images left
        If e.X < 20 Then

        ElseIf e.X > pnlThumbnails.Width - 20 Then
            ' If they click on the far right, we pan the images right

        Else

            objSelectedPhoto = Nothing

            '*** Loop through each photo in the list to see if it was clicked
            For Each objPhoto In photoList

                Dim regTest As New Region(objPhoto.Bounds)

                '*** If the photo was selected, update the view and preview window
                If regTest.IsVisible(New Point(e.X, e.Y)) Then
                    objSelectedPhoto = objPhoto
                    RaiseEvent ThumbnailClick(objSelectedPhoto.FilePath)
                End If

            Next

            '*** If no photo was clicked then clear the preview window
            If objSelectedPhoto Is Nothing Then
                RaiseEvent ThumbnailClick("")
            End If

        End If

    End Sub

    Private Function getPhotoCountWidth()
        Dim rectBounds As New Rectangle(0, 0, pnlThumbnails.Width - 1, pnlThumbnails.Height / 1.4)
        Dim rectImage As New Rectangle(0, 0, rectBounds.Height - 10, rectBounds.Height - 10)
        Dim intRetCount As Integer
        intRetCount = rectBounds.Width / (rectImage.Width + 10)
        Return intRetCount
    End Function

    ''' <summary>
    ''' Paint the thumbnail panel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlThumbnails_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlThumbnails.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        '*** Initialize the variables
        Dim rectBounds As New Rectangle(0, 0, pnlThumbnails.Width - 1, pnlThumbnails.Height / 1.4)
        Dim rectImage As New Rectangle(0, 0, rectBounds.Height - 10, rectBounds.Height - 10)
        Dim blnDraw As Boolean = True
        Dim intLeft = intStartLeft
        Dim ftFont As New Font("Arial", Math.Min(rectBounds.Height / 9, 16), FontStyle.Regular, GraphicsUnit.Pixel)
        Dim sfStringFormat As New StringFormat

        sfStringFormat.Alignment = StringAlignment.Center

        '*** Figure out how many images will fit
        Dim intOffset As Integer = rectBounds.Width / (rectImage.Width + 10)

        '*** Set the offset index (to put the current photo in the middle of the control rather than the far left)
        intOffset = (intOffset / 2) - 1

        '*** Set the current index 
        Dim intCurrent As Integer = intPhotoIndex - intOffset

        '*** Draw each thumbnail
        While blnDraw

            '*** Check to see if we are past the width of the control
            If (intLeft < rectBounds.Width) Then

                '*** Make sure we are not at the end of the list
                If intCurrent < photoList.Count Then

                    '*** Only draw if the current index is at least 0
                    If (intCurrent >= 0) Then

                        Dim rectCurrent As New Rectangle(intLeft, 5, rectImage.Width, rectImage.Height)
                        Dim objCurrentPhoto As XPhotoFile = photoList(intCurrent)

                        objCurrentPhoto.Bounds = rectCurrent

                        Dim rectText As New Rectangle(rectCurrent.X, rectCurrent.Y + (rectCurrent.Height) + (rectBounds.Height / 10), rectCurrent.Width, rectCurrent.Height)

                        '*** Draw the text under the thumbnail
                        e.Graphics.DrawString(objCurrentPhoto.getThumbnailCaption, ftFont, Brushes.DarkGray, rectText, sfStringFormat)

                        '*** If the thumbnail image has been retrieved, draw it - otherwise, draw a black outline and retrieve the thumbnail asynchronously
                        If (objCurrentPhoto.Thumbnail Is Nothing) Then

                            e.Graphics.DrawRectangle(Pens.Black, rectCurrent)

                            '*** If the thumbnail is not already being retrieved, start the thread to get it
                            If (Not objCurrentPhoto.FetchingThumbnail) Then
                                Dim threadThumbnail As New Thread(New ThreadStart(AddressOf objCurrentPhoto.fetchThumbnail))
                                threadThumbnail.Start()
                            End If

                        Else

                            Dim intWidth As Integer = rectCurrent.Width
                            Dim intHeight As Integer = rectCurrent.Height

                            '*** Determine the rectangle to draw the thumbnail (depending on if it is wide or tall)
                            If (objCurrentPhoto.Thumbnail.Width > objCurrentPhoto.Thumbnail.Height) Then

                                intHeight = (intWidth * objCurrentPhoto.Thumbnail.Height) / objCurrentPhoto.Thumbnail.Width
                                rectCurrent = New Rectangle(rectCurrent.X, rectCurrent.Y + ((rectCurrent.Height - intHeight) / 2), rectCurrent.Width, intHeight)
                            Else

                                intWidth = (intHeight * objCurrentPhoto.Thumbnail.Width) / objCurrentPhoto.Thumbnail.Height
                                rectCurrent = New Rectangle(rectCurrent.X + ((rectCurrent.Width - intWidth) / 2), rectCurrent.Y, intWidth, intHeight)

                            End If

                            '*** Draw the shadow rectangle
                            Dim rectShadow As New Rectangle(rectCurrent.X + (rectBounds.Height / 20), rectCurrent.Y + (rectBounds.Height / 20), rectCurrent.Width, rectCurrent.Height)
                            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), rectShadow)

                            '*** Draw the thumbnail
                            e.Graphics.DrawImage(objCurrentPhoto.Thumbnail, rectCurrent)

                            '*** If it's a duplicate, draw the duplicate overlay
                            If objCurrentPhoto.DuplicateFlag = True Then
                                Dim rectDuplicateOverlay As Rectangle
                                If (rectCurrent.Width < rectCurrent.Height) Then
                                    rectDuplicateOverlay = New Rectangle(rectCurrent.X,
                                                                        rectCurrent.Y + (rectCurrent.Height / 2) - (rectCurrent.Width / 2),
                                                                        rectCurrent.Width,
                                                                        rectCurrent.Width)
                                Else
                                    rectDuplicateOverlay = New Rectangle(rectCurrent.X + (rectCurrent.Width / 2) - (rectCurrent.Height / 2),
                                                                        rectCurrent.Y,
                                                                        rectCurrent.Height,
                                                                        rectCurrent.Height)
                                End If

                                e.Graphics.DrawImage(imgDuplicateOverlay, rectDuplicateOverlay)
                            End If

                            '*** If the current thumbnail is the one selected, draw a red outline
                            If (Not objSelectedPhoto Is Nothing) Then
                                If (objCurrentPhoto.FilePath = objSelectedPhoto.FilePath) Then
                                    Dim pnOutline As New Pen(Color.Red, 2)
                                    e.Graphics.DrawRectangle(pnOutline, rectCurrent)
                                End If
                            End If

                        End If
                    End If

                Else
                    '*** Exit the loop
                    blnDraw = False
                End If
            Else
                '*** Exit the loop
                blnDraw = False
            End If

            '*** Increment the image index and the current position of the drawing
            intCurrent += 1
            intLeft = intLeft + rectImage.Width + 10

        End While

        Dim rectLeft = New Rectangle((rectBounds.Height / 2) - 2, 0, rectBounds.Height, pnlThumbnails.Height)
        Dim brLeft = New LinearGradientBrush(rectLeft, Color.White, Color.Transparent, 0)
        Dim rectRight = New Rectangle(rectBounds.X + rectBounds.Width - (rectBounds.Height * 3 / 2), 0, rectBounds.Height, pnlThumbnails.Height)
        Dim brRight = New LinearGradientBrush(rectRight, Color.Transparent, Color.White, 0)

        '*** Draw the left and right "fade" effect
        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(rectBounds.X, 0, (rectBounds.Height / 2) + 2, pnlThumbnails.Height))
        e.Graphics.FillRectangle(brLeft, New Rectangle(rectBounds.X + (rectBounds.Height / 2) - 1, 0, rectBounds.Height - 2, pnlThumbnails.Height))

        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(rectBounds.X + rectBounds.Width - (rectBounds.Height / 2) - 2, 0, (rectBounds.Height / 2) + 6, pnlThumbnails.Height))
        e.Graphics.FillRectangle(brRight, New Rectangle(rectBounds.X + rectBounds.Width - (rectBounds.Height * 3 / 2) + 2, 0, rectBounds.Height, pnlThumbnails.Height))

    End Sub

    Public Sub PanLeft()
        bolPanLeft = True
        MakeSmoothMove()
    End Sub

    Public Sub PanRight()
        bolPanLeft = False
        MakeSmoothMove()
    End Sub

    ''' <summary>
    ''' Refresh the drawing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick

        tmrRefresh.Enabled = False

        pnlThumbnails.Invalidate()

        tmrRefresh.Enabled = True
    End Sub

    ''' <summary>
    ''' Change the cursor image depending on where the position on the control is
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlThumbnails_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlThumbnails.MouseMove
        pnlThumbnails.Cursor = Cursors.Hand
        tmrPan.Enabled = False
    End Sub

    Private Sub tmrPan_Tick(sender As Object, e As EventArgs) Handles tmrPan.Tick
        If bolPanLeft Then
            PanLeft()
        Else
            PanRight()
        End If
    End Sub

    Private Sub MakeSmoothMove()
        If (intPhotoIndex > 0 And bolPanLeft) Or (intPhotoIndex < (photoList.Count - 1) And bolPanLeft = False) Then
            tmrSmoothMove.Enabled = True
        End If
    End Sub

    Private Sub tmrSmoothMove_Tick(sender As Object, e As EventArgs) Handles tmrSmoothMove.Tick
        Dim intThumbMove As Integer

        intThumbMove = (pnlThumbnails.Height / 1.4) + 1

        If bolPanLeft Then
            intStartLeft = intStartLeft + (intThumbMove / 5)
        Else
            intStartLeft = intStartLeft - (intThumbMove / 5)
        End If
        If intStartLeft > (5 + intThumbMove) Or intStartLeft < (5 - intThumbMove) Then
            tmrSmoothMove.Enabled = False
            If bolPanLeft Then
                intPhotoIndex = Math.Max(intPhotoIndex - 1, 0)
            Else
                intPhotoIndex = Math.Min(intPhotoIndex + 1, photoList.Count - 1)
            End If
            intStartLeft = 5
            If bolAutoPan Then
                MakeSmoothMove()
            Else
                tmrRefresh.Enabled = True
            End If
        End If
        pnlThumbnails.Invalidate()
    End Sub

    Private Sub pnlPanLeft_MouseEnter(sender As Object, e As EventArgs) Handles pnlPanLeft.MouseEnter
        pnlThumbnails.Cursor = Cursors.PanWest
        bolPanLeft = True
        MakeSmoothMove()
        bolAutoPan = True
    End Sub

    Private Sub pnlPanLeft_MouseLeave(sender As Object, e As EventArgs) Handles pnlPanLeft.MouseLeave
        bolAutoPan = False
    End Sub

    Private Sub pnlPanRight_MouseEnter(sender As Object, e As EventArgs) Handles pnlPanRight.MouseEnter
        pnlThumbnails.Cursor = Cursors.PanEast
        bolPanLeft = False
        MakeSmoothMove()
        bolAutoPan = True
    End Sub

    Private Sub pnlPanRight_MouseLeave(sender As Object, e As EventArgs) Handles pnlPanRight.MouseLeave
        bolAutoPan = False
    End Sub
End Class
