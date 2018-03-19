using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class StTypeRepository : BaseRepository<StType>, IStTypeRepository
    {
        public StTypeRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
