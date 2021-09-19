CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT IDENTITY PRIMARY KEY, 
	[CategoryName] NVARCHAR(100) NOT NULL, 
	[DailyRate] FLOAT(2) NOT NULL, 
	[WeeklyRate] FLOAT(2) NOT NULL, 
	[MonthlyRate] FLOAT(2) NOT NULL, 
	[WeekendRate] FLOAT(2) NOT NULL
)

CREATE TABLE [Cars](
	[Id] INT IDENTITY PRIMARY KEY, 
	[PlateNumber] NVARCHAR(20) NOT NULL, 
	[Manufacturer] VARCHAR(20) NOT NULL, 
	[Model] NVARCHAR(30) NOT NULL, 
	[CarYear] INT NOT NULL, 
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]), 
	[Doors] INT NOT NULL, 
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Condition] VARCHAR(30) NOT NULL, 
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT IDENTITY PRIMARY KEY, 
	[FirstName] NVARCHAR(50) NOT NULL, 
	[LastName] NVARCHAR(50) NOT NULL, 
	[Title] VARCHAR(50) NOT NULL, 
	[Notes] NVARCHAR(500)
)

CREATE TABLE [Customers](
	[Id] INT IDENTITY PRIMARY KEY, 
	[DriverLicenceNumber] NVARCHAR(50) NOT NULL, 
	[FullName] NVARCHAR(100)NOT NULL, 
	[Address] NVARCHAR , 
	[City] NVARCHAR, 
	[ZIPCode] VARCHAR(20), 
	[Notes] NVARCHAR(500)
)

CREATE TABLE [RentalOrders](
	[Id] INT IDENTITY PRIMARY KEY, 
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL, 
	[CarId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL, 
	[TankLevel] INT, 
	[KilometrageStart] INT, 
	[KilometrageEnd] INT, 
	[TotalKilometrage] FLOAT, 
	[StartDate] DATE, 
	[EndDate]DATE, 
	[TotalDays] INT, 
	[RateApplied] , 
	[TaxRate], 
	[OrderStatus], 
	[Notes]
)