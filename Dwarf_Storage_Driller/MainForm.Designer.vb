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
        Me.components = New System.ComponentModel.Container()
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
        Me.RemoveScopeButton = New System.Windows.Forms.Button()
        Me.HideButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ResultsDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ResultsDataGrid
        '
        Me.ResultsDataGrid.AllowUserToAddRows = False
        Me.ResultsDataGrid.AllowUserToDeleteRows = False
        Me.ResultsDataGrid.AllowUserToResizeRows = False
        Me.ResultsDataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ResultsDataGrid.Location = New System.Drawing.Point(13, 71)
        Me.ResultsDataGrid.Name = "ResultsDataGrid"
        Me.ResultsDataGrid.ReadOnly = True
        Me.ResultsDataGrid.Size = New System.Drawing.Size(982, 404)
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
        Me.SelectFolderButton.Location = New System.Drawing.Point(429, 11)
        Me.SelectFolderButton.Name = "SelectFolderButton"
        Me.SelectFolderButton.Size = New System.Drawing.Size(98, 23)
        Me.SelectFolderButton.TabIndex = 6
        Me.SelectFolderButton.Text = "Select starting folder"
        Me.ToolTip1.SetToolTip(Me.SelectFolderButton, "Shortcut 'M'")
        Me.SelectFolderButton.UseVisualStyleBackColor = True
        '
        'NewDrillButton
        '
        Me.NewDrillButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewDrillButton.Location = New System.Drawing.Point(533, 11)
        Me.NewDrillButton.Name = "NewDrillButton"
        Me.NewDrillButton.Size = New System.Drawing.Size(98, 23)
        Me.NewDrillButton.TabIndex = 2
        Me.NewDrillButton.Text = "New Drill"
        Me.ToolTip1.SetToolTip(Me.NewDrillButton, "Shortcut 'N'")
        Me.NewDrillButton.UseVisualStyleBackColor = True
        '
        'FolderPathTextBox
        '
        Me.FolderPathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FolderPathTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.FolderPathTextBox.Location = New System.Drawing.Point(13, 13)
        Me.FolderPathTextBox.Name = "FolderPathTextBox"
        Me.FolderPathTextBox.Size = New System.Drawing.Size(410, 21)
        Me.FolderPathTextBox.TabIndex = 1
        Me.FolderPathTextBox.Text = "D:\"
        '
        'ProgBar
        '
        Me.ProgBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgBar.Location = New System.Drawing.Point(703, 486)
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
        Me.ProgressLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressLabel.AutoSize = True
        Me.ProgressLabel.Location = New System.Drawing.Point(707, 488)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(74, 13)
        Me.ProgressLabel.TabIndex = 7
        Me.ProgressLabel.Text = "ProgressLabel"
        Me.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ProgressLabel.Visible = False
        '
        'DrillDownButton
        '
        Me.DrillDownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DrillDownButton.Enabled = False
        Me.DrillDownButton.Location = New System.Drawing.Point(637, 11)
        Me.DrillDownButton.Name = "DrillDownButton"
        Me.DrillDownButton.Size = New System.Drawing.Size(98, 23)
        Me.DrillDownButton.TabIndex = 3
        Me.DrillDownButton.Text = "Drill Down"
        Me.ToolTip1.SetToolTip(Me.DrillDownButton, "Shortcut 'D'")
        Me.DrillDownButton.UseVisualStyleBackColor = True
        '
        'ScopeButton
        '
        Me.ScopeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScopeButton.Enabled = False
        Me.ScopeButton.Location = New System.Drawing.Point(793, 13)
        Me.ScopeButton.Name = "ScopeButton"
        Me.ScopeButton.Size = New System.Drawing.Size(98, 23)
        Me.ScopeButton.TabIndex = 4
        Me.ScopeButton.Text = "Scope rows"
        Me.ToolTip1.SetToolTip(Me.ScopeButton, "Shortcut 'S'")
        Me.ScopeButton.UseVisualStyleBackColor = True
        '
        'RemoveScopeButton
        '
        Me.RemoveScopeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemoveScopeButton.Enabled = False
        Me.RemoveScopeButton.Location = New System.Drawing.Point(793, 42)
        Me.RemoveScopeButton.Name = "RemoveScopeButton"
        Me.RemoveScopeButton.Size = New System.Drawing.Size(202, 23)
        Me.RemoveScopeButton.TabIndex = 5
        Me.RemoveScopeButton.Text = "Remove scope"
        Me.ToolTip1.SetToolTip(Me.RemoveScopeButton, "Shortcut 'R'")
        Me.RemoveScopeButton.UseVisualStyleBackColor = True
        '
        'HideButton
        '
        Me.HideButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HideButton.Enabled = False
        Me.HideButton.Location = New System.Drawing.Point(897, 13)
        Me.HideButton.Name = "HideButton"
        Me.HideButton.Size = New System.Drawing.Size(98, 23)
        Me.HideButton.TabIndex = 4
        Me.HideButton.Text = "Hide rows"
        Me.ToolTip1.SetToolTip(Me.HideButton, "Shortcut 'F'")
        Me.HideButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 511)
        Me.Controls.Add(Me.RemoveScopeButton)
        Me.Controls.Add(Me.HideButton)
        Me.Controls.Add(Me.ScopeButton)
        Me.Controls.Add(Me.DrillDownButton)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.ProgBar)
        Me.Controls.Add(Me.FolderPathTextBox)
        Me.Controls.Add(Me.NewDrillButton)
        Me.Controls.Add(Me.SelectFolderButton)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.ResultsDataGrid)
        Me.KeyPreview = True
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
    Friend WithEvents RemoveScopeButton As Button
    Friend WithEvents HideButton As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
