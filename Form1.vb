Imports System.Data.OleDb
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LDRRMA\Desktop\Database.mdb")
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [tblUser] WHERE [username] = '" & txtUsername.Text & "' and [password] = '" & txtPassword.Text & "'", conn)
        'Dim da As New OleDbDataAdapter(cmd)

        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)



        If dt.Rows.Count = 1 Then
            Main.Show()
            Me.Hide()
            Main.lblDisplayUser.Text = "Welcome Josh"
        Else
            MsgBox("The username and password is Incorrect!")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class
