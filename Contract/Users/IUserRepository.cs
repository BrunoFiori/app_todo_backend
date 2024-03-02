using App_Todo_Backend.Data;

namespace App_Todo_Backend.Contract.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetTodos(int id);
    }
}
