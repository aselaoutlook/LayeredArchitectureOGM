using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}