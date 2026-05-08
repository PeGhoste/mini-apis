using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PruebaDeFuego.Data;
using PruebaDeFuego.Models;

namespace PruebaDeFuego.DAO
{
    public class UsuariosDao
    {
        private readonly AppDbContext _context;

        public UsuariosDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuariosViewModel>> ObtenerUsuarios()
        {
            List<UsuariosViewModel> usuarios = new List<UsuariosViewModel>();

            usuarios = await _context.usuarios.ToListAsync();

            if(usuarios == null)
            {
                return new List<UsuariosViewModel>();
            }
            else
            {
                return usuarios;
            }

        }

        public async Task<UsuariosViewModel> ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = await _context.usuarios.FirstOrDefaultAsync(u => u.idUsuario == idUsuario);

            if(usuario == null)
            {
                return null;
            }
            else
            {
                return usuario;
            }

        }

        public async Task<UsuariosViewModel> CrearUsuario(UsuariosViewModel usuario)
        {

            _context.Add(usuario);
            AppWinStyle 


        }


    }
}
