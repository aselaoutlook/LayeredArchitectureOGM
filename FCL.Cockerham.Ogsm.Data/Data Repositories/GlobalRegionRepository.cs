using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class GlobalRegionRepository : BaseRepository<GlobalRegion>, IGlobalRegionRepository
    {
        public GlobalRegionRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
