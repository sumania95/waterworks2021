Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class PrintReading

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
    End Sub

    Private Sub PrintReading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\ReadingList.rdlc"
                .DataSources.Clear()
            End With
            Dim ds As New DataSetConsumers
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT * FROM a_customer WHERE a_customer.Status = 'Active' AND a_customer.ReadingPeriodId < '" & Main.ToolStripLabel4.Text & "' AND a_customer.Barangay = '" & ReadingRecordPrint.ComboBox1.Text & "' ORDER BY a_customer.Cluster,a_customer.Lastname,a_customer.Firstname", cn)
            da.Fill(ds.Tables("tConsumers"))

            Dim barangay As New ReportParameter("Barangay", ReadingRecordPrint.ComboBox1.Text)
            ReportViewer1.LocalReport.SetParameters(barangay)

            Dim monthreading As New ReportParameter("MonthlyReading", ReadingRecordPrint.txMonthReading.Text)
            ReportViewer1.LocalReport.SetParameters(monthreading)

            rptDataSource = New ReportDataSource("DataSetReading", ds.Tables("tConsumers"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub
End Class