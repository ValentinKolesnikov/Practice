using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;

namespace DataAccessLayerEF.Repositories
{
    public class EmployeeRepository: Repository, IEmployeeRepository
    {
        public IEnumerable<Employee> GetList()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Employees.ToList();
            }
        }

        public IEnumerable<Employee> GetListWithBranchAndPosition()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Employees.Include(e => e.Branch).Include(e => e.Position).AsEnumerable();
            }
        }

        public Employee GetItem(int employeeId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Employees.Where(e => e.Id == employeeId).First();
            }
        }

        public Employee GetItemWithBranchAndPosition(int employeeId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Employees.Include(e => e.Branch).Include(e => e.Position).Where(e => e.Id == employeeId).First();
            }
        }

        public void Insert(Employee employee)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Employees.Add(employee);
                dataBase.SaveChanges();
            }
        }

        public void Update(int employeeId, Employee employee)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Employee changeableEmployee = dataBase.Employees.Find(employeeId);
                changeableEmployee = employee;
                changeableEmployee.Id = employeeId;
                dataBase.SaveChanges();
            }
        }

        public void Delete(int employeeId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Employees.Remove(dataBase.Employees.Where(e => e.Id == employeeId).First());
                dataBase.SaveChanges();
            }
        }
    }
}
