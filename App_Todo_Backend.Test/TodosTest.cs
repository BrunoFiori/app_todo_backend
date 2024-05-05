using App_Todo_Backend.Core.Models;
using App_Todo_Backend.Core.Services;
using App_Todo_Backend.Data.Contract;
using App_Todo_Backend.Data.Models;
using AutoMapper;
using Moq;
using NUnit.Framework;

namespace App_Todo_Backend.Test
{
    [TestFixture]
    public class TodosTest
    {
        private ServiceTodo _serviceTodo;
        private readonly Mock<IRepositoryTodo> _mockRepositoryTodo = new Mock<IRepositoryTodo>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [SetUp]
        public void SetUp()
        {           
            _serviceTodo = new ServiceTodo(_mockRepositoryTodo.Object, _mockMapper.Object);
        }

        [Test]
        public async Task ListAllAsync_ShouldReturnListOfOutputTodo()
        {
            // Arrange
            var inputTodos = new List<Todo>
            {
                new Todo { Id = 1, Title = "Todo 1", Description = "Description 1" },
                new Todo { Id = 2, Title = "Todo 2", Description = "Description 2" },
                new Todo { Id = 3, Title = "Todo 3", Description = "Description 3" }
            };
            var expectedOutputTodos = new List<OutputTodo>
            {
                new OutputTodo { Id = 1, Title = "Todo 1", Description = "Description 1" },
                new OutputTodo { Id = 2, Title = "Todo 2", Description = "Description 2" },
                new OutputTodo { Id = 3, Title = "Todo 3", Description = "Description 3" }
            };

            _mockRepositoryTodo.Setup(repo => repo.ListAllAsync()).ReturnsAsync(inputTodos);
            _mockMapper.Setup(mapper => mapper.Map<List<OutputTodo>>(inputTodos)).Returns(expectedOutputTodos);

            // Act
            var result = await _serviceTodo.ListAllAsync();

            // Assert
            Assert.Equals(expectedOutputTodos, result);
        }

        [Test]
        public async Task ListAllPagedAsync_ShouldReturnPagedResultOfOutputTodo()
        {
            // Arrange
            
            var inputTodos = new PagedResult<Todo>
            {
                TotalCount = 3,
                PageNumber = 1,
                RecordNumber = 5,
                Items = new List<Todo>
                {
                    new Todo { Id = 1, Title = "Todo 1", Description = "Description 1" },
                    new Todo { Id = 2, Title = "Todo 2", Description = "Description 2" },
                    new Todo { Id = 3, Title = "Todo 3", Description = "Description 3" }
                }
            };
            var expectedOutputTodos = new List<OutputTodo>
            {
                new OutputTodo { Id = 1, Title = "Todo 1", Description = "Description 1" },
                new OutputTodo { Id = 2, Title = "Todo 2", Description = "Description 2" },
                new OutputTodo { Id = 3, Title = "Todo 3", Description = "Description 3" }
            };
            var expectedPagedResult = new PagedResult<OutputTodo>(3, 1, 5, expectedOutputTodos);

            _mockRepositoryTodo.Setup(repo => repo.ListAllPagedAsync<Todo>(It.IsAny<QueryParameters>())).ReturnsAsync(inputTodos);
            _mockMapper.Setup(mapper => mapper.Map<PagedResult<OutputTodo>>(inputTodos)).Returns(expectedPagedResult);

            // Act
            var result = await _serviceTodo.ListAllPagedAsync(It.IsAny<QueryParameters>());

            // Assert
            Assert.Equals(expectedPagedResult, result);
        }
    }
}
