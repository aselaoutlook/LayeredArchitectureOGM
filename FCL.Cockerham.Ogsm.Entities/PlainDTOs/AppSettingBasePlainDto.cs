using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class AppSettingBasePlainDto
    {
        public long AppSettingBaseId { get; set; }
        [Required]
        [StringLength(50)]
        public string SettingValue { get; set; }
        //public virtual ICollection<AppSetting> AppSettings { get; set; }
    }
}
