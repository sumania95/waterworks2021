Imports MySql.Data.MySqlClient
Public Class SpecialMain

    Private Sub SpecialMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.GetWorkingArea(Me)
        Timer1.Enabled = True
        With DashboardII
            .TopLevel = False
            Panel1.Controls.Add(DashboardII)
            .BringToFront()
            .TotalExpenses()
            .DailyCollection()
            .TotalCollectionYearEx()
            .Installment()
            .loadchart()
            .Show()
        End With
    End Sub

    Private Sub ACCOUNTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACCOUNTToolStripMenuItem.Click
        With Expenses
            .TopLevel = False
            Panel1.Controls.Add(Expenses)
            .BringToFront()
            .loadrecord()
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripLabel3.Text = "Local Ip : " + GetIPv4Address()
    End Sub

    Private Sub COLLECTIONLOGSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COLLECTIONLOGSToolStripMenuItem.Click
        With CollectionLogsIII
            .TopLevel = False
            Panel1.Controls.Add(CollectionLogsIII)
            .BringToFront()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .Label4.ResetText()
            .DataGridView1.Rows.Clear()
            .Show()
        End With
    End Sub
    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_setting", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Label1.Text = dr.Item(1)
                ToolStripLabel4.Text = dr.Item(2)
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub MESSAGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MESSAGESToolStripMenuItem.Click
        With DashboardII
            .TopLevel = False
            Panel1.Controls.Add(DashboardII)
            .BringToFront()
            .TotalExpenses()
            .DailyCollection()
            .TotalCollectionYearEx()
            .Installment()
            .loadchart()
            .Show()
        End With
    End Sub

    Private Sub HISTORYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HISTORYToolStripMenuItem.Click
        With SettingsIII
            .year001()
            .ApplicationName()
            .ShowDialog()
        End With
    End Sub

    Private Sub CONSUMERLOGSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONSUMERLOGSToolStripMenuItem.Click
        With ConsumerLogs
            .TopLevel = False
            Panel1.Controls.Add(ConsumerLogs)
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

    Private Sub CANCELEDPAYMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELEDPAYMENTToolStripMenuItem.Click
        With CancelledPayment
            .TopLevel = False
            Panel1.Controls.Add(CancelledPayment)
            .BringToFront()
            .loadrecord()
            .Show()
        End With
    End Sub
End Class