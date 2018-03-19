using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class DisplayBaseRepository: BaseRepository<DisplayBase>, IDisplayBaseRepository
    {
        public DisplayBaseRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
