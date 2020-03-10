Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class frmNewUser

    Dim id As String

    Public Sub New()

        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal empID As String)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        id = empID
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtUsername.Text <> "" And txtPassword.Text <> "" And txtUsertype.Text <> "" Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "INSERT INTO tbluser(Username,Password,UserType,LoginStatus,AccountStatus,EmployeeID) " +
                                      "VALUES(@Username,@Password,@UserType, 'LOGOUT', 'PENDING', @empID)"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@Username", Regex.Replace(txtUsername.Text, "[^A-Za-z0-9\-/]", ""))
                    sqlcmd.Parameters.AddWithValue("@Password", Encrypt(txtPassword.Text, hashKey))
                    sqlcmd.Parameters.AddWithValue("@UserType", txtUsertype.Text)
                    sqlcmd.Parameters.AddWithValue("@empID", id)
                    Dim x As Integer = sqlcmd.ExecuteNonQuery()
                    If x = 1 Then
                        MsgBox("User account successfully created")
                        Me.Close()
                    Else
                        MsgBox("Error saving")
                    End If
                End Using
            End Using
        Else
            MsgBox("Username and Password cannot be empty")
        End If
    End Sub

    Private Sub txtUsertype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsertype.KeyPress
        e.Handled = True
    End Sub

    Private Sub frmNewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class