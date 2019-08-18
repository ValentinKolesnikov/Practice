using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerADO.Interfaces;


namespace DataAccessLayerADO.Mappers
{
    public class PositionMapper: IPositionMapper
    {
        public Position MapFromRow(DataRow row)
        {
            Position position = new Position
            {
                Id = row.Field<int>("PositionId"),
                Name = row.Field<string>("PositionName"),
                Flag = row.Field<bool>("Flag")
            };
            return position;
        }

        public Position MapFromReader(SqlDataReader reader)
        {
            Position position = new Position
            {
                Id = (int)reader["PositionId"],
                Name = (string)reader["PositionName"],
                Flag = (bool)reader["PositionFlag"]
            };
            return position;
        }
    }
}
