using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IServiceHistoryMapper
    {
        ServicesHistory MapFromRow(DataRow row);
        ServicesHistory MapFromReader(SqlDataReader reader);


    }
}
