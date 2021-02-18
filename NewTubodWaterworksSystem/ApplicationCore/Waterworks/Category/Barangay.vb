Imports MySql.Data.MySqlClient
Public Class Barangay
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectBarangay_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Barangay").ToString, dr.Item("Stat").ToString, dr.Item("ClassType").ToString, dr.Item("Implementation").ToString, "Action", "Update")
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With BarangayCreate
            .txBarangay.Clear()
            .ShowDialog()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column14" Then
            If DataGridView1.CurrentRow.Cells(3).Value.ToString() = "Active" Then

                Try
                    If (MsgBox("Are you sure you want to InActive this record?", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_updateBarangayStat", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", DataGridView1.CurrentRow.Cells(1).Value.ToString())
                        cm.Parameters.AddWithValue("p2", "InActive")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        loadrecord()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            Else
                Try
                    If (MsgBox("Are you sure you want to Active this record?", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_updateBarangayStat", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", DataGridView1.CurrentRow.Cells(1).Value.ToString())
                        cm.Parameters.AddWithValue("p2", "Active")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        loadrecord()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If
        ElseIf colName = "Column3" Then
            With BarangayPtypeUpdate
                .IdLabel.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
                .txBarangay.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
                .ComboBox2.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
                .ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
                .ComboBox3.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()
                .ShowDialog()
            End With
        End If
    End Sub
End Class