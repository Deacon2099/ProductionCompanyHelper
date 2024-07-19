using ProductionCompanyHelper.Controllers;
using ProductionCompanyHelper.Models;
using ProductionCompanyHelper.Services.Implementations;
using ProductionCompanyHelper.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductionCompanyHelper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<CalculatorContext>(Lifestyle.Scoped);
            container.Register<ICityService, CityService>(Lifestyle.Scoped);
            container.Register<IModuleService, ModuleService>(Lifestyle.Scoped);
            container.Register<ICalculatorCostService, CalculatorCostService>(Lifestyle.Scoped);
            container.Register<ISearchHistoryService, SearchHistoryService>(Lifestyle.Scoped);
            container.Register<IShowResultService, ShowResultService>(Lifestyle.Scoped);
            container.Register<CitiesController>(Lifestyle.Scoped);
            container.Register<ModulesController>(Lifestyle.Scoped);
            container.Register<SearchHistoriesController>(Lifestyle.Scoped);
            container.Register<ShowResultController>(Lifestyle.Scoped);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
