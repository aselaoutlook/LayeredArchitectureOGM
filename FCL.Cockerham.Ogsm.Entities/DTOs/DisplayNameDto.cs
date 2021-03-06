﻿using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class DisplayNameDto
    {
        public long DisplayNameId { get; set; }
        public long OrganizationId { get; set; }
        public long DisplayBaseId { get; set; }
        [Required]
        [StringLength(300)]
        public string DisplayValue { get; set; }
        public virtual DisplayBasePlainDto DisplayBase { get; set; }
    }
}

