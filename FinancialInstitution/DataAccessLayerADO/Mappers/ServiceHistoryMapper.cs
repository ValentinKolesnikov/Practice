using DataAccessLayerCommon;
using DataAccessLayerADO.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Mappers
{
    public class ServiceHistoryMapper: IServiceHistoryMapper
    {
        public ServicesHistory MapFromRow(DataRow row)
        {
            ServicesHistory serviceHistory = new ServicesHistory();
            serviceHistory.Id = row.Field<int>("ServicesHistoryId");
            serviceHistory.Date = row.Field<DateTime>("ServicesHistoryDate");
            serviceHistory.ServicesDirectoryId = row.Field<int>("ServicesHistoryServiceId");
            serviceHistory.EmployeeId = row.Field<int>("ServicesHistoryEmployeeId");
            serviceHistory.ClientId = row.Field<int>("ServicesHistoryClientId");
            return serviceHistory;
        }

        public  ServicesHistory MapFromReader(SqlDataReader reader)
        {
            ServicesHistory serviceHistory = new ServicesHistory();
           
          
            serviceHistory.Id = (int)reader["ServicesHistoryId"];
            serviceHistory.Date = (DateTime)reader["ServicesHistoryDate"]; ;
            serviceHistory.ServicesDirectoryId = (int)reader["ServicesHistoryServiceId"]; ;
            serviceHistory.EmployeeId = (int)reader["ServicesHistoryEmployeeId"]; ;
            serviceHistory.ClientId = (int)reader["ServicesHistoryClientId"]; ;

            return serviceHistory;
        }
    }
}
