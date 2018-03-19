using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class CsfRepository : BaseRepository<Csf>, ICsfRepository
    {
        public CsfRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
