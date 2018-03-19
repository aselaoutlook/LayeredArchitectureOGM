using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{

    [Table("EmployeeStrategy")]
    public partial class EmployeeStrategy
    {
        public long EmployeeStrategyId { get; set; }

        public long EmployeeId { get; set; }

        public long UserId { get; set; }

        public long OrganizationId { get; set; }

        public long? StrategicDriverId { get; set; }

        public bool? IsBusinessUnitLead { get; set; }

        public bool? IsGoalOwner { get; set; }

        public bool? IsStrategicDriverOwner { get; set; }

        public bool? IsActionPlanOwner { get; set; }

        public bool? IsViewOnly { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(1500)]
        public string Notes { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Employee EmployeeStrategyEmployee { get; set; }
        
        public virtual StrategicDriver StrategicDriver { get; set; }

        public virtual User EmployeeStrategyUser { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return EmployeeStrategyId; }
            set { EmployeeStrategyId = value; }
        }

        #endregion
    }
}
