Imports MySql.Data.MySqlClient
Public Class StatusAndReplacementActive
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectCustomerfilterorderStatus_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("p2", Label3.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Classification").ToString, dr.Item("MeterNo").ToString, dr.Item("Barangay").ToString, dr.Item("KeyNo").ToString, "Status", "Replace", "Print Form", dr.Item("Status").ToString, "Initial Update")
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            DataGridView1.Rows.Clear()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        'If CheckBox1.Checked = True Then
        '    Try
        '        Dim i As Integer = 0
        '        DataGridView1.Rows.Clear()
        '        cn.Open()
        '        cm = New MySqlCommand("sp_selectCustomerfilterOrderStatusDisconnectionList_search", cn)
        '        cm.CommandType = CommandType.StoredProcedure
        '        cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
        '        cm.Parameters.AddWithValue("p2", Label3.Text)
        '        cm.Parameters.AddWithValue("p3", cmbBarangay.Text)
        '        dr = cm.ExecuteReader
        '        While dr.Read
        '            i += 1
        '            DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Classification").ToString, dr.Item("MeterNo").ToString, dr.Item("Barangay").ToString, dr.Item("KeyNo").ToString, "Status", "Replace", "Print Form", dr.Item("Status").ToString)
        '        End While
        '        dr.Close()
        '        cn.Close()
        '        Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        '    Catch ex As Exception
        '        cn.Close()
        '        DataGridView1.Rows.Clear()
        '        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        '    End Try
        'Else
        '    Try
        '        Dim i As Integer = 0
        '        DataGridView1.Rows.Clear()
        '        cn.Open()
        '        cm = New MySqlCommand("sp_selectCustomerfilterorderStatus_search", cn)
        '        cm.CommandType = CommandType.StoredProcedure
        '        cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
        '        cm.Parameters.AddWithValue("p2", Label3.Text)
        '        cm.Parameters.AddWithValue("p3", cmbBarangay.Text)
        '        dr = cm.ExecuteReader
        '        While dr.Read
        '            i += 1
        '            DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Classification").ToString, dr.Item("MeterNo").ToString, dr.Item("Barangay").ToString, dr.Item("KeyNo").ToString, "Status", "Replace", "Print Form", dr.Item("Status").ToString)
        '        End While
        '        dr.Close()
        '        cn.Close()
        '        Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        '    Catch ex As Exception
        '        cn.Close()
        '        DataGridView1.Rows.Clear()
        '        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        '    End Try
        'End If

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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        MetroTextBox1.Select()
        loadrecord()
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
            With StatusAndReplacementStatus
                .txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .cmbStatus.SelectedIndex = -1
                .Label2.Visible = False
                .txKey.Visible = False
                .ShowDialog()
            End With
        ElseIf colName = "Column5" Then
            With StatusAndReplacementReplace
                .txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txMeterOld.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .txMeterNew.Clear()
                .txInitialReading.Clear()
                .txReason.Clear()
                .ShowDialog()
            End With
        ElseIf colName = "Column6" Then
            With PrintRequestFormForDCorMPO
                .TopLevel = False
                Main.Panel1.Controls.Add(PrintRequestFormForDCorMPO)
                .BringToFront()
                .loadreport()
                .Show()
            End With
        ElseIf colName = "Column8" Then
            With Status_Update_Info
                .id = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .consumer_info(DataGridView1.CurrentRow.Cells(1).Value.ToString)
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub cmbBarangay_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadrecord()
        MetroTextBox1.Select()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        loadrecord()
        MetroTextBox1.Select()
    End Sub
End Class