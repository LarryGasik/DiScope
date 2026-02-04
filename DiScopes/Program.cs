using DiScopes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register SomeService with different lifetimes using keyed services
builder.Services.AddKeyedSingleton<IService, SomeService>("singleton");
builder.Services.AddKeyedScoped<IService, SomeService>("scoped");
builder.Services.AddKeyedTransient<IService, SomeService>("transient");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
