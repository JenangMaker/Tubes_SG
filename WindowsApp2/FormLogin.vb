Imports System.Data.SqlClient
Public Class FormLogin
    Private Sub TextBox1_KeypPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data Login belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New SqlCommand("select * from TBL_ADMIN where KodeAdmin='" & TextBox1.Text & "' and PasswordAdmin='" & TextBox2.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                Me.Close()
                Call Terbuka()
            Else
                MsgBox("Kode Admin atau Password salah")
            End If
        End If
    End Sub

    Private Sub TextBox2_KeypPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then Button1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Sub Terbuka()
        Form1.LoginToolStripMenuItem.Enabled = False
        Form1.LogoutToolStripMenuItem.Enabled = True
        Form1.MasterToolStripMenuItem.Enabled = True
        Form1.TransaksiToolStripMenuItem.Enabled = True
    End Sub

    Private Sub FormLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBox1.Focus()
    End Sub

    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.MaxLength = 6
        TextBox2.PasswordChar = "*"
    End Sub
End Class