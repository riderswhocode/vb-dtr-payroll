<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvert
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCm = New System.Windows.Forms.TextBox()
        Me.btnHeight = New System.Windows.Forms.Button()
        Me.txtInch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFeet = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKg = New System.Windows.Forms.TextBox()
        Me.btnWeight = New System.Windows.Forms.Button()
        Me.txtPounds = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCm)
        Me.GroupBox1.Controls.Add(Me.btnHeight)
        Me.GroupBox1.Controls.Add(Me.txtInch)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFeet)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(198, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Height"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cm:"
        '
        'txtCm
        '
        Me.txtCm.Location = New System.Drawing.Point(44, 72)
        Me.txtCm.Name = "txtCm"
        Me.txtCm.ReadOnly = True
        Me.txtCm.Size = New System.Drawing.Size(133, 20)
        Me.txtCm.TabIndex = 5
        '
        'btnHeight
        '
        Me.btnHeight.Location = New System.Drawing.Point(44, 43)
        Me.btnHeight.Name = "btnHeight"
        Me.btnHeight.Size = New System.Drawing.Size(133, 23)
        Me.btnHeight.TabIndex = 4
        Me.btnHeight.Text = "Convert"
        Me.btnHeight.UseVisualStyleBackColor = True
        '
        'txtInch
        '
        Me.txtInch.Location = New System.Drawing.Point(139, 17)
        Me.txtInch.Name = "txtInch"
        Me.txtInch.Size = New System.Drawing.Size(38, 20)
        Me.txtInch.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(89, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inche/s:"
        '
        'txtFeet
        '
        Me.txtFeet.Location = New System.Drawing.Point(44, 17)
        Me.txtFeet.Name = "txtFeet"
        Me.txtFeet.Size = New System.Drawing.Size(38, 20)
        Me.txtFeet.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Feet:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtKg)
        Me.GroupBox2.Controls.Add(Me.btnWeight)
        Me.GroupBox2.Controls.Add(Me.txtPounds)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(216, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(198, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Weight"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Kg:"
        '
        'txtKg
        '
        Me.txtKg.Location = New System.Drawing.Point(44, 72)
        Me.txtKg.Name = "txtKg"
        Me.txtKg.ReadOnly = True
        Me.txtKg.Size = New System.Drawing.Size(133, 20)
        Me.txtKg.TabIndex = 5
        '
        'btnWeight
        '
        Me.btnWeight.Location = New System.Drawing.Point(44, 43)
        Me.btnWeight.Name = "btnWeight"
        Me.btnWeight.Size = New System.Drawing.Size(133, 23)
        Me.btnWeight.TabIndex = 4
        Me.btnWeight.Text = "Convert"
        Me.btnWeight.UseVisualStyleBackColor = True
        '
        'txtPounds
        '
        Me.txtPounds.Location = New System.Drawing.Point(44, 17)
        Me.txtPounds.Name = "txtPounds"
        Me.txtPounds.Size = New System.Drawing.Size(38, 20)
        Me.txtPounds.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Lbs:"
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(216, 118)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(198, 23)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "Copy to Form"
        Me.btnCopy.UseVisualStyleBackColor = True
        Me.btnCopy.Visible = False
        '
        'frmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(427, 148)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConvert"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFeet As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHeight As System.Windows.Forms.Button
    Friend WithEvents txtCm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtKg As System.Windows.Forms.TextBox
    Friend WithEvents btnWeight As System.Windows.Forms.Button
    Friend WithEvents txtPounds As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCopy As System.Windows.Forms.Button
End Class
