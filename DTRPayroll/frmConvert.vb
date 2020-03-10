Public Class frmConvert

    Const value As Double = 0.45

    'Private Sub frmConvert_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '  frmEmployee.txtHeight.Text = Functions.convertHeight(txtFeet.Text, txtInch.Text)
    '  frmEmployee.txtWeight.Text = Functions.convertWeight(txtPounds.Text)
    'End Sub

    Private Sub btnHeight_Click(sender As Object, e As EventArgs) Handles btnHeight.Click
        txtCm.Text = Functions.convertHeight(txtFeet.Text, txtInch.Text)

    End Sub

    Private Sub btnWeight_Click(sender As Object, e As EventArgs) Handles btnWeight.Click
        txtKg.Text = Functions.convertWeight(txtPounds.Text)

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        frmEmployee.txtHeight.Text = Me.txtCm.Text
        frmEmployee.txtWeight.Text = Me.txtKg.Text
        ' Me.Close()
    End Sub
End Class