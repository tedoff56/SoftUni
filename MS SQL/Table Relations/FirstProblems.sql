CREATE DATABASE [TableRelations]

USE [TableRelations]

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