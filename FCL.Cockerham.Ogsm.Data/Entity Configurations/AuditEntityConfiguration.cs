#region Header
///--------------------------------------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Data.Entity_Configurations
///MODULE        :         
///SUB MODULE    :    
///Class         : AuditEntityConfiguration
///AUTHOR        : Asela Chamara      
///CREATED       : 03/10/2015 
///DESCRIPTION   : Purpose is to add the configuration details of the FCL.Cockerham.Ogsm.Entities.Audit entity
///MODIFICATION HISTORY:
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///--------------------------------------------------------------------------------------------------------------------------
#endregion

using FCL.Cockerham.Ogsm.Entities;
using System.Data.Entity.ModelConfiguration;

namespace FCL.Cockerham.Ogsm.Data.Entity_Configurations
{
    public class AuditEntityConfiguration : EntityTypeConfiguration<Audit>
    {
        public AuditEntityConfiguration()
        {
            this.Ignore(e => e.EntityId);
            this.MapToStoredProcedures();
        }
    }
}
