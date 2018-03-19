using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class StrategicDriverRepository : BaseRepository<StrategicDriver>, IStrategicDriverRepository
    {
        public StrategicDriverRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}