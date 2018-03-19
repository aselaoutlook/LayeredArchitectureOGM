using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class StrategicDriverTargetDto
    {
        public long StrategicDriverTargetId { get; set; }
        public long StrategicDriverId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(10)]
        public string QuaterName { get; set; }
        public decimal QuaterValue { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual StrategicDriverPlainDto StrategicDriver { get; set; }
    }
}
