-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Generation Time: Nov 23, 2020 at 05:35 PM
-- Server version: 5.7.32-log
-- PHP Version: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs3230f20a`
--

DELIMITER $$
--
-- Procedures
--
$$

CREATE DEFINER=`jchitta2`@`%` PROCEDURE `lab_test_get_name` (IN `test_code` INT)  NO SQL
    DETERMINISTIC
BEGIN
	SELECT name FROM lab_test WHERE code = test_code;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `username` varchar(20) NOT NULL,
  `password` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`username`, `password`) VALUES
('admin', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('admin2', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('admin3', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('admin4', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('admin5', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('nurse', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('nurse2', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('nurse3', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('nurse4', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8'),
('nurse5', '5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8');

-- --------------------------------------------------------

--
-- Table structure for table `administrator`
--

CREATE TABLE `administrator` (
  `user_id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `administrator`
--

INSERT INTO `administrator` (`user_id`, `username`) VALUES
(46, 'admin'),
(49, 'admin2'),
(50, 'admin3'),
(51, 'admin4'),
(52, 'admin5');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `patient_id` int(11) NOT NULL,
  `datetime` datetime NOT NULL,
  `doctor_id` int(11) NOT NULL,
  `reasons` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`patient_id`, `datetime`, `doctor_id`, `reasons`) VALUES
(6, '2020-10-31 12:00:15', 1, 'test1'),
(6, '2020-11-03 09:00:25', 1, 'test'),
(6, '2020-12-30 13:00:19', 2, 'reasons for the visit'),
(7, '2020-01-31 12:01:51', 2, 'w3r3r'),
(7, '2020-10-29 11:25:23', 2, '1'),
(7, '2020-10-31 12:02:51', 1, 'testing123'),
(7, '2020-11-10 08:11:39', 1, 'test'),
(14, '2020-10-29 12:37:08', 1, 'test reasons'),
(21, '2020-11-23 17:21:15', 1, 'bc'),
(23, '2020-11-16 10:00:28', 4, 'very sick');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `user_id` int(11) NOT NULL,
  `doctor_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`user_id`, `doctor_id`) VALUES
(44, 1),
(45, 2),
(53, 3),
(54, 4),
(55, 5);

-- --------------------------------------------------------

--
-- Table structure for table `has_specialty`
--

CREATE TABLE `has_specialty` (
  `doctor_id` int(11) NOT NULL,
  `specialty` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `has_specialty`
--

INSERT INTO `has_specialty` (`doctor_id`, `specialty`) VALUES
(1, 'Alergist'),
(2, 'Dentist'),
(3, 'Dermatolgy'),
(4, 'ER'),
(5, 'Family Medicine');

-- --------------------------------------------------------

--
-- Table structure for table `has_tests`
--

CREATE TABLE `has_tests` (
  `order_id` int(11) NOT NULL,
  `test_code` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `has_tests`
--

INSERT INTO `has_tests` (`order_id`, `test_code`) VALUES
(7, 305),
(7, 453),
(9, 508),
(6, 10165),
(8, 10165),
(9, 10165),
(10, 10165),
(9, 11328),
(5, 37266),
(5, 39448),
(10, 39448),
(10, 93027);

-- --------------------------------------------------------

--
-- Table structure for table `lab_test`
--

CREATE TABLE `lab_test` (
  `code` int(11) NOT NULL,
  `name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lab_test`
--

INSERT INTO `lab_test` (`code`, `name`) VALUES
(10165, 'Basic Metabolic Panel'),
(305, 'Caffeine (blood)'),
(37266, 'Caffeine (urine)'),
(6399, 'CBC'),
(11328, 'Cocaine Confirmation'),
(10231, 'Comprehensive Metabolic Panel'),
(453, 'Drug Screen Panel'),
(439, 'Estrogen'),
(508, 'Hepatitis A'),
(501, 'Hepatitis B'),
(8293, 'LDL'),
(90896, 'Pregnancy'),
(8847, 'Pro Time'),
(31672, 'SARS-CoV-2 (COVID-19) Antibodies'),
(39448, 'SARS-CoV-2 (COVID-19) RNA'),
(93027, 'Synthetic Cannabis Confirmation'),
(1234, 'test'),
(15983, 'Testosterone'),
(937, 'WBC');

-- --------------------------------------------------------

--
-- Table structure for table `lab_test_order`
--

CREATE TABLE `lab_test_order` (
  `order_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `visit_datetime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lab_test_order`
--

INSERT INTO `lab_test_order` (`order_id`, `patient_id`, `visit_datetime`) VALUES
(8, 6, '2020-10-31 12:00:15'),
(7, 6, '2020-11-03 09:00:25'),
(6, 6, '2020-12-30 13:00:19'),
(9, 7, '2020-01-31 12:01:51'),
(10, 21, '2020-11-23 17:21:15'),
(5, 23, '2020-11-16 10:00:28');

-- --------------------------------------------------------

--
-- Table structure for table `lab_test_result`
--

CREATE TABLE `lab_test_result` (
  `order_id` int(11) NOT NULL,
  `test_code` int(11) NOT NULL,
  `results` varchar(200) DEFAULT NULL,
  `is_abnormal` tinyint(4) DEFAULT NULL,
  `datetime_taken` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lab_test_result`
--

INSERT INTO `lab_test_result` (`order_id`, `test_code`, `results`, `is_abnormal`, `datetime_taken`) VALUES
(5, 37266, 'wayyy too much', 1, '2020-11-10 23:08:47'),
(5, 39448, 'no covid', 0, '2020-11-14 23:08:36'),
(6, 10165, 'test', 1, '2020-11-01 12:09:05'),
(7, 305, 'caffeine!', 0, '2020-11-16 19:05:24'),
(7, 453, 'results', 1, '2020-11-16 19:04:58'),
(10, 10165, 'good', 0, '2020-11-23 17:20:50'),
(10, 39448, 'probably ok... idk though', 0, '2020-11-23 17:21:11'),
(10, 93027, 'he\'s high', 1, '2020-11-23 17:21:02');

-- --------------------------------------------------------

--
-- Table structure for table `nurse`
--

CREATE TABLE `nurse` (
  `user_id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nurse`
--

INSERT INTO `nurse` (`user_id`, `username`) VALUES
(25, 'nurse'),
(56, 'nurse2'),
(57, 'nurse3'),
(58, 'nurse4'),
(59, 'nurse5');

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `user_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`user_id`, `patient_id`) VALUES
(35, 6),
(36, 7),
(43, 14),
(64, 21),
(65, 22),
(66, 23);

-- --------------------------------------------------------

--
-- Table structure for table `specialty`
--

CREATE TABLE `specialty` (
  `specialty` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `specialty`
--

INSERT INTO `specialty` (`specialty`) VALUES
('Alergist'),
('Dentist'),
('Dermatolgy'),
('ER'),
('Family Medicine');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `address_line1` varchar(45) NOT NULL,
  `address_line2` varchar(45) DEFAULT NULL,
  `city` varchar(45) NOT NULL,
  `state` char(2) NOT NULL,
  `zip` int(5) NOT NULL,
  `phone` varchar(14) NOT NULL,
  `dob` date NOT NULL,
  `gender` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `first_name`, `last_name`, `address_line1`, `address_line2`, `city`, `state`, `zip`, `phone`, `dob`, `gender`) VALUES
(33, 'Admin', 'Chittam', '123 maple', NULL, 'Carrollton', 'GA', 12345, '1234567802', '2020-09-29', 'M'),
(52, 'admin', 'five', '1', NULL, '1', 'GA', 12345, '1234567800', '2020-10-31', 'M'),
(51, 'admin', 'four', '1', NULL, '1', 'GA', 12345, '1234567800', '2020-10-31', 'F'),
(50, 'admin', 'three', '1', NULL, '1', 'GA', 12345, '1234567800', '2020-10-31', 'M'),
(49, 'admin', 'two', '1', NULL, '1', 'GA', 12345, '1234567800', '2020-10-31', 'F'),
(25, 'Ana', 'Stanescu', 'addr1', NULL, 'city', 'GA', 12345, '1234567890', '2020-02-20', 'M'),
(46, 'Andrew', 'Young', '123 Maple. St', NULL, 'Fallston', 'AR', 30117, '1234567890', '2020-10-30', 'M'),
(47, 'andrew', 'young', '123 test ave', NULL, 'somewere', 'CA', 12345, '1234567890', '2020-11-11', 'M'),
(55, 'doctor', 'five', '1', NULL, '1', 'GA', 12345, '1234567890', '2000-10-31', 'M'),
(54, 'doctor', 'four', '1', NULL, '1', 'GA', 12345, '1234567890', '2000-10-31', 'M'),
(53, 'doctor', 'three', '1', NULL, '1', 'GA', 12345, '1234567890', '2000-10-31', 'M'),
(44, 'DrFirst', 'DrLast', 'q', NULL, 'w', 'GA', 30134, '1234567890', '2000-01-01', 'F'),
(66, 'f', 'f', 'f', 'f', 'f', 'AL', 11111, '2223336666', '2020-11-14', 'F'),
(35, 'Li', 'Yang', '123', '123', '123', 'SC', 12345, '1234567890', '2003-06-27', 'F'),
(43, 'Linda', 'Wonez', '666 Monster Ave.', '', 'Gotham', 'AL', 22222, '1234567890', '2020-09-28', 'F'),
(65, 'm', 'm', 'm', 'm', 'm', 'ME', 11111, '1112223333', '2020-11-14', 'M'),
(64, 'male', 'male', 'm', 'm', 'm', 'AL', 12345, '1112223344', '2020-11-14', 'M'),
(59, 'nurse', 'five', '1', NULL, '1', 'GA', 12345, '1234567999', '1922-12-25', 'F'),
(58, 'nurse', 'four', '1', NULL, '1', 'GA', 12345, '1234567999', '1922-12-25', 'M'),
(57, 'nurse', 'three', '1', NULL, '1', 'GA', 12345, '1234567999', '1922-12-25', 'F'),
(56, 'nurse', 'two', '1', NULL, '1', 'GA', 12345, '1234567999', '1922-12-25', 'M'),
(45, 'Second', 'Doctor2', 'addr1', NULL, 'q', 'GA', 12344, '1234567890', '1959-02-28', 'F'),
(36, 'Stacy', 'Wone', '123 Berry Dr.', '', 'New York', 'NE', 12345, '8675309000', '2020-10-13', 'M'),
(48, 'test', 'patient', 'add1', NULL, '1', 'HI', 12345, '1234567890', '2020-11-12', 'F');

-- --------------------------------------------------------

--
-- Table structure for table `visit`
--

CREATE TABLE `visit` (
  `patient_id` int(11) NOT NULL,
  `datetime` datetime NOT NULL,
  `bp_systolic` int(3) NOT NULL,
  `bp_diastolic` int(3) NOT NULL,
  `temperature` decimal(5,2) NOT NULL,
  `weight` decimal(6,2) NOT NULL,
  `pulse` int(3) NOT NULL,
  `symptoms` varchar(200) CHARACTER SET latin1 NOT NULL,
  `diagnoses` varchar(200) CHARACTER SET latin1 DEFAULT NULL,
  `nurse_user_id` int(11) NOT NULL,
  `doctor_id` int(11) NOT NULL,
  `final_diagnosis` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `visit`
--

INSERT INTO `visit` (`patient_id`, `datetime`, `bp_systolic`, `bp_diastolic`, `temperature`, `weight`, `pulse`, `symptoms`, `diagnoses`, `nurse_user_id`, `doctor_id`, `final_diagnosis`) VALUES
(6, '2020-10-31 12:00:15', 100, 100, '100.00', '100.00', 100, 'test', NULL, 25, 1, 0),
(6, '2020-11-03 09:00:25', 100, 100, '100.00', '100.00', 100, 'symptoms', 'diag\r\n\r\nFINAL: ', 25, 1, 1),
(6, '2020-12-30 13:00:19', 100, 100, '100.00', '100.00', 100, 'test', '469iuy7i6te4eq2wr', 25, 2, 1),
(7, '2020-01-31 12:01:51', 80, 20, '101.20', '100.00', 21, 'Always tired', NULL, 25, 2, 0),
(7, '2020-10-29 11:25:23', 95, 100, '100.00', '200.00', 100, 'Test symptoms', 'Test diag', 25, 1, 0),
(7, '2020-10-31 12:02:51', 34, 22, '101.20', '300.50', 21, 'dead', NULL, 25, 2, 0),
(7, '2020-11-10 08:11:39', 100, 100, '100.00', '1000.59', 100, 'symp', 'diag', 25, 1, 0),
(14, '2020-10-29 12:37:08', 110, 109, '107.00', '1000.99', 108, 'he\'s prolly dead', 'Yeah, he\'s def dead.', 25, 1, 0),
(21, '2020-11-23 17:21:15', 100, 100, '100.00', '100.00', 100, 'sef', 'sdf', 25, 1, 0),
(23, '2020-11-16 10:00:28', 100, 100, '100.00', '100.00', 100, 'very sick', 'Yeah, he sick\r\n\r\nFINAL: No covid, but high on caffeine.', 25, 4, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `administrator`
--
ALTER TABLE `administrator`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username_UNIQUE` (`username`),
  ADD KEY `fk_administrator_account1_idx` (`username`);

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`patient_id`,`datetime`),
  ADD UNIQUE KEY `doctorid_datetime_UNIQUE` (`datetime`,`doctor_id`),
  ADD KEY `fk_appointment_doctor1_idx` (`doctor_id`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `doctor_id_UNIQUE` (`doctor_id`);

--
-- Indexes for table `has_specialty`
--
ALTER TABLE `has_specialty`
  ADD PRIMARY KEY (`doctor_id`,`specialty`),
  ADD KEY `fk_has_specialty_specialty1_idx` (`specialty`);

--
-- Indexes for table `has_tests`
--
ALTER TABLE `has_tests`
  ADD PRIMARY KEY (`order_id`,`test_code`),
  ADD KEY `fk_has_tests_lab_test1_idx` (`test_code`);

--
-- Indexes for table `lab_test`
--
ALTER TABLE `lab_test`
  ADD PRIMARY KEY (`code`),
  ADD UNIQUE KEY `name_UNIQUE` (`name`);

--
-- Indexes for table `lab_test_order`
--
ALTER TABLE `lab_test_order`
  ADD PRIMARY KEY (`order_id`),
  ADD UNIQUE KEY `patientid_appointmentdatetime_UNIQUE` (`patient_id`,`visit_datetime`),
  ADD KEY `fk_lab_test_order_appointment1_idx` (`patient_id`,`visit_datetime`);

--
-- Indexes for table `lab_test_result`
--
ALTER TABLE `lab_test_result`
  ADD PRIMARY KEY (`order_id`,`test_code`),
  ADD KEY `fk_results_lab_test1_idx` (`test_code`);

--
-- Indexes for table `nurse`
--
ALTER TABLE `nurse`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username_UNIQUE` (`username`),
  ADD KEY `fk_nurse_account1_idx` (`username`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `patient_id_UNIQUE` (`patient_id`);

--
-- Indexes for table `specialty`
--
ALTER TABLE `specialty`
  ADD PRIMARY KEY (`specialty`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `info_unique` (`first_name`,`last_name`,`address_line1`,`address_line2`,`city`,`state`,`zip`,`phone`,`dob`,`gender`);

--
-- Indexes for table `visit`
--
ALTER TABLE `visit`
  ADD PRIMARY KEY (`patient_id`,`datetime`),
  ADD KEY `fk_record_nurse1_idx` (`nurse_user_id`),
  ADD KEY `fk_record_doctor_idx` (`doctor_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `doctor`
--
ALTER TABLE `doctor`
  MODIFY `doctor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `lab_test_order`
--
ALTER TABLE `lab_test_order`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `patient_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `administrator`
--
ALTER TABLE `administrator`
  ADD CONSTRAINT `fk_administrator_account1` FOREIGN KEY (`username`) REFERENCES `account` (`username`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_administrator_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `appointment`
--
ALTER TABLE `appointment`
  ADD CONSTRAINT `fk_appointment_doctor1` FOREIGN KEY (`doctor_id`) REFERENCES `doctor` (`doctor_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_appointment_patient1` FOREIGN KEY (`patient_id`) REFERENCES `patient` (`patient_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `fk_doctor_user1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `has_specialty`
--
ALTER TABLE `has_specialty`
  ADD CONSTRAINT `fk_has_specialty_doctor1` FOREIGN KEY (`doctor_id`) REFERENCES `doctor` (`doctor_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_has_specialty_specialty1` FOREIGN KEY (`specialty`) REFERENCES `specialty` (`specialty`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `has_tests`
--
ALTER TABLE `has_tests`
  ADD CONSTRAINT `fk_has_tests_lab_test1` FOREIGN KEY (`test_code`) REFERENCES `lab_test` (`code`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_has_tests_lab_test_order1` FOREIGN KEY (`order_id`) REFERENCES `lab_test_order` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `lab_test_order`
--
ALTER TABLE `lab_test_order`
  ADD CONSTRAINT `fk_lab_test_order_appointment1` FOREIGN KEY (`patient_id`,`visit_datetime`) REFERENCES `appointment` (`patient_id`, `datetime`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `lab_test_result`
--
ALTER TABLE `lab_test_result`
  ADD CONSTRAINT `fk_results_lab_test1` FOREIGN KEY (`test_code`) REFERENCES `lab_test` (`code`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_results_lab_test_order1` FOREIGN KEY (`order_id`) REFERENCES `lab_test_order` (`order_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `nurse`
--
ALTER TABLE `nurse`
  ADD CONSTRAINT `fk_nurse_account1` FOREIGN KEY (`username`) REFERENCES `account` (`username`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_nurse_user1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `patient`
--
ALTER TABLE `patient`
  ADD CONSTRAINT `fk_patient_user1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `visit`
--
ALTER TABLE `visit`
  ADD CONSTRAINT `fk_record_appointment1` FOREIGN KEY (`patient_id`,`datetime`) REFERENCES `appointment` (`patient_id`, `datetime`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_record_doctor` FOREIGN KEY (`doctor_id`) REFERENCES `doctor` (`doctor_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_record_nurse1` FOREIGN KEY (`nurse_user_id`) REFERENCES `nurse` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
