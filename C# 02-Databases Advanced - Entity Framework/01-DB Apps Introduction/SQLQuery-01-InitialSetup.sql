USE MinionsDB

CREATE TABLE Minions
(Id INT IDENTITY NOT NULL,
Name NVARCHAR(25),
Age INT,
TownID INT,
CONSTRAINT PK_Minions PRIMARY KEY (Id)
)

CREATE TABLE Towns
(Id INT IDENTITY NOT NULL,
TownName NVARCHAR(35),
CountryName NVARCHAR(35),
CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Villains
(Id INT IDENTITY NOT NULL,
Name NVARCHAR(25),
EvilnessFactor VARCHAR(10) CHECK (EvilnessFactor IN ('good', 'bad', 'evil', 'super evil')),
CONSTRAINT PK_Villains PRIMARY KEY (Id)
)

CREATE TABLE MinionsVillains
(MinionID INT,
VillainID INT,
CONSTRAINT PK_MinionsVillainsIDs PRIMARY KEY (MinionID, VillainID)
)

--CONSTRAINT FK_MinionIDs FOREIGN KEY (MinionID) REFERENCES Minions(Id),
--CONSTRAINT FK_VillainIDs FOREIGN KEY (VillainID) REFERENCES Villains(Id)


INSERT INTO Minions (Name, Age, TownId)
VALUES
	('Mark', 23, 4),
	('Arthur', 21, 2),
	('Tom', 35, 5),
	('John', 40, 1),
	('Tim', 33, 3)


INSERT INTO Towns (TownName, CountryName)
VALUES 
	('Varna', 'Bulgaria'),
	('London', 'UK'),
	('Toronto', 'Canada'),
	('Budapest', 'Hungary'),
	('Moscow', 'Russia')


INSERT INTO Villains (Name, EvilnessFactor)
VALUES
	('Jimmy', 'bad'),
	('Kain', 'good'),
	('Jill', 'evil'),
	('Mons', 'super evil'),
	('Jerry', 'good')

INSERT INTO MinionsVillains (MinionId, VillainId)
VALUES	
	(1, 2),
	(2, 3),
	(5, 2), 
	(3, 3), 
	(4, 3),
	(2, 2),
	(1, 1), 
	(4, 2),
	(1, 3)