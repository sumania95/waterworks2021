Imports MySql.Data.MySqlClient
Public Class CustomerRegistration
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectCustomer_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("l1", ComboBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("Dateapplied").ToString
                DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Contact").ToString, dr.Item("Classification").ToString, dr.Item("Purok").ToString, dr.Item("Barangay").ToString, ddate.ToString("MM-dd-yyyy"), "Update", "Print Form")
            End While
            dr.Close()
            cn.Close()
            'Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
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
            .Allcustomer()
            .ReadyForInstallation()
            .Show()
        End With
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                ComboBox1.SelectedIndex = 0
                loadrecord()
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MetroTextBox1.Select()
        loadrecord()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With CustomerRegistrationCreate
            .cleartext()
            .cmbbarangay01()
            .Button1.Enabled = True
            .Button2.Enabled = False
            .DateTimePicker1.Value = Date.Now
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column14" Then
            With CustomerRegistrationCreate
                .cmbbarangay01()
                .txAccountNo.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .autofill()
                .Button1.Enabled = False
                .Button2.Enabled = True
                .ShowDialog()
            End With
        ElseIf colName = "Column7" Then
            With ReportViewer
                .TopLevel = False
                Main.Panel1.Controls.Add(ReportViewer)
                .BringToFront()
                .loadreportII()
                .Show()
            End With
        End If
    End Sub

End Class