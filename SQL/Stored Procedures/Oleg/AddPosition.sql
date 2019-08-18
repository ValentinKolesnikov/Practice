USE FinancialInstitution;

GO

CREATE PROCEDURE AddPosition
   @name NVARCHAR(50),
    @flag BIT
AS
INSERT INTO [dbo].[Position]
        ([Name], [Flag])
    VALUES
        ( @name, @flag) 