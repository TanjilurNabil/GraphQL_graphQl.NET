using GraphQL.Types;
using GraphQL_graphQl.NET.Data;
using GraphQL_graphQl.NET.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_graphQl.NET.GraphQL.Queries
{
    public class AppQuery:ObjectGraphType
    {
        public AppQuery(AppDbContext dbContext)
        {
            Name = "Query";
            Field<StringGraphType>("hello").Resolve(context => "Hello from GraphQL.NET");

            Field<ListGraphType<UserType>>("users").Resolve(context => dbContext.Users
            .Include(p => p.Projects)
            .Include(p => p.AssignedTasks)
            .ToList());

            Field<ListGraphType<ProjectType>>("projects").Resolve(context => dbContext.Projects
            .Include(u => u.Owner)
            .Include(u => u.Tasks)
            .ToList());

            Field<ListGraphType<TaskItemType>>("tasks").Resolve(context=>dbContext.Tasks
            .Include(o=>o.Project)
            .Include(o=>o.AssignedUser)
            .ToList());
        }
    }
}
