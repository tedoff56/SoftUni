--Problem 1.	Find Names of All Employees by First Name

SELECT [FirstName], [LastName] 
  FROM [Employees]
 WHERE LEFT([FirstName], 2) = 'Sa'

--Problem 2.	  Find Names of All employees by Last Name 

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

--Problem 3.	Find First Names of All Employees

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005

 --Problem 4.	Find All Employees Except Engineers

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

--Problem 6.	 Find Towns Starting With

  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE [Name] LIKE '[mkbe]%'
ORDER BY [Name]

--Problem 7.	 Find Towns Not Starting With

  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE '[rbd]%'
ORDER BY [Name]

--Problem 8.	Create View Employees Hired After 2000 Year

GO
CREATE VIEW [V_EmployeesHiredAfter2000] AS (
     SELECT [FirstName], [LastName]
       FROM [Employees]
      WHERE YEAR([HireDate]) > 2000)

GO

--Problem 9.	Length of Last Name

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

 --Problem 10.	Rank Employees by Salary

  SELECT [EmployeeID],
         [FirstName],
		 [LastName],
		 [Salary],
		 DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--Problem 11.	Find All Employees with Rank 2 *

  SELECT * FROM
  (
  SELECT [EmployeeID],
         [FirstName],
		 [LastName],
		 [Salary],
		 DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
   ) AS r
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

--Problem 12.	Countries Holding ‘A’ 3 or More Times

USE [Geography]

  SELECT [CountryName] AS [Country Name],
         [IsoCode] AS [ISO Code]
    FROM [Countries]
   WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode] ASC

--Problem 13.	 Mix of Peak and River Names

   SELECT p.PeakName, 
          r.RiverName, 
   	      LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
     FROM [Peaks] AS p, [Rivers] AS r
    WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
 ORDER BY [Mix]

--Problem 14.	Games from 2011 and 2012 year

USE [Diablo]

  SELECT TOP 50 [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM [Games]
   WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start] ASC, [Name] ASC

--Problem 15.	 User Email Providers

   SELECT [Username],
          RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
     FROM [Users]
 ORDER BY [Email Provider] ASC, [Username] ASC

 --Problem 16.	 Get Users with IPAdress Like Pattern

  SELECT [Username], [IpAddress] AS [IP Address] 
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username] ASC

--Problem 17.	 Show All Games with Duration and Part of the Day

SELECT * FROM (
SELECT [Name] AS [Game],
       CASE
			WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
			WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	   END AS [Part of the Day],
	   CASE
			WHEN [Duration] > 0 AND [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
	   END AS [Duration]
  FROM [Games]) AS g
  ORDER BY [Game] ASC, [Duration] ASC, [Part of the Day] ASC

--Problem 18.	 Orders Table

USE [Orders]

SELECT [ProductName],
       [OrderDate],
	   DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
	   DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders]