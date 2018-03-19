using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("User")]
    public partial class User : EntityBase, IIdentifiableEntity
    {
        public User()
        {
            OwnedActionPlans = new HashSet<ActionPlan>();
            EmployeeUser = new List<Employee>();
            OwnedEmployeeStrategies = new List<EmployeeStrategy>();
            PrimaryOwnerGoals = new HashSet<Goal>();
            SecondryOwnerGoals = new HashSet<Goal>();
            OwnerStrategicDrivers  = new HashSet<StrategicDriver>();
            Roles = new List<Role>();
        }

        public long UserId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(1)]
        public string MiddleInitial { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Salt { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public DateTime? LastLoggedOn { get; set; }

        public bool IsActive { get; set; }

        [StringLength(5)]
        public string LanguageCode { get; set; }

        [StringLength(50)]
        public string TimeZone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<ActionPlan> OwnedActionPlans { get; set; }

        public virtual IList<Employee> EmployeeUser { get; set; }

        public virtual ICollection<Goal> PrimaryOwnerGoals { get; set; }

        public virtual ICollection<Goal> SecondryOwnerGoals { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<StrategicDriver> OwnerStrategicDrivers { get; set; }

        public virtual IList<Role> Roles { get; set; }

        public virtual IList<EmployeeStrategy> OwnedEmployeeStrategies { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return UserId; }
            set { UserId = value; }
        }

        #endregion
    }
}
