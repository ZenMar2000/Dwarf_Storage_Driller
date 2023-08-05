Imports System.IO

Class DrillDownLogic
    Private Shared megabyteDivider As Double = 1048576.0
    Private _MainFormInstance As MainForm
    Private folderSize As Long = 0
    Private folderInfo As DirectoryInfo

    ''' <summary>
    ''' Get instance of the Main form.
    ''' </summary>
    ''' <param name="mainFormInstance"></param>
    Public Sub New(ByRef mainFormInstance As MainForm)
        _MainFormInstance = mainFormInstance

    End Sub

    ''' <summary>
    ''' Start drilling down, starting from the selected folder
    ''' </summary>
    Public Sub BeginNewDrillDown(targetPath As String)
        Try
            ScanFolders(targetPath, "0")

        Catch ex As Exception
            MsgBox("Exception caught in ScanFolders: " & ex.Message)

        End Try
    End Sub

    Public Sub ContinueDrillDown(selctedRows As DataGridViewSelectedRowCollection)
        Dim warnForAlreadyDrilledRows As Boolean = False

        For Each row As DataGridViewRow In _MainFormInstance.ResultsDataGrid.Rows
            If row.DefaultCellStyle.BackColor = Color.Yellow Then
                row.DefaultCellStyle.BackColor = Color.LightGreen

            End If
        Next

        For Each row As DataGridViewRow In selctedRows
            If row.DefaultCellStyle.BackColor <> Color.LightGreen Then
                ScanFolders(row.Cells(Column_FullPath).Value, row.Cells(Column_Level).Value)
                row.DefaultCellStyle.BackColor = Color.Yellow
            Else
                warnForAlreadyDrilledRows = True

            End If
        Next

        If warnForAlreadyDrilledRows Then
            MsgBox("One or more rows have been ignored. Already drilled down.")
        End If

    End Sub

    Private Sub ScanFolders(ByVal targetPath As String, parentLevel As String)
        Dim localLevel As Integer = 0
        Dim currentLevel As String
        Dim skippedDirs As String = "The following directories were skipped:" & vbNewLine & vbNewLine
        Dim showSkippedDirs As Boolean = False
        Dim subdirectories As String()

        'Get the subdirectories in the current folder
        Try
            subdirectories = Directory.GetDirectories(targetPath)
            For Each subdirectory As String In subdirectories
                Try
                    currentLevel = parentLevel & "_" & localLevel

                    'Get info for current subdirectory
                    GetFolderData(subdirectory, currentLevel)

                    localLevel += 1
                Catch ex2 As Exception
                    skippedDirs &= subdirectory & " || " & ex2.Message & vbNewLine & vbNewLine
                    showSkippedDirs = True
                End Try
            Next

        Catch ex As Exception
            skippedDirs &= targetPath & " || " & ex.Message & vbNewLine & vbNewLine
            showSkippedDirs = True
        End Try

        If showSkippedDirs Then
            MsgBox(skippedDirs)
        End If
    End Sub

    Private Sub GetFolderData(targetPath As String, localLevel As String)
        folderSize = 0
        folderInfo = New DirectoryInfo(targetPath)
        'files = folderInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly)

        'For Each file As FileInfo In files
        '    folderSize += file.Length
        'Next

        'megaBytes = folderSize / megabyteDivider 'Convert to Megabytes
        GetAllSubFolderInfo(targetPath)

        'Dim subdirectories As String() = Directory.GetDirectories(targetPath)
        'For Each subdir As String In subdirectories
        '    GetAllSubFolderInfo(subdir, megaBytes)

        'Next

        Dim newLine As DataRow = _MainFormInstance.dtResult.NewRow

        newLine(Column_Folder) = folderInfo.Name
        newLine(Column_Level) = localLevel
        newLine(Column_Dimension) = Math.Round(folderSize / megabyteDivider, 3)
        newLine(Column_FullPath) = targetPath

        _MainFormInstance.DwarfDriller.ReportProgress(0, newLine)
    End Sub

    Private Sub GetAllSubFolderInfo(SubDirectory As String)
        Try
            Dim localSize As Long = 0
            Dim localFolderInfo As New DirectoryInfo(SubDirectory)
            Dim localFileInfo As FileInfo() = localFolderInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly)

            For Each file As FileInfo In localFileInfo
                localSize += file.Length
            Next

            folderSize += localSize

            Dim subdirectories As String() = Directory.GetDirectories(SubDirectory)
            For Each subdir As String In subdirectories
                GetAllSubFolderInfo(subdir)

            Next

        Catch ex As Exception

        End Try
    End Sub

End Class
