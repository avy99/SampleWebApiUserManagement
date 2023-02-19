using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement.DataAccess.Data;
using UserManagement.Model.Models;

namespace UserManagement.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Update(User user)
        {
            var obj = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (obj != null)
            {
                obj.Role = user.Role;
                obj.Email = user.Email;
                obj.Name = user.Name;
                obj.Phone = user.Phone;
                obj.Password = user.Password;
                _dbContext.Update(obj);
            }
        }

        public async Task<User> Get(string Id)
        {
            return await _dbContext.Users.FindAsync(Id);
        }
    }
}