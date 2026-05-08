using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaDeFuego.Models
{
    [Table("Usuarios")]
    public class UsuariosViewModel
    {
        [Key]
        public int idUsuario { get; set; }

        public string usuario { get; set; }

        public string pass { get; set; }

        public string estado { get; set; }
    }
}
