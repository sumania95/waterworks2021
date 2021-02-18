<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Download_Information_List
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSetConsumers = New NewTubodWaterworksSystem.DataSetConsumers()
        Me.tConsumersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSetConsumers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tConsumersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "DataSetAccountInfo"
        ReportDataSource4.Value = Me.tConsumersBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "NewTubodWaterworksSystem.DownloadInfoList.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1084, 561)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSetConsumers
        '
        Me.DataSetConsumers.DataSetName = "DataSetConsumers"
        Me.DataSetConsumers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tConsumersBindingSource
        '
        Me.tConsumersBindingSource.DataMember = "tConsumers"
        Me.tConsumersBindingSource.DataSource = Me.DataSetConsumers
        '
        'Download_Information_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 561)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(1100, 600)
        Me.Name = "Download_Information_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DOWNLOAD ACCOUNT INFORMATION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataSetConsumers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tConsumersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tConsumersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetConsumers As NewTubodWaterworksSystem.DataSetConsumers
End Class
