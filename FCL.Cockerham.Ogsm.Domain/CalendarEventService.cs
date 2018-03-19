using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FCL.Cockerham.Ogsm.Data.Contracts;
using FCL.Cockerham.Ogsm.Data.Contracts.Repository_Interfaces;
using FCL.Cockerham.Ogsm.Domain.Contracts;
using FCL.Cockerham.Ogsm.Entities;
using FCL.Cockerham.Ogsm.Entities.DTOs;
using AutoMapper;

namespace FCL.Cockerham.Ogsm.Domain
{
    [Export(typeof(ICalendarEventService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CalendarEventService:ICalendarEventService
    {
        public CalendarEventDto CreateCalendarEvent(CalendarEventDto _calendarEvent, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            CalendarEventDto _createdCalendarEvent = Mapper.Map<CalendarEventDto>(CalendarEventService.Add(Mapper.Map<CalendarEvent>(_calendarEvent)));

            return _createdCalendarEvent;
        }

        public CalendarEventDto UpdateCalendarEvent(CalendarEventDto _calendarEvent, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            CalendarEventDto _updatedCalendarEvent = Mapper.Map<CalendarEventDto>(CalendarEventService.Update(Mapper.Map<CalendarEvent>(_calendarEvent)));

            return _updatedCalendarEvent;
        }

        public CalendarEventDto UpdateCalendarEvent(CalendarEventDto _calendarEvent, long _calendarEventId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            CalendarEventDto _updatedCalendarEvent = Mapper.Map<CalendarEventDto>(CalendarEventService.Update(Mapper.Map<CalendarEvent>(_calendarEvent), _calendarEventId));

            return _updatedCalendarEvent;
        }

        public CalendarEventDto GetCalendarEventByCalendarEventId(long _calendarEventId, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            CalendarEventDto _calendarEvent = Mapper.Map<CalendarEventDto>(CalendarEventService.GetSingle(i => i.CalendarEventId.Equals(_calendarEventId) && i.OrganizationId.Equals(_organizationId)));

            return _calendarEvent;
        }

        public ICollection<CalendarEventDto> GetAllCalendarEvents(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            ICollection<CalendarEventDto> _allCalendarEvents = Mapper.Map<ICollection<CalendarEventDto>>(CalendarEventService.GetAll(i => i.OrganizationId.Equals(_organizationId)));

            return _allCalendarEvents;
        }

        public IEnumerable<CalendarEventDto> GetCalendarEventList(int pageNo, int pageSize, long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            IEnumerable<CalendarEventDto> _allCalendarEvents = Mapper.Map<IEnumerable<CalendarEventDto>>(CalendarEventService.GetPagedList(pageNo, pageSize, i => i.OrganizationId.Equals(_organizationId), q => q.OrderBy(s => s.Name), null));

            return _allCalendarEvents;
        }

        public long GetCalendarEventCount(long _organizationId, IUnitOfWork _dataRepositoryFactory)
        {
            IBaseRepository<CalendarEvent> CalendarEventService = _dataRepositoryFactory.GetRepository<CalendarEvent>();
            return CalendarEventService.Count(i => i.OrganizationId.Equals(_organizationId));
        }
    }
}