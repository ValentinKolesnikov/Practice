
using DataAccessLayerADO.Interfaces;
using DataAccessLayerADO.Mappers;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerADO.Repositories
{
    public class BranchRepository : Repository, IBranchRepository
    {
        private IBranchMapper branchMapper;

        public BranchRepository(IBranchMapper branchMapper)
        {
            this.branchMapper = branchMapper;
        }

        public Branch GetItem(int branchId)
        {
            string sqlInsertCom = @"SELECT 
                                        Branch.Id AS 'BranchId', Branch.Name AS 'BranchName', Branch.Address AS 'BranchAddress'
                                    FROM Branch WHERE Id = @id";

            Branch branch = new Branch();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", branchId);
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    branch = branchMapper.MapFromReader(dataReader);
                }
            }


            return branch;
        }


        public IEnumerable<Branch> GetList()
        {

            string sqlInsertCom = @"SELECT 
                                        Branch.Id AS 'BranchId', Branch.Name AS 'BranchName', Branch.Address AS 'BranchAddress'
                                    FROM Branch";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            DataTable dataTable = GetDataTable(sqlCommand);

            Branch branch = new Branch();
            List<Branch> branchesList = new List<Branch>();

            foreach (DataRow row in dataTable.Rows)
            {
                branch = branchMapper.MapFromRow(row);
                branchesList.Add(branch);
            }

            return branchesList;
        }



        public void Insert(Branch branch)
        {
            string sqlInsertCom = String.Format("INSERT INTO Branch " +
            "(Name, Address) VALUES (@Name, @Address)");

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Name", branch.Name);
            sqlCommand.Parameters.AddWithValue("@Address", branch.Address);

            ExecuteNonQueryCommand(sqlCommand);
        }

        public void Delete(int Id)
        {
            string sqlInsertCom = $"DELETE Branch WHERE Id = @Id";

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", Id);

            ExecuteNonQueryCommand(sqlCommand);
        }

        public void Update(int Id, Branch branch)
        {
            string sqlInsertCom = String.Format("UPDATE Branch" +
                                                " SET " +
                                                    "Name = @Name," +
                                                    "Address = @Address " +
                                                    "WHERE Id = @Id");

            SqlCommand sqlCommand = new SqlCommand(sqlInsertCom, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Name", branch.Name);
            sqlCommand.Parameters.AddWithValue("@Address", branch.Address);
            sqlCommand.Parameters.AddWithValue("@Id", Id);

            ExecuteNonQueryCommand(sqlCommand);
        }

        //Доделать get-ы

    }
}
