using Microsoft.Extensions.DependencyInjection;
using ProductPricing.Application.Repositories;
using ProductPricing.Application.Services;

namespace ProductPricing.Application.Extensions;

public static class ProductPricingApplicationExtensions
{
    public static IServiceCollection AddProductPricingApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductPricingRepository, ProductPricingRepository>();
        services.AddScoped<IProductPricingService, ProductPricingService>();
        return services;
    }
}