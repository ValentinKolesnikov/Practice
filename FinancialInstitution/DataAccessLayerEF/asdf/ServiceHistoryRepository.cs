using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayerEF.Repositories
{
    public class ServiceHistoryRepository : Repository, IServiceHistoryRepository
    {
        public void Delete(int serviceHistoryId)
        {
            using (dataBase= new FinancialInstitutionEntities())
            {
                ServicesHistory sh = dataBase.ServicesHistories.Find(serviceHistoryId);
                dataBase.ServicesHistories.Remove(sh);
            }
            
        }

        public IEnumerable<ServicesHistory> GetAll()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.ServicesHistories.ToList();
            }
            
        }

        public IEnumerable<ServicesHistory> GetList()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.ServicesHistories.ToList();
            }

        }

        public ServicesHistory GetItem(int serviceHistoryId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.ServicesHistories.Find(serviceHistoryId);
            }
            
        }

       

        public void Insert(ServicesHistory serviceHistory)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.ServicesHistories.Add(serviceHistory);
                dataBase.SaveChanges();
            }
            
        }

        public void Update(int serviceHistoryId, ServicesHistory serviceHistory)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesHistory sh = dataBase.ServicesHistories.Find(serviceHistoryId);
                ServicesHistory newsh = new ServicesHistory
                {
                    Id = serviceHistory.Id,
                    Date = serviceHistory.Date,
                    ServiceDirectoryId = serviceHistory.ServiceDirectoryId,
                    EmployeeId = serviceHistory.EmployeeId,
                    ClientId = serviceHistory.ClientId
                };
                dataBase.SaveChanges();
            }
            
        }
    }
}
