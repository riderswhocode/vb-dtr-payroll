Imports MySql.Data.MySqlClient
Public Class frmPass

    Sub loadPasses()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tblpass.PassID, tblpass.Destination, tblpass.Purpose, tblpass.DeptTime, tblpass.ArTime, tblpass.DateApplied, " +
                                  "tblpass.Status FROM tblemployee, tblpass"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsPasses As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsPasses)
                bSource.DataSource = dsPasses.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
    End Sub

    Private Sub frmPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadPasses()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.Close()
        frmPassAdd.saveFlag = True
        frmPassAdd.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            Me.Close()
            Functions._passID = DataGridView1.Rows(0).Cells("PassID").Value
            With frmPassAdd
                .saveFlag = False
                .txtEmpID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtDestination.Text = DataGridView1.Rows(0).Cells("Destination").Value
                .txtPurpose.Text = DataGridView1.Rows(0).Cells("Purpose").Value
                .deptTime.Value = DataGridView1.Rows(0).Cells("DeptTime").Value
                .returnTime.Value = DataGridView1.Rows(0).Cells("ArTime").Value
                .dateApplied.Value = DataGridView1.Rows(0).Cells("DateApplied").Value
                .Show()
            End With
        End If
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblpass SET Status = 'APPROVED' WHERE PassID = @PassID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@PassID", DataGridView1.Rows(0).Cells("PassID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Pass slip has been approved")
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Pass slip has already been approved")
            Else
                MsgBox("Pass slip has already been denied")
            End If
        End If
    End Sub

    Private Sub btnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblpass SET Status = 'DISAPPROVED' WHERE PassID = @PassID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@PassID", DataGridView1.Rows(0).Cells("PassID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Pass slip has been disapproved")
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Pass slip has already been approved")
            Else
                MsgBox("Pass slip has already been denied")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Or DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblpass SET Status = 'CANCELLED' WHERE PassID = @PassID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@PassID", DataGridView1.Rows(0).Cells("PassID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Pass slip has been approved")
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "DISAPPROVED" Then
                MsgBox("Pass slip has already been disapproved")
            Else
                MsgBox("Pass slip has already been denied")
            End If
        End If
    End Sub
End Class