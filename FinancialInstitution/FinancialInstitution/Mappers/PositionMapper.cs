using System;
using System.Collections.Generic;

namespace FinancialInstitution.Mappers
{
    public class PositionMapper
    {
        public PositionMapper(){}

        public Models.Position MapFromItem(DataAccessLayerCommon.Position position)
        {
            return new Models.Position()
            {
                Id = position.Id,
                Name = position.Name,
                Flag = position.Flag
            };
        }

        public DataAccessLayerCommon.Position MapToItem(Models.Position position)
        {
            return new DataAccessLayerCommon.Position()
            {
                Id = position.Id,
                Name = position.Name,
                Flag = position.Flag
            };
        }


        public IEnumerable<Models.Position> MapFromList(IEnumerable<DataAccessLayerCommon.Position> positions)
        {
            List<Models.Position> positionsReturn = new List<Models.Position>();
            foreach (DataAccessLayerCommon.Position position in positions)
                positionsReturn.Add(new Models.Position()
                {
                    Id = position.Id,
                    Name = position.Name,
                    Flag = position.Flag
                });
            return positionsReturn;
        }
    }
}