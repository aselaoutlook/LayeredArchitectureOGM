using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
