using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? Categoryname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
