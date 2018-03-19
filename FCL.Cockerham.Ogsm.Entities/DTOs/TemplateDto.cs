using System;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class TemplateDto
    {
        public long TemplateID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Template name is required")]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Template content is required")]
        public string Content { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Salt { get; set; }
        public DateTime CreatedOn { get; set; }        
        public DateTime LastLoggedOn { get; set; }
        public int Status { get; set; }
        [StringLength(5, MinimumLength = 5)]
        public string LanguageCode { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string TimeZone { get; set; }
    }
}
