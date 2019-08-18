using FinancialInstitution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.AspNet.Mvc;

namespace FinancialIntitution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
