using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class GoalTargetPlainDto
    {
        public long GoalTargetId { get; set; }
        public long GoalId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(10)]
        public string YearName { get; set; }
        public decimal YearValue { get; set; }
        public decimal Results { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual GoalDto Goal { get; set; }
    }
}

