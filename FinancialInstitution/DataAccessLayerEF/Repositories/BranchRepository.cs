using DataAccessLayerCommon.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerCommon;

namespace DataAccessLayerEF.Repositories
{
    public class BranchRepository : Repository, IBranchRepository
    {
        public IEnumerable<Branch> GetList()
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Branches.ToList();
            }
        }
        public Branch GetItem(int branchId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Branches.Find(branchId);
            }
        }
        public void Insert(Branch branch)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Branches.Add(branch);
                dataBase.SaveChanges();
            }
        }
        public void Update(int Id, Branch branch)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Branch changeableBranch = dataBase.Branches.Find(Id);
                changeableBranch.Name = branch.Name;
                changeableBranch.Address = branch.Address;

                dataBase.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Branch removableBranch = dataBase.Branches.Find(Id);
                dataBase.Branches.Remove(removableBranch);
                dataBase.SaveChanges();
            }
        }
    }
}
