namespace miniCRM
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string Email { get; init; }
        public DateTime CreatedAt { get; init; }

        public Client(int id, string name, string email, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} <{Email}> ({CreatedAt})";
        }
    }
}
