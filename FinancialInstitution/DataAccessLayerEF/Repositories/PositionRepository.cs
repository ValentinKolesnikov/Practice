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
                return dataBase.Positions.ToList();
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
                changeablePosition.Name = position.Name;
                changeablePosition.Flag = position.Flag;
                dataBase.SaveChanges();
            }
        }

        public void Delete(int positionId)
        {
            using (dataBase = new FinancialInstitutionEntities())
            {
                dataBase.Positions.Remove(dataBase.Positions.Where(p => p.Id == positionId).First());



                dataBase.SaveChanges();
            }
        }
    }
}
