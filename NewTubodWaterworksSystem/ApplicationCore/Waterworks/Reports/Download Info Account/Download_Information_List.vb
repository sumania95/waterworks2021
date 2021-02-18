Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class Download_Information_List

    Private Sub Download_Information_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\DownloadInfoList.rdlc"
                .DataSources.Clear()
            End With
            Dim reading_period_name As String = ""
            cn.Open()
            cm = New MySqlCommand("SELECT * FROM s_readingpreiod WHERE Id = '" & Main.ToolStripLabel4.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                reading_period_name = dr.GetString("ReadingPeriod").ToString
            End While

            dr.Close()
            cn.Close()

            Dim ds As New DataSetConsumers
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT * FROM a_customer WHERE a_customer.Status = 'Active'  ORDER BY a_customer.Barangay,a_customer.Lastname,a_customer.Firstname", cn)
            da.Fill(ds.Tables("tConsumers"))

            Dim monthreading As New ReportParameter("MonthlyReading", reading_period_name)
            ReportViewer1.LocalReport.SetParameters(monthreading)

            rptDataSource = New ReportDataSource("DataSetAccountInfo", ds.Tables("tConsumers"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Download_Information_List_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class