using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class StrategicDriverTargetRepository : BaseRepository<StrategicDriver>, IStrategicDriverRepository
    {
        public StrategicDriverTargetRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
