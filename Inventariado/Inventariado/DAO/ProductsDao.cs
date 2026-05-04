using Inventariado.Models;

namespace Inventariado.DAO
{
    public class ProductsDao
    {

        // Creamos una lista dinamica
        private List<ProductsViewModel> ProductsList = new List<ProductsViewModel>()
        {
            new ProductsViewModel()
            {
                Id=1,
                Name="Producto 1",
                Description="Descripción del producto 1",
                Price=10.99m,
                Stock=100,
                Category="Categoría A"
            }
        };

        // Método para obtener todos los productos
        public List<ProductsViewModel> ObtenerProductos()
        {
            return ProductsList;
        }

        // Método para agregar un nuevo producto
        public int AgregarProducto(ProductsViewModel product)
        {
            ProductsList.Add(product);
            return ProductsList.Count;
        }

        // Método para actualizar un producto
        public int ActualizarProducto(ProductsViewModel product)
        {
            var productToUpdate = ProductsList.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.Stock = product.Stock;
                productToUpdate.Category = product.Category;
            }
            return ProductsList.Count;
        }


    }
}
