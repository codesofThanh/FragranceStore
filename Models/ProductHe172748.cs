using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class ProductHe172748
    {
        public ProductHe172748()
        {
            CartHe172748s = new HashSet<CartHe172748>();
            OrderDetailHe172748s = new HashSet<OrderDetailHe172748>();
            ReviewHe172748s = new HashSet<ReviewHe172748>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Price { get; set; }
        public int EmployeeEmployeeId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public string Tmp { get; set; } = null!;

        public virtual CategoryHe172748 Category { get; set; } = null!;
        public virtual EmployeeHe172748 EmployeeEmployee { get; set; } = null!;
        public virtual ICollection<CartHe172748> CartHe172748s { get; set; }
        public virtual ICollection<OrderDetailHe172748> OrderDetailHe172748s { get; set; }
        public virtual ICollection<ReviewHe172748> ReviewHe172748s { get; set; }
    }
}
