using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Contracts.Responses;

namespace ProductPricing.Application.Services;

public interface IProductPricingService
{
    Task<ProductsResponse> GetAllProductsAsync();
    Task<ProductPricingResponse> GetProductPricingByIdAsync(int id);
    Task<DiscountResponse> ApplyDiscountAsync(int id, DiscountRequest request);
}