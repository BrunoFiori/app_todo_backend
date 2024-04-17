using App_Todo_Backend.Core.Contract.Todo;
using App_Todo_Backend.Core.Models.QueryParameters;
using App_Todo_Backend.Core.Models.Todo;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace App_Todo_Backend.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TodoController : ControllerBase
    {
        public readonly ITodoRepository _todoRepository;
        private readonly ILogger<AuthenticationController> _logger;

        public TodoController(ITodoRepository todoRepository, ILogger<AuthenticationController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        [HttpGet("SemFiltro")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> GetAll()
        {
            var result = await _todoRepository.ListAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> Get([FromQuery] QueryParameters queryParameters)
        {
            var pagedTodoResult = await _todoRepository.ListAllPagedAsync<OutputTodo>(queryParameters);
            return Ok(pagedTodoResult);
        }

    }
}
