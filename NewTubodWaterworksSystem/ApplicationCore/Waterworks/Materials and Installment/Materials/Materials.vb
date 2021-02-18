Imports MySql.Data.MySqlClient
Public Class Materials
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
            cm = New MySqlCommand("sp_selectMaterials_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim money As Double
                money = dr.Item("Price").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Description").ToString, dr.Item("Unit").ToString, money.ToString("₱ #,##0.00"), "Update")
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
        With MaterialsCreate
            .txDescription.Clear()
            .txLength.Clear()
            .txPrice.Clear()
            .Label5.ResetText()
            .ShowDialog()
        End With
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column14" Then
            With MaterialsCreate
                .Label5.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .autofill()
                .ShowDialog()
            End With
        End If
    End Sub
End Class