using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayerADO.Repositories;
using DataAccessLayerADO.Mappers;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Repositories
{

    public class ServiceDirectoryRepository : Repository, IServicesDirectoryRepository
    {
        private IServiceDirectoryMapper serviceMapper;
        public ServiceDirectoryRepository(IServiceDirectoryMapper serviceMapper)
        {
            this.serviceMapper = serviceMapper;
        }
        public ServicesDirectory GetItem(int serviceId)
        {
            SqlParameter serviceIdParam = new SqlParameter("@serviceId", serviceId);
            string expression = "SELECT * FROM ServicesDirectory  WHERE Id = @serviceid";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            command.Parameters.Add(serviceIdParam);
            ServicesDirectory service = new ServicesDirectory();

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    service = serviceMapper.MapFromReader(reader);
                }
            }
            
            return service;
        }
        public List<ServicesDirectory> GetAll()
        {
            List<ServicesDirectory> services = new List<ServicesDirectory>();
            string expression = "SELECT * FROM ServicesDirectory";
            SqlCommand sqlCommand = new SqlCommand(expression, sqlConnection);
            DataTable dataTable = GetDataTable(sqlCommand);
            foreach (DataRow row in dataTable.Rows)
            {
                ServicesDirectory service = serviceMapper.MapFromRow(row);
                services.Add(service);

            }
            return services;
        }

        public void Delete(int serviceId)
        {

            string expression = "DELETE ServicesDirectory WHERE Id = @serviceid";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter serviceIdParam = new SqlParameter("@serviceId", serviceId);
            command.Parameters.Add(serviceIdParam);
            ExecuteNonQueryCommand(command);

        }
        public void Insert(ServicesDirectory service)
        {

            string expression = "INSERT ServicesDirectory (Name) VALUES (@name)";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter nameParam = new SqlParameter("@name", service.Name);
            command.Parameters.Add(nameParam);
            ExecuteNonQueryCommand(command);

        }

        public void Update(int serviceId, ServicesDirectory service)
        {
            string expression = "UPDATE ServicesDirectory SET Name = @name WHERE Id = @serviceid";
            SqlCommand command = new SqlCommand(expression, sqlConnection);
            SqlParameter nameParam = new SqlParameter("@name", service.Name);
            SqlParameter serviceIdParam = new SqlParameter("@serviceId", serviceId);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(serviceIdParam);
            ExecuteNonQueryCommand(command);

        }

    }
}

