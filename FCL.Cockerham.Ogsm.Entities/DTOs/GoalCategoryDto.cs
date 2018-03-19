using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class GoalCategoryDto
    {
        public long GoalCategoryId { get; set; }
        public long? StTypeId { get; set; }
        public long OrganizationId { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        public ICollection<ActionPlanPlainDto> ActionPlans { get; set; }
        public ICollection<CalendarEventPlainDto> CalendarEvents { get; set; }
        public StTypePlainDto StType { get; set; }
        public ICollection<GoalPlainDto> Goals { get; set; }
        public ICollection<StrategicDriverPlainDto> StrategicDrivers { get; set; }
    }
}
