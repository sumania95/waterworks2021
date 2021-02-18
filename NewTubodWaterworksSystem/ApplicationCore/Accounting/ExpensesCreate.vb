Imports MySql.Data.MySqlClient
Public Class ExpensesCreate
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
        If txParticular.Text = String.Empty Or txPayeeName.Text = String.Empty Or txAmount.Text = String.Empty Then
            MsgBox("Warning : Missing field required", vbInformation)
        Else
            Try
                If (MsgBox("Are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_insertTreasuryExpenses", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", txParticular.Text)
                    cm.Parameters.AddWithValue("p2", txPayeeName.Text)
                    cm.Parameters.AddWithValue("p3", txAmount.Text)
                    cm.Parameters.AddWithValue("p4", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cm.Parameters.AddWithValue("p5", SpecialMain.ToolStripLabel4.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Record has been successfully saved.", vbInformation)
                    With Expenses
                        .loadrecord()
                    End With
                    txAmount.Clear()
                    txParticular.Clear()
                    txPayeeName.Clear()
                    DateTimePicker1.Value = Date.Now
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txParticular.Text = String.Empty Or txPayeeName.Text = String.Empty Or txAmount.Text = String.Empty Then
            MsgBox("Warning : Missing field required", vbInformation)
        Else
            Try
                If (MsgBox("Are you sure you want to update this record?", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateExpenses", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", txParticular.Text)
                    cm.Parameters.AddWithValue("p2", txPayeeName.Text)
                    cm.Parameters.AddWithValue("p3", txAmount.Text)
                    cm.Parameters.AddWithValue("p4", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cm.Parameters.AddWithValue("p5", lblId.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Record has been successfully updated.", vbInformation)
                    With Expenses
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

    Private Sub txAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
    End Sub
End Class