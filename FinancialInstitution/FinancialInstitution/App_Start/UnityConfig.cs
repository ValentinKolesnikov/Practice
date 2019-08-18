using DataAccessLayerADO.Interfaces;
using DataAccessLayerADO.Mappers;
using DataAccessLayerCommon.Interfaces;
using System;

using Unity;

namespace FinancialInstitution
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IEmployeeMapper, EmployeeMapper>();
            container.RegisterType<IBranchMapper, BranchMapper>();
            container.RegisterType<IClientMapper, ClientMapper>();
            container.RegisterType<IPositionMapper, PositionMapper>();
            container.RegisterType<IServiceHistoryMapper, ServiceHistoryMapper>();
            container.RegisterType<IServiceDirectoryMapper, ServiceDirectoryMapper>();

            container.RegisterType<IEmployeeRepository, DataAccessLayerADO.Repositories.EmployeeRepository>();
            container.RegisterType<IClientRepository, DataAccessLayerEF.Repositories.ClientRepository>();
            container.RegisterType<IBranchRepository, DataAccessLayerEF.Repositories.BranchRepository>();
            container.RegisterType<IPositionRepository, DataAccessLayerEF.Repositories.PositionRepository>();
            container.RegisterType<IServicesDirectoryRepository, DataAccessLayerEF.Repositories.ServiceDirectoryRepository>();
            container.RegisterType<IServicesHistoryRepository, DataAccessLayerEF.Repositories.ServiceHistoryRepository>();
        }
    }
}