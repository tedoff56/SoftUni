CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT IDENTITY PRIMARY KEY,
	[DirectorName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Genres](
	[Id] INT IDENTITY PRIMARY KEY,
	[GenreName] VARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Categories](
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] VARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Movies](
	[Id] INT IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(MAX) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] INT NOT NULL, 
	[Length] TIME  NOT NULL, 
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL, 
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL, 
	[Rating] FLOAT, 
	[Notes] NVARCHAR
)

INSERT INTO [Directors] ([DirectorName]) VALUES
	('Шон Леви'),
	('Дестин Даниел Кретън'),
	('Антоан Фукуа'),
	('Пол Шрадер'),
	('Едгар Райт')

INSERT INTO [Genres] ([GenreName]) VALUES
	('Action'),
	('Triller'),
	('Comedy'),
	('Drama'),
	('Mistery')

INSERT INTO [Categories]([CategoryName]) VALUES
	('Action'),
	('Triller'),
	('Comedy'),
	('Drama'),
	('Mistery')

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId]) VALUES 
	('Free Guy', 4,  2021, '01:55', 1, 3),
	('Shang-Chi and the Legend of the Ten Rings', 3, 2021, '02:12', 1, 5),
	('The Guilty', 3, 2021, '01:30', 5, 1),
	('The Card Counter', 3, 2021, '01:51', 2, 5),
	('Last Night in Soho', 4, 2021, '01:56', 4, 3)

