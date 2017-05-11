-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 10, 2017 at 07:36 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mapsdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `cafedb`
--

CREATE TABLE IF NOT EXISTS `cafedb` (
  `Name` text COLLATE utf8_unicode_ci NOT NULL,
  `Address` text COLLATE utf8_unicode_ci NOT NULL,
  `Long` double NOT NULL,
  `Lat` double NOT NULL,
  `Phone Number` text COLLATE utf8_unicode_ci NOT NULL,
  `Website` text COLLATE utf8_unicode_ci NOT NULL,
  `Opening Hour` text COLLATE utf8_unicode_ci NOT NULL,
  `Closing Hour` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `cafedb`
--

INSERT INTO `cafedb` (`Name`, `Address`, `Long`, `Lat`, `Phone Number`, `Website`, `Opening Hour`, `Closing Hour`) VALUES
('Tashir', 'Xanjyan', 11, 10, '010633456', 'www.menu.am', '10:30', '22:30'),
('Tashir', 'Xorenaci', 10, 10, '010633456', 'www.menu.am', '10:30', '22:30');

-- --------------------------------------------------------

--
-- Table structure for table `usersdb`
--

CREATE TABLE IF NOT EXISTS `usersdb` (
  `User` text COLLATE utf8_unicode_ci NOT NULL COMMENT 'user username',
  `Password` text COLLATE utf8_unicode_ci NOT NULL COMMENT 'user password'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `usersdb`
--

INSERT INTO `usersdb` (`User`, `Password`) VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
