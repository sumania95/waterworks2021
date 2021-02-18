Imports MySql.Data.MySqlClient
Public Class ReadingRecord
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub
    Public Sub cmbbarangay01()
        cmbBarangay.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectBarangay", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim barangay = dr.GetString("Barangay")
                cmbBarangay.Items.Add(barangay)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub loadrecord()
        Try
            'Dim i As Integer = 0
            DataGridView1.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("sp_selectCustomerfilterActiveAndDescriptionId_ReadingRecord", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
            cm.Parameters.AddWithValue("p2", Main.ToolStripLabel4.Text)
            cm.Parameters.AddWithValue("p3", cmbBarangay.Text)
            dr = cm.ExecuteReader
            While dr.Read
                'i += 1
                Dim ddate As Date
                ddate = dr.Item("PresentReadingDate").ToString
                DataGridView1.Rows.Add(dr.Item("Cluster").ToString, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, dr.Item("PresentR").ToString, ddate.ToString("MMM-dd-yyyy"), dr.Item("ReadingPeriodId").ToString, dr.Item("Classification").ToString, dr.Item("BillingBalance").ToString, dr.Item("MeterBalance").ToString, "Hide", dr.Item("MeterSize").ToString)
            End While
            dr.Close()
            cn.Close()
            Label12.Text = "" & DataGridView1.RowCount & " record(s) found."
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try

    End Sub
    Sub loadbarangay()
        lblimplement.ResetText()
        Try
            cn.Open()
            Dim query As String
            query = "Select * FROM s_Barangay WHERE Barangay like '" & cmbBarangay.Text & "'"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            While dr.Read
                lblimplement.Text = dr.Item(4)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub
    Private Sub CmbBarangay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBarangay.SelectedIndexChanged
        loadrecord()
        loadbarangay()
        txPres.Clear()
        txAccount.Clear()
        txName.Clear()
        txMeterNo.Clear()
        txprev.Clear()
        txPres.Clear()
        txAmount.Clear()
        txConsumption.Clear()

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        txPres.Select()
        txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        txMeterNo.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        txClassification.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString()
        txprev.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
        txPrevDate.Text = CDate(DataGridView1.CurrentRow.Cells(5).Value).ToString("yyyy-MM-dd")
        txUnpaid.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString()
        txMeterBalance.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString()
        txMeterSize.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString()
        tarifarates()
        If Val(txprev.Text) > Val(txPres.Text) Then
            txprev.Enabled = True
        Else
            txprev.Enabled = False
        End If
    End Sub
    Public Sub tarifarates()
        Dim consumption As Double
        Dim amount As Double
        consumption = Val(txPres.Text) - Val(txprev.Text)
        txConsumption.Text = consumption
        If txPres.Text = String.Empty Then
            consumption = 0
            amount = 0
            txConsumption.Text = consumption.ToString()
            txAmount.Text = amount.ToString("##0.00")
        ElseIf Val(txPres.Text) < Val(txprev.Text) Then
            consumption = 0
            amount = 0
            txConsumption.Text = consumption.ToString()
            txAmount.Text = amount.ToString("##0.00")
        Else
            If lblimplement.Text = "Yes" Then
                'Actual Charge
                If (txClassification.Text = "Residential" Or txClassification.Text = "Industrial" Or txClassification.Text = "Commercial") And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txConsumption.Text > 50 Then
                        amount = (Val(txConsumption.Text) * 35) - 1005
                    ElseIf txConsumption.Text > 40 Then
                        amount = (Val(txConsumption.Text) * 30) - 755
                    ElseIf txConsumption.Text > 30 Then
                        amount = (Val(txConsumption.Text) * 20) - 355
                    ElseIf txConsumption.Text > 25 Then
                        amount = (Val(txConsumption.Text) * 15) - 205
                    ElseIf txConsumption.Text > 20 Then
                        amount = (Val(txConsumption.Text) * 10) - 80
                    ElseIf txConsumption.Text > 15 Then
                        amount = (Val(txConsumption.Text) * 8) - 40
                    ElseIf txConsumption.Text > 10 Then
                        amount = (Val(txConsumption.Text) * 6) - 10
                    ElseIf txConsumption.Text > 0 Then
                        amount = 50
                    Else
                        amount = 50
                    End If
                ElseIf (txClassification.Text = "Government") And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txConsumption.Text > 50 Then
                        amount = (Val(txConsumption.Text) * 35) - 1055
                    ElseIf txConsumption.Text > 40 Then
                        amount = (Val(txConsumption.Text) * 30) - 805
                    ElseIf txConsumption.Text > 30 Then
                        amount = (Val(txConsumption.Text) * 20) - 405
                    ElseIf txConsumption.Text > 25 Then
                        amount = (Val(txConsumption.Text) * 15) - 255
                    ElseIf txConsumption.Text > 20 Then
                        amount = (Val(txConsumption.Text) * 10) - 130
                    ElseIf txConsumption.Text > 15 Then
                        amount = (Val(txConsumption.Text) * 8) - 90
                    ElseIf txConsumption.Text > 10 Then
                        amount = (Val(txConsumption.Text) * 6) - 60
                    Else
                        amount = 0
                    End If
                ElseIf txClassification.Text = "Bulk Sale" And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txConsumption.Text > 0 Then
                        amount = Val(txConsumption.Text) * 30
                    End If
                ElseIf txClassification.Text = "Bulk Sale" And txMeterSize.Text = "3 inches" Then
                    If txConsumption.Text > 50 Then
                        amount = (Val(txConsumption.Text) * 45) + 4815
                    ElseIf txConsumption.Text > 40 Then
                        amount = (Val(txConsumption.Text) * 40) + 5065
                    ElseIf txConsumption.Text > 30 Then
                        amount = (Val(txConsumption.Text) * 30) + 5465
                    ElseIf txConsumption.Text > 25 Then
                        amount = (Val(txConsumption.Text) * 25) + 5615
                    ElseIf txConsumption.Text > 20 Then
                        amount = (Val(txConsumption.Text) * 20) + 5740
                    ElseIf txConsumption.Text > 15 Then
                        amount = (Val(txConsumption.Text) * 16) + 5820
                    ElseIf txConsumption.Text > 10 Then
                        amount = (Val(txConsumption.Text) * 12) + 5880
                    ElseIf txConsumption.Text > 0 Then
                        amount = 6000
                    Else
                        amount = 0
                    End If
                ElseIf txClassification.Text = "Bulk Sale" And txMeterSize.Text = "4 inches" Then
                    If txConsumption.Text > 50 Then
                        amount = (Val(txConsumption.Text) * 45) + 10815
                    ElseIf txConsumption.Text > 40 Then
                        amount = (Val(txConsumption.Text) * 40) + 11065
                    ElseIf txConsumption.Text > 30 Then
                        amount = (Val(txConsumption.Text) * 30) + 11465
                    ElseIf txConsumption.Text > 25 Then
                        amount = (Val(txConsumption.Text) * 25) + 11615
                    ElseIf txConsumption.Text > 20 Then
                        amount = (Val(txConsumption.Text) * 20) + 11740
                    ElseIf txConsumption.Text > 15 Then
                        amount = (Val(txConsumption.Text) * 16) + 11820
                    ElseIf txConsumption.Text > 10 Then
                        amount = (Val(txConsumption.Text) * 12) + 11880
                    ElseIf txConsumption.Text > 0 Then
                        amount = 12000
                    Else
                        amount = 0
                    End If
                End If
            Else
                'Minimum Charge
                If (txClassification.Text = "Residential" Or txClassification.Text = "Commercial" Or txClassification.Text = "Industrial") And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txConsumption.Text > 0 Then
                        amount = 50
                    Else
                        amount = 50
                    End If
                ElseIf (txClassification.Text = "Government") And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txAccount.Text = "950" Then
                        If txConsumption.Text > 50 Then
                            amount = (Val(txConsumption.Text) * 35) - 1055
                        ElseIf txConsumption.Text > 40 Then
                            amount = (Val(txConsumption.Text) * 30) - 805
                        ElseIf txConsumption.Text > 30 Then
                            amount = (Val(txConsumption.Text) * 20) - 405
                        ElseIf txConsumption.Text > 25 Then
                            amount = (Val(txConsumption.Text) * 15) - 255
                        ElseIf txConsumption.Text > 20 Then
                            amount = (Val(txConsumption.Text) * 10) - 130
                        ElseIf txConsumption.Text > 15 Then
                            amount = (Val(txConsumption.Text) * 8) - 90
                        ElseIf txConsumption.Text > 10 Then
                            amount = (Val(txConsumption.Text) * 6) - 60
                        Else
                            amount = 0
                        End If
                    Else
                        If txConsumption.Text > 10 Then
                            amount = 50
                        Else
                            amount = 0
                        End If
                    End If
                ElseIf txClassification.Text = "Bulk Sale" And (txMeterSize.Text = "15 mm" Or txMeterSize.Text = "20 mm") Then
                    If txConsumption.Text > 0 Then
                        amount = Val(txConsumption.Text) * 30
                    End If
                End If
            End If
            txAmount.Text = amount.ToString("##0.00")
        End If
    End Sub

    Private Sub TxPres_TextChanged(sender As Object, e As EventArgs) Handles txPres.TextChanged
        tarifarates()
        If Val(txprev.Text) > Val(txPres.Text) Then
            txprev.Enabled = True
        Else
            txprev.Enabled = False
        End If
    End Sub

    Private Sub TxPres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txPres.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub Txprev_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txprev.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txPres.Select()
        txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        txName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        txMeterNo.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        txClassification.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString()
        txprev.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
        txPrevDate.Text = CDate(DataGridView1.CurrentRow.Cells(5).Value).ToString("yyyy-MM-dd")
        txUnpaid.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString()
        txMeterBalance.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString()
        txMeterSize.Text = DataGridView1.CurrentRow.Cells(11).Value.ToString()
        tarifarates()
        If Val(txprev.Text) > Val(txPres.Text) Then
            txprev.Enabled = True
        Else
            txprev.Enabled = False
        End If
    End Sub

    Private Sub Txprev_TextChanged(sender As Object, e As EventArgs) Handles txprev.TextChanged
        tarifarates()
    End Sub
    Sub submit()
        If Val(txPres.Text) < Val(txprev.Text) Then
            MsgBox("Warning : Negative Reading!", vbInformation, Main.Label1.Text)
        Else
            Try
                If (MsgBox("Are you sure you want to submit this reading?", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_insertReading", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                    cm.Parameters.AddWithValue("Previous_R", txprev.Text)
                    cm.Parameters.AddWithValue("Previous_D", txPrevDate.Text)
                    cm.Parameters.AddWithValue("Current_R", txPres.Text)
                    cm.Parameters.AddWithValue("Current_D", Date.Now.ToString("yyyy-MM-dd"))
                    cm.Parameters.AddWithValue("Consumption", txConsumption.Text)
                    cm.Parameters.AddWithValue("Amount", txAmount.Text)
                    cm.Parameters.AddWithValue("MonthPeriodId", Main.ToolStripLabel4.Text)
                    cm.Parameters.AddWithValue("User", Main.ToolStripLabel3.Text)
                    cm.Parameters.AddWithValue("B1", txUnpaid.Text)
                    cm.Parameters.AddWithValue("B2", txMeterBalance.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    'MsgBox("Reading has been successfully submitted!", vbInformation)
                    loadrecord()
                    txPres.Clear()
                End If


            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If

    End Sub
    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
        End Select
    End Sub

    Private Sub TxPres_KeyDown(sender As Object, e As KeyEventArgs) Handles txPres.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                submit()
        End Select
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column9" Then
            Try
                If (MsgBox("Are you sure you want to hide this record", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_updateReadingHide", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", DataGridView1.CurrentRow.Cells(1).Value.ToString())
                    cm.Parameters.AddWithValue("p2", "1")
                    cm.ExecuteNonQuery()
                    cn.Close()
                    loadrecord()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        With ReadingRecordPrint
            .cmbbarangay()
            .ShowDialog()
        End With
    End Sub
End Class