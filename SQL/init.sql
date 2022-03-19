CREATE DATABASE IF NOT EXISTS catalog;
USE catalog;

CREATE TABLE IF NOT EXISTS `authors`
(
	`id` INT AUTO_INCREMENT,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `publishers`
(
	`id` INT AUTO_INCREMENT,
    `name` VARCHAR(128) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `categories`
(
	`id` INT AUTO_INCREMENT,
    `name` VARCHAR(128) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `directors`
(
	`id` INT AUTO_INCREMENT,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL,
    PRIMARY KEY(`id`)
);

CREATE TABLE IF NOT EXISTS `actors`
(
	`id` INT AUTO_INCREMENT ,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `books`
(
	`id` INT AUTO_INCREMENT,
    `title` varchar(128) NOT NULL,
    `authorId` INT NOT NULL,
    `publisherId` INT NOT NULL,
    `pages` INT NOT NULL,
    `publicationYear` INT NOT NULL,
    `categoryIds` varchar(128) NOT NULL,
    `price` decimal(6, 2) UNSIGNED NOT NULL,
    FOREIGN KEY (`publisherId`) REFERENCES `publishers`(`id`),
    FOREIGN KEY (`authorId`) REFERENCES `authors`(`id`),
    PRIMARY KEY(`id`)
);

CREATE TABLE IF NOT EXISTS `movies`
(
	`id` INT AUTO_INCREMENT,
    `title` varchar(128) NOT NULL,
    `directorId` INT NOT NULL,
    `actorIds` varchar(128) NOT NULL,
    `publicationYear` INT NOT NULL,
    `categoryIds` varchar(128) NOT NULL,
    FOREIGN KEY (`directorId`) REFERENCES `directors`(`id`),
    PRIMARY KEY (`id`)
);
