using AuthMS.Api.Extensions;
using AuthMS.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplicationServices()
    .AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseCustomExceptionsHandler();
app.UseHttpsRedirection();

app.MapAuthEndpoints();

app.Run();