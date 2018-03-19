using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("Employee")]
    public partial class Employee : EntityBase, IIdentifiableEntity
    {
        public Employee()
        {
            EmployeeStrategies = new HashSet<EmployeeStrategy>();
        }

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

        public virtual User User { get; set; }

        public virtual ICollection<EmployeeStrategy> EmployeeStrategies { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return EmployeeId; }
            set { EmployeeId = value; }
        }

        #endregion

    }

}


