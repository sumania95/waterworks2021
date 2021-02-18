Imports MySql.Data.MySqlClient
Public Class ReportMonthlyBarangayConsumption
    Public Sub cmbreadingperiod()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectReadingPeriod", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                Dim ReadingPeriod01 = dr.GetString("ReadingPeriod")
                ComboBox1.Items.Add(ReadingPeriod01)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_reportMonthlyBarangayConsumption", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", ComboBox1.Text)
            cm.Parameters.AddWithValue("p2", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim consumption As Double
                consumption = dr.Item("Consumption").ToString
                DataGridView1.Rows.Add(i, dr.Item("Barangay").ToString, consumption.ToString("#,##0"))
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadrecord()
    End Sub
End Class