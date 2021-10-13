CREATE DATABASE [Service]

USE [Service]

--Section 1. DDL (30 pts)
CREATE TABLE [Users](
	[Id] INT IDENTITY UNIQUE,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	[Birthdate] DATETIME2,
	[Age] INT,
	[Email] VARCHAR(50) NOT NULL,
	CHECK([Age] BETWEEN 14 AND 110)
)

CREATE TABLE [Departments](
	[Id] INT IDENTITY UNIQUE,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT IDENTITY UNIQUE,
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Birthdate] DATETIME2,
	[Age] INT,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
	CHECK([Age] BETWEEN 18 AND 110)
)

CREATE TABLE [Categories](
	[Id] INT IDENTITY UNIQUE,
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
)

CREATE TABLE [Status](
	[Id] INT IDENTITY UNIQUE,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE [Reports](
	[Id] INT IDENTITY UNIQUE,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[StatusId] INT FOREIGN KEY REFERENCES [Status]([Id]),
	[OpenDate] DATETIME2 NOT NULL,
	[CloseDate] DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES [Users]([Id]),
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
)

--2.	Insert
INSERT INTO [Employees]([FirstName], [LastName], [Birthdate], [DepartmentId]) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21',	9),
('Ronnie', 'Peterson', '1944-02-14',9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO [Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId]) VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--3.	Update
UPDATE [Reports]
   SET [CloseDate] = GETDATE()
 WHERE [CloseDate] IS NULL

--4.	Delete
DELETE FROM [Reports]
WHERE [StatusId] = 4

--5.	Unassigned Reports
   SELECT [Description], 
          FORMAT([OpenDate], 'dd-MM-yyyy') AS [OpenDate]
     FROM [Reports] AS r
LEFT JOIN [Employees] AS e
       ON r.[EmployeeId] = e.[Id]
    WHERE [EmployeeId] IS NULL
 ORDER BY r.[OpenDate]


--6.	Reports & Categories
SELECT * FROM(
   SELECT r.[Description], 
	      c.[Name] AS [CategoryName]
     FROM [Reports] AS r
JOIN [Categories] AS c
       ON r.[CategoryId] = c.[Id]
	   ) AS [CategoriesSub]
ORDER BY [Description], [CategoryName]

--7.	Most Reported Category
   SELECT TOP (5) 
          c.[Name] AS [CategoryName],
	      COUNT(c.[Id]) AS [ReportsNumber]
     FROM [Reports] AS r
LEFT JOIN [Categories] AS c
       ON r.[CategoryId] = c.[Id]
 GROUP BY c.[Name]
 ORDER BY [ReportsNumber] DESC, [CategoryName]

--8.	Birthday Report
    SELECT u.[Username],
		   c.[Name] AS [CategoryName]
      FROM [Reports] AS r
 LEFT JOIN [Users] AS u
        ON r.[UserId] = u.[Id]
 LEFT JOIN [Categories] AS c
        ON r.[CategoryId] = c.[Id]
     WHERE FORMAT(r.[OpenDate], 'dd-MM') = FORMAT(u.[Birthdate], 'dd-MM')
  ORDER BY u.[Username], c.[Name]

 --9.	Users per Employee ??
 SELECT [FullName], 
        COUNT([UserId]) AS [UsersCount] 
		FROM(
 SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName],
        r.[UserId],
		r.[EmployeeId]
FROM [Employees] AS e
LEFT JOIN [Reports] AS r
ON e.[Id] = r.[EmployeeId]
) AS [FullNameSub]
GROUP BY [EmployeeId], [FullName]
ORDER BY [UsersCount] DESC, [FullName]