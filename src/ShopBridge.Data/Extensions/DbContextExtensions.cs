using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Data;

namespace System;
public static class DbContextExtensions
{
    public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShopBridgeContext>(options => options.UseSqlServer(configuration.GetConnectionString(GlobalConstants.DefaultDbContextName)));

        return services;
    }
}
