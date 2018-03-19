using FCL.Cockerham.Ogsm.ClientSite.Core.Filters;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Filters
{
    public static class FclStaticApiAuthorizeExtendedMethods
    {
        public static bool HasSRole(this ApiControllerBase controller, string role)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has the specified role...
                bFound = new FclAuthorizeUser(controller.ControllerContext.RequestContext.Principal.Identity.Name).HasRole(role);
                //bFound = new FclAuthorizeUser("admin").HasRole(role);
                //bFound = _User.HasRole(role);
            }
            catch { }
            return bFound;
        }

        public static bool HasRole(this ApiControllerBase controller, string role)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has the specified role...
                bFound = new FclAuthorizeUser(controller.ControllerContext.RequestContext.Principal.Identity.Name).HasRole(role);
                //bFound = new FclAuthorizeUser("admin").HasRole(role);
                //bFound = _User.HasRole(role);
            }
            catch { }
            return bFound;
        }

        public static bool HasRoles(this ApiControllerBase controller, string roles)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has any of the specified roles...
                //Make sure you separate the roles using ; (ie "Sales Manager;Sales Operator"

                bFound = new FclAuthorizeUser(controller.ControllerContext.RequestContext.Principal.Identity.Name).HasRoles(roles);
            }
            catch { }
            return bFound;
        }

        public static bool HasPermission(this ApiControllerBase controller, string permission)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has the specified application permission...
                bFound = new FclAuthorizeUser(controller.ControllerContext.RequestContext.Principal.Identity.Name).HasPermission(permission);
            }
            catch { }
            return bFound;
        }

        public static bool IsSysAdmin(this ApiControllerBase controller)
        {
            bool bIsSysAdmin = false;
            try
            {
                //Check if the requesting user has the System Administrator privilege...
                bIsSysAdmin = new FclAuthorizeUser(controller.ControllerContext.RequestContext.Principal.Identity.Name).IsSysAdmin;
            }
            catch { }
            return bIsSysAdmin;
        }
    }
}