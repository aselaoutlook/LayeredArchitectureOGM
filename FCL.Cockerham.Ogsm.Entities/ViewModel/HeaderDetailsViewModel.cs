using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Entities.ViewModel
{
    public class HeaderDetailsViewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string CompanyLogo { get; set; }
        public string UserImage { get; set; }
    }
}
