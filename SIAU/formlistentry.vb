Public Class formlistentry
    Private Sub formlistentry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        entrytampil()
    End Sub
    Sub entrytampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select id_pinjam,id_alat,id_operator,qty, tgl_pinjam,durasi,ket from pinjam_kembali where validasi='" & "submit" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        DataGridview1.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.DataGridview1.Columns(0).HeaderText = "ID"
        Me.DataGridview1.Columns(1).HeaderText = "ID Alat"
        Me.DataGridview1.Columns(2).HeaderText = "ID Pegawai"
        Me.DataGridview1.Columns(3).HeaderText = "Qty"
        Me.DataGridview1.Columns(4).HeaderText = "Tanggal Pinjam"
        Me.DataGridview1.Columns(5).HeaderText = "Durasi"
        Me.DataGridview1.Columns(6).HeaderText = "Keterangan"
    End Sub
    Private Sub peminjamandgvpegawai_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridview1.CellClick
        Try
            lblid.Text = ""
            Dim i As Integer = DataGridview1.CurrentRow.Index
            lblid.Text = DataGridview1.Item(0, i).Value

        Catch ex As Exception
            lblid.Text = ""
        End Try
    End Sub

    Private Sub peminjamanbtnentry_Click(sender As Object, e As EventArgs) Handles peminjamanbtnentry.Click
        If lblid.Text = "" Then
            MsgBox("Pilih terlebih dahulu data submit yang ingin dicancel", MsgBoxStyle.Exclamation)
        Else
            Try
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("delete from pinjam_kembali where id_pinjam='" & lblid.Text & "'", con)
                cmd.ExecuteNonQuery()
                entrytampil()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
End Class