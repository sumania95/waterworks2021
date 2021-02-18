Imports MySql.Data.MySqlClient
Public Class UserAccount
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
        If txName.Text = Nothing Or txPass.Text = Nothing Or txUser.Text = Nothing Then
            MsgBox("Missing field required", vbInformation, Main.Label1.Text)
        Else
            If txPass.Text = txRePass.Text Then
                Try
                    If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertUserLogin", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txName.Text)
                        cm.Parameters.AddWithValue("p2", txUser.Text)
                        cm.Parameters.AddWithValue("p3", txPass.Text)
                        cm.Parameters.AddWithValue("p4", cmbType.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully updated.", vbInformation, Main.Label1.Text)
                        txName.Clear()
                        txPass.Clear()
                        txRePass.Clear()
                        txUser.Clear()
                        cmbType.SelectedIndex = -1
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            Else
                MsgBox("Password and confirm password does not match", vbInformation, Main.Label1.Text)
            End If
        End If
        
    End Sub
End Class