-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `encrypted_files_info`
--

DROP TABLE IF EXISTS `encrypted_files_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `encrypted_files_info` (
  `File_id` int NOT NULL,
  `User_id` int DEFAULT NULL,
  `File_name` varchar(255) DEFAULT NULL,
  `File_data` varbinary(255) DEFAULT NULL,
  `Encryption_key_id` int NOT NULL,
  `Is_encrypted` tinyint(1) DEFAULT NULL,
  `Upload_date` datetime DEFAULT NULL,
  PRIMARY KEY (`File_id`),
  UNIQUE KEY `Encryption_key_id_UNIQUE` (`Encryption_key_id`),
  KEY `User_id` (`User_id`),
  CONSTRAINT `encrypted_files_info_ibfk_1` FOREIGN KEY (`User_id`) REFERENCES `users` (`User_id`),
  CONSTRAINT `encrypted_files_info_ibfk_2` FOREIGN KEY (`Encryption_key_id`) REFERENCES `encryption_keys` (`UserKey_en_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `encrypted_files_info`
--

LOCK TABLES `encrypted_files_info` WRITE;
/*!40000 ALTER TABLE `encrypted_files_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `encrypted_files_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-17 16:42:20
