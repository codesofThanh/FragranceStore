using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class CategoryHe172748
    {
        public CategoryHe172748()
        {
            ProductHe172748s = new HashSet<ProductHe172748>();
        }

        public string Cname { get; set; } = null!;
        public int Id { get; set; }

        public virtual ICollection<ProductHe172748> ProductHe172748s { get; set; }
    }
}
