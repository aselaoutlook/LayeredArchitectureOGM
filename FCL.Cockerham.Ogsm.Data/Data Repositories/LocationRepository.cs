using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
