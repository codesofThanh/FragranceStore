using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class EmployeeHe172748
    {
        public EmployeeHe172748()
        {
            ProductHe172748s = new HashSet<ProductHe172748>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleRoleId { get; set; }
        public string Email { get; set; } = null!;

        public virtual RoleHe172748 RoleRole { get; set; } = null!;
        public virtual ICollection<ProductHe172748> ProductHe172748s { get; set; }
    }
}
