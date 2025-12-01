using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQL_graphQl.NET.Data;
using GraphQL_graphQl.NET.GraphQL;
using GraphQL_graphQl.NET.GraphQL.Queries;
using GraphQL_graphQl.NET.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add GraphQL services
builder.Services.AddTransient<AppQuery>();
builder.Services.AddTransient<ISchema, AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddTransient<UserType>();
builder.Services.AddTransient<ProjectType>();
builder.Services.AddTransient<TaskItemType>();
//Add GraphQL server
builder.Services.AddGraphQL(options =>
{
    options.AddSystemTextJson();
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<DbInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Enable GraphQl Endpoint
app.UseGraphQL<ISchema>("/graphql");

//Enable GraphQL UI
app.UseGraphQLGraphiQL("/ui/graphiql");

//Map default controller route
//app.MapControllers();

app.UseHttpsRedirection();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
        await dbInitializer.InitializeAsync();
    }
}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}


app.Run();