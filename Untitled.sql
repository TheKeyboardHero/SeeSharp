CREATE DATABASE  IF NOT EXISTS `Activitydb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `Activitydb`;
-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: Activitydb
-- ------------------------------------------------------
-- Server version	5.7.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Activities`
--

DROP TABLE IF EXISTS `Activities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Activities` (
  `idActivity` int(11) NOT NULL AUTO_INCREMENT,
  `Duration` varchar(45) NOT NULL,
  `Attendees` int(11) DEFAULT NULL,
  `Activity_Name` varchar(45) NOT NULL,
  `Activity_Descript` varchar(255) NOT NULL,
  `Activity_Date` datetime DEFAULT NULL,
  `Activity_Createdby` varchar(105) DEFAULT NULL,
  `CreatedByID` int(11) NOT NULL,
  PRIMARY KEY (`idActivity`),
  KEY `UserThatCreatedActivities_idx` (`CreatedByID`),
  KEY `fk_Activity_Users1_idx` (`CreatedByID`),
  CONSTRAINT `UserThatCreatedActivities` FOREIGN KEY (`CreatedByID`) REFERENCES `Users` (`idUsers`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Activities`
--

LOCK TABLES `Activities` WRITE;
/*!40000 ALTER TABLE `Activities` DISABLE KEYS */;
INSERT INTO `Activities` VALUES (2,'asdfasdf',NULL,'sadfasdf','asdfasdfasdf','2018-04-27 00:00:00','sadfasdf',4),(5,'dddddddd',NULL,'dddddddd','aaaaaaaaaaaaaaaaaaa','1111-01-01 00:00:00','dddddddd',5);
/*!40000 ALTER TABLE `Activities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Attendees`
--

DROP TABLE IF EXISTS `Attendees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Attendees` (
  `idAttendees` int(11) NOT NULL AUTO_INCREMENT,
  `Users_idUsers` int(11) NOT NULL,
  `CreateActivities_idActivities` int(11) NOT NULL,
  PRIMARY KEY (`idAttendees`),
  KEY `fk_Attendee_Users_idx` (`Users_idUsers`),
  KEY `fk_Attendee_Activity1_idx` (`CreateActivities_idActivities`),
  CONSTRAINT `fk_Attendee_Activity1` FOREIGN KEY (`CreateActivities_idActivities`) REFERENCES `Activities` (`idActivity`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Attendee_Users` FOREIGN KEY (`Users_idUsers`) REFERENCES `Users` (`idUsers`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Attendees`
--

LOCK TABLES `Attendees` WRITE;
/*!40000 ALTER TABLE `Attendees` DISABLE KEYS */;
INSERT INTO `Attendees` VALUES (1,5,2),(5,4,2),(6,4,2),(7,4,2);
/*!40000 ALTER TABLE `Attendees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `idUsers` int(11) NOT NULL AUTO_INCREMENT,
  `First_Name` varchar(45) NOT NULL,
  `Last_Name` varchar(45) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`idUsers`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (4,'larry','larry','larry@larry.larry','AQAAAAEAACcQAAAAEPsH7ehAVtQRWikzdjV5ioigENgenTAMbLsBGCWLe3XUf7tGJGpWBWbXtrmlgdzDtw=='),(5,'lar','lar','lar@lar.lar','AQAAAAEAACcQAAAAEJM1X84ZAr6j5RXhC0BJlb+HjmR53QYYmo3bW/yDvdnWXgS4c5od7QzGciv9c9Z1Wg=='),(6,'Noelle','Caldwell','ncaldwell@codingdojo.com','AQAAAAEAACcQAAAAEPzoUK+9RzKDtJJyeWmACoQlv5HKDZCmW/GIdkWIWekw6x/s0jf2LTE6tDb8rPmAXw==');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-26 18:09:09
