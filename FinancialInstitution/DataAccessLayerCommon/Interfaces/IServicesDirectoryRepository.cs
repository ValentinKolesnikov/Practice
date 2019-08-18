using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IServicesDirectoryRepository
    {
        void Insert(ServicesDirectory service);
        void Update(int serviceId, ServicesDirectory service);
        void Delete(int serviceId);
        List<ServicesDirectory> GetAll();
        ServicesDirectory GetItem(int serviceId);
    }
}
