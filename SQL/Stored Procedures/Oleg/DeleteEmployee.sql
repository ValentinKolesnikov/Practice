USE FinancialInstitution;

GO

CREATE PROCEDURE DeleteEmployee
   @id INT
AS
DELETE [dbo].[Employee]
WHERE [dbo].[Employee].[Id] = @id
GO
