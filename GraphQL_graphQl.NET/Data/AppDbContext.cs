using GraphQL_graphQl.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GraphQL_graphQl.NET.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        
    }
}
