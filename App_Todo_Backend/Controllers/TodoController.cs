using App_Todo_Backend.Core.Contract;
using App_Todo_Backend.Data.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App_Todo_Backend.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TodoController : ControllerBase
    {
        public readonly IServiceTodo _serviceTodo;
        private readonly ILogger<AuthenticationController> _logger;

        public TodoController(IServiceTodo serviceTodo, ILogger<AuthenticationController> logger)
        {
            _serviceTodo = serviceTodo;
            _logger = logger;
        }

        [HttpGet("SemFiltro")]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceTodo.ListAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> Get([FromQuery] QueryParameters queryParameters)
        {
            var pagedTodoResult = await _serviceTodo.ListAllPagedAsync(queryParameters);
            return Ok(pagedTodoResult);
        }

    }
}
