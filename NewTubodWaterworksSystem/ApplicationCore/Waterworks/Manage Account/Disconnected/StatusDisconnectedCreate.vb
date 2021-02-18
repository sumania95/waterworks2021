Imports MySql.Data.MySqlClient
Public Class StatusDisconnectedCreate
    Dim draggable As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        draggable = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion) = vbYes) Then
                cn.Open()
                cm = New MySqlCommand("sp_updateCustomerStatusActive", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txAccount.Text)
                cm.Parameters.AddWithValue("p2", "Changed to Active")
                cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                cm.Parameters.AddWithValue("Stat", "Active")
                cm.Parameters.AddWithValue("KeyNo", "")
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Record has been successfully updated.", vbInformation)
                With StatusAndReplacementDisconnected
                    .loadrecord()
                End With
                Me.Hide()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class