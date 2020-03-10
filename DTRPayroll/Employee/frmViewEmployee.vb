Imports MySql.Data.MySqlClient
Public Class frmViewEmployee

    Dim byFilter As String

    Sub loadEmployee()
        Dim dsEmployee As New DataSet
        Dim bSource As New BindingSource
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tblemployee.DOB,tblemployee.Gender,tblemployee.CivilStatus,tbldesignation.DeptTitle As Department, " +
                                  "tbldesignation.Position,tblrates.Rate " +
                                  "FROM tblemployee " +
                                  "INNER JOIN tbldesignation ON tblemployee.EmployeeID = tbldesignation.EmployeeID " +
                                  "INNER JOIN tblrates ON tblemployee.EmployeeID = tblrates.EmployeeID WHERE tbldesignation.Status = 'ACTIVE' "
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsEmployee)
                bSource.DataSource = dsEmployee.Tables(0)
                DataGridView1.DataSource = bSource
            End Using
        End Using
        DataGridView1.ClearSelection()
    End Sub

    Private Sub frmViewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadEmployee()
        If accType = "ADMIN" Then
            CreateAccountToolStripMenuItem.Visible = True
        Else
            CreateAccountToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        If ComboBox1.SelectedIndex = 1 Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "SELECT CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                      "tblemployee.DOB,tblemployee.Gender,tblemployee.CivilStatus,tbldesignation.DeptTitle As Department, " +
                                      "tbldesignation.Position,tblrates.Rate " +
                                      "FROM tblemployee " +
                                      "INNER JOIN tbldesignation ON tblemployee.EmployeeID = tbldesignation.EmployeeID " +
                                      "INNER JOIN tblrates ON tblemployee.EmployeeID = tblrates.EmployeeID " +
                                      "WHERE tblemployee.Lastname LIKE @actualFilter"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    Dim dsEmployee As New DataSet
                    Dim bSource As New BindingSource
                    Dim sqlda As New MySqlDataAdapter
                    sqlcmd.Parameters.AddWithValue("@actualFilter", txtFilter.Text + "%")
                    sqlda.SelectCommand = sqlcmd
                    sqlda.Fill(dsEmployee)
                    bSource.DataSource = dsEmployee.Tables(0)
                    DataGridView1.DataSource = bSource
                End Using
            End Using
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "SELECT CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                      "tblemployee.DOB,tblemployee.Gender,tblemployee.CivilStatus,tbldesignation.DeptTitle As Department, " +
                                      "tbldesignation.Position,tblrates.Rate " +
                                      "FROM tblemployee " +
                                      "INNER JOIN tbldesignation ON tblemployee.EmployeeID = tbldesignation.EmployeeID " +
                                      "INNER JOIN tblrates ON tblemployee.EmployeeID = tblrates.EmployeeID " +
                                      "WHERE tblemployee.EmployeeID LIKE @actualFilter"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    Dim dsEmployee As New DataSet
                    Dim bSource As New BindingSource
                    Dim sqlda As New MySqlDataAdapter
                    sqlcmd.Parameters.AddWithValue("@actualFilter", txtFilter.Text + "%")
                    sqlda.SelectCommand = sqlcmd
                    sqlda.Fill(dsEmployee)
                    bSource.DataSource = dsEmployee.Tables(0)
                    DataGridView1.DataSource = bSource
                End Using
            End Using
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "SELECT CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                      "tblemployee.DOB,tblemployee.Gender,tblemployee.CivilStatus,tbldesignation.DeptTitle As Department, " +
                                      "tbldesignation.Position,tblrates.Rate " +
                                      "FROM tblemployee " +
                                      "INNER JOIN tbldesignation ON tblemployee.EmployeeID = tbldesignation.EmployeeID " +
                                      "INNER JOIN tblrates ON tblemployee.EmployeeID = tblrates.EmployeeID " +
                                      "WHERE tbldesignation.DeptTitle LIKE @actualFilter"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    Dim dsEmployee As New DataSet
                    Dim bSource As New BindingSource
                    Dim sqlda As New MySqlDataAdapter
                    sqlcmd.Parameters.AddWithValue("@actualFilter", txtFilter.Text + "%")
                    sqlda.SelectCommand = sqlcmd
                    sqlda.Fill(dsEmployee)
                    bSource.DataSource = dsEmployee.Tables(0)
                    DataGridView1.DataSource = bSource
                End Using
            End Using
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            Call Me.loadEmployee()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            byFilter = "EmployeeID"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            byFilter = "DeptTitle"
        Else
            byFilter = ComboBox1.Text
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(DataGridView1, e.Location)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If DataGridView1.SelectedRows.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MessageBox.Show("Are you sure want to delete this user information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "DELETE FROM tblemployee WHERE EmployeeID = @EmpID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)
                    sqlcmd.Parameters.AddWithValue("@EmpID", DataGridView1.SelectedRows.Item(0).Cells(0).Value)
                    sqlcmd.ExecuteNonQuery()
                End Using
            End Using
            Using sqlcon = New MySqlConnection(conString)
                sqlcon.Open()
                Dim query As String = "DELETE tbluser,designation, FROM tbluser WHERE EmployeeID = @EmpID"
                Using sqlcmd = New MySqlCommand(query, sqlcon)

                End Using
            End Using
        End If
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.SelectedRows.Count <> 0 Then
            Call Functions.loadEmployeeFullInfo(DataGridView1.SelectedRows.Item(0).Cells(0).Value)
            'frmEmployee.loadEmployeeFullInfo(DataGridView1.SelectedRows.Item(0).Cells(0).Value)
            frmEmployee.Show()
            Me.Close()
        End If
    End Sub

    Private Sub CreateAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAccountToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            empID = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            frmNewUser1.ShowDialog()
        End If
    End Sub
End Class