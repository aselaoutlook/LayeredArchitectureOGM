using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class CsfPlainDto
    {
        public long CsfId { get; set; }
        public long OrganizationId { get; set; }
        public long? StTypeId { get; set; }
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        public int? SequenceNumber { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

