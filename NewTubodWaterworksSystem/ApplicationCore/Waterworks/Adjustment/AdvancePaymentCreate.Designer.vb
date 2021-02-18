<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancePaymentCreate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancePaymentCreate))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txAccountNo = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txOR = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txAmount = New System.Windows.Forms.TextBox()
        Me.txName = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txBalance = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txAccountMirror = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 32)
        Me.Panel1.TabIndex = 96
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 21)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "ADVANCE PAYMENT (for service connection)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(441, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 77
        Me.PictureBox1.TabStop = False
        '
        'txAccountNo
        '
        Me.txAccountNo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txAccountNo.Enabled = False
        Me.txAccountNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txAccountNo.Location = New System.Drawing.Point(229, 391)
        Me.txAccountNo.Name = "txAccountNo"
        Me.txAccountNo.Size = New System.Drawing.Size(206, 29)
        Me.txAccountNo.TabIndex = 86
        Me.txAccountNo.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox11)
        Me.GroupBox7.Controls.Add(Me.GroupBox10)
        Me.GroupBox7.Location = New System.Drawing.Point(10, 211)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(454, 170)
        Me.GroupBox7.TabIndex = 86
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Transaction"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txOR)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 94)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(442, 64)
        Me.GroupBox11.TabIndex = 90
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Official Reciept"
        '
        'txOR
        '
        Me.txOR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txOR.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txOR.Location = New System.Drawing.Point(7, 24)
        Me.txOR.Name = "txOR"
        Me.txOR.Size = New System.Drawing.Size(431, 29)
        Me.txOR.TabIndex = 87
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txAmount)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 24)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(443, 64)
        Me.GroupBox10.TabIndex = 87
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Amount"
        '
        'txAmount
        '
        Me.txAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txAmount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txAmount.Location = New System.Drawing.Point(6, 24)
        Me.txAmount.Name = "txAmount"
        Me.txAmount.Size = New System.Drawing.Size(431, 29)
        Me.txAmount.TabIndex = 86
        '
        'txName
        '
        Me.txName.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txName.Location = New System.Drawing.Point(6, 24)
        Me.txName.Name = "txName"
        Me.txName.Size = New System.Drawing.Size(430, 29)
        Me.txName.TabIndex = 86
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txName)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(442, 64)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lastname (Search)"
        '
        'txBalance
        '
        Me.txBalance.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txBalance.Enabled = False
        Me.txBalance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txBalance.Location = New System.Drawing.Point(6, 24)
        Me.txBalance.Name = "txBalance"
        Me.txBalance.Size = New System.Drawing.Size(202, 29)
        Me.txBalance.TabIndex = 86
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txBalance)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 94)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(214, 64)
        Me.GroupBox4.TabIndex = 88
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Balance"
        '
        'txAccountMirror
        '
        Me.txAccountMirror.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txAccountMirror.Enabled = False
        Me.txAccountMirror.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txAccountMirror.Location = New System.Drawing.Point(10, 24)
        Me.txAccountMirror.Name = "txAccountMirror"
        Me.txAccountMirror.Size = New System.Drawing.Size(206, 29)
        Me.txAccountMirror.TabIndex = 90
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txAccountMirror)
        Me.GroupBox6.Location = New System.Drawing.Point(226, 94)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(222, 64)
        Me.GroupBox6.TabIndex = 89
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Account No"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.GroupBox4)
        Me.GroupBox5.Controls.Add(Me.GroupBox3)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 37)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(454, 168)
        Me.GroupBox5.TabIndex = 85
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Account Info"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txAccountNo)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.GroupBox7)
        Me.Panel4.Controls.Add(Me.GroupBox5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(478, 441)
        Me.Panel4.TabIndex = 97
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(23, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(182, 33)
        Me.Button1.TabIndex = 87
        Me.Button1.Text = "Proceed"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'AdvancePaymentCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 441)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "AdvancePaymentCreate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdvancePaymentCreate"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txAmount As System.Windows.Forms.TextBox
    Friend WithEvents txName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txBalance As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txAccountMirror As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txOR As System.Windows.Forms.TextBox
End Class
