USE FinancialInstitution;

GO

CREATE PROCEDURE DeletePosition
   @id INT
AS
DELETE [dbo].[Position]
WHERE [dbo].[Position].[Id] = @id