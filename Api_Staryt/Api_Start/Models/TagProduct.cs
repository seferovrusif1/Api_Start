using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class TagProduct
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
