# Sistem Informasi Peminjaman Alat Ukur
Sistem Informasi Peminjaman Alat Ukur SIAU, dibangun dengan menggunakan Visual Studio 2019 sebagai mesin pengembangnya dan MySQL 5.6 sebagai database utama yang menjadi landasan aplikasi ini. Aplikasi ini dirancang dengan tujuan untuk mempermudah pengelolaan peminjaman alat ukur. Dibuat pada tahun 2019 sebagai bagian dari tugas skripsi, aplikasi ini memanfaatkan Visual Studio 2019, MySQL, dan Crystal Report secara bersama-sama untuk memberikan pengalaman pengguna yang optimal dan menarik.

Aplikasi SIAU menawarkan berbagai fitur unggulan yang terlihat biasa saja, tetapi juga membuatnya menjadi solusi yang cukup dalam pengelolaan peminjaman alat ukur. Terdapat dua jenis pengguna/admin, yaitu admin utama dan admin management, masing-masing dengan akses yang terpisah untuk menjalankan tugas-tugas mereka.
## Features
Berikut ini adalah beberapa fitur yang disediakan oleh admin utama:

1. **Entri Data Alat dan Operator/Teknisi**: Admin utama dapat dengan mudah memasukkan data alat ukur dan operator/teknisi sebelum dikirimkan ke bagian manajemen alat untuk ditindaklanjuti.
2. **Menu Refused, Pembukuan, dan Re-submit**: Aplikasi ini menyediakan menu khusus untuk menangani alat-alat yang ditolak, pembukuan, dan pengajuan ulang dengan cara yang menakjubkan.
3. **Current Borrowing**: Fitur ini memungkinkan admin utama untuk melacak alat ukur yang sedang dipinjam oleh para teknisi dengan tampilan yang menarik.
4. **Rekapan Peminjaman**: Aplikasi ini memberikan laporan dan rekapan yang komprehensif tentang seluruh peminjaman alat dengan tampilan luar biasa.
5. **Data Alat Ukur**: Admin utama dapat dengan mudah mengelola dan memperbarui data alat ukur yang tersedia dengan cara yang elegan.
6. **Data Teknisi atau Pegawai**: Aplikasi ini menyimpan informasi tentang teknisi atau pegawai yang terlibat dalam peminjaman alat dengan antarmuka yang menawan.
7. **Data Pengelola (Admin)**: Admin utama dapat mengatur dan mengelola pengguna atau admin lainnya dalam sistem dengan tampilan yang mengagumkan.
8. **Laporan Menggunakan Crystal Report**: Aplikasi ini menyediakan laporan yang lengkap dan terstruktur menggunakan Crystal Report, memberikan informasi yang jelas dan menarik bagi pengguna.

Selain itu, terdapat juga Form Management yang dapat diakses menggunakan akun admin2:

- **Username**: admin2
- **Password**: admin2

Form Management memungkinkan admin management untuk mengelola aspek-aspek penting dalam peminjaman alat ukur, termasuk permintaan peminjaman, rekapan peminjaman, data alat ukur, dan data teknisi atau pegawai dengan sentuhan seni yang memukau.

Aplikasi ini dirancang untuk mendukung penggunaan multi user/admin dengan syarat satu pengguna berperan sebagai server, memberikan

 fleksibilitas yang luar biasa. Dengan demikian, aplikasi ini dapat digunakan secara efisien, untuk mengoptimalkan proses peminjaman alat ukur dengan keanggunan yang mempesona.
## Running Test
Untuk menjalankan mentahan aplikasi ini, ikuti langkah-langkah berikut:

Langkah 1:

1. Mulailah dengan mengunduh Visual Studio 2019 melalui [tautan ini](https://visualstudio.microsoft.com/vs/older-downloads/). Setelah selesai diunduh, lakukan instalasi dengan penuh semangat mengikuti petunjuk yang disediakan.
2. Selanjutnya, unduh Crystal Report for VS2019 dari [tautan ini](https://www.sap.com/cmp/td/sap-crystal-reports-developer-trial.html) dan lakukan instalasi dengan penuh kecermatan mengikuti instruksi yang disediakan.
3. Untuk langkah selanjutnya, unduh XAMPP versi 5.6 melalui [tautan ini](https://www.apachefriends.org/download.html) dan ikuti proses instalasinya dengan penuh keahlian sesuai instruksi yang ada.
4. Dalam langkah berikutnya, unduh Connector/ODBC 8.0 melalui [tautan ini](https://dev.mysql.com/downloads/connector/odbc/). Setelah itu, lakukan instalasi dengan penuh perhatian hingga selesai.
5. Lanjutkan dengan mengunduh file db_utc.sql melalui [tautan ini](https://drive.google.com/file/d/1qxTo2TYMQ5nyecRzg_pCuD7pTUUeIf3D/view?usp=sharing) dan lakukan impor file tersebut ke dalam MySQL yang telah diinstal pada langkah sebelumnya (Langkah 3). Dan jangan lupa unduh mentahan Aplikasi SIPAU nya di atas!
6. Pastikan bahwa PC atau laptop Anda sudah menginstal Net Framework 4.5. Jika belum, Anda dapat mengunduhnya dengan penuh semangat melalui [tautan ini](https://dotnet.microsoft.com/download/dotnet-framework/net45).
7. Jangan lupa untuk membuat koneksi ODBC. Caranya, buka panel kontrol ODBC pada sistem operasi Anda dan ikuti petunjuk yang ada dengan cerdas.
8. Setelah langkah-langkah di atas selesai, aplikasi siap untuk dijalankan dan Anda akan menikmati pengalaman yang luar biasa!
9. Jika Anda mengalami error saat menjalankan aplikasi, cobalah menghapus dan menambahkan kembali mysql.data.dll pada referensi aplikasi Anda dengan penuh kesabaran dan ketelitian.
## Setup Only
Jika anda hanya ingin menjalankan yang sudah aplikasi jadinya, anda hanya tinggal [Unduh pada tautan ini](https://drive.google.com/file/d/11WkGAbL_Y9qtiZEs5MwoRbaeGJ69eCe3/view?usp=sharing). Jika ada error pastikan Net Framework dan Crystall Report nya sudah terinstall,
## Screenshots

![App Screenshot](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEj8cCLkc2HcLSupKVKpsyrBA7ORl2YaLgq-MaMsz7nYVdNlMy6eZ_9meVQifCbUjwxSC0Q3gr1FpeK_ENyHovYQEYpTwh_dg_ASQg89A2tmERHrzcblarzo5fURg-o4pSPudPQJkYsQm4RprCIyWXOrPyQmxwWHLPWEMCvXFlk3EY5YVef-uYWalzlQNg/s1280/WhatsApp%20Image%202022-11-14%20at%2003.03.47.jpeg)

![App Screenshot](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhIaC5gUvVow_rSFjcpO5kzhMT7KTY3hqKyo-Mgjw8xgh80r9H240dPdLiGq3eCr48S_rq3pwOx7pJgbv50qlt_enT11Hv16NGe4uuvaDreoKLnCSQQVTKPgqJo8CSZkNfOuITUYXr2PNa6tcFO6o5PC4g2__Lrm-gPJrRRFaAyDh1yG_iFLFMl7gO41Q/s1280/WhatsApp%20Image%202022-11-13%20at%2021.34.11.jpeg)

![App Screenshot](https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEhZD7YFKnYhoS2gg6843dwNBpdiYm4F_2kzY3DVCjcIg991_3Tn_M0ziD7Er3vNbYR5HkfkJP-SLEBOdqMlw0Siz432vCb0TjnbOLDF2iXziqoGQON3V8Gv5-Y6uZ09gaQPv7UuNaonP839bSiHhqcLaP_RFHfX5tYInVhY3TeKrya553FDBtU3dnozKQ/s1280/WhatsApp%20Image%202022-11-13%20at%2023.34.09.jpeg)
