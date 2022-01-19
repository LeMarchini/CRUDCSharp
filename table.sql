CREATE DATABASE clients;

USE clients;

CREATE TABLE `clientlist` (
  `clientID` int NOT NULL AUTO_INCREMENT,
  `username` varchar(150) DEFAULT NULL,
  `userEmail` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`clientID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
