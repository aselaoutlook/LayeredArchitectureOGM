using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class StatePlainDto
    {
        public long StateId { get; set; }
        public long CountryId { get; set; }
        public long OrganizationId { get; set; }
        [Required]
        [StringLength(50)]
        public string StateName { get; set; }
        [StringLength(10)]
        public string StateCode { get; set; }
        public virtual CountryDto Country { get; set; }
        //public virtual ICollection<Location> Locations { get; set; }
    }
}
     
