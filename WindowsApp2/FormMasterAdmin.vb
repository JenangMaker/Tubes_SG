Imports System.Data.SqlClient
Public Class FormMasterAdmin
    Sub TampilStatus()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("ADMIN")
        ComboBox1.Items.Add("USER")
        ComboBox1.SelectedItem = "ADMIN"
    End Sub
    Sub TampilGrid()
        Call Koneksi()
        DA = New SqlDataAdapter("select kodeAdmin as Kode, NamaAdmin as Nama, PasswordAdmin as Password, LevelAdmin as Level From TBL_ADMIN", CONN)
        DS = New DataSet
        DA.Fill(DS, "TBL_ADMIN")
        DataGridView1.DataSource = DS.Tables("TBL_ADMIN")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap, mohon diisi semua")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into TBL_ADMIN values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
            CMD = New SqlCommand(simpan, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex > DataGridView1.Rows.Count() OrElse e.RowIndex < 0 OrElse DataGridView1.Rows(e.RowIndex) Is Nothing OrElse DataGridView1.Rows(e.RowIndex).DataBoundItem Is Nothing Then
            e.Value = Nothing
        ElseIf e.ColumnIndex = 2 Then
            e.Value = "*****"
        End If
    End Sub

    Private Sub FormMasterAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call TampilStatus()
        Call TampilGrid()
        TextBox1.Focus()
        TextBox3.PasswordChar = "*"
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Call Koneksi()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CMD = New SqlCommand("Select * from TBL_ADMIN where KodeAdmin='" & DataGridView1.Item(0, i).Value & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            TextBox2.Focus()
        Else
            TextBox1.Text = RD.Item("KodeAdmin")
            TextBox2.Text = RD.Item("NamaAdmin")
            TextBox3.Text = RD.Item("PasswordAdmin")
            ComboBox1.Text = RD.Item("LevelAdmin")
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap, mohon diisi semua ya bosq!!")
            Exit Sub
        Else
            Call Koneksi()
            Dim edit As String = "update TBL_ADMIN set NamaAdmin='" & TextBox2.Text & "',PasswordAdmin='" & TextBox3.Text & "',LevelAdmin='" & ComboBox1.Text & "' where KodeAdmin='" & TextBox1.Text & "'"
            CMD = New SqlCommand(edit, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Edit", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Silahkan double klik data di bawah bosq!!")
            Exit Sub
        Else
            Call Koneksi()
            Dim hapus As String = "delete from TBL_ADMIN where KodeAdmin='" & TextBox1.Text & "'"
            CMD = New SqlCommand(hapus, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Hapus", MsgBoxStyle.Information, "Information")
            Call TampilGrid()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Call Koneksi()
        CMD = New SqlCommand("select * from TBL_ADMIN where NamaAdmin like '%" & TextBox4.Text & "%'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New SqlDataAdapter("select * from TBL_ADMIN where NamaAdmin like '%" & TextBox4.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS, "ketemu")
            DataGridView1.DataSource = DS.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class