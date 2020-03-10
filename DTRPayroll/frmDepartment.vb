Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class frmDepartment

    Dim id As Integer

    Function deptID() As Integer
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT DeptID FROM tbldepartment ORDER BY DeptID ASC LIMIT 1"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    While sqldr.Read
                        If sqldr.HasRows Then
                            id = CInt(sqldr("DeptID")) + 1
                        Else
                            id = 1
                        End If
                    End While
                End Using
            End Using
        End Using
        Return id
    End Function
    Sub loadDept()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT DeptID,DeptTitle FROM tbldepartment"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Using sqldr = sqlcmd.ExecuteReader
                    ListView1.Items.Clear()
                    While sqldr.Read
                        If sqldr.HasRows Then
                            With ListView1
                                .Items.Add(sqldr("DeptID"))
                                With .Items(.Items.Count - 1).SubItems
                                    .Add(sqldr("DeptTitle"))
                                End With
                            End With
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim department As String = Regex.Replace(txtDepartment.Text, "[^A-Za-z0-9\-/]", "")
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "INSERT IGNORE INTO tbldepartment(DeptID,DeptTitle) " +
                                  "VALUES(@DeptID,@DeptTitle)"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@DeptID", deptID)
                sqlcmd.Parameters.AddWithValue("@DeptTitle", department)
                Dim x As Integer = sqlcmd.ExecuteNonQuery
                If x = 1 Then
                    MsgBox("New Department has been added")
                    txtDepartment.Text = ""
                    Call Me.loadDept()
                Else
                    MsgBox("Error saving the new department")
                End If

            End Using
        End Using

    End Sub

    Private Sub frmDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadDept()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class