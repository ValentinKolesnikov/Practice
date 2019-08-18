using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IClientRepository 
    {
        void Insert(Client client);

        bool Delete(int Id);

        void Update(int Id, Client client);

        IEnumerable<Client> GetAll();

        //IEnumerable<Client> GetList();

        Client GetItem(int clientId);
    }
}
