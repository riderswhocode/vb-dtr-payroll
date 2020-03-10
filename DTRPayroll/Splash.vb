Public Class Splash

    Dim _str As String
    Dim _count As Integer
    Dim _exitTimer As Integer

    Sub checkConfig()
        If checkConnection() Then
            _str = "Connecting to Database: OK!"
            _count = 1
            Timer1.Enabled = True
        Else
            Label3.Text = "Connecting to Database: ERROR!"
            _count = 1
            frmDBSettings.Show()
            Me.Close()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label3.Text.Length = _str.Length Then
            Timer1.Enabled = False
            _exitTimer = 1
            Timer2.Enabled = True
            Exit Sub
        End If

        Label3.Text = _str.Substring(0, _count)
        _count += 1

    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = ""
        Me.checkConfig()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If _exitTimer = 2 Then
            Timer2.Enabled = False
            frmLogin.Show()
            Me.Close()
        Else
            _exitTimer += 1
        End If
    End Sub

    
End Class
