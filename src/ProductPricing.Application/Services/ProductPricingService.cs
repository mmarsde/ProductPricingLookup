using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Mappers.Extensions;
using ProductPricing.Application.Models.Domain;
using ProductPricing.Application.Repositories;

namespace ProductPricing.Application.Services;

public class ProductPricingService : IProductPricingService
{
    private readonly IProductPricingRepository _productPricingRepository;
    
    public ProductPricingService(IProductPricingRepository productPricingRepository)
    {
        _productPricingRepository = productPricingRepository;
    }

    public async Task<ProductsResponse> GetAllProductsAsync()
    {
        var productPricingModels = await _productPricingRepository.GetAllProductsAsync();
        
        return productPricingModels?.MapToProductsResponse() ??
               new ProductsResponse(Enumerable.Empty<ProductResponse>());
    }

    public async Task<ProductPricingResponse> GetProductPricingByIdAsync(int id)
    {
        var productPricingModel = await _productPricingRepository.GetProductPricingByIdAsync(id);

        return productPricingModel?.MapToProductPricingResponse();
    }

    public async Task<DiscountResponse> ApplyDiscountAsync(int id, DiscountRequest request)
    {
        var productPricingModel = await _productPricingRepository.GetProductPricingByIdAsync(id);

        if (productPricingModel == null)
        {
            return null;
        }
        
        var discountPrice = CalculateDiscountPrice(request.DiscountPercentage, productPricingModel.CurrentPrice);

        return new DiscountResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            OriginalPrice = productPricingModel.CurrentPrice,
            DiscountedPrice = discountPrice
        };
    }

    public Task<NewPriceResponse> UpdatePriceAsync(PriceModel priceModel)
    {
        throw new NotImplementedException();
    }

    private static decimal CalculateDiscountPrice(int discountPercentage, decimal currentPrice)
    {
        var discountValue = discountPercentage / 100m;
        var discountPrice = currentPrice * (1m - discountValue);
        return Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
    }
}