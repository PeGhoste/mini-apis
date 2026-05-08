using Microsoft.EntityFrameworkCore;
using PruebaInventario.Data;
using PruebaInventario.Models;

namespace PruebaInventario.Dao
{
    public class ProductosDao
    {
        private readonly AppDbContext _context;

        public ProductosDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductosViewModel>> ObtenerProductos()
        {
            return await _context.productos.ToListAsync();
        }

        public async Task<ProductosViewModel> ObtenerProductoPorId(int idProducto)
        {
            return await _context.productos.FindAsync(idProducto);
        }

        public async Task<ProductosViewModel> CrearProducto(ProductosViewModel producto)
        {
            _context.productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<ProductosViewModel> ActualizarProducto(int idProducto, ProductosViewModel producto)
        {
            var productoExiste = await _context.productos.FindAsync(idProducto);
            if(productoExiste != null)
            {
                productoExiste.Nombre = producto.Nombre;
                productoExiste.Descripcion = producto.Descripcion;
                productoExiste.Stock = producto.Stock;
                productoExiste.fecha = producto.fecha;
                productoExiste.Estado = producto.Estado;
                productoExiste.FK_IdCategoria = producto.FK_IdCategoria;
                await _context.SaveChangesAsync();
                return producto;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> EliminarProducto(int idProducto)
        {
            var productoExiste = await _context.productos.FindAsync(idProducto);
            if(productoExiste != null)
            {
                _context.productos.Remove(productoExiste);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

    }
}
