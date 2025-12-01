using GraphQL.Types;

namespace GraphQL_graphQl.NET.GraphQL.Queries
{
    public class AppQuery:ObjectGraphType
    {
        public AppQuery()
        {
            Field<StringGraphType>("hello").Resolve(context => "Hello from GraphQL.NET");
        }
    }
}
