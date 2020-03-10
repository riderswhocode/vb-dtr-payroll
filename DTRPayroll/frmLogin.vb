Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class frmLogin

    Dim username, password As String

    Sub validateInput()
        username = Regex.Replace(txtUser.Text, "[^A-Za-z0-9\-/]", "")
        password = txtPass.Text
    End Sub

    Function isLogin(ByRef user As String, ByRef pass As String) As String
        Dim s As String
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT Username,Password,UserType, AccountStatus FROM tbluser " +
                                  "WHERE Username = @User AND Password = @Pass AND LoginStatus = @LoginStatus"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@User", username)
                sqlcmd.Parameters.AddWithValue("@Pass", Encrypt(password, hashKey))
                sqlcmd.Parameters.AddWithValue("@LoginStatus", "LOGOUT")
                Using sqldr = sqlcmd.ExecuteReader
                    If sqldr.HasRows Then
                        sqldr.Read()
                        If sqldr("AccountStatus").ToString = "PENDING" Then
                            s = "PENDING"
                        Else
                            s = "LOGIN"
                        End If
                    Else
                        s = "INVALID"
                    End If
                End Using
            End Using
        End Using
        Return s
    End Function

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'If txtUser.Text = "admin" And txtPass.Text = "admin" Then
        '    MainForm.Show()
        '    Me.Close()
        'Else
        '    MsgBox("Invalid username or password")
        'End If
        If txtUser.Text <> "" And txtPass.Text <> "" Then
            Call Me.validateInput()
            If isLogin(username, password) = "LOGIN" Then
                MainForm.Show()
                Me.Close()
            ElseIf isLogin(username, password) = "INVALID" Then
                MsgBox("Invalid Username or Password")
            Else
                MsgBox("This account is still pending")
            End If
        Else
            MsgBox("Username or Password cannot be empty")
            txtUser.Focus()
        End If


    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUser.Focus()
    End Sub
End Class