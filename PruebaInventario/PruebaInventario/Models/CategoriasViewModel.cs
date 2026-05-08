using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaInventario.Models
{
    [Table("Categorias")]
    public class CategoriasViewModel
    {
        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }

        [Column("categoria")]
        public string Categoria { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

    }
}
