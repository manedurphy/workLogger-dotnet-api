CREATE DATABASE IF NOT EXISTS workLogger;

USE workLogger;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` varchar(60) NULL,
    `LastName` varchar(60) NULL,
    `Email` varchar(60) NULL,
    `Password` varchar(60) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Tasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` text NULL,
    `ProjectNumber` bigint NOT NULL,
    `HoursAvailableToWork` float NOT NULL,
    `HoursWorked` float NOT NULL,
    `HoursRemaining` float NOT NULL,
    `Notes` text NULL,
    `NumberOfReviews` int NOT NULL,
    `ReviewHours` int NOT NULL,
    `HoursRequiredByBim` int NOT NULL,
    `IsComplete` tinyint(1) NOT NULL,
    `UserId` int NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Tasks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Tasks_UserId` ON `Tasks` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201223212610_Init', '3.1.10');