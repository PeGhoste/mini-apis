using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BancoEmpanadas.Models
{
    [Table("Cuentas")]
    public class CuentasViewModel
    {
        [Key]
        public int? idCuenta { get; set; }

        public string tipoCuenta { get; set; }

        public string numeroCuenta { get; set; }

        public decimal saldo { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public string? estado { get; set; }


        [ForeignKey("fk_idCliente")]
        [Column("fk_idCliente")]
        public int idCliente { get; set; }


    }
}
