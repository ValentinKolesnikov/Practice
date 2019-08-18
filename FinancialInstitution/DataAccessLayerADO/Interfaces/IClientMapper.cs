using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IClientMapper
    {
        Client MapFromRow(DataRow row);

        Client MapFromReader(SqlDataReader reader);
       
    }
}
