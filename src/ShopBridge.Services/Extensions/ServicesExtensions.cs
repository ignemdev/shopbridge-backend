using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Core.Services;
using ShopBridge.Services;

namespace System;
public static class ServicesExtensions
{
    public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryServices, CategoryServices>();
        services.AddTransient<IProductServices, ProductServices>();

        return services;
    }
}
