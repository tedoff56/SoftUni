USE [SoftUni]

--1.	Employee Address
    SELECT TOP (5) 
           e.[EmployeeID], 
           e.[JobTitle], 
	 	   e.[AddressID], 
	 	   a.[AddressText] 
      FROM [Employees] AS e
 LEFT JOIN [Addresses] AS a
        ON e.[AddressID] = a.[AddressID]
  ORDER BY e.[AddressID]

--2.	Addresses with Towns
   SELECT TOP (50) 
          e.[FirstName], 
		  e.[LastName], 
		  t.[Name], 
		  a.[AddressText]
     FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
       ON e.[AddressID] = a.[AddressID]
LEFT JOIN [Towns] AS t
       ON a.[TownID] = t.[TownID]
 ORDER BY e.[FirstName], e.[LastName]

 --3.	Sales Employee
    SELECT e.[EmployeeID], 
	       e.[FirstName], 
		   e.[LastName], 
		   d.[Name] 
      FROM [Employees] as e
 LEFT JOIN [Departments] AS d
        ON e.[DepartmentID] = d.[DepartmentID]
     WHERE d.Name = 'Sales'
  ORDER BY e.[EmployeeID]

--4.	Employee Departments
    SELECT TOP (5)
	       e.[EmployeeID], 
		   e.[FirstName], 
		   e.[Salary], 
		   d.[Name] 
      FROM [Employees] as e
 LEFT JOIN [Departments] AS d
        ON e.[DepartmentID] = d.[DepartmentID]
		WHERE e.[Salary] > 15000
		ORDER BY e.[DepartmentID]

--5.	Employees Without Project
   SELECT TOP (3)
          e.[EmployeeID], 
	      e.[FirstName]
     FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
       ON e.[EmployeeID] = ep.EmployeeID
    WHERE ep.[ProjectID] IS NULL
 ORDER BY e.[EmployeeID]

 --6.	Employees Hired After
    SELECT e.[FirstName], 
           e.[LastName], 
		   e.[HireDate], 
	  	   d.[Name]
      FROM [Employees] AS e
 LEFT JOIN [Departments] AS d
        ON e.[DepartmentID] = d.DepartmentID
     WHERE YEAR(e.[HireDate]) >= 1999 AND d.[Name] IN ('Sales', 'Finance')
  ORDER BY e.[HireDate]

--7.	Employees with Project
   SELECT TOP (5)
          e.[EmployeeID], 
		  e.[FirstName], 
		  p.[Name]
     FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
       ON e.[EmployeeID] = ep.[EmployeeID]
LEFT JOIN [Projects] AS p
       ON ep.[ProjectID] = p.[ProjectID]
    WHERE p.[StartDate] > '09.13.2002' AND p.[EndDate] IS NULL
 ORDER BY e.[EmployeeID]

 --8.	Employee 24
   SELECT e.[EmployeeID], 
		  e.[FirstName], 
		  CASE
				WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
				ELSE p.[Name]
		  END AS [ProjectName]
     FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
       ON e.[EmployeeID] = ep.[EmployeeID]
LEFT JOIN [Projects] AS p
       ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24

--9.	Employee Manager
    SELECT e.[EmployeeID], 
		   e.[FirstName], 
		   e.[ManagerID], 
		   m.[FirstName] AS [ManagerName]
      FROM [Employees] AS e
INNER JOIN [Employees] AS m
		ON e.[ManagerID] = m.[EmployeeID]
	 WHERE e.[ManagerID] IN (3, 7)
  ORDER BY e.[EmployeeID]

 --10. Employee Summary
	SELECT TOP (50)
	       e.[EmployeeID], 
	       CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName],
		   CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName],
		   d.[Name]
	  FROM [Employees] AS e
 LEFT JOIN [Employees] AS m
	    ON e.[ManagerID] = m.[EmployeeID]
 LEFT JOIN [Departments] AS d
	    ON e.[DepartmentID] = d.[DepartmentID]
  ORDER BY e.[EmployeeID]

 --11. Min Average Salary
	 SELECT MIN([LowestSalary]) FROM 
	 (
	 SELECT AVG(e.[Salary]) AS LowestSalary 
	   FROM [Employees] AS e
  LEFT JOIN [Departments] AS d
		 ON e.[DepartmentID] = d.[DepartmentID]
   GROUP BY e.[DepartmentID]
     ) AS Salaries


--12. Highest Peaks in Bulgaria
USE [Geography]

   SELECT c.[CountryCode],
		  m.[MountainRange],
		  p.[PeakName],
		  p.[Elevation]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] as mc
	   ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
	   ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
	   ON mc.[MountainId] = p.[MountainId]
	WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
 ORDER BY p.[Elevation] DESC

--13. Count Mountain Ranges
   SELECT c.[CountryCode], 
		  COUNT(m.[MountainRange]) AS [MountainRanges]
     FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
	   ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
	   ON mc.[MountainId] = m.[Id]
    WHERE c.[CountryCode] IN ('BG', 'RU', 'US')
 GROUP BY c.[CountryCode]

 --14. Countries with Rivers
   SELECT TOP (5)
		  c.[CountryName],
		  r.[RiverName]
     FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
	   ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
	   ON cr.[RiverId] = r.[Id]
    WHERE c.[ContinentCode] = 'AF'
 ORDER BY c.[CountryName]

 --16. Countries Without Any Mountains
	SELECT COUNT(c.[CountryCode])
	  FROM [Countries] AS c
 LEFT JOIN [MountainsCountries] AS mc
	    ON c.[CountryCode] = mc.[CountryCode]
	 WHERE mc.[MountainId] IS NULL


 --17. Highest Peak and Longest River by Country
SELECT TOP (5)
	   [CountryName],	
	   [HighestPeakElevation],
	   [LongestRiverLength]
  FROM (
	SELECT c.[CountryName],
		   MAX(p.[Elevation]) AS [HighestPeakElevation],
		   MAX(r.[Length]) AS [LongestRiverLength]
	  FROM [Countries] AS c
 LEFT JOIN [MountainsCountries] AS mc
		ON c.[CountryCode] = mc.[CountryCode]
 LEFT JOIN [Peaks] AS p
		ON mc.[MountainId] = p.[MountainId]
 LEFT JOIN [CountriesRivers] AS cr
		ON c.[CountryCode] = cr.[CountryCode]
 LEFT JOIN [Rivers] AS r
		ON cr.[RiverId] = r.[Id]
  GROUP BY c.[CountryName]
	  ) AS [HighestPeakLongestRiver]
  ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]

