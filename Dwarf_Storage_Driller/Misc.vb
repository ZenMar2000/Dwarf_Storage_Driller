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
    ''' Enable or disable buttons. Usuallu called before background workers starts or after they ends
    ''' </summary>
    Public Sub HandleButtons(enabled As Boolean)
        _MainFormInstance.SelectFolderButton.Enabled = enabled
        _MainFormInstance.NewDrillButton.Enabled = enabled
        _MainFormInstance.ScopeButton.Enabled = enabled
    End Sub

    ''' <summary>
    ''' Clear and reset the datasource connected to the data grid view.
    ''' </summary>
    Public Sub ClearAndCreateDataSource()
        _MainFormInstance.dtResult = New DataTable
        _MainFormInstance.dtResult.Columns.Add(Column_Level, GetType(String))
        _MainFormInstance.dtResult.Columns.Add(Column_Folder, GetType(String))
        _MainFormInstance.dtResult.Columns.Add(Column_Dimension, GetType(Double))
        _MainFormInstance.dtResult.Columns.Add(Column_FullPath, GetType(String))

        SetDataSource()

    End Sub

    ''' <summary>
    ''' Method for auto set and format the data grid view
    ''' </summary>
    Public Sub SetDataSource()
        _MainFormInstance.ResultsDataGrid.DataSource = _MainFormInstance.dtResult
        _MainFormInstance.ResultsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        _MainFormInstance.DrillDownButton.Enabled = IIf(_MainFormInstance.ResultsDataGrid.Rows.Count > 0, True, False)
        _MainFormInstance.ScopeButton.Enabled = _MainFormInstance.DrillDownButton.Enabled

        _MainFormInstance.ResultsDataGrid.Sort(_MainFormInstance.ResultsDataGrid.Columns(Column_FullPath), ComponentModel.ListSortDirection.Ascending)
        _MainFormInstance.ResultsDataGrid.ClearSelection()

    End Sub

    ''' <summary>
    ''' Main method used for calling and starting the background worker. There should not be any other way to start a bgw process other than adding new BackGroundOperation to the Enum and the Select in this method.
    ''' </summary>
    ''' <param name="operation"></param>
    Public Sub StartBackgroundWorker(operation As BackGroundOperation)
        Dim args As New BackGroundWorkerArguments(operation)

        'BackGroundWorker called using a list of 2 object. The first is an BackGroundOperation enum, while the second is a possible data needed by the bgw. 
        Select Case operation
            Case BackGroundOperation.BeginNewDrillDown
                args.Data = _MainFormInstance.FolderPathTextBox.Text
                _MainFormInstance.DwarfDriller.RunWorkerAsync(args)

            Case BackGroundOperation.ContinueDrillDown
                args.Data = _MainFormInstance.ResultsDataGrid.SelectedRows
                _MainFormInstance.DwarfDriller.RunWorkerAsync(args)

        End Select

    End Sub

End Class

''' <summary>
''' Used for handling which operation the background worker should do
''' </summary>
Public Class BackGroundWorkerArguments
    Public Property Operation As BackGroundOperation
    Public Property Data As Object

    Public Sub New(newOperation As BackGroundOperation, Optional newData As Object = Nothing)
        Operation = newOperation
        Data = newData
    End Sub
End Class

''' <summary>
''' Used for selecting which operation the background worker will do. Add more enums as needed, along with editing the sub StartBackgroundWorker()
''' </summary>
Public Enum BackGroundOperation
    BeginNewDrillDown
    ContinueDrillDown
End Enum
