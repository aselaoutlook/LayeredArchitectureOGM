using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class DisplayNameRepository : BaseRepository<DisplayName>, IDisplayNameRepository
    {
        public DisplayNameRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}