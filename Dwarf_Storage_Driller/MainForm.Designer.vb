<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ResultsDataGrid = New System.Windows.Forms.DataGridView()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.SelectFolderButton = New System.Windows.Forms.Button()
        Me.NewDrillButton = New System.Windows.Forms.Button()
        Me.FolderPathTextBox = New System.Windows.Forms.TextBox()
        Me.ProgBar = New System.Windows.Forms.ProgressBar()
        Me.DwarfDriller = New System.ComponentModel.BackgroundWorker()
        Me.ProgressLabel = New System.Windows.Forms.Label()
        Me.DrillDownButton = New System.Windows.Forms.Button()
        Me.ScopeButton = New System.Windows.Forms.Button()
        CType(Me.ResultsDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ResultsDataGrid
        '
        Me.ResultsDataGrid.AllowUserToAddRows = False
        Me.ResultsDataGrid.AllowUserToDeleteRows = False
        Me.ResultsDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultsDataGrid.Location = New System.Drawing.Point(13, 42)
        Me.ResultsDataGrid.Name = "ResultsDataGrid"
        Me.ResultsDataGrid.ReadOnly = True
        Me.ResultsDataGrid.Size = New System.Drawing.Size(897, 433)
        Me.ResultsDataGrid.TabIndex = 0
        '
        'VersionLabel
        '
        Me.VersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(13, 486)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(48, 13)
        Me.VersionLabel.TabIndex = 1
        Me.VersionLabel.Text = "Version: "
        '
        'SelectFolderButton
        '
        Me.SelectFolderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SelectFolderButton.Location = New System.Drawing.Point(428, 13)
        Me.SelectFolderButton.Name = "SelectFolderButton"
        Me.SelectFolderButton.Size = New System.Drawing.Size(98, 23)
        Me.SelectFolderButton.TabIndex = 2
        Me.SelectFolderButton.Text = "Select starting folder"
        Me.SelectFolderButton.UseVisualStyleBackColor = True
        '
        'NewDrillButton
        '
        Me.NewDrillButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewDrillButton.Location = New System.Drawing.Point(532, 13)
        Me.NewDrillButton.Name = "NewDrillButton"
        Me.NewDrillButton.Size = New System.Drawing.Size(98, 23)
        Me.NewDrillButton.TabIndex = 3
        Me.NewDrillButton.Text = "New Drill"
        Me.NewDrillButton.UseVisualStyleBackColor = True
        '
        'FolderPathTextBox
        '
        Me.FolderPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FolderPathTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FolderPathTextBox.Location = New System.Drawing.Point(13, 13)
        Me.FolderPathTextBox.Name = "FolderPathTextBox"
        Me.FolderPathTextBox.Size = New System.Drawing.Size(409, 21)
        Me.FolderPathTextBox.TabIndex = 5
        Me.FolderPathTextBox.Text = "C:\"
        '
        'ProgBar
        '
        Me.ProgBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgBar.Location = New System.Drawing.Point(618, 486)
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(292, 18)
        Me.ProgBar.TabIndex = 6
        Me.ProgBar.Visible = False
        '
        'DwarfDriller
        '
        Me.DwarfDriller.WorkerReportsProgress = True
        '
        'ProgressLabel
        '
        Me.ProgressLabel.AutoSize = True
        Me.ProgressLabel.Location = New System.Drawing.Point(519, 488)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(74, 13)
        Me.ProgressLabel.TabIndex = 7
        Me.ProgressLabel.Text = "ProgressLabel"
        Me.ProgressLabel.Visible = False
        '
        'DrillDownButton
        '
        Me.DrillDownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DrillDownButton.Enabled = False
        Me.DrillDownButton.Location = New System.Drawing.Point(708, 13)
        Me.DrillDownButton.Name = "DrillDownButton"
        Me.DrillDownButton.Size = New System.Drawing.Size(98, 23)
        Me.DrillDownButton.TabIndex = 8
        Me.DrillDownButton.Text = "Drill Down"
        Me.DrillDownButton.UseVisualStyleBackColor = True
        '
        'ScopeButton
        '
        Me.ScopeButton.Enabled = False
        Me.ScopeButton.Location = New System.Drawing.Point(812, 13)
        Me.ScopeButton.Name = "ScopeButton"
        Me.ScopeButton.Size = New System.Drawing.Size(98, 23)
        Me.ScopeButton.TabIndex = 9
        Me.ScopeButton.Text = "Scope selected"
        Me.ScopeButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 511)
        Me.Controls.Add(Me.ScopeButton)
        Me.Controls.Add(Me.DrillDownButton)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.FolderPathTextBox)
        Me.Controls.Add(Me.NewDrillButton)
        Me.Controls.Add(Me.SelectFolderButton)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.ResultsDataGrid)
        Me.Name = "MainForm"
        Me.Text = "Dwarf Storage Driller"
        CType(Me.ResultsDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ResultsDataGrid As DataGridView
    Friend WithEvents VersionLabel As Label
    Friend WithEvents SelectFolderButton As Button
    Friend WithEvents NewDrillButton As Button
    Friend WithEvents FolderPathTextBox As TextBox
    Friend WithEvents ProgBar As ProgressBar
    Friend WithEvents DwarfDriller As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressLabel As Label
    Friend WithEvents DrillDownButton As Button
    Friend WithEvents ScopeButton As Button
End Class
