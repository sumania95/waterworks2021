Imports MySql.Data.MySqlClient
Public Class ApplicationSetting
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
    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_applicationSettings", cn)
            dr = cm.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item(1)
                TextBox2.Text = dr.Item(2)
                ComboBox1.Text = dr.Item(3)
                txReminders.Text = dr.Item(4)
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = String.Empty Or TextBox2.Text = String.Empty Or ComboBox1.Text = Nothing Then
            MsgBox("Warning : Missing field required!", vbInformation)
        Else
            Try
                If (MsgBox("Are you sure you want to update this record?", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateApplicationSetting", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", TextBox1.Text)
                    cm.Parameters.AddWithValue("p2", TextBox2.Text)
                    cm.Parameters.AddWithValue("p3", ComboBox1.Text)
                    cm.Parameters.AddWithValue("p4", "1")
                    cm.Parameters.AddWithValue("r1", txReminders.Text)

                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Record has been successfully updated.", vbInformation)
                    With Main
                        .ApplicationName()
                    End With
                    Me.Hide()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Public Sub year001()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectCalendarYear", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim year02 = dr.GetString("Year")
                ComboBox1.Items.Add(year02)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class