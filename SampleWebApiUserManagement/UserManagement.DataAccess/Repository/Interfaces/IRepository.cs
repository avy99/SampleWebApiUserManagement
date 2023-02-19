using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();

        Task Add(T entity);
    }
}