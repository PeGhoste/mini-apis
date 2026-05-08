using BancoEmpanadas.Data;
using BancoEmpanadas.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEmpanadas.DAO
{
    public class ClientesDao
    {

        private readonly AppDbContext _context;

        public ClientesDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientesViewModel>> ObtenerClientes()
        {

            List<ClientesViewModel> clientes = new List<ClientesViewModel>();

            return clientes = await _context.clientes.ToListAsync();

        }

        public async Task<ClientesViewModel> CrearCliente(ClientesViewModel client)
        {
            _context.clientes.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }


    }
}
