using Demo.Backend.Endpoints;
using Demo.Backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7018").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services.AddTransient<IPersonRepository, PersonInMemoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("blazorfrontend"); // stuurt allow-access-control header terug

app.MapPersonEndpoints();


app.Run();