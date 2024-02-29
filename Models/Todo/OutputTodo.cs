using App_Todo_Backend.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Todo_Backend.Models.Todo
{
    public class OutputTodo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}