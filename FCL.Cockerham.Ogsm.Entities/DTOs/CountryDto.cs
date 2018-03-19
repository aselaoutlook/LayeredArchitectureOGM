using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class CountryDto
    {
        public long CountryId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public long GlobalRegionId { get; set; }
        public virtual GlobalRegionPlainDto GlobalRegion { get; set; }

        public virtual ICollection<LocationPlainDto> Locations { get; set; }
        public virtual ICollection<StatePlainDto> States { get; set; }
    }
}


