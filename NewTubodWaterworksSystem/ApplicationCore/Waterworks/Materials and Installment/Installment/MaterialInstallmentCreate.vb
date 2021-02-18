Imports MySql.Data.MySqlClient
Public Class MaterialInstallmentCreate
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub
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

    Private Sub MaterialInstallmentCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Bounds = Screen.GetWorkingArea(Me)
    End Sub

    Public Sub calculate()
        Dim amount As Double

        If txQty.Text = Nothing Or txPrice.Text = Nothing Then
            amount = 0
            txAmount.Text = amount.ToString("##0.00")
        Else
            amount = Val(txQty.Text) * Val(txPrice.Text)
            txAmount.Text = amount.ToString("##0.00")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txDescription.Text = String.Empty Or txAccount.Text = String.Empty Or txQty.Text = String.Empty Then
            MsgBox("Warning : Missing field required!", vbInformation)
        Else
            Try
                If (MsgBox("Are you sure you want to submit this record", vbYesNo + vbQuestion) = vbYes) Then
                    cn.Open()
                    cm = New MySqlCommand("sp_insertInstallment", cn)
                    cm.CommandType = CommandType.StoredProcedure
                    cm.Parameters.AddWithValue("p1", txAccount.Text)
                    cm.Parameters.AddWithValue("p2", txDescription.Text)
                    cm.Parameters.AddWithValue("p3", txQty.Text)
                    cm.Parameters.AddWithValue("p4", txAmount.Text)
                    cm.Parameters.AddWithValue("p5", DateTimePicker1.Value.ToString("yyyy-MM-dd"))
                    cm.Parameters.AddWithValue("p6", Main.ToolStripLabel3.Text)
                    cm.Parameters.AddWithValue("p7", "Added into Installment")
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Record has been successfully submitted.", vbInformation)
                    txDescription.Clear()
                    txName.Clear()
                    txAccount.Clear()
                    txPrice.Clear()
                    txQty.Clear()
                    DateTimePicker1.Value = Date.Now
                    calculate()
                    With MaterialInstallment
                        .loadrecord()
                    End With
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
            End Try
        End If

    End Sub

    Private Sub txQty_TextChanged(sender As Object, e As EventArgs) Handles txQty.TextChanged
        calculate()
    End Sub
    Public Sub autoConsumer()
        Try
            cn.Open()
            Dim query As String

            query = "Select AccountNo,CONCAT(Lastname,', ',Firstname,' ',Middlename) as Name FROM a_customer"
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
    Public Sub autoMaterials()
        Try
            cn.Open()
            Dim query As String

            query = "SELECT Description FROM `s_materials`"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            Dim autoco As New AutoCompleteStringCollection()

            While dr.Read
                autoco.Add(dr("Description"))
            End While
            dr.Close()
            txDescription.AutoCompleteMode = AutoCompleteMode.Suggest
            txDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
            txDescription.AutoCompleteCustomSource = autoco
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
            query = "Select AccountNo,CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')) From a_customer where CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            While dr.Read
                txAccount.Text = dr.Item(0)
                txAccountMirror.Text = dr.Item(1)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Private Sub txDescription_TextChanged(sender As Object, e As EventArgs) Handles txDescription.TextChanged
        Try
            cn.Open()
            Dim query As String
            query = "SELECT Price FROM s_materials WHERE Description like '" & txDescription.Text & "'"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            While dr.Read
                txPrice.Text = dr.Item(0)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Private Sub txQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txQty.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub
End Class