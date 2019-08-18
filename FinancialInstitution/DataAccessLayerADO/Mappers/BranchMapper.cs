using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Mappers
{
    public class BranchMapper: IBranchMapper
    {
        public  Branch MapFromRow(DataRow row)
        {
            Branch branch = new Branch
            {
                Id = row.Field<int>("BranchId"),
                Name = row.Field<string>("BranchName"),
                Address = row.Field<string>("BranchAddress"),
                

            };

            return branch;
        }

        public Branch MapFromReader(SqlDataReader reader)
        {
            Branch branch = new Branch
            {
                Id = (int)reader["BranchId"],
                Name = (string)reader["BranchName"],
                Address = (string)reader["BranchAddress"]

            };

            return branch;
        }
    }
}
