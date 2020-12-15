using System;
using System.Collections.Generic;

namespace Core_NewServie.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BasePrice { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
