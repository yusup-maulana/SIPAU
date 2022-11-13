Imports MySql.Data.MySqlClient

Public Class Form3
    Sub navgreen()
        Panel4.BackColor = Color.DarkGreen
        Panel5.BackColor = Color.DarkGreen

        Panel7.BackColor = Color.DarkGreen
        Panel12.BackColor = Color.DarkGreen

        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
        Label4.ForeColor = Color.White
        Label10.ForeColor = Color.White

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label5.Text = "SVP > Loan Request"
        navgreen()
        Panel4.BackColor = Color.White
        Label1.ForeColor = Color.Black
        TabControl1.SelectedTab = tabrequest
        requesttampil()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Label5.Text = "SVP > Rekap Peminjaman"
        navgreen()
        Panel5.BackColor = Color.White
        Label2.ForeColor = Color.Black
        TabControl1.SelectedTab = tabretrival
        rekappinjam_tampil()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        alat_tampil()
        Label5.Text = "SVP > Data Alat Ukur"
        navgreen()
        Panel7.BackColor = Color.White
        Label4.ForeColor = Color.Black
        TabControl1.SelectedTab = tabalat
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
        Me.Dispose()
        Form1.Show()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Label5.Text = "SVP > Data Pegawai"
        navgreen()
        Panel12.BackColor = Color.White
        Label10.ForeColor = Color.Black
        pegawai_tampil()
        TabControl1.SelectedTab = tabpegawai
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.BackColor = Color.White
        Label1.ForeColor = Color.Black
        TabControl1.SelectedTab = tabrequest
        requesttampil()
    End Sub




    'request////////////////////////////////////////////////////////////////////////////////////
    Sub requesttampil()
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pinjam_kembali where validasi='" & "submit" & "' order by id_pinjam desc", con)
        dt = New DataSet
        ap.Fill(dt, "pinjam_kembali")
        requestdgv.DataSource = dt.Tables("pinjam_kembali")
        con.Close()
        Me.requestdgv.Columns(0).HeaderText = "ID Pinjam"
        Me.requestdgv.Columns(1).Visible = False 'Validasi"
        Me.requestdgv.Columns(2).HeaderText = "ID Alat"
        Me.requestdgv.Columns(3).HeaderText = "ID Pegawai"
        Me.requestdgv.Columns(4).HeaderText = "Qty"
        Me.requestdgv.Columns(5).HeaderText = "Tgl Pinjam"
        Me.requestdgv.Columns(6).Visible = False 'Tgl Akhir"
        Me.requestdgv.Columns(7).HeaderText = "Durasi"
        Me.requestdgv.Columns(8).Visible = False 'Keterangan
        Me.requestdgv.Columns(9).Visible = False 'Tgl Pengambilan
        Me.requestdgv.Columns(10).Visible = False 'status
    End Sub

    Sub requestbersih()
        requesttxtid.Text = ""
        requesttxttglpinjam.Text = ""
        requesttxttglbataspinjam.Text = ""
        requesttxtlamahari.Text = ""
        requesttxtket.Text = ""

        requestlblatasnama.Text = ""
        requestlblgender.Text = ""
        requestlblsebagai.Text = ""
        requestlblcell.Text = ""

        requestlblalatukur.Text = ""
        requestlblstok.Text = ""
        requestlblsatuan.Text = ""
        requestlblupdate.Text = ""
        requestlblstatus.Text = ""
        requestlblketalat.Text = ""
        requestlblketalat.Text = ""
        requestlblqty.Text = ""

        requesttxtidalat.Text = ""
    End Sub
    Private Sub requestdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles requestdgv.CellClick
        Try
            requestbersih()
            Dim i As Integer = requestdgv.CurrentRow.Index
            requesttxtid.Text = requestdgv.Item(0, i).Value
            requesttxttglpinjam.Text = requestdgv.Item(5, i).Value
            requesttxttglbataspinjam.Text = requestdgv.Item(6, i).Value
            requesttxtlamahari.Text = requestdgv.Item(7, i).Value
            requesttxtket.Text = requestdgv.Item(8, i).Value
            requesttxtidalat.Text = requestdgv.Item(2, i).Value

            koneksi()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from pegawai where id_operator='" & requestdgv.Item(3, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                requestlblatasnama.Text = rd("nama")
                requestlblgender.Text = rd("gender")
                requestlblsebagai.Text = rd("sebagai")
                requestlblcell.Text = rd("cell")
            End If
            rd.Close()
            con.Close()
            koneksi()

            cmd = New MySql.Data.MySqlClient.MySqlCommand("select * from alat_ukur where id_alat='" & requestdgv.Item(2, i).Value & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                requestlblalatukur.Text = rd("uraian_alat")
                requestlblstok.Text = rd("stok_alat")
                requestlblsatuan.Text = rd("satuan")
                requestlblupdate.Text = rd("tgl")
                requestlblstatus.Text = rd("status_alat")
                requestlblketalat.Text = rd("ket")
            End If
            rd.Close()
            con.Close()

            requestlblqty.Text = requestdgv.Item(4, i).Value
        Catch ex As Exception
            requestbersih()
        End Try
    End Sub

    Private Sub requestlblreject_Click(sender As Object, e As EventArgs) Handles requestlblreject.Click
        If requesttxtid.Text = "" Then
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        Else
            Dim x As String = MsgBox("Apakah anda yakin ingin menolak permintaan ini?", MsgBoxStyle.Question + vbYesNo)
            If x = vbYes Then
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set validasi='" & "reject" & "' where id_pinjam = '" & requesttxtid.Text & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                requestbersih()
                requesttampil()
                MsgBox("Rejected Succes", MsgBoxStyle.Information)
            Else
            End If
        End If

    End Sub

    Private Sub requestbtnaccept_Click(sender As Object, e As EventArgs) Handles requestbtnaccept.Click
        Dim qtyloan As Integer = Val(requestlblqty.Text)
        Dim stokalat As Integer = Val(requestlblstok.Text)
        If requesttxtid.Text = "" Then
            MsgBox("pilih terlebih dahulu", MsgBoxStyle.Exclamation)
        ElseIf stokalat < 1 Then
            MsgBox("Stok alat kosong", MsgBoxStyle.Critical)
        ElseIf stokalat < qtyloan Then
            MsgBox("Stok alat tidak cukup", MsgBoxStyle.Critical)
        Else
            Dim x As String = MsgBox("Apakah anda yakin ingin menolak permintaan ini?", MsgBoxStyle.Question + vbYesNo)
            If x = vbYes Then
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("update pinjam_kembali set validasi='" & "ok" & "', status='" & "current" & "' where id_pinjam = '" & requesttxtid.Text & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim stokminqty As Integer = stokalat - qtyloan
                koneksi()
                cmd = New MySql.Data.MySqlClient.MySqlCommand("update alat_ukur set stok_alat='" & stokminqty & "' where id_alat = '" & requesttxtidalat.Text & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()
                requestbersih()
                requesttampil()
                MsgBox("Accept Succes", MsgBoxStyle.Information)
            Else
            End If
        End If
    End Sub

    'end request////////////////////////////////////////////////////////////////////////////////////








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
            TabControl1.SelectedTab = tabdetail
            Label5.Text = "SVP > Rekap Peminjaman > Detail"
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
        Label5.Text = "SVP > Rekap Peminjaman"
        TabControl1.SelectedTab = tabretrival
    End Sub

    Private Sub Panel13_Paint(sender As Object, e As PaintEventArgs) Handles Panel13.Paint

    End Sub

    'end rekappinjam+detail////////////////////////////////////////////////////////////////////////////////////



    'pegawai////////////////////////////////////////////////////////////////////////////////////
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
    Private Sub pegawaitxtcari_TextChanged(sender As Object, e As EventArgs) Handles pegawaitxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from pegawai where nama like '%" & pegawaitxtcari.Text & "%' order by id_operator desc", con)
        dt = New DataSet
        ap.Fill(dt, "pegawai")
        pegawaidgv.DataSource = dt.Tables("pegawai")
        con.Close()
    End Sub

    Private Sub pegawaibtnclear_Click(sender As Object, e As EventArgs) Handles pegawaibtnclear.Click
        pegawaitxtcari.Clear()
        pegawai_tampil()
    End Sub
    'end pegawai////////////////////////////////////////////////////////////////////////////////////


    'alat////////////////////////////////////////////////////////////////////////////////////
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

    Private Sub alattxtcari_TextChanged(sender As Object, e As EventArgs) Handles alattxtcari.TextChanged
        koneksi()
        ap = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from alat_ukur where uraian_alat like '%" & alattxtcari.Text & "%' order by id_alat desc", con)
        dt = New DataSet
        ap.Fill(dt, "alat_ukur")
        alatdgv.DataSource = dt.Tables("alat_ukur")
        con.Close()
        'end alat////////////////////////////////////////////////////////////////////////////////////
    End Sub

    Private Sub alatbtnclear_Click(sender As Object, e As EventArgs) Handles alatbtnclear.Click
        alat_tampil()
        alattxtcari.Clear()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not e.CloseReason = CloseReason.WindowsShutDown Then
            e.Cancel = True
        End If
    End Sub
End Class