Imports MySql.Data.MySqlClient
Public Class Messages
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
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectMessagesServer", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Messages").ToString, dr.Item("SendFrom").ToString, dr.Item("SendTo").ToString, ddate.ToString("MM-dd-yyyy"), ddate.ToString("hh:mm:ss tt"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub
    Public Sub LoginName()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectLoginName", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim user = dr.GetString("Name")
                ComboBox1.Items.Add(user)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txMessages.Text = String.Empty Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Missing field required!", vbInformation)
        Else
            Try
                cn.Open()
                cm = New MySqlCommand("sp_insertMessages", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txMessages.Text)
                cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                cm.Parameters.AddWithValue("p3", "Administrator")
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Message has been successfully sent.", vbInformation)
                loadrecord()
                txMessages.Clear()
                ComboBox1.SelectedIndex = -1

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadrecord()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If (MsgBox("Are you sure you want to delete all messages?", vbYesNo + vbQuestion) = vbYes) Then
                cn.Open()
                cm = New MySqlCommand("sp_deleteMessages", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Messages has been successfully deleted.", vbInformation)
                loadrecord()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub

    Private Sub txMessages_KeyDown(sender As Object, e As KeyEventArgs) Handles txMessages.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button1.PerformClick()
        End Select
    End Sub
End Class