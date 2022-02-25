CREATE DATABASE `googlenotification`;

CREATE TABLE `notifyhistory` (
  `NotifyHistoryId` int NOT NULL AUTO_INCREMENT,
  `UserId` int DEFAULT NULL,
  `PushDate` datetime DEFAULT NULL,
  `Status` bit(1) DEFAULT NULL,
  `Message` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `Link` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`NotifyHistoryId`),
  UNIQUE KEY `NotifyHistoryId_UNIQUE` (`NotifyHistoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `user` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `IpAddress` varchar(100) DEFAULT NULL,
  `SubscribeToken` varchar(500) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

