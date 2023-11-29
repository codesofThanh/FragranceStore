using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class OrderDetailHe172748
    {
        public int Id { get; set; }
        public int ProductHe172748Id { get; set; }
        public int OrderHe172748OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Tmp { get; set; }

        public virtual OrderHe172748 OrderHe172748Order { get; set; } = null!;
        public virtual ProductHe172748 ProductHe172748 { get; set; } = null!;
    }
}
