 CREATE DATABASE CigarShop

 USE CigarShop

 --1.	Database design
 CREATE TABLE Sizes
 (
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
	RingRange DECIMAL(4,2) NOT NULL,
	CHECK([Length] BETWEEN 10 AND 25),
	CHECK(RingRange BETWEEN 1.5 AND 7.5)
 )

 CREATE TABLE Tastes
 (
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(200) NOT NULL
 )

 CREATE TABLE Brands
 (
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
 )

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(10, 4) NOT NULL,
	ImageURL NVARCHAR(200) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(60) NOT NULL,
	Streat NVARCHAR(200) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(60) NOT NULL,
	LastName NVARCHAR(60) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)


--2.	Insert
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) 
VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

--3.	Update
UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2
WHERE EXISTS(SELECT * FROM Cigars AS c
			 LEFT JOIN Tastes AS t
			 ON c.TastId = t.Id
			 WHERE TasteType = 'Spicy')

UPDATE [Brands]
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4.	Delete
ALTER TABLE Clients 
ALTER COLUMN AddressId INT NULL

UPDATE Clients
SET AddressId = NULL
WHERE EXISTS(SELECT * FROM Addresses WHERE LEFT(Country, 1) = 'C')

DELETE FROM Addresses
WHERE LEFT(Country, 1) = 'C'

--5.	Cigars by Price
SELECT CigarName, PriceForSingleCigar, ImageURL FROM Cigars
ORDER BY PriceForSingleCigar, CigarName DESC

--6.	Cigars by Taste
SELECT c.Id, 
       c.CigarName, 
	   c.PriceForSingleCigar, 
	   t.TasteType, 
	   t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t
ON c.TastId = t.Id
WHERE t.TasteType IN('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

--7.	Clients without Cigars
SELECT c.Id,
	   CONCAT(c.FirstName, ' ', c.LastName) AS ClientName,
	   c.Email
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc
ON c.Id = cc.ClientId
LEFT JOIN Cigars AS cig
ON cc.CigarId = cig.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName

--8.	First 5 Cigars??
SELECT TOP (5) 
		c.CigarName,
		c.PriceForSingleCigar,
		c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s
ON c.SizeId = s.Id
WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC


--9.	Clients with ZIP Codes
SELECT FullName, Country, ZIP, CONCAT('$', MAX(CigarPrice)) FROM
(SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	   a.Country,
	   a.ZIP,
	   cig.PriceForSingleCigar AS CigarPrice
FROM Clients AS c
LEFT JOIN Addresses AS a
ON c.AddressId = a.Id
LEFT JOIN ClientsCigars AS cc
ON c.Id = cc.ClientId
LEFT JOIN Cigars AS cig
ON cc.CigarId = cig.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%') AS ZipSubq
GROUP BY FullName, Country, ZIP

--10.	Cigars by Size
SELECT c.LastName,
       AVG(s.[Length]) AS CiagrLength,
	   CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM ClientsCigars AS cc
JOIN Clients AS c
ON cc.ClientId = c.Id
JOIN Cigars AS cig
ON cc.CigarId = cig.Id
JOIN Sizes AS s
ON cig.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--11.	Client with Cigars
GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(60))
RETURNS INT AS
BEGIN
	DECLARE @CigarsCount INT = (SELECT COUNT(*) FROM ClientsCigars AS cc
	JOIN Clients AS c
	ON cc.ClientId = c.Id
	JOIN Cigars AS cig
	ON cc.CigarId = cig.Id
	WHERE c.FirstName = @name)

	RETURN @CigarsCount
END

 GO

 --12.	Search for Cigar with Specific Taste
 CREATE PROCEDURE usp_SearchByTaste @taste VARCHAR(20)
 AS
 BEGIN
	SELECT c.CigarName,
		   CONCAT('$', c.PriceForSingleCigar) AS Price,
		   t.TasteType,
		   b.BrandName,
		   CONCAT(s.[Length], ' cm') AS CigarLength,
		   CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars AS c
	JOIN Brands AS b
	ON c.BrandId = b.Id
	JOIN Tastes AS t
	ON c.TastId = t.Id
	JOIN Sizes AS s
	ON c.SizeId = s.Id
	WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC
 END

 EXEC usp_SearchByTaste 'Woody'