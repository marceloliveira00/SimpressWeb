using System.ComponentModel.DataAnnotations;

namespace Simpress.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool Perishable { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}