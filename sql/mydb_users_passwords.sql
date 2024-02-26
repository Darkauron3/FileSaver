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
-- Table structure for table `users_passwords`
--

DROP TABLE IF EXISTS `users_passwords`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users_passwords` (
  `User_id` int NOT NULL AUTO_INCREMENT,
  `pass_hash` varchar(64) NOT NULL,
  `deleted` tinyint NOT NULL,
  PRIMARY KEY (`User_id`),
  CONSTRAINT `fk_users_passwords_users1` FOREIGN KEY (`User_id`) REFERENCES `users` (`User_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_passwords`
--

LOCK TABLES `users_passwords` WRITE;
/*!40000 ALTER TABLE `users_passwords` DISABLE KEYS */;
INSERT INTO `users_passwords` VALUES (1,'$2a$11$31sQw0Ne9KvyobYefXmAie2aSM1jgfhathqcPjGQ3iuurLRNB0cfC',0),(2,'$2a$11$5Q3gAKvzzM57eRyGwKIDk.55tuLQHFD9HD.K6Y3cjlcPeqNGZsTYW',0),(3,'$2a$11$kfaMwS1oMYoqGkho9/tCjuxhGg/zJMXuj6L/73axuQm8vXecDvUqW',0),(4,'$2a$11$fBh8hj526Pli0WLwRd5ZLOI2gdtFnyzfKQq8BO60Qsqg3gJ7BuM.W',0);
/*!40000 ALTER TABLE `users_passwords` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-26 18:24:26
