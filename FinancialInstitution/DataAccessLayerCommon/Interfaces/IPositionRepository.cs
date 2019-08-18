using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerCommon.Interfaces
{
    public interface IPositionRepository
    {
        void Insert(Position position);

        void Delete(int positionId);

        void Update(int positionId, Position position);

        IEnumerable<Position> GetList();

        Position GetItem(int positionId);
    }
}
