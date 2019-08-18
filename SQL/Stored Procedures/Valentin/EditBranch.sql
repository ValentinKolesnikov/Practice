USE [FinancialInstitution]
GO
CREATE PROCEDURE EditBranch
    @id INT,
    @name NVARCHAR(50),
	@address NVARCHAR(50)
AS
UPDATE [dbo].[Branch]
set [dbo].[Branch].[Name] = @name,
    [dbo].[Branch].[Address] = @address

WHERE [dbo].[Branch].[Id] = @id