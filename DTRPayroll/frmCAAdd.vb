Imports MySql.Data.MySqlClient
Public Class frmCAAdd

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        Functions.IntDouble(True, e)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtAmount.Text <> "" Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "INSERT INTO tblca(EmployeeID,CaDate,Amount) " +
                                      "VALUES(@EmpID, CURDATE(), @Amount)"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                    sqlcmd.Parameters.AddWithValue("@Amount", txtAmount.Text)
                    Dim x As Integer = sqlcmd.ExecuteNonQuery
                    If x > 0 Then
                        MsgBox("Cash advance added")
                        Dim ChildForm As New frmCA
                        ChildForm.MdiParent = MainForm
                        ChildForm.Show()
                        Me.Close()
                    Else
                        MsgBox("Error")
                        txtAmount.Focus()
                    End If
                End Using
            End Using
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim ChildForm As New frmCA
        ChildForm.MdiParent = MainForm
        ChildForm.Show()
        Me.Close()
    End Sub
End Class