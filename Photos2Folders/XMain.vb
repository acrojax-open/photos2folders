Module XMain
    Public MainSorter As SorterControl
    Public AppOptions As ApplicationOptions
    Public ScaleRatio As Double
    Public WithEvents TheApp As Application

    Public Sub InitializeApplication()
        MainSorter = New SorterControl()
        AppOptions = ApplicationOptions.Instance
        ScaleRatio = 1.0
    End Sub

    Public Sub AboutMe()
        MsgBox("Photos2Folders v" & Application.ProductVersion, MsgBoxStyle.OkOnly, "About Photos2Folders...")
    End Sub

    Public Sub UnhandledException(ex As Exception)
        MsgBox("Uh oh... we've run into an unexpected error and unfortunately the application needs to close. " &
               "Please report the following error " &
               "to us on our website (www.photos2folders.com)." & vbCr & vbCr &
               ex.Message, MsgBoxStyle.OkOnly, "Uh oh...")
    End Sub

    Public Sub UnhandledPFException(pex As PFException)
        UnhandledException(pex)
    End Sub

End Module
