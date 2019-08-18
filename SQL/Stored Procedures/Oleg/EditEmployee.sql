USE FinancialInstitution
GO
CREATE PROCEDURE EditEmployee
    @id INT,
    @firstname NVARCHAR(50),
    @secondName NVARCHAR(50),
    @middleName NVARCHAR(50),
    @birthDay DATE,
    @branchID INT,
    @positionID INT
AS
UPDATE [dbo].[Employee]
SET [dbo].[Employee].[Firstname] = @firstname,
    [dbo].[Employee].[SecondName] = @secondName,
    [dbo].[Employee].[MiddleName] = @middleName,
    [dbo].[Employee].[BirthDay] = @birthDay,
    [dbo].[Employee].[BranchID] = @branchID,
    [dbo].[Employee].[PositionID] = @positionID
WHERE [dbo].[Employee].[Id] = @id