using System.Collections.Generic;

namespace FCL.Cockerham.Ogsm.Entities.ViewModel
{
    public class EmployeeUserViewModel
    {
        public User UserOwner { get; set; }
        public Employee EmployeeOwner { get; set; }
        public ICollection<User> UserOwners { get; set; }
        public ICollection<Employee> EmployeeOwners { get; set; }
    }
}
