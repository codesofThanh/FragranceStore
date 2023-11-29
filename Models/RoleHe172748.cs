using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class RoleHe172748
    {
        public RoleHe172748()
        {
            EmployeeHe172748s = new HashSet<EmployeeHe172748>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<EmployeeHe172748> EmployeeHe172748s { get; set; }
    }
}
