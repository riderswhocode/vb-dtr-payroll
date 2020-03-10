Imports MySql.Data.MySqlClient
Public Class frmDeduction

    Sub loadDeduction()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tblrates.Rate, tblsss.SSS, tblphilhealth.PHILHEALTH, tblpagibig.PAGIBIG FROM " +
                                  "tblemployee, tblrates, tblsss, tblphilhealth, tblpagibig"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsDeduction As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsDeduction)
                bSource.DataSource = dsDeduction.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
    End Sub

    Private Sub frmDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadDeduction()
    End Sub

    Private Sub btnCA_Click(sender As Object, e As EventArgs) Handles btnCA.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            With frmDeductionAdd
                .txtEmpID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtName.Text = DataGridView1.Rows(0).Cells("Fullname").Value
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "SELECT tblsss.SSS, tblphilhealth.PHILHEALTH, tblpagibig.PAGIBIG " +
                                          "FROM tblsss, tblgsis, tblphilhealth, tblpagibig WHERE tblsss.EmployeeID = @ID AND " +
                                          "tblphilhealth.EmployeeID = @ID AND tblpagibig.EmployeeID = @ID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@ID", DataGridView1.Rows(0).Cells("EmployeeID").Value)
                        Using sqldr = sqlcmd.ExecuteReader
                            While sqldr.Read
                                If sqldr.HasRows Then
                                    .txtsss1.Text = sqldr("SSS")
                                    .txtphilhealth1.Text = sqldr("PHILHEALTH")
                                    .txtpagibig1.Text = sqldr("PAGIBIG")
                                End If
                            End While
                        End Using
                    End Using
                End Using
                .ShowDialog()
                Me.Close()
            End With
        End If
        
    End Sub
End Class