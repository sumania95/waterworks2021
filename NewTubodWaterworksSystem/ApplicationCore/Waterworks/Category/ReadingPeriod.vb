Imports MySql.Data.MySqlClient
Public Class ReadingPeriod
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
            cm = New MySqlCommand("sp_selectReadingPeriod", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate1 As Date
                Dim ddate2 As Date
                Dim ddate3 As Date
                Dim ddate4 As Date
                ddate1 = dr.Item("DueDate").ToString
                ddate2 = dr.Item("DisconnectionDate").ToString
                ddate3 = dr.Item("DueDateB").ToString
                ddate4 = dr.Item("DisconnectionDateB").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("ReadingPeriod").ToString, ddate1.ToString("MMM-dd-yyyy"), ddate2.ToString("MMM-dd-yyyy"), ddate3.ToString("MMM-dd-yyyy"), ddate4.ToString("MMM-dd-yyyy"), dr.Item("User").ToString, "Update")
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With ReadingPeriodCreate
            .Month001()
            .ComboBox1.Enabled = True
            .Button1.Enabled = True
            .Button2.Enabled = False
            .ComboBox1.SelectedIndex = -1
            .ComboBox1.Text = ""
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .DateTimePicker3.Value = Date.Now
            .DateTimePicker4.Value = Date.Now
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column5" Then
            With ReadingPeriodCreate
                .Month001()
                .lblId.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .DateTimePicker1.Value = CDate(DataGridView1.CurrentRow.Cells(3).Value)
                .DateTimePicker2.Value = CDate(DataGridView1.CurrentRow.Cells(4).Value)
                .DateTimePicker3.Value = CDate(DataGridView1.CurrentRow.Cells(5).Value)
                .DateTimePicker4.Value = CDate(DataGridView1.CurrentRow.Cells(6).Value)
                .ComboBox1.Enabled = False
                .Button1.Enabled = False
                .Button2.Enabled = True
                .ShowDialog()
            End With
        End If
    End Sub
End Class