Imports MySql.Data.MySqlClient
Public Class ConsumerHistoryPayment
    Public Sub autoConsumer()
        Try
            cn.Open()
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub
    Public Sub loadrecord()
        Try
            Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectConsumerLogs", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txAccount.Text)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                Dim ddate As Date
                ddate = dr.Item("DateCreated").ToString
                Dim money As Double
                money = dr.Item("Amount").ToString
                DataGridView1.Rows.Add(i, dr.Item("Id").ToString, dr.Item("Type").ToString, dr.Item("OrNo").ToString, money.ToString("₱ #,##0.00"), ddate.ToString("MM-dd-yyyy"), ddate.ToString("hh:mm:ss tt"), dr.Item("User").ToString)
            End While
            dr.Close()
            cn.Close()
            'Label2.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub
    Private Sub txName_TextChanged(sender As Object, e As EventArgs) Handles txName.TextChanged
        Try
            cn.Open()
            cm = New MySqlCommand("sp_autofillConsumers", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txName.Text)
            dr = cm.ExecuteReader
            While dr.Read
                txAccount.Text = dr.Item(0)
                txMeter.Text = dr.Item(1)
                txAccountMirror.Text = dr.Item(2)
            End While
            dr.Close()
            cn.Close()
            loadrecord()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class