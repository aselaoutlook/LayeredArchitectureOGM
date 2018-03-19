using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class DisplayNamePlainDto
    {
        public long DisplayNameId { get; set; }
        public long OrganizationId { get; set; }
        public long DisplayBaseId { get; set; }
        [Required]
        [StringLength(300)]
        public string DisplayValue { get; set; }
        public virtual DisplayBaseDto DisplayBase { get; set; }
    }
}

