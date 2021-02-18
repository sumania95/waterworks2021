Imports MySql.Data.MySqlClient
Public Class CollectionLogsCreate
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
    Public Sub autofill()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_autofillCancelPayment", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", lblId.Text)
            dr = cm.ExecuteReader
            While dr.Read
                txAccount.Text = dr.Item(1).ToString
                txOR.Text = dr.Item(3).ToString
                txAmount.Text = dr.Item(4).ToString
                txType.Text = dr.Item(2).ToString
                txReason.Clear()
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, CollectionMain.Label1.Text)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txReason.Text = String.Empty Then
            MsgBox("Warning : Missing field required", vbExclamation, CollectionMain.Label1.Text)
        Else
            If txType.Text = "Service Connection" Then
                Try
                    If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion, CollectionMain.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_CancelPaymentServiceConnection", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccount.Text)
                        cm.Parameters.AddWithValue("p2", txReason.Text)
                        cm.Parameters.AddWithValue("p3", txOR.Text)
                        cm.Parameters.AddWithValue("p4", txAmount.Text)
                        cm.Parameters.AddWithValue("p5", CollectionMain.ToolStripLabel2.Text)
                        cm.Parameters.AddWithValue("p6", txType.Text)
                        cm.Parameters.AddWithValue("p7", lblId.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully updated.", vbInformation, CollectionMain.Label1.Text)
                        With POSCollectionLogs
                            .loadrecord()
                        End With
                        With CollectionMain
                            .loadrecord()
                        End With
                        Me.Hide()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox(ex.Message, vbCritical)
                    'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, CollectionMain.Label1.Text)
                End Try
            ElseIf txType.Text = "Water Meter Balance" Then
                Try
                    If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion, CollectionMain.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_CancelPaymentMeterBalance", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccount.Text)
                        cm.Parameters.AddWithValue("p2", txReason.Text)
                        cm.Parameters.AddWithValue("p3", txOR.Text)
                        cm.Parameters.AddWithValue("p4", txAmount.Text)
                        cm.Parameters.AddWithValue("p5", CollectionMain.ToolStripLabel2.Text)
                        cm.Parameters.AddWithValue("p6", txType.Text)
                        cm.Parameters.AddWithValue("p7", lblId.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully updated.", vbInformation, CollectionMain.Label1.Text)
                        With POSCollectionLogs
                            .loadrecord()
                        End With
                        With CollectionMain
                            .loadrecord()
                        End With
                        Me.Hide()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox(ex.Message, vbCritical)
                End Try
            ElseIf txType.Text = "Material Installment" Then
                Try
                    If (MsgBox("Are you sure you want to update this record", vbYesNo + vbQuestion, CollectionMain.Label1.Text) = vbYes) Then
                        cn.Open()
                        cm = New MySqlCommand("sp_CancelPaymentInstallment", cn)
                        cm.CommandType = CommandType.StoredProcedure
                        cm.Parameters.AddWithValue("p1", txAccount.Text)
                        cm.Parameters.AddWithValue("p2", txReason.Text)
                        cm.Parameters.AddWithValue("p3", txOR.Text)
                        cm.Parameters.AddWithValue("p4", txAmount.Text)
                        cm.Parameters.AddWithValue("p5", CollectionMain.ToolStripLabel2.Text)
                        cm.Parameters.AddWithValue("p6", txType.Text)
                        cm.Parameters.AddWithValue("p7", lblId.Text)
                        cm.ExecuteNonQuery()
                        cn.Close()
                        MsgBox("Record has been successfully updated.", vbInformation, CollectionMain.Label1.Text)
                        With POSCollectionLogs
                            .loadrecord()
                        End With
                        With CollectionMain
                            .loadrecord()
                        End With
                        Me.Hide()
                    End If

                Catch ex As Exception
                    cn.Close()
                    MsgBox(ex.Message, vbCritical)
                End Try
            End If
        End If
        
    End Sub
End Class