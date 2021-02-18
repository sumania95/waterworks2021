Imports MySql.Data.MySqlClient
Public Class Collector

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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

    Private Sub Collector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripLabel3.Text = "IP Address : " + GetIPv4Address()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With POSCollectionLogs
            .Label4.ResetText()
            .DateTimePicker1.Value = Date.Now
            .DateTimePicker2.Value = Date.Now
            .DataGridView1.Rows.Clear()
            .ShowDialog()
        End With
    End Sub
End Class