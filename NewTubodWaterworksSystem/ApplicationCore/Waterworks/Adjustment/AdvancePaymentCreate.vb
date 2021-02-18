Imports MySql.Data.MySqlClient
Public Class AdvancePaymentCreate
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
            Dim query As String

            query = "Select CONCAT(Lastname,', ',Firstname,' ',Middlename) as Name FROM a_customer"
            cm = New MySqlCommand(query, cn)
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
            Dim query As String
            Dim bal As Double
            query = "SELECT AccountNo,BillingBalance, CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')) FROM a_customer WHERE CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            While dr.Read
                txAccountNo.Text = dr.Item(0)
                bal = dr.Item(1)
                txBalance.Text = bal.ToString("₱ #,##0.00")
                txAccountMirror.Text = dr.Item(2)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txAmount.Text = String.Empty Or txOR.Text = String.Empty Then
            MsgBox("Warning : Missing field required", vbInformation, Main.Label1.Text)
        Else
            Try
                cn.Open()
                Dim i As Integer
                i = 0
                cm = New MySqlCommand("sp_validateOfficialReciept", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txOR.Text)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cm)
                da.Fill(dt)
                i = Convert.ToInt32(dt.Rows.Count.ToString())
                If i = 0 Then
                    cn.Close()
                    Try
                        If (MsgBox("Are you sure you want to proceed this transaction?", vbYesNo + vbQuestion, Label1.Text) = vbYes) Then
                            cn.Open()
                            cm = New MySqlCommand("sp_POSbillingBalance", cn)
                            cm.CommandType = CommandType.StoredProcedure
                            cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                            cm.Parameters.AddWithValue("p2", "Service Connection")
                            cm.Parameters.AddWithValue("p3", txOR.Text)
                            cm.Parameters.AddWithValue("p4", txAmount.Text)
                            cm.Parameters.AddWithValue("p5", Main.ToolStripLabel3.Text)
                            cm.ExecuteNonQuery()
                            cn.Close()
                            MsgBox("Transaction has been successfully saved.", vbInformation, Main.Label1.Text)
                            txAccountMirror.Clear()
                            txAccountNo.Clear()
                            txAmount.Clear()
                            txBalance.Clear()
                            txName.Clear()
                            txOR.Clear()
                        End If

                    Catch ex As Exception
                        cn.Close()
                        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
                    End Try
                Else
                    cn.Close()
                    MsgBox("Warning : OR Number Duplicated!", vbInformation, Label1.Text)
                End If
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
            End Try
        End If
        
    End Sub

    Private Sub txAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub txOR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txOR.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub
End Class