CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategotyName] NVARCHAR NOT NULL,
	[Notes] NVARCHAR
)

CREATE TABLE [Movies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] DATE NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] FLOAT,
	[Notes] NVARCHAR
)

DROP TABLE [Genres]
DROP TABLE [Directors]
DROP TABLE [Categories]
DROP TABLE [Movies]

ALTER TABLE [Movies]
	ADD CONSTRAINT FK_MoviesGenreId FOREIGN KEY ([GenreId]) REFERENCES Genres([Id])

ALTER TABLE [Movies]
	ADD CONSTRAINT FK_MoviesCategoryId FOREIGN KEY ([CategoryId]) REFERENCES Categories([Id])

ALTER TABLE [Movies]
	ADD CONSTRAINT FK_MoviesDirectorId FOREIGN KEY (DirectorId) REFERENCES Directors([Id])
