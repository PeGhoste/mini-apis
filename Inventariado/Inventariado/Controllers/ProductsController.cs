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

        // GET: ProductsController/Product
        [HttpGet("{id}")] // api/products/product/1
        public ActionResult<List<ProductsViewModel>> Product(int id)
        {
            var product = _productsDao.ObtenerProducto(id);

            return product;
        }


        // POST: ProductsController/CreateProduct
        [HttpPost] // api/products/createproduct
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductsViewModel product)
        {
             _productsDao.AgregarProducto(product);

            return Ok();
        }

        // PUT: ProductsController/UpdateProduct
        [HttpPut] // api/products/updateproduct
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductsViewModel product)
        {
             _productsDao.ActualizarProducto(product);

            return Ok();
        }

        // DELETE: ProductsController/DeleteProduct
        [HttpDelete] // api/products/deleteproduct
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
             _productsDao.EliminarProducto(id);

            return Ok();
        }


    }
}
