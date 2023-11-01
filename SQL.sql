--Create a database
CREATE DATABASE DotNetCourseDatabase
GO

USE DotNetCourseDatabase
GO

CREATE SCHEMA TutorialAppSchema
GO

CREATE TABLE TutorialAppSchema.Computer(
	ComputerId INT IDENTITY(1,1) PRIMARY KEY,
	Motherboard NVARCHAR(50),
	CPUCores INT,
	HasWifi BIT,
	HasLTE BIT,
	ReleaseDate DATE,
	Price DECIMAL(18,4),
	VideoCard NVARCHAR(50)
);

SELECT * FROM TutorialAppSchema.Computer
-----------------------
--Create a login to SQL based on Windows account
CREATE LOGIN [<domainName>\<loginName>] FROM WINDOWS;
CREATE LOGIN [DESKTOP-CFCPFSG\JOBB] FROM WINDOWS;
--Grant reader permission
USE DotNetCourseDatabase
EXEC sp_addrolemember 'db_datareader', 'DESKTOP-CFCPFSG\JOBB';
--Grant owner permission
use DotNetCourseDatabase
exec sp_addrolemember 'db_owner', 'DESKTOP-CFCPFSG\JOBB';
