Imports MySql.Data.MySqlClient
Public Class DashboardII
    Public Sub TotalExpenses()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardIISumExpenses", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", SpecialMain.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("Amount").ToString
            End While
            dr.Close()
            cn.Close()
            lbl01.Text = countl4.ToString("₱ #,##0.00")
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
            'MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub

    Public Sub TotalCollectionYearEx()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardIITotalCollectionYearEx", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", SpecialMain.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("Amount").ToString
            End While
            dr.Close()
            cn.Close()
            lbl02.Text = countl4.ToString("₱ #,##0.00")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub DailyCollection()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardDailyCollection", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("sumAmount").ToString
            End While
            dr.Close()
            cn.Close()
            lbl03.Text = countl4.ToString("₱ #,##0.00")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub Installment()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardIIInstallmentCollectable", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("Installment").ToString
            End While
            dr.Close()
            cn.Close()
            lbl04.Text = countl4.ToString("₱ #,##0.00")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub loadchart()
        Chart1.Series(0).Points.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_dashboardChartTreasuryOffice", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", SpecialMain.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read

                Chart1.Series("IncomeGenerated").Points.AddXY(dr.GetString("Type"), dr.GetUInt32("Amount"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class