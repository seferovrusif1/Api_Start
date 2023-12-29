using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class TagBlog
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual Tag Tag { get; set; } = null!;
    }
}
