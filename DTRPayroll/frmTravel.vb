Imports MySql.Data.MySqlClient
Public Class frmTravel

    Sub loadTravel()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tbltravelorder.TravelID, tbltravelorder.Destination, tbltravelorder.DeptDate, tbltravelorder.ArDate, tbltravelorder.ApplicationDate, " +
                                  "tbltravelorder.Status FROM tblemployee, tbltravelorder"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsTravel As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsTravel)
                bSource.DataSource = dsTravel.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.Close()
        frmTravelAdd.saveFlag = True
        frmTravelAdd.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            Me.Close()
            Functions._travelID = DataGridView1.Rows(0).Cells("TravelID").Value
            With frmTravelAdd
                .saveFlag = False
                .txtEmployeeID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtDestination.Text = DataGridView1.Rows(0).Cells("Destination").Value
                .dateFrom.Value = DataGridView1.Rows(0).Cells("DeptDate").Value
                .dateTo.Value = DataGridView1.Rows(0).Cells("ArDate").Value
                .dateApplied.Value = DataGridView1.Rows(0).Cells("ApplicationDate").Value
                .Show()
            End With
        End If
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tbltravelorder SET Status = 'APPROVED' WHERE TravelID = @TravelID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@TravelID", DataGridView1.Rows(0).Cells("TravelID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Travel order has been approved")
                            Call Me.loadTravel()
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Travel Order has already been approved")
            Else
                MsgBox("Travel Order has already been denied")
            End If
        End If
    End Sub

    Private Sub btnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tbltravelorder SET Status = 'DISAPPROVED' WHERE TravelID = @TravelID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@TravelID", DataGridView1.Rows(0).Cells("TravelID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Travel order has been denied")
                            Call Me.loadTravel()
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Travel Order has already been approved")
            Else
                MsgBox("Travel Order has already been denied")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            If DataGridView1.Rows(0).Cells("Status").Value = "PENDING" Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tbltravelorder SET Status = 'CANCELLED' WHERE TravelID = @TravelID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@TravelID", DataGridView1.Rows(0).Cells("TravelID").Value)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Travel order has been cancelled")
                            Call Me.loadTravel()
                        End If
                    End Using
                End Using
            ElseIf DataGridView1.Rows(0).Cells("Status").Value = "APPROVED" Then
                MsgBox("Travel Order has already been approved")
            Else
                MsgBox("Travel Order has already been cancelled")
            End If
        End If
    End Sub

    Private Sub frmTravel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadTravel()
    End Sub
End Class