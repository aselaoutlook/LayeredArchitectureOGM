using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class StTypePlainDto
    {
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

        //public virtual ICollection<StrategicDriver> StrategicDrivers { get; set; }
        //public virtual ICollection<GoalCategory> GoalCategories { get; set; }
    }
}

