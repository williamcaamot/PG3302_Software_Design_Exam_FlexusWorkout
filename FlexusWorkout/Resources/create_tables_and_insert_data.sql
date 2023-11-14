CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
    );

START TRANSACTION;

CREATE TABLE `User` (
    `UserId` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext NULL,
    `LastName` longtext NULL,
    `Email` longtext NULL,
    `Password` longtext NULL,
    PRIMARY KEY (`UserId`)
);

CREATE TABLE `Workout` (
    `WorkoutId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    `Description` longtext NOT NULL,
    `UserId` int NOT NULL,
    `Type` longtext NOT NULL,
    `Location` longtext NOT NULL,
    PRIMARY KEY (`WorkoutId`),
    CONSTRAINT `FK_Workout_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`) ON DELETE CASCADE
);

CREATE TABLE `Exercise` (
    `ExerciseId` int NOT NULL AUTO_INCREMENT,
    `Type` longtext NOT NULL,
    `Name` longtext NULL,
    `Description` longtext NULL,
    `DurationInMinutes` int NULL,
    `Repetitions` int NULL,
    `Sets` int NULL,
    `EquipmentRequired` longtext NULL,
    `IntensityLevel` int NULL,
    `Location` longtext NULL,
    `Discriminator` longtext NOT NULL,
    `WorkoutId` int NULL,
    PRIMARY KEY (`ExerciseId`),
    CONSTRAINT `FK_Exercise_Workout_WorkoutId` FOREIGN KEY (`WorkoutId`) REFERENCES `Workout` (`WorkoutId`)
);

CREATE INDEX `IX_Exercise_WorkoutId` ON `Exercise` (`WorkoutId`);

CREATE INDEX `IX_Workout_UserId` ON `Workout` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231112155648_Initial', '7.0.13');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231113141842_secondmigratiod', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE `Exercise` DROP CONSTRAINT `FK_Exercise_Workout_WorkoutId`;

DROP INDEX IX_Exercise_WorkoutId ON Exercise;

ALTER TABLE `Exercise` DROP COLUMN `WorkoutId`;

CREATE TABLE `ExerciseWorkout` (
        `ExercisesExerciseId` int NOT NULL,
        `WorkoutId` int NOT NULL,
        PRIMARY KEY (`ExercisesExerciseId`, `WorkoutId`),
        CONSTRAINT `FK_ExerciseWorkout_Exercise_ExercisesExerciseId` FOREIGN KEY (`ExercisesExerciseId`) REFERENCES `Exercise` (`ExerciseId`) ON DELETE CASCADE,
       CONSTRAINT `FK_ExerciseWorkout_Workout_WorkoutId` FOREIGN KEY (`WorkoutId`) REFERENCES `Workout` (`WorkoutId`) ON DELETE CASCADE
);

CREATE INDEX `IX_ExerciseWorkout_WorkoutId` ON `ExerciseWorkout` (`WorkoutId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231113152909_jointablemigrationexerciseandworkout', '7.0.13');

COMMIT;

START TRANSACTION;

ALTER TABLE `Workout` DROP COLUMN `Location`;

ALTER TABLE `Workout` DROP COLUMN `Type`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231114102101_RemoveFieldsFromWorkout', '7.0.13');

COMMIT;
