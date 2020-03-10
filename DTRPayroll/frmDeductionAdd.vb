Imports MySql.Data.MySqlClient
Public Class frmDeductionAdd

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "UPDATE tblsss SET Deduction = @Deduction WHERE EmployeeID = @EmpID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@Deduction", txtSSS.Text)
                sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using

        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "UPDATE tblgsis SET Deduction = @Deduction WHERE EmployeeID = @EmpID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@Deduction", txtGSIS.Text)
                sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using

        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "UPDATE tblphilhealth SET Deduction = @Deduction WHERE EmployeeID = @EmpID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@Deduction", txtPHILHEALTH.Text)
                sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using

        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "UPDATE tblpagibig SET Deduction = @Deduction WHERE EmployeeID = @EmpID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@Deduction", txtPAGIBIG.Text)
                sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                sqlcmd.ExecuteNonQuery()
            End Using
        End Using

        MsgBox("Deduction has been added")
        Dim ChildForm As New frmDeduction
        ChildForm.MdiParent = MainForm
        ChildForm.Show()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim ChildForm As New frmDeduction
        ChildForm.MdiParent = MainForm
        ChildForm.Show()
        Me.Close()
    End Sub
End Class