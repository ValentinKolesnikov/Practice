using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetList();
        IEnumerable<Employee> GetListWithBranchAndPosition();

        Employee GetItem(int employeeId);
        Employee GetItemWithBranchAndPosition(int employeeId);


        void Insert(Employee employee);

        void Delete(int employeeId);

        void Update(int employeeId, Employee employee);

    }
}
