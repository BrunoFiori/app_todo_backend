using App_Todo_Backend.Core.Models;
using App_Todo_Backend.Data.Models;

namespace App_Todo_Backend.Core.Contract
{
    public interface IServiceTodo
    {
        public Task<List<OutputTodo>> ListAllAsync();
        public Task<PagedResult<OutputTodo>> ListAllPagedAsync(QueryParameters queryParameters);
    }
}
