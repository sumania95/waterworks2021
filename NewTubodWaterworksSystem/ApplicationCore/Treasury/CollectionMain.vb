Imports MySql.Data.MySqlClient
Public Class CollectionMain
    Private Sub CollectionMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Bounds = Screen.GetWorkingArea(Me)
        Timer1.Enabled = True
    End Sub
    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function
    Public Sub loadrecord2()
        Try
            Dim i As Integer = 0
            Dim j As Integer = 0
            DataGridView2.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("SELECT * FROM s_readingpreiod ORDER BY Id DESC", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                j += 50
                DataGridView2.Rows.Add(i, dr.Item("ReadingPeriod").ToString, j)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
        End Try
        
    End Sub
    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_applicationSettings", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Label1.Text = dr.Item(1)
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
        End Try
    End Sub
    Public Sub loadrecord()
        If cmbStatus.SelectedIndex = -1 Then
            hideGridV()
            DataGridView1.Rows.Clear()
        ElseIf cmbStatus.SelectedIndex = 0 Then
            Try
                hideGridV()
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomer_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                cm.Parameters.AddWithValue("l1", ComboBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    Dim bal As Double
                    bal = dr.Item("BillingBalance").ToString
                    Dim ddate As Date
                    ddate = dr.Item("DateApplied").ToString
                    DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, dr.Item("Classification").ToString, dr.Item("Barangay").ToString, bal.ToString("₱ #,##0.00"), dr.Item("ReadingPeriod").ToString, "Billing")
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
                
            End Try
            
        ElseIf cmbStatus.SelectedIndex = 1 Then
            Try
                hideGridV()
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomer_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                cm.Parameters.AddWithValue("l1", ComboBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    Dim bal As Double
                    bal = dr.Item("MeterBalance").ToString
                    DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, dr.Item("Classification").ToString, dr.Item("Barangay").ToString, bal.ToString("₱ #,##0.00"), dr.Item("ReadingPeriod").ToString, "Meter")
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
                
            End Try
            
        ElseIf cmbStatus.SelectedIndex = 2 Then
            Try
                hideGridV()
                Dim i As Integer = 0
                DataGridView1.Rows.Clear()
                cn.Open()
                cm = New MySqlCommand("sp_selectCustomerInstallment_search", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", MetroTextBox1.Text)
                cm.Parameters.AddWithValue("l1", ComboBox1.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    Dim bal As Double
                    bal = dr.Item("Installement").ToString
                    DataGridView1.Rows.Add(i, dr.Item("AccountNo").ToString, dr.Item("Lastname").ToString + ", " + dr.Item("Firstname").ToString + " " + dr.Item("Middlename").ToString, dr.Item("MeterNo").ToString, dr.Item("Classification").ToString, dr.Item("Barangay").ToString, bal.ToString("₱ #,##0.00"), dr.Item("ReadingPeriod").ToString, "Installment")
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical, Label1.Text)

            End Try

        End If
    End Sub
    Private Sub SIGNOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SIGNOUTToolStripMenuItem.Click
        Try
            If (MsgBox("Are you sure you want to logout?", vbYesNo + vbQuestion, Label1.Text) = vbYes) Then
                Me.Dispose()
                With Login
                    .txPass.Clear()
                    .Show()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        MetroTextBox1.Select()
        ComboBox1.SelectedIndex = 0
        loadrecord()
    End Sub

    Private Sub MESSAGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MESSAGESToolStripMenuItem.Click
        With CollectionMessages
            .loadrecord()
            .loadrecordII()
            .MetroTabControl1.SelectedIndex = 0
            .ShowDialog()
        End With
    End Sub

    Private Sub ACCOUNTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACCOUNTToolStripMenuItem.Click
        With ConsumerLogs
            .txName.Clear()
            .txMeter.Clear()
            .txAccount.Clear()
            .txAccountMirror.Clear()
            .autoConsumer()
            .DataGridView1.Rows.Clear()
            .ShowDialog()
        End With
    End Sub

    Private Sub MetroTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MetroTextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                loadrecord()
                ComboBox1.SelectedIndex = 0
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MetroTextBox1.Select()
        loadrecord()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column14" Then
            txAccount.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            autofill()
            txAmount.Select()
            If txAccount.Text = String.Empty Then
                cmbStatus.Enabled = True
            Else
                cmbStatus.Enabled = False
            End If


        End If
    End Sub
    Public Sub autofill()
        If cmbStatus.SelectedIndex = 0 Then
            Try
                cn.Open()
                cm = New MySqlCommand("sp_autofillCustomerUpdate", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txAccount.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    txName.Text = dr.Item(3).ToString + ", " + dr.Item(1).ToString + " " + dr.Item(2).ToString
                    txbarangay.Text = dr.Item(6).ToString
                    txClassification.Text = dr.Item(5).ToString
                    txMeterNo.Text = dr.Item(10).ToString
                    Dim bal As Double
                    bal = dr.Item(19).ToString
                    txBalance.Text = bal.ToString("##0.00")
                    Dim ddate As Date
                    ddate = dr.Item(9).ToString
                    Select Case Len(Trim(dr.Item(0).ToString))
                        Case 1 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0000" + Trim(Str(dr.Item(0).ToString))
                        Case 2 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "000" + Trim(Str(dr.Item(0).ToString))
                        Case 3 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "00" + Trim(Str(dr.Item(0).ToString))
                        Case 4 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0" + Trim(Str(dr.Item(0).ToString))

                    End Select
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                txAccount.Clear()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)

            End Try
        ElseIf cmbStatus.SelectedIndex = 1 Then
            Try
                cn.Open()
                cm = New MySqlCommand("sp_autofillCustomerUpdate", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txAccount.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    Dim bal As Double
                    txName.Text = dr.Item(3).ToString + ", " + dr.Item(1).ToString + " " + dr.Item(2).ToString
                    txbarangay.Text = dr.Item(6).ToString
                    txClassification.Text = dr.Item(5).ToString
                    txMeterNo.Text = dr.Item(10).ToString
                    bal = dr.Item(20).ToString
                    txBalance.Text = bal.ToString("##0.00")
                    Dim ddate As Date
                    ddate = dr.Item(9).ToString
                    Select Case Len(Trim(dr.Item(0).ToString))
                        Case 1 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0000" + Trim(Str(dr.Item(0).ToString))
                        Case 2 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "000" + Trim(Str(dr.Item(0).ToString))
                        Case 3 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "00" + Trim(Str(dr.Item(0).ToString))
                        Case 4 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0" + Trim(Str(dr.Item(0).ToString))

                    End Select
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                txAccount.Clear()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
            End Try
        ElseIf cmbStatus.SelectedIndex = 2 Then
            Try
                cn.Open()
                cm = New MySqlCommand("sp_autofillCustomerUpdate", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txAccount.Text)
                dr = cm.ExecuteReader
                While dr.Read
                    Dim bal As Double
                    txName.Text = dr.Item(3).ToString + ", " + dr.Item(1).ToString + " " + dr.Item(2).ToString
                    txbarangay.Text = dr.Item(6).ToString
                    txClassification.Text = dr.Item(5).ToString
                    txMeterNo.Text = dr.Item(10).ToString
                    bal = dr.Item(30).ToString
                    txBalance.Text = bal.ToString("##0.00")
                    Dim ddate As Date
                    ddate = dr.Item(9).ToString
                    Select Case Len(Trim(dr.Item(0).ToString))
                        Case 1 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0000" + Trim(Str(dr.Item(0).ToString))
                        Case 2 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "000" + Trim(Str(dr.Item(0).ToString))
                        Case 3 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "00" + Trim(Str(dr.Item(0).ToString))
                        Case 4 : txAccountMirror.Text = ddate.ToString("yyyy") + "-" + "0" + Trim(Str(dr.Item(0).ToString))

                    End Select
                End While
                dr.Close()
                cn.Close()
            Catch ex As Exception
                cn.Close()
                txAccount.Clear()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
            End Try
        End If

    End Sub
    Public Sub hideGridV()
        If cmbStatus.SelectedIndex = -1 Then
            DataGridView1.Columns("Column6").Visible = False
        ElseIf cmbStatus.SelectedIndex = 0 Then
            DataGridView1.Columns("Column6").Visible = True
        ElseIf cmbStatus.SelectedIndex = 1 Then
            DataGridView1.Columns("Column6").Visible = False
        ElseIf cmbStatus.SelectedIndex = 2 Then
            DataGridView1.Columns("Column6").Visible = False
        End If

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txAccount.Clear()
        txName.Clear()
        txAmount.Clear()
        txBalance.Clear()
        txbarangay.Clear()
        txClassification.Clear()
        txMeterNo.Clear()
        txOrNo.Clear()
        txAccountMirror.Clear()
        cmbStatus.Enabled = True
        MetroTextBox1.Select()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txAmount.Select()
    End Sub

    Private Sub TxOrNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txOrNo.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub TxAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub BtnSaveUpdate_Click(sender As Object, e As EventArgs) Handles btnSaveUpdate.Click
        If txAmount.Text = String.Empty Or txOrNo.Text = String.Empty Or txAmount.Text = 0 Then
            MsgBox("Warning: Empty field required!", vbInformation, Label1.Text)
        Else
            
            If Val(txBalance.Text) < Val(txAmount.Text) Then
                MsgBox("Warning: Sufficient Amount.", vbInformation, Label1.Text)
            Else
                If cmbStatus.SelectedIndex = 0 Then
                    Try
                        cn.Open()
                        Dim i As Integer
                        i = 0
                        cm = New MySqlCommand("sp_validateOfficialReciept", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txOrNo.Text)
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
                                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                                    cm.Parameters.AddWithValue("p2", cmbStatus.Text)
                                    cm.Parameters.AddWithValue("p3", txOrNo.Text)
                                    cm.Parameters.AddWithValue("p4", txAmount.Text)
                                    cm.Parameters.AddWithValue("p5", ToolStripLabel2.Text)
                                    cm.ExecuteNonQuery()
                                    cn.Close()
                                    MsgBox("Transaction has been successfully saved.", vbInformation, Label1.Text)
                                    loadrecord()
                                    autofill()
                                    txAmount.Clear()
                                    txOrNo.Clear()
                                    txOrNo.Select()
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

                ElseIf cmbStatus.SelectedIndex = 1 Then
                    Try
                        cn.Open()
                        Dim i As Integer
                        i = 0
                        cm = New MySqlCommand("sp_validateOfficialReciept", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txOrNo.Text)
                        Dim dt As New DataTable
                        Dim da As New MySqlDataAdapter(cm)
                        da.Fill(dt)
                        i = Convert.ToInt32(dt.Rows.Count.ToString())
                        If i = 0 Then
                            cn.Close()
                            Try
                                If (MsgBox("Are you sure you want to proceed this transaction?", vbYesNo + vbQuestion, Label1.Text) = vbYes) Then
                                    cn.Open()
                                    cm = New MySqlCommand("sp_POSmeterBalance", cn)
                                    cm.CommandType = CommandType.StoredProcedure
                                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                                    cm.Parameters.AddWithValue("p2", cmbStatus.Text)
                                    cm.Parameters.AddWithValue("p3", txOrNo.Text)
                                    cm.Parameters.AddWithValue("p4", txAmount.Text)
                                    cm.Parameters.AddWithValue("p5", ToolStripLabel2.Text)
                                    cm.ExecuteNonQuery()
                                    cn.Close()
                                    MsgBox("Transaction has been successfully saved.", vbInformation, Label1.Text)
                                    loadrecord()
                                    autofill()
                                    txAmount.Clear()
                                    txOrNo.Clear()
                                    txOrNo.Select()
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
                ElseIf cmbStatus.SelectedIndex = 2 Then
                    Try
                        cn.Open()
                        Dim i As Integer
                        i = 0
                        cm = New MySqlCommand("sp_validateOfficialReciept", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txOrNo.Text)
                        Dim dt As New DataTable
                        Dim da As New MySqlDataAdapter(cm)
                        da.Fill(dt)
                        i = Convert.ToInt32(dt.Rows.Count.ToString())
                        If i = 0 Then
                            cn.Close()
                            Try
                                If (MsgBox("Are you sure you want to proceed this transaction?", vbYesNo + vbQuestion, Label1.Text) = vbYes) Then
                                    cn.Open()
                                    cm = New MySqlCommand("sp_POSInstallmentBalance", cn)
                                    cm.CommandType = CommandType.StoredProcedure
                                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                                    cm.Parameters.AddWithValue("p2", cmbStatus.Text)
                                    cm.Parameters.AddWithValue("p3", txOrNo.Text)
                                    cm.Parameters.AddWithValue("p4", txAmount.Text)
                                    cm.Parameters.AddWithValue("p5", ToolStripLabel2.Text)
                                    cm.ExecuteNonQuery()
                                    cn.Close()
                                    MsgBox("Transaction has been successfully saved.", vbInformation, Label1.Text)
                                    loadrecord()
                                    autofill()
                                    txAmount.Clear()
                                    txOrNo.Clear()
                                    txOrNo.Select()
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

            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ToolStripLabel3.Text = "IP Address : " + GetIPv4Address()
    End Sub

    Private Sub HISTORYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HISTORYToolStripMenuItem.Click
        With POSCollectionLogs
            .Label4.ResetText()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .DataGridView1.Rows.Clear()
            .ShowDialog()
        End With
    End Sub

    Private Sub SCANOFFICIALRECIEPTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SCANOFFICIALRECIEPTToolStripMenuItem.Click
        With CollectionORScanning
            .MetroTextBox1.Select()
            .ShowDialog()
        End With
    End Sub
End Class