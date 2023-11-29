using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class CartHe172748
    {
        public int Id { get; set; }
        public int CustomerCustomerId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public virtual CustomerHe172748 CustomerCustomer { get; set; } = null!;
        public virtual ProductHe172748 Product { get; set; } = null!;
    }
}
