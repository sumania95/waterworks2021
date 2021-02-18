Imports MySql.Data.MySqlClient
Public Class StatusAndReplacementStatus
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

    Private Sub TxKey_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txKey.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbStatus.SelectedIndex = -1 Then
            MsgBox("Warning: Empty field required!", vbInformation)
        ElseIf cmbStatus.SelectedIndex = 0 Then
            If txKey.Text = String.Empty Then
                MsgBox("Warning: Empty field required!", vbInformation)
            Else
                Try
                    If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_updateCustomerStatusDisconnected", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccount.Text)
                        cm.Parameters.AddWithValue("p2", "Changed to Disconnected")
                        cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("Stat", cmbStatus.Text)
                        cm.Parameters.AddWithValue("KeyNo", txKey.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()

                        MsgBox("Record has been successfully updated.", vbInformation)
                        With StatusAndReplacementActive
                            .loadrecord()
                        End With
                        Me.Hide()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If

        ElseIf cmbStatus.SelectedIndex = 1 Then
            Try
                If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateCustomerStatusCondemn", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                    cm.Parameters.AddWithValue("p2", "Changed to Condemn")
                    cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                    cm.Parameters.AddWithValue("Stat", cmbStatus.Text)
                    cm.Parameters.AddWithValue("KeyNo", txKey.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()

                    MsgBox("Record has been successfully updated.", vbInformation)
                    With StatusAndReplacementActive
                        .loadrecord()
                    End With
                    Me.Hide()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        Else

        End If
    End Sub

    Private Sub CmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedIndex = -1 Then
            Label2.Visible = False
            txKey.Visible = False
        ElseIf cmbStatus.SelectedIndex = 0 Then
            Label2.Visible = True
            txKey.Visible = True
        ElseIf cmbStatus.SelectedIndex = 1 Then
            Label2.Visible = False
            txKey.Visible = False
        End If
    End Sub
End Class