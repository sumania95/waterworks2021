Imports MySql.Data.MySqlClient
Public Class ReadingRecordVisible

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
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectCustomerfilterActiveAndDescriptionId_ReadingRecord_1", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("p2", Main.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read
                'i += 1
                Dim ddate As Date
                ddate = dr.Item("PresentReadingDate").ToString
                DataGridView1.Rows.Add(dr.Item("Cluster").ToString, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, dr.Item("Barangay").ToString, dr.Item("PresentR").ToString, ddate.ToString("MMM-dd-yyyy"), dr.Item("ReadingPeriodId").ToString, dr.Item("Classification").ToString, dr.Item("BillingBalance").ToString, "Unhide")
            End While
            dr.Close()
            cn.Close()
            Label12.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column9" Then
            Try
                If (MsgBox("Are you sure you want to hide this record", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateReadingHide", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", DataGridView1.CurrentRow.Cells(1).Value.ToString())
                    cm.Parameters.AddWithValue("p2", "0")
                    cm.ExecuteNonQuery()
                    cn.Close()
                    loadrecord()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
    End Sub
End Class