Imports System.IO

Class DrillDownLogic
    Private _MainFormInstance As MainForm

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
    Public Sub BeginDrillDown(targetPath As String)
        Try
            Dim folderSize As Long = 0
            Dim folderInfo As New DirectoryInfo(targetPath)
            Dim files As FileInfo() = folderInfo.GetFiles("*.*", SearchOption.AllDirectories)

            For Each file As FileInfo In files
                folderSize += file.Length
            Next

            Console.WriteLine("Folder size: " & folderSize & " bytes")

        Catch ex As Exception
            If Strings.InStr(ex.Message, ("Access to the path")) Then
                MsgBox("Access denied to one or more folders. Try launching application as Administrator.")
            End If
        End Try
    End Sub




End Class
