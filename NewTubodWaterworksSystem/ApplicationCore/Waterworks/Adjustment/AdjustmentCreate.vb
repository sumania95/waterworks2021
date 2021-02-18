Imports MySql.Data.MySqlClient
Public Class AdjustmentCreate
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
        Dim bal As Double
        If ComboBox1.SelectedIndex = 0 Then
            Try
                cn.Open()
                Dim query As String

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
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Try
                cn.Open()
                Dim query As String
                query = "SELECT AccountNo,MeterBalance,CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')) FROM a_customer WHERE CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"
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
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Try
                cn.Open()
                Dim query As String
                query = "SELECT AccountNo,IFNULL(Installement,0),CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')) FROM a_customer WHERE CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"
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
        Else

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        txName.Clear()
        txAccountNo.Clear()
        txAccountMirror.Clear()
        txBalance.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = -1 Or txAmount.Text = String.Empty Or txReason.Text = String.Empty Or txAmount.Text = 0 Or txAccountNo.Text = String.Empty Then
            MsgBox("Warning : Missing field required!", vbInformation)
        ElseIf ComboBox1.SelectedIndex = 0 Then
            If ComboBox2.SelectedIndex = -1 Then
                MsgBox("Warning : Missing field required!", vbInformation)
            ElseIf ComboBox2.SelectedIndex = 0 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentServiceConnectionAdd", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Billing Balance added " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            ElseIf ComboBox2.SelectedIndex = 1 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentServiceConnectionRemove", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Billing Balance deducted " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If
        ElseIf ComboBox1.SelectedIndex = 1 Then
            If ComboBox2.SelectedIndex = -1 Then
                MsgBox("Warning : Missing field required!", vbInformation)
            ElseIf ComboBox2.SelectedIndex = 0 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentWaterMeterAdd", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Meter Balance added " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            ElseIf ComboBox2.SelectedIndex = 1 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentWaterMeterRemove", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Meter Balance deducted " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If
        ElseIf ComboBox1.SelectedIndex = 2 Then
            If ComboBox2.SelectedIndex = -1 Then
                MsgBox("Warning : Missing field required!", vbInformation)
            ElseIf ComboBox2.SelectedIndex = 0 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentInstallmentAdd", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Installment Balance added " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            ElseIf ComboBox2.SelectedIndex = 1 Then
                Try
                    If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_insertAdjustmentInstallmentRemove", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                        cm.Parameters.AddWithValue("p2", ComboBox1.Text)
                        cm.Parameters.AddWithValue("p3", txAmount.Text)
                        cm.Parameters.AddWithValue("p4", ComboBox2.Text)
                        cm.Parameters.AddWithValue("p5", txReason.Text)
                        cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                        cm.Parameters.AddWithValue("p7", "Adjust Installment Balance deducted " & txAmount.Text & "")
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully submitted.", vbInformation)
                        txAccountNo.Clear()
                        txAccountMirror.Clear()
                        txName.Clear()
                        txBalance.Clear()
                        ComboBox1.SelectedIndex = -1
                        txAmount.Clear()
                        ComboBox2.SelectedIndex = -1
                        txReason.Clear()
                        With Adjustment
                            .loadrecord()
                        End With
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                End Try
            End If
        End If
    End Sub
End Class