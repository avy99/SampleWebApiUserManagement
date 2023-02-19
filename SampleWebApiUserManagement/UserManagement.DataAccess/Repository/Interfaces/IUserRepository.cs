using System.Threading.Tasks;
using UserManagement.Model.Models;

namespace UserManagement.DataAccess.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(string Id);

        Task Update(User user);
    }
}