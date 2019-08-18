using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IPositionMapper
    {
        Position MapFromRow(DataRow row);

        Position MapFromReader(SqlDataReader reader);

    }
}
