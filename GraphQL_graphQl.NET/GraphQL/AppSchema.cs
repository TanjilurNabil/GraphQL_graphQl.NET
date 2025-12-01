using GraphQL.Types;
using GraphQL_graphQl.NET.GraphQL.Queries;

namespace GraphQL_graphQl.NET.GraphQL
{
    public class AppSchema:Schema
    {
        public AppSchema(IServiceProvider provider):base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            //Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
