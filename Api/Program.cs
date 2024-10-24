using read_cloud.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .BuildDependencies(builder.Configuration)
    .BuildControllers()
    .BuildAuthentication(builder);

var app = builder.Build();

app.MapHealthChecks("/");

app.Configure();
app.Run();
