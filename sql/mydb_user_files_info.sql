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
  `Encoding` varchar(45) NOT NULL,
  `Upload_date` datetime NOT NULL,
  PRIMARY KEY (`File_id`),
  KEY `fk_user_files_info_users1_idx` (`User_id`),
  CONSTRAINT `fk_user_files_info_user_files1` FOREIGN KEY (`File_id`) REFERENCES `user_files` (`file_id`),
  CONSTRAINT `fk_user_files_info_users1` FOREIGN KEY (`User_id`) REFERENCES `users` (`User_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_files_info`
--

LOCK TABLES `user_files_info` WRITE;
/*!40000 ALTER TABLE `user_files_info` DISABLE KEYS */;
INSERT INTO `user_files_info` VALUES (1,1,'C:\\Users\\robot\\Desktop\\proba.txt','25B','.txt','','2024-02-20 18:17:17'),(2,1,'C:\\Users\\robot\\Desktop\\proba.txt','25B','.txt','','2024-02-20 18:19:22'),(3,1,'C:\\Users\\robot\\Desktop\\proba.txt','21B','.txt','','2024-02-20 18:36:45'),(4,1,'C:\\Users\\robot\\Desktop\\proba.txt','24B','.txt','','2024-02-20 19:00:47'),(5,1,'C:\\Users\\robot\\Desktop\\proba.txt','19B','.txt','','2024-02-20 19:12:07'),(6,1,'C:\\Users\\robot\\Desktop\\proba.txt','275B','.txt','','2024-02-20 19:16:53'),(7,1,'C:\\Users\\robot\\Desktop\\proba.txt','275B','.txt','','2024-02-20 19:31:18'),(8,1,'C:\\Users\\robot\\Desktop\\proba.txt','25B','.txt','','2024-02-20 20:16:22'),(9,1,'C:\\Users\\robot\\Desktop\\proba.txt','278B','.txt','','2024-02-20 20:25:34'),(10,1,'C:\\Users\\robot\\Desktop\\proba.txt','278B','.txt','','2024-02-20 20:28:43'),(11,1,'C:\\Users\\robot\\Desktop\\proba.txt','284B','.txt','','2024-02-20 20:31:17'),(12,1,'C:\\Users\\robot\\Desktop\\proba.txt','284B','.txt','','2024-02-20 20:34:48'),(13,1,'C:\\Users\\robot\\Desktop\\opa.txt','284B','.txt','','2024-02-20 20:40:25'),(14,1,'C:\\Users\\robot\\Desktop\\12d.jpg','9.3KB','.jpg','','2024-02-25 17:22:52'),(15,1,'C:\\Users\\robot\\Desktop\\ku4e2.jpg','7KB','.jpg','','2024-02-25 17:26:39'),(16,1,'C:\\Users\\robot\\Desktop\\real - Copy.png','1.3MB','.png','','2024-02-25 17:30:06'),(17,1,'C:\\Users\\robot\\Desktop\\real - Copy.png','1.3MB','.png','Unicode (UTF-8)','2024-02-25 19:30:23'),(18,1,'C:\\Users\\robot\\Desktop\\real - Copy.png','1.3MB','.png','Unicode (UTF-8)','2024-02-25 19:32:09'),(19,1,'C:\\Users\\robot\\Desktop\\real - Copy.png','1.3MB','.png','Unicode (UTF-8)','2024-02-25 19:33:59'),(20,1,'C:\\Users\\robot\\Desktop\\real - Copy.png','1.3MB','.png','Unicode (UTF-8)','2024-02-25 19:36:07'),(21,1,'C:\\Users\\robot\\Desktop\\ku4e.jpg','7KB','.jpg','UTF8EncodingSealed','2024-02-25 20:59:50'),(22,1,'C:\\Users\\robot\\Desktop\\ku4e.jpg','7KB','.jpg','UTF8EncodingSealed','2024-02-25 21:00:45'),(23,1,'C:\\Users\\robot\\Desktop\\ku4e.jpg','7KB','.jpg','UTF8EncodingSealed','2024-02-25 21:02:15'),(24,1,'C:\\Users\\robot\\Desktop\\da.txt','7B','.txt','UTF8EncodingSealed','2024-02-25 21:03:59'),(25,1,'C:\\Users\\robot\\Desktop\\test.jpg','81.1KB','.jpg','UTF8EncodingSealed','2024-02-26 18:22:17'),(26,1,'C:\\Users\\robot\\Desktop\\test.pdf','623.5KB','.pdf','UTF8EncodingSealed','2024-02-27 17:36:21'),(27,1,'C:\\Users\\robot\\Desktop\\powerpoint-test.pptx','0B','.pptx','UTF8EncodingSealed','2024-02-27 17:37:44'),(28,1,'C:\\Users\\robot\\Desktop\\word-proba.docx','0B','.docx','UTF8EncodingSealed','2024-02-27 17:37:48'),(29,1,'C:\\Users\\robot\\Desktop\\word-proba.docx','11.7KB','.docx','UTF8EncodingSealed','2024-02-27 17:38:29'),(30,1,'C:\\Users\\robot\\Desktop\\powerpoint-test.pptx','33.5KB','.pptx','UTF8EncodingSealed','2024-02-27 17:38:37');
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

-- Dump completed on 2024-02-28  6:49:26
