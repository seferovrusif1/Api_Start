using System;
using System.Collections.Generic;

namespace Api_Start.Models
{
    public partial class Author
    {
        public Author()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
