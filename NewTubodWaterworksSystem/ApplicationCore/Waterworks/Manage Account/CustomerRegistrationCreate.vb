Imports MySql.Data.MySqlClient
Public Class CustomerRegistrationCreate
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
    'Public Sub autoID()
    '    Try
    '        cn.Open()
    '        Dim autono As Single
    '        cm = New MySqlCommand("SELECT COUNT(`Account`) as result FROM `a_customercounter`", cn)
    '        dr = cm.ExecuteReader
    '        While dr.Read
    '            autono = dr.Item("result").ToString + 1
    '        End While
    '        dr.Close()
    '        Select Case Len(Trim(autono))
    '            Case 1 : txAccountNo.Text = Format(Now, "yyyy") + "000000" + Trim(Str(autono))
    '            Case 2 : txAccountNo.Text = Format(Now, "yyyy") + "00000" + Trim(Str(autono))
    '            Case 3 : txAccountNo.Text = Format(Now, "yyyy") + "0000" + Trim(Str(autono))
    '            Case 4 : txAccountNo.Text = Format(Now, "yyyy") + "000" + Trim(Str(autono))
    '            Case 5 : txAccountNo.Text = Format(Now, "yyyy") + "00" + Trim(Str(autono))
    '            Case 6 : txAccountNo.Text = Format(Now, "yyyy") + "0" + Trim(Str(autono))

    '        End Select

    '        cn.Close()

    '    Catch ex As Exception
    '        cn.Close()
    '        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
    '    End Try
    'End Sub
    Public Sub autofill()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_autofillCustomerUpdate", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txAccountNo.Text)
            dr = cm.ExecuteReader
            While dr.Read
                txFirst.Text = dr.Item(1).ToString
                txMiddle.Text = dr.Item(2).ToString
                txLast.Text = dr.Item(3).ToString
                txContact.Text = dr.Item(4).ToString
                txPurok.Text = dr.Item(7).ToString
                cmbBarangay.Text = dr.Item(6).ToString
                cmbClassification.Text = dr.Item(5).ToString
                DateTimePicker1.Text = dr.Item(9)
                txSpouse.Text = dr.Item(14).ToString
                txOccupancy.Text = dr.Item(15).ToString
                txOccupation.Text = dr.Item(16).ToString

            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub
    Public Sub cmbbarangay01()
        cmbBarangay.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectBarangay_CustomerCreate", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim barangay = dr.GetString("Barangay")
                cmbBarangay.Items.Add(barangay)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub cleartext()
        'autoID()
        txContact.Clear()
        txFirst.Clear()
        txLast.Clear()
        txMiddle.Clear()
        txOccupation.Clear()
        txPurok.Clear()
        txSpouse.Clear()
        cmbBarangay.SelectedIndex = -1
        cmbClassification.SelectedIndex = -1
        DateTimePicker1.Value = Date.Now
        txOccupancy.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txLast.Text = String.Empty Or cmbBarangay.SelectedIndex = -1 Or cmbClassification.SelectedIndex = -1 Then
            MsgBox("Warning: Empty field required!", vbInformation)
        Else
            Try
                cn.Open()
                Dim i As Integer
                i = 0
                cm = New MySqlCommand("sp_validateInsertCustomer", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("validate1", txFirst.Text)
                cm.Parameters.AddWithValue("validate2", txLast.Text)
                cm.Parameters.AddWithValue("validate3", txMiddle.Text)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cm)
                da.Fill(dt)
                i = Convert.ToInt32(dt.Rows.Count.ToString())
                If i = 0 Then
                    cn.Close()
                    Try
                        If (MsgBox("Are you sure you want to save this record", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                            cn.Open()
                            cm = New MySqlCommand("sp_insertCustomer", cn)
                            cm.CommandType = CommandType.StoredProcedure
                            cm.Parameters.AddWithValue("Firstname", txFirst.Text)
                            cm.Parameters.AddWithValue("Middlename", txMiddle.Text)
                            cm.Parameters.AddWithValue("Lastname", txLast.Text)
                            cm.Parameters.AddWithValue("Contact", txContact.Text)
                            cm.Parameters.AddWithValue("Purok", txPurok.Text)
                            cm.Parameters.AddWithValue("Barangay", cmbBarangay.Text)
                            cm.Parameters.AddWithValue("Classification", cmbClassification.Text)
                            cm.Parameters.AddWithValue("Dateapplied", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                            cm.Parameters.AddWithValue("NameSpouse", txSpouse.Text)
                            cm.Parameters.AddWithValue("NoOccupancy", txOccupancy.Text)
                            cm.Parameters.AddWithValue("Occupation", txOccupation.Text)
                            cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                            cm.ExecuteNonQuery()
                            cn.Close()
                            MsgBox("Record has been successfully saved.", vbInformation, Main.Label1.Text)
                            With CustomerRegistration
                                .loadrecord()
                            End With
                            With Dashboard
                                .loadchart02()
                                .Allcustomer()
                            End With
                            cleartext()

                            If (MsgBox("Do you want to print the registration form?", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                                With ReportViewer
                                    Me.Hide()
                                    .TopLevel = False
                                    Main.Panel1.Controls.Add(ReportViewer)
                                    .BringToFront()
                                    .loadreport()
                                    .Show()
                                End With
                            End If


                        End If

                    Catch ex As Exception
                        cn.Close()
                        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                    End Try

                Else
                    cn.Close()
                    MsgBox("Warning : Duplicate Account Found!", vbInformation)
                End If
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try

        End If

    End Sub

    Private Sub TxContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txContact.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub TxOccupancy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txOccupancy.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion, Main.Label1.Text) = vbYes) Then
                cn.Open()
                cm = New MySqlCommand("sp_updateCustomer", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("p1", txAccountNo.Text)
                cm.Parameters.AddWithValue("p2", "Changed Information")
                cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                cm.Parameters.AddWithValue("Firstname", txFirst.Text)
                cm.Parameters.AddWithValue("Middlename", txMiddle.Text)
                cm.Parameters.AddWithValue("Lastname", txLast.Text)
                cm.Parameters.AddWithValue("Contact", txContact.Text)
                cm.Parameters.AddWithValue("Purok", txPurok.Text)
                cm.Parameters.AddWithValue("Barangay", cmbBarangay.Text)
                cm.Parameters.AddWithValue("Classification", cmbClassification.Text)
                cm.Parameters.AddWithValue("Dateapplied", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                cm.Parameters.AddWithValue("NameSpouse", txSpouse.Text)
                cm.Parameters.AddWithValue("NoOccupancy", txOccupancy.Text)
                cm.Parameters.AddWithValue("Occupation", txOccupation.Text)
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Record has been successfully updated.", vbInformation, Main.Label1.Text)
                With CustomerRegistration
                    .loadrecord()
                End With
                With Dashboard
                    .loadchart02()
                End With
                Me.Hide()
            End If

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
End Class