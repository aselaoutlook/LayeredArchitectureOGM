using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FCL.Cockerham.Ogsm.Admin.Core.Filters
{
    public class FclAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string requiredPermission = String.Format("{0}-{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
            FclAuthorizeUser requestingUser = new FclAuthorizeUser("admin");

            if (!requestingUser.HasPermission(requiredPermission) & !requestingUser.IsSysAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "AccessDenied" }, { "controller", "ErrorController" } });
            }
        }
    }
}

