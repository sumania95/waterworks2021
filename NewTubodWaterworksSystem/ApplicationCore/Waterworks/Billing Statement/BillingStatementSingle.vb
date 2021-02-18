Imports MySql.Data.MySqlClient
Public Class BillingStatementSingle
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
            'Dim query As String

            'query = "Select AccountNo,CONCAT(Lastname,', ',Firstname,' ',Middlename) as Name FROM a_customer"
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
    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_applicationSettings", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                txReminders.Text = dr.Item(4)
            End While

            dr.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub ReadingPeriod01()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectPrintSingle", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txAccountNo.Text)
            dr = cm.ExecuteReader
            While dr.Read
                Dim readingp1 = dr.GetString("ReadingPeriod")
                ComboBox1.Items.Add(readingp1)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Private Sub txName_TextChanged(sender As Object, e As EventArgs) Handles txName.TextChanged
        Try
            cn.Open()
            'Dim query As String
            'query = "Select `AccountNo`, CONCAT(YEAR(`DateApplied`),'-',LPAD(`AccountNo`, 5, '0')),IFNULL(ClassType,'') From a_customer LEFT JOIN s_Barangay ON a_customer.Barangay = s_Barangay.Barangay where CONCAT(Lastname,', ',Firstname,' ',Middlename) like '" & txName.Text & "'"
            cm = New MySqlCommand("sp_autofillConsumers", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", txName.Text)
            dr = cm.ExecuteReader
            While dr.Read
                txAccountNo.Text = dr.Item(0)
                txAccountMirror.Text = dr.Item(2)
                txClasstype.Text = dr.Item(3)
            End While
            dr.Close()
            cn.Close()
            ReadingPeriod01()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txAccountNo.Text = String.Empty Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Warning : Missing field required!", vbInformation, Main.Label1.Text)
        Else
            If txClasstype.Text = "A" Or txClasstype.Text = "" Then
                With PrintBillingStatementSingle
                    Me.Hide()
                    .TopLevel = False
                    Main.Panel1.Controls.Add(PrintBillingStatementSingle)
                    .BringToFront()
                    .loadreport()
                    .Show()
                End With
            Else
                With PrintBillingStatementSingle
                    Me.Hide()
                    .TopLevel = False
                    Main.Panel1.Controls.Add(PrintBillingStatementSingle)
                    .BringToFront()
                    .loadreportII()
                    .Show()
                End With
            End If
            
        End If
    End Sub
End Class