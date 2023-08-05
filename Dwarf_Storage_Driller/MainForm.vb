Imports System.ComponentModel
Imports System.IO

Public Class MainForm
#Region "Public variables"
    Public dtResult As New DataTable

#End Region

#Region "Private variables"
    Private misc As New Misc(Me)
    Private ddl As New DrillDownLogic(Me)

#End Region

#Region "Form Handlers"
    Private Sub OnShow_Form() Handles Me.Shown
        'Set version label with product version
        VersionLabel.Text = "Version: " & Application.ProductVersion

        'Reset progress label to empty string
        ProgressLabel.Text = ""

        'Precompile datatable columns. Will be used as datasource for the ResultDataGrid

        misc.ClearAndCreateDataSource()

    End Sub

#End Region

#Region "Button Handlers"
    Private Sub SelectPathButton_Click(sender As Object, e As EventArgs) Handles SelectFolderButton.Click
        'Get folder
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = FolderPathTextBox.Text

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FolderPathTextBox.Text = dialog.SelectedPath
        End If

        misc.ClearAndCreateDataSource()

    End Sub

    Private Sub NewDrillButton_Click(sender As Object, e As EventArgs) Handles NewDrillButton.Click
        'If directory does not exist, warn the user
        If Not Directory.Exists(FolderPathTextBox.Text) Then
            MsgBox("Target folder does not exists")
            Exit Sub
        End If

        misc.ClearAndCreateDataSource()
        misc.HandleProgressBar(True)
        misc.HandleButtons(False)

        misc.StartBackgroundWorker(BackGroundOperation.BeginNewDrillDown)

    End Sub

    Private Sub DrillDownButton_Click(sender As Object, e As EventArgs) Handles DrillDownButton.Click
        If ResultsDataGrid.SelectedRows.Count > 0 Then
            misc.StartBackgroundWorker(BackGroundOperation.ContinueDrillDown)

        Else
            MsgBox("No rows selected to drill down")

        End If
    End Sub


#End Region

#Region "Background worker"
    ''' <summary>
    ''' Needed a BackGroundWorkerArguments object as argument. Called by method Misc.StartBackgroundWorker()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DwarfDriller_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles DwarfDriller.DoWork
        Dim arguments As BackGroundWorkerArguments = DirectCast(e.Argument, BackGroundWorkerArguments)

        Select Case arguments.Operation
            Case BackGroundOperation.BeginNewDrillDown
                ddl.BeginNewDrillDown(arguments.Data)

            Case BackGroundOperation.ContinueDrillDown
                ddl.ContinueDrillDown(arguments.Data)

        End Select

    End Sub

    Private Sub DwarfDriller_ReportProgress(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles DwarfDriller.ProgressChanged
        Dim newRow As DataRow = CType(e.UserState, DataRow)
        dtResult.Rows.Add(newRow)

    End Sub

    Private Sub DwarfDriller_WorkEnded() Handles DwarfDriller.RunWorkerCompleted
        misc.SetDataSource()

        misc.HandleProgressBar(False)
        misc.HandleButtons(True)
    End Sub
#End Region

End Class
