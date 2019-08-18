USE FinancialInstitution;
GO
CREATE PROCEDURE DeleteBranch
   @id INT
AS
DELETE [dbo].[Branch]
WHERE [dbo].[Branch].[Id] = @id