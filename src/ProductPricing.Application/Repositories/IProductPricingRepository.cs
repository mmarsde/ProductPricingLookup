using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Repositories;

public interface IProductPricingRepository
{
    Task<ProductPricingModel> GetProductPricingByIdAsync(int id);
    Task<IEnumerable<ProductPricingModel>> GetAllProductsAsync();
    
    Task<IEnumerable<ProductPricingModel>> UpdateProductPriceAsync(int productId, PriceModel originalPrice, PriceModel newPrice);
}