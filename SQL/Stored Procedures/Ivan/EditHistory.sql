USE FinancialInstitution
GO
CREATE PROCEDURE EditHistory
    @historyid INT,
    @date DATETIME,
    @employeeid INT,
    @serviceid INT,
    @clientid INT AS
UPDATE [dbo].[ServicesHistory]
SET
    Date = @date,
    EmployeeID =@employeeid,
    ServiceID=@serviceid,
    ClientID=@clientid
WHERE Id =@historyid