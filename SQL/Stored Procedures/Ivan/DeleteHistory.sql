USE FinancialInstitution
GO
CREATE PROCEDURE DeleteHistory
    @historyid INT AS
DELETE  [dbo].[ServicesHistory]
WHERE [Id]=@historyid