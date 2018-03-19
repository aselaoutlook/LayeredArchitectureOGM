using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class GlobalRegionPlainDto
    {  
        public long GlobalRegionId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //public virtual ICollection<Country> Countries { get; set; }
        //public virtual ICollection<Location> Locations { get; set; }
    }
}
