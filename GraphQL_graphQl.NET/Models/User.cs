namespace GraphQL_graphQl.NET.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        //Navigation
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
    }
}
