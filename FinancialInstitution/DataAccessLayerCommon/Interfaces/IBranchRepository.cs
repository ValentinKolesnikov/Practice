using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IBranchRepository
    {
        void Insert(Branch branch);

        void Delete(int Id);

        void Update(int Id, Branch branch);

        IEnumerable<Branch> GetList();

        Branch GetItem(int branchId);
    }
}
