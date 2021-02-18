Imports MySql.Data.MySqlClient
Public Class BillingStatementMultiple
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
    Public Sub ApplicationName()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_applicationSettings", cn)
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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub
    Public Sub cmbbarangay()
        ComboBox1.Items.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_selectBarangay", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                Dim barangay = dr.GetString("Barangay")
                ComboBox1.Items.Add(barangay)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = String.Empty Then
            MsgBox("Warning : Missing field required!", vbInformation)
        Else
            If txClasstype.Text = "A" Then
                With PrintBillingStatement
                    Me.Hide()
                    .TopLevel = False
                    Main.Panel1.Controls.Add(PrintBillingStatement)
                    .BringToFront()
                    .loadreport()
                    .Show()
                End With
            Else
                With PrintBillingStatement
                    Me.Hide()
                    .TopLevel = False
                    Main.Panel1.Controls.Add(PrintBillingStatement)
                    .BringToFront()
                    .loadreportII()
                    .Show()
                End With
            End If
            
        End If
    End Sub
    Sub loadbarangay()
        Try
            cn.Open()
            Dim query As String
            query = "Select IFNULL(ClassType,'') From s_barangay WHERE s_barangay.Barangay = '" & ComboBox1.Text & "'"
            cm = New MySqlCommand(query, cn)
            dr = cm.ExecuteReader
            While dr.Read
                txClasstype.Text = dr.Item(0)
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)

        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadbarangay()
    End Sub

End Class