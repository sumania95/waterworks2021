Imports MySql.Data.MySqlClient
Public Class ReportYearlyConsumption

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_reportYearlyConsumption", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim consumption As Double
                consumption = dr.Item("Consumption").ToString
                DataGridView1.Rows.Add(i, dr.Item("Year").ToString, consumption.ToString("#,##0"))
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub
End Class