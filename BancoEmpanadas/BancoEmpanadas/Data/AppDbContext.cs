using BancoEmpanadas.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEmpanadas.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ClientesViewModel> clientes { get; set; }
        public DbSet<CuentasViewModel> cuentas { get; set; }


    }
}
