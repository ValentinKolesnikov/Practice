using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;

namespace DataAccessLayerEF.Repositories
{
    public abstract class Repository
    {
        protected FinancialInstitutionEntities dataBase;
    }
}
