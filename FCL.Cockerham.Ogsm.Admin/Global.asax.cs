using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FCL.Cockerham.Ogsm.Admin.Core;
using FCL.Cockerham.Ogsm.Bootstrapper;
using FCL.Web.Framework.Core.Common.Core;

namespace FCL.Cockerham.Ogsm.Admin
{
    public class MvcApplication : HttpApplication
    {
        public static CompositionContainer baseContainer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
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
            
        }
    }
}
