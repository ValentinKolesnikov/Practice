USE [FinancialInstitution]
GO
CREATE PROCEDURE EditClient
    @id INT,
    @firstName NVARCHAR(50),
	@secondName NVARCHAR(50),
	@middleName NVARCHAR(50),
	@birthDay DATE,
	@address NVARCHAR(50),
	@passport NVARCHAR(50),
	@cardNumber NVARCHAR(50)
AS
UPDATE [dbo].[Client]
set [dbo].[Client].[Firstname] = @firstname,
    [dbo].[Client].[SecondName] = @secondName,
    [dbo].[Client].[MiddleName] = @middleName,
    [dbo].[Client].[BirthDay] = @birthDay,
    [dbo].[Client].[Address] = @address,
	[dbo].[Client].[Passport_series_and_number] = @passport,
	[dbo].[Client].[Card_number] = @cardNumber

WHERE [dbo].[Client].[Id] = @id