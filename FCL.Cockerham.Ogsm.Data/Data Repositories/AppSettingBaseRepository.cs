using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class AppSettingBaseRepository : BaseRepository<AppSettingBase>, IAppSettingBaseRepository
    {
        public AppSettingBaseRepository(FclDBContext context)
            : base(context)
        {
        }
         
    }
}