USE FinancialInstitution
GO
CREATE PROCEDURE AddServiceHistory
    @date DATETIME,
    @employeeid INT,
    @serviceid INT,
    @clientid INT
AS
INSERT [dbo].[ServicesHistory] ([Date], [EmployeeID], [ServiceID], [ClientID])
VALUES (@date,@employeeid,@serviceid,@clientid)