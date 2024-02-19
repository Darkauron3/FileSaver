-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `login_logs`
--

DROP TABLE IF EXISTS `login_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login_logs` (
  `log_Id` int NOT NULL AUTO_INCREMENT,
  `users_User_id` int NOT NULL,
  `Time` datetime NOT NULL,
  `Action` varchar(255) NOT NULL,
  PRIMARY KEY (`log_Id`),
  KEY `fk_login_logs_users1_idx` (`users_User_id`),
  CONSTRAINT `fk_login_logs_users1` FOREIGN KEY (`users_User_id`) REFERENCES `users` (`User_id`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_logs`
--

LOCK TABLES `login_logs` WRITE;
/*!40000 ALTER TABLE `login_logs` DISABLE KEYS */;
INSERT INTO `login_logs` VALUES (1,3,'2024-02-13 17:21:43','New account registered'),(2,1,'2024-02-13 17:21:58','Logged in'),(3,1,'2024-02-13 17:28:12','Logged in'),(4,1,'2024-02-13 18:05:45','Logged in'),(5,1,'2024-02-13 18:06:18','Logged in'),(6,1,'2024-02-13 18:14:41','Failed to log in'),(7,1,'2024-02-13 18:14:46','Logged in'),(8,2,'2024-02-13 18:32:46','Logged in'),(9,1,'2024-02-13 18:47:46','Logged in'),(10,1,'2024-02-13 18:49:29','Logged in'),(11,1,'2024-02-14 15:58:46','Logged in'),(12,1,'2024-02-14 16:02:41','Logged in'),(13,1,'2024-02-14 16:30:07','Logged in'),(14,1,'2024-02-14 18:45:52','Logged in'),(15,1,'2024-02-14 18:46:59','Logged in'),(16,1,'2024-02-14 18:49:13','Logged in'),(17,1,'2024-02-15 17:10:57','Logged in'),(18,1,'2024-02-15 17:59:31','Logged in'),(19,1,'2024-02-15 18:00:29','Logged in'),(20,1,'2024-02-15 18:09:21','Logged in'),(21,1,'2024-02-15 18:17:59','Logged in'),(22,1,'2024-02-15 18:51:34','Logged in'),(23,1,'2024-02-15 19:05:05','Logged in'),(24,1,'2024-02-15 19:08:00','Logged in'),(25,1,'2024-02-15 19:08:58','Logged in'),(26,1,'2024-02-16 18:04:01','Logged in'),(27,1,'2024-02-16 18:05:53','Logged in'),(28,1,'2024-02-16 18:41:48','Logged in'),(29,1,'2024-02-16 18:53:36','Logged in'),(30,1,'2024-02-16 18:55:45','Logged in'),(31,1,'2024-02-16 19:12:05','Logged in'),(32,1,'2024-02-16 19:36:44','Logged in'),(33,1,'2024-02-16 19:38:49','Logged in'),(34,1,'2024-02-16 19:40:02','Failed to log in'),(35,1,'2024-02-16 19:40:04','Logged in'),(36,1,'2024-02-16 19:45:52','Logged in'),(37,1,'2024-02-16 19:47:05','Logged in'),(38,1,'2024-02-16 19:53:40','Logged in'),(39,1,'2024-02-16 19:56:17','Logged in'),(40,1,'2024-02-16 20:07:07','Logged in'),(41,1,'2024-02-18 18:35:08','Logged in'),(42,1,'2024-02-18 18:35:09','Log out'),(43,1,'2024-02-18 18:35:13','Logged in'),(44,1,'2024-02-18 18:36:28','Logged in'),(45,1,'2024-02-18 18:49:36','Logged in'),(46,1,'2024-02-18 18:52:57','Logged in'),(47,1,'2024-02-18 18:57:43','Logged in'),(48,1,'2024-02-18 18:58:43','Logged in'),(49,1,'2024-02-18 19:27:02','Logged in'),(50,1,'2024-02-18 19:31:19','Logged in'),(51,1,'2024-02-18 19:34:00','Logged in'),(52,1,'2024-02-18 19:35:33','Logged in'),(53,1,'2024-02-18 19:38:51','Logged in'),(54,1,'2024-02-18 19:47:00','Logged in'),(55,1,'2024-02-18 20:39:18','Logged in'),(56,1,'2024-02-19 23:00:57','Logged in'),(57,1,'2024-02-19 23:30:35','Logged in'),(58,1,'2024-02-19 23:36:09','Logged in'),(59,1,'2024-02-19 23:37:25','Logged in');
/*!40000 ALTER TABLE `login_logs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-20  0:04:56
