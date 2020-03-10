Imports MySql.Data.MySqlClient
Public Class frmRate

    Sub loadRates()
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                  "tbldesignation.Position,tbldesignation.DeptTitle, tblrates.Rate, tblrates.AddRate FROM tblemployee, tbldesignation, tblrates"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                Dim dsRate As New DataSet
                Dim bSource As New BindingSource
                Dim sqlda As New MySqlDataAdapter
                sqlda.SelectCommand = sqlcmd
                sqlda.Fill(dsRate)
                bSource.DataSource = dsRate.Tables(0)
                DataGridView1.DataSource = bSource
            End Using

            For i As Integer = 0 To DataGridView1.RowCount - 1
                Dim baseRate As Double = 0
                Dim addRate As Double = 0
                Dim totalRate As Double = 0
                baseRate = DataGridView1.Rows(i).Cells("Rate").Value
                addRate = DataGridView1.Rows(i).Cells("AddRate").Value
                totalRate = baseRate + addRate
                DataGridView1.Rows(i).Cells("TotalRate").Value = totalRate
            Next

        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Me.loadRates()
    End Sub

    Private Sub txtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFilter.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text <> "" Then
            If txtFilter.SelectedIndex = 1 Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                          "tbldesignation.Position,tbldesignation.DeptTitle, tblrates.Rate, tblrates.AddRate FROM tblemployee, tbldesignation, tblrates " +
                                          "WHERE tblemployee.EmployeeID = @ID AND tbldesignation.EmployeeID = @ID AND tblrates.EmployeeID = @ID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@ID", txtSearch.Text)
                        Dim dsRate As New DataSet
                        Dim bSource As New BindingSource
                        Dim sqlda As New MySqlDataAdapter
                        sqlda.SelectCommand = sqlcmd
                        sqlda.Fill(dsRate)
                        bSource.DataSource = dsRate.Tables(0)
                        DataGridView1.DataSource = bSource
                    End Using

                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        Dim baseRate As Double = 0
                        Dim addRate As Double = 0
                        Dim totalRate As Double = 0
                        baseRate = DataGridView1.Rows(i).Cells("Rate").Value
                        addRate = DataGridView1.Rows(i).Cells("AddRate").Value
                        totalRate = baseRate + addRate
                        DataGridView1.Rows(i).Cells("TotalRate").Value = totalRate
                    Next
                End Using
            ElseIf txtFilter.SelectedIndex = 2 Then
                Using sqlcon = New MySqlConnection(conString)
                    sqlcon.Open()
                    Dim query As String = "SELECT tblemployee.EmployeeID, CONCAT(tblemployee.Lastname, ', ', tblemployee.Firstname, ' ', tblemployee.Middlename) As Fullname, " +
                                          "tbldesignation.Position,tbldesignation.DeptTitle, tblrates.Rate, tblrates.AddRate FROM tblemployee, tbldesignation, tblrates " +
                                          "WHERE tblemployee.Lastname = @Lastname AND tbldesignation.EmployeeID = tblemployee.EmployeeID AND tblrates.EmployeeID = tblemployee.EmployeeID"
                    Using sqlcmd = New MySqlCommand(query, sqlcon)
                        sqlcmd.Parameters.AddWithValue("@Lastname", txtSearch.Text)
                        Dim dsRate As New DataSet
                        Dim bSource As New BindingSource
                        Dim sqlda As New MySqlDataAdapter
                        sqlda.SelectCommand = sqlcmd
                        sqlda.Fill(dsRate)
                        bSource.DataSource = dsRate.Tables(0)
                        DataGridView1.DataSource = bSource
                    End Using

                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        Dim baseRate As Double = 0
                        Dim addRate As Double = 0
                        Dim totalRate As Double = 0
                        baseRate = DataGridView1.Rows(i).Cells("Rate").Value
                        addRate = DataGridView1.Rows(i).Cells("AddRate").Value
                        totalRate = baseRate + addRate
                        DataGridView1.Rows(i).Cells("TotalRate").Value = totalRate
                    Next
                End Using
            End If
        Else
            Call Me.loadRates()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If DataGridView1.SelectedRows.Count <> 0 Then
            Functions._rateID = DataGridView1.Rows(0).Cells("RateID").Value
            With frmRateAdd
                .txtEmpID.Text = DataGridView1.Rows(0).Cells("EmployeeID").Value
                .txtName.Text = DataGridView1.Rows(0).Cells("Fullname").Value
                .txtBase.Text = DataGridView1.Rows(0).Cells("Rate").Value
                .ShowDialog()
                Me.Close()
            End With
        End If
    End Sub
End Class