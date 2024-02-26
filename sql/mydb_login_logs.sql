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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_logs`
--

LOCK TABLES `login_logs` WRITE;
/*!40000 ALTER TABLE `login_logs` DISABLE KEYS */;
INSERT INTO `login_logs` VALUES (1,1,'2024-02-22 18:53:33','Log out'),(2,1,'2024-02-25 17:22:24','Logged in'),(3,1,'2024-02-25 17:22:54','File encrypted -> C:\\Users\\robot\\Desktop\\12d.jpg'),(4,1,'2024-02-25 17:23:47','File decrypted -> C:\\Users\\robot\\Desktop\\12d.filesaver_14'),(5,1,'2024-02-25 17:26:41','File encrypted -> C:\\Users\\robot\\Desktop\\ku4e2.jpg'),(6,1,'2024-02-25 17:26:45','File decrypted -> C:\\Users\\robot\\Desktop\\ku4e2.filesaver_15'),(7,1,'2024-02-25 17:30:07','File encrypted -> C:\\Users\\robot\\Desktop\\real - Copy.png'),(8,1,'2024-02-25 17:30:12','File decrypted -> C:\\Users\\robot\\Desktop\\real - Copy.filesaver_16'),(9,1,'2024-02-25 17:34:08','Log out'),(10,1,'2024-02-25 19:30:09','Logged in'),(11,1,'2024-02-25 19:33:52','Logged in'),(12,1,'2024-02-25 19:36:00','Logged in'),(13,1,'2024-02-25 19:36:08','File encrypted -> C:\\Users\\robot\\Desktop\\real - Copy.png'),(14,1,'2024-02-25 20:13:07','Logged in'),(15,1,'2024-02-25 20:59:43','Logged in'),(16,1,'2024-02-25 21:03:51','Logged in'),(17,1,'2024-02-25 21:04:00','File encrypted -> C:\\Users\\robot\\Desktop\\da.txt'),(18,1,'2024-02-25 21:04:13','File decrypted -> C:\\Users\\robot\\Desktop\\da.filesaver_24'),(19,1,'2024-02-26 18:22:06','Logged in'),(20,1,'2024-02-26 18:22:18','File encrypted -> C:\\Users\\robot\\Desktop\\test.jpg'),(21,1,'2024-02-26 18:23:19','File decrypted -> C:\\Users\\robot\\Desktop\\test.filesaver_25'),(22,1,'2024-02-26 18:24:03','Log out');
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

-- Dump completed on 2024-02-26 18:24:25
