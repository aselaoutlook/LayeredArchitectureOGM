using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class EmployeePlainDto
    {
        public long EmployeeId { get; set; }
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        [StringLength(15)]
        public string BusinessPhone { get; set; }
        [StringLength(15)]
        public string Fax { get; set; }
        [StringLength(15)]
        public string HomePhone { get; set; }
        [StringLength(100)]
        public string AddressOne { get; set; }
        [StringLength(100)]
        public string AddressTwo { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(10)]
        public string Zip { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        public bool? IsBusinessUnitLead { get; set; }
        public bool? IsGoalOwner { get; set; }
        public bool? IsStrategicDriverOwner { get; set; }
        public bool? IsActionPlanOwner { get; set; }
        public bool? IsViewOnly { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserDto User { get; set; }
        //public virtual ICollection<EmployeeStrategy> EmployeeStrategies { get; set; }
    }

}


