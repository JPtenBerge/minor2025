using Insta.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("blazorfrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:7295").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("blazorfrontend");

app.MapCommentEndpoints();

app.Run();