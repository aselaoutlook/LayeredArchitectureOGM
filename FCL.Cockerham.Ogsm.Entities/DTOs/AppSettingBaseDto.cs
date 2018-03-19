using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class AppSettingBaseDto
    {
        public long AppSettingBaseId { get; set; }
        [Required]
        [StringLength(50)]
        public string SettingValue { get; set; }
        public virtual ICollection<AppSettingPlainDto> AppSettings { get; set; }
    }
}
