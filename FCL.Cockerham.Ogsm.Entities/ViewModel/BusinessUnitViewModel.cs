using FCL.Cockerham.Ogsm.Entities.DTOs;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Entities.ViewModel
{
    public class BusinessUnitViewModel
    {
        public BusinessUnitDto businessUnit { get; set; }
        public ICollection<BusinessUnitDto> businessUnits { get; set; }
    }
}
