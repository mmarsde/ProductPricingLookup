using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Repositories;

namespace ProductPricing.Application.Services;

public class ProductPricingService : IProductPricingService
{
    private readonly IProductPricingRepository _productPricingRepository;
    
    public ProductPricingService(IProductPricingRepository productPricingRepository)
    {
        _productPricingRepository = productPricingRepository;
    }
    
    public async Task<ProductPricingResponse> GetProductPricingByIdAsync(int id)
    {
        var productPricingModel = await _productPricingRepository.GetProductPricingByIdAsync(id);

        if (productPricingModel == null)
        {
            return null;
        }

        return new ProductPricingResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            LastUpdatedDateTime = productPricingModel.LastUpdated,
            CurrentPrice = productPricingModel.CurrentPrice,
            PriceHistory = productPricingModel.PriceHistory.Select(ph => new PriceResponse
                { Price = ph.Price, CreateDateTime = ph.CreateDateTime }).ToList() 
        };
    }
    
}