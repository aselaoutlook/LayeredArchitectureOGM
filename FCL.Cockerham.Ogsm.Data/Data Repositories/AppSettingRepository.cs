using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class AppSettingRepository : BaseRepository<AppSetting>, IAppSettingRepository
    {
        public AppSettingRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}