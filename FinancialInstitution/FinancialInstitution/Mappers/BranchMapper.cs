using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialInstitution.Models;
using DataAccessLayerCommon;

namespace FinancialInstitution.Mappers
{
    public class BranchMapper
    {
        public Models.Branch MapFromEntity(DataAccessLayerCommon.Branch branch)
        {
            Models.Branch tempBranch = new Models.Branch
            {
                Id = branch.Id,
                Name = branch.Name
            };
            SplitAddress(branch.Address, tempBranch);

            return tempBranch;
        }
        public DataAccessLayerCommon.Branch MapFromModel(Models.Branch branch)
        {
            DataAccessLayerCommon.Branch tempBranch = new DataAccessLayerCommon.Branch
            {
                Id = branch.Id,
                Name = branch.Name
            };

            ConcatAddress(tempBranch, branch);
            return tempBranch;
        }

        private void SplitAddress(string address, Models.Branch branch)
        {
            string[] addressArray = address.Split(',');
            
            branch.Country = addressArray[0];
            branch.City = addressArray[1];
            branch.Street = "";
            for(int x = 2; x < addressArray.Length; x++)
            {
                branch.Street += addressArray[x];
            }
        }
        private void ConcatAddress(DataAccessLayerCommon.Branch branch, Models.Branch tempBranch)
        {
            branch.Address = tempBranch.Country+"," + tempBranch.City + "," + tempBranch.Street;
        }
    }
}