using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayerADO.Interfaces
{
    public interface IBranchMapper
    {
        Branch MapFromRow(DataRow row);

        Branch MapFromReader(SqlDataReader reader);

    }
}
