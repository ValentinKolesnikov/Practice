USE FinancialInstitution;

GO

CREATE PROCEDURE AddEmployee
   @firstname NVARCHAR(50),
   @secondName NVARCHAR(50),
   @middleName NVARCHAR(50),
   @birthDay DATE,
   @branchID INT,
   @positionID INT
AS
INSERT INTO [dbo].[Employee]
        ([Firstname], [SecondName], [MiddleName], [BirthDay], [BranchID], [PositionID])
    VALUES
        ( @firstname, @secondName, @middleName, @birthDay, @branchID, @positionID)