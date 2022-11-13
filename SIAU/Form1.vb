Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Focus()
    End Sub
    Sub login()
        Try
            koneksi()
            cmd = New MySqlCommand("select * from admin where user='" & TextBox2.Text & "'", con)
            rd = cmd.ExecuteReader
            If rd.Read Then
                rd.Close()
                con.Close()
                koneksi()
                cmd = New MySqlCommand("select * from admin where pass='" & TextBox1.Text & "'", con)
                rd = cmd.ExecuteReader
                If rd.Read Then
                    Dim akses As String = Convert.ToString(rd("akses"))
                    If akses = "admin_operator" Then
                        Form2.Text = Convert.ToString(rd("nama_user"))
                        rd.Close()
                        con.Close()
                        Form2.Show()
                        Me.Hide()
                    Else
                        Form3.Text = Convert.ToString(rd("nama_user"))
                        rd.Close()
                        con.Close()
                        Form3.Show()
                        Me.Hide()
                    End If

                Else
                    rd.Close()
                    con.Close()
                    MsgBox("Password salah", MsgBoxStyle.Critical)
                    TextBox1.Focus()
                End If
            Else
                MsgBox("User tidak ditemukan", MsgBoxStyle.Critical)
                TextBox2.Focus()
                rd.Close()
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar = Chr(13)) Then
            login()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        MsgBox("The technology we use today is indeed shifting to the cloud era. Even Microsoft, which originally concentrated on the Windows OS, now turns to Azure, the cloud computing platform they developed.

The internet will be faster, and cloud services, both computing and storage, will become increasingly convenient services.
The Chinese state, of course, is aware of this, and they must encourage their people to use cloud services.

One way for people to switch to cloud services is to provide this service for free, to invite as many people as possible to try it. No half-hearted, to attract users, they offer enormous free storage to the count of tens of Terabytes.", MsgBoxStyle.Information)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        MsgBox("In the fields of science, engineering industry, and statistics, the accuracy [1] of a measurement system is the level of measurement of the proximity of the actual value. The precision of a measurement system, also called reproducibility (English: reproducibility) or repeatability of English: repeatability, is the extent to which repeated measurements under unchanged conditions get the same results. [2]

A measurement system can be accurate and precise, or accurate but not exact, or precise but not accurate or inaccurate and inaccurate.", MsgBoxStyle.Information)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        MsgBox("In physics and engineering, measurement is an activity that compares the physical quantity of objects and real-world events. Measuring instrument is a tool used to measure objects or events. All gauges can be subject to varying equipment errors. The field of science that studies methods of measurement is called metrology.

Physicists use many tools to take their measurements. It starts from simple devices such as rulers and stopwatches to electron microscopes and particle accelerators. Virtual instruments are widely used in the development of modern measuring instruments.", MsgBoxStyle.Information)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        MsgBox("collection of data that forms a file (file) that are interconnected (relations) with certain procedures to form new data or information. Or database (database) is a collection of data that are interconnected (relations) between one another that is organized based on a particular scheme or structure. On computers, databases are stored in hardware storage devices, and with certain software manipulated certain interests or uses. Relationships or data relations are usually indicated by the key (key) of each file that is there. Data is a fact or value that is recorded or represents a description of an object. Data which is a recorded fact and then carried out processing (process) into a form that is useful or beneficial to the user will form what is called information. Complex and integrated forms of information and the processing of a database with a computer will be used for the decision making process in management to form a Management Information System (SIM), data in the database is the smallest and most important item to build a good and valid database. Data in a database is integrated and shared", MsgBoxStyle.Information)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar = Chr(13)) Then
            login()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
End Class
