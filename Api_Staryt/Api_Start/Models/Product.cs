using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            TagProducts = new HashSet<TagProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string ProductHoverImg { get; set; } = null!;
        public string ProductMainImg { get; set; } = null!;
        public string? About { get; set; }
        public string? Description { get; set; }
        public decimal SellPrice { get; set; }
        public decimal CostPrice { get; set; }
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<TagProduct> TagProducts { get; set; }
    }
}
