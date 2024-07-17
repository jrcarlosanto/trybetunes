USE TrybeTunes;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET = utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Users` (
    `UserId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`UserId`)
) CHARACTER SET = utf8mb4;

CREATE TABLE `Tracks` (
    `TrackId` int NOT NULL AUTO_INCREMENT,
    `TrackName` longtext CHARACTER SET utf8mb4 NULL,
    `PreviewUrl` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` int NOT NULL,
    CONSTRAINT `PK_Tracks` PRIMARY KEY (`TrackId`),
    CONSTRAINT `FK_Tracks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`UserId`) ON DELETE CASCADE
) CHARACTER SET = utf8mb4;

CREATE INDEX `IX_Tracks_UserId` ON `Tracks` (`UserId`);

INSERT INTO
    `__EFMigrationsHistory` (
        `MigrationId`,
        `ProductVersion`
    )
VALUES (
        '20240717184318_createDataBase',
        '7.0.9'
    );

COMMIT;