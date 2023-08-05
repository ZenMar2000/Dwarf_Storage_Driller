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
        _MainFormInstance.ProgBar.Style = ProgressBarStyle.Marquee
        _MainFormInstance.ProgBar.MarqueeAnimationSpeed = IIf(startAnimation, 70, 0)
    End Sub


    ''' <summary>
    ''' Enable or disable buttons.
    ''' </summary>
    Public Sub HandleButtons(enabled As Boolean)
        _MainFormInstance.SelectFolderButton.Enabled = enabled
        _MainFormInstance.NewDrillButton.Enabled = enabled
    End Sub

    Public Sub ClearAndCreateDataSource()
        _MainFormInstance.dtResult = New DataTable
        _MainFormInstance.dtResult.Columns.Add(Column_Level)
        _MainFormInstance.dtResult.Columns.Add(Column_Folder)
        _MainFormInstance.dtResult.Columns.Add(Column_Dimension)
        _MainFormInstance.dtResult.Columns.Add(Column_FullPath)

        SetDataSource()

    End Sub

    Public Sub SetDataSource()
        _MainFormInstance.ResultsDataGrid.DataSource = _MainFormInstance.dtResult
        _MainFormInstance.ResultsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        _MainFormInstance.DrillDownButton.Enabled = IIf(_MainFormInstance.ResultsDataGrid.Rows.Count > 0, True, False)
        _MainFormInstance.ResultsDataGrid.Sort(_MainFormInstance.ResultsDataGrid.Columns(Column_FullPath), ComponentModel.ListSortDirection.Ascending)

        _MainFormInstance.ResultsDataGrid.ClearSelection()

    End Sub

    Public Sub StartBackgroundWorker(operation As BackGroundOperation)
        Select Case operation
            Case BackGroundOperation.BeginNewDrillDown
                _MainFormInstance.DwarfDriller.RunWorkerAsync(New List(Of Object) From {_MainFormInstance.FolderPathTextBox.Text, BackGroundOperation.BeginNewDrillDown})

            Case BackGroundOperation.ContinueDrillDown
                _MainFormInstance.DwarfDriller.RunWorkerAsync(New List(Of Object) From {_MainFormInstance.ResultsDataGrid.SelectedRows, BackGroundOperation.ContinueDrillDown})

        End Select

    End Sub

End Class

Public Enum BackGroundOperation
    BeginNewDrillDown
    ContinueDrillDown
End Enum
