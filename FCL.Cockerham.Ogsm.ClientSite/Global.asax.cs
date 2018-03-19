using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FCL.Cockerham.Ogsm.Bootstrapper;
using FCL.Cockerham.Ogsm.ClientSite.Core;
using FCL.Web.Framework.Core.Common.Core;
using FCL.Cockerham.Ogsm.ClientSite.App_Start;
using FCL.Cockerham.Ogsm.ClientSite.Core.Filters;
using System.Configuration;

namespace FCL.Cockerham.Ogsm.ClientSite
{
    public class MvcApplication : HttpApplication
    {
        public static CompositionContainer baseContainer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            CompositionContainer container = MefLoader.Init(catalog.Catalogs);
            ObjectBase.Container = container;
            baseContainer = container;

            //Resolved dependancy through mef resolvers
            DependencyResolver.SetResolver(new MefDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new MefAPIDependencyResolver(container);
            AutoMapperConfigLoader.RegisterMappings();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;            
            GlobalFilters.Filters.Add(new ExceptionFilter());


            if (ConfigurationManager.AppSettings["ApplicationEnviorment"] == "Development")
            {
                ResourceExtensions.JavascriptStrings("SystemMessages");
            }
        }

        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
    }
}
