using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class AppSettingDto
    {
        public long AppSettingId { get; set; }
        public long OrganizationId { get; set; }
        public long AppSettingBaseId { get; set; }
        [Required]
        [StringLength(50)]
        public string AppSettingValue { get; set; }
        public virtual AppSettingBasePlainDto AppSettingBase { get; set; }
    }
}

