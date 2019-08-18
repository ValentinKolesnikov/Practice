USE [FinancialInstitution]
GO
CREATE PROCEDURE EditPosition
    @id INT,
   @name NVARCHAR(50)
AS
UPDATE [dbo].[Position] set [dbo].[Position].[Name] = @name WHERE [dbo].[Position].[Id] = @id