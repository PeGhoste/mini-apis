using Azure.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using PruebaInventario.Dao;
using PruebaInventario.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly ProductosDao _prod;

        public ProductosController(ProductosDao prod)
        {
            _prod = prod;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductos(){

            List<ProductosViewModel> productos = new List<ProductosViewModel>();

            productos = await _prod.ObtenerProductos();

            if(productos != null && productos.Count > 0)
            {
                return Ok(productos);
            }

            return NotFound();
        }


        // GET: api/<ProductosController>
        [HttpGet("{idProducto}")]
        public async Task<IActionResult> ObtenerProductoPorId(int idProducto)
        {
            var producto = await _prod.ObtenerProductoPorId(idProducto);

            if(producto != null)
            {
                return Ok(producto);
            }

            return NotFound();

        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] ProductosViewModel prod)
        {

            var productoExiste = await _prod.ObtenerProductoPorId(prod.IdProducto);

            if(productoExiste == null)
            {
                await _prod.CrearProducto(prod);
                return Ok(prod);
            }

            return NotFound();

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{idProducto}")]
        public async Task<IActionResult> ActualizarProducto(int idProducto, [FromBody] ProductosViewModel prod)
        {

            var resp = await _prod.ActualizarProducto(idProducto, prod);

            if(resp != null)
            {
                return Ok(resp);
            }

            return NotFound();


        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{idProducto}")]
        public async Task<IActionResult> EliminarProducto(int idProducto)
        {
            var resp = await _prod.EliminarProducto(idProducto);
        
            if(resp == true)
            {
                return Ok();
            }

            return NotFound();


        }
    }
}
