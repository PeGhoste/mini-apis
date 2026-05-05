using System.ComponentModel.DataAnnotations.Schema;

namespace Inventariado.Models
{
    [Table("Productos")]
    public class ProductsViewModel
    {
        // Métodos get y set 
        public int Id { get; set; }
        public string Name {get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
    }
}

