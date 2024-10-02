using Microsoft.Extensions.DependencyInjection;
using ProductPricing.Application.Repositories;
using ProductPricing.Application.Services;

namespace ProductPricing.Application.Extensions;

public static class ProductPricingApplicationExtensions
{
    public static IServiceCollection AddProductPricingApplication(this IServiceCollection services)
    {
        services.AddSingleton<IProductPricingRepository, ProductPricingRepository>();
        services.AddSingleton<IProductPricingService, ProductPricingService>();
        return services;
    }
}