using DataAccessLayerCommon;
using System.Collections.Generic;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IServicesHistoryRepository
    {
        void Insert( ServicesHistory serviceHistory);
        void Update(int serviceHistoryId, ServicesHistory serviceHistory);
        void Delete(int serviceHistoryId);
        

        IEnumerable<ServicesHistory> GetList();
        IEnumerable<ServicesHistory> GetAll();
        ServicesHistory GetItem(int serviceHistoryId);
    }
}
