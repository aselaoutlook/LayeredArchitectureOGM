using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class ActionStatusRepository : BaseRepository<ActionStatus>, IActionStatusRepository
    {
        public ActionStatusRepository(FclDBContext context)
            : base(context)
        {
        } 
    }
}
