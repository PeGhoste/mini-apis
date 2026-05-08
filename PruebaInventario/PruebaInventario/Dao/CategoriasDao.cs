using Microsoft.EntityFrameworkCore;
using PruebaInventario.Data;
using PruebaInventario.Models;

namespace PruebaInventario.Dao
{
    public class CategoriasDao
    {

        private readonly AppDbContext _context;

        public CategoriasDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriasViewModel>> ObtenerCategorias()
        {
            return await _context.categorias.ToListAsync();
        }

        public async Task<CategoriasViewModel> ObtenerCategoriaPorId(int idCategoria)
        {
            return await _context.categorias.FindAsync(idCategoria);
        }

        public async Task<CategoriasViewModel> CrearCategoria(CategoriasViewModel categoria)
        {
            _context.categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }

        public async Task<CategoriasViewModel> ActualizarCategoria(int idCategoria, CategoriasViewModel categoria)
        {
            var categoriaExiste = await _context.categorias.FindAsync(idCategoria);
            if (categoriaExiste != null)
            {

                categoriaExiste.Categoria = categoria.Categoria;
                categoriaExiste.Descripcion = categoria.Descripcion;
                categoriaExiste.Estado = categoria.Estado;

                await _context.SaveChangesAsync();
                return categoriaExiste;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> EliminarCategoria(int idCategoria)
        {
            var categoriaExiste = await _context.categorias.FindAsync(idCategoria);
            if (categoriaExiste != null)
            {
                _context.categorias.Remove(categoriaExiste);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }




    }
}
