using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("GoalCategory")]
    public partial class GoalCategory : EntityBase, IIdentifiableEntity
    {
        public GoalCategory()
        {
            ActionPlans = new HashSet<ActionPlan>();
            CalendarEvents = new HashSet<CalendarEvent>();
            Goals = new HashSet<Goal>();
            StrategicDrivers = new HashSet<StrategicDriver>();
        }

        public long GoalCategoryId { get; set; }
        public long? StTypeId { get; set; }
        public long OrganizationId { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        public StType StType { get; set; }
        public ICollection<ActionPlan> ActionPlans { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<StrategicDriver> StrategicDrivers { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return GoalCategoryId; }
            set { GoalCategoryId = value; }
        }

        #endregion
    }
}
