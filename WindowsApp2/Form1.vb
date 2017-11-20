Public Class Form1
    Sub Terkunci()
        LoginToolStripMenuItem.Enabled = True
        LogoutToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem.Enabled = False
        TransaksiToolStripMenuItem.Enabled = False
    End Sub
    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub MasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterToolStripMenuItem.Click

    End Sub

    Private Sub TransaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem.Click

    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UtilityToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        FormLogin.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Terkunci()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim Pilih = MessageBox.Show("Logout", "Yakin, mau logout??", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Pilih = Windows.Forms.DialogResult.Yes Then
            Call Terkunci()
        End If
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        FormMasterAdmin.ShowDialog()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem.Click
        FormMahasiswa.ShowDialog()
    End Sub
End Class
