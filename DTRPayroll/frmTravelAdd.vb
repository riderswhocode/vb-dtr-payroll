Imports MySql.Data.MySqlClient
Public Class frmTravelAdd

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtEmployeeID.Text <> "" And txtDestination.Text <> "" Then
            If saveFlag Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "INSERT INTO tbltravelorder(EmployeeID,Destination,DeptDate,ArDate,ApplicationDate,Status) " +
                                          "VALUES(@EmpID,@Destination,@DeptDate,@ArDate,@ApplicationDate,@Status)"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text)
                        sqlcmd.Parameters.AddWithValue("@Destination", txtDestination.Text)
                        sqlcmd.Parameters.AddWithValue("@DeptDate", dateFrom.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@ArDate", dateTo.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@ApplicationDate", dateApplied.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@Status", "PENDING")
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x = 1 Then
                            MsgBox("Application for a Travel Order has been added.")
                        Else
                            MsgBox("Error saving", MsgBoxStyle.Critical)
                        End If
                    End Using
                End Using
            Else
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "UPDATE tbltravelorder SET EmployeeID = @EmpID, Destination = @Dest, " +
                                          "DeptDate = @DeptDate, ArDate = @ArDate, ApplicationDate = @DateApplied " +
                                          "WHERE TravelID = @TravelID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text)
                        sqlcmd.Parameters.AddWithValue("@Dest", txtDestination.Text)
                        sqlcmd.Parameters.AddWithValue("@DeptDate", dateFrom.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@ArDate", dateTo.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@DateApplied", dateApplied.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@TravelID", Functions._travelID)
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x > 0 Then
                            MsgBox("Request for travel order has been updated.")
                            Dim ChildForm As New frmLeave
                            ChildForm.MdiParent = MainForm
                            ChildForm.Show()
                            Me.Close()
                        End If
                    End Using
                End Using
            End If
        Else
            MsgBox("Employee ID and Destination should not be leave empty")
        End If
    End Sub

    Private Sub frmTravelAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class