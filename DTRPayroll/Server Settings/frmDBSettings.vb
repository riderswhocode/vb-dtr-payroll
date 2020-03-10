Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class frmDBSettings

    Sub ListDB()
        Dim conString = "Server = '" & txtServername.Text & "';User Id='" & txtUsername.Text & "';Password='" & txtPassword.Text & "'"
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SHOW DATABASES"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    If sqldr.HasRows Then
                        txtDBname.Items.Clear()
                        While sqldr.Read
                            txtDBname.Items.Add(sqldr(0).ToString)
                        End While
                    End If
                End Using
            End Using
            'Using adpt = New MySqlDataAdapter(query, sqlcon)
            '    Dim dt As New DataTable
            '    adpt.Fill(dt)
            '    txtDBname.Items.Clear()
            '    Dim i = 0
            '    While i = 0 <> dt.Rows.Count - 1
            '        txtDBname.Items.Add(dt.Rows(i).ToString())
            '        i += 1
            '    End While
            'End Using
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtServername.Text = "" Or txtUsername.Text = "" Then
            Label1.Text = "Servername or Username cannot be empty"
            txtServername.Focus()
        Else
            If txtDBname.Text = "" Then
                Label1.Text = "Select your Database.."
                txtDBname.Focus()
            Else
                Dim server As String = txtServername.Text
                Dim user As String = txtUsername.Text
                Dim pass As String = txtPassword.Text
                Dim db As String = txtDBname.Text
                Dim flag = Functions.insertConfig(server, user, pass, db)
                If flag Then
                    Label1.Text = "Server Settings successfully configured. (Exiting..)"
                    frmLogin.Show()
                    Splash.Show()
                    Me.Close()
                Else
                    Label1.Text = "Something's wrong while saving..."
                End If
            End If
        End If
    End Sub

    Private Sub txtDBname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDBname.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtDBname_Enter(sender As Object, e As EventArgs) Handles txtDBname.Enter
        ListDB()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class