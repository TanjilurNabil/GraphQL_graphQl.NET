using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQL_graphQl.NET.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add GraphQL services
builder.Services.AddSingleton<ISchema, AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)));

//Add GraphQL server
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//Enable GraphQl Endpoint
app.UseGraphQL<ISchema>("/graphql");

//Enable GraphQL UI
app.UseGraphQLGraphiQL("/ui/graphiql");

//Map default controller route
//app.MapControllers();

app.UseHttpsRedirection();



app.Run();


