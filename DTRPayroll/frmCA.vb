Imports MySql.Data.MySqlClient
Public Class frmCA

    Sub loadCA()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tbldesignation.DeptTitle, tbldesignation.Position, tblca.CaDate, tblca.Amount FROM " +
                                  "tblemployee, tbldesignation, tblca"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsCA As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsCA)
                bSource.DataSource = dsCA.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadCA()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text <> "" Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tbldesignation.DeptTitle, tbldesignation.Position, tblca.CaDate, tblca.Amount FROM " +
                                  "tblemployee, tbldesignation, tblca WHERE tblemployee.EmployeeID = @ID AND tbldesignation.EmployeeID = @ID AND tblca.EmployeeID = @ID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@ID", txtSearch.Text)
                    Dim dsCA As New DataSet
                    Dim bSource As New BindingSource
                    Dim sqlda As New MySqlDataAdapter
                    sqlda.SelectCommand = sqlcmd
                    sqlda.Fill(dsCA)
                    bSource.DataSource = dsCA.Tables(0)
                    DataGridView1.DataSource = bSource
                End Using
            End Using
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub

    Private Sub btnCA_Click(sender As Object, e As EventArgs) Handles btnCA.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            With frmCAAdd
                .txtEmpID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtName.Text = DataGridView1.Rows(0).Cells("Fullname").Value
                .ShowDialog()
            End With
            Me.Close()
        End If
    End Sub

   
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If DataGridView1.SelectedRows.Count <> 0 Then

        End If
    End Sub
End Class