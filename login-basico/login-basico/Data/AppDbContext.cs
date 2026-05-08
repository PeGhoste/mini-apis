using login_basico.Models;
using Microsoft.EntityFrameworkCore;

namespace login_basico.Data
{
    // Importamos de Entity Framework Core el DbContext 
    // que nos permite trabajar con la base de datos
    public class AppDbContext : DbContext
    {
        // Creamos un constructor que recibe las opciones de la base de datos
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        // Creamos un DbSet para la tabla de usuarios
        public DbSet<UsersViewModel> Usuarios { get; set; }

    }
}

