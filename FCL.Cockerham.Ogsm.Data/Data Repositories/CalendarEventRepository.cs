using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Entities;

namespace FCL.Cockerham.Ogsm.Data.Data_Repositories
{
    public class CalendarEventRepository : BaseRepository<CalendarEvent>, ICalendarEventRepository
    {
        public CalendarEventRepository(FclDBContext context)
            : base(context)
        {
        }
    }
}