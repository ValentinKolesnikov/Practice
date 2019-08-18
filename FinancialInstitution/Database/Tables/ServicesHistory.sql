CREATE TABLE [dbo].[ServicesHistory]
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME NOT NULL,
	[EmployeeId] INT REFERENCES Employee (ID) NOT NULL,
	[ServicesDirectoryId] INT REFERENCES ServicesDirectory (ID) NOT NULL,
	[ClientId] INT REFERENCES Client (ID) NOT NULL
)
