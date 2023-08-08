Imports System.ComponentModel
Imports System.IO

Public Class MainForm
#Region "Public variables"
    Public dtResult As New DataTable
    Public ColorDictionary As New Dictionary(Of String, Color)
    Public bindingSource As New BindingSource()

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

    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.S
                ScopeButton.PerformClick()

            Case Keys.D
                DrillDownButton.PerformClick()

            Case Keys.R
                RemoveScopeButton.PerformClick()

            Case Keys.F
                HideButton.PerformClick()

            Case Keys.A
                MsgBox("Not implemented. Increase drill levels per operation")

            Case Keys.Q
                MsgBox("Not implemented. Reduce drill levels per operation")

            Case Keys.N
                NewDrillButton.PerformClick()

            Case Keys.M
                SelectFolderButton.PerformClick()

        End Select
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
            misc.HandleProgressBar(True)
            misc.HandleButtons(False)

            misc.StartBackgroundWorker(BackGroundOperation.ContinueDrillDown)

        Else
            MsgBox("No rows selected to drill down")

        End If
    End Sub

    Private Sub ScopeButton_Click(sender As Object, e As EventArgs) Handles ScopeButton.Click, HideButton.Click

        Dim type As String = CType(sender, Button).Name

        If ResultsDataGrid.SelectedRows.Count <= 0 Then
            MsgBox("No rows selected. Cannot perform scope")
            Exit Sub
        End If
        If bindingSource.DataSource Is Nothing Then
            bindingSource.DataSource = dtResult
        End If

        Dim filteredDataTable As DataTable = dtResult.Clone

        Dim partialFilter As String = IIf(type = "ScopeButton", Column_Level, Column_Level & " NOT")
        Dim selectFilter As String = partialFilter & " LIKE '" & ResultsDataGrid.SelectedRows(0).Cells(Column_Level).Value

        For i As Integer = 1 To ResultsDataGrid.SelectedRows.Count - 1
            selectFilter &= "%' " & IIf(type = "ScopeButton", "OR ", "AND ") & partialFilter & " LIKE '" & ResultsDataGrid.SelectedRows(i).Cells(Column_Level).Value
            '    res = dtResult.Select(selectFilter)

            '    For Each dtrow As DataRow In res
            '        filteredDataTable.Rows.Add(dtResult.)
            '    Next
        Next
        selectFilter &= "%' "

        If type = "HideButton" Then
            bindingSource.Filter = IIf(bindingSource.Filter Is Nothing, selectFilter, "(" & bindingSource.Filter & ") AND " & selectFilter)

        Else
            bindingSource.Filter &= IIf(bindingSource.Filter Is Nothing, selectFilter, " AND " & selectFilter)

        End If

        misc.SetDataSource(bindingSource)
        ApplyDictionaryColor()

    End Sub

    Private Sub RemoveScopeButton_Click(sender As Object, e As EventArgs) Handles RemoveScopeButton.Click
        If MsgBox("Do you want to remove all filters?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            bindingSource.DataSource = dtResult
            bindingSource.RemoveFilter()

            misc.SetDataSource(bindingSource)

            ApplyDictionaryColor()

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

        ApplyDictionaryColor()

        misc.HandleProgressBar(False)
        misc.HandleButtons(True)

    End Sub


#End Region

    Private Sub ResultsDataGrid_Sorted(sender As Object, e As EventArgs) Handles ResultsDataGrid.Sorted
        ApplyDictionaryColor()

    End Sub

    Public Sub SaveDictionaryColor(key As String, value As Color)
        If ColorDictionary.ContainsKey(key) = True Then
            ColorDictionary(key) = value

        Else
            ColorDictionary.Add(key, value)

        End If

    End Sub

    Public Sub ApplyDictionaryColor()
        Dim val As Color
        For Each row As DataGridViewRow In ResultsDataGrid.Rows
            If ColorDictionary.TryGetValue(row.Cells(Column_Level).Value, val) = True Then
                row.DefaultCellStyle.BackColor = val
            End If
        Next
    End Sub

End Class
