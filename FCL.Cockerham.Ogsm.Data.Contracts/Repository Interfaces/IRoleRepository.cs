using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Role AddAllPermissionToRole(Role role);
    }
}
