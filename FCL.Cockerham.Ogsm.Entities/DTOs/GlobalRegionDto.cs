using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class GlobalRegionDto
    {  
        public long GlobalRegionId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<CountryPlainDto> Countries { get; set; }
        public virtual ICollection<LocationPlainDto> Locations { get; set; }
    }
}
