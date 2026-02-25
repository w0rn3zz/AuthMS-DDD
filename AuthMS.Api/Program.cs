using AuthMS.Api.Extensions;
using AuthMS.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplicationServices()
    .AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCustomExceptionsHandler();
app.UseHttpsRedirection();

app.MapAuthEndpoints();

app.Run();