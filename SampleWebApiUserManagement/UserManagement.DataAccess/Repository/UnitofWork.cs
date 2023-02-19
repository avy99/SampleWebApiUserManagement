using UserManagement.DataAccess.Data;

namespace UserManagement.DataAccess.Repository
{
    public class UnitofWork : IunitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;
            Users = new UserRepository(_db);
        }

        public IUserRepository Users { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}