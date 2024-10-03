using ProductPricing.Application.Contracts.Requests;
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
        {
            return new ProductsResponse
            {
                Products = Enumerable.Empty<ProductResponse>()
            };   
        }
        
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

    public async Task<DiscountResponse> ApplyDiscountAsync(int id, DiscountRequest request)
    {
        if (!IsDiscountValid(request.DiscountPercentage))
        {
            throw new ArgumentException("Discount percentage must be between 1 and 100.", nameof(request)); 
        }
        
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

    private static decimal CalculateDiscountPrice(int discountPercentage, decimal currentPrice)
    {
        var discountValue = discountPercentage / 100m;
        var discountPrice = currentPrice * (1m - discountValue);
        return Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
    }

    private static bool IsDiscountValid(int discountPercentage)
    {
        return discountPercentage > 0 & discountPercentage <= 100;
    }
}