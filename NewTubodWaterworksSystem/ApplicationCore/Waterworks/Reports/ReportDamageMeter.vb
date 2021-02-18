Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class ReportDamageMeter

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

    Private Sub ReportDamageMeter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub loadreport()
        Try
            ReportViewer1.RefreshReport()
            Dim rptDataSource As ReportDataSource
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\DamageMeter.rdlc"
                .DataSources.Clear()
            End With
            Dim ds As New DataSetDamageMeter
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT a_damagewatermeter.AccountNo,a_customer.Firstname,a_customer.Middlename,a_customer.Lastname,a_damagewatermeter.MeterNo,a_damagewatermeter.Reason,a_damagewatermeter.DateCreated,a_damagewatermeter.User FROM a_damagewatermeter LEFT JOIN a_customer ON a_damagewatermeter.AccountNo = a_customer.AccountNo ORDER BY a_damagewatermeter.DateCreated", cn)
            da.Fill(ds.Tables("tDamageMeter"))

            rptDataSource = New ReportDataSource("DataSetDamageMeter", ds.Tables("tDamageMeter"))
            ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub
End Class