Imports MySql.Data.MySqlClient
Public Class Adjustment
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
            cm = New MySqlCommand("sp_selectAdjustment", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("d1", DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"))
            cm.Parameters.AddWithValue("d2", DateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59"))
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                Dim amount As Double
                amount = dr.Item("Amount").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("CollectionType").ToString, amount.ToString("₱ #,##0.00"), dr.Item("Action").ToString, dr.Item("Reason").ToString, ddate.ToString("MM-dd-yyyy"), dr.Item("User").ToString)
            End While
            dr.Close()
            cn.Close()
            'Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With AdjustmentCreate
            .autoConsumer()
            .txName.Clear()
            .txAccountNo.Clear()
            .txBalance.Clear()
            .ComboBox1.SelectedIndex = -1
            .ShowDialog()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadrecord()
    End Sub
End Class