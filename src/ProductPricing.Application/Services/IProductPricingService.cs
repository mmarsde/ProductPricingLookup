using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Services;

public interface IProductPricingService
{
    Task<ProductPricingResponse> GetProductPricingByIdAsync(int id);
}