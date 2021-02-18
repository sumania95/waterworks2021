Imports MySql.Data.MySqlClient
Public Class MaterialInstallment
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With MaterialInstallmentCreate
            .DateTimePicker1.Value = Date.Now
            .txName.Clear()
            .txAccount.Clear()
            .txAccountMirror.Clear()
            .txDescription.Clear()
            .txPrice.Clear()
            .calculate()
            .autoConsumer()
            .autoMaterials()
            .ShowDialog()
        End With
    End Sub
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectInstallment", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString()
                Dim amount As Double
                amount = dr.Item("AmountDue").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("Materials").ToString, dr.Item("Quantity").ToString, amount.ToString("₱ #,##0.00"), ddate.ToString("MM-dd-yyyy"), dr.Item("User").ToString)
            End While
            dr.Close()
            cn.Close()
            Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
        
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
    End Sub
End Class