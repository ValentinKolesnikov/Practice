using DataAccessLayerCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Mappers

{
    public class ClientMapper: IClientMapper
    {
        public Client MapFromRow(DataRow row)
        {
            Client client = new Client
            {
                Id = row.Field<int>("ClientId"),
                FirstName = row.Field<string>("ClientFirstName"),
                SecondName = row.Field<string>("ClientSecondName"),
                MiddleName = row.Field<string>("ClientMiddleName"),
                BirthDay = row.Field<DateTime>("ClientBirthDay"),
                Address = row.Field<string>("ClientAddress"),
                PassportSeriesAndNumber = row.Field<string>("ClientPassport"),
                CardNumber = row.Field<string>("ClientCardNumber")

            };

            return client;
        }

        public Client MapFromReader(SqlDataReader reader)
        {
            Client client = new Client
            {
                Id = (int)reader["ClientId"],
                FirstName = (string)reader["ClientFirstName"],
                SecondName = (string)reader["ClientSecondName"],
                MiddleName = (string)reader["ClientMiddleName"],
                BirthDay = (DateTime)reader["ClientBirthDay"],
                Address = (string)reader["ClientAddress"],
                PassportSeriesAndNumber = (string)reader["ClientPassport"],
                CardNumber = (string)reader["ClientCardNumber"]

            };

            return client;
        }
    }
}
