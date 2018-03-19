using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class GoalCategoryPlainDto
    {
        public long GoalCategoryId { get; set; }
        public long? StTypeId { get; set; }
        public long OrganizationId { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        //public ICollection<ActionPlan> ActionPlans { get; set; }
        //public ICollection<CalendarEvent> CalendarEvents { get; set; }
        public StTypeDto StType { get; set; }
        //public ICollection<Goal> Goals { get; set; }
        //public ICollection<StrategicDriver> StrategicDrivers { get; set; }
    }
}
