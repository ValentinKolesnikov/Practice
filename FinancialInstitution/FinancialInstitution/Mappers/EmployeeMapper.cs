
using System.Collections.Generic;

namespace FinancialInstitution.Mappers
{
    public class EmployeeMapper
    {
        DataAccessLayerEF.Repositories.BranchRepository branchRepository;
        DataAccessLayerEF.Repositories.PositionRepository positionRepository;


        public EmployeeMapper()
        {
            branchRepository = new DataAccessLayerEF.Repositories.BranchRepository();
            positionRepository = new DataAccessLayerEF.Repositories.PositionRepository();
        }

        public Models.Employee MapFromItem(DataAccessLayerCommon.Employee employee)
        {
            return new Models.Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                MiddleName = employee.MiddleName,
                Branch = employee.Branch.Name,
                Position = employee.Position.Name,
                PositionId = employee.PositionId,
                BranchId = employee.BranchId,
                BirthDay = employee.BirthDay
            };
        }

        public DataAccessLayerCommon.Employee MapToItem(Models.Employee employee)
        {
            return new DataAccessLayerCommon.Employee()
            {
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                MiddleName = employee.MiddleName,
                //Branch = branchRepository.GetItem(employee.BranchId),
                //Position = positionRepository.GetItem(employee.PositionId),
                PositionId = employee.PositionId,
                BranchId = employee.BranchId,
                BirthDay = employee.BirthDay
            };
        }

        public IEnumerable<Models.Employee> MapFromList(IEnumerable<DataAccessLayerCommon.Employee> employees)
        {
            List<Models.Employee> employeesReturn = new List<Models.Employee>();
            foreach (DataAccessLayerCommon.Employee employee in employees)
                employeesReturn.Add(new Models.Employee()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    SecondName = employee.SecondName,
                    MiddleName = employee.MiddleName,
                    Branch = employee.Branch.Name,
                    Position = employee.Position.Name,
                    PositionId = employee.PositionId,
                    BranchId = employee.BranchId,
                    BirthDay = employee.BirthDay
                });
            return employeesReturn; 
        }
    }
}