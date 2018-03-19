using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}