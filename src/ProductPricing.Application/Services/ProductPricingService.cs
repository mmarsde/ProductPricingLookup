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

    public async Task<ProductsResponse> GetAllProductsAsync()
    {
        var productPricingModels = await _productPricingRepository.GetAllProductsAsync();
        
        if (productPricingModels == null)
            return new ProductsResponse
            {
                Products = Enumerable.Empty<ProductResponse>()
            };

        return new ProductsResponse
        {
            Products = productPricingModels.Select(x => new ProductResponse
                { Id = x.Id, Name = x.Name, CurrentPrice = x.CurrentPrice, LastUpdatedDateTime = x.LastUpdated })
        };
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