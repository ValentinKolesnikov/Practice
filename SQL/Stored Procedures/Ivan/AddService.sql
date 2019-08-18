USE [FinancialInstitution]
GO
CREATE PROCEDURE AddService
    @name NVARCHAR(50) AS
INSERT ServicesDirectory (Name) VALUES (@name)