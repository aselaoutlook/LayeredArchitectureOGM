using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class ActionOperatorRepository : BaseRepository<ActionOperator>, IActionOperatorRepository
    {
        public ActionOperatorRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
