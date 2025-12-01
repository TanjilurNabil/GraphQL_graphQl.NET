namespace GraphQL_graphQl.NET.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;

        //Foreign Key
        public int OwnerId { get; set; }
        public User Owner { get; set; } = default!;
        //Navigation
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
