CREATE DATABASE [TableRelations]

USE [TableRelations]

--1
CREATE TABLE [Passports](
	[PassportID] INT IDENTITY(101, 1) PRIMARY KEY,
	[PassportNumber] CHAR(8) NOT NULL
)

CREATE TABLE [Persons](
	[PersonId] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(7, 2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportId]) UNIQUE
)

INSERT INTO [Passports]([PassportNumber]) 
	VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
	VALUES	
		('Roberto', 43300.00, 102),
		('Tom', 56100.00, 103),
		('Yana', 60200.00, 101)


--2
CREATE TABLE [Manufacturers](
	[ManufacturerID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models](
	[ModelID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]([Name], [EstablishedOn]) VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO [Models]([Name], [ManufacturerID]) VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

--3

CREATE TABLE [Students](
	[StudentID] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL
	PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students]([Name]) VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO [Exams]([Name]) VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID], [ExamID]) VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--4

CREATE TABLE [Teachers](
	[TeacherID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name], [ManagerID]) VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)