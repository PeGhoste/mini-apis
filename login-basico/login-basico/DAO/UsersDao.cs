using login_basico.Data;
using login_basico.Models;
using Microsoft.EntityFrameworkCore;

namespace login_basico.DAO
{
    public class UsersDao
    {
        // Creamos una instancia de la base de datos
        private readonly AppDbContext _context;

        // Creamos un constructor que recibe la base de datos
        public UsersDao(AppDbContext context)
        {
            _context = context;
        }

        // Creamos un método de login
        public async Task<UsersViewModel> Login(string username, string pass)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User == username && u.Pass == pass);
        }

       
    }
}