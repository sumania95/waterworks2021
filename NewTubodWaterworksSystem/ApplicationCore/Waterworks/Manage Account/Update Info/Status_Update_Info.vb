Imports MySql.Data.MySqlClient
Public Class Status_Update_Info
    Dim draggable As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer
    Public id As String

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
        Me.Dispose()
    End Sub
    Public Sub consumer_info(id)
        Try
            cn.Open()
            cm = New MySqlCommand("consumer_info", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("consumer_id", id)
            dr = cm.ExecuteReader
            While dr.Read
                txName.Text = dr.Item("Lastname").ToString.ToUpper + ", " + dr.Item("Firstname").ToString.ToUpper + " " + dr.Item("Middlename").ToString.ToUpper
                TextBox1.Text = dr.Item("MeterNo").ToString
                TextBox2.Text = dr.Item("PresentR").ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If (MsgBox("Are you sure you want to change this record", vbYesNo + vbQuestion) = vbYes) Then
                cn.Open()
                cm = New MySqlCommand("consumer_info_update_meter_initial_reading", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("username", Main.ToolStripLabel3.Text)
                cm.Parameters.AddWithValue("consumer_id", id)
                cm.Parameters.AddWithValue("meter_no", TextBox1.Text)
                cm.Parameters.AddWithValue("present_r", TextBox2.Text)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Successfully changed", vbInformation, Main.Label1.Text)
                StatusAndReplacementActive.loadrecord()
                Me.Hide()
            End If


        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class