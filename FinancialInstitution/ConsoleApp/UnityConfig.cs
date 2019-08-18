using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DataAccessLayerADO.Interfaces;
using DataAccessLayerADO.Mappers;
using DataAccessLayerADO.Repositories;
using DataAccessLayerCommon.Interfaces;

namespace ConsoleApp
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IEmployeeMapper, EmployeeMapper>();
            container.RegisterType<IBranchMapper, BranchMapper>();
            container.RegisterType<IClientMapper, ClientMapper>();
            container.RegisterType<IPositionMapper, PositionMapper>();
            container.RegisterType<IServiceHistoryMapper, ServiceHistoryMapper>();
            container.RegisterType<IServiceDirectoryMapper, ServiceDirectoryMapper>();

            container.RegisterType<IEmployeeRepository, DataAccessLayerEF.Repositories.EmployeeRepository>();
            container.RegisterType<IClientRepository, DataAccessLayerEF.Repositories.ClientRepository>();
            container.RegisterType<IBranchRepository, DataAccessLayerEF.Repositories.BranchRepository>();
            container.RegisterType<IPositionRepository, DataAccessLayerEF.Repositories.PositionRepository>();
            container.RegisterType<IServicesDirectoryRepository, DataAccessLayerEF.Repositories.ServiceDirectoryRepository>();
            container.RegisterType<IServicesHistoryRepository, DataAccessLayerEF.Repositories.ServiceHistoryRepository>();

            return container;
            
        }


    }
}
