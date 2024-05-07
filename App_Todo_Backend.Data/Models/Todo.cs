namespace App_Todo_Backend.Data.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
