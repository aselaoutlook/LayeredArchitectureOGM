﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class CountryPlainDto
    {
        public long CountryId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public long GlobalRegionId { get; set; }
        public virtual GlobalRegionDto GlobalRegion { get; set; }

        //public virtual ICollection<Location> Locations { get; set; }
        //public virtual ICollection<State> States { get; set; }
    }
}


