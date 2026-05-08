using BancoEmpanadas.Data;
using BancoEmpanadas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<ClientesViewModel> ObtenerClientePorId(int idCliente)
        {
            var resp = await _context.clientes.FirstOrDefaultAsync(c => c.idCliente == idCliente);

            return resp;

        }

        public async Task<ClientesViewModel> CrearCliente(ClientesViewModel client)
        {
            _context.clientes.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<ClientesViewModel> ActualizarCliente(int idCliente, ClientesViewModel client)
        {

            var clienteExiste = await _context.clientes.FirstOrDefaultAsync(c => c.idCliente == client.idCliente);

            if(clienteExiste != null)
            {
                clienteExiste.nombres = client.nombres;
                clienteExiste.apellidos = client.apellidos;
                clienteExiste.edad = client.edad;
                clienteExiste.estado = client.estado;

                await _context.SaveChangesAsync();
                return clienteExiste;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> EliminarCliente(int idCliente)
        {
            var clienteExiste = await _context.clientes.FirstOrDefaultAsync(c => c.idCliente == idCliente);

            if(clienteExiste != null)
            {
                _context.Remove(clienteExiste);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
