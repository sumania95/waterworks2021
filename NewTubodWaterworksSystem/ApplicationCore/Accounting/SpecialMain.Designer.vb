<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpecialMain))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SIGNOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HISTORYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SCANOFFICIALRECIEPTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COLLECTIONLOGSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSUMERLOGSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ACCOUNTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MESSAGESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CANCELEDPAYMENTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(41, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Label1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SIGNOUTToolStripMenuItem, Me.HISTORYToolStripMenuItem, Me.SCANOFFICIALRECIEPTToolStripMenuItem, Me.ACCOUNTToolStripMenuItem, Me.MESSAGESToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 45)
        Me.MenuStrip1.TabIndex = 96
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SIGNOUTToolStripMenuItem
        '
        Me.SIGNOUTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SIGNOUTToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow
        Me.SIGNOUTToolStripMenuItem.Image = CType(resources.GetObject("SIGNOUTToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SIGNOUTToolStripMenuItem.Name = "SIGNOUTToolStripMenuItem"
        Me.SIGNOUTToolStripMenuItem.Size = New System.Drawing.Size(103, 41)
        Me.SIGNOUTToolStripMenuItem.Text = " SIGN OUT"
        '
        'HISTORYToolStripMenuItem
        '
        Me.HISTORYToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HISTORYToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HISTORYToolStripMenuItem.Image = CType(resources.GetObject("HISTORYToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HISTORYToolStripMenuItem.Name = "HISTORYToolStripMenuItem"
        Me.HISTORYToolStripMenuItem.Size = New System.Drawing.Size(97, 41)
        Me.HISTORYToolStripMenuItem.Text = "SETTINGS"
        '
        'SCANOFFICIALRECIEPTToolStripMenuItem
        '
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COLLECTIONLOGSToolStripMenuItem, Me.CONSUMERLOGSToolStripMenuItem, Me.CANCELEDPAYMENTToolStripMenuItem})
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.Image = CType(resources.GetObject("SCANOFFICIALRECIEPTToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.Name = "SCANOFFICIALRECIEPTToolStripMenuItem"
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.Size = New System.Drawing.Size(121, 41)
        Me.SCANOFFICIALRECIEPTToolStripMenuItem.Text = "MONITORING"
        '
        'COLLECTIONLOGSToolStripMenuItem
        '
        Me.COLLECTIONLOGSToolStripMenuItem.Name = "COLLECTIONLOGSToolStripMenuItem"
        Me.COLLECTIONLOGSToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.COLLECTIONLOGSToolStripMenuItem.Text = "COLLECTION LOGS"
        '
        'CONSUMERLOGSToolStripMenuItem
        '
        Me.CONSUMERLOGSToolStripMenuItem.Name = "CONSUMERLOGSToolStripMenuItem"
        Me.CONSUMERLOGSToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CONSUMERLOGSToolStripMenuItem.Text = "CONSUMER LOGS"
        '
        'ACCOUNTToolStripMenuItem
        '
        Me.ACCOUNTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ACCOUNTToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ACCOUNTToolStripMenuItem.Image = CType(resources.GetObject("ACCOUNTToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ACCOUNTToolStripMenuItem.Name = "ACCOUNTToolStripMenuItem"
        Me.ACCOUNTToolStripMenuItem.Size = New System.Drawing.Size(100, 41)
        Me.ACCOUNTToolStripMenuItem.Text = "EXPENSES"
        '
        'MESSAGESToolStripMenuItem
        '
        Me.MESSAGESToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MESSAGESToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.MESSAGESToolStripMenuItem.Image = CType(resources.GetObject("MESSAGESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MESSAGESToolStripMenuItem.Name = "MESSAGESToolStripMenuItem"
        Me.MESSAGESToolStripMenuItem.Size = New System.Drawing.Size(115, 41)
        Me.MESSAGESToolStripMenuItem.Text = "DASHBOARD"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripSeparator1, Me.ToolStripLabel3, Me.ToolStripSeparator2, Me.ToolStripLabel5, Me.ToolStripLabel4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 675)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1200, 25)
        Me.ToolStrip1.TabIndex = 97
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel1.Text = "User :"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripLabel2.Text = "ToolStripLabel2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripLabel3.Text = "Local Ip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripLabel5.Text = "Calendar Year :"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(31, 22)
        Me.ToolStripLabel4.Text = "2019"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 630)
        Me.Panel1.TabIndex = 98
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 95
        Me.PictureBox1.TabStop = False
        '
        'CANCELEDPAYMENTToolStripMenuItem
        '
        Me.CANCELEDPAYMENTToolStripMenuItem.Name = "CANCELEDPAYMENTToolStripMenuItem"
        Me.CANCELEDPAYMENTToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.CANCELEDPAYMENTToolStripMenuItem.Text = "CANCELED PAYMENT"
        '
        'SpecialMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SpecialMain"
        Me.Text = "Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SIGNOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HISTORYToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SCANOFFICIALRECIEPTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COLLECTIONLOGSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CONSUMERLOGSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ACCOUNTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MESSAGESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CANCELEDPAYMENTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
