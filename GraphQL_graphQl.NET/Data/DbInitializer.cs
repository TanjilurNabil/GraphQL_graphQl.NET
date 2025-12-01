using GraphQL_graphQl.NET.Models;

namespace GraphQL_graphQl.NET.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;

        public DbInitializer(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            if (_context.Database.EnsureCreated())
            {
                Console.WriteLine("Database Created");
            }

            if (!_context.Users.Any())
            {
                // Original user and project
                var user1 = new User { Name = "Nabil" };
                await _context.Users.AddAsync(user1);

                var project1 = new Project
                {
                    Title = "Demo Project",
                    Owner = user1
                };
                await _context.Projects.AddAsync(project1);

                _context.Tasks.Add(new TaskItem
                {
                    Title = "Setup GraphQL",
                    Project = project1,
                    AssignedUser = user1,
                    IsCompleted = false
                });

                // Additional users
                var user2 = new User { Name = "Alice" };
                var user3 = new User { Name = "Bob" };
                await _context.Users.AddRangeAsync(user2, user3);

                // Additional projects
                var project2 = new Project
                {
                    Title = "Website Redesign",
                    Owner = user2
                };
                var project3 = new Project
                {
                    Title = "Mobile App Development",
                    Owner = user3
                };
                await _context.Projects.AddRangeAsync(project2, project3);

                // Additional tasks
                _context.Tasks.AddRange(
                    new TaskItem
                    {
                        Title = "Create Wireframes",
                        Project = project2,
                        AssignedUser = user2,
                        IsCompleted = false
                    },
                    new TaskItem
                    {
                        Title = "Develop Backend API",
                        Project = project3,
                        AssignedUser = user3,
                        IsCompleted = false
                    },
                    new TaskItem
                    {
                        Title = "Testing and QA",
                        Project = project3,
                        AssignedUser = user1,
                        IsCompleted = false
                    }
                );

                await _context.SaveChangesAsync();
            }
        }
    }
}
