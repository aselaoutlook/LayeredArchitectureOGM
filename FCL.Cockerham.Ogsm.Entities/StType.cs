using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCL.Web.Framework.Core.Common.Contracts;
using FCL.Web.Framework.Core.Common.Core;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCL.Cockerham.Ogsm.Entities
{
    [Table("StType")]
    public partial class StType : EntityBase, IIdentifiableEntity
    {
        public StType()
        {
            StrategicDrivers = new HashSet<StrategicDriver>();
            GoalCategories = new HashSet<GoalCategory>();
        }

        public long StTypeId { get; set; }

        public long OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
        public ICollection<StrategicDriver> StrategicDrivers { get; set; }

        public ICollection<GoalCategory> GoalCategories { get; set; }

        #region IIdentifiableEntity members

        public long EntityId
        {
            get { return StTypeId; }
            set { StTypeId = value; }
        }

        #endregion

    }
}

