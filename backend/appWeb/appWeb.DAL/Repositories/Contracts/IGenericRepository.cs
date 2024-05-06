using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appWeb.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<IQueryable<TEntityModel>> ObtenerTodo();
        Task<TEntityModel> Buscar(int id);
        Task<bool> Registrar(TEntityModel model);
        Task<bool> Modificar(int id, TEntityModel model);
        Task<bool> Eliminar(int id);
    }
}
