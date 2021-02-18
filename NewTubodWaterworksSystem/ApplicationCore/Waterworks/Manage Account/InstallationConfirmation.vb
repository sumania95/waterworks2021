Imports MySql.Data.MySqlClient
Public Class InstallationConfirmation
    Public Sub loadrecord()
        Try
            If CheckBox1.Checked Then
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomerInstallation_searchFilterMeterBalance", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    'Dim ddate As Date
                    'ddate = dr.Item("Dateapplied").ToString
                    DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Contact").ToString, dr.Item("Classification").ToString, dr.Item("Purok").ToString, dr.Item("Barangay").ToString, "Install Meter")
                End While
                dr.Close()
                cn.Close()
                Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
            Else
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomerInstallation_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    'Dim ddate As Date
                    'ddate = dr.Item("Dateapplied").ToString
                    DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Contact").ToString, dr.Item("Classification").ToString, dr.Item("Purok").ToString, dr.Item("Barangay").ToString, "Install Meter")
                End While
                dr.Close()
                cn.Close()
                Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
            End If
        Catch ex As Exception
            cn.Close()
            DataGridView1.Rows.Clear()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .ReadyForInstallation()
            .Show()
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
            With InstallationConfirmationCreate
                .txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        loadrecord()
    End Sub
End Class