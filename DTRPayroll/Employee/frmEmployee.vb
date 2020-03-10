Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class frmEmployee

    'SSS ID Format Sample 04-1234567-0
    'GSIS ID Format Sample 4000 0076 1978 0014
    'PHILHEALTH ID Format Sample 01-025131564-2
    'PAGIBIG ID Format Sample 1234-5678-9101

    Dim Firstname, Middlename, Lastname, Ext, Brgy, City, Province, Gender, Status As String
    Dim Citizenship, TIN, BType, Contact, Email As String
    Dim SSS, PAGIBIG, PHILHEALTH As String
    Dim DOB As Date
    Dim _Height, _Weight As Double
    Dim Age As Integer
    Dim saveFlag As Boolean

    Public Sub loadEmployeeFullInfo(ByRef EmpID As String)
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID,tblemployee.Lastname,tblemployee.Firstname,tblemployee.Middlename, " +
                                  "tblemployee.Ext, tblemployee.DOB,tblemployee.Age,tblemployee.Barangay," +
                                  "tblemployee.City, tblemployee.Province,tblemployee.Gender,tblemployee.CivilStatus, " +
                                  "tblemployee.Citizenship,tblemployee.Height,tblemployee.Weight,tblemployee.TIN," +
                                  "tblemployee.BloodType,tblemployee.ContactNo,tblemployee.Email, " +
                                  "tbldesignation.Position,tbldesignation.DeptTitle, " +
                                  "tblrates.Rate " +
                                  "FROM tblemployee, tbldesignation, tblrates WHERE tblemployee.EmployeeID = '" & EmpID & "' " +
                                  "AND tbldesignation.EmployeeID = '" & EmpID & "' AND tblrates.EmployeeID = '" & EmpID & "'"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    If sqldr.HasRows Then
                        While sqldr.Read
                            With Me
                                .txtLastname.Text = sqldr("Lastname")
                                .txtFirstname.Text = sqldr("Firstname")
                                .txtMiddlename.Text = sqldr("Middlename")
                                .txtExt.Text = sqldr("Ext")
                                .txtBrgy.Text = sqldr("Barangay")
                                .txtCity.Text = sqldr("City")
                                .txtProvince.Text = sqldr("Province")
                                .txtDOB.Value = sqldr("DOB")
                                .txtGender.Text = sqldr("Gender")
                                .txtStatus.Text = sqldr("CivilStatus")
                                .txtAge.Text = sqldr("Age")
                                .txtCitizenship.Text = sqldr("Citizenship")
                                .txtHeight.Text = sqldr("Height")
                                .txtWeight.Text = sqldr("Weight")
                                .txtTIN.Text = sqldr("TIN")
                                .txtBtype.Text = sqldr("BloodType")
                                .txtContact.Text = sqldr("ContactNo")
                                .txtEmail.Text = sqldr("Email")

                                .txtEmpID.Text = sqldr("EmployeeID")
                                .txtPosition.Text = sqldr("Position")
                                .txtDepartment.Text = sqldr("DeptTitle")
                                .txtRate.Text = sqldr("Rate")
                            End With
                        End While
                    End If
                End Using
            End Using
        End Using
    End Sub

    Sub enableFields()
        txtLastname.Enabled = True
        txtFirstname.Enabled = True
        txtMiddlename.Enabled = True
        txtExt.Enabled = True
        txtBrgy.Enabled = True
        txtCity.Enabled = True
        txtProvince.Enabled = True
        txtDOB.Enabled = True
        txtGender.Enabled = True
        txtStatus.Enabled = True
        txtCitizenship.Enabled = True
        txtHeight.Enabled = True
        txtWeight.Enabled = True
        txtTIN.Enabled = True
        txtBtype.Enabled = True
        txtContact.Enabled = True
        txtEmail.Enabled = True
        txtSSS.Enabled = True
        txtPHILHEALTH.Enabled = True
        txtPAGIBIG.Enabled = True
        txtPosition.Enabled = True
        txtDepartment.Enabled = True
        txtRate.Enabled = True
        btnCancel.Enabled = True
        btnSave.Enabled = True
        btnClose1.Enabled = True
        btnSearch.Enabled = False
        btnUpdate.Enabled = False
        btnNew.Enabled = False
    End Sub
    Sub disableFields()
        txtLastname.Enabled = False
        txtFirstname.Enabled = False
        txtMiddlename.Enabled = False
        txtExt.Enabled = False
        txtBrgy.Enabled = False
        txtCity.Enabled = False
        txtProvince.Enabled = False
        txtDOB.Enabled = False
        txtGender.Enabled = False
        txtStatus.Enabled = False
        txtCitizenship.Enabled = False
        txtHeight.Enabled = False
        txtWeight.Enabled = False
        txtTIN.Enabled = False
        txtBtype.Enabled = False
        txtContact.Enabled = False
        txtEmail.Enabled = False
        txtSSS.Enabled = False
        txtPHILHEALTH.Enabled = False
        txtPAGIBIG.Enabled = False
        txtPosition.Enabled = False
        txtDepartment.Enabled = False
        txtRate.Enabled = False
        btnCancel.Enabled = False
        btnSave.Enabled = False
        btnSearch.Enabled = True
        btnUpdate.Enabled = True
        btnNew.Enabled = True
    End Sub
    Sub clearBoxes()
        txtFirstname.Text = ""
        txtMiddlename.Text = ""
        txtLastname.Text = ""
        txtBrgy.Text = ""
        txtCity.Text = ""
        txtProvince.Text = ""
        txtGender.Text = ""
        txtStatus.Text = ""
        txtCitizenship.Text = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtTIN.Text = ""
        txtBtype.Text = ""
        txtContact.Text = "'"
        txtEmail.Text = ""

        txtSSS.Text = ""
        txtPHILHEALTH.Text = ""
        txtPAGIBIG.Text = ""

        txtPosition.Text = ""
        txtDepartment.Text = ""
        txtRate.Text = ""
    End Sub
    Sub validateInput()
        If txtFirstname.Text = "" Or txtLastname.Text = "" Or txtBrgy.Text = "" Or txtCity.Text = "" Or txtProvince.Text = "" Then
            MsgBox("All fields are required")
        ElseIf txtGender.Text = "" Or txtStatus.Text = "" Or txtCitizenship.Text = "" Or txtHeight.Text = "" Or txtWeight.Text = "" Then
            MsgBox("All fields are required")
        ElseIf txtTIN.Text = "" Or txtBtype.Text = "" Or txtContact.Text = "" Or txtEmail.Text = "" Then
            MsgBox("All fields are required")
        ElseIf txtPosition.Text = "" Or txtDepartment.Text = "" Then
            MsgBox("All fields are required")
        Else
            Firstname = Regex.Replace(txtFirstname.Text, "[^A-Za-z0-9\-/]", "")
            Middlename = Regex.Replace(txtMiddlename.Text, "[^A-Za-z0-9\-/]", "")
            Lastname = Regex.Replace(txtLastname.Text, "[^A-Za-z0-9\-/]", "")
            Ext = Regex.Replace(txtExt.Text, "[^A-Za-z0-9\-/]", "")
            Brgy = Regex.Replace(txtBrgy.Text, "[^A-Za-z0-9\-/]", "")
            City = Regex.Replace(txtCity.Text, "[^A-Za-z0-9\-/]", "")
            Province = Regex.Replace(txtProvince.Text, "[^A-Za-z0-9\-/]", "")
            DOB = txtDOB.Value.ToShortDateString
            Gender = txtGender.Text
            Status = txtStatus.Text
            Citizenship = Regex.Replace(txtCitizenship.Text, "[^A-Za-z0-9\-/]", "")
            _Height = Regex.Replace(txtHeight.Text, "[^A-Za-z0-9\-/]", "")
            _Weight = Regex.Replace(txtWeight.Text, "[^A-Za-z0-9\-/]", "")
            TIN = Regex.Replace(txtTIN.Text, "[^A-Za-z0-9\-/]", "")
            BType = Regex.Replace(txtBtype.Text, "[^A-Za-z0-9\-/]", "")
            Contact = Regex.Replace(txtContact.Text, "[^A-Za-z0-9\-/]", "")
            Email = txtEmail.Text
            Call Me.save()
        End If
    End Sub
    Sub validateForUpdate()
        Firstname = Regex.Replace(txtFirstname.Text, "[^A-Za-z0-9\-/]", "")
        Middlename = Regex.Replace(txtMiddlename.Text, "[^A-Za-z0-9\-/]", "")
        Lastname = Regex.Replace(txtLastname.Text, "[^A-Za-z0-9\-/]", "")
        Ext = Regex.Replace(txtExt.Text, "[^A-Za-z0-9\-/]", "")
        Brgy = Regex.Replace(txtBrgy.Text, "[^A-Za-z0-9\-/]", "")
        City = Regex.Replace(txtCity.Text, "[^A-Za-z0-9\-/]", "")
        Province = Regex.Replace(txtProvince.Text, "[^A-Za-z0-9\-/]", "")
        DOB = txtDOB.Value.ToShortDateString
        Gender = txtGender.Text
        Status = txtStatus.Text
        Citizenship = Regex.Replace(txtCitizenship.Text, "[^A-Za-z0-9\-/]", "")
        _Height = Regex.Replace(txtHeight.Text, "[^A-Za-z0-9\-/]", "")
        _Weight = Regex.Replace(txtWeight.Text, "[^A-Za-z0-9\-/]", "")
        TIN = Regex.Replace(txtTIN.Text, "[^A-Za-z0-9\-/]", "")
        BType = Regex.Replace(txtBtype.Text, "[^A-Za-z0-9\-/]", "")
        Contact = Regex.Replace(txtContact.Text, "[^A-Za-z0-9\-/]", "")
        Email = txtEmail.Text
    End Sub
    Sub loadDepartment()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT DISTINCT DeptTitle FROM tbldepartment"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    txtDepartment.Items.Clear()
                    While sqldr.Read
                        If sqldr.HasRows Then
                            txtDepartment.Items.Add(sqldr("DeptTitle"))
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub
    Sub save()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tblemployee(EmployeeID,Firstname,Middlename,Lastname,Ext,DOB,Age, " +
                                  "Barangay,City,Province,Gender,CivilStatus,Citizenship,Height,Weight,TIN,BloodType,ContactNo,Email) " +
                                  "VALUES(@EmployeeID,@Firstname,@Middlename,@Lastname,@Ext,@DOB,@Age,@Barangay,@City, " +
                                  "@Province,@Gender,@CivilStatus,@Citizenship,@Height,@Weight,@TIN,@BloodType,@Contact,@Email)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmployeeID", empID)
                sqlcmd.Parameters.AddWithValue("@Firstname", Firstname)
                sqlcmd.Parameters.AddWithValue("@Middlename", Middlename)
                sqlcmd.Parameters.AddWithValue("@Lastname", Lastname)
                sqlcmd.Parameters.AddWithValue("@Ext", Ext)
                sqlcmd.Parameters.AddWithValue("@DOB", DOB)
                sqlcmd.Parameters.AddWithValue("@Age", txtAge.Text)
                sqlcmd.Parameters.AddWithValue("@Barangay", Brgy)
                sqlcmd.Parameters.AddWithValue("@City", City)
                sqlcmd.Parameters.AddWithValue("@Province", Province)
                sqlcmd.Parameters.AddWithValue("@Gender", Gender)
                sqlcmd.Parameters.AddWithValue("@CivilStatus", Status)
                sqlcmd.Parameters.AddWithValue("@Citizenship", Citizenship)
                sqlcmd.Parameters.AddWithValue("@Height", _Height)
                sqlcmd.Parameters.AddWithValue("@Weight", _Weight)
                sqlcmd.Parameters.AddWithValue("@TIN", TIN)
                sqlcmd.Parameters.AddWithValue("@BloodType", BType)
                sqlcmd.Parameters.AddWithValue("@Contact", Contact)
                sqlcmd.Parameters.AddWithValue("@Email", Email)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using

        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tbldsss(EmployeeID,SSS) " +
                                  "VALUES(@EmpID,@SSS)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                sqlcmd.Parameters.AddWithValue("@SSS", txtSSS.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tblphilhealth(EmployeeID,PHILHEALTH) " +
                                  "VALUES(@EmpID,@PHILHEALTH)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                sqlcmd.Parameters.AddWithValue("@PHILHEALTH", txtPHILHEALTH.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tblpagibig(EmployeeID,PAGIBIG) " +
                                  "VALUES(@EmpID,@PAGIBIG)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                sqlcmd.Parameters.AddWithValue("@PAGIBIG", txtPAGIBIG.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tbldesignation(EmployeeID,Position,DeptTitle) " +
                                  "VALUES(@EmpID,@Position,@Dept)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                sqlcmd.Parameters.AddWithValue("@Position", txtPosition.Text)
                sqlcmd.Parameters.AddWithValue("@Dept", txtDepartment.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT INTO tblrates(EmployeeID,MonthYear,Rate) " +
                                  "VALUES(@EmpID,@MonthYear,@Rate)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                sqlcmd.Parameters.AddWithValue("@MonthYear", "CURDATE()")
                sqlcmd.Parameters.AddWithValue("@Rate", txtRate.Text)
            End Using
        End Using
        If accType = "ADMIN" Then
            If MessageBox.Show("Do you want to create an account for this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New frmNewUser(empID)
                frm.ShowDialog()
                Call Me.clearBoxes()
                empID = Functions.employeeIDGenerator
                txtEmpID.Text = empID
            Else
                Call Me.clearBoxes()
                empID = Functions.employeeIDGenerator
                txtEmpID.Text = empID
            End If
        Else
            Call Me.clearBoxes()
            empID = Functions.employeeIDGenerator
            txtEmpID.Text = empID
        End If
        
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call Me.enableFields()
        saveFlag = True
        empID = Functions.employeeIDGenerator
        txtEmpID.Text = empID
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call Me.disableFields()
        Call Me.clearBoxes()
        txtEmpID.Text = ""
    End Sub

    Private Sub btnClose1_Click(sender As Object, e As EventArgs) Handles btnClose1.Click
        Me.Close()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        frmConvert.ShowDialog()
    End Sub

    Private Sub txtDOB_Validated(sender As Object, e As EventArgs) Handles txtDOB.Validated
        txtAge.Text = Functions.GetCurrentAge(txtDOB.Value)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If saveFlag Then
            Call Me.validateInput()
        Else
            Call Me.validateForUpdate()
            empID = txtEmpID.Text
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "UPDATE tblemployee SET Firstname=@Firstname, Middlename = @Middlename, " +
                                      "Lastname = @Lastname, Ext = @Ext, DOB = @DOB, Age = @Age, Barangay = @Brgy, " +
                                      "City = @City, Province = @Province, Gender = @Gender, CivilStatus = @Civil, " +
                                      "Citizenship = @Citizenship, Height = @Height, Weight = @Weight, TIN = @TIN, " +
                                      "BloodType = @BloodType, ContactNo = @Contact, Email = @Email " +
                                      " WHERE EmployeeID = @EmpID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@Firstname", Firstname)
                    sqlcmd.Parameters.AddWithValue("@Middlename", Middlename)
                    sqlcmd.Parameters.AddWithValue("@Lastname", Lastname)
                    sqlcmd.Parameters.AddWithValue("@Ext", Ext)
                    sqlcmd.Parameters.AddWithValue("@DOB", DOB)
                    sqlcmd.Parameters.AddWithValue("@Age", txtAge.Text)
                    sqlcmd.Parameters.AddWithValue("@Brgy", Brgy)
                    sqlcmd.Parameters.AddWithValue("@City", City)
                    sqlcmd.Parameters.AddWithValue("@Province", Province)
                    sqlcmd.Parameters.AddWithValue("@Gender", Gender)
                    sqlcmd.Parameters.AddWithValue("@Civil", Status)
                    sqlcmd.Parameters.AddWithValue("@Citizenship", Citizenship)
                    sqlcmd.Parameters.AddWithValue("@Height", _Height)
                    sqlcmd.Parameters.AddWithValue("@Weight", _Weight)
                    sqlcmd.Parameters.AddWithValue("@TIN", TIN)
                    sqlcmd.Parameters.AddWithValue("@BloodType", BType)
                    sqlcmd.Parameters.AddWithValue("@Contact", Contact)
                    sqlcmd.Parameters.AddWithValue("@Email", Email)
                    sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                    sqlcmd.ExecuteNonQuery()
                End Using
            End Using
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "UPDATE tblgsis,tblsss,tblphilhealth,tblpagibig " +
                                      "SET tblsss.SSS = @SSS, " +
                                      "tblphilhealth.PHILHEALTH = @PHILHEALTH, tblpagibig.PAGIBIG = @PAGIBIG " +
                                      "WHERE tblsss.EmployeeID = @EmpID AND " +
                                      "tblphilhealth.EmployeeID = @EmpID AND tblpagibig.EmployeeID = @EmpID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                    sqlcmd.Parameters.AddWithValue("@SSS", txtSSS.Text)
                    sqlcmd.Parameters.AddWithValue("@PHILHEALTH", txtPHILHEALTH.Text)
                    sqlcmd.Parameters.AddWithValue("@PAGIBIG", txtPAGIBIG.Text)
                    sqlcmd.ExecuteNonQuery()
                End Using
            End Using
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "UPDATE tbldesignation,tblrates SET tblrates.Rate = @Rate, " +
                                      "tbldesignation.Position = @Position, tbldesignation.DeptTitle = @Dept " +
                                      "WHERE tblrates.EmployeeID = tbldesignation.EmployeeID AND " +
                                      "tbldesignation.EmployeeID = @EmpID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@Rate", txtRate.Text)
                    sqlcmd.Parameters.AddWithValue("@Position", txtPosition.Text)
                    sqlcmd.Parameters.AddWithValue("@Dept", txtDepartment.Text)
                    sqlcmd.Parameters.AddWithValue("@EmpID", empID)
                End Using
            End Using
            MsgBox("Updated successfully")
            Call Me.clearBoxes()
            Call Me.disableFields()
            txtEmpID.Text = ""
        End If
    End Sub

    Private Sub txtGender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGender.KeyPress
        e.Handled = True
    End Sub
    Private Sub txtStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStatus.KeyPress
        e.Handled = True
    End Sub
    Private Sub txtPosition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPosition.KeyPress
        e.Handled = True
    End Sub
    Private Sub txtDepartment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepartment.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtSSS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSSS.KeyPress
        If txtSSS.TextLength <= 12 Then
            IDInputFormat(e)
        Else
            e.Handled = True
            MsgBox("Invalid SSS ID Number Length")
        End If
    End Sub
    Private Sub txtPHILHEALTH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPHILHEALTH.KeyPress
        If txtPHILHEALTH.TextLength <= 14 Then
            IDInputFormat(e)
        Else
            e.Handled = True
            MsgBox("Invalid PHILHEALTH ID Number Length")
        End If
    End Sub
    Private Sub txtPAGIBIG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPAGIBIG.KeyPress
        If txtPAGIBIG.TextLength <= 14 Then
            IDInputFormat(e)
        Else
            e.Handled = True
            MsgBox("Invalid PAGIBIG ID Number Length")
        End If
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadDepartment()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmViewEmployee.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtEmpID.Text <> "" Then
            If MessageBox.Show("Are you sure want to update the user information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                saveFlag = False
                Call Me.enableFields()
            End If
        End If
        
    End Sub
End Class