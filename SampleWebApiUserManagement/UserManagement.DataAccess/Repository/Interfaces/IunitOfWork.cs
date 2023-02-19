namespace UserManagement.DataAccess.Repository
{
    public interface IunitOfWork
    {
        IUserRepository Users { get; }
        void Save();
    }
}