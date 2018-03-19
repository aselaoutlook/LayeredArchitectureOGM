#region Header
///--------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Entity_Configurations
///MODULE        :         
///SUB MODULE    :    
///Class         : RoleEntityConfiguration
///AUTHOR        : Asela Chamara      
///CREATED       : 03/10/2015 
///DESCRIPTION   : Purpose is to add the configuration details of the FCL.Cockerham.Ogsm.Entities.Role entity
///MODIFICATION HISTORY:
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///--------------------------------------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);             
            

            this.HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));
        }
    }
}
