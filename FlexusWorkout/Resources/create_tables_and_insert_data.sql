CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
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
        PRIMARY KEY (`ExerciseId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE TABLE `User` (
        `UserId` int NOT NULL AUTO_INCREMENT,
        `FirstName` longtext NULL,
        `LastName` longtext NULL,
        `Email` longtext NULL,
        `Password` longtext NULL,
        PRIMARY KEY (`UserId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE TABLE `Workout` (
        `WorkoutId` int NOT NULL AUTO_INCREMENT,
        `Name` longtext NOT NULL,
        `Description` longtext NOT NULL,
        `UserId` int NOT NULL,
        PRIMARY KEY (`WorkoutId`),
        CONSTRAINT `FK_Workout_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE TABLE `ExerciseWorkout` (
        `ExercisesExerciseId` int NOT NULL,
        `WorkoutId` int NOT NULL,
        PRIMARY KEY (`ExercisesExerciseId`, `WorkoutId`),
        CONSTRAINT `FK_ExerciseWorkout_Exercise_ExercisesExerciseId` FOREIGN KEY (`ExercisesExerciseId`) REFERENCES `Exercise` (`ExerciseId`) ON DELETE CASCADE,
        CONSTRAINT `FK_ExerciseWorkout_Workout_WorkoutId` FOREIGN KEY (`WorkoutId`) REFERENCES `Workout` (`WorkoutId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE TABLE `WorkoutDay` (
        `WorkoutDayId` int NOT NULL AUTO_INCREMENT,
        `WorkoutId` int NOT NULL,
        `date` date NOT NULL,
        `UserId` int NULL,
        PRIMARY KEY (`WorkoutDayId`),
        CONSTRAINT `FK_WorkoutDay_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`UserId`),
        CONSTRAINT `FK_WorkoutDay_Workout_WorkoutId` FOREIGN KEY (`WorkoutId`) REFERENCES `Workout` (`WorkoutId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE INDEX `IX_ExerciseWorkout_WorkoutId` ON `ExerciseWorkout` (`WorkoutId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE INDEX `IX_Workout_UserId` ON `Workout` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE INDEX `IX_WorkoutDay_UserId` ON `WorkoutDay` (`UserId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    CREATE INDEX `IX_WorkoutDay_WorkoutId` ON `WorkoutDay` (`WorkoutId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231114140453_initialMigration')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20231114140453_initialMigration', '7.0.13');
END;

COMMIT;

