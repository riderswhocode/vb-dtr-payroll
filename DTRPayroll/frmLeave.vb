Imports MySql.Data.MySqlClient
Public Class frmLeave

    Sub loadLeave()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tbldesignation.Position, tblleaves.LeaveID, tblleaves.LeaveType, tblleaves.StartDate, tblleaves.EndDate, tblleaves.DateApplied, " +
                                  "tblleaves.Status FROM tblemployee, tbldesignation, tblleaves"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsLeave As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsLeave)
                bSource.DataSource = dsLeave.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadLeave()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.Close()
        frmLeaveAdd.saveFlag = True
        frmLeaveAdd.ShowDialog()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count <> 0 Then

            btnApprove.Enabled = True
            btnDisapprove.Enabled = True
        Else
            btnApprove.Enabled = True
            btnDisapprove.Enabled = True
        End If
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblleaves SET Status = 'APPROVED' WHERE LeaveID = @LeaveID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@LeaveID", DataGridView1.Rows(0).Cells("LeaveID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Leave has been approved")
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Leave has already been approved")
            Else
                MsgBox("Leave has already been denied")
            End If
        End If
    End Sub

    Private Sub btnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblleaves SET Status = 'DISAPPROVED' WHERE LeaveID = @LeaveID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@LeaveID", DataGridView1.Rows(0).Cells("LeaveID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Leave has been denied")
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Leave has already been approved")
            Else
                MsgBox("Leave has already been denied")
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            Me.Close()
            Functions._leaveID = DataGridView1.Rows(0).Cells("LeaveID").Value
            With frmLeaveAdd
                .saveFlag = False
                .txtEmployeeID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtLeaveType.Text = DataGridView1.Rows(0).Cells("LeaveType").Value
                .dateApplied.Value = DataGridView1.Rows(0).Cells("DateApplied").Value
                .dateFrom.Value = DataGridView1.Rows(0).Cells("StartDate").Value
                .dateTo.Value = DataGridView1.Rows(0).Cells("EndDate").Value
                .Show()
            End With
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "UPDATE tblleaves SET Status = 'CANCELLED' WHERE LeaveID = @LeaveID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@LeaveID", DataGridView1.Rows(0).Cells("LeaveID").Value)
                    Dim x As Integer = sqlcmd.ExecuteNonQuery
                    If x > 0 Then
                        MsgBox("Leave application has been cancelled")
                    End If
                End Using
            End Using
        End If
    End Sub
End Class