--1. Records’ Count
SELECT COUNT(*) AS [Count] 
  FROM [WizzardDeposits]

--2. Longest Magic Wand
SELECT MAX([MagicWandSize]) AS [LongestMagicWand] 
  FROM [WizzardDeposits]

--3. Longest Magic Wand Per Deposit Groups
  SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--5. Deposits Sum
  SELECT [DepositGroup], SUM([DepositAmount]) 
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--6. Deposits Sum for Ollivander Family
  SELECT [DepositGroup], 
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--7. Deposits Filter
  SELECT * FROM 
    (
  SELECT [DepositGroup], 
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
	) AS [Sums]
   WHERE [TotalSum] < 150000
ORDER BY [TotalSum] DESC

--8.  Deposit Charge
  SELECT [DepositGroup], 
         [MagicWandCreator],
		 MIN([DepositCharge])
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

--9. Age Groups
SELECT [AgeGroup], 
       SUM([WizardCount]) AS [WizardCount]
	   FROM
	 (
   SELECT CASE
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
	     END AS [AgeGroup],
	     COUNT([Id]) AS [WizardCount]
    FROM [WizzardDeposits]
GROUP BY [Age]
    ) AS [AgeGroup]
GROUP BY [AgeGroup]

--10. First Letter
  SELECT UPPER(LEFT([FirstName], 1)) AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY UPPER(LEFT([FirstName], 1))

--11. Average Interest 
  SELECT [DepositGroup],
	     [IsDepositExpired],
	     AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--13. Departments Total Salaries
USE [SoftUni]

  SELECT [DepartmentID],
	     SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]

--14. Employees Minimum Salaries
  SELECT [DepartmentID], 
	     MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]

--15. Employees Average Salaries
SELECT * INTO [EmployeesCopy] 
  FROM Employees
 WHERE [Salary] > 30000

DELETE FROM [EmployeesCopy]
 WHERE [ManagerID] = 42

UPDATE [EmployeesCopy]
   SET [Salary] = [Salary] + 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID], 
         AVG([Salary]) AS [AverageSalary]
    FROM [EmployeesCopy]
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries
  SELECT [DepartmentID], MAX([Salary])
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(*) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL
