-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 09 Agu 2019 pada 05.12
-- Versi Server: 10.1.13-MariaDB
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_utc`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `admin`
--

CREATE TABLE `admin` (
  `id_user` int(11) NOT NULL,
  `nama_user` varchar(35) NOT NULL,
  `user` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL,
  `akses` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `admin`
--

INSERT INTO `admin` (`id_user`, `nama_user`, `user`, `pass`, `akses`) VALUES
(1, 'admin', 'admin', 'admin', 'admin_operator'),
(3, 'asdsa', 'asdasd', 'asd', 'admin_operator'),
(5, 'asdsa', 'asdasd', '123', 'admin_operator'),
(6, 'asdsa', 'asdasd1', '123123', 'admin_operator'),
(7, 'asdsa', 'asdasd11', '123455', 'admin_operator');

-- --------------------------------------------------------

--
-- Struktur dari tabel `alat_ukur`
--

CREATE TABLE `alat_ukur` (
  `id_alat` varchar(11) NOT NULL,
  `uraian_alat` varchar(50) NOT NULL,
  `stok_alat` int(11) NOT NULL,
  `satuan` varchar(10) NOT NULL,
  `tgl` date NOT NULL,
  `status_alat` varchar(15) NOT NULL,
  `ket` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `alat_ukur`
--

INSERT INTO `alat_ukur` (`id_alat`, `uraian_alat`, `stok_alat`, `satuan`, `tgl`, `status_alat`, `ket`) VALUES
('A03', 'asd', 2323, 'Set', '2019-08-08', 'Baik', ''),
('A04', '12312', 12213, 'Set', '2019-08-16', 'Baik', ''),
('A05', 'a', 5, 'Buah', '2019-08-01', 'Buah', 'erwr'),
('A06', 'asdas', 2343, 'Set', '2019-08-08', 'Set', 'asdas'),
('A07', 'asdas', 2343, 'Set', '2019-08-08', 'Baik', 'asdas'),
('A08', 'asdas', 2343, 'Box', '2019-08-08', 'Tidak Layak', 'a');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pegawai`
--

CREATE TABLE `pegawai` (
  `id_operator` varchar(11) NOT NULL,
  `nama` varchar(35) NOT NULL,
  `gender` varchar(25) NOT NULL,
  `alamat` longtext NOT NULL,
  `sebagai` varchar(35) NOT NULL,
  `cell` varchar(35) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pegawai`
--

INSERT INTO `pegawai` (`id_operator`, `nama`, `gender`, `alamat`, `sebagai`, `cell`) VALUES
('P02', 'a', 'Perempuan', 'a', 'C2 Instrument', '3'),
('P03', 'asda', 'Laki - Laki', 'asdas', 'A1 Rotary', '1'),
('P04', 'asdas', 'Laki - Laki', '', 'A1 Rotary', '1'),
('P05', 'asdsads', 'Laki - Laki', '', 'A1 Rotary', '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pinjam_kembali`
--

CREATE TABLE `pinjam_kembali` (
  `id_pinjam` int(11) NOT NULL,
  `validasi` varchar(15) NOT NULL,
  `id_alat` varchar(11) NOT NULL,
  `id_operator` varchar(11) NOT NULL,
  `qty` varchar(3) NOT NULL,
  `tgl_pinjam` date NOT NULL,
  `tgl_akhirpinjam` date NOT NULL,
  `durasi` varchar(10) NOT NULL,
  `ket` longtext NOT NULL,
  `tgl_pengembalian` date NOT NULL,
  `status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `pinjam_kembali`
--

INSERT INTO `pinjam_kembali` (`id_pinjam`, `validasi`, `id_alat`, `id_operator`, `qty`, `tgl_pinjam`, `tgl_akhirpinjam`, `durasi`, `ket`, `tgl_pengembalian`, `status`) VALUES
(2, 'submit', 'A06', 'P03', '3', '2019-08-09', '2019-08-31', '21', 'asdasd', '0000-00-00', ''),
(12, 'submit', 'A06', 'P03', '2', '2019-08-16', '2019-09-05', '21', '', '0000-00-00', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_user`);

--
-- Indexes for table `alat_ukur`
--
ALTER TABLE `alat_ukur`
  ADD PRIMARY KEY (`id_alat`);

--
-- Indexes for table `pinjam_kembali`
--
ALTER TABLE `pinjam_kembali`
  ADD PRIMARY KEY (`id_pinjam`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `pinjam_kembali`
--
ALTER TABLE `pinjam_kembali`
  MODIFY `id_pinjam` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
