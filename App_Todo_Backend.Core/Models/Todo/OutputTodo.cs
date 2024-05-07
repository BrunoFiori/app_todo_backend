
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Todo_Backend.Core.Models
{
    public class OutputTodo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}