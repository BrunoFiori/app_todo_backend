namespace App_Todo_Backend.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Avatar { get; set; }
        public virtual IList<Todo> Todos { get; set; }
    }
}