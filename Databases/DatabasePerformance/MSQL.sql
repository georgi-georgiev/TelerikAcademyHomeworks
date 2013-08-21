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

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Authors
WHERE YEAR(RegisterDate)> 2005 AND YEAR(RegisterDate)<2008
-- on my computer 00:01:01

CREATE INDEX DateIndex
ON Authors (RegisterDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Authors
WHERE YEAR(RegisterDate)> 2005 AND YEAR(RegisterDate)<2008
-- on my computer with index 00:02:05

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Authors
WHERE Description LIKE 'Bog%'

CREATE FULLTEXT CATALOG AuthorsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Authors(Description)
KEY INDEX PK_Authors_AuthorId
ON AuthorsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Authors
WHERE Description LIKE 'Bog%'