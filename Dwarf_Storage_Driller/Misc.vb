Class Misc
    Private _MainFormInstance As MainForm

    ''' <summary>
    ''' Get instance of the Main form.
    ''' </summary>
    ''' <param name="mainFormInstance"></param>
    Public Sub New(ByRef mainFormInstance As MainForm)
        _MainFormInstance = mainFormInstance
    End Sub

    ''' <summary>
    ''' Start or stop marquee progress bar animation and show the ProgressLabel.
    ''' </summary>
    ''' <param name="startAnimation">True to star and show, False to stop and hide</param>
    Public Sub HandleProgressBar(startAnimation As Boolean)
        _MainFormInstance.ProgBar.Visible = startAnimation
        _MainFormInstance.ProgressLabel.Visible = startAnimation
        _MainFormInstance.ProgBar.MarqueeAnimationSpeed = IIf(startAnimation, 70, 0)
    End Sub


    ''' <summary>
    ''' Enable or disable buttons.
    ''' </summary>
    Public Sub HandleButtons(enabled As Boolean)
        _MainFormInstance.SelectFolderButton.Enabled = enabled
        _MainFormInstance.DrillDownButton.Enabled = enabled
    End Sub

End Class
