using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Services;

public class ProductPricingService : IProductPricingService
{
    private readonly IEnumerable<ProductPricingModel> _productPrices =
    [
        new()
        {
            Id = 1,
            Name = "Product A",
            CurrentPrice = 100.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new()
        {
            Id = 2,
            Name = "Product B",
            CurrentPrice = 110.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new()
        {
            Id = 3,
            Name = "Product C",
            CurrentPrice = 120.0M,
            LastUpdated = DateTime.UtcNow,
        },
        new()
        {
            Id = 5,
            Name = "Product E",
            CurrentPrice = 130.0M,
            LastUpdated = DateTime.UtcNow,
        }
    ];
    
    public bool CheckProductExists(int id)
    {
        return _productPrices.Any(p => p.Id == id);
    }
}