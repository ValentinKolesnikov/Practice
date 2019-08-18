USE FinancialInstitution
GO
CREATE PROCEDURE AddClient
	@firstName NVARCHAR(50),
	@secondName NVARCHAR(50),
	@middleName NVARCHAR(50),
	@birthDay DATE,
	@address NVARCHAR(50),
	@passport NVARCHAR(50),
	@cardNumber NVARCHAR(50) 
AS

INSERT INTO [dbo].[Client] 
	([Firstname], [SecondName], [MiddleName], [BirthDay], [Address], [Passport_series_and_number], [Card_number])
VALUES 
	(@firstName, @secondName, @middleName, @birthDay, @address, @passport, @cardNumber)