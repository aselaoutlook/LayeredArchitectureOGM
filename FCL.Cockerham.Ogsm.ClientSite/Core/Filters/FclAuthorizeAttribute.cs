using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Filters
{
    public class FclAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string requiredPermission = String.Format("{0}-{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);

            FclAuthorizeUser requestingUser = new FclAuthorizeUser(HttpContext.Current.User.Identity.Name);

            if (!requestingUser.HasPermission(requiredPermission) & !requestingUser.IsSysAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "AccessDenied" }, { "controller", "ErrorController" } });
            }
        }
    }
}

