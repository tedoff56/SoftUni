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