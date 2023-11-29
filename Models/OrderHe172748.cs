using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class OrderHe172748
    {
        public OrderHe172748()
        {
            OrderDetailHe172748s = new HashSet<OrderDetailHe172748>();
        }

        public int OrderId { get; set; }
        public string Address { get; set; } = null!;
        public decimal Total { get; set; }
        public int CustomerHe172748CustomerId { get; set; }
        public int? StatusId { get; set; }
        public string? Tmp { get; set; }

        public virtual CustomerHe172748 CustomerHe172748Customer { get; set; } = null!;
        public virtual ICollection<OrderDetailHe172748> OrderDetailHe172748s { get; set; }
    }
}
