Imports MySql.Data.MySqlClient
Public Class Dashboard
    Public Sub Allcustomer()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardCustomerCounter", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("IDCount").ToString
            End While
            dr.Close()
            cn.Close()
            lbl01.Text = countl4.ToString("#,##0")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub

    Public Sub ReadyForInstallation()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardReadyforInstallation", cn)
            cm.CommandType = CommandType.StoredProcedure
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("IDCount1").ToString
            End While
            dr.Close()
            cn.Close()
            lbl02.Text = countl4.ToString("#,##0")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub DailyCollection()
        Try
            cn.Open()
            Dim countl4 As Single
            cm = New MySqlCommand("sp_dashboardyearlyconsumption", cn)
            'cm = New MySqlCommand("sp_dashboardDailyCollection", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("Consumption").ToString
                'countl4 = dr.Item("sumAmount").ToString
            End While
            dr.Close()
            cn.Close()
            lbl03.Text = countl4.ToString("#,##0 m³")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub Consumption()
        Try
            cn.Open()
            Dim countl4 As Single
            Dim countl5 As Single
            cm = New MySqlCommand("sp_dashboardConsumption", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel4.Text)
            dr = cm.ExecuteReader
            While dr.Read
                countl4 = dr.Item("Consumption").ToString
                countl5 = dr.Item("Counter").ToString
            End While
            dr.Close()
            cn.Close()
            lbl04.Text = countl4.ToString("#,##0 m³")
        Catch ex As Exception
            cn.Close()
            MsgBox("Server connection lost." & vbNewLine & "Please check your lan and wireless connection.", vbExclamation, Main.Label1.Text)
        End Try
    End Sub
    Public Sub loadchart()
        Chart1.Series(0).Points.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_dashboardConsumerCounter", cn)
            'cm = New MySqlCommand("sp_dashboardChartTreasuryOffice", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            'cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                Chart1.Series("IncomeGenerated").Points.AddXY(dr.GetString("Classification"), dr.GetUInt32("Counter"))
                'Chart1.Series("IncomeGenerated").Points.AddXY(dr.GetString("Type"), dr.GetUInt32("Amount"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub loadchart02()
        Chart2.Series(0).Points.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_dashboardpresentConsumptionByBarangay", cn)
            'cm = New MySqlCommand("sp_dashboardConsumerCounter", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel4.Text)
            'cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read
                Chart2.Series("ConsumerCount").Points.AddXY(dr.GetString("Barangay"), dr.GetUInt32("Consumption"))
                'Chart2.Series("ConsumerCount").Points.AddXY(dr.GetString("Classification"), dr.GetUInt32("Counter"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub loadchart03()
        Chart3.Series(0).Points.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_dashboardStatusCounter", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read

                Chart3.Series("StatusCounter").Points.AddXY(dr.GetString("Status"), dr.GetUInt32("NoStat"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub loadchart04()
        Chart4.Series(0).Points.Clear()
        Try
            cn.Open()
            cm = New MySqlCommand("sp_dashboardClassificationCounterFinal", cn)
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("p1", Main.ToolStripLabel5.Text)
            dr = cm.ExecuteReader
            While dr.Read

                Chart4.Series("ClassificationCount").Points.AddXY(dr.GetString("Classification"), dr.GetUInt32("NoClass"))
            End While
            dr.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class