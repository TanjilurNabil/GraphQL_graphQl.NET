using GraphQL.Types;
using GraphQL_graphQl.NET.Models;

namespace GraphQL_graphQl.NET.GraphQL.Types
{
    public class TaskItemType:ObjectGraphType<TaskItem>
    {
        public TaskItemType()
        {
            Name = "Task";
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.IsCompleted);

            //Navigation
            Field<ProjectType>("project").Resolve(context=>context.Source.Project);
            Field<UserType>("assignedUser").Resolve(context=>context.Source.AssignedUser);
        }
    }
}
