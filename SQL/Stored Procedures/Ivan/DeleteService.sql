USE [FinancialInstitution]
GO
CREATE PROCEDURE DeleteService
    @serviceid INT 
AS
    DELETE ServicesDirectory
    WHERE Id = @serviceid