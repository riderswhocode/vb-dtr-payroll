Imports MySql.Data.MySqlClient
Public Class frmRateAdd

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtAdd_Leave(sender As Object, e As EventArgs) Handles txtAdd.Leave
        txtTotal.Text = txtBase.Text + txtAdd.Text
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using sqlcon = New MySqlConnection(conString)
            sqlcon.Open()
            Dim query As String = "UPDATE tblrates SET AddRate = @newRate WHERE RateID = @RateID"
            Using sqlcmd = New MySqlCommand(query, sqlcon)
                sqlcmd.Parameters.AddWithValue("@newRate", txtAdd.Text)
                sqlcmd.Parameters.AddWithValue("@RateID", Functions._rateID)
                Dim x As Integer = sqlcmd.ExecuteNonQuery
                If x > 0 Then
                    MsgBox("Additional rate has been updated")
                    Dim ChildForm As New frmRate
                    ChildForm.MdiParent = MainForm
                    ChildForm.Show()
                    Me.Close()
                Else
                    MsgBox("Error saving the additional rate")
                End If
            End Using
        End Using
    End Sub

    Private Sub txtAdd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdd.KeyPress
        IntDouble(True, e)
    End Sub
End Class