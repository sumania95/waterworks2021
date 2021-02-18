Imports MySql.Data.MySqlClient
Public Class CollectionORScanning

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
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectORScanning_search", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                Dim money As Double
                money = dr.Item("Amount").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Type").ToString, dr.Item("OrNo").ToString, money.ToString("₱ #,##0.00"), ddate.ToString("MM-dd-yyyy"), ddate.ToString("hh:mm:ss tt"), dr.Item("User").ToString)
            End While
            dr.Close()
            cn.Close()
            'Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
            Case Keys.Escape
                Me.Hide()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MetroTextBox1.Clear()
        loadrecord()
    End Sub
End Class