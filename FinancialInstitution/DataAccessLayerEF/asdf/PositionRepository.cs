using DataAccessLayerCommon;
using DataAccessLayerCommon.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerEF.Repositories
{
    public class PositionRepository: Repository, IPositionRepository
    {
        public IEnumerable<Position> GetList()
        {
            using(dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Positions.AsEnumerable();
            }
        }

        public Position GetItem(int positionId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                return dataBase.Positions.Where(p => p.Id == positionId).First();
            }
        }

        public void Insert(Position position)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Positions.Add(position);
                dataBase.SaveChanges();
            }
        }

        public void Update(int positionId, Position position)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                Position changeablePosition = dataBase.Positions.Find(positionId);
                changeablePosition = position;
                changeablePosition.Id = positionId;
                dataBase.SaveChanges();
            }
        }

        public void Delete(int posiitonId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Positions.Remove(dataBase.Positions.Where(p => p.Id == posiitonId).First());
                dataBase.SaveChanges();
            }
        }
    }
}
