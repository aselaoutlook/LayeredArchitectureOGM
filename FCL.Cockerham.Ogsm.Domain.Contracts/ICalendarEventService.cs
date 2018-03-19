using System.Collections.Generic;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;

namespace FCL.Cockerham.Ogsm.Domain.Contracts
{
    public interface ICalendarEventService
    {
        CalendarEventDto CreateCalendarEvent(CalendarEventDto _calendarEvent, IUnitOfWork _dataRepositoryFactory);
        CalendarEventDto UpdateCalendarEvent(CalendarEventDto _calendarEvent, IUnitOfWork _dataRepositoryFactory);
        CalendarEventDto UpdateCalendarEvent(CalendarEventDto _calendarEvent, long _businessUnitId, IUnitOfWork _dataRepositoryFactory);
        CalendarEventDto GetCalendarEventByCalendarEventId(long _calendarEventId, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        ICollection<CalendarEventDto> GetAllCalendarEvents(long _organizationId, IUnitOfWork _dataRepositoryFactory);
        IEnumerable<CalendarEventDto> GetCalendarEventList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory);
        long GetCalendarEventCount(long _organizationId, IUnitOfWork _dataRepositoryFactory); 
    }
}