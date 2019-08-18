using DataAccessLayerCommon;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerADO.Interfaces;
using System;

namespace DataAccessLayerADO.Mappers
{
    public class EmployeeMapper: IEmployeeMapper
    {
        public Employee MapFromRow(DataRow row)
        {
            Employee employee = new Employee
            {
                Id = row.Field<int>("EmployeeId"),
                FirstName = row.Field<string>("EmployeeFirstName"),
                SecondName = row.Field<string>("EmployeeSecondName"),
                MiddleName = row.Field<string>("EmployeeMiddleName"),
                BirthDay = row.Field<DateTime>("EmployeeBirthDay"),
                BranchId = row.Field<int>("EmployeeBranchId"),
                PositionId = row.Field<int>("EmployeePositionId")
            };
            return employee;
        }

        public Employee MapFromReader(SqlDataReader reader)
        {
            Employee employee = new Employee
            {
                Id = (int)reader["EmployeeId"],
                FirstName = (string)reader["EmployeeFirstName"],
                SecondName = (string)reader["EmployeeSecondName"],
                MiddleName = (string)reader["EmployeeMiddleName"],
                BirthDay = (DateTime)reader["EmployeeBirthDay"],
                BranchId = (int)reader["EmployeeBranchId"],
                PositionId = (int)reader["EmployeePositionId"]
            };
            return employee;
        }
    }
}
