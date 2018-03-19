using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class DisplayBasePlainDto
    {
        public long DisplayBaseId { get; set; }
        [Required]
        [StringLength(300)]
        public string DisplayValue { get; set; }
        //public virtual ICollection<DisplayName> DisplayNames { get; set; }        
    }
}
