USE [FinancialInstitution]
GO
CREATE PROCEDURE EditService
    @serviceid INT,
    @newname NVARCHAR(50) AS
UPDATE ServicesDirectory
SET Name = @newname
WHERE Id = @serviceid