using FinancialInstitution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FinancialInstitution.Mappers
{
    public class ServicesDirectoryMapper
    {
        public ServicesDirectory MapFromEntity(DataAccessLayerCommon.ServicesDirectory servicesDirectory)
        {
            ServicesDirectory SDModel = new ServicesDirectory { Name = servicesDirectory.Name, Id= servicesDirectory.Id };
            return SDModel;
        }
        public DataAccessLayerCommon.ServicesDirectory MapFromModel(Models.ServicesDirectory model)
        {
            return new DataAccessLayerCommon.ServicesDirectory { Id = model.Id, Name = model.Name };
        }

        //public DataAccessLayerCommon.ServicesDirectory MapFromModel(Models.ServicesDirectory servicesDirectory)
        //{

        //    DataAccessLayerCommon.Client tempClient = new DataAccessLayerCommon.Client
        //    {
        //        FirstName = client.FirstName,
        //        SecondName = client.SecondName,
        //        MiddleName = client.MiddleName,
        //        BirthDay = client.BirthDay,
        //        Address = client.Address,
        //        PassportSeriesAndNumber = client.PassportSeriesAndNumber,
        //        CardNumber = client.CardNumber
        //    };

        //    return tempClient;

        //}
    }
}