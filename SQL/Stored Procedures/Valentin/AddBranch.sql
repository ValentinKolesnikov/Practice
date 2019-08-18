USE FinancialInstitution
GO
CREATE PROCEDURE AddBranch
	@name NVARCHAR(50),
	@address NVARCHAR(50)
AS

INSERT INTO [dbo].[Branch] 
	([Name], [Address])
VALUES 
	(@name, @address)