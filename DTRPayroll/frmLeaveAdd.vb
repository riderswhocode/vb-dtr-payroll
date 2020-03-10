Imports MySql.Data.MySqlClient
Public Class frmLeaveAdd

    Public saveFlag As Boolean

    Sub autoSuggest()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT EmployeeID FROM tblemployee"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim ds As New DataSet
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(ds, "List")

                Dim col As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    col.Add(ds.Tables(0).Rows(i)("EmployeeID").ToString)
                Next
                txtEmployeeID.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtEmployeeID.AutoCompleteCustomSource = col
                txtEmployeeID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
        End Using
    End Sub

    Private Sub frmLeaveAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.autoSuggest()
        If saveFlag Then
            txtEmployeeID.Enabled = True
        Else
            txtEmployeeID.Enabled = False
        End If
    End Sub

   
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtLeaveType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLeaveType.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtEmployeeID.Text <> "" And txtLeaveType.Text <> "" Then
            If saveFlag Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "INSERT INTO tblleaves(EmployeeID,LeaveType,StartDate,EndDate,DateApplied,Signatory,Status) " +
                                          "VALUES(@EmpID,@Type,@dateFrom,@dateTo,@dateApplied,@Signatory,@status)"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text)
                        sqlcmd.Parameters.AddWithValue("@Type", txtLeaveType.Text)
                        sqlcmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@dateTo", dateTo.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@dateApplied", dateApplied.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@Signatory", accType)
                        sqlcmd.Parameters.AddWithValue("@status", "PENDING")
                        Dim x As Integer = sqlcmd.ExecuteNonQuery()
                        If x > 0 Then
                            MsgBox("Request for leave is added, the ADMINISTRATOR may accept its application")
                            Dim ChildForm As New frmLeave
                            ChildForm.MdiParent = MainForm
                            ChildForm.Show()
                            Me.Close()
                        Else
                            MsgBox("Error", MsgBoxStyle.Critical)
                        End If
                    End Using
                End Using
            Else
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tblleaves SET EmployeeID = @EmpID, LeaveType = @Type, StartDate = @dateFrom, " +
                                          "EndDate = @dateTo, DateApplied = @dateApplied WHERE LeaveID = @LeaveID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text)
                        sqlcmd.Parameters.AddWithValue("@Type", txtLeaveType.Text)
                        sqlcmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@dateTo", dateTo.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@dateApplied", dateApplied.Value.ToShortDateString))
                        sqlcmd.Parameters.AddWithValue("@LeaveID", Functions._leaveID)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Request for leave has been updated, the ADMINISTRATOR may accept its application")
                            Dim ChildForm As New frmLeave
                            ChildForm.MdiParent = MainForm
                            ChildForm.Show()
                            Me.Close()
                        End If
                    End Using
                End Using
            End If
        Else
            MsgBox("Required all fields")
        End If
    End Sub

End Class