Imports MySql.Data.MySqlClient
Public Class MainForm

    Dim ChildForm As New Form


    Sub test()
        Using sqlcon As New MySqlConnection(conString)
            statusConnection.Text = "Connection: " & sqlcon.State
            sqlcon.Open()
            statusConnection.Text = "Connection: " & sqlcon.State.ToString
        End Using

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Functions.setFormsize(Me)
        Call Functions.checkConnection()
        Call Me.test()
        If accType = "ADMIN" Then
            ADDUSERToolStripMenuItem.Visible = True
        Else
            ADDUSERToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub NEWEMPLOYEEToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NEWEMPLOYEEToolStripMenuItem1.Click
        'If ChildForm.Visible Then
        '    ChildForm.Close()
        '    ChildForm = New frmEmployee
        '    ChildForm.MdiParent = Me
        '    ChildForm.Show()
        'Else
        '    ChildForm = New frmEmployee
        '    ChildForm.MdiParent = Me
        '    ChildForm.Show()
        'End If
        frmEmployee.ShowDialog()
    End Sub

    Private Sub SERVERSETTINGSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SERVERSETTINGSToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmDBSettings
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmDBSettings
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub
    Private Sub ADDToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem3.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmDepartment
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmDepartment
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub
    Private Sub VIEWEMPLOYEEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWEMPLOYEEToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmViewEmployee
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmViewEmployee
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub

    Private Sub VIEWUSERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VIEWUSERToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmViewUsers
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmViewUsers
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub

    Private Sub LEAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LEAVEToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmLeave
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmLeave
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub

    Private Sub PASSSLIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PASSSLIPToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmPass
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmPass
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub

    Private Sub RATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RATEToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmRate
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmRate
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub

    Private Sub DEDUCTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DEDUCTIONToolStripMenuItem.Click
        If ChildForm.Visible Then
            ChildForm.Close()
            ChildForm = New frmDeduction
            ChildForm.MdiParent = Me
            ChildForm.Show()
        Else
            ChildForm = New frmDeduction
            ChildForm.MdiParent = Me
            ChildForm.Show()
        End If
    End Sub
End Class