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

        public List<ProductsViewModel> ObtenerProducto(int Id)
        {

            // Creamos una lista para retornar un producto específico
            List<ProductsViewModel> lista = new List<ProductsViewModel>();

            // Agregamos el producto a la lista, si no existe retorna un nuevo producto
            lista.Add(ProductsList.FirstOrDefault(p => p.Id == Id) ?? new ProductsViewModel());
            return lista;
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
            try
            {
                // Buscamos el producto a actualizar y validamos que exista
                var productToUpdate = ProductsList.FirstOrDefault(p => p.Id == product.Id);
                if (productToUpdate != null)
                {
                    // Actualizamos los campos del producto
                    productToUpdate.Name = product.Name;
                    productToUpdate.Description = product.Description;
                    productToUpdate.Price = product.Price;
                    productToUpdate.Stock = product.Stock;
                    productToUpdate.Category = product.Category;

                    // Retornamos 0 para indicar que se actualizó correctamente
                    return 0;
                }

                // Retornamos 1 en caso de que no se haya encontrado el producto
                return 1;
            }
            catch
            {
                // Mandamos un throw para que el llamador maneje la excepción
                throw;
            }
        }

        // Método para eliminar un producto
        public int EliminarProducto(int id){

            try
            {
                // Buscamos el producto a eliminar y validamos que exista
                var productToDelete = ProductsList.FirstOrDefault(p => p.Id == id);

                // Si el producto existe, lo eliminamos
                if (productToDelete != null)
                {
                    ProductsList.Remove(productToDelete);

                    // Retornamos 0 para indicar que se eliminó correctamente
                    return 0;
                }

                // Retornamos 1 en caso de que no se haya encontrado el producto
                return 1;
            }
            catch
            {
                // Mandamos un throw para que el llamador maneje la excepción
                // Así en caso de que cuando consuman la API, puedan manejarla
                // de la manera que consideren oportuna
                throw;
            }


        }


    }
}
