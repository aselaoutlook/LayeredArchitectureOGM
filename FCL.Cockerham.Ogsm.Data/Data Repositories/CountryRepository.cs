using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}
