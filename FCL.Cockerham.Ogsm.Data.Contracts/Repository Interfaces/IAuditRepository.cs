using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces
{
    public interface IAuditRepository : IBaseRepository<Audit>
    {
        IEnumerable<Audit> AllAudits();
    }
}
