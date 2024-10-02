using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Repositories;

public interface IProductPricingRepository
{
    Task<ProductPricingModel> GetProductPricingByIdAsync(int id);
}