<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewer_DCList
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.tConsumersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetConsumers = New NewTubodWaterworksSystem.DataSetConsumers()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.tConsumersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetConsumers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tConsumersBindingSource
        '
        Me.tConsumersBindingSource.DataMember = "tConsumers"
        Me.tConsumersBindingSource.DataSource = Me.DataSetConsumers
        '
        'DataSetConsumers
        '
        Me.DataSetConsumers.DataSetName = "DataSetConsumers"
        Me.DataSetConsumers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSetDisconnectionList"
        ReportDataSource2.Value = Me.tConsumersBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "NewTubodWaterworksSystem.DisconnectionList.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1084, 561)
        Me.ReportViewer1.TabIndex = 0
        '
        'ReportViewer_DCList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 561)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(1100, 600)
        Me.Name = "ReportViewer_DCList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DISCONNECTION LIST"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tConsumersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetConsumers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tConsumersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetConsumers As NewTubodWaterworksSystem.DataSetConsumers
End Class
