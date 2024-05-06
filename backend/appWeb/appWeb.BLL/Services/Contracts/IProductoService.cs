using appWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWeb.BLL.Services.Contracts
{
    public interface IProductoService
    {
        Task<IQueryable<Producto>> ObtenerTodo();
        Task<Producto> Buscar(int id);
        Task<bool> Registrar(Producto model);
        Task<bool> Modificar(int id, Producto model);
        Task<bool> Eliminar(int id);
        Task<Producto> ObtenerPorNombre(string nombreProducto);
    }
}
