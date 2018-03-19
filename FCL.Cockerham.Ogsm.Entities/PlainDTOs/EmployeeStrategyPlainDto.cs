using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class EmployeeStrategyPlainDto
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
        public virtual EmployeeDto EmployeeStrategyEmployee { get; set; }        
        public virtual StrategicDriverDto StrategicDriver { get; set; }
        public virtual UserDto EmployeeStrategyUser { get; set; }        
    }
}
