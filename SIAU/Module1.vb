Imports mysql.data.mysqlclient
Module Module1
    Public cmd As MySqlCommand
    Public ap As MySqlDataAdapter
    Public rd As MySqlDataReader
    Public con As MySqlConnection
    Public dt As New DataSet

    Sub koneksi()
        con = New MySqlConnection("server=localhost;user=root;password=;database=db_utc;convert zero datetime=true;allow user variables=true")
        con.Open()
        If con.State = ConnectionState.Open Then

        Else
            MsgBox("tidak terkoneksi, ada masalah")
        End If
    End Sub
End Module
