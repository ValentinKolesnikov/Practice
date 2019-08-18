using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

namespace DataAccessLayerEF.Repositories
{
    public class ServiceHistoryRepository : Repository, IServicesHistoryRepository
    {
        public void Delete(int serviceHistoryId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesHistory sh = dataBase.ServicesHistories.Find(serviceHistoryId);
                dataBase.ServicesHistories.Remove(sh);
                dataBase.SaveChanges();
            }

        }

        public IEnumerable<ServicesHistory> GetAll()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.ServicesHistories.Include(sh => sh.Client).Include(sh => sh.Employee).Include(sh => sh.Employee.Branch).Include(sh => sh.ServicesDirectory).Include(sh => sh.Employee.Position).ToList();
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



        public void Insert( ServicesHistory serviceHistory)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                
                dataBase.ServicesHistories.Add(serviceHistory);
                try
                {
                    dataBase.SaveChanges();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }




            }

        }

        public void Update(int serviceHistoryId, ServicesHistory serviceHistory)
        {
           
            using (dataBase = new FinancialInstitutionEntities())
            {
                ServicesHistory sh = dataBase.ServicesHistories.Find(serviceHistoryId);

              
                sh.Date = serviceHistory.Date;
                sh.ServicesDirectoryId = serviceHistory.ServicesDirectoryId;
                sh.EmployeeId = serviceHistory.EmployeeId;
                sh.ClientId = serviceHistory.ClientId;
                sh.Client = serviceHistory.Client;
                sh.ServicesDirectory = serviceHistory.ServicesDirectory;
                sh.Employee = serviceHistory.Employee;
               
                    dataBase.SaveChanges();
                
                        }

        }

        public IEnumerable<ServicesHistory> GetHistories(int id)
        {
            List<ServicesHistory> shl = new List<ServicesHistory>();
            IEnumerable<ServicesHistory> stories = GetAll();
            foreach (ServicesHistory sh in stories)
            {
                if(sh.ClientId == id)
                {
                    shl.Add(sh);
                }
            }
            return shl;
        }
    }
}
