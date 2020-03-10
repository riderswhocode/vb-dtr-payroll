Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Module Functions

#Region "Public"
    Public conString As String = "Server=localhost;uid=root;Password='';Database=gss;Convert Zero Datetime=true;"
    Dim DBServer As String
    Dim DBUser As String
    Dim DBPass As String
    Dim DBName As String

    Public empID As String
    Public accType As String = "ADMIN"

    Public _leaveID As String
    Public _travelID As String
    Public _passID As String
    Public _rateID As String
    Public _caID As String

#End Region
#Region "Crypto"
    Public hashKey As String = "c411ec3fbe63b02c622f135613672f82"

    Dim DES As New TripleDESCryptoServiceProvider
    Dim MD5 As New MD5CryptoServiceProvider

    Function MD5Hash(value As String)
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function
    Public Function Encrypt(input As String, key As String) As String
        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB

        Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(input)

        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function
    Public Function Decrypt(input As String, key As String) As String
        DES.Key = MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim buffer As Byte() = Convert.FromBase64String(input)
        Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function
#End Region

    Public Function insertConfig(server As String, username As String, pass As String, db As String) As Boolean
        Dim success As Boolean
        Dim path As String = "./dtr.ini"
        Dim data As String() = {Encrypt(server, hashKey), Encrypt(username, hashKey), Encrypt(pass, hashKey), Encrypt(db, hashKey)}
        File.WriteAllLines(path, data)
        success = True
        Return success
    End Function
    Public Function checkConnection() As Boolean
        Dim status As Boolean
        Dim objReader As New StreamReader("./dtr.ini")
        Dim s As String = ""
        Dim Data As String()
        Do While objReader.Peek <> -1
            s += objReader.ReadLine & " "
        Loop

        If String.IsNullOrWhiteSpace(s) Then
            status = False
            Return False
            Exit Function
        Else
            If s.Length <> 0 Then
                Data = s.Split(" ")
                My.Settings.Servername = Decrypt(Data(0), hashKey)
                My.Settings.ServerUser = Decrypt(Data(1), hashKey)
                My.Settings.ServerPass = Decrypt(Data(2), hashKey)
                My.Settings.ServerDB = Decrypt(Data(3), hashKey)
            End If

        End If
        objReader.Close()

        conString = "Server='" & My.Settings.Servername & "';uid='" & My.Settings.ServerUser & "';Password='" & My.Settings.ServerPass & "';Database='" & My.Settings.ServerDB & "';Convert Zero Datetime=true;"

        Using sqlcon As New MySql.Data.MySqlClient.MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT DATABASE()"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    sqldr.Read()
                    If sqldr.HasRows Then
                        status = True
                    Else
                        status = False
                    End If
                End Using
            End Using
        End Using
        Return status
    End Function


    Sub setFormsize(frm As Form)
        frm.MaximumSize = Screen.FromRectangle(frm.Bounds).WorkingArea.Size
        frm.WindowState = FormWindowState.Maximized
    End Sub
    Public Sub IntDouble(a As Boolean, e As KeyPressEventArgs)
        If a = False Then
            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf a = True Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub IntDouble2(a As Boolean, b As String, e As KeyPressEventArgs)
        If a = False Then
            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf a = True Then
            Dim c As Integer = 0
            Try
                Dim str As String() = b.Split(".")
                c = str.Length - 1
            Catch ex As Exception
                c = 0
            End Try

            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
                If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf e.KeyChar = "." And c = 0 Then
                    e.Handled = False
                ElseIf e.KeyChar = "." And c > 0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub IDInputFormat(e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Or e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Function convertHeight(ft As Integer, inch As Integer) As Double
        Dim newHeight As Double
        newHeight = ((CInt(ft) * 12) + CInt(inch)) * 2.54
        Return newHeight
    End Function
    Function convertWeight(lbs As Double) As Double
        Dim newWeight As Double
        newWeight = CDbl(lbs) * 0.45
        Return newWeight
    End Function
    Function IsEmail(ByVal email As String) As Boolean
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailExpression.IsMatch(email)
    End Function

    Public Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Function employeeIDGenerator() As String
        Dim id As String = ""
        Using sqlcon As New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT EmployeeID FROM tblemployee ORDER BY EmployeeID ASC LIMIT 1"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    If sqldr.HasRows Then
                        While sqldr.Read
                            id = CInt(sqldr(0)) + 1
                        End While
                    Else
                        id = "100001005"
                    End If
                End Using
            End Using
        End Using
        Return id
    End Function


    Sub loadEmployeeFullInfo(ByRef EmpID As String)
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID,tblemployee.Lastname,tblemployee.Firstname,tblemployee.Middlename, " +
                                  "tblemployee.Ext, tblemployee.DOB,tblemployee.Age,tblemployee.Barangay," +
                                  "tblemployee.City, tblemployee.Province,tblemployee.Gender,tblemployee.CivilStatus, " +
                                  "tblemployee.Citizenship,tblemployee.Height,tblemployee.Weight,tblemployee.TIN," +
                                  "tblemployee.BloodType,tblemployee.ContactNo,tblemployee.Email, " +
                                  "tbldesignation.Position,tbldesignation.DeptTitle, " +
                                  "tblrates.Rate,tblgsis.GSIS,tblsss.SSS,tblphilhealth.PHILHEALTH,tblpagibig.PAGIBIG " +
                                  "FROM tblemployee, tbldesignation, tblrates, tblgsis, tblsss, tblphilhealth, tblpagibig WHERE tblemployee.EmployeeID = '" & EmpID & "' " +
                                  "AND tbldesignation.EmployeeID = '" & EmpID & "' AND tblrates.EmployeeID = '" & EmpID & "' " +
                                  "AND tblgsis.EmployeeID = '" & EmpID & "' AND tblsss.EmployeeID = '" & EmpID & "' " +
                                  "AND tblphilhealth.EmployeeID = '" & EmpID & "' AND tblpagibig.EmployeeID = '" & EmpID & "'"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    If sqldr.HasRows Then
                        While sqldr.Read
                            With frmEmployee
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

                                .txtGSIS.Text = sqldr("GSIS")
                                .txtSSS.Text = sqldr("SSS")
                                .txtPHILHEALTH.Text = sqldr("PHILHEALTH")
                                .txtPAGIBIG.Text = sqldr("PAGIBIG")

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

End Module
