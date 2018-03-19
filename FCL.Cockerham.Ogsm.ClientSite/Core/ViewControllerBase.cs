using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Cockerham.Ogsm.ClientSite.ActionResults;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using FCL.Cockerham.Ogsm.Entities.CustomDTOs;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
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
            LoggedInUserDto _user = (LoggedInUserDto)Session["LoggedInUser"];
            if (_user == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Account/Authenticate");
                return;
            }
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

        //public JsonResultExtender<T> JsonExtender<T>(T model)
        //{
        //    return new JsonResultExtender<T>() { Data = model };
        //}
    }
}