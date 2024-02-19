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
-- Table structure for table `user_files_info`
--

DROP TABLE IF EXISTS `user_files_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_files_info` (
  `File_id` int NOT NULL AUTO_INCREMENT,
  `User_id` int NOT NULL,
  `File_name` varchar(255) NOT NULL,
  `File_size` varchar(45) NOT NULL,
  `File_type` varchar(45) NOT NULL,
  `Upload_date` datetime NOT NULL,
  PRIMARY KEY (`File_id`),
  KEY `fk_user_files_info_users1_idx` (`User_id`),
  CONSTRAINT `fk_user_files_info_users1` FOREIGN KEY (`User_id`) REFERENCES `users` (`User_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_files_info`
--

LOCK TABLES `user_files_info` WRITE;
/*!40000 ALTER TABLE `user_files_info` DISABLE KEYS */;
INSERT INTO `user_files_info` VALUES (1,1,'C:\\Users\\robot\\Desktop\\test.txt','19B','.txt','2024-02-16 19:40:12'),(2,1,'C:\\Users\\robot\\Desktop\\test2.txt','0B','.txt','2024-02-16 19:53:47'),(3,1,'C:\\Users\\robot\\Desktop\\test.txt','15B','.txt','2024-02-16 19:56:35'),(4,1,'C:\\Users\\robot\\Desktop\\test2.txt','19B','.txt','2024-02-18 18:35:27'),(5,1,'C:\\Users\\robot\\Desktop\\test3.txt','20B','.txt','2024-02-18 18:59:23'),(6,1,'C:\\Users\\robot\\Desktop\\opa.txt','24B','.txt','2024-02-18 19:27:14'),(7,1,'C:\\Users\\robot\\Desktop\\opa.txt','13B','.txt','2024-02-18 19:31:27'),(8,1,'C:\\Users\\robot\\Desktop\\opa.txt','17B','.txt','2024-02-18 19:39:14'),(9,1,'C:\\Users\\robot\\Desktop\\opa.txt','26B','.txt','2024-02-18 19:47:10'),(10,1,'C:\\Users\\robot\\Desktop\\opa.txt','15B','.txt','2024-02-18 20:39:40'),(11,1,'C:\\Users\\robot\\Desktop\\opa.txt','17B','.txt','2024-02-19 23:01:11'),(12,1,'C:\\Users\\robot\\Desktop\\opa.txt','18B','.txt','2024-02-19 23:30:39'),(13,1,'C:\\Users\\robot\\Desktop\\opa.txt','17B','.txt','2024-02-19 23:36:17'),(14,1,'C:\\Users\\robot\\Desktop\\proba.txt','17B','.txt','2024-02-19 23:37:31');
/*!40000 ALTER TABLE `user_files_info` ENABLE KEYS */;
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
