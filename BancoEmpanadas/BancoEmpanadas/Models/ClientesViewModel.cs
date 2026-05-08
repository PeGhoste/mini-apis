using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoEmpanadas.Models
{

    [Table("Clientes")]
    public class ClientesViewModel
    {
        [Key]
        public int idCliente { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public int edad { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string estado { get; set; }


    }
}
