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
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_logs`
--

LOCK TABLES `login_logs` WRITE;
/*!40000 ALTER TABLE `login_logs` DISABLE KEYS */;
INSERT INTO `login_logs` VALUES (1,1,'2024-03-21 18:14:31','Log out'),(2,1,'2024-03-21 18:20:55','Logged in'),(3,1,'2024-03-21 18:21:01','Log out'),(4,2,'2024-03-21 18:21:20','New account registered'),(5,1,'2024-03-21 18:21:28','Logged in'),(6,1,'2024-03-21 18:22:49','Logged in'),(7,1,'2024-03-21 18:24:33','Failed to log in'),(8,1,'2024-03-21 18:24:39','Logged in'),(9,2,'2024-03-21 18:24:59','Account deleted'),(10,1,'2024-03-21 18:26:28','Logged in'),(11,1,'2024-03-21 18:26:30','Log out'),(12,2,'2024-03-22 15:24:42','New account registered'),(13,1,'2024-03-22 15:51:03','Logged in'),(14,2,'2024-03-22 15:51:08','Account deleted'),(15,1,'2024-03-22 15:51:48','Log out'),(16,1,'2024-03-22 19:10:56','Logged in'),(17,1,'2024-03-22 19:11:22','Log out'),(18,1,'2024-03-22 19:11:33','Logged in'),(19,1,'2024-03-22 19:11:37','Log out'),(20,1,'2024-03-22 19:16:12','Logged in'),(21,1,'2024-03-22 19:16:22','Log out'),(22,1,'2024-03-22 19:17:38','Logged in'),(23,1,'2024-03-22 19:18:00','Log out'),(24,1,'2024-03-22 19:32:09','Logged in'),(25,1,'2024-03-22 19:34:53','Logged in'),(26,1,'2024-03-22 19:36:24','Logged in'),(27,1,'2024-03-22 19:37:33','Logged in'),(28,1,'2024-03-23 13:13:39','Logged in'),(29,1,'2024-03-23 13:15:59','Logged in'),(30,1,'2024-03-23 13:16:48','Logged in'),(31,1,'2024-03-23 13:20:10','Logged in'),(32,1,'2024-03-23 13:22:17','Logged in'),(33,1,'2024-03-23 13:25:08','Logged in'),(34,1,'2024-03-23 13:27:18','Logged in'),(35,1,'2024-03-23 13:27:57','Logged in'),(36,1,'2024-03-23 13:28:40','File encrypted -> C:\\Users\\robot\\Desktop\\ku4e.jpg'),(37,1,'2024-03-23 13:29:25','Logged in'),(38,1,'2024-03-23 13:33:21','Logged in'),(39,1,'2024-03-23 13:34:33','Logged in'),(40,1,'2024-03-23 13:35:37','Logged in'),(41,1,'2024-03-23 13:37:35','Logged in'),(42,1,'2024-03-23 13:39:16','Logged in'),(43,1,'2024-03-24 12:06:37','Logged in'),(44,1,'2024-03-24 12:10:52','Logged in'),(45,1,'2024-03-24 12:11:50','File encrypted -> C:\\Users\\robot\\Desktop\\test.jpg'),(46,1,'2024-03-24 12:15:50','Logged in'),(47,1,'2024-03-24 12:19:35','Logged in'),(48,1,'2024-03-24 12:26:59','Logged in'),(49,1,'2024-03-24 12:27:19','File decrypted -> C:\\Users\\robot\\Desktop\\test.filesaver_1'),(50,1,'2024-03-24 12:28:24','Logged in'),(51,1,'2024-03-24 12:28:48','File encrypted -> C:\\Users\\robot\\Desktop\\11111.jpg'),(52,1,'2024-03-24 12:32:54','Logged in'),(53,1,'2024-03-24 12:34:00','File encrypted -> C:\\Users\\robot\\Desktop\\proba.txt'),(54,1,'2024-03-24 12:37:39','Logged in'),(55,1,'2024-03-24 12:39:43','Logged in'),(56,1,'2024-03-24 12:40:07','File decrypted -> C:\\Users\\robot\\Desktop\\proba.filesaver_1'),(57,1,'2024-03-24 12:40:46','Log out'),(58,1,'2024-03-24 12:40:55','Logged in'),(59,1,'2024-03-24 12:41:03','File encrypted -> C:\\Users\\robot\\Desktop\\proba.txt'),(60,1,'2024-03-24 12:41:13','File decrypted -> C:\\Users\\robot\\Desktop\\proba.filesaver_1'),(61,1,'2024-03-24 12:42:10','File encrypted -> C:\\Users\\robot\\Desktop\\real.png'),(62,1,'2024-03-24 12:42:29','File decrypted -> C:\\Users\\robot\\Desktop\\real.filesaver_1'),(63,1,'2024-03-24 12:42:45','Log out');
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

-- Dump completed on 2024-03-24 12:50:16
