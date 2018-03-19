using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class LocationPlainDto
    {
        public long LocationId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        public bool IsGlobal { get; set; }
        public long StateId { get; set; }
        public long CountryId { get; set; }
        public long GlobalRegionId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual CountryDto Country { get; set; }
        public virtual GlobalRegionDto GlobalRegion { get; set; }
        public virtual StateDto State { get; set; }
    }
}

