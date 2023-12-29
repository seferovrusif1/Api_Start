using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
