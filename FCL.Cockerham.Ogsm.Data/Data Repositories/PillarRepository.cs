using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class PillarRepository : BaseRepository<Pillar>, IPillarRepository
    {
        public PillarRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
