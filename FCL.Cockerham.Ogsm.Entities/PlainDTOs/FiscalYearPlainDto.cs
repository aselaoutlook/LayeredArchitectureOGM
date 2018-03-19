using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class FiscalYearPlainDto
    {
        public long FiscalYearId { get; set; }
        public long OrganizationId { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
        public int EvaluationLength { get; set; }
        [StringLength(1500)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

