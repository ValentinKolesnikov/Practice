using DataAccessLayerCommon;
using DataAccessLayerADO.Interfaces;

using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Mappers
{
    public class ServiceDirectoryMapper: IServiceDirectoryMapper
    {
        public  ServicesDirectory MapFromRow(DataRow row)
        {
            ServicesDirectory service = new ServicesDirectory();
            service.Id = row.Field<int>("ServicesDirectoryId");
            service.Name = row.Field<string>("ServicesDirectoryName");
            return service;
        }

        public ServicesDirectory MapFromReader(SqlDataReader reader)
        {
            ServicesDirectory service = new ServicesDirectory();
            service.Id = (int)reader["ServicesDirectoryId"];
            service.Name = (string)reader["ServicesDirectoryName"];
            return service;
        }
    }
}
