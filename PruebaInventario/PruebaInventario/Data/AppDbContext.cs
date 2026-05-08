using Microsoft.EntityFrameworkCore;
using PruebaInventario.Models;

namespace PruebaInventario.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<CategoriasViewModel> categorias { get; set; }
        public DbSet<ProductosViewModel> productos { get; set; }


    }
}
