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
-- Table structure for table `login_logs`
--

DROP TABLE IF EXISTS `login_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login_logs` (
  `User_id` int NOT NULL,
  `Time` datetime NOT NULL,
  `Action` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_logs`
--

LOCK TABLES `login_logs` WRITE;
/*!40000 ALTER TABLE `login_logs` DISABLE KEYS */;
INSERT INTO `login_logs` VALUES (2,'2024-01-16 23:34:02','Logged in'),(2,'2024-01-16 23:34:08','Log out'),(1,'2024-01-16 23:34:17','Logged in'),(2,'2024-01-16 23:34:23','Account deleted'),(3,'2024-01-16 23:38:13','Logged in'),(3,'2024-01-16 23:38:17','Log out'),(1,'2024-01-16 23:38:24','Logged in'),(1,'2024-01-16 23:45:47','Logged in'),(1,'2024-01-17 11:37:28','Logged in'),(1,'2024-01-17 11:43:22','Logged in'),(3,'2024-01-17 11:43:30','Account deleted'),(1,'2024-01-17 11:44:05','Log out'),(4,'2024-01-17 12:28:55','Logged in'),(4,'2024-01-17 12:28:57','Log out'),(1,'2024-01-18 09:42:23','Logged in'),(1,'2024-01-18 09:59:20','Logged in'),(1,'2024-01-18 10:00:01','Logged in'),(1,'2024-01-18 10:05:50','Logged in'),(1,'2024-01-18 10:08:42','Logged in'),(1,'2024-01-18 10:14:41','Logged in'),(1,'2024-01-18 10:30:47','Logged in'),(1,'2024-01-18 10:31:47','Logged in'),(1,'2024-01-18 10:36:20','Logged in'),(1,'2024-01-18 10:36:58','Logged in'),(1,'2024-01-18 10:38:53','Logged in'),(1,'2024-01-18 17:38:31','Logged in'),(1,'2024-01-18 17:41:03','Logged in'),(1,'2024-01-18 17:45:41','Logged in'),(1,'2024-01-18 18:02:30','Logged in'),(1,'2024-01-18 18:09:21','Logged in'),(1,'2024-01-18 18:16:54','Logged in'),(1,'2024-01-18 18:18:50','Logged in'),(1,'2024-01-18 18:19:36','Logged in'),(1,'2024-01-18 18:22:49','Logged in'),(1,'2024-01-18 18:26:10','Logged in'),(1,'2024-01-18 18:26:46','Logged in'),(1,'2024-01-18 18:31:07','Logged in'),(1,'2024-01-18 18:34:17','Logged in'),(1,'2024-01-20 13:54:11','Logged in'),(1,'2024-01-20 14:05:04','Logged in'),(1,'2024-01-20 14:11:36','Logged in'),(1,'2024-01-20 14:14:56','Logged in'),(1,'2024-01-20 14:20:41','Logged in'),(1,'2024-01-20 14:23:17','Logged in'),(1,'2024-01-20 15:18:01','Logged in');
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

-- Dump completed on 2024-01-20 15:22:22
