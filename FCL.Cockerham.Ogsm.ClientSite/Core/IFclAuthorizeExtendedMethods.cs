using System.Web.Mvc;

namespace FCL.Cockerham.Ogsm.ClientSite.Core
{
    public interface IFclAuthorizeExtendedMethods
    {
        bool HasPermission(ControllerBase controller, string requiredPermission);
        bool HasRole(ControllerBase controller, string role);
        bool HasRoles(ControllerBase controller, string roles);
        bool IsSysAdmin(ControllerBase controller);
    }
}
