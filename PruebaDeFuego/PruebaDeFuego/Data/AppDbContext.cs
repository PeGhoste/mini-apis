using Microsoft.EntityFrameworkCore;
using PruebaDeFuego.Models;

namespace PruebaDeFuego.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UsuariosViewModel> usuarios { get; set; }

    }
}
