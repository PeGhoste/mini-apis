using Inventariado.DAO;
using Inventariado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventariado.Controllers
{
    // Definimos que la ruta se llamará /api/products
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        // Creamos una variable de tipo readonly para inyectar la dependencia del DAO
        // readonly significa que solo se puede asignar una vez, en el constructor y
        // sirve para evitar que se modifique la variable después de su inicialización
        private readonly ProductsDao _productsDao;

        // Constructor que recibe la dependencia del DAO
        public ProductsController(ProductsDao productsDao)
        {
            _productsDao = productsDao;
        }

        // GET: ProductsController/AllProducts
        [HttpGet("all")] // Redefinimos la ruta para obtener todos los productos, ahora es /api/products/all
        public ActionResult<List<ProductsViewModel>> AllProducts()
        {
            var products = _productsDao.ObtenerProductos();

            return products;
        }

        // GET: Products
        [HttpGet("{id}")]
        public ActionResult<List<ProductsViewModel>> Product(int id)
        {
            var product = _productsDao.ObtenerProducto(id);

            return product;
        }



    }
}
