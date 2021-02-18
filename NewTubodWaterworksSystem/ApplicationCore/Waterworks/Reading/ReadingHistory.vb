Imports MySql.Data.MySqlClient
Public Class ReadingHistory
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
    Public Sub autoConsumer()
        Try
            cn.Open()
            'Dim query As String

            'query = "Select CONCAT(Lastname,', ',Firstname,' ',Middlename) as Name FROM a_customer"
            cm = New MySqlCommand("sp_autocompleteConsumer", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            Dim autoco As New AutoCompleteStringCollection()

            While dr.Read
                autoco.Add(dr("Name"))
            End While
            dr.Close()
            txName.AutoCompleteMode = AutoCompleteMode.Suggest
            txName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txName.AutoCompleteCustomSource = autoco
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub

    Private Sub txName_TextChanged(sender As Object, e As EventArgs) Handles txName.TextChanged
        Try
            cn.Open()
            'Dim query As String

            'query = "SELECT AccountNo,IFNULL(MeterNo,''),CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')) FROM a_customer WHERE CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"

            cm = New MySqlCommand("sp_autofillConsumers", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txName.Text)
            dr = cm.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item(0)
                TextBox2.Text = dr.Item(1)
                TextBox3.Text = dr.Item(2)
            End While
            dr.Close()
            cn.Close()
            loadrecord()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("reading_history", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", TextBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim amount As Double
                amount = dr.Item("Amount").ToString
                Dim consumption As Double
                consumption = dr.Item("Consumption").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("ReadingPeriod").ToString, consumption.ToString("#,##0"), amount.ToString("₱ #,##0.00"), "Cancel", dr.Item("readingperiod_id").ToString)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column4" Then
            Try

                If (Val(DataGridView1.CurrentRow.Cells(6).Value.ToString()) = Val(Main.ToolStripLabel4.Text)) Then
                    Dim amount_increase As Boolean = False
                    cn.Open()
                    cm = New MySqlCommand("consumer_info", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("consumer_id", TextBox1.Text)
                    dr = cm.ExecuteReader
                    While dr.Read
                        If Val(dr.Item("BillingBalance").ToString) >= Val(dr.Item("Amount").ToString) Then
                            amount_increase = True
                        Else
                            amount_increase = False
                        End If
                    End While
                    dr.Close()
                    cn.Close()
                    If amount_increase = True Then
                        If (MsgBox("Are you sure you want to cancel this record", vbYesNo + vbQuestion) = vbYes) Then
                            cn.Open()
                            cm = New MySqlCommand("reading_history_cancelled", cn)
                            cm.CommandType = CommandType.StoredProcedure
                            cm.Parameters.AddWithValue("reading_id", DataGridView1.CurrentRow.Cells(1).Value.ToString())
                            cm.Parameters.AddWithValue("consumer_id", TextBox1.Text)
                            cm.Parameters.AddWithValue("username", Main.ToolStripLabel3.Text)
                            cm.ExecuteNonQuery()
                            cn.Close()
                            MsgBox("Successfully cancelled", vbInformation, Main.Label1.Text)
                            loadrecord()
                        End If
                    Else
                        MsgBox("Consumer already process the payment", vbInformation, Main.Label1.Text)
                    End If
                    
                Else
                    MsgBox("Present reading period is allowed to cancel", vbExclamation, Main.Label1.Text)
                End If


            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub
End Class