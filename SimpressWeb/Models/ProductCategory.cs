using System.ComponentModel.DataAnnotations;

namespace Simpress.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}