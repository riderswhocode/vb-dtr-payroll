Imports MySql.Data.MySqlClient
Public Class frmViewUsers

    Sub loadUsers()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim bSource As New BindingSource
            Dim dsUser As New DataSet
            Dim query As String = "SELECT CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tblemployee.ContactNo, tbluser.UserID, tbluser.Username, tbluser.UserType, tbluser.LoginStatus, " +
                                  "tbluser.AccountStatus FROM tblemployee INNER JOIN tbluser ON tblemployee.EmployeeID = tbluser.EmployeeID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsUser)
                bSource.DataSource = dsUser.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
           
        End Using
    End Sub

    Private Sub frmViewUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadUsers()
        If accType = "ADMIN" Then
            ContextMenuStrip1.Enabled = True
        Else
            ContextMenuStrip1.Enabled = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
