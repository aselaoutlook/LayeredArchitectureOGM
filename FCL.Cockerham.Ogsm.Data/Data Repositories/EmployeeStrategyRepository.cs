using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class EmployeeStrategyRepository : BaseRepository<EmployeeStrategy>, IEmployeeStrategyRepository
    {
        public EmployeeStrategyRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
