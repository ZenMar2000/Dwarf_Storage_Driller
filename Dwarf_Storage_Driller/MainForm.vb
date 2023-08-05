Imports System.ComponentModel
Imports System.IO

Public Class MainForm
    Private misc As New Misc(Me)
    Private ddl As New DrillDownLogic(Me)

#Region "Form Handlers"
    Private Sub OnShow_Form() Handles Me.Shown
        VersionLabel.Text = "Version: " & Application.ProductVersion
        ProgressLabel.Text = ""
    End Sub

#End Region

#Region "Button Handlers"
    Private Sub SelectPathButton_Click(sender As Object, e As EventArgs) Handles SelectFolderButton.Click
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = FolderPathTextBox.Text

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FolderPathTextBox.Text = dialog.SelectedPath
        End If

    End Sub

    Private Sub DrillDownButton_Click(sender As Object, e As EventArgs) Handles DrillDownButton.Click

        If Not Directory.Exists(FolderPathTextBox.Text) Then
            MsgBox("Target folder does not exists")
            Exit Sub

        Else
            misc.HandleProgressBar(True)
            misc.HandleButtons(False)
            DwarfDriller.RunWorkerAsync(FolderPathTextBox.Text)

        End If


    End Sub


    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles DwarfDriller.DoWork
        ddl.BeginDrillDown(e.Argument.ToString)

    End Sub

    Private Sub WorkEnded() Handles DwarfDriller.RunWorkerCompleted
        misc.HandleProgressBar(False)
        misc.HandleButtons(True)
    End Sub

#End Region

End Class
