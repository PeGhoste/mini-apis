using BancoEmpanadas.DAO;
using BancoEmpanadas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoEmpanadas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : Controller
    {

        private readonly CuentasDao _cuenta;

        public CuentasController(CuentasDao cuenta)
        {
            _cuenta = cuenta;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCuentas()
        {

            List<CuentasViewModel> cuentas = new List<CuentasViewModel>();

            cuentas = await _cuenta.ObtenerCuentas();

            return Ok(cuentas);

        }

        [HttpGet("{idCuenta}")]
        public async Task<IActionResult> ObtenerCuenta(int idCuenta)
        {
            var cuenta = await _cuenta.ObtenerCuentaPorId(idCuenta);

            return Ok(cuenta);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearCuenta([FromBody] CuentasViewModel cuenta)
        {

            var res = await _cuenta.CrearCuenta(cuenta);

            return Ok(res);

        }

        [HttpPut("actualizar/{idCuenta}")]
        public async Task<IActionResult> ActualizarCuenta(int idCuenta, [FromBody] CuentasViewModel cuenta)
        {

            var res = await _cuenta.ActualizarCuenta(idCuenta, cuenta);

            return Ok(res);

        }

        [HttpDelete("eliminar/{idCuenta}")]
        public async Task<IActionResult> EliminarCuenta(int idCuenta)
        {
            var res = await _cuenta.EliminarCuenta(idCuenta);

            return Ok(res);
        }






    }
}
