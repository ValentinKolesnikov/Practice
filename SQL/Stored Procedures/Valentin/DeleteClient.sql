USE FinancialInstitution
GO

CREATE PROCEDURE DeleteClient
   @id INT
AS
DELETE [dbo].[Client]
WHERE [dbo].[Client].[Id] = @id