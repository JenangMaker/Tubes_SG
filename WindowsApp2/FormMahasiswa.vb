Imports System.Data.SqlClient
Public Class FormMahasiswa
    Sub TampilGrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select Nama as Name, Nim as NIM, Kelas as Kelass, TmpLhr as tmpt, TglLhr as tgl, Alamat as Adress , Agama as religion, No_Hp as nohp, Email as imel From TBL_DATA_MHS_2", CONN)
        DS = New DataSet
        DA.Fill(DS, "TBL_DATA_MHS_2")
        DataGridView1.DataSource = DS.Tables("TBL_DATA_MHS_2")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub txtKelas_TextChanged(sender As Object, e As EventArgs) Handles txtKelas.TextChanged

    End Sub

    Private Sub lblKelas_Click(sender As Object, e As EventArgs) Handles lblKelas.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtNIM_TextChanged(sender As Object, e As EventArgs) Handles txtNIM.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from TBL_DATA_MHS_2 where Nama like '%" & txtCari.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from TBL_DATA_MHS_2 where Nama like '%" & txtCari.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "ketemu")
            DataGridView1.DataSource = DS.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex > DataGridView1.Rows.Count() OrElse e.RowIndex < 0 OrElse DataGridView1.Rows(e.RowIndex) Is Nothing OrElse DataGridView1.Rows(e.RowIndex).DataBoundItem Is Nothing Then
            e.Value = Nothing
        End If
    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        If txtNama.Text = "" Or txtNIM.Text = "" Or txtKelas.Text = "" Or txtTmptLhr.Text = "" Or txtHari.Text = "" Or txtBulan.Text = "" Or txtTahun.Text = "" Or txtAlamat.Text = "" Or txtAgama.Text = "" Or txtNo_hp.Text = "" Or txtEmail.Text = "" Then
            MsgBox("Data belum lengkap, mohon diisi semua")
            Exit Sub
        Else
            Call Koneksi()
            Dim tanggal As String = txtTahun.Text & "-" & txtBulan.Text & "-" & txtHari.Text
            Dim simpan As String = "insert into TBL_DATA_MHS_2 values ('" & txtNama.Text & "','" & txtNIM.Text & "','" & txtKelas.Text & "','" & txtTmptLhr.Text & "','" & tanggal & "','" & txtAlamat.Text & "','" & txtAgama.Text & "','" & txtNo_hp.Text & "','" & txtEmail.Text & "')"
            CMD = New SqlCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub FormMahasiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilGrid()
        txtNama.Focus()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Call Koneksi()
        Dim tanggal As String
        Dim i As Integer
        Dim arraytangggal(0 To 2) As String
        i = DataGridView1.CurrentRow.Index
        CMD = New SqlCommand("Select * from TBL_DATA_MHS_2 where Nama='" & DataGridView1.Item(0, i).Value & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            txtNama.Focus()
        Else
            txtNama.Text = RD.Item("Nama")
            txtNIM.Text = RD.Item("Nim")
            txtKelas.Text = RD.Item("Kelas")
            txtTmptLhr.Text = RD.Item("TmpLhr")
            tanggal = RD.Item("TglLhr")
            arraytangggal = Split(tanggal, "-")
            txtHari.Text = arraytangggal(2)
            txtBulan.Text = arraytangggal(1)
            txtTahun.Text = arraytangggal(0)
            txtAlamat.Text = RD.Item("Alamat")
            txtAgama.Text = RD.Item("No_Hp")
            txtEmail.Text = RD.Item("Email")
            txtNama.Focus()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtNama.Text = "" Or txtNIM.Text = "" Or txtKelas.Text = "" Or txtTmptLhr.Text = "" Or txtHari.Text = "" Or txtBulan.Text = "" Or txtTahun.Text = "" Or txtAlamat.Text = "" Or txtAgama.Text = "" Or txtNo_hp.Text = "" Or txtEmail.Text = "" Then
            MsgBox("Data belum lengkap, mohon diisi semua ya bosq!!")
            Exit Sub
        Else
            Call Koneksi()
            Dim tanggal As String = txtTahun.Text & "-" & txtBulan.Text & "-" & txtHari.Text
            Dim edit As String = "update TBL_DATA_MHS_2 set Nim='" & txtNIM.Text & "',Kelas='" & txtKelas.Text & "',TmpLhr='" & txtTmptLhr.Text & "',TglLhr='" & tanggal & "',Alamat='" & txtAlamat.Text & "',Agama='" & txtAgama.Text & "',No_Hp='" & txtNo_hp.Text & "',Email='" & txtEmail.Text & "' where Nama='" & txtNama.Text & "'"
            CMD = New SqlCommand(edit, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Edit", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtNama.Text = "" Or txtNIM.Text = "" Or txtKelas.Text = "" Or txtTmptLhr.Text = "" Or txtHari.Text = "" Or txtBulan.Text = "" Or txtTahun.Text = "" Or txtAlamat.Text = "" Or txtAgama.Text = "" Or txtNo_hp.Text = "" Or txtEmail.Text = "" Then
            MsgBox("Silahkan double klik data di bawah bosq!!")
            Exit Sub
        Else
            Call Koneksi()
            Dim hapus As String = "delete from TBL_DATA_MHS_2 where Nama='" & txtNama.Text & "'"
            CMD = New SqlCommand(hapus, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Hapus", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
End Class