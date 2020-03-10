<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusConnection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.UserAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDUSERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWUSERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NEWEMPLOYEEToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VIEWEMPLOYEEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LEAVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TRAVELORDERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PASSSLIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RATEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CASHADVANCEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEDUCTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SERVERSETTINGSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEPARTMENTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPDATEToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SIGNATORYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPDATEToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEDUCTIONToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ADDToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPDATEToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusUser, Me.statusConnection})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1058, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusUser
        '
        Me.StatusUser.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.StatusUser.Name = "StatusUser"
        Me.StatusUser.Size = New System.Drawing.Size(59, 17)
        Me.StatusUser.Text = "User: Jade"
        '
        'statusConnection
        '
        Me.statusConnection.Name = "statusConnection"
        Me.statusConnection.Size = New System.Drawing.Size(72, 17)
        Me.statusConnection.Text = "Connection:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumBlue
        Me.Panel1.Controls.Add(Me.btnMin)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 54)
        Me.Panel1.TabIndex = 1
        '
        'btnMin
        '
        Me.btnMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMin.BackColor = System.Drawing.Color.DarkRed
        Me.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.ForeColor = System.Drawing.Color.White
        Me.btnMin.Location = New System.Drawing.Point(997, 2)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(29, 23)
        Me.btnMin.TabIndex = 2
        Me.btnMin.TabStop = False
        Me.btnMin.Text = "_"
        Me.btnMin.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(1026, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(29, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(478, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Good Shepherd School - DTR and Payroll System"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1058, 38)
        Me.Panel2.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserAccountsToolStripMenuItem, Me.EmployeeToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.LogsToolStripMenuItem, Me.PayrollToolStripMenuItem, Me.ReportToolStripMenuItem, Me.SystemSettingsToolStripMenuItem, Me.LoginToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1058, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'UserAccountsToolStripMenuItem
        '
        Me.UserAccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDUSERToolStripMenuItem, Me.VIEWUSERToolStripMenuItem})
        Me.UserAccountsToolStripMenuItem.Name = "UserAccountsToolStripMenuItem"
        Me.UserAccountsToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.UserAccountsToolStripMenuItem.Text = "User Accounts"
        '
        'ADDUSERToolStripMenuItem
        '
        Me.ADDUSERToolStripMenuItem.Name = "ADDUSERToolStripMenuItem"
        Me.ADDUSERToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.ADDUSERToolStripMenuItem.Text = "ADD USER"
        '
        'VIEWUSERToolStripMenuItem
        '
        Me.VIEWUSERToolStripMenuItem.Name = "VIEWUSERToolStripMenuItem"
        Me.VIEWUSERToolStripMenuItem.Size = New System.Drawing.Size(160, 24)
        Me.VIEWUSERToolStripMenuItem.Text = "VIEW USERS"
        '
        'EmployeeToolStripMenuItem
        '
        Me.EmployeeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NEWEMPLOYEEToolStripMenuItem1, Me.VIEWEMPLOYEEToolStripMenuItem})
        Me.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        Me.EmployeeToolStripMenuItem.Size = New System.Drawing.Size(87, 24)
        Me.EmployeeToolStripMenuItem.Text = "Employee"
        '
        'NEWEMPLOYEEToolStripMenuItem1
        '
        Me.NEWEMPLOYEEToolStripMenuItem1.Name = "NEWEMPLOYEEToolStripMenuItem1"
        Me.NEWEMPLOYEEToolStripMenuItem1.Size = New System.Drawing.Size(187, 24)
        Me.NEWEMPLOYEEToolStripMenuItem1.Text = "NEW EMPLOYEE"
        '
        'VIEWEMPLOYEEToolStripMenuItem
        '
        Me.VIEWEMPLOYEEToolStripMenuItem.Name = "VIEWEMPLOYEEToolStripMenuItem"
        Me.VIEWEMPLOYEEToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.VIEWEMPLOYEEToolStripMenuItem.Text = "VIEW EMPLOYEE"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LEAVEToolStripMenuItem, Me.TRAVELORDERToolStripMenuItem, Me.PASSSLIPToolStripMenuItem, Me.RATEToolStripMenuItem, Me.CASHADVANCEToolStripMenuItem, Me.DEDUCTIONToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(96, 24)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'LEAVEToolStripMenuItem
        '
        Me.LEAVEToolStripMenuItem.Name = "LEAVEToolStripMenuItem"
        Me.LEAVEToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.LEAVEToolStripMenuItem.Text = "LEAVE"
        '
        'TRAVELORDERToolStripMenuItem
        '
        Me.TRAVELORDERToolStripMenuItem.Name = "TRAVELORDERToolStripMenuItem"
        Me.TRAVELORDERToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.TRAVELORDERToolStripMenuItem.Text = "TRAVEL ORDER"
        '
        'PASSSLIPToolStripMenuItem
        '
        Me.PASSSLIPToolStripMenuItem.Name = "PASSSLIPToolStripMenuItem"
        Me.PASSSLIPToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.PASSSLIPToolStripMenuItem.Text = "PASS SLIP"
        '
        'RATEToolStripMenuItem
        '
        Me.RATEToolStripMenuItem.Name = "RATEToolStripMenuItem"
        Me.RATEToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.RATEToolStripMenuItem.Text = "RATE"
        '
        'CASHADVANCEToolStripMenuItem
        '
        Me.CASHADVANCEToolStripMenuItem.Name = "CASHADVANCEToolStripMenuItem"
        Me.CASHADVANCEToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.CASHADVANCEToolStripMenuItem.Text = "CASH ADVANCE"
        '
        'DEDUCTIONToolStripMenuItem
        '
        Me.DEDUCTIONToolStripMenuItem.Name = "DEDUCTIONToolStripMenuItem"
        Me.DEDUCTIONToolStripMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.DEDUCTIONToolStripMenuItem.Text = "DEDUCTION"
        '
        'LogsToolStripMenuItem
        '
        Me.LogsToolStripMenuItem.Name = "LogsToolStripMenuItem"
        Me.LogsToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.LogsToolStripMenuItem.Text = "Logs"
        '
        'PayrollToolStripMenuItem
        '
        Me.PayrollToolStripMenuItem.Name = "PayrollToolStripMenuItem"
        Me.PayrollToolStripMenuItem.Size = New System.Drawing.Size(65, 24)
        Me.PayrollToolStripMenuItem.Text = "Payroll"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(66, 24)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'SystemSettingsToolStripMenuItem
        '
        Me.SystemSettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SERVERSETTINGSToolStripMenuItem, Me.DEPARTMENTToolStripMenuItem, Me.SIGNATORYToolStripMenuItem, Me.DEDUCTIONToolStripMenuItem1})
        Me.SystemSettingsToolStripMenuItem.Name = "SystemSettingsToolStripMenuItem"
        Me.SystemSettingsToolStripMenuItem.Size = New System.Drawing.Size(125, 24)
        Me.SystemSettingsToolStripMenuItem.Text = "System Settings"
        '
        'SERVERSETTINGSToolStripMenuItem
        '
        Me.SERVERSETTINGSToolStripMenuItem.Name = "SERVERSETTINGSToolStripMenuItem"
        Me.SERVERSETTINGSToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.SERVERSETTINGSToolStripMenuItem.Text = "SERVER SETTINGS"
        '
        'DEPARTMENTToolStripMenuItem
        '
        Me.DEPARTMENTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDToolStripMenuItem3, Me.UPDATEToolStripMenuItem1})
        Me.DEPARTMENTToolStripMenuItem.Name = "DEPARTMENTToolStripMenuItem"
        Me.DEPARTMENTToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.DEPARTMENTToolStripMenuItem.Text = "DEPARTMENT"
        '
        'ADDToolStripMenuItem3
        '
        Me.ADDToolStripMenuItem3.Name = "ADDToolStripMenuItem3"
        Me.ADDToolStripMenuItem3.Size = New System.Drawing.Size(132, 24)
        Me.ADDToolStripMenuItem3.Text = "ADD"
        '
        'UPDATEToolStripMenuItem1
        '
        Me.UPDATEToolStripMenuItem1.Name = "UPDATEToolStripMenuItem1"
        Me.UPDATEToolStripMenuItem1.Size = New System.Drawing.Size(132, 24)
        Me.UPDATEToolStripMenuItem1.Text = "UPDATE"
        '
        'SIGNATORYToolStripMenuItem
        '
        Me.SIGNATORYToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDToolStripMenuItem4, Me.UPDATEToolStripMenuItem2})
        Me.SIGNATORYToolStripMenuItem.Name = "SIGNATORYToolStripMenuItem"
        Me.SIGNATORYToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.SIGNATORYToolStripMenuItem.Text = "SIGNATORY"
        '
        'ADDToolStripMenuItem4
        '
        Me.ADDToolStripMenuItem4.Name = "ADDToolStripMenuItem4"
        Me.ADDToolStripMenuItem4.Size = New System.Drawing.Size(132, 24)
        Me.ADDToolStripMenuItem4.Text = "ADD"
        '
        'UPDATEToolStripMenuItem2
        '
        Me.UPDATEToolStripMenuItem2.Name = "UPDATEToolStripMenuItem2"
        Me.UPDATEToolStripMenuItem2.Size = New System.Drawing.Size(132, 24)
        Me.UPDATEToolStripMenuItem2.Text = "UPDATE"
        '
        'DEDUCTIONToolStripMenuItem1
        '
        Me.DEDUCTIONToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDToolStripMenuItem5, Me.UPDATEToolStripMenuItem3})
        Me.DEDUCTIONToolStripMenuItem1.Name = "DEDUCTIONToolStripMenuItem1"
        Me.DEDUCTIONToolStripMenuItem1.Size = New System.Drawing.Size(198, 24)
        Me.DEDUCTIONToolStripMenuItem1.Text = "DEDUCTION"
        '
        'ADDToolStripMenuItem5
        '
        Me.ADDToolStripMenuItem5.Name = "ADDToolStripMenuItem5"
        Me.ADDToolStripMenuItem5.Size = New System.Drawing.Size(132, 24)
        Me.ADDToolStripMenuItem5.Text = "ADD"
        '
        'UPDATEToolStripMenuItem3
        '
        Me.UPDATEToolStripMenuItem3.Name = "UPDATEToolStripMenuItem3"
        Me.UPDATEToolStripMenuItem3.Size = New System.Drawing.Size(132, 24)
        Me.UPDATEToolStripMenuItem3.Text = "UPDATE"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1058, 522)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents UserAccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PayrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWUSERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NEWEMPLOYEEToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VIEWEMPLOYEEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LEAVEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TRAVELORDERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PASSSLIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RATEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CASHADVANCEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEDUCTIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVERSETTINGSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEPARTMENTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPDATEToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SIGNATORYToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPDATEToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DEDUCTIONToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ADDToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPDATEToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusConnection As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ADDUSERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
