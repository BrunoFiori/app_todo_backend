using App_Todo_Backend.Core.Contract;
using App_Todo_Backend.Core.Models;
using App_Todo_Backend.Data.Contract;
using App_Todo_Backend.Data.Models;
using AutoMapper;

namespace App_Todo_Backend.Core.Services
{
    public class ServiceTodo : IServiceTodo
    {
        private readonly IRepositoryTodo _repositoryTodo;
        private readonly IMapper _mapper;

        public ServiceTodo(IRepositoryTodo repositoryTodo, IMapper mapper )
        {
            _mapper = mapper;
            _repositoryTodo = repositoryTodo;
        }

        public async Task<List<OutputTodo>> ListAllAsync()
        {
            var result = await _repositoryTodo.ListAllAsync();
            return _mapper.Map<List<OutputTodo>>(result);
        }

        public async Task<PagedResult<OutputTodo>> ListAllPagedAsync(QueryParameters queryParameters)
        {
            var result = await _repositoryTodo.ListAllPagedAsync<Todo>(queryParameters);
            return _mapper.Map<PagedResult<OutputTodo>>(result);
        }
    }
}
