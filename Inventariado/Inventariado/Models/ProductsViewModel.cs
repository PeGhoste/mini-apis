using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventariado.Models
{
    [Table("Productos")]
    public class ProductsViewModel
    {
        // Métodos get y set 
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string Name { get; set; }
        [Column("Descripcion")]
        public string Description { get; set; }
        [Column("Precio")]
        public decimal Price { get; set; }
        [Column("Stock")]
        public int Stock { get; set; }
        [Column("Categoria")]
        public string Category { get; set; }
    }
}
