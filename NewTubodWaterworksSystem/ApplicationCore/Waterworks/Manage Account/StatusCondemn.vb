Imports MySql.Data.MySqlClient
Public Class StatusCondemn
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
            cm = New MySqlCommand("sp_selectCustomerfilterOrderStatusDCMPO_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("p2", Label3.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Classification").ToString, dr.Item("MeterNo").ToString, dr.Item("Barangay").ToString, dr.Item("KeyNo").ToString, "Change", "Replace", "Print Form", dr.Item("Status").ToString)
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            DataGridView1.Rows.Clear()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
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
            With StatusCondemnCreate
                .txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txMeterNo.Clear()
                .txInitialReading.Clear()
                .cmbMeterSize.SelectedIndex = -1
                .ShowDialog()
            End With
        ElseIf colName = "Column6" Then
            With PrintDisconnectedForm
                .TopLevel = False
                Main.Panel1.Controls.Add(PrintDisconnectedForm)
                .BringToFront()
                .loadreport01()
                .Show()
            End With
        End If
    End Sub
End Class