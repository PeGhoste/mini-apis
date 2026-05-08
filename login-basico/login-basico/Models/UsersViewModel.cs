using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_basico.Models
{
    [Table("Usuarios")]
    public class UsersViewModel
    {
        [Key]
        [Column("idUsuario")]
        public int IdUser { get; set; }
        [Column("usuario")]
        public string? User { get; set; }
        [Column("pass")]
        public string? Pass { get; set; }
        [Column("fk_idempleado")]
        public int FK_IdEmpleado { get; set; }
    }
}
