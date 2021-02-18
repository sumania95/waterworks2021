Imports MySql.Data.MySqlClient
Public Class CollectionLogsIII
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectCollectionLog", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"))
            cm.Parameters.AddWithValue("p2", DateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59"))
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                Dim money As Double
                money = dr.Item("Amount").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Type").ToString, dr.Item("OrNo").ToString, money.ToString("₱ #,##0.00"), ddate.ToString("MM-dd-yyyy"), ddate.ToString("hh:mm:ss tt"), dr.Item("User").ToString)
            End While
            dr.Close()
            cn.Close()
            'Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
            'For s As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1

            '    Dim sum As Double
            '    sum = sum + DataGridView1.Rows(s).Cells(5).Value
            '    Label4.Text = sum.ToString("₱ #,##0.00")

            'Next
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadrecord()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With DashboardII
            .TopLevel = False
            SpecialMain.Panel1.Controls.Add(DashboardII)
            .BringToFront()
            .TotalExpenses()
            .DailyCollection()
            .TotalCollectionYearEx()
            .Installment()
            .loadchart()
            .Show()
        End With
    End Sub
End Class