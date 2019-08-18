using System.Collections.Generic;
using System.Linq;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;


namespace DataAccessLayerEF.Repositories
{
   public class ServiceDirectoryRepository : Repository, IServicesDirectoryRepository 
    {
        public void Delete(int serviceId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesDirectory sd = dataBase.ServicesDirectories.Find(serviceId);
                dataBase.ServicesDirectories.Remove(sd);
                dataBase.SaveChanges();
            }
           
        }

        public List<ServicesDirectory> GetAll()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.ServicesDirectories.ToList();
            }
            
        }

        public ServicesDirectory GetItem(int serviceId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesDirectory sd = dataBase.ServicesDirectories.Find(serviceId);
                return sd;
            }
         
        }

        public void Insert(ServicesDirectory service)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.ServicesDirectories.Add(service);
                dataBase.SaveChanges();
            }
            
        }

        public void Update(int serviceId, ServicesDirectory service)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesDirectory sd = dataBase.ServicesDirectories.Find(serviceId);
                 sd.Name = service.Name ;
                dataBase.SaveChanges();
            }
          

        }
    }

}
