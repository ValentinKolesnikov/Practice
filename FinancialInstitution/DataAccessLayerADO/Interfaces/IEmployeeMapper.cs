using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IEmployeeMapper
    {
        Employee MapFromRow(DataRow row);

        Employee MapFromReader(SqlDataReader reader);

    }
}
