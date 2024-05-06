using appWeb.BLL.Services.Contracts;
using appWeb.DAL.Repositories.Contracts;
using appWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWeb.BLL.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _repository;

        public ProductoService(IGenericRepository<Producto> repository)
        {
            _repository = repository;
        }

        public async Task<Producto> Buscar(int id)
        {
            return await _repository.Buscar(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repository.Eliminar(id);
        }

        public async Task<bool> Modificar(int id, Producto model)
        {
            return await _repository.Modificar(id, model);
        }

        public async Task<Producto> ObtenerPorNombre(string nombreProducto)
        {
            var productoSQL = await _repository.ObtenerTodo();
            var producto = productoSQL.Where(p => p.Nombre == nombreProducto).FirstOrDefault();
            return producto;
        }

        public async Task<IQueryable<Producto>> ObtenerTodo()
        {
            return await _repository.ObtenerTodo();
        }

        public async Task<bool> Registrar(Producto model)
        {
            return await _repository.Registrar(model);
        }
    }
}
