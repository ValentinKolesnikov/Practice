using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;


namespace DataAccessLayerEF.Repositories
{
    public class ClientRepository: Repository, IClientRepository
    {
        public IEnumerable<Client> GetList()
        {
            using(dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Clients.ToList();
            }
        }

        public Client GetItem(int clientId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Clients.Find(clientId);
            }
        }

        public void Insert(Client client)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Clients.Add(client);
                dataBase.SaveChanges();
            }
        }

        public void Update(int clientId, Client client)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Client changeableClient = dataBase.Clients.Find(clientId);
                
                dataBase.SaveChanges();
            }
        }

        public void Delete(int clientId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Client removableClient = dataBase.Clients.Find(clientId);
                dataBase.Clients.Remove(removableClient);
                dataBase.SaveChanges();
            }
        }
    }
}
