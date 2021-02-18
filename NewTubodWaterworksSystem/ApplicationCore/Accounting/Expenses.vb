Imports MySql.Data.MySqlClient
Public Class Expenses

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
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectExpenses_Search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("p2", SpecialMain.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Particulars").ToString, dr.Item("PayeeName").ToString, dr.Item("Amount").ToString, ddate.ToString("MMM-dd-yyyy"), "Update")
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
        With ExpensesCreate
            .txParticular.Clear()
            .txPayeeName.Clear()
            .txAmount.Clear()
            .Button1.Enabled = True
            .Button2.Enabled = False
            .DateTimePicker1.Value = Date.Now
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column14" Then
            With ExpensesCreate
                .lblId.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txParticular.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txPayeeName.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                .txAmount.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .DateTimePicker1.Value = CDate(DataGridView1.CurrentRow.Cells(5).Value.ToString)
                .Button1.Enabled = False
                .Button2.Enabled = True
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
    End Sub
End Class