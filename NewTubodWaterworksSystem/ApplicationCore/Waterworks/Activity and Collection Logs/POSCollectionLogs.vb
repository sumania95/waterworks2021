Imports MySql.Data.MySqlClient
Public Class POSCollectionLogs
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
            cm = New MySqlCommand("sp_selectCollectionLog_POS", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"))
            cm.Parameters.AddWithValue("p2", DateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59"))
            'cm.Parameters.AddWithValue("p3", Collector.ToolStripLabel2.Text)
            cm.Parameters.AddWithValue("p3", CollectionMain.ToolStripLabel2.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                Dim money As Double
                money = dr.Item("Amount").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Type").ToString, dr.Item("OrNo").ToString, money.ToString("₱ #,##0.00"), ddate.ToString("MM-dd-yyyy"), ddate.ToString("hh:mm:ss tt"), dr.Item("User").ToString, "Cancel Payment")
            End While
            dr.Close()
            cn.Close()
            'For s As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1

            '    Dim sum As Double
            '    sum = sum + DataGridView1.Rows(s).Cells(5).Value
            '    Label4.Text = sum.ToString("₱ #,##0.00")

            'Next
            Label5.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadrecord()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column7" Then
            With CollectionLogsCreate
                .lblId.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
                .txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
                .autofill()
                .ShowDialog()
            End With
        End If
    End Sub
End Class