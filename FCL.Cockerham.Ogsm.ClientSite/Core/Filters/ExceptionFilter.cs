using FCL.Web.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Filters
{
    public class ExceptionFilter : HandleErrorAttribute
    {
        ILoggerService _logger { get; set; }

        public ExceptionFilter()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = FCL.Cockerham.Ogsm.Bootstrapper.MefLoader.Init(catalog.Catalogs);
            _logger = container.GetExportedValue<ILoggerService>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);
            ViewResult v = new ViewResult();
            v.ViewName = "Error";
            v.ViewBag.Message = filterContext.Exception.Message;
            filterContext.Result = v;
            filterContext.ExceptionHandled = true;
            _logger.Error(filterContext.Exception);

        }    
    }
}