Imports MySql.Data.MySqlClient
Public Class MaterialsCreate
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label5.Text = Nothing Then
            If txDescription.Text = String.Empty Or txPrice.Text = String.Empty Or txLength.Text = String.Empty Then
                MsgBox("Warning : Missing field required!", vbInformation)
            Else
                Try
                    If (MsgBox("Are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertMaterials", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txDescription.Text)
                        cm.Parameters.AddWithValue("s1", txLength.Text)
                        cm.Parameters.AddWithValue("p2", txPrice.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully saved.", vbInformation)
                        With Materials
                            .loadrecord()
                        End With
                        txDescription.Clear()
                        txLength.Clear()
                        txPrice.Clear()
                        Me.Hide()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If
        Else
            Try
                If (MsgBox("Are you sure you want to update this record?", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateMaterials", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", Label5.Text)
                    cm.Parameters.AddWithValue("p2", txDescription.Text)
                    cm.Parameters.AddWithValue("p3", txLength.Text)
                    cm.Parameters.AddWithValue("p4", txPrice.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Record has been successfully updated.", vbInformation)
                    With Materials
                        .loadrecord()
                    End With
                    Me.Hide()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
        

    End Sub

    Private Sub txPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txPrice.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub
    Public Sub autofill()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_autofillMaterials", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Label5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                txDescription.Text = dr.Item(1).ToString
                txLength.Text = dr.Item(2).ToString
                txPrice.Text = dr.Item(3).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            Label5.ResetText()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)

        End Try
    End Sub

End Class