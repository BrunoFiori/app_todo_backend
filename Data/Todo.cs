using System.ComponentModel.DataAnnotations.Schema;

namespace App_Todo_Backend.Data
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
