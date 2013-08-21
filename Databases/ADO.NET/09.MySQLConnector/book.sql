SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE DATABASE IF NOT EXISTS `Book`;
CREATE SCHEMA IF NOT EXISTS `Book` DEFAULT CHARACTER SET utf8 ;
USE `Book` ;

-- -----------------------------------------------------
-- Table `books`.`Books`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Book`.`Books` ;

CREATE  TABLE IF NOT EXISTS `Book`.`Books` (
  `idBooks` INT NOT NULL AUTO_INCREMENT ,
  `titleBook` VARCHAR(45) NOT NULL ,
  `publishDate` DATE NOT NULL ,
  `ISBN` BIGINT NOT NULL ,
  PRIMARY KEY (`idBooks`) ,
  UNIQUE INDEX `idBooks_UNIQUE` (`idBooks` ASC) ,
  UNIQUE INDEX `ISBN_UNIQUE` (`ISBN` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `books`.`Authors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Book`.`Authors` ;

CREATE  TABLE IF NOT EXISTS `Book`.`Authors` (
  `idAuthors` INT(11) NOT NULL AUTO_INCREMENT ,
  `AuthorName` VARCHAR(45) NULL DEFAULT NULL ,
  `Books_idBooks` INT NOT NULL ,
  PRIMARY KEY (`idAuthors`, `Books_idBooks`) ,
  UNIQUE INDEX `idAuthors_UNIQUE` (`idAuthors` ASC) ,
  UNIQUE INDEX `AuthorName_UNIQUE` (`AuthorName` ASC) ,
  INDEX `fk_Authors_Books_idx` (`Books_idBooks` ASC) ,
  CONSTRAINT `fk_Authors_Books`
    FOREIGN KEY (`Books_idBooks` )
    REFERENCES `Book`.`Books` (`idBooks` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


USE `Book` ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"Book1\"', '2001-03-31', '123456789');
INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"Book2\"', '2001-03-31', '345623456');
INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"Book3\"', '2001-03-31', '123124567');

UPDATE `bookstores`.`books` SET `publishDate`='2011-05-08' WHERE `idBooks`='3';
UPDATE `bookstores`.`books` SET `publishDate`='2004-10-31' WHERE `idBooks`='2';

INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Ivan Todorov\"', '1');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Misho Petrov\"', '1');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Onq s konq\"', '2');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Tilivizor', '3');