CREATE DATABASE [Minions];

USE [Minions];

CREATE TABLE [Minions]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT,
	[TownId] INT NOT NULL FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [Towns]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

INSERT INTO [Towns]([Id], [Name])
VALUES (1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES (1, 'Kevin', 22, 1), (2, 'Bob', 15, 3), (3, 'Steward', NULL, 2)

TRUNCATE TABLE [Minions]

DROP TABLE [Minions]

DROP TABLE [Towns]

CREATE TABLE [People]
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(400) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH ([Picture]) <= 2000000),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biographt] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate]) VALUES 
	('Pesho', 'm', '1995-10-02'), 
	('Ivan', 'm', '1995-03-02'), 
	('Gosho', 'm', '1993-10-04'), 
	('Ivana', 'f', '1994-04-05'), 
	('Mihaela', 'f', '1994-10-02') 

DROP TABLE [People]

CREATE TABLE [Users]
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password]) VALUES
	('Pesho', '123456'), 
	('Ivan', 'dfgdfgd'), 
	('Gosho', '1251rfs'), 
	('Ivana', 'asda23veq'), 
	('Mihaela', '5ryuhnsdf') 

DROP TABLE [Users]

ALTER TABLE [Users]
	DROP CONSTRAINT PK__Users__3214EC07C6556A69

ALTER TABLE [Users]
	ADD CONSTRAINT PK_UsersIdUsername 
	PRIMARY KEY([Id], [Username])

ALTER TABLE [Users]
	ADD CONSTRAINT CHK_PasswordLength 
	CHECK (DATALENGTH([Password]) >= 5)

ALTER TABLE [Users]
	ADD CONSTRAINT DF_LastLoginTimeCurrentTime 
	DEFAULT GETDATE() FOR [LastLoginTime];

ALTER TABLE [Users]
	DROP CONSTRAINT PK_UsersIdUsername

ALTER TABLE [Users]
	ADD CONSTRAINT PK_UsersId PRIMARY KEY ([Id])

ALTER TABLE [Users]
	ADD CONSTRAINT UQ_UsersUsername UNIQUE ([Username])

ALTER TABLE [Users]
	ADD CONSTRAINT CHK_UsersUsernameLength 
	CHECK (DATALENGTH([Username]) >= 3)

