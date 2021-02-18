Imports MySql.Data.MySqlClient
Public Class ReadingPeriodCreate
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
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Warning : Empty field required!", vbInformation)
        Else
            Try
                cn.Open()
                Dim i As Integer
                i = 0
                cm = New MySqlCommand("sp_validateReadingPeriod", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", ComboBox1.Text + " " + Main.ToolStripLabel5.Text)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cm)
                da.Fill(dt)
                i = Convert.ToInt32(dt.Rows.Count.ToString())
                If i = 0 Then
                    cn.Close()
                    Try
                        If (MsgBox("Are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes) Then
                            cn.Open()
                            cm = New MySqlCommand("sp_insertReadingPeriod", cn)
                            cm.CommandType = CommandType.StoredProcedure
                            cm.Parameters.AddWithValue("p1", ComboBox1.Text + " " + Main.ToolStripLabel5.Text)
                            cm.Parameters.AddWithValue("p2", Main.ToolStripLabel5.Text)
                            cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                            cm.Parameters.AddWithValue("d1", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                            cm.Parameters.AddWithValue("d2", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
                            cm.Parameters.AddWithValue("d3", DateTimePicker3.Value.ToString("yyyy-MM-dd"))
                            cm.Parameters.AddWithValue("d4", DateTimePicker4.Value.ToString("yyyy-MM-dd"))
                            cm.ExecuteNonQuery()
                            cn.Close()
                            MsgBox("Record has been successfully saved.", vbInformation)
                            With ReadingPeriod
                                .loadrecord()
                            End With
                            With Main
                                .ReadingPeriod001()
                            End With
                            Me.Hide()
                        End If

                    Catch ex As Exception
                        cn.Close()
                        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                    End Try
                Else
                    cn.Close()
                    MsgBox("Warning : Reading Period Duplicated!", vbInformation)
                End If
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub

    Public Sub Month001()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectMonth", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim month02 = dr.GetString("Month")
                ComboBox1.Items.Add(month02)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If (MsgBox("Are you sure you want to update this record?", vbYesNo + vbQuestion) = vbYes) Then
                cn.Open()
                cm = New MySqlCommand("sp_updateReadingPeriod", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", lblId.Text)
                cm.Parameters.AddWithValue("p2", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                cm.Parameters.AddWithValue("p3", DateTimePicker2.Value.ToString("yyyy-MM-dd"))
                cm.Parameters.AddWithValue("p4", DateTimePicker3.Value.ToString("yyyy-MM-dd"))
                cm.Parameters.AddWithValue("p5", DateTimePicker4.Value.ToString("yyyy-MM-dd"))
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record has been successfully updated.", vbInformation)
                With ReadingPeriod
                    .loadrecord()
                End With
                With Main
                    .ReadingPeriod001()
                End With
                Me.Hide()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class