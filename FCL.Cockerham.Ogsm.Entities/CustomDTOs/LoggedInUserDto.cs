using System;
using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Entities.CustomDTOs
{
    public class LoggedInUserDto
    {
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string LanguageCode { get; set; }
        public string TimeZone { get; set; }
        public DateTime? LastLoggedOn { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual IList<Employee> EmployeeUser { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual IList<Role> Roles { get; set; }
        public virtual ICollection<StrategicDriver> OwnerStrategicDrivers { get; set; }
    }
}
