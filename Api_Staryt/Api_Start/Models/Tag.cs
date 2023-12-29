using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagBlogs = new HashSet<TagBlog>();
            TagProducts = new HashSet<TagProduct>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<TagBlog> TagBlogs { get; set; }
        public virtual ICollection<TagProduct> TagProducts { get; set; }
    }
}
