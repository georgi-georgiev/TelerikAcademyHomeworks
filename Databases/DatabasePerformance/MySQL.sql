---------------------------------------------------------------------
-- Create database PerformanceDB
---------------------------------------------------------------------

USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

---------------------------------------------------------------------
-- Create table Authors and populate 100 000 rows in it
---------------------------------------------------------------------

CREATE TABLE Authors(
  AuthorId int NOT NULL PRIMARY KEY IDENTITY,
  AuthorName varchar(100),
  Description text,
  RegisterDate datetime
)
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Svetlin Nakov', 'Bog na programiraneto', '20100301')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Doncho Minkov', 'Bog na web', '20110511')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Nikolay Kostov', 'Bog na programiraneto 2', '20120721')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('George Georgiev', 'Bog na programiraneto 3', '20090305')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Bay Ivan', 'djambaza', '20061101')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Kaka Penka', 'Kovrata', '20090506')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Bate Goyko', 'Ciganina', '20080614')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Bay Mangal', 'Bqgai che idvat', '20040101')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Lelya Ginka', 'koqto mi e strinka', '20070809')
INSERT INTO Authors(AuthorName, Description, RegisterDate) VALUES ('Chicho Mitko', 'Boklik', '20050219')

DECLARE @Counter int
SET @Counter = 0
WHILE (SELECT COUNT(*) FROM Authors) < 10000000
BEGIN
  INSERT INTO Authors(AuthorName, Description, RegisterDate)
  SELECT AuthorName + CONVERT(varchar, @Counter), Description, RegisterDate FROM Authors
  SET @Counter = @Counter + 1
END

DELIMITER $$  
CREATE PROCEDURE ABC()
   BEGIN
      DECLARE counter INT Default 1 ;
      simple_loop: LOOP
         SET counter=counter+1;
         IF counter<10000000 THEN
            INSERT INTO Authors(AuthorName, Description, RegisterDate)
			SELECT AuthorName + CONVERT(varchar, @Counter), Description, RegisterDate FROM Authors
         END IF;
   END LOOP simple_loop;
END $$

CALL `ABC`()

CREATE DATABASE PartitioningDB;
USE PartitioningDB;
CREATE TABLE Partitions(
	PartId int NOT NULL AUTO_INCREMENT,
	PartDate datetime,
	PartText nvarchar(100),
	CONSTRAINT PK_Partitions_PartId PRIMARY KEY(PartId)
) PARTITION BY RANGE(YEAR(PartDate))(
	PARTITION p1 VALUES LESS THAN (2006),
    PARTITION p2 VALUES LESS THAN (2007),
	PARTITION p3 VALUES LESS THAN (2008),
	PARTITION p4 VALUES LESS THAN MAXVALUE
);

SELECT * FROM Partitions PARTITION (p3)

SELECT * FROM Partitions
WHERE YEAR(PartDate) < 2007

SELECT * FROM Logs PARTITION(p2)
WHERE YEAR(PartDate) < 2006