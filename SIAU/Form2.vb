Imports CrystalDecisions.CrystalReports.Engine
Public Class Form2
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim CP As CreateParams
            CP = MyBase.CreateParams
            CP.ClassStyle = CP.ClassStyle Or &H200
            Return CP
        End Get
    End Property
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        navdodgeblue()
        Panel4.BackColor = Color.White
        Label1.ForeColor = Color.Black
        TabControl1.SelectedTab = Tabpeminjaman
        peminjaman_alat_tampil()
        peminjaman_pegawai_tampil()
    End Sub
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not e.CloseReason = CloseReason.WindowsShutDown Then
            e.Cancel = True
        End If
    End Sub
    'navigasi////////////////////////////////////////////////////////////////////////////////////

    Private Sub Label41_Click_1(sender As Object, e As EventArgs) Handles Label41.Click
        Me.Close()
        Me.Dispose()
        Form1.Show()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub
    Sub navdodgeblue()
        Panel4.BackColor = Color.SteelBlue
        Panel5.BackColor = Color.SteelBlue
        Panel6.BackColor = Color.SteelBlue
        Panel7.BackColor = Color.SteelBlue

        Panel9.BackColor = Color.SteelBlue
        Panel10.BackColor = Color.SteelBlue
        Panel11.BackColor = Color.SteelBlue
        Panel12.BackColor = Color.SteelBlue
        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
        Label3.ForeColor = Color.White
        Label4.ForeColor = Color.White

        Label6.ForeColor = Color.White
        Label7.ForeColor = Color.White
        Label8.ForeColor = Color.White
        Label9.ForeColor = Color.White
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        navdodgeblue()
        Panel4.BackColor = Color.White
        Label1.ForeColor = Color.Black
        TabControl1.SelectedTab = Tabpeminjaman
        peminjaman_alat_tampil()
        peminjaman_pegawai_tampil()
        Label5.Text = "UTC > Peminjaman"
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        navdodgeblue()
        Panel5.BackColor = Color.White
        Label2.ForeColor = Color.Black
        TabControl1.SelectedTab = tabrefused
        refuse_tampil()
        Label5.Text = "UTC > Refused"
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        navdodgeblue()
        Panel6.BackColor = Color.White
        Label3.ForeColor = Color.Black
        TabControl1.SelectedTab = tabcurrent
        current_tampil()
        Label5.Text = "UTC > Current Borrowing"
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        navdodgeblue()
        Panel7.BackColor = Color.White
        Label4.ForeColor = Color.Black
        TabControl1.SelectedTab = tabrekappeminjaman
        rekappinjam_tampil()
        Label5.Text = "UTC > Rekap Peminjaman"
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        navdodgeblue()
        Panel9.BackColor = Color.White
        Label6.ForeColor = Color.Black
        TabControl1.SelectedTab = tabdatalatukur
        alat_tampil()
        alatCariKode()
        Label5.Text = "UTC > Data Alat Ukur"
    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        navdodgeblue()
        Panel10.BackColor = Color.White
        Label7.ForeColor = Color.Black
        TabControl1.SelectedTab = tabdatateknisi
        pegawai_tampil()
        pegawaiCariKode()
        Label5.Text = "UTC > Data Pegawai"
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        navdodgeblue()
        Panel11.BackColor = Color.White
        Label8.ForeColor = Color.Black
        TabControl1.SelectedTab = tabdatauser
        user_tampil()
        usertxtnama.Focus()
        Label5.Text = "UTC > User"
    End Sub
    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        navdodgeblue()
        Panel12.BackColor = Color.White
        Label9.ForeColor = Color.Black
        TabControl1.SelectedTab = tablaporan
        Label5.Text = "UTC > Laporan"
    End Sub
    'end navigasi////////////////////////////////////////////////////////////////////////////////////







    'user////////////////////////////////////////////////////////////////////////////////////
    Sub user_bersih()
        usertxtid.Clear()
        usertxtnama.Clear()
        usertxtusername.Clear()
        usertxtpassword.Clear()
        usertxtrepassword.Clear()
        usertxtcari.Clear()
        usercbakses.Text = ""
    End Sub
    Sub user_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select id_user, nama_user, user,akses from admin order by id_user desc", con)
        dt = New DataSet
        ap.Fill(dt, "admin")
        userdgv.DataSource = dt.Tables("admin")
        con.Close()
        Me.userdgv.Columns(0).HeaderText = "ID"
        Me.userdgv.Columns(1).HeaderText = "Nama User"
        Me.userdgv.Columns(2).HeaderText = "Username"
        Me.userdgv.Columns(3).HeaderText = "Akses"
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles usertxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from admin where nama_user like '%" & usertxtcari.Text & "%' order by id_user desc", con)
        dt = New DataSet
        ap.Fill(dt, "admin")
        userdgv.DataSource = dt.Tables("admin")
        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles userbtnclear.Click
        user_tampil()
        user_bersih()
    End Sub

    Private Sub userdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles userdgv.CellClick
        Try
            user_bersih()
            Dim i As Integer = userdgv.CurrentRow.Index
            usertxtid.Text = userdgv.Item(0, i).Value
            usertxtnama.Text = userdgv.Item(1, i).Value
            usertxtusername.Text = userdgv.Item(2, i).Value
            usercbakses.Text = userdgv.Item(3, i).Value
        Catch ex As Exception
            user_bersih()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles userbtnsimpan.Click
        If usertxtpassword.Text <> usertxtrepassword.Text Then
            MsgBox("Password tidak sama, koreksi kembali", MsgBoxStyle.Exclamation)
        ElseIf usertxtnama.Text = "" Or usertxtusername.Text = "" Or usertxtpassword.Text = "" Or usertxtrepassword.Text = "" Or usercbakses.Text = "" Then
            MsgBox("Semua box harus terisi", MsgBoxStyle.Exclamation)
        ElseIf usertxtnama.TextLength < 5 Or usertxtusername.TextLength < 5 Or usertxtpassword.TextLength < 5 Or usertxtrepassword.TextLength < 5 Then
            MsgBox("Ingat!. jumlah karakter harus lebih dari 6 digit (Berlaku untuk semua Box isian)", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from admin where user='" & usertxtusername.Text & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                rd.Close()
                con.Close()
                MsgBox("Username tersebut sudah dipakai, silahkan cari yang lain", MsgBoxStyle.Exclamation)
            Else
                rd.Close()
                con.Close()
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("insert into admin (nama_user, user, pass, akses) values ('" & usertxtnama.Text & "','" & usertxtusername.Text & "','" & usertxtpassword.Text & "','" & usercbakses.Text & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()
                user_bersih()
                user_tampil()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles userbtnhapus.Click
        If usertxtid.Text = "" Then
            MsgBox("Pilih terlebih dahulu data user yang ingin dihapus", MsgBoxStyle.Exclamation)
        Else
            Try
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("delete from admin where id_user=" & usertxtid.Text & "", con)
                cmd.ExecuteNonQuery()
                user_bersih()
                user_tampil()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    'end user////////////////////////////////////////////////////////////////////////////////////






    'alat ukur////////////////////////////////////////////////////////////////////////////////////
    Sub alatCariKode()
        koneksi()
        On Error Resume Next
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from alat_ukur order by id_alat desc", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            strSementara = Mid(rd.Item("id_alat"), 2, 2)
            strIsi = Val(strSementara) + 1
            alattxtid.Text = "A" + Mid("0", 1, 2 - strIsi.Length) & strIsi
        Else
            alattxtid.Text = "A01"
        End If
        alattxtnama.Focus()
        rd.Close()
        con.Close()
    End Sub
    Sub alat_bersih()
        alattxtid.Clear()
        alattxtnama.Clear()
        alattxtstok.Clear()
        alatcbxsatuan.Text = "Set"
        alatcbxstatus.Text = "Baik"
        alatrtbket.Clear()
        alattxtcari.Clear()
    End Sub
    Sub alat_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from alat_ukur order by id_alat desc", con)
        dt = New DataSet
        ap.Fill(dt, "alat_ukur")
        alatdgv.DataSource = dt.Tables("alat_ukur")
        con.Close()
        Me.alatdgv.Columns(0).HeaderText = "ID"
        Me.alatdgv.Columns(1).HeaderText = "Nama Alat"
        Me.alatdgv.Columns(2).HeaderText = "Stok"
        Me.alatdgv.Columns(3).HeaderText = "Satuan"
        Me.alatdgv.Columns(4).HeaderText = "Pembaruan Terakhir"
        Me.alatdgv.Columns(5).HeaderText = "Kondisi"
        Me.alatdgv.Columns(6).HeaderText = "Keterangan"
    End Sub

    Private Sub alatbtnclear_Click(sender As Object, e As EventArgs) Handles alatbtnclear.Click
        alat_tampil()
        alat_bersih()
        alatCariKode()
    End Sub

    Private Sub alattxtcari_TextChanged(sender As Object, e As EventArgs) Handles alattxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from alat_ukur where uraian_alat like '%" & alattxtcari.Text & "%' order by id_alat desc", con)
        dt = New DataSet
        ap.Fill(dt, "alat_ukur")
        alatdgv.DataSource = dt.Tables("alat_ukur")
        con.Close()
    End Sub

    Private Sub DataGridView1asdasd_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles alatdgv.CellClick
        Try
            alat_bersih()
            Dim i As Integer = alatdgv.CurrentRow.Index
            alattxtid.Text = alatdgv.Item(0, i).Value
            alattxtnama.Text = alatdgv.Item(1, i).Value
            alattxtstok.Text = alatdgv.Item(2, i).Value
            alatcbxsatuan.Text = alatdgv.Item(3, i).Value
            alatdtptgl.Text = alatdgv.Item(4, i).Value
            alatcbxstatus.Text = alatdgv.Item(5, i).Value
            alatrtbket.Text = alatdgv.Item(6, i).Value
        Catch ex As Exception
            alat_bersih()
        End Try
    End Sub
    Private Sub alatdgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles alatdgv.DataBindingComplete
        For i = 0 To alatdgv.Rows.Count - 1
            Dim Str As String = alatdgv.Rows(i).Cells("stok_alat").Value
            If Str = "0" Then
                alatdgv.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
            End If
        Next
    End Sub
    Private Sub alatbtnsimpan_Click(sender As Object, e As EventArgs) Handles alatbtnsimpan.Click
        alatCariKode()
        If alattxtid.Text = "" Or alattxtnama.Text = "" Or alattxtstok.Text = "" Then
            MsgBox("Id alat, Nama alat, dan Stok alat harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("insert into alat_ukur (id_alat, uraian_alat, stok_alat, satuan, tgl, status_alat, ket) values ('" & alattxtid.Text & "','" & alattxtnama.Text & "','" & alattxtstok.Text & "','" & alatcbxsatuan.Text & "','" & alatdtptgl.Text & "','" & alatcbxstatus.Text & "','" & alatrtbket.Text & "')", con)
            cmd.ExecuteNonQuery()
            con.Close()
            alat_bersih()
            alat_tampil()
            alatCariKode()
        End If
    End Sub

    Private Sub alatbtnhapus_Click(sender As Object, e As EventArgs) Handles alatbtnhapus.Click
        If alattxtid.Text = "" Then
            MsgBox("Pilih terlebih dahulu data alat yang ingin dihapus", MsgBoxStyle.Exclamation)
        Else
            Try
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("delete from alat_ukur where id_alat='" & alattxtid.Text & "'", con)
                cmd.ExecuteNonQuery()
                alat_bersih()
                alat_tampil()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        alatCariKode()
    End Sub

    Private Sub alatbtnupdate_Click(sender As Object, e As EventArgs) Handles alatbtnupdate.Click
        If alattxtid.Text = "" Or alattxtnama.Text = "" Or alattxtstok.Text = "" Then
            MsgBox("Id alat, Nama alat, dan Stok alat harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update alat_ukur set uraian_alat ='" & alattxtnama.Text & "', stok_alat ='" & alattxtstok.Text & "', satuan='" & alatcbxsatuan.Text & "', tgl='" & alatdtptgl.Text & "', status_alat='" & alatcbxstatus.Text & "', ket='" & alatrtbket.Text & "' where id_alat='" & alattxtid.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            alat_bersih()
            alat_tampil()
            alatCariKode()
        End If
    End Sub

    Private Sub alattxtstok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles alattxtstok.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    'end alat ukur////////////////////////////////////////////////////////////////////////////////////







    'pegawai////////////////////////////////////////////////////////////////////////////////////
    Sub pegawaiCariKode()
        koneksi()
        On Error Resume Next
        Dim strSementara As String = ""
        Dim strIsi As String = ""
        cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from pegawai order by id_operator desc", con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            strSementara = Mid(rd.Item("id_operator"), 2, 2)
            strIsi = Val(strSementara) + 1
            pegawaitxtid.Text = "P" + Mid("0", 1, 2 - strIsi.Length) & strIsi
        Else
            pegawaitxtid.Text = "P01"
        End If
        pegawaitxtnama.Focus()
        rd.Close()
        con.Close()
    End Sub
    Sub pegawai_bersih()
        pegawaitxtid.Clear()
        pegawaitxtnama.Clear()
        pegawaicbxcell.Text = "1"
        pegawaicbxsebagai.Text = "A1 Rotary"
        pegawairtbalamat.Text = ""
        pegawaitxtcari.Clear()
        pegawaitxtgender.Clear()
        pegawairbl.Checked = False
        pegawairbp.Checked = False
    End Sub
    Sub pegawai_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pegawai order by id_operator desc", con)
        dt = New DataSet
        ap.Fill(dt, "pegawai")
        pegawaidgv.DataSource = dt.Tables("pegawai")
        con.Close()
        Me.pegawaidgv.Columns(0).HeaderText = "IDP"
        Me.pegawaidgv.Columns(1).HeaderText = "Nama Pegawai"
        Me.pegawaidgv.Columns(2).HeaderText = "Gender"
        Me.pegawaidgv.Columns(3).HeaderText = "Alamat"
        Me.pegawaidgv.Columns(4).HeaderText = "Mandatory"
        Me.pegawaidgv.Columns(5).HeaderText = "Cell"
    End Sub
    Private Sub pegawaibtnclear_Click(sender As Object, e As EventArgs) Handles pegawaibtnclear.Click
        pegawai_bersih()
        pegawai_tampil()
        pegawaiCariKode()
    End Sub
    Private Sub pegawaitxtcari_TextChanged(sender As Object, e As EventArgs) Handles pegawaitxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pegawai where nama like '%" & pegawaitxtcari.Text & "%' order by id_operator desc", con)
        dt = New DataSet
        ap.Fill(dt, "pegawai")
        pegawaidgv.DataSource = dt.Tables("pegawai")
        con.Close()
    End Sub
    Private Sub pegawaidgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles pegawaidgv.CellClick
        Try
            pegawai_bersih()
            Dim i As Integer = pegawaidgv.CurrentRow.Index
            pegawaitxtid.Text = pegawaidgv.Item(0, i).Value
            pegawaitxtnama.Text = pegawaidgv.Item(1, i).Value
            pegawaitxtgender.Text = pegawaidgv.Item(2, i).Value
            If pegawaitxtgender.Text = "Laki - Laki" Then
                pegawairbl.Checked = True
                pegawairbp.Checked = False
            Else
                pegawairbp.Checked = True
                pegawairbl.Checked = False
            End If
            pegawairtbalamat.Text = pegawaidgv.Item(3, i).Value
            pegawaicbxsebagai.Text = pegawaidgv.Item(4, i).Value
            pegawaicbxcell.Text = pegawaidgv.Item(5, i).Value
        Catch ex As Exception
            pegawai_bersih()
        End Try
    End Sub

    Private Sub pegawairbl_CheckedChanged(sender As Object, e As EventArgs) Handles pegawairbl.CheckedChanged
        pegawaitxtgender.Text = "Laki - Laki"

    End Sub

    Private Sub pegawairbp_CheckedChanged(sender As Object, e As EventArgs) Handles pegawairbp.CheckedChanged
        pegawaitxtgender.Text = "Perempuan"

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If pegawaitxtid.Text = "" Then
            MsgBox("Pilih terlebih dahulu data pegawai yang ingin dihapus", MsgBoxStyle.Exclamation)
        Else
            Try
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("delete from pegawai where id_operator='" & pegawaitxtid.Text & "'", con)
                cmd.ExecuteNonQuery()
                pegawai_bersih()
                pegawai_tampil()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub pegawaibtnsimpan_Click(sender As Object, e As EventArgs) Handles pegawaibtnsimpan.Click
        pegawaiCariKode()
        If pegawaitxtid.Text = "" Or pegawaitxtnama.Text = "" Or pegawaitxtgender.Text = "" Then
            MsgBox("Id, Nama, dan gender pegawai harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("insert into pegawai (id_operator, nama, gender, alamat, cell, sebagai) values ('" & pegawaitxtid.Text & "','" & pegawaitxtnama.Text & "','" & pegawaitxtgender.Text & "','" & pegawairtbalamat.Text & "','" & pegawaicbxcell.Text & "','" & pegawaicbxsebagai.Text & "')", con)
            cmd.ExecuteNonQuery()
            con.Close()
            pegawai_bersih()
            pegawai_tampil()
            pegawaiCariKode()
        End If
    End Sub

    Private Sub pegawaibtnhapus_Click(sender As Object, e As EventArgs) Handles pegawaibtnhapus.Click
        If pegawaitxtid.Text = "" Or pegawaitxtnama.Text = "" Or pegawaitxtgender.Text = "" Then
            MsgBox("Id, Nama, dan gender pegawai harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update pegawai set nama ='" & pegawaitxtnama.Text & "', gender ='" & pegawaitxtgender.Text & "', alamat='" & pegawairtbalamat.Text & "', cell='" & pegawaicbxcell.Text & "', sebagai='" & pegawaicbxsebagai.Text & "' where id_operator='" & pegawaitxtid.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            pegawai_bersih()
            pegawai_tampil()
            pegawaiCariKode()
        End If
    End Sub
    'end pegawai////////////////////////////////////////////////////////////////////////////////////





    'peminjaman////////////////////////////////////////////////////////////////////////////////////
    Sub peminjaman_alat_bersih()
        peminjamanalattxtid.Clear()
        peminjamanalatxtnama.Clear()
    End Sub
    Sub peminjaman_pegawai_bersih()
        peminjamanpegawaitxtid.Clear()
        peminjamanpegawaitxtnama.Clear()
    End Sub
    Sub peminjaman_bersih()
        peminjamanalattxtcari.Clear()
        peminjamanpegawaitxtcari.Clear()
        peminjamantxtqty.Clear()
        peminjamanrtbket.Clear()
    End Sub
    Sub peminjaman_alat_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from alat_ukur order by id_alat desc", con)
        dt = New DataSet
        ap.Fill(dt, "alat_ukur")
        peminjamandgvalat.DataSource = dt.Tables("alat_ukur")
        con.Close()
        Me.peminjamandgvalat.Columns(0).HeaderText = "ID"
        Me.peminjamandgvalat.Columns(1).HeaderText = "Nama Alat"
        Me.peminjamandgvalat.Columns(2).HeaderText = "Stok"
        Me.peminjamandgvalat.Columns(3).HeaderText = "Satuan"
        Me.peminjamandgvalat.Columns(4).HeaderText = "Pembaruan Terakhir"
        Me.peminjamandgvalat.Columns(5).HeaderText = "Kondisi"
        Me.peminjamandgvalat.Columns(6).HeaderText = "Keterangan"
    End Sub
    Sub peminjaman_pegawai_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pegawai order by id_operator desc", con)
        dt = New DataSet
        ap.Fill(dt, "pegawai")
        peminjamandgvpegawai.DataSource = dt.Tables("pegawai")
        con.Close()
        Me.peminjamandgvpegawai.Columns(0).HeaderText = "IDP"
        Me.peminjamandgvpegawai.Columns(1).HeaderText = "Nama Pegawai"
        Me.peminjamandgvpegawai.Columns(2).HeaderText = "Gender"
        Me.peminjamandgvpegawai.Columns(3).HeaderText = "Alamat"
        Me.peminjamandgvpegawai.Columns(4).HeaderText = "Mandatory"
        Me.peminjamandgvpegawai.Columns(5).HeaderText = "Cell"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles peminjamanalattxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from alat_ukur where uraian_alat like '%" & peminjamanalattxtcari.Text & "%' or  id_alat like '%" & peminjamanalattxtcari.Text & "%' order by id_alat desc", con)
        dt = New DataSet
        ap.Fill(dt, "alat_ukur")
        peminjamandgvalat.DataSource = dt.Tables("alat_ukur")
        con.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles peminjamanpegawaitxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pegawai where nama like '%" & peminjamanpegawaitxtcari.Text & "%' or  id_operator like '%" & peminjamanpegawaitxtcari.Text & "%' order by id_operator desc", con)
        dt = New DataSet
        ap.Fill(dt, "pegawai")
        peminjamandgvpegawai.DataSource = dt.Tables("pegawai")
        con.Close()
    End Sub

    Private Sub DataGridViewasdasdas1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles peminjamandgvalat.CellClick, alatdgv.CellClick
        Try
            peminjaman_alat_bersih()
            Dim i As Integer = peminjamandgvalat.CurrentRow.Index
            peminjamanalattxtid.Text = peminjamandgvalat.Item(0, i).Value
            peminjamanalatxtnama.Text = peminjamandgvalat.Item(1, i).Value
        Catch ex As Exception
            peminjaman_alat_bersih()
        End Try
    End Sub
    Private Sub peminjamandgvalat_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles peminjamandgvalat.DataBindingComplete
        For i = 0 To peminjamandgvalat.Rows.Count - 1
            Dim Str As String = peminjamandgvalat.Rows(i).Cells("stok_alat").Value
            If Str = "0" Then
                peminjamandgvalat.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
            End If
        Next
    End Sub
    Private Sub DataGridViewdfsdfsd2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles peminjamandgvpegawai.CellClick
        Try
            peminjaman_pegawai_bersih()
            Dim i As Integer = peminjamandgvpegawai.CurrentRow.Index
            peminjamanpegawaitxtid.Text = peminjamandgvpegawai.Item(0, i).Value
            peminjamanpegawaitxtnama.Text = peminjamandgvpegawai.Item(1, i).Value
        Catch ex As Exception
            peminjaman_pegawai_bersih()
        End Try
    End Sub

    Private Sub Buttonasdasdasdsadd1_Click_1(sender As Object, e As EventArgs) Handles peminjamanbtnsubmit.Click
        If peminjamantxtqty.Text = "" Or peminjamanalattxtid.Text = "" Or peminjamanpegawaitxtid.Text = "" Then
            MsgBox("qty dan id alat juga pegawai harus terisi", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("insert into pinjam_kembali (validasi, id_alat, id_operator, qty, tgl_pinjam, tgl_akhirpinjam, durasi, ket) values ('" & "submit" & "','" & peminjamanalattxtid.Text & "','" & peminjamanpegawaitxtid.Text & "','" & peminjamantxtqty.Text & "','" & peminjamandtp1.Text & "','" & peminjamandtp2.Text & "','" & DateDiff(DateInterval.Day, peminjamandtp1.Value, peminjamandtp2.Value) + 1 & "','" & peminjamanrtbket.Text & "')", con)
            cmd.ExecuteNonQuery()
            con.Close()
            peminjaman_alat_bersih()
            peminjaman_pegawai_bersih()
            peminjaman_bersih()
            formlistentry.entrytampil()
            MsgBox("Submit Succes", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub peminjamanbtnentry_Click(sender As Object, e As EventArgs) Handles peminjamanbtnentry.Click
        formlistentry.Show()
    End Sub


    'end peminjaman////////////////////////////////////////////////////////////////////////////////////




    'refuse////////////////////////////////////////////////////////////////////////////////////
    Sub refuse_bersih()
        refusetxtidpinjam.Clear()

        refusetxttglpinjam.Text = ""
        refusetxtlamahari.Text = ""
        refusetxtket.Text = ""
    End Sub
    Sub refuse_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where validasi='" & "reject" & "' and status='" & "" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        refusedgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.refusedgv.Columns(0).HeaderText = "ID Pinjam"
        Me.refusedgv.Columns(1).Visible = False 'Validasi"
        Me.refusedgv.Columns(2).HeaderText = "ID Alat"
        Me.refusedgv.Columns(3).HeaderText = "ID Pegawai"
        Me.refusedgv.Columns(4).HeaderText = "Qty"
        Me.refusedgv.Columns(5).HeaderText = "Tgl Pinjam"
        Me.refusedgv.Columns(6).Visible = False 'Tgl Akhir"
        Me.refusedgv.Columns(7).HeaderText = "Durasi"
        Me.refusedgv.Columns(8).Visible = False 'Keterangan
        Me.refusedgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.refusedgv.Columns(10).Visible = False 'status
    End Sub


    Private Sub refusedgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles refusedgv.CellClick
        Try
            refuse_bersih()
            Dim i As Integer = refusedgv.CurrentRow.Index
            refusetxtidpinjam.Text = refusedgv.Item(0, i).Value
            refusetxttglpinjam.Text = refusedgv.Item(5, i).Value
            refusetxttglbataspinjam.Text = refusedgv.Item(6, i).Value
            refusetxtlamahari.Text = refusedgv.Item(7, i).Value
            refusetxtlamahari.ForeColor = Color.Black
        Catch ex As Exception
            refuse_bersih()
        End Try
    End Sub

    Private Sub refusebtnresubmit_Click(sender As Object, e As EventArgs) Handles refusebtnresubmit.Click
        If refusetxtidpinjam.Text = "" Then
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set validasi='" & "submit" & "', ket='" & refusetxtket.Text & "', durasi='" & DateDiff(DateInterval.Day, refusetxtnewtgl.Value, refusetxttglbataspinjam.Value) + 1 & "', tgl_pinjam='" & refusetxtnewtgl.Text & "', tgl_akhirpinjam='" & refusetxttglbataspinjam.Text & "' where id_pinjam = '" & refusetxtidpinjam.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            refuse_bersih()
            refuse_tampil()
            MsgBox("Re-Submit Succes", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub refusetxtnewtgl_ValueChanged(sender As Object, e As EventArgs) Handles refusetxtnewtgl.ValueChanged
        refusetxtlamahari.Text = DateDiff(DateInterval.Day, refusetxtnewtgl.Value, refusetxttglbataspinjam.Value) + 1
        refusetxtlamahari.ForeColor = Color.DarkGreen
    End Sub

    Private Sub refusetxttglbataspinjam_ValueChanged(sender As Object, e As EventArgs) Handles refusetxttglbataspinjam.ValueChanged
        refusetxtlamahari.Text = DateDiff(DateInterval.Day, refusetxtnewtgl.Value, refusetxttglbataspinjam.Value) + 1
        refusetxtlamahari.ForeColor = Color.DarkGreen
    End Sub

    Private Sub refusebtnhapus_Click(sender As Object, e As EventArgs) Handles refusebtnhapus.Click
        If refusetxtidpinjam.Text = "" Then
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set status='" & "selesai" & "' where id_pinjam = '" & refusetxtidpinjam.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()
            refuse_bersih()
            refuse_tampil()
        End If
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        koneksi()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set status='" & "selesai" & "' where validasi = '" & "reject" & "' and status='" & "" & "'", con)
        cmd.ExecuteNonQuery()
            con.Close()
            refuse_bersih()
            refuse_tampil()
        MsgBox("Semua Data temp penolakan telah di bukukan", MsgBoxStyle.Information)

    End Sub
    'end refuse////////////////////////////////////////////////////////////////////////////////////






    'current////////////////////////////////////////////////////////////////////////////////////
    Sub current_bersih()
        currenttxtidpinjam.Clear()
        currenttxttglpinjam.Text = ""
        currenttxttglakhirpinjam.Text = ""
        currenttxtlamahari.Text = ""
        currenttxtket.Text = ""
        currentlblatasnama.Text = ""
        currentlblgender.Text = ""
        currentlblsebagai.Text = ""
        currentlblcell.Text = ""
        currentlblalatukur.Text = ""
        currentlblqty.Text = ""
        currentlblsatuan.Text = ""
        currrentlblupdate.Text = ""
        currentlblstatusalat.Text = ""
        currentlblketalata.Text = ""
        currenttxttersisa.Text = ""
        currenttxtidalat.Text = ""
        currentlblstokalat.Text = ""
    End Sub
    Sub current_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where validasi='" & "ok" & "' and status='" & "current" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        currentdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.currentdgv.Columns(0).HeaderText = "IDP"
        Me.currentdgv.Columns(1).Visible = False 'Validasi"
        Me.currentdgv.Columns(2).HeaderText = "IDA"
        Me.currentdgv.Columns(3).HeaderText = "IDPEG"
        Me.currentdgv.Columns(4).HeaderText = "QTY"
        Me.currentdgv.Columns(5).HeaderText = "TGL"
        Me.currentdgv.Columns(6).Visible = False 'Tgl Akhir"
        Me.currentdgv.Columns(7).HeaderText = "Durasi"
        Me.currentdgv.Columns(8).Visible = False 'Keterangan
        Me.currentdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.currentdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub currentdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles currentdgv.CellClick
        Try
            current_bersih()
            Dim i As Integer = currentdgv.CurrentRow.Index
            currenttxtidpinjam.Text = currentdgv.Item(0, i).Value
            currenttxttglpinjam.Text = currentdgv.Item(5, i).Value
            currenttxttglakhirpinjam.Text = currentdgv.Item(6, i).Value
            currenttxtlamahari.Text = currentdgv.Item(7, i).Value
            currenttxtket.Text = currentdgv.Item(8, i).Value
            currenttxtidalat.Text = currentdgv.Item(2, i).Value

            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from pegawai where id_operator='" & currentdgv.Item(3, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                currentlblatasnama.Text = rd("nama")
                currentlblgender.Text = rd("gender")
                currentlblsebagai.Text = rd("sebagai")
                currentlblcell.Text = rd("cell")
            End If
            rd.Close()
            con.Close()
            koneksi()

            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from alat_ukur where id_alat='" & currentdgv.Item(2, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                currentlblalatukur.Text = rd("uraian_alat")
                currentlblstokalat.Text = rd("stok_alat")
                currentlblsatuan.Text = rd("satuan")
                currrentlblupdate.Text = rd("tgl")
                currentlblstatusalat.Text = rd("status_alat")
                currentlblketalata.Text = rd("ket")
            End If
            rd.Close()
            con.Close()

            currentlblqty.Text = currentdgv.Item(4, i).Value
        Catch ex As Exception
            current_bersih()
        End Try
    End Sub

    Private Sub currentbtnkembalikan1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        current_tampil()
    End Sub

    Private Sub currenttxtcari_TextChanged(sender As Object, e As EventArgs) Handles currenttxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where id_pinjam like '%" & currenttxtcari.Text & "%' and validasi='" & "ok" & "' and status='" & "current" & "' or id_alat like '%" & currenttxtcari.Text & "%' and validasi='" & "ok" & "' and status='" & "current" & "' or id_operator like '%" & currenttxtcari.Text & "%' and validasi='" & "ok" & "' and status='" & "current" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        currentdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.currentdgv.Columns(0).HeaderText = "IDP"
        Me.currentdgv.Columns(1).Visible = False 'Validasi"
        Me.currentdgv.Columns(2).HeaderText = "IDA"
        Me.currentdgv.Columns(3).HeaderText = "IDPEG"
        Me.currentdgv.Columns(4).HeaderText = "QTY"
        Me.currentdgv.Columns(5).HeaderText = "TGL"
        Me.currentdgv.Columns(6).Visible = False 'Tgl Akhir"
        Me.currentdgv.Columns(7).HeaderText = "Durasi"
        Me.currentdgv.Columns(8).Visible = False 'Keterangan
        Me.currentdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.currentdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles currentdtptglcari.ValueChanged, currentdtptglkembali.ValueChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where tgl_pinjam ='" & currentdtptglcari.Text & "' And validasi ='" & "ok" & "' and status='" & "current" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        currentdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.currentdgv.Columns(0).HeaderText = "IDP"
        Me.currentdgv.Columns(1).Visible = False 'Validasi"
        Me.currentdgv.Columns(2).HeaderText = "IDA"
        Me.currentdgv.Columns(3).HeaderText = "IDPEG"
        Me.currentdgv.Columns(4).HeaderText = "QTY"
        Me.currentdgv.Columns(5).HeaderText = "TGL"
        Me.currentdgv.Columns(6).Visible = False 'Tgl Akhir"
        Me.currentdgv.Columns(7).HeaderText = "Durasi"
        Me.currentdgv.Columns(8).Visible = False 'Keterangan
        Me.currentdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.currentdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub currentbtnkembalikan_Click(sender As Object, e As EventArgs) Handles currentbtnkembalikan.Click
        Dim qtyloan As Integer = Val(currentlblqty.Text)
        Dim stokalat As Integer = Val(currentlblstokalat.Text)
        If currenttxtidpinjam.Text = "" Then
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        Else
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set status='" & "dikembalikan" & "', tgl_pengembalian='" & currentdtptglkembali.Text & "' where id_pinjam = '" & currenttxtidpinjam.Text & "'", con)
            cmd.ExecuteNonQuery()
            con.Close()

            Dim stokminqty As Integer = stokalat + qtyloan
            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update alat_ukur set stok_alat='" & stokminqty & "' where id_alat = '" & currenttxtidalat.Text & "'", con)
            cmd.ExecuteNonQuery()
            current_bersih()
            current_tampil()
            MsgBox("Data dikemblikan", MsgBoxStyle.Information)
        End If
    End Sub
    'end current////////////////////////////////////////////////////////////////////////////////////




    'rekappinjam+detail////////////////////////////////////////////////////////////////////////////////////
    Sub rekappinjam_tampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where validasi !='" & "submit" & "' and status !='" & "" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        rekappinjamdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.rekappinjamdgv.Columns(0).HeaderText = "IDP"
        Me.rekappinjamdgv.Columns(1).HeaderText = "SVM VALID" 'Validasi"
        Me.rekappinjamdgv.Columns(2).HeaderText = "IDA"
        Me.rekappinjamdgv.Columns(3).HeaderText = "IDPEG"
        Me.rekappinjamdgv.Columns(4).HeaderText = "QTY"
        Me.rekappinjamdgv.Columns(5).HeaderText = "Tanggal Pinjam"
        Me.rekappinjamdgv.Columns(6).HeaderText = "Batas Tanggal" 'Tgl Akhir"
        Me.rekappinjamdgv.Columns(7).HeaderText = "Durasi"
        Me.rekappinjamdgv.Columns(8).HeaderText = "Keterangan" 'Keterangan
        Me.rekappinjamdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.rekappinjamdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub rekappinjamtxtcari_TextChanged(sender As Object, e As EventArgs) Handles rekappinjamtxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where id_pinjam like '%" & rekappinjamtxtcari.Text & "%' and validasi !='" & "submit" & "' and status !='" & "" & "' or id_alat like '%" & rekappinjamtxtcari.Text & "%' and validasi !='" & "submit" & "' and status !='" & "" & "' or id_operator like '%" & rekappinjamtxtcari.Text & "%' and validasi !='" & "submit" & "' and status !='" & "" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        rekappinjamdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.rekappinjamdgv.Columns(0).HeaderText = "IDP"
        Me.rekappinjamdgv.Columns(1).HeaderText = "SVM VALIDASI" 'Validasi"
        Me.rekappinjamdgv.Columns(2).HeaderText = "IDA"
        Me.rekappinjamdgv.Columns(3).HeaderText = "IDPEG"
        Me.rekappinjamdgv.Columns(4).HeaderText = "QTY"
        Me.rekappinjamdgv.Columns(5).HeaderText = "Tanggal Pinjam"
        Me.rekappinjamdgv.Columns(6).HeaderText = "Batas Tanggal" 'Tgl Akhir"
        Me.rekappinjamdgv.Columns(7).HeaderText = "Durasi Hari"
        Me.rekappinjamdgv.Columns(8).HeaderText = "Keterangan" 'Keterangan
        Me.rekappinjamdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.rekappinjamdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub rekappinjamdtpcari_ValueChanged(sender As Object, e As EventArgs) Handles rekappinjamdtpcari.ValueChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where tgl_pinjam = '" & rekappinjamdtpcari.Text & "' and  validasi !='" & "submit" & "' and status !='" & "" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        rekappinjamdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.rekappinjamdgv.Columns(0).HeaderText = "IDP"
        Me.rekappinjamdgv.Columns(1).HeaderText = "SVM VALID" 'Validasi"
        Me.rekappinjamdgv.Columns(2).HeaderText = "IDA"
        Me.rekappinjamdgv.Columns(3).HeaderText = "IDPEG"
        Me.rekappinjamdgv.Columns(4).HeaderText = "QTY"
        Me.rekappinjamdgv.Columns(5).HeaderText = "Tanggal Pinjam"
        Me.rekappinjamdgv.Columns(6).HeaderText = "Batas Tanggal" 'Tgl Akhir"
        Me.rekappinjamdgv.Columns(7).HeaderText = "Durasi"
        Me.rekappinjamdgv.Columns(8).HeaderText = "Keterangan" 'Keterangan
        Me.rekappinjamdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.rekappinjamdgv.Columns(10).Visible = False 'status
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        rekappinjam_tampil()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If detailtxtidpinjam.Text = "" Then
            MsgBox("Pilih terlebih dahulu, dan pastikan di klik dengan benar", MsgBoxStyle.Information)
        Else
            TabControl1.SelectedTab = tabrekapdetail
            Label5.Text = "UTC > Rekap Peminjaman > Detail"
            Try
                Dim i As Integer = rekappinjamdgv.CurrentRow.Index
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("select *, COUNT(*) as banyakmeminjam from pinjam_kembali where id_operator='" & detailtxtidpegawai.Text & "' and validasi='" & "ok" & "'", con)
                rd = cmd.ExecuteReader
                If rd.Read Then
                    detaillbltelahmeminjamalatsebanyak.Text = "telah meminjam alat sebanyak " & Convert.ToString(rd("banyakmeminjam")) & " Kali"
                End If
                rd.Close()
                con.Close()

                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("select *, COUNT(*) as banyakmeminjam from pinjam_kembali where id_alat='" & detailtxtidalat.Text & "'  and validasi='" & "ok" & "'", con)
                rd = cmd.ExecuteReader
                If rd.Read Then
                    detailtelahdipinjampegawaisebanyak.Text = "alat ini telah dipinjam  sebanyak " & Convert.ToString(rd("banyakmeminjam")) & " Kali"
                End If
                rd.Close()
                con.Close()

                koneksi()
                ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where id_operator ='" & detailtxtidpegawai.Text & "'  and validasi='" & "ok" & "'", con)
                dt = New DataSet
                ap.Fill(dt, "pinjam_kembali")
                detaildgvpegawai.DataSource = dt.Tables("pinjam_kembali")
                con.Close()
                Me.detaildgvpegawai.Columns(0).Visible = False
                Me.detaildgvpegawai.Columns(1).HeaderText = "SVM VALIDASI" 'Validasi"
                Me.detaildgvpegawai.Columns(2).Visible = False
                Me.detaildgvpegawai.Columns(3).Visible = False
                Me.detaildgvpegawai.Columns(4).Visible = False
                Me.detaildgvpegawai.Columns(5).HeaderText = "Tanggal Pinjam"
                Me.detaildgvpegawai.Columns(6).HeaderText = "Batas Tanggal" 'Tgl Akhir"
                Me.detaildgvpegawai.Columns(7).HeaderText = "Durasi Hari"
                Me.detaildgvpegawai.Columns(8).HeaderText = "Keterangan" 'Keterangan
                Me.detaildgvpegawai.Columns(9).Visible = False 'Tgl Pengambilan
                Me.detaildgvpegawai.Columns(10).Visible = False 'status

                koneksi()
                ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where id_alat ='" & detailtxtidalat.Text & "'  and validasi='" & "ok" & "'", con)
                dt = New DataSet
                ap.Fill(dt, "pinjam_kembali")
                detaildgvalat.DataSource = dt.Tables("pinjam_kembali")
                con.Close()
                Me.detaildgvalat.Columns(0).Visible = False
                Me.detaildgvalat.Columns(1).HeaderText = "SVM VALIDASI" 'Validasi"
                Me.detaildgvalat.Columns(2).Visible = False
                Me.detaildgvalat.Columns(3).Visible = False
                Me.detaildgvalat.Columns(4).Visible = False
                Me.detaildgvalat.Columns(5).HeaderText = "Tanggal Pinjam"
                Me.detaildgvalat.Columns(6).HeaderText = "Batas Tanggal" 'Tgl Akhir"
                Me.detaildgvalat.Columns(7).HeaderText = "Durasi Hari"
                Me.detaildgvalat.Columns(8).HeaderText = "Keterangan" 'Keterangan
                Me.detaildgvalat.Columns(9).Visible = False 'Tgl Pengambilan
                Me.detaildgvalat.Columns(10).Visible = False 'status
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


    End Sub
    Sub detail_bersih()
        detailtxtidpinjam.Text = ""
        detailtxtidalat.Text = ""
        detailtxtidpegawai.Text = ""
        detailtxtqty.Text = ""
        detailtxttglpinjam.Text = ""
        detailtxttglbataspinjam.Text = ""
        detailtxtlamahari.Text = ""
        detailtxtket.Text = ""
        detailtxttglpengembalian.Text = ""
        detaillblnamapegawai.Text = ""
        detaillblsebagai.Text = ""
        detaillblcell.Text = ""
        detaillblnamaalat.Text = ""
        detaillblsatuan.Text = ""
        detaillblupdate.Text = ""
        detaillblstatus.Text = ""
        detaillblketalat.Text = ""
        detailtelahdipinjampegawaisebanyak.Text = ""
        detaillbltelahmeminjamalatsebanyak.Text = ""
    End Sub
    Private Sub rekappinjamdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles rekappinjamdgv.CellClick
        Try
            detail_bersih()
            Dim i As Integer = rekappinjamdgv.CurrentRow.Index
            detailtxtidpinjam.Text = rekappinjamdgv.Item(0, i).Value
            detailtxtstatuspeminjaman.Text = rekappinjamdgv.Item(1, i).Value
            detailtxtidalat.Text = rekappinjamdgv.Item(2, i).Value
            detailtxtidpegawai.Text = rekappinjamdgv.Item(3, i).Value
            detailtxtqty.Text = rekappinjamdgv.Item(4, i).Value
            detailtxttglpinjam.Text = rekappinjamdgv.Item(5, i).Value
            detailtxttglbataspinjam.Text = rekappinjamdgv.Item(6, i).Value
            detailtxtlamahari.Text = rekappinjamdgv.Item(7, i).Value
            detailtxtket.Text = rekappinjamdgv.Item(8, i).Value
            detailtxttglpengembalian.Text = rekappinjamdgv.Item(9, i).Value

            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from pegawai where id_operator='" & rekappinjamdgv.Item(3, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                detaillblnamapegawai.Text = rd("nama")
                detaillblsebagai.Text = rd("sebagai")
                detaillblcell.Text = rd("cell")
            End If
            rd.Close()
            con.Close()
            koneksi()

            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from alat_ukur where id_alat='" & rekappinjamdgv.Item(2, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                detaillblnamaalat.Text = rd("uraian_alat")

                detaillblsatuan.Text = rd("satuan")
                detaillblupdate.Text = rd("tgl")
                detaillblstatus.Text = rd("status_alat")
                detaillblketalat.Text = rd("ket")
            End If
            rd.Close()
            con.Close()


        Catch ex As Exception
            detail_bersih()
        End Try
    End Sub

    Private Sub rekappinjamdgv_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles rekappinjamdgv.DataBindingComplete
        For i = 0 To rekappinjamdgv.Rows.Count - 1
            Dim Str As String = rekappinjamdgv.Rows(i).Cells("validasi").Value
            If Str = "reject" Then
                rekappinjamdgv.Rows(i).DefaultCellStyle.BackColor = Color.LightPink
            ElseIf Str = "ok" Then
                rekappinjamdgv.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
            End If
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TabControl1.SelectedTab = tabrekappeminjaman
        Label5.Text = "UTC > Rekap Peminjaman"
    End Sub


    'end rekappinjam+detail////////////////////////////////////////////////////////////////////////////////////






    'laporan////////////////////////////////////////////////////////////////////////////////////
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ComboBox2.Text = "" Then
            MsgBox("Pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        ElseIf ComboBox2.Text = "Semua Data Pegawai" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("cell", "")
                rpt.SetParameterValue("sebagai", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Pegawai C1" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("cell", "1")
                rpt.SetParameterValue("sebagai", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Pegawai C2" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("cell", "2")
                rpt.SetParameterValue("sebagai", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Pegawai C3" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("cell", "3")
                rpt.SetParameterValue("sebagai", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Pegawai C4" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("cell", "4")
                rpt.SetParameterValue("sebagai", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai A1 Rotary" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "A1 Rotary")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai A2 Airframe" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "A2 Airframe")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai A3 Piston" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "A3 Piston")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai A4 Turbine" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "A4 Turbine")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai C1 Radio" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "C1 Radio")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai C2 Instrument" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "C2 Instrument")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Pegawai C4 Electrical" Then
            Try
                Dim str As String = "cr1.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("sebagai", "C4 Electrical")
                rpt.SetParameterValue("cell", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try



        ElseIf ComboBox2.Text = "Semua Data Alat" Then
            Try
                Dim str As String = "cralat.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("stok", "")
                rpt.SetParameterValue("status", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Alat Maintenance" Then
            Try
                Dim str As String = "cralat.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("stok", "")
                rpt.SetParameterValue("status", "Maintenance")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Alat Baik" Then
            Try
                Dim str As String = "cralat.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("stok", "")
                rpt.SetParameterValue("status", "Baik")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Alat Tidak Layak" Then
            Try
                Dim str As String = "cralat.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("stok", "")
                rpt.SetParameterValue("status", "Tidak Layak")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Data Alat Kosong" Then
            Try
                Dim str As String = "cralat.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("stok", "Kosong")
                rpt.SetParameterValue("status", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try



        ElseIf ComboBox2.Text = "Semua Riwayat Peminjaman" Then
            Try
                Dim str As String = "crpinjam.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Peminjaman Saat Ini" Then
            Try
                Dim str As String = "crpinjam.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "current")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Peminjaman Ditolak" Then
            Try
                Dim str As String = "crpinjam.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "reject")
                rpt.SetParameterValue("status", "")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox2.Text = "Semua Riwayat Pengembalian" Then
            Try
                Dim str As String = "crpinjam.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "dikembalikan")
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ComboBox1.Text = "Riwayat Peminjaman" Then
            Try
                Dim str As String = "crpinjampriode.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "")
                rpt.SetParameterValue("tglawal", DateTimePicker2.Value)
                rpt.SetParameterValue("tglakhir", DateTimePicker1.Value)
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox1.Text = "Peminjaman Saat Ini" Then
            Try
                Dim str As String = "crpinjampriode.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "current")
                rpt.SetParameterValue("tglawal", DateTimePicker2.Value)
                rpt.SetParameterValue("tglakhir", DateTimePicker1.Value)
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox1.Text = "Peminjaman Ditolak" Then
            Try
                Dim str As String = "crpinjampriode.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "reject")
                rpt.SetParameterValue("status", "")
                rpt.SetParameterValue("tglawal", DateTimePicker2.Value)
                rpt.SetParameterValue("tglakhir", DateTimePicker1.Value)
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        ElseIf ComboBox1.Text = "Riwayat Pengembalian" Then
            Try
                Dim str As String = "crpinjampriode.rpt"
                Dim rpt As New ReportDocument()
                rpt.Load(str)
                rpt.SetParameterValue("validasi", "")
                rpt.SetParameterValue("status", "dikembalikan")
                rpt.SetParameterValue("tglawal", DateTimePicker2.Value)
                rpt.SetParameterValue("tglakhir", DateTimePicker1.Value)
                CrystalReportViewer1.Refresh()
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.Show()
            Catch ex As Exception
            End Try
        End If
    End Sub
    'end laporan////////////////////////////////////////////////////////////////////////////////////
End Class