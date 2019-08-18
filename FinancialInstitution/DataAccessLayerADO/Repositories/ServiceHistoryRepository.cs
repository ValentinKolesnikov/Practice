using System.Collections.Generic;
using DataAccessLayerADO.Mappers;
using System.Data.SqlClient;
using DataAccessLayerADO.Repositories;
using System.Data;
using DataAccessLayerCommon.Interfaces;
using DataAccessLayerCommon;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Repositories
{
    public class ServiceHistoryRepository : Repository, IServicesHistoryRepository
    {
        private IServiceHistoryMapper serviceHistoryMapper;
        private IServiceDirectoryMapper serviceMapper;
        private IEmployeeMapper employeeMapper;
        private IClientMapper clientMapper;
        public ServiceHistoryRepository(IServiceDirectoryMapper serviceMapper, IServiceHistoryMapper serviceHistoryMapper, IEmployeeMapper employeeMapper, IClientMapper clientMapper)
        {
            this.serviceHistoryMapper = serviceHistoryMapper;
            this.serviceMapper = serviceMapper;
            this.employeeMapper = employeeMapper;
            this.clientMapper = clientMapper;
        }
        public ServicesHistory GetItem(int serviceHistoryId)
        {
            SqlParameter serviceIdParam = new SqlParameter("@serviceHistoryId", serviceHistoryId);
            string expression = @"SELECT ServicesHistory.Id AS ServicesHistoryId ,
                                ServicesHistory.Date AS ServicesHistoryDate, ServicesHistory.ServiceId AS ServicesHistoryServiceId, 
                                ServicesHistory.EmployeeId  AS ServicesHistoryEmployeeId, ServicesHistory.ClientId  AS ServicesHistoryClientId,
                                ServicesDirectory.Id AS 'ServicesDirectoryId', ServicesDirectory.Name AS 'ServicesDirectoryName',
                                Employee.Id AS EmployeeId, Employee.FirstName AS EmployeeFirstName, Employee.SecondName AS EmployeeSecondName,
                                Employee.MiddleName AS EmployeeMiddleName, Employee.BirthDay AS EmployeeBirthDay, Employee.BranchId AS EmployeeBranchId,
                                Employee.PositionId AS EmployeePositionId,
                                Client.Id AS ClientId, Client.FirstName AS ClientFirstName, Client.SecondName AS ClientSecondName,
                                Client.MiddleName AS ClientMiddleName, Client.BirthDay AS ClientBirthDay, Client.Address AS ClientAddress,
                                Client.PassportSeriesAndNumber AS ClientPassportSeriesAndNumber, Client.CardNumber AS ClientCardNumber
                                FROM ServicesHistory 
                                JOIN ServicesDirectory ON ServicesDirectory.Id = ServicesHistory.ServiceId
                                JOIN Employee ON Employee.Id = ServicesHistory.EmployeeId
                                JOIN Client ON Client.Id = ServicesHistory.ClientId
                                WHERE ServicesHistory.Id = @serviceHistoryId";

            SqlCommand command = new SqlCommand(expression, sqlConnection);
            command.Parameters.Add(serviceIdParam);
            ServicesHistory serviceHistory = new ServicesHistory();

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    serviceHistory = serviceHistoryMapper.MapFromReader(reader);
                    serviceHistory.ServicesDirectory = serviceMapper.MapFromReader(reader);
                    serviceHistory.Employee = employeeMapper.MapFromReader(reader);
                    serviceHistory.Client = clientMapper.MapFromReader(reader);
                }
            }
           
            return serviceHistory;
        }
        public IEnumerable<ServicesHistory> GetAll()
        {
            List<ServicesHistory> serviceHistories = new List<ServicesHistory>();
            string expression = @"SELECT ServicesHistory.Id AS ServicesHistoryId ,
                                ServicesHistory.Date AS ServicesHistoryDate, ServicesHistory.ServiceId AS ServicesHistoryServiceId, 
                                ServicesHistory.EmployeeId  AS ServicesHistoryEmployeeId, ServicesHistory.ClientId  AS ServicesHistoryClientId,
                                ServicesDirectory.Id AS 'ServicesDirectoryId', ServicesDirectory.Name AS 'ServicesDirectoryName',
                                Employee.Id AS EmployeeId, Employee.FirstName AS EmployeeFirstName, Employee.SecondName AS EmployeeSecondName,
                                Employee.MiddleName AS EmployeeMiddleName, Employee.BirthDay AS EmployeeBirthDay, Employee.BranchId AS EmployeeBranchId,
                                Employee.PositionId AS EmployeePositionId,
                                Client.Id AS ClientId, Client.FirstName AS ClientFirstName, Client.SecondName AS ClientSecondName,
                                Client.MiddleName AS ClientMiddleName, Client.BirthDay AS ClientBirthDay, Client.Address AS ClientAddress,
                                Client.PassportSeriesAndNumber AS ClientPassportSeriesAndNumber, Client.CardNumber AS ClientCardNumber
                                FROM ServicesHistory
                                JOIN ServicesDirectory ON ServicesDirectory.Id = ServicesHistory.ServiceId
                                JOIN Employee ON Employee.Id = ServicesHistory.EmployeeId
                                JOIN Client ON Client.Id = ServicesHistory.ClientId";

            SqlCommand sqlCommand = new SqlCommand(expression, sqlConnection);
            DataTable dataTable = GetDataTable(sqlCommand);
            foreach (DataRow row in dataTable.Rows)
            {
                ServicesHistory serviceHistory = serviceHistoryMapper.MapFromRow(row);

                serviceHistory.ServicesDirectory = serviceMapper.MapFromRow(row);
                serviceHistory.Employee = employeeMapper.MapFromRow(row);
                serviceHistory.Client = clientMapper.MapFromRow(row);
                serviceHistories.Add(serviceHistory);

            }
            return serviceHistories;
        }
    

        public IEnumerable<ServicesHistory> GetList()
        {
            List<ServicesHistory> serviceHistories = new List<ServicesHistory>();
            string expression = @"SELECT ServicesHistory.Id AS ServicesHistoryId ,
                                ServicesHistory.Date AS ServicesHistoryDate, ServicesHistory.ServiceId AS ServicesHistoryServiceId, 
                                ServicesHistory.EmployeeId  AS ServicesHistoryEmployeeId, ServicesHistory.ClientId  AS ServicesHistoryClientId                                                          
                                FROM ServicesHistory";

            SqlCommand sqlCommand = new SqlCommand(expression, sqlConnection);
            DataTable dataTable = GetDataTable(sqlCommand);
            foreach (DataRow row in dataTable.Rows)
            {
                ServicesHistory serviceHistory = serviceHistoryMapper.MapFromRow(row);
                serviceHistories.Add(serviceHistory);
            }
            return serviceHistories;
        }

        public void Delete(int serviceHistoryId)
        {
            string expression = "DELETE ServicesHistory WHERE Id = @serviceHistoryId";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter serviceHistoryIdParam = new SqlParameter("@serviceHistoryId", serviceHistoryId);
            command.Parameters.Add(serviceHistoryIdParam);
            ExecuteNonQueryCommand(command);
        }

        public void Insert(ServicesHistory serviceHistory)
        {
            string expression = "INSERT [dbo].[ServicesHistory] (Date,EmployeeID,ServiceID,ClientID) VALUES(@date, @employeeid, @serviceid, @clientid)";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter dateParam = new SqlParameter("@date", serviceHistory.Date);
            SqlParameter employeeidParam = new SqlParameter("@employeeid", serviceHistory.EmployeeId);
            SqlParameter serviceidParam = new SqlParameter("@serviceid", serviceHistory.ServicesDirectoryId);
            SqlParameter clientidParam = new SqlParameter("@clientid", serviceHistory.ClientId);
            SqlParameter[] parametrs = new SqlParameter[] { dateParam, employeeidParam, serviceidParam, clientidParam };
            command.Parameters.AddRange(parametrs);
            ExecuteNonQueryCommand(command);
        }

        public void Update(int serviceHistoryId, ServicesHistory serviceHistory)
        {
            string expression = "UPDATE [dbo].[ServicesHistory] SET    Date = @date,EmployeeID = @employeeid,ServiceID = @serviceid,ClientID = @clientid WHERE Id = @serviceHistoryId";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter dateParam = new SqlParameter("@date", serviceHistory.Date);
            SqlParameter employeeidParam = new SqlParameter("@employeeid", serviceHistory.EmployeeId);
            SqlParameter serviceidParam = new SqlParameter("@serviceid", serviceHistory.ServicesDirectoryId);
            SqlParameter clientidParam = new SqlParameter("@clientid", serviceHistory.ClientId);
            SqlParameter serviceHistoryIdParam = new SqlParameter("@serviceHistoryId", serviceHistoryId);
            SqlParameter[] parametrs = new SqlParameter[] { dateParam, employeeidParam, serviceidParam, clientidParam, serviceHistoryIdParam };
            command.Parameters.AddRange(parametrs);
            ExecuteNonQueryCommand(command);
        }

        

    }
}
