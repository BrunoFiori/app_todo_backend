using App_Todo_Backend.Data;

namespace App_Todo_Backend.Contract.Todo
{
    public interface ITodoRepository : IGenericRepository<Data.Todo>
    {
    }
}
