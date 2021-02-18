Imports MySql.Data.MySqlClient
Public Class Login
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
    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        draggable = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim found As Boolean = False
            Dim strname As String = ""
            Dim strType As String = ""
            cn.Open()
            cm = New MySqlCommand("SELECT * FROM u_login", cn)
            dr = cm.ExecuteReader
            While dr.Read
                If txUser.Text = dr.Item("User").ToString And txPass.Text = dr.Item("Pass").ToString Then
                    found = True
                    strname = dr.Item("Name").ToString
                    strType = dr.Item("Type").ToString

                End If
            End While
            dr.Close()
            cn.Close()
            If found = True Then
                MsgBox("Access Granted. Welcome : " & strname, vbInformation, Label1.Text)
                If strType = "Administrator" Then
                    With Main
                        Me.Hide()
                        .ToolStripLabel3.Text = strname
                        .ApplicationName()
                        .ReadingPeriod001()
                        .ShowDialog()
                    End With
                ElseIf strType = "Admin" Then
                    With Main
                        Me.Hide()
                        .ADJUSTMENTRECORDToolStripMenuItem.Visible = False
                        .USERACCOUNTLISTToolStripMenuItem.Visible = False
                        .READINGPERIODToolStripMenuItem.Visible = False
                        .CALENDARYEARToolStripMenuItem.Visible = False
                        .BARANGAYToolStripMenuItem.Visible = False
                        .MATERIALSToolStripMenuItem.Visible = False
                        .ACTIVITYLOGSToolStripMenuItem.Visible = False
                        .COLLECTIONLOGSToolStripMenuItem.Visible = False
                        .MESSAGESSECTIONToolStripMenuItem.Visible = False
                        .CATEGORYToolStripMenuItem.Visible = False
                        .ToolStripLabel3.Text = strname
                        .ApplicationName()
                        .ReadingPeriod001()
                        .ShowDialog()
                    End With
                ElseIf strType = "Staff" Then
                    'With Collector
                    With CollectionMain
                        Me.Hide()
                        '' ''.ToolStripLabel2.Text = strname
                        .ToolStripLabel2.Text = strname
                        .ApplicationName()
                        .loadrecord()
                        .loadrecord2()
                        .cmbStatus.SelectedIndex = -1
                        .cmbStatus.Text = "Select Category"
                        .ComboBox1.SelectedIndex = 0
                        .ShowDialog()
                    End With
                ElseIf strType = "Special" Then
                    With SpecialMain
                        Me.Hide()
                        .ToolStripLabel2.Text = strname
                        .ApplicationName()
                        .ShowDialog()
                    End With
                End If

            Else
                MsgBox("Access Denied. Invalid username or password.", vbExclamation, Label1.Text)
            End If
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Label1.Text)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
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

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection()
        Timer1.Enabled = True
    End Sub

    Private Sub txUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txUser.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button1.PerformClick()
        End Select
    End Sub

    Private Sub txPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txPass.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Button1.PerformClick()
        End Select
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripLabel3.Text = "Local Ip : " + GetIPv4Address()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txPass.PasswordChar = ""
        Else
            txPass.PasswordChar = "*"
        End If
    End Sub
End Class