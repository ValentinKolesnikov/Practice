using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayerADO.Repositories;
using DataAccessLayerADO.Mappers;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using DataAccessLayerADO.Interfaces;

namespace DataAccessLayerADO.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        private IEmployeeMapper employeeMapper { get; set; }

        private IPositionMapper positionMapper { get; set; }
        private IBranchMapper branchMapper { get; set; }


        public EmployeeRepository(IEmployeeMapper employeeMapper, IPositionMapper positionMapper, IBranchMapper branchMapper) : base()
        {
            this.employeeMapper = employeeMapper;
            this.positionMapper = positionMapper;
            this.branchMapper = branchMapper;
        }

        public IEnumerable<Employee> GetListWithBranchAndPosition()
        {
            string sqlInsertCom = @"SELECT [Employee].[Id] AS [EmployeeId], [Employee].[FirstName] AS [EmployeeFirstName],
                                    [Employee].[SecondName] AS [EmployeeSecondName], [Employee].[MiddleName] AS [EmployeeMiddleName],
                                    [Employee].[BirthDay] AS [EmployeeBirthDay], [Employee].[BranchId] AS [EmployeeBranchId],
                                    [Branch].[Id] AS [BranchId], [Branch].[Name] AS [BranchName],
                                    [Branch].[Address] AS [BranchAddress], [Employee].[PositionId] AS [EmployeePositionId],
                                    [Position].[Id] AS [PositionId], [Position].[Name] AS [PositionName], [Position].[Flag] AS [Flag]
                                    FROM[dbo].[Employee] JOIN[dbo].[Position] ON[dbo].[Employee].[PositionId] = [dbo].[Position].[Id]
                                    JOIN[dbo].[Branch] ON[dbo].[Employee].[BranchID] = [dbo].[Branch].[Id]";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            DataTable dataTable = GetDataTable(sqlCommand);
            //PositionRepository positionRepository = new PositionRepository();

            Employee employee = new Employee();
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                employee = employeeMapper.MapFromRow(row);
                //employee.Branch = employeeMapper.MapFromRow(row);
                employee.Position = positionMapper.MapFromRow(row);
                employees.Add(employee);
            }
            return employees;
        }

        public IEnumerable<Employee> GetList()
        {
            string sqlInsertCom = @"SELECT [Employee].[Id] AS [EmployeeId], [Employee].[FirstName] AS [EmployeeFirstName], [Employee].[SecondName] AS [EmployeeSecondName],
                                    [Employee].[MiddleName] AS [EmployeeMiddleName], [Employee].[BirthDay] AS [EmployeeBirthDay] , [Employee].[BranchId] AS [EmployeeBranchId],
                                    [Employee].[PositionId] AS [EmployeePositionId] FROM [dbo].[Employee]";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            DataTable dataTable = GetDataTable(sqlCommand);
            //PositionRepository positionRepository = new PositionRepository();

            Employee employee = new Employee();
            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                employee = employeeMapper.MapFromRow(row);
                employees.Add(employee);
            }
            return employees;
        }

        public Employee GetItemWithBranchAndPosition(int employeeId)
        {
            string sqlInsertCom = @"SELECT [Employee].[Id] AS [EmployeeId], [Employee].[FirstName] AS [EmployeeFirstName],
                                    [Employee].[SecondName] AS [EmployeeSecondName], [Employee].[MiddleName] AS [EmployeeMiddleName],
                                    [Employee].[BirthDay] AS [EmployeeBirthDay], [Employee].[BranchId] AS [EmployeeBranchId],
                                    [Branch].[Id] AS [BranchId], [Branch].[Name] AS [BranchName],
                                    [Branch].[Address] AS [BranchAddress], [Employee].[PositionId] AS [EmployeePositionId],
                                    [Position].[Id] AS [PositionId], [Position].[Name] AS [PositionName], [Position].[Flag] AS [Flag]
                                    FROM[dbo].[Employee] JOIN[dbo].[Position] ON[dbo].[Employee].[PositionId] = [dbo].[Position].[Id]
                                    JOIN[dbo].[Branch] ON[dbo].[Employee].[BranchID] = [dbo].[Branch].[Id] WHERE [Employee].[Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", employeeId);
            Employee employee = new Employee();

            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.Read())
                {
                    employee = employeeMapper.MapFromReader(dataReader);
                    employee.Branch = branchMapper.MapFromReader(dataReader);
                    employee.Position = positionMapper.MapFromReader(dataReader);
                }
            }
           
            return employee;
        }

        public Employee GetItem(int employeeId)
        {
            string sqlInsertCom = @"SELECT [Employee].[Id] AS [EmployeeId],[Employee].[FirstName] AS [EmployeeFirstName],
                                    [Employee].[SecondName] AS [EmployeeSecondName], [Employee].[MiddleName] AS [EmployeeMiddleName], 
                                    [Employee].[BirthDay] AS [EmployeeBirthDay], [Employee].[BranchId] AS [EmployeeBranchId], 
                                    [Employee].[PositionId] AS [EmployeePositionId] FROM [dbo].[Employee] WHERE [Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", employeeId);
            Employee employee = new Employee();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                employee = employeeMapper.MapFromReader(dataReader);
            }
            
            return employee;
        }


        public void Insert(Employee employee)
        {
            string sqlInsertCom = @"INSERT INTO [dbo].[Employee]
                                    ([FirstName], [SecondName], [MiddleName], [BirthDay], [BranchId], [PositionId])
                                    VALUES
                                    (@firstName, @secondName, @middleName, @birthDay, @branchId, @positionId)";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@firstName", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@secondName", employee.SecondName);
            sqlCommand.Parameters.AddWithValue("@middleName", employee.MiddleName);
            sqlCommand.Parameters.AddWithValue("@birthDay", employee.BirthDay);
            sqlCommand.Parameters.AddWithValue("@branchId", employee.BranchId);
            sqlCommand.Parameters.AddWithValue("@positionId", employee.PositionId);
            GetDataTable(sqlCommand);
        }

        public void Update(int employeeId, Employee employee)
        {
            string sqlInsertCom = @"UPDATE [dbo].[Employee]
                                    SET[dbo].[Employee].[Firstname] = @Firstname,
                                    [dbo].[Employee].[SecondName] = @SecondName,
                                    [dbo].[Employee].[MiddleName] = @MiddleName,
                                    [dbo].[Employee].[BirthDay] = @BirthDay,
                                    [dbo].[Employee].[BranchID] = @BranchID,
                                    [dbo].[Employee].[PositionID] = @PositionID
                                    WHERE[dbo].[Employee].[Id] = @Id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", employee.SecondName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
            sqlCommand.Parameters.AddWithValue("@BirthDay", employee.BirthDay);
            sqlCommand.Parameters.AddWithValue("@BranchId", employee.BranchId);
            sqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            sqlCommand.Parameters.AddWithValue("@Id", employeeId);
            GetDataTable(sqlCommand);
        }

        public void Delete(int employeeId)
        {

            string sqlInsertCom = @"DELETE [dbo].[Employee]
                WHERE [dbo].[Employee].[Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", employeeId);
            GetDataTable(sqlCommand);
        }
    }
}
