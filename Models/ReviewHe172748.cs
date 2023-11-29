using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class ReviewHe172748
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int ProductId { get; set; }
        public int Star { get; set; }
        public int CustomerCustomerId { get; set; }
        public DateTime CreateOn { get; set; }
        public string Tmp { get; set; } = null!;

        public virtual CustomerHe172748 CustomerCustomer { get; set; } = null!;
        public virtual ProductHe172748 Product { get; set; } = null!;
    }
}
