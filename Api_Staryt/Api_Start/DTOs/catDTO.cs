using Api_Start.Models;

namespace Api_Start.DTOs
{
    public class catDTO
    {
       

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int? ParentCategoryId { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
