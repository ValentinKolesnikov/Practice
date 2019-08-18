using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialInstitution.Models;
using DataAccessLayerCommon;
namespace FinancialInstitution.Mappers
{
    public class ClientMapper
    {
        public Models.Client MapFromEntity(DataAccessLayerCommon.Client client)
        {

            Models.Client tempClient = new Models.Client
            {
                Id = client.Id,
                FirstName = client.FirstName,
                SecondName = client.SecondName,
                MiddleName = client.MiddleName,
                BirthDay = client.BirthDay,
                PassportSeriesAndNumber = client.PassportSeriesAndNumber,
                CardNumber = client.CardNumber
                
            };
            SplitAddress(client.Address, tempClient);
            return tempClient;

        }
        public DataAccessLayerCommon.Client MapFromModel(Models.Client client)
        {

            DataAccessLayerCommon.Client tempClient = new DataAccessLayerCommon.Client
            {
                FirstName = client.FirstName,
                SecondName = client.SecondName,
                MiddleName = client.MiddleName,
                BirthDay = client.BirthDay,
                PassportSeriesAndNumber = client.PassportSeriesAndNumber,
                CardNumber = client.CardNumber
            };
            ConcatAddress(tempClient, client);
            return tempClient;

        }
        private void SplitAddress(string address, Models.Client client)
        {
            string[] addressArray = address.Split(',');

            client.Country = addressArray[0];
            client.City = addressArray[1];
            client.Street = "";
            for (int x = 2; x < addressArray.Length; x++)
            {
                client.Street += addressArray[x];
            }
        }
        private void ConcatAddress(DataAccessLayerCommon.Client client, Models.Client tempClient)
        {
            client.Address = tempClient.Country + "," + tempClient.City + "," + tempClient.Street;
        }


    }
}