using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Blog
    {
        public Blog()
        {
            TagBlogs = new HashSet<TagBlog>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual ICollection<TagBlog> TagBlogs { get; set; }
    }
}
