Imports MySql.Data.MySqlClient
Public Class StatusAndReplacementReplace
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txMeterNew.Text = String.Empty Or txInitialReading.Text = String.Empty Or txReason.Text = String.Empty Or cmbMeterSize.Text = String.Empty Then
            MsgBox("Warning : Missing field required!", vbInformation)
        Else
            Try
                cn.Open()
                Dim i As Integer
                i = 0
                cm = New MySqlCommand("sp_validateMeterNo_InstallationMeter", cn)
                cm.CommandType = CommandType.StoredProcedure
                cm.Parameters.AddWithValue("meter", txMeterNew.Text)
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(cm)
                da.Fill(dt)
                i = Convert.ToInt32(dt.Rows.Count.ToString())
                If i = 0 Then
                    cn.Close()
                    Try
                        If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion) = vbYes) Then
                            cn.Open()
                            cm = New MySqlCommand("sp_updateCustomerReplaceMeter", cn)
                            cm.CommandType = CommandType.StoredProcedure
                            cm.Parameters.AddWithValue("p1", txAccount.Text)
                            cm.Parameters.AddWithValue("p2", "Replaced Water Meter No. " + txMeterNew.Text)
                            cm.Parameters.AddWithValue("p3", Main.ToolStripLabel3.Text)
                            cm.Parameters.AddWithValue("MeterNo", txMeterNew.Text)
                            cm.Parameters.AddWithValue("CurrentR", txInitialReading.Text)
                            cm.Parameters.AddWithValue("MeterSize", cmbMeterSize.Text)
                            cm.Parameters.AddWithValue("DateBilled", Date.Now.ToString("yyyy-MM-dd"))
                            cm.Parameters.AddWithValue("Reason", txReason.Text)
                            cm.Parameters.AddWithValue("MeterOld", txMeterOld.Text)
                            cm.ExecuteNonQuery()
                            cn.Close()

                            MsgBox("Record has been successfully updated.", vbInformation)
                            With StatusAndReplacementActive
                                .loadrecord()
                            End With
                            Me.Hide()
                        End If

                    Catch ex As Exception
                        cn.Close()
                        MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
                    End Try

                Else
                    cn.Close()
                    MsgBox("Warning : Duplicate Water Meter No!", vbInformation)
                End If
            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try

        End If

    End Sub
End Class