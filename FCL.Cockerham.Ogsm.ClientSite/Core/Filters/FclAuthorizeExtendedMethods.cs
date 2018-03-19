using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Filters
{
    //Get requesting user's roles/permissions from database tables...
    [Export(typeof(IFclAuthorizeExtendedMethods))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FclAuthorizeExtendedMethods : IFclAuthorizeExtendedMethods
    {
        public bool HasRole(ControllerBase controller, string role)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has the specified role...
                bFound = new FclAuthorizeUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasRole(role);
                //bFound = new FclAuthorizeUser("admin").HasRole(role);
                //bFound = _User.HasRole(role);
            }
            catch { }
            return bFound;
        }

        public bool HasRoles(ControllerBase controller, string roles)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has any of the specified roles...
                //Make sure you separate the roles using ; (ie "Sales Manager;Sales Operator"
                bFound = new FclAuthorizeUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasRoles(roles);
            }
            catch { }
            return bFound;
        }

        public bool HasPermission(ControllerBase controller, string permission)
        {
            bool bFound = false;
            try
            {
                //Check if the requesting user has the specified application permission...
                bFound = new FclAuthorizeUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasPermission(permission);
            }
            catch { }
            return bFound;
        }

        public bool IsSysAdmin(ControllerBase controller)
        {
            bool bIsSysAdmin = false;
            try
            {
                //Check if the requesting user has the System Administrator privilege...
                bIsSysAdmin = new FclAuthorizeUser(controller.ControllerContext.HttpContext.User.Identity.Name).IsSysAdmin;
            }
            catch { }
            return bIsSysAdmin;
        }
    }
}

