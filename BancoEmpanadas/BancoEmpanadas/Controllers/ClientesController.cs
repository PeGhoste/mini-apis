using BancoEmpanadas.DAO;
using BancoEmpanadas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoEmpanadas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {

        private readonly ClientesDao _cliente;

        public ClientesController(ClientesDao cliente)
        {
            _cliente = cliente;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            List<ClientesViewModel> clientes = new List<ClientesViewModel>();

            clientes = await _cliente.ObtenerClientes();

            if(clientes != null || clientes.Any())
            {
                return Ok(clientes);

            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> ObtenerClientePorId(int idCliente)
        {
            var resp = await _cliente.ObtenerClientePorId(idCliente);

            return Ok(resp);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearCliente([FromBody] ClientesViewModel cliente)
        {
            var resp = await _cliente.CrearCliente(cliente);

            if(resp != null)
            {
                return Ok(resp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("actualizar/{idCliente}")]
        public async Task<IActionResult> ActualizarCliente(int idCliente, [FromBody] ClientesViewModel cliente)
        {
            var resp = await _cliente.ActualizarCliente(idCliente, cliente);

            if (resp != null)
            {
                return Ok(resp);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("eliminar/{idCliente}")]
        public async Task<IActionResult> EliminarCliente(int idCliente)
        {
            var resp = await _cliente.EliminarCliente(idCliente);

            return Ok(resp);

        }

    }
}
