using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PruebaInventario.Models
{
    [Table("Productos")]
    public class ProductosViewModel
    {
        [Key]
        [Column("idProducto")]
        public int IdProducto { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }
        [Column("stock")]
        public int Stock { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [ForeignKey("fk_idCategoria")]
        public int FK_IdCategoria { get; set; }

    }
}
