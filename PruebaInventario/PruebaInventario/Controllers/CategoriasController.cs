using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaInventario.Dao;
using PruebaInventario.Models;

namespace PruebaInventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {

        private readonly CategoriasDao _categorias;

        public CategoriasController(CategoriasDao categorias)
        {
            _categorias = categorias;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCategorias()
        {
            List<CategoriasViewModel> categorias = new List<CategoriasViewModel>();

            categorias = await _categorias.ObtenerCategorias();

            if(categorias != null && categorias.Count > 0)
            {
                return Ok(categorias);
            }

            return NotFound("No se encontraron categorias");
        }

        [HttpGet("{idCategoria}")]
        public async Task<IActionResult> ObtenerCategoriaPorId(int idCategoria)
        {
            var categoria = await _categorias.ObtenerCategoriaPorId(idCategoria);

            if (categoria != null)
            {
                return Ok(categoria);
            }

            return NotFound("No se encontraron categorias");
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriasViewModel cat)
        {
            var res = await _categorias.CrearCategoria(cat);

            if (res != null)
            {
                return Ok();
            }

            return NotFound();

        }

        [HttpPut("{idCategoria}")]
        public async Task<IActionResult> Actualizar(int idCategoria, [FromBody] CategoriasViewModel cat)
        {
            var res = await _categorias.ActualizarCategoria(idCategoria, cat);

            if(res != null)
            {
                return Ok();
            }

            return NotFound();

        }


        // DELETE: CategoriasController/Delete/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var res = await _categorias.EliminarCategoria(id);

            if(res != null)
            {
                return Ok();
            }

            return NotFound();
        }

    }
}
