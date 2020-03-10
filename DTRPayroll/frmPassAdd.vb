Imports MySql.Data.MySqlClient
Public Class frmPassAdd

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
                txtEmpID.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtEmpID.AutoCompleteCustomSource = col
                txtEmpID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtEmpID.Text <> "" And txtDestination.Text <> "" And txtPurpose.Text <> "" Then
            If saveFlag Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "INSERT INTO tblpass(EmployeeID,DeptTime,ArTime,Destination,Purpose,DateApplied,Status) " +
                                          "VALUES(@EmpID,@DeptTime,@ArTime,@Destination,@Purpose,@DateApplied,@Status) "
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                        sqlcmd.Parameters.AddWithValue("@DeptTime", deptTime.Value.ToShortTimeString)
                        sqlcmd.Parameters.AddWithValue("@ArTime", returnTime.Value.ToShortTimeString)
                        sqlcmd.Parameters.AddWithValue("@Destination", txtDestination.Text)
                        sqlcmd.Parameters.AddWithValue("@Purpose", txtPurpose.Text)
                        sqlcmd.Parameters.AddWithValue("@DateApplied", dateApplied.Value.ToShortDateString)
                        sqlcmd.Parameters.AddWithValue("@Status", "PENDING")
                        Dim x As Integer = sqlcmd.ExecuteNonQuery
                        If x = 1 Then
                            MsgBox("Request for pass slip has been added.")
                            Dim ChildForm As New frmPass
                            ChildForm.MdiParent = MainForm
                            ChildForm.Show()
                            Me.Close()
                        Else
                            MsgBox("Error", MsgBoxStyle.Critical)
                        End If
                    End Using
                End Using
            Else
                If txtEmpID.Text <> "" And txtDestination.Text <> "" And txtPurpose.Text <> "" Then
                    Using sqlcon = New MySqlConnection(conString)
                        sqlcon.Open()
                        Dim query As String = "UPDATE tblpass SET EmployeeID = @EmpID, DeptTime = @DeptTime, ArTime = @ArTime, " +
                                              "Destination = @Destination, Purpose = @Purpose, DateApplied = @DateApplied WHERE PassID = @PassID"
                        Using sqlcmd = New MySqlCommand(query, sqlcon)
                            sqlcmd.Parameters.AddWithValue("@EmpID", txtEmpID.Text)
                            sqlcmd.Parameters.AddWithValue("@DeptTime", deptTime.Value.ToShortTimeString)
                            sqlcmd.Parameters.AddWithValue("@ArTime", returnTime.Value.ToShortTimeString)
                            sqlcmd.Parameters.AddWithValue("@Destination", txtDestination.Text)
                            sqlcmd.Parameters.AddWithValue("@Purpose", txtPurpose.Text)
                            sqlcmd.Parameters.AddWithValue("@DateApplied", dateApplied.Value.ToShortDateString)
                            sqlcmd.Parameters.AddWithValue("@PassID", Functions._passID)
                            Dim x As Integer = sqlcmd.ExecuteNonQuery
                            If x > 0 Then
                                MsgBox("Application for pass slip has been updated")
                            Else
                                MsgBox("Pass slip application encountered an error")
                            End If
                        End Using
                    End Using
                End If
            End If
        Else
            MsgBox("Required all fields", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtEmpID_Leave(sender As Object, e As EventArgs) Handles txtEmpID.Leave
        If txtEmpID.Text <> "" Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "SELECT CONCAT(Lastname, ', ', Firstname, ' ', Middlename) As Fullname FROM tblEmployee WHERE EmployeeID = '" & txtEmpID.Text & "'"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    Using sqldr = sqlcmd.ExecuteReader
                        sqldr.Read()
                        If sqldr.HasRows Then
                            txtName.Text = sqldr("Fullname")
                        Else
                            txtName.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

End Class