Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class PrintBillingStatementSingle

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\BillStatementSingle.rdlc"
                .DataSources.Clear()
            End With
            Dim ds As New DataSetBilling
            Dim da As New MySqlDataAdapter
            'da.SelectCommand = New MySqlCommand("SELECT CONCAT(YEAR(a_customer.DateApplied),'-',LPAD(a_reading.AccountNo, 5, '0')) as AccountNo, a_customer.Firstname , a_customer.Middlename,a_customer.Lastname,a_customer.Classification,a_customer.Barangay,a_customer.MeterNo,a_reading.BillingBalance,IFNULL(a_reading.BillingBalance, 0) + a_reading.Amount as TotalAmountDue,a_reading.MeterBalance, a_reading.PreviousR,a_reading.PresentR,a_reading.Consumption,a_reading.Amount,a_reading.PreviousReadingDate,a_reading.PresentReadingDate, a_customer.HouseNo,s_readingpreiod.ReadingPeriod,s_readingpreiod.DueDate,s_readingpreiod.DisconnectionDate FROM `a_reading` LEFT JOIN s_readingpreiod ON a_reading.ReadingPeriodId = s_readingpreiod.Id LEFT JOIN a_customer ON a_reading.AccountNo = a_customer.AccountNo WHERE a_customer.Status = 'Active' AND a_reading.AccountNo = '" & BillingStatementSingle.txAccountNo.Text & "' AND ReadingPeriod = '" & BillingStatementSingle.ComboBox1.Text & "'", cn)
            da.SelectCommand = New MySqlCommand("sp_printBillingSingleA", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("p1", BillingStatementSingle.txAccountNo.Text)
            da.SelectCommand.Parameters.AddWithValue("p2", BillingStatementSingle.ComboBox1.Text)
            da.Fill(ds.Tables("tBilling"))

            Dim notices As New ReportParameter("Notices", BillingStatementSingle.txReminders.Text)
            ReportViewer1.LocalReport.SetParameters(notices)
            Dim contactno As New ReportParameter("ContactNo", Main.ToolStripLabel6.Text)
            ReportViewer1.LocalReport.SetParameters(contactno)

            rptDataSource = New ReportDataSource("DataSetBilling", ds.Tables("tBilling"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub
    Sub loadreportII()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\BillStatementSingle.rdlc"
                .DataSources.Clear()
            End With
            Dim ds As New DataSetBilling
            Dim da As New MySqlDataAdapter
            'da.SelectCommand = New MySqlCommand("SELECT CONCAT(YEAR(a_customer.DateApplied),'-',LPAD(a_reading.AccountNo, 5, '0')) as AccountNo, a_customer.Firstname , a_customer.Middlename,a_customer.Lastname,a_customer.Classification,a_customer.Barangay,a_customer.MeterNo,a_reading.BillingBalance,IFNULL(a_reading.BillingBalance, 0) + a_reading.Amount as TotalAmountDue,a_reading.MeterBalance, a_reading.PreviousR,a_reading.PresentR,a_reading.Consumption,a_reading.Amount,a_reading.PreviousReadingDate,a_reading.PresentReadingDate, a_customer.HouseNo,s_readingpreiod.ReadingPeriod,s_readingpreiod.DueDateB as DueDate,s_readingpreiod.DisconnectionDateB as DisconnectionDate FROM `a_reading` LEFT JOIN s_readingpreiod ON a_reading.ReadingPeriodId = s_readingpreiod.Id LEFT JOIN a_customer ON a_reading.AccountNo = a_customer.AccountNo WHERE a_customer.Status = 'Active' AND a_reading.AccountNo = '" & BillingStatementSingle.txAccountNo.Text & "' AND ReadingPeriod = '" & BillingStatementSingle.ComboBox1.Text & "'", cn)
            da.SelectCommand = New MySqlCommand("sp_printBillingSingleB", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("p1", BillingStatementSingle.txAccountNo.Text)
            da.SelectCommand.Parameters.AddWithValue("p2", BillingStatementSingle.ComboBox1.Text)
            da.Fill(ds.Tables("tBilling"))

            Dim notices As New ReportParameter("Notices", BillingStatementSingle.txReminders.Text)
            ReportViewer1.LocalReport.SetParameters(notices)
            Dim contactno As New ReportParameter("ContactNo", Main.ToolStripLabel6.Text)
            ReportViewer1.LocalReport.SetParameters(contactno)

            rptDataSource = New ReportDataSource("DataSetBilling", ds.Tables("tBilling"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub PrintBillingStatementSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class