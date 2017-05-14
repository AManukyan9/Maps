-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 14, 2017 at 06:39 PM
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
-- Table structure for table `addressdb`
--

CREATE TABLE IF NOT EXISTS `addressdb` (
  `Address Name` text COLLATE utf8_unicode_ci NOT NULL,
  `Lat` double NOT NULL,
  `Long` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `addressdb`
--

INSERT INTO `addressdb` (`Address Name`, `Lat`, `Long`) VALUES
('Northern Ave 1/56', 10, 10),
('Abovyan 20', 10.1, 10.1),
('Tumanyan 35/30', 10.2, 10.2),
('Abovyan 2', 10.3, 10.3);

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
('Segafredo', 'Northern Ave 1/56', 10, 10, '060 521190', 'www.segafredo.it', '08:30', '02:00'),
('Jazzve', 'Tumanyan 35/30', 10.2, 10.2, '010 532048', 'www.jazzve.com', '09:00', '22:00'),
('Artbridge', 'Abovyan 20', 10.1, 10.1, '010 521239', 'www.artbridge.am', '08:30', '00:00'),
('Jazzve', 'Abovyan 2', 10.3, 10.3, '010 493351', 'www.jazzve.com', '10:00', '00:00');

-- --------------------------------------------------------

--
-- Table structure for table `reviewsdb`
--

CREATE TABLE IF NOT EXISTS `reviewsdb` (
  `Cafe Name` text COLLATE utf8_unicode_ci NOT NULL,
  `Address` text COLLATE utf8_unicode_ci NOT NULL,
  `Review` text COLLATE utf8_unicode_ci NOT NULL,
  `Rating` text COLLATE utf8_unicode_ci NOT NULL,
  `User` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `reviewsdb`
--

INSERT INTO `reviewsdb` (`Cafe Name`, `Address`, `Review`, `Rating`, `User`) VALUES
('Segafredo', 'Northern Ave 1/56', 'Nice, comfortable place, good atmosphere', '5', 'Armen'),
('Jazzve', 'Abovyan 2', 'Nothing special', '3', 'Armen'),
('Artbridge', 'Abovyan 20', 'Good Place', '4', 'Armen'),
('Jazzve', 'Abovyan 2', 'Good place', '4', 'Areg'),
('Segafredo', 'Northern Ave 1/56', 'Nice place', '4', 'Areg'),
('Artbridge', 'Abovyan 20', 'Comfortable place', '4', 'Samo'),
('Jazzve', 'Abovyan 2', 'Good place to spend time', '4', 'Vahe');

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
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'),
('Armen', 'c40d62a8a2b77890f82084185c7f5a65bed6ccbf3d70d2b026c994391652e51f'),
('Areg', '50b507626893912fce09604f6c7c90bf74a95257e363478783691e916bcc65d5'),
('Samo', 'ee4619f9aea21c9cfba7d58d12a6dabea208fee425487d3d434b0afc254f72cb'),
('Vahe', 'e1660bdca466582dc552d56a9dea747663e4e107870c80ea7bb55284f2168fb3'),
('guest', '84983c60f7daadc1cb8698621f802c0d9f9a3c3c295c810748fb048115c186ec');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
