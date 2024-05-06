using appWeb.DAL.DataContext;
using appWeb.DAL.Repositories.Contracts;
using appWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWeb.DAL.Repositories
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly DbTienda2Context _context;

        public ProductoRepository(DbTienda2Context context)
        {
            _context = context;
        }

        public async Task<Producto> Buscar(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var model = await _context.Productos.FindAsync(id);

            if (model == null)
                return false;

            _context.Productos.Remove(model);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Modificar(int id, Producto model)
        {
            if(id != model.Idproducto)
                return false;

            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
                return false;

            model.Fecharegistro = producto.Fecharegistro;

            _context.Entry(producto).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Producto>> ObtenerTodo()
        {
            return _context.Productos;
        }

        public async Task<bool> Registrar(Producto model)
        {
            await _context.Productos.AddAsync(model);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
