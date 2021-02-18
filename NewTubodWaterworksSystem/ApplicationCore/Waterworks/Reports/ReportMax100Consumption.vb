Public Class ReportMax100Consumption

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        With Dashboard
            .TopLevel = False
            Main.Panel1.Controls.Add(Dashboard)
            .BringToFront()
            .DailyCollection()
            .Show()
        End With
    End Sub
End Class