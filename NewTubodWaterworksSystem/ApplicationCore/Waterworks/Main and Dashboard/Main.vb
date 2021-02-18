Imports MySql.Data.MySqlClient
Public Class Main
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.GetWorkingArea(Me)
        Timer1.Enabled = True
        With Dashboard
            .TopLevel = False
            Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .Allcustomer()
            .ReadyForInstallation()
            .DailyCollection()
            .Consumption()
            .loadchart()
            .loadchart02()
            .loadchart03()
            .loadchart04()
            .Show()
        End With
    End Sub
    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function

    Private Sub SIGNOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SIGNOUTToolStripMenuItem.Click
        Try
            If (MsgBox("Are you sure you want to logout?", vbYesNo + vbQuestion, Label1.Text) = vbYes) Then
                Me.Dispose()
                With Login
                    .txPass.Clear()
                    .Show()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BARANGAYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BARANGAYToolStripMenuItem.Click
        With Barangay
            .TopLevel = False
            Panel1.Controls.Add(Barangay)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub CALENDARYEARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CALENDARYEARToolStripMenuItem.Click
        With CalendarYear
            .TopLevel = False
            Panel1.Controls.Add(CalendarYear)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub READINGPERIODToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles READINGPERIODToolStripMenuItem.Click
        With ReadingPeriod
            .TopLevel = False
            Panel1.Controls.Add(ReadingPeriod)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub CONSUMERSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONSUMERSToolStripMenuItem1.Click
        With CustomerRegistration
            .TopLevel = False
            Panel1.Controls.Add(CustomerRegistration)
            .BringToFront()
            .ComboBox1.SelectedIndex = 0
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub INSTALLATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSTALLATIONToolStripMenuItem.Click
        With InstallationConfirmation
            .TopLevel = False
            Panel1.Controls.Add(InstallationConfirmation)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub ALLOCATEZONESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALLOCATEZONESToolStripMenuItem.Click
        With AllocateZones
            .TopLevel = False
            Panel1.Controls.Add(AllocateZones)
            .BringToFront()
            .ComboBox1.Text = "Select Barangay"
            .ComboBox2.Text = "Select Zones"
            .cmbbarangay()
            .hideGridV()
            .DataGridView1.Rows.Clear()
            .loadrecord()
            .MetroTextBox1.Select()
            .Show()
        End With
    End Sub


    Private Sub DASHBOARDToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DASHBOARDToolStripMenuItem1.Click
        With Dashboard
            .TopLevel = False
            Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .loadchart()
            .loadchart02()
            .loadchart03()
            .loadchart04()
            .Allcustomer()
            .ReadyForInstallation()
            .DailyCollection()
            .Consumption()
            .Show()
        End With
    End Sub

    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_applicationSettings", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Label1.Text = dr.Item(1)
                ToolStripLabel6.Text = dr.Item(2)
                ToolStripLabel5.Text = dr.Item(3)
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub ReadingPeriod001()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectMaxIdReadingPeriod", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                ToolStripLabel4.Text = dr.GetString("Id").ToString
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub RECORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem.Click
        With ReadingRecord
            .TopLevel = False
            Panel1.Controls.Add(ReadingRecord)
            .BringToFront()
            .cmbbarangay01()
            .cmbBarangay.SelectedIndex = -1
            .cmbBarangay.Text = "Select Barangay"
            .loadrecord()
            .txAccount.Clear()
            .txName.Clear()
            .txMeterNo.Clear()
            .txprev.Clear()
            .txPres.Clear()
            .txAmount.Clear()
            .txConsumption.Clear()
            .lblimplement.ResetText()
            .Show()
        End With
    End Sub

    Private Sub ActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActiveToolStripMenuItem.Click
        With StatusAndReplacementActive
            .TopLevel = False
            Panel1.Controls.Add(StatusAndReplacementActive)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub DisconnectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnectedToolStripMenuItem.Click
        With StatusAndReplacementDisconnected
            .TopLevel = False
            Panel1.Controls.Add(StatusAndReplacementDisconnected)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub CondemnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CondemnToolStripMenuItem.Click
        With StatusCondemn
            .TopLevel = False
            Panel1.Controls.Add(StatusCondemn)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub


    Private Sub BATCHPRINTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BATCHPRINTToolStripMenuItem.Click
        With BillingStatementMultiple
            .txClasstype.Clear()
            .ComboBox1.SelectedIndex = -1
            .ApplicationName()
            .cmbbarangay()
            .ShowDialog()
        End With
    End Sub

    Private Sub DAMAGEMETERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DAMAGEMETERToolStripMenuItem.Click
        With ReportDamageMeterView
            .TopLevel = False
            Panel1.Controls.Add(ReportDamageMeterView)
            .BringToFront()
            .loadrecord()
            .MetroTextBox1.Select()
            .Show()
        End With
    End Sub


    Private Sub SINGLEPRINTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SINGLEPRINTToolStripMenuItem.Click
        With BillingStatementSingle
            .txName.Select()
            .txName.Clear()
            .txAccountNo.Clear()
            .txAccountMirror.Clear()
            .txClasstype.Clear()
            .ComboBox1.Text = ""
            .ApplicationName()
            .autoConsumer()
            .ReadingPeriod01()
            .ShowDialog()
        End With
    End Sub

    Private Sub VisibleRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleRecordToolStripMenuItem.Click
        With ReadingRecordVisible
            .TopLevel = False
            Panel1.Controls.Add(ReadingRecordVisible)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub ADJUSTMENTRECORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADJUSTMENTRECORDToolStripMenuItem.Click
        With Adjustment
            .TopLevel = False
            Panel1.Controls.Add(Adjustment)
            .BringToFront()
            .DataGridView1.Rows.Clear()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .Show()
        End With
    End Sub

    Private Sub MESSAGESSECTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MESSAGESSECTIONToolStripMenuItem.Click
        With Messages
            .loadrecord()
            .LoginName()
            .ShowDialog()
        End With
    End Sub

    Private Sub MAINTENANCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MAINTENANCEToolStripMenuItem.Click
        With ApplicationSetting
            .ApplicationName()
            .year001()
            .ShowDialog()
        End With
    End Sub

    Private Sub ACTIVITYLOGSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACTIVITYLOGSToolStripMenuItem.Click
        With Activity_Log
            .TopLevel = False
            Panel1.Controls.Add(Activity_Log)
            .BringToFront()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .DataGridView1.Rows.Clear()
            .Show()
        End With
    End Sub

    Private Sub COLLECTIONLOGSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COLLECTIONLOGSToolStripMenuItem.Click
        With CollectionLogs
            .TopLevel = False
            Panel1.Controls.Add(CollectionLogs)
            .BringToFront()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .Label4.ResetText()
            .DataGridView1.Rows.Clear()
            .Show()
        End With
    End Sub

    Private Sub USERACCOUNTLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USERACCOUNTLISTToolStripMenuItem.Click
        With UserAccount
            .txName.Clear()
            .txPass.Clear()
            .txRePass.Clear()
            .cmbType.SelectedIndex = -1
            .txUser.Clear()
            .ShowDialog()
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripLabel7.Text = "Local Ip : " + GetIPv4Address()
    End Sub

    Private Sub MAX100CONSUMPTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MAX100CONSUMPTIONToolStripMenuItem.Click
        With ReportMax100ConsumptionView
            .TopLevel = False
            Panel1.Controls.Add(ReportMax100ConsumptionView)
            .BringToFront()
            .ComboBox1.SelectedIndex = -1
            .ComboBox1.Text = "Select Barangay"
            .cmbbarangay01()
            .ComboBox2.SelectedIndex = -1
            .ComboBox2.Text = "Select Reading Period"
            .cmbreadingperiod()
            .MetroTextBox1.Select()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub MATERIALSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MATERIALSToolStripMenuItem.Click
        With Materials
            .TopLevel = False
            Panel1.Controls.Add(Materials)
            .BringToFront()
            .MetroTextBox1.Clear()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub MATERIALINSTALLMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MATERIALINSTALLMENTToolStripMenuItem.Click
        With MaterialInstallment
            .TopLevel = False
            Panel1.Controls.Add(MaterialInstallment)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub HISTORYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HISTORYToolStripMenuItem.Click
        With ReadingHistory
            .TextBox1.Clear()
            .DataGridView1.Rows.Clear()
            .TextBox2.Clear()
            .txName.Clear()
            .autoConsumer()
            .ShowDialog()
        End With
    End Sub

    Private Sub MONTHLYINSTALLEDREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MONTHLYINSTALLEDREPORTToolStripMenuItem.Click
        With ReportSummaryInstalledView
            .TopLevel = False
            Panel1.Controls.Add(ReportSummaryInstalledView)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub ANNUALCONSUMPTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ANNUALCONSUMPTIONToolStripMenuItem.Click
        With ReportAnnualConsumptionView
            .TopLevel = False
            Panel1.Controls.Add(ReportAnnualConsumptionView)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub YEARLYCONSUMPTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YEARLYCONSUMPTIONToolStripMenuItem.Click
        With ReportYearlyConsumption
            .TopLevel = False
            Panel1.Controls.Add(ReportYearlyConsumption)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub


    Private Sub MONTHLYBARANGAYCONSUMPTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MONTHLYBARANGAYCONSUMPTIONToolStripMenuItem.Click
        With ReportMonthlyBarangayConsumption
            .TopLevel = False
            Panel1.Controls.Add(ReportMonthlyBarangayConsumption)
            .BringToFront()
            .ComboBox1.SelectedIndex = -1
            .ComboBox1.Text = "Select Reading Period"
            .cmbreadingperiod()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub INSTALLMENTBILLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSTALLMENTBILLToolStripMenuItem.Click
        MsgBox("Available soon. Please contact the Administrator!", vbExclamation, Label1.Text)
    End Sub

    Private Sub CONSUMERSHISTORYPAYMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONSUMERSHISTORYPAYMENTToolStripMenuItem.Click
        With ConsumerHistoryPayment
            .TopLevel = False
            Panel1.Controls.Add(ConsumerHistoryPayment)
            .BringToFront()
            .txName.Clear()
            .txMeter.Clear()
            .txAccount.Clear()
            .txAccountMirror.Clear()
            .autoConsumer()
            .DataGridView1.Rows.Clear()
            .Show()
        End With
    End Sub

    Private Sub PAYMENTCANCELEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PAYMENTCANCELEDToolStripMenuItem.Click
        With CancelledPayment
            .TopLevel = False
            Panel1.Controls.Add(CancelledPayment)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub

    Private Sub ChangeReadingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeReadingToolStripMenuItem.Click
        With ReadingLogs
            .ShowDialog()
        End With
    End Sub

    Private Sub PRINTDISCONNECTIONLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTDISCONNECTIONLISTToolStripMenuItem.Click
        With Disconnection_CreateView
            .cmbbarangay()
            .ComboBox1.SelectedIndex = 0
            .ShowDialog()
        End With
    End Sub

    Private Sub PRINTACCOUNTBALANCESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTACCOUNTBALANCESToolStripMenuItem.Click
        With Download_Information_List
            .loadreport()
            .ShowDialog()
        End With
    End Sub
End Class
