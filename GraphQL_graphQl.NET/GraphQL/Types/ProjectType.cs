using GraphQL.Types;
using GraphQL_graphQl.NET.Models;

namespace GraphQL_graphQl.NET.GraphQL.Types
{
    public class ProjectType:ObjectGraphType<Project>
    {
        public ProjectType()
        {
            Name = "Project";
            Field(x => x.Id);
            Field(x => x.Title);

            //Navigation
            Field<UserType>("owner").Resolve(context => context.Source.Owner);
            Field<ListGraphType<TaskItemType>>("tasks").Resolve(context => context.Source.Tasks);
        }
    }
}
