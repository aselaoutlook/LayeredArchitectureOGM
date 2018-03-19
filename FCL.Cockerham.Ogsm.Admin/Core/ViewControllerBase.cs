using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.Admin.ActionResults;

namespace FCL.Cockerham.Ogsm.Admin.Core
{
    public class ViewControllerBase : Controller
    {
        List<IServiceContract> _DisposableServices;

        protected virtual void RegisterServices(List<IServiceContract> disposableServices)
        {
        }

        List<IServiceContract> DisposableServices
        {
            get
            {
                if (_DisposableServices == null)
                    _DisposableServices = new List<IServiceContract>();

                return _DisposableServices;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            RegisterServices(DisposableServices);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            foreach (var service in DisposableServices)
            {
                if (service != null && service is IDisposable)
                    (service as IDisposable).Dispose();
            }
        }

        public JsonResultExtender<T> JsonExtender<T>(T model)
        {
            return new JsonResultExtender<T>() { Data = model };
        }
    }
}