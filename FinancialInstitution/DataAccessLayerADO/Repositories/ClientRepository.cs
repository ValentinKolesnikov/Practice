using DataAccessLayerADO.Interfaces;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayerADO.Mappers;
using System.Diagnostics;

namespace DataAccessLayerADO.Repositories
{
    public class ClientRepository : Repository, IClientRepository
    {
        private IClientMapper clientMapper;
        public ClientRepository(IClientMapper clientMapper)
        {
            this.clientMapper = clientMapper;
        }

        public Client GetItem(int clientId)
        {
            string sqlInsertCom = @"SELECT 
                                        Id AS 'ClientId', Client.FirstName AS 'ClientFirstName', Client.SecondName AS 'ClientSecondName', Client.MiddleName AS 'ClientMiddleName',
                                        Client.BirthDay AS 'ClientBirthDay', Client.Address AS 'ClientAddress', Client.PassportSeriesAndNumber AS 'ClientPassport', 
                                        Client.CardNumber AS 'ClientCardNumber'
                                    FROM Client WHERE Id = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", clientId);
            Client client = new Client();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    client = clientMapper.MapFromReader(dataReader);

                }
                Console.WriteLine(client.FirstName);

            }


            return client;
        }

        public IEnumerable<Client> GetAll()
        {

            string sqlInsertCom = @"SELECT 
                                        Client.Id AS 'ClientId', Client.FirstName AS 'ClientFirstName', Client.SecondName AS 'ClientSecondName', Client.MiddleName AS 'ClientMiddleName',
                                        Client.BirthDay AS 'ClientBirthDay', Client.Address AS 'ClientAddress', Client.PassportSeriesAndNumber AS 'ClientPassport', 
                                        Client.CardNumber AS 'ClientCardNumber'
                                    FROM Client";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            DataTable dataTable = GetDataTable(sqlCommand);

            Client client = new Client();
            List<Client> clientsList = new List<Client>();

            foreach (DataRow row in dataTable.Rows)
            {
                client = clientMapper.MapFromRow(row);
                clientsList.Add(client);
            }

            return clientsList;
        }

        //public IEnumerable<Client> GetList()
        //{

        //    string sqlInsertCom = @"SELECT	
        //                            [dbo].[Client].[Id] AS 'ClientId',
        //                            CONCAT([dbo].[Client].[SecondName] AS 'ClientSecondName', ' ', [dbo].[Client].[Firstname] AS 'ClientFirstName', ' ', [dbo].[Client].[MiddleName] AS 'ClientMiddleName') AS 'ФИО', 
		      //                      [dbo].[Client].[BirthDay] AS 'ClientBirthDay', 
		      //                      [dbo].[Client].[PassportSeriesAndNumber] AS 'ClientPassport', 
		      //                      [dbo].[Client].[CardNumber] AS 'ClientCard'

        //                            FROM [dbo].[Client]";

        //    SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

        //    DataTable dataTable = GetDataTable(sqlCommand);

        //    Client client = new Client();
        //    List<Client> clientsList = new List<Client>();

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        client = clientMapper.MapFromRow(row);
        //        clientsList.Add(client);
        //    }

        //    return clientsList;
        //}



        public void Insert(Client client)
        {
            string sqlExpression = "AddClient";

            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", client.SecondName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", client.MiddleName);
            sqlCommand.Parameters.AddWithValue("@BirthDay", client.BirthDay);
            sqlCommand.Parameters.AddWithValue("@Address", client.Address);
            sqlCommand.Parameters.AddWithValue("@Passport", client.PassportSeriesAndNumber);
            sqlCommand.Parameters.AddWithValue("@CardNumber", client.CardNumber);

            ExecuteNonQueryCommand(sqlCommand);
        }



        public bool Delete(int Id)
        {
            string sqlInsertCom = $"DELETE Client WHERE Id = @Id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            try
            {
                ExecuteNonQueryCommand(sqlCommand);
                return true;
            }
            catch (Exception ex) { return false; }
        }


        public void Update(int Id, Client client)
        {
            string sqlExpression = "EditClient";

            SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", client.SecondName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", client.MiddleName);
            sqlCommand.Parameters.AddWithValue("@BirthDay", client.BirthDay);
            sqlCommand.Parameters.AddWithValue("@Address", client.Address);
            sqlCommand.Parameters.AddWithValue("@Passport", client.PassportSeriesAndNumber);
            sqlCommand.Parameters.AddWithValue("@CardNumber", client.CardNumber);
            sqlCommand.Parameters.AddWithValue("@Id", Id);

            ExecuteNonQueryCommand(sqlCommand);
        }





        //public void Update(int Id, Client client)
        //{
        //    string sqlInsertCom = String.Format("UPDATE Client" +
        //                                        " SET " +
        //                                            "FirstName = @FirstName," +
        //                                            "SecondName = @SecondName," +
        //                                            "MiddleName = @MiddleName," +
        //                                            "BirthDay = @BirthDay," +
        //                                            "Address = @Address," +
        //                                            "Passport_series_and_number = @Passport," +
        //                                            "Card_number = @Card " +
        //                                            "WHERE Id = @Id");

        //    SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

        //    sqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
        //    sqlCommand.Parameters.AddWithValue("@SecondName", client.SecondName);
        //    sqlCommand.Parameters.AddWithValue("@MiddleName", client.MiddleName);
        //    sqlCommand.Parameters.AddWithValue("@BirthDay", client.BirthDay);
        //    sqlCommand.Parameters.AddWithValue("@Address", client.Address);
        //    sqlCommand.Parameters.AddWithValue("@Passport", client.Passport);
        //    sqlCommand.Parameters.AddWithValue("@Card", client.CardNumber);
        //    sqlCommand.Parameters.AddWithValue("@Id", Id);

        //    ExecuteNonQueryCommand(sqlCommand);
        //}








        //public void Insert(Client client)
        //{
        //    string sqlInsertCom = String.Format("INSERT INTO Client " +
        //    "(FirstName, SecondName, MiddleName, BirthDay, Address, Passport_series_and_number, Card_number) VALUES (@FirstName, @SecondName, @MiddleName, @BirthDay, @Address, @Passport, @Card)");

        //    SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

        //    sqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
        //    sqlCommand.Parameters.AddWithValue("@SecondName", client.SecondName);
        //    sqlCommand.Parameters.AddWithValue("@MiddleName", client.MiddleName);
        //    sqlCommand.Parameters.AddWithValue("@BirthDay", client.BirthDay);
        //    sqlCommand.Parameters.AddWithValue("@Address", client.Address);
        //    sqlCommand.Parameters.AddWithValue("@Passport", client.Passport);
        //    sqlCommand.Parameters.AddWithValue("@Card", client.CardNumber);

        //    ExecuteNonQueryCommand(sqlCommand);
        //}



    }




}
