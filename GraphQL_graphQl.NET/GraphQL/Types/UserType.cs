using GraphQL.Types;
using GraphQL_graphQl.NET.Models;

namespace GraphQL_graphQl.NET.GraphQL.Types
{
    public class UserType:ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Name);

            //Navigation
            Field<ListGraphType<ProjectType>>("projects").Resolve(context=>context.Source.Projects);
            Field<ListGraphType<TaskItemType>>("assignedTasks").Resolve(context => context.Source.AssignedTasks);
        }
    }
}
