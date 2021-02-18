Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class ReportViewer_DCList

    Private Sub ReportViewer_DCList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\DisconnectionList.rdlc"
                .DataSources.Clear()
            End With
            Dim reading_period_name As String = ""
            Dim total_records As Integer = 0
            cn.Open()
            cm = New MySqlCommand("SELECT * FROM s_readingpreiod WHERE Id = '" & Main.ToolStripLabel4.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                reading_period_name = dr.GetString("ReadingPeriod").ToString
            End While

            dr.Close()
            cn.Close()

            cn.Open()
            cm = New MySqlCommand("SELECT COUNT(*) as ID FROM a_customer WHERE a_customer.BillingBalance > 0 AND a_customer.Status = 'Active' AND a_customer.Barangay = '" & Disconnection_CreateView.ComboBox1.Text & "' ORDER BY a_customer.Cluster,a_customer.Lastname,a_customer.Firstname", cn)
            dr = cm.ExecuteReader
            While dr.Read
                total_records = dr.Item("ID").ToString
            End While

            dr.Close()
            cn.Close()
            Dim ds As New DataSetConsumers
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT * FROM a_customer WHERE a_customer.BillingBalance > 0 AND a_customer.Status = 'Active' AND a_customer.Barangay = '" & Disconnection_CreateView.ComboBox1.Text & "' ORDER BY a_customer.Cluster,a_customer.Lastname,a_customer.Firstname", cn)
            da.Fill(ds.Tables("tConsumers"))

            Dim barangay As New ReportParameter("Barangay", Disconnection_CreateView.ComboBox1.Text)
            ReportViewer1.LocalReport.SetParameters(barangay)
            Dim monthreading As New ReportParameter("MonthlyReading", reading_period_name)
            ReportViewer1.LocalReport.SetParameters(monthreading)
            Dim total As New ReportParameter("TotalRecords", total_records)
            ReportViewer1.LocalReport.SetParameters(total)

            rptDataSource = New ReportDataSource("DataSetDisconnectionList", ds.Tables("tConsumers"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ReportViewer_DCList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class