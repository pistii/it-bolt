-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Máj 01. 18:05
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `it_bolt`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bolt`
--

CREATE TABLE `bolt` (
  `boltID` int(11) NOT NULL,
  `raktarID` int(11) DEFAULT NULL,
  `rendelesID` int(11) DEFAULT NULL,
  `bolt_neve` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `bolt_cime` varchar(100) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `nyitvatartasi_ido` varchar(15) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `bolt`
--

INSERT INTO `bolt` (`boltID`, `raktarID`, `rendelesID`, `bolt_neve`, `bolt_cime`, `nyitvatartasi_ido`) VALUES
(1, NULL, NULL, 'Bolt 123', 'Szeged', 'H-P 10-18'),
(2, NULL, NULL, 'Bolt 2', 'Budapest', 'H-P 10-18'),
(3, 23, NULL, 'Bolt 3', 'Algyő', 'H-P 12-15'),
(4, NULL, NULL, 'Bolt 4', 'Szőreg', 'H-P 7-19'),
(5, 2, NULL, 'Bolt 5', 'Pécs', 'H-P 6-18'),
(7, NULL, NULL, 'IT bolt ', 'Győr', 'h-p 10-12'),
(8, NULL, NULL, 'Tuti Butik', 'Hódmezővásárhely', 'H-P 10-12'),
(9, 8, NULL, 'Tutika Butika', 'Hódmezővásárhely', 'H-P 10-18'),
(10, 1, NULL, 'Tuti Butik 2', 'Algyő', 'H-K 8-9'),
(11, NULL, NULL, 'TESCO', 'Makó Sziget sor  9', ' 6:00-23:00'),
(12, 61, NULL, 'TESCO', 'Makó Bánya tér  19', ' 5:00-23:00'),
(13, 5, NULL, 'Nagy IT SHOP', 'Makó Kárász utca  19', 'H-P 8:00-18:00'),
(14, NULL, NULL, 'Kis IT SHOP', 'Makó Sukovec  utca  3', 'H-P 8:00-18:00'),
(15, NULL, NULL, 'Pingvin IT SHOP', 'Makó Turi utca  1', 'H-P 8:00-18:00'),
(16, NULL, NULL, 'Sóhers SHOP', 'Makó Sós  utca  103', 'H-P 8:00-19:00'),
(17, NULL, NULL, 'IT SHOP HUN', 'Makó Móra utca  109', 'H-P 8:00-19:00'),
(18, 21, NULL, 'Kiss SHOP', 'Makó Szúnyog  utca  30', 'H-P 8:00-18:00 '),
(19, 40, NULL, 'Gyalog SHOP', 'Makó Tv utca  10', 'H-P 8:00-18:00 '),
(20, NULL, NULL, 'Modul SHOP', 'Makó Nagy  utca  120', 'H-P 8:00-18:00 '),
(21, 59, NULL, 'Nagy BOLT', 'Kecskés Lajka utca  17', ' 0:00-24:00'),
(22, NULL, NULL, 'Nyakas BOLT', 'Kecskés Baka utca 1 9', ' 0:00-24:00'),
(23, NULL, NULL, 'TESCO', 'Kecskés Nagyteleki sor  29', ' 6:00-23:00'),
(24, 44, NULL, 'TESCO', 'Kecskés Oszvald tér  1', ' 5:00-23:00'),
(25, NULL, NULL, 'NIT SHOP', 'Kecskés Mák utca  1', 'H-P 8:00-18:00'),
(26, NULL, NULL, 'IT SHOP', 'Kecskés Florensz  utca  31', 'H-P 8:00-18:00'),
(27, NULL, NULL, 'Tomas IT SHOP', 'Kecskés Tomas utca  41', 'H-P 8:00-18:00'),
(28, NULL, NULL, 'Fix SHOP', 'Kecskés Póker  utca  13', 'H-P 8:00-19:00'),
(29, NULL, NULL, 'IT SHOP 2000 KFT', 'Kecskés Móra utca  19', 'H-P 8:00-19:00'),
(30, NULL, NULL, 'Bizalom SHOP', 'Kecskés Béka  utca  3', 'H-P 8:00-18:00 '),
(31, 55, NULL, 'Big mini shop', 'Kecskés Fekete utca  1', 'H-P 8-18\r\nSZ 8-'),
(32, NULL, NULL, 'Test SHOP', 'Kecskés Nagy  utca  12', 'H-P 8-18 \r\nSZ 8'),
(33, 60, NULL, 'Joanne BOLT', 'Nagylak Holmes 12 utca  17', ' 0:00-24:00'),
(34, NULL, NULL, 'Marilyn BOLT', 'Nagylak Castaneda utca 1 ', ' 0:00-24:00'),
(35, NULL, NULL, 'Syeda', 'Nagylak Cameron sor  29', ' 6:00-23:00'),
(36, NULL, NULL, 'Syeda', 'Nagylak Burnett tér  1', ' 5:00-23:00'),
(37, NULL, NULL, 'NIT SHOP', 'Nagylak Bullock utca  1', 'H-P 8:00-18:00'),
(38, NULL, NULL, 'Shauna SHOP', 'Nagylak Trujillo  utca  3', 'H-P 8:00-18:00'),
(39, 47, NULL, 'Jessica IT SHOP', 'Budapest Brennan utca  41', 'H-P 8:00-18:00'),
(40, NULL, NULL, 'Ruben SHOP', 'Budapest Duke  utca  13', 'H-P 8:00-19:00'),
(41, NULL, NULL, 'Georgina SHOP 2000 KFT', 'Budapest Ramirez utca  109', 'H-P 8:00-19:00'),
(42, NULL, NULL, 'Georgina  SHOP', 'Budapest Bowers  utca  3', 'H-P 8:00-18:00 '),
(43, NULL, NULL, 'Lewys SHOP', 'Budapest Bowers utca  12', 'H-P 8-18\r\nSZ 8-'),
(44, 26, NULL, 'Izaak SHOP', 'Budapest Rice  utca  12', 'H-P 8-18 \r\nSZ 8'),
(45, NULL, NULL, 'Lance BOLT', 'Budapest Murphy utca 1 9', ' 0:00-24:00'),
(46, NULL, NULL, 'TESCO', 'Budapest Wu sor  29', ' 6:00-23:00'),
(47, NULL, NULL, 'TESCO', 'Budapest Sanchez tér  18', ' 5:00-23:00'),
(48, NULL, NULL, 'Marley  SHOP', 'Budapest O\'Neill utca  21', 'H-P 8:00-18:00'),
(49, NULL, NULL, 'Archibald IT SHOP', 'Szentgotthárd Owens  utca  1', 'H-P 8:00-18:00'),
(50, 37, NULL, 'Erica IT SHOP', 'Szentgotthárd House utca  4', 'H-P 8:00-18:00'),
(51, NULL, NULL, 'Billy  SHOP', 'Szentgotthárd Williamson  utca  15', 'H-P 8:00-19:00'),
(52, NULL, NULL, 'Sanaa  SHOP 2000 KFT', 'Szentgotthárd Dillon utca  9', 'H-P 8:00-19:00'),
(53, NULL, NULL, 'Corey  SHOP', 'Szentgotthárd Molina  utca  3', 'H-P 8:00-18:00 '),
(54, NULL, NULL, 'Abdullah mini SHOP', 'Szentgotthárd Briggs utca 4', 'H-P 8-18\r\nSZ 8-'),
(55, 12, NULL, 'Benjamin  SHOP', 'Szentgotthárd Day  utca  12', 'H-P 8-18 \r\nSZ 8'),
(56, NULL, NULL, 'Nyakas BOLT', 'Budapest Harrison utca 1 9', ' 0:00-24:00'),
(57, NULL, NULL, 'Elsa Bolt', 'Budapest Clements sor  2', ' 6:00-23:00'),
(58, NULL, NULL, 'Nicola Bolt', 'Budapest Hines tér  12', ' 5:00-23:00'),
(59, 8, NULL, 'Mateo  SHOP', 'Budapest Henry utca  1', 'H-P 8:00-18:00'),
(60, NULL, NULL, 'Shannon  SHOP', 'Budapest Hernandez  utca  31', 'H-P 8:00-18:00'),
(61, NULL, NULL, 'Florensz IT SHOP', 'Budapest Benton utca  40', 'H-P 8:00-18:00'),
(62, 42, NULL, 'FiLm SHOP', 'Budapest Mcdowell  utca  3', 'H-P 8:00-19:00'),
(63, NULL, NULL, 'SHOP 2022 KFT', 'Budapest Parker utca  96', 'H-P 8:00-19:00'),
(64, NULL, NULL, 'Bizalom SHOP', 'Budapest Montes  utca  3', 'H-P 8:00-18:00 '),
(65, 18, NULL, 'BFC SHOP', 'Budapest Burke utca  10', 'H-P 8-18\r\nSZ 8-'),
(66, NULL, NULL, 'TTT SHOP', 'Budapest Nagymama  utca  2', 'H-P 8-18 \r\nSZ 8'),
(67, 2, NULL, 'ST Supermarkez', '6720 Szeged Dózsa utca 9', 'H-P 6:00-20:00'),
(68, NULL, NULL, 'KIS BOLT', 'Makó Lantos utca  6', ' 0:00-24:00'),
(69, NULL, NULL, 'Nagy BOLT', 'Makó Lantos utca  7', ' 0:00-24:00'),
(70, NULL, NULL, 'Nagy BOLT', 'Makó Lantos utca  9', ' 0:00-24:00'),
(71, 3, NULL, 'Bolt 125', 'Sopron', 'H-P 10-12'),
(72, NULL, NULL, 'MikkMakk', 'MikkMakk utca', 'H-K 8-10'),
(84, NULL, NULL, 'Tuti Butik', 'Szeged', 'H-K 8-9'),
(91, 59, NULL, 'Teszt név', 'Teszt Cím', 'H-P 8-18'),
(94, 1, NULL, '123231132 Bolt KFT.', '123231132123 Bolt', 'H-P 8:00 - 16');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eszkoz`
--

CREATE TABLE `eszkoz` (
  `eszkozID` int(11) NOT NULL,
  `gyartoID` int(11) DEFAULT NULL,
  `eszkoz_neve` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `eszkoz_ara` int(11) DEFAULT NULL,
  `eszkoz_sorozatszama` varchar(25) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `eszkoz_gyartas_ev` date DEFAULT NULL,
  `kategoriaID` int(11) DEFAULT NULL,
  `raktar_keszlet` int(11) DEFAULT NULL,
  `garancialis_e` bit(1) DEFAULT NULL,
  `kedvezmenyes_e` bit(1) DEFAULT NULL,
  `eszkoz_tipus` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `eszkoz`
--

INSERT INTO `eszkoz` (`eszkozID`, `gyartoID`, `eszkoz_neve`, `eszkoz_ara`, `eszkoz_sorozatszama`, `eszkoz_gyartas_ev`, `kategoriaID`, `raktar_keszlet`, `garancialis_e`, `kedvezmenyes_e`, `eszkoz_tipus`) VALUES
(13, 1, 'Kis Masina', 1230, 'a1fgf3578x', '2023-03-27', 1, 60, b'1', b'1', 'Csúcsszuper'),
(14, 2, 'Nagy Masina', 6060, '10xvcx2356', '2040-01-01', 3, 65, b'1', b'0', 'Laptop'),
(15, 4, 'Közepesen Jó masina RAM', 5555, '1xgz78954fdg', '2022-11-17', 3, 69, b'1', b'0', 'tuti'),
(22, 3, 'Simonizer', 1000, 'VCA42', '2022-01-09', 1, 20, b'1', b'0', '1'),
(23, 2, 'SimonizerPhone', 20000, 'VCA43', '2022-02-09', 1, 20, b'0', b'1', '1'),
(24, 3, 'Mikezer', 30000, 'VCA44', '2022-03-09', 1, 20, b'1', b'1', '1'),
(25, 1, 'MScott Devoner', 40000, 'VCA46', '2022-04-09', 1, 20, b'0', b'1', '1'),
(26, 2, 'tt Devoner', 50000, 'VCA48', '2022-05-09', 1, 30, b'1', b'0', '1'),
(27, 3, 'tt Devoner', 60000, 'VCA49', '2022-06-09', 1, 30, b'1', b'1', '1'),
(28, 4, 'tt Devoner', 90000, 'CA490', '2022-07-09', 1, 30, b'1', b'1', '2'),
(29, 1, 'tt Devoner', 45000, 'CA491', '2022-08-09', 1, 30, b'1', b'1', '3'),
(30, 2, 'tt Devoner', 31000, 'CA492', '2022-09-09', 1, 30, b'1', b'1', '4'),
(31, 3, 'tt Devoner', 3000, 'CA493', '2022-01-09', 1, 30, b'1', b'1', '2'),
(32, 4, 'Snizer Asia', 90000, 'CA494', '2022-02-09', 1, 20, b'1', b'1', '2'),
(33, 3, 'Snizer Asia Phone', 160000, 'CA495', '2022-03-09', 1, 20, b'1', b'1', '1'),
(34, 2, 'Snizer Asia', 3000, 'CA496', '2022-04-09', 1, 20, b'1', b'1', '1'),
(35, 1, 'Snizer AsiaPhone', 10000, 'CA4907', '2022-05-09', 1, 20, b'1', b'1', '1'),
(36, 1, 'Snizer Asia', 30000, 'CA498', '2022-06-09', 1, 20, b'1', b'1', '1'),
(38, 1, 'SimoChaya Chayanizer', 30000, 'CAB120', '2022-08-09', 1, 20, b'1', b'1', '1'),
(39, 2, 'Chaya Chaya', 15000, 'CAB121', '2022-09-09', 1, 1, b'1', b'1', '1'),
(40, 2, 'Chaya Chaya', 2000, 'CAB122', '2022-01-09', 1, 1, b'1', b'0', '1'),
(41, 2, 'Chaya123', 2000, 'CAB123', '2022-02-09', 1, 1, b'0', b'1', '1'),
(42, 2, 'Chaya Chaya', 7000, 'CDB124', '2022-03-09', 1, 1, b'0', b'1', '1'),
(43, 1, 'Chaya Chaya123', 80000, 'CAB125', '2022-04-09', 1, 600, b'0', b'1', '1'),
(44, 2, 'Lewis 1', 900012, 'CAB126', '2022-05-09', 1, 1, b'1', b'1', '1'),
(45, 2, 'LewisPhone', 1233, 'CAB127', '2022-06-09', 1, 20, b'1', b'1', '4'),
(46, 2, 'Lewis 200', 4000, 'CAB128', '2022-04-09', 1, 1, b'1', b'1', '4'),
(47, 1, 'Lewis 300', 80000, 'CAB129', '2022-05-09', 1, 1, b'1', b'1', '1'),
(48, 3, 'Lewis 400', 70000, 'CAB130', '2022-06-09', 1, 2, b'1', b'1', '4'),
(49, 3, 'Lewis 5000', 70001, 'AAB130', '2022-07-09', 1, 2, b'1', b'1', '1'),
(76, 3, 'Coffey Coffey', 160000, 'ACA121', '2022-08-09', 1, 2, b'1', b'1', '3'),
(77, 4, 'Casta Carantha', 7000, 'AAB132', '2022-09-09', 1, 2, b'1', b'1', '1'),
(78, 4, 'Coffey Coffey', 3500, 'AAB133', '2022-01-09', 1, 2, b'1', b'1', '1'),
(79, 4, 'Reeveszer', 600, 'AAB134', '2022-02-09', 1, 2, b'1', b'1', '1'),
(80, 4, 'Reeveszer', 20000, 'AAB138', '2022-03-09', 1, 4, b'1', b'1', '2'),
(81, 2, 'ReeveszerPhone', 90000, 'AAB139', '2022-04-09', 1, 4, b'0', b'1', '1'),
(82, 1, 'Reeveszer', 80000, 'AB130C', '2022-05-09', 1, 4, b'1', b'1', '1'),
(83, 3, 'Reeveszer', 70000, 'AB131C', '2022-06-09', 1, 4, b'1', b'1', '1'),
(84, 3, 'Reeveszer', 80000, 'AB120C', '2022-07-09', 1, 4, b'1', b'1', '4'),
(85, 3, 'SimonReeveszerizer Phone', 90000, 'AB133C', '2022-08-09', 1, 4, b'1', b'0', '2'),
(86, 3, 'Reeveszer', 3100, 'AB134C', '2022-09-09', 1, 4, b'1', b'1', '1'),
(87, 2, 'Reeveszer', 21000, 'AB135C', '2022-03-09', 1, 4, b'1', b'1', '1'),
(88, 1, 'Reeveszer Phone', 30000, 'AB136C', '2022-03-09', 1, 4, b'1', b'1', '1'),
(89, 2, 'Simonizer', 30000, 'va597', '2022-03-09', 1, 20, b'1', b'1', '1'),
(90, 4, 'Michaeler', 3000, '59782', '2022-06-09', 1, 2, b'1', b'1', '1'),
(91, 1, 'Woodyzer Phone', 200000, 'TA123', '2023-03-09', 1, 20, b'0', b'1', '1'),
(97, 3, 'Teszt eszköz', 1234, '12345', '2023-02-14', 4, 123, b'0', b'0', NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `id` int(11) NOT NULL,
  `nev` varchar(15) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `jelszo` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`id`, `nev`, `jelszo`) VALUES
(1, 'Jack Daniels', '$2a$11$AOsuFdcnRd6Maa4jnwzIYOi6a5v2XHZEfCjdohU3KY2XxnqglxjAW'),
(2, 'admin', '$2a$11$FBLrMnMv76MaMtiWgrQnUOyQ3Bd.X5CIPNSuLwePSsbjTqhzQshPq'),
(4, 'aaa', '$2a$11$vYQFXHyUtZBeIhTkCMbjHebSgRhGZ8CveDPv18IImIaEJeqKviCTq'),
(5, 'mikkmakk', '$2a$11$OhFZ3Xxd8cssUJYJRbalB.MDa.8rKoC.dyuzqNWwKOnL0ohh25xI6'),
(10, '100', '$2a$11$ADyK92pBrx3Z3vbyr9FtJ.uwXL4ZCoacXTdKd3MobH4kBtHytuI8y'),
(11, '1000', '$2a$11$QIT6ugxm0DAquEoZrxKLD.sXNR.uf4a4qAbvqYsipblKTq52BhNYu');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyarto`
--

CREATE TABLE `gyarto` (
  `gyartoID` int(11) NOT NULL,
  `gyarto_neve` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `gyarto_szekhelye` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `gyarto`
--

INSERT INTO `gyarto` (`gyartoID`, `gyarto_neve`, `gyarto_szekhelye`) VALUES
(1, 'Acer', 'Arcadia'),
(2, 'MSI', 'Arnside Lea'),
(3, 'HP', 'Back Avenue Victoria'),
(4, 'Kingston', 'Jesmond Highway');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoria`
--

CREATE TABLE `kategoria` (
  `kategoriaID` int(11) NOT NULL,
  `kategoria_nev` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `kategoria`
--

INSERT INTO `kategoria` (`kategoriaID`, `kategoria_nev`) VALUES
(1, 'laptop'),
(2, 'videokártya'),
(3, 'memória'),
(4, 'processzor'),
(5, 'monitor');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `leltarieszkoz`
--

CREATE TABLE `leltarieszkoz` (
  `eszkozID` int(11) NOT NULL,
  `boltID` int(11) NOT NULL,
  `leltariszam` varchar(25) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `leltarieszkoz`
--

INSERT INTO `leltarieszkoz` (`eszkozID`, `boltID`, `leltariszam`) VALUES
(1, 5, 'ab1'),
(2, 3, 'ad3'),
(4, 1, 'd43'),
(5, 3, 'cd545'),
(7, 1, 'BA12]'),
(8, 2, 'BA12]'),
(18, 3, 'BA12]'),
(19, 4, 'BA12]'),
(20, 4, 'BA12]'),
(21, 4, 'BA12]'),
(22, 4, 'BA12]'),
(23, 4, 'BA121]'),
(24, 4, 'BA122]'),
(25, 4, 'BA123]'),
(26, 4, 'BA124]'),
(27, 5, 'BA125]'),
(28, 5, 'BA126]'),
(29, 5, 'BA129]'),
(30, 5, 'BAC12]'),
(31, 5, 'BAC112]'),
(32, 5, 'BAC212]'),
(33, 5, 'BAC312]'),
(34, 5, 'BAC412]'),
(35, 5, 'BAC512]'),
(36, 1, 'VA25B'),
(37, 1, 'VA25C'),
(38, 1, 'VA25V'),
(39, 1, 'VA25N'),
(40, 1, 'VA25M'),
(41, 1, 'VA25Q'),
(42, 1, 'VA25W'),
(43, 1, 'VA25E'),
(44, 1, 'VA25R'),
(45, 1, 'VA25T'),
(46, 1, 'VA25Z'),
(47, 1, 'VA25U'),
(48, 1, 'VA25I'),
(49, 1, 'VA25O'),
(76, 2, 'CVA25CC'),
(77, 2, 'CVA25VC'),
(78, 2, 'CVA25NC'),
(79, 3, 'CVA25MC'),
(80, 3, 'CVA25QC'),
(81, 5, 'CVA25WC'),
(82, 5, 'CVA25EC'),
(83, 7, 'CVA25TC'),
(84, 8, 'CVA25ZC'),
(85, 9, 'CVA25UC'),
(86, 10, 'CVA25IC'),
(87, 11, 'CVA25OC'),
(88, 2, 'CVA25CC'),
(89, 12, 'CVA25VC'),
(90, 22, 'CVA25NC'),
(91, 43, 'CVA25MC'),
(92, 33, 'CVA25QC'),
(93, 35, 'CVA25WC'),
(94, 25, 'CVA25EC'),
(95, 17, 'CVA25TC'),
(96, 18, 'CVA25ZC'),
(97, 9, 'CVA25UC'),
(98, 14, 'CVA25IC'),
(99, 13, 'CVA25OC'),
(100, 2, 'BBB2Q'),
(101, 12, 'BBB2W'),
(102, 22, 'BBB2Q1'),
(103, 43, 'BBB2Q2'),
(104, 33, 'BBB2Q3'),
(105, 35, 'BBB2Q4'),
(106, 25, 'BBB2Q5'),
(107, 17, 'BBB2Q6'),
(108, 18, 'BBB2Q7'),
(109, 9, 'BBB2Q8'),
(110, 14, 'BBB2Q9'),
(111, 13, 'BBB2Q10');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `raktar`
--

CREATE TABLE `raktar` (
  `raktarID` int(11) NOT NULL,
  `raktar_neve` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `raktar_helye` varchar(100) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `Berlesi_ido` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `raktar`
--

INSERT INTO `raktar` (`raktarID`, `raktar_neve`, `raktar_helye`, `Berlesi_ido`) VALUES
(1, 'raktár 1', 'Szeged', '2022-01-02'),
(2, 'raktár 2', 'Budapest', '2017-02-20'),
(3, 'raktár 3', 'Algyő', '2005-04-07'),
(4, 'raktár 4', 'Szigetszentmiklós', '2010-05-10'),
(5, 'raktár 5', 'Pécs', '2012-12-12'),
(8, 'RB100', 'Budapest', '2022-08-02'),
(9, 'RB101', 'Sopron', '2016-01-19'),
(12, 'raki2', 'raki2', '2023-04-11'),
(14, 'R69', 'SZEGED', '2023-01-02'),
(15, 'R79', 'SZEGED', '2022-01-02'),
(16, 'R89', 'SZEGED', '2024-01-02'),
(17, 'R99', 'SZEGED', '2025-01-02'),
(18, 'R91', 'SZEGED', '2024-01-02'),
(19, 'R92', 'SZEGED', '2025-01-02'),
(20, 'R93', 'SZEGED', '2024-01-02'),
(21, 'R94', 'SZEGED', '2025-01-02'),
(22, 'R95', 'SZEGED', '2024-01-02'),
(23, 'R96', 'SZEGED', '2025-01-02'),
(24, 'R97', 'SZEGED', '2024-01-02'),
(25, 'R9', 'Budapest', '2023-01-02'),
(26, 'RB', 'Budapest', '2023-03-02'),
(27, 'RB39', 'Budapest', '2023-04-02'),
(28, 'RB49', 'Budapest', '2023-05-02'),
(29, 'RB59', 'Budapest', '2023-06-02'),
(30, 'RB69', 'Budapest', '2023-07-02'),
(31, 'RB79', 'Budapest', '2022-08-02'),
(32, 'RB89', 'Budapest', '2024-09-02'),
(33, 'RB99', 'Budapest', '2025-11-02'),
(34, 'RB91', 'Budapest', '2024-12-02'),
(35, 'RB92', 'Budapest', '2025-01-02'),
(36, 'RB93', 'Budapest', '2024-03-02'),
(37, 'RB94', 'Budapest', '2025-04-02'),
(38, 'RB95', 'Budapest', '2024-05-02'),
(39, 'RB96', 'Budapest', '2025-06-02'),
(40, 'RB97', 'Budapest', '2024-07-02'),
(41, 'R9', 'Algyő', '2023-01-02'),
(42, 'RA', 'Algyő', '2023-03-03'),
(43, 'RA39', 'Algyő', '2023-04-04'),
(44, 'RA49', 'Algyő', '2023-05-05'),
(45, 'RA59', 'Algyő', '2023-06-06'),
(46, 'RA69', 'Algyő', '2023-07-07'),
(47, 'RA79', 'Algyő', '2022-08-08'),
(48, 'RA89', 'Algyő', '2024-09-09'),
(49, 'RA99', 'Algyő', '2025-11-01'),
(50, 'RA91', 'Algyő', '2024-12-12'),
(51, 'RA92', 'Algyő', '2025-01-12'),
(52, 'RA93', 'Algyő', '2024-03-12'),
(53, 'RA94', 'Algyő', '2025-04-12'),
(54, 'RA95', 'Algyő', '2024-05-12'),
(55, 'RA96', 'Algyő', '2025-06-12'),
(56, 'RA97', 'Algyő', '2024-07-12'),
(57, 'R9', 'SZEGED', '2023-01-02'),
(58, 'R55', 'Budapest', NULL),
(59, 'R39', 'Győr', '1940-12-24'),
(60, 'R49', 'SZEGED', '2023-01-02'),
(61, 'R59', 'SZEGED', '2023-01-02'),
(62, 'R8', 'SZEGED', '2022-01-02'),
(63, 'CDA40', 'London Bd sqr. 40', '2022-07-20');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlas`
--

CREATE TABLE `vasarlas` (
  `vasarloID` int(11) NOT NULL,
  `rendelesID` int(11) NOT NULL,
  `fizetesmod` varchar(25) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `vasarlas_datuma` date DEFAULT NULL,
  `vasarlas_tipusa` varchar(25) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `szamlazasi_cim` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `szallitasi_cim` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlo`
--

CREATE TABLE `vasarlo` (
  `vasarloID` int(11) NOT NULL,
  `vasarlo_neve` varchar(50) COLLATE utf8mb4_hungarian_ci DEFAULT NULL,
  `vasarlo_telefonszama` int(10) DEFAULT NULL,
  `vasarlo_emailcime` varchar(25) COLLATE utf8mb4_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bolt`
--
ALTER TABLE `bolt`
  ADD PRIMARY KEY (`boltID`),
  ADD KEY `raktar` (`raktarID`),
  ADD KEY `bolt_ibfk_2` (`rendelesID`);

--
-- A tábla indexei `eszkoz`
--
ALTER TABLE `eszkoz`
  ADD PRIMARY KEY (`eszkozID`),
  ADD KEY `kategoria` (`kategoriaID`),
  ADD KEY `gyartoID` (`gyartoID`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `gyarto`
--
ALTER TABLE `gyarto`
  ADD PRIMARY KEY (`gyartoID`),
  ADD KEY `gyartoID` (`gyartoID`);

--
-- A tábla indexei `kategoria`
--
ALTER TABLE `kategoria`
  ADD PRIMARY KEY (`kategoriaID`),
  ADD KEY `kategoriaID` (`kategoriaID`);

--
-- A tábla indexei `leltarieszkoz`
--
ALTER TABLE `leltarieszkoz`
  ADD PRIMARY KEY (`eszkozID`),
  ADD KEY `bolt` (`boltID`);

--
-- A tábla indexei `raktar`
--
ALTER TABLE `raktar`
  ADD PRIMARY KEY (`raktarID`);

--
-- A tábla indexei `vasarlas`
--
ALTER TABLE `vasarlas`
  ADD PRIMARY KEY (`vasarloID`,`rendelesID`),
  ADD KEY `rendelesID` (`rendelesID`);

--
-- A tábla indexei `vasarlo`
--
ALTER TABLE `vasarlo`
  ADD PRIMARY KEY (`vasarloID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `bolt`
--
ALTER TABLE `bolt`
  MODIFY `boltID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;

--
-- AUTO_INCREMENT a táblához `eszkoz`
--
ALTER TABLE `eszkoz`
  MODIFY `eszkozID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=100;

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `gyarto`
--
ALTER TABLE `gyarto`
  MODIFY `gyartoID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `kategoria`
--
ALTER TABLE `kategoria`
  MODIFY `kategoriaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `leltarieszkoz`
--
ALTER TABLE `leltarieszkoz`
  MODIFY `eszkozID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- AUTO_INCREMENT a táblához `raktar`
--
ALTER TABLE `raktar`
  MODIFY `raktarID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `bolt`
--
ALTER TABLE `bolt`
  ADD CONSTRAINT `bolt_ibfk_1` FOREIGN KEY (`raktarID`) REFERENCES `raktar` (`raktarID`),
  ADD CONSTRAINT `bolt_ibfk_2` FOREIGN KEY (`rendelesID`) REFERENCES `vasarlas` (`rendelesID`);

--
-- Megkötések a táblához `eszkoz`
--
ALTER TABLE `eszkoz`
  ADD CONSTRAINT `eszkoz_ibfk_2` FOREIGN KEY (`gyartoID`) REFERENCES `gyarto` (`gyartoID`),
  ADD CONSTRAINT `eszkoz_ibfk_3` FOREIGN KEY (`kategoriaID`) REFERENCES `kategoria` (`kategoriaID`);

--
-- Megkötések a táblához `leltarieszkoz`
--
ALTER TABLE `leltarieszkoz`
  ADD CONSTRAINT `leltarieszkoz_ibfk_1` FOREIGN KEY (`boltID`) REFERENCES `bolt` (`boltID`);

--
-- Megkötések a táblához `vasarlas`
--
ALTER TABLE `vasarlas`
  ADD CONSTRAINT `vasarlas_ibfk_1` FOREIGN KEY (`vasarloID`) REFERENCES `vasarlo` (`vasarloID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
