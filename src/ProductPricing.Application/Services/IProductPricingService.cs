using System.Data.Common;
using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Services;

public interface IProductPricingService
{
    Task<ProductsResponse> GetAllProductsAsync();
    Task<ProductPricingResponse> GetProductPricingByIdAsync(int id);
    Task<DiscountResponse> ApplyDiscountAsync(int id, DiscountRequest request);
    Task<NewPriceResponse> UpdatePriceAsync(int id,  PriceModel priceModel);
}