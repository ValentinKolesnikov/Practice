using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IServiceDirectoryMapper
    {
        ServicesDirectory MapFromRow(DataRow row);

        ServicesDirectory MapFromReader(SqlDataReader reader);
       
    }
}
