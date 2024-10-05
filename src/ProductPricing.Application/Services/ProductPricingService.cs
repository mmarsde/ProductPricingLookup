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

        if (productPricingModel is null)
        {
            return null;
        }
        
        var discountPrice = CalculateDiscountPrice(request.DiscountPercentage, productPricingModel.CurrentPrice);
        
        return productPricingModel.MapToDiscountResponse(discountPrice);
    }
    
    public async Task<NewPriceResponse> UpdatePriceAsync(int id, PriceModel priceModel)
    {
        var productPricingModel = await _productPricingRepository.GetProductPricingByIdAsync(id);

        if (productPricingModel is null)
        {
            return null;
        }

        var priceHistory = UpdatePriceHistory(productPricingModel);
        var productPriceModel = UpdateProductPriceModel(priceModel, productPricingModel, priceHistory);
        await _productPricingRepository.UpdateProductPriceAsync(id, productPriceModel);
        
        return productPriceModel.MapToNewPriceResponse();
    }

    private static ProductPricingModel UpdateProductPriceModel(PriceModel priceModel, ProductPricingModel productPricingModel,
        IEnumerable<PriceModel> priceHistory)
    {
        productPricingModel.CurrentPrice = priceModel.Price;
        productPricingModel.LastUpdated = priceModel.CreateDateTime;
        productPricingModel.PriceHistory = priceHistory;
        return productPricingModel;
    }

    private static IEnumerable<PriceModel> UpdatePriceHistory(ProductPricingModel productPricingModel)
    {
        var priceHistory = productPricingModel.PriceHistory?.ToList() ?? [];
        var originalPrice = productPricingModel.CurrentPrice;
        var lastUpdated = productPricingModel.LastUpdated;
        priceHistory.Add(new PriceModel{ CreateDateTime = lastUpdated, Price = originalPrice });
        return priceHistory.OrderByDescending(x => x.CreateDateTime); 
    }
    
    private static decimal CalculateDiscountPrice(int discountPercentage, decimal currentPrice)
    {
        var discountValue = discountPercentage / 100m;
        var discountPrice = currentPrice * (1m - discountValue);
        return Math.Round(discountPrice, 2, MidpointRounding.AwayFromZero);
    }
}