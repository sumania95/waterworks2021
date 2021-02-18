Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class PrintCondemnForm

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\RequestForActiveMPO.rdlc"
                .DataSources.Clear()
            End With
            Dim ds As New DataSetConsumers
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT CONCAT(YEAR(a_customer.DateApplied),'-',LPAD(a_customer.AccountNo, 5, '0')) as AccountNo, `Firstname`, `Middlename`, `Lastname`, `Contact`, `Classification`, `Barangay`, `Purok`, `HouseNo`, `Dateapplied`, `MeterNo`, `MeterSize`, `Cluster`, `Status`, `NameSpouse`, `NoOuccupancy`, `Occupation`, `DateInstalled`, `ReconnectionFee`, `BillingBalance`, `MeterBalance`, `PreviousR`, `PresentR`, `Consumption`, `Amount`, `PreviousReadingDate`, `PresentReadingDate`, `ReadingPeriodId`, `KeyNo`, `RegistrationInstallation`, `Installement`, `HideReading` FROM a_customer WHERE a_customer.AccountNo = '" & StatusAndReplacementActive.DataGridView1.CurrentRow.Cells(1).Value.ToString & "'", cn)
            da.Fill(ds.Tables("tConsumers"))

            rptDataSource = New ReportDataSource("DataSetDisconnection", ds.Tables("tConsumers"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub
End Class