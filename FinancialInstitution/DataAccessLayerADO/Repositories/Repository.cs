using Configuration;
using DataAccessLayerADO.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerADO.Repositories
{
    public abstract class Repository
    {

        protected readonly string connectionString;
        protected SqlConnection sqlConnection;
       
        public Repository()
        {
            connectionString = ConfigurationManager.AppSettings["cnStr"];
        }

        public void ExecuteNonQueryCommand(SqlCommand sqlCommand)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
       
        public DataTable GetDataTable(SqlCommand sqlCommand)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.ConnectionString = connectionString;
                sqlCommand.Connection = sqlConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                sqlConnection.Open();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
                return dataTable;
            }
        }


    }
}
