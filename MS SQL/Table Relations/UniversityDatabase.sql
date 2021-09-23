CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY,
	[StudentNumber] VARCHAR(50) NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY([StudentID], [SubjectID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(10, 2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)