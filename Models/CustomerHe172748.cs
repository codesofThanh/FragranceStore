using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class CustomerHe172748
    {
        public CustomerHe172748()
        {
            CartHe172748s = new HashSet<CartHe172748>();
            OrderHe172748s = new HashSet<OrderHe172748>();
            ReviewHe172748s = new HashSet<ReviewHe172748>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<CartHe172748> CartHe172748s { get; set; }
        public virtual ICollection<OrderHe172748> OrderHe172748s { get; set; }
        public virtual ICollection<ReviewHe172748> ReviewHe172748s { get; set; }
    }
}
