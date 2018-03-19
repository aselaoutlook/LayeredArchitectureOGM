using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FCL.Cockerham.Ogsm.Entities.DTOs
{
    public class ActionOperatorPlainDto
    {
        public long ActionOperatorId { get; set; }
        [Required]
        [StringLength(50)]
        public string Operator { get; set; }
        //public virtual ICollection<ActionStatus> ActionStatuses { get; set; }
    }
}
