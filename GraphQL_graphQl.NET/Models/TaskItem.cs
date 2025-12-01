namespace GraphQL_graphQl.NET.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public bool IsCompleted { get; set; }
        //Foreign Key
        public int ProjectId { get; set; }
        public Project Project { get; set; } = default!;
        public int? AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }
    }
}
