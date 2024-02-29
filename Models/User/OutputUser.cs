using App_Todo_Backend.Models.Todo;

namespace App_Todo_Backend.Models.User
{
    public class OutputUser : BaseUserDto
    {
        public int Id { get; set; }
        public virtual IList<OutputTodo> Todos { get; set; }
    }
}
