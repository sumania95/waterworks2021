Imports MySql.Data.MySqlClient
Public Class AllocateZones
    Public Sub cmbbarangay()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectBarangay", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim barangay = dr.GetString("Barangay")
                ComboBox1.Items.Add(barangay)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub hideGridV()
        If ComboBox2.SelectedIndex = -1 Then
            DataGridView1.Columns("Column3").Visible = True
            DataGridView1.Columns("Column14").Visible = True
            DataGridView1.Columns("Column1").Visible = False
            DataGridView1.Columns("Column5").Visible = False
        ElseIf ComboBox2.SelectedIndex = 0 Then
            DataGridView1.Columns("Column3").Visible = True
            DataGridView1.Columns("Column14").Visible = True
            DataGridView1.Columns("Column1").Visible = False
            DataGridView1.Columns("Column5").Visible = False
        ElseIf ComboBox2.SelectedIndex = 1 Then
            DataGridView1.Columns("Column1").Visible = True
            DataGridView1.Columns("Column5").Visible = True
            DataGridView1.Columns("Column3").Visible = False
            DataGridView1.Columns("Column14").Visible = False
        End If

    End Sub
    Public Sub loadrecord()
        Try
            If ComboBox2.SelectedIndex = -1 Or ComboBox2.Text = "Select Zones" Then
                DataGridView1.Rows.Clear()
                Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
                hideGridV()
            ElseIf ComboBox2.SelectedIndex = 0 Then
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                hideGridV()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomerfilterandorderCluster_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    DataGridView1.Rows.Add(i, dr.Item("Cluster").ToString, dr.Item("HouseNo").ToString, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, "Cluster", "Sequence")
                End While
                dr.Close()
                cn.Close()
                Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
            ElseIf ComboBox2.SelectedIndex = 1 Then
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                hideGridV()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomerfilterandorderHouseNo_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    DataGridView1.Rows.Add(i, dr.Item("Cluster").ToString, dr.Item("HouseNo").ToString, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, "Cluster", "Sequence")
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
            .Show()
        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MetroTextBox1.Select()
        loadrecord()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
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
            With AllocateZonesCluster
                .txCluster.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                .txAccount.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .ShowDialog()
            End With
        ElseIf colName = "Column5" Then
            With AllocateZonesSequenceNo
                .txSequence.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                .txAccount.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                .txName.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        MetroTextBox1.Select()
    End Sub
End Class