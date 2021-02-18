Imports MySql.Data.MySqlClient

Public Class Disconnection_CreateView
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With ReportViewer_DCList
            .loadreport()
            .ShowDialog()
        End With
    End Sub
End Class