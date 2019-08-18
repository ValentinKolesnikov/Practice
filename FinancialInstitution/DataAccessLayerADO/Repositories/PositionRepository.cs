using DataAccessLayerADO.Mappers;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Repositories
{
    public class PositionRepository : Repository, IPositionRepository
    {
        private IEmployeeMapper employeeMapper { get; set; }
        private IPositionMapper positionMapper { get; set; }

        public PositionRepository(IPositionMapper positionMapper, IEmployeeMapper employeeMapper)
        {
            this.employeeMapper = employeeMapper;
            this.positionMapper = positionMapper;
        }

        public IEnumerable<Position> GetList()
        {
            string sqlInsertCom = @"SELECT [Position].[Id] AS [PositionId], [Position].[Name] AS [PositionName],
                                    [Position].[Flag] AS [Flag] FROM [dbo].[Position]";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            DataTable dataTable = GetDataTable(sqlCommand);

            Position position = new Position();
            List<Position> positions = new List<Position>();

            foreach (DataRow row in dataTable.Rows)
            {
                position = positionMapper.MapFromRow(row);
                positions.Add(position);
            }
            return positions;
        }

        public Position GetItem(int positionId)
        {
            string sqlInsertCom = @"SELECT [Position].[Id] AS [PositionId], [Position].[Name] AS [PositionName],
                                    [Position].[Flag] AS [Flag] FROM [dbo].[Position] WHERE [Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", positionId);
            Position position = new Position();

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    position = positionMapper.MapFromReader(dataReader);

                }
            }
            
            return position;
        }

        public void Insert(Position position)
        {
            string sqlInsertCom = @"INSERT INTO [dbo].[Position] ([Name], [Flag]) VALUES (@name, @isWorkWithClients)";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", position.Name);
            sqlCommand.Parameters.AddWithValue("@isWorkWithClients", position.Flag);
            GetDataTable(sqlCommand);
        }

        public void Update(int positionId, Position position)
        {
            string sqlInsertCom = @"UPDATE [dbo].[Position] set [dbo].[Position].[Name] = @name,
                                   [dbo].[Position].[Flag] = @isWorkWithClients WHERE [dbo].[Position].[Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", position.Name);
            sqlCommand.Parameters.AddWithValue("@isWorkWithClients", position.Flag);
            sqlCommand.Parameters.AddWithValue("@id", positionId);
            GetDataTable(sqlCommand);
        }

        public void Delete(int positionId)
        {
            string sqlInsertCom = @"DELETE [dbo].[Position] WHERE[dbo].[Position].[Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", positionId);
            GetDataTable(sqlCommand);
        }
    }
}

