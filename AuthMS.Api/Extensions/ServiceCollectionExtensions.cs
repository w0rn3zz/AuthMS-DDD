using AuthMS.Application.Commands;
using AuthMS.Domain.Interfaces;
using AuthMS.Infrastructure.Data;
using AuthMS.Infrastructure.Repositories;
using AuthMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthMS.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));

        return services;
    }
}