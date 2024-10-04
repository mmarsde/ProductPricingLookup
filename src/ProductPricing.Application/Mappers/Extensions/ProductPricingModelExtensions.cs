using ProductPricing.Application.Contracts.Responses;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Mappers.Extensions;

public static class ProductPricingModelExtensions
{
    public static ProductPricingResponse MapToProductPricingResponse(this ProductPricingModel productPricingModel)
    {
        return new ProductPricingResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            LastUpdatedDateTime = productPricingModel.LastUpdated,
            CurrentPrice = productPricingModel.CurrentPrice,
            PriceHistory = productPricingModel.PriceHistory.Select(MapToPriceResponse).ToList() 
        };
    }
    
    public static ProductsResponse MapToProductsResponse(this IEnumerable<ProductPricingModel> productPricingModels)
    {
        return new ProductsResponse
        {
            Products = productPricingModels.Select(MapToPriceResponse)
        };
    }

    private static ProductResponse MapToPriceResponse(this ProductPricingModel productPricingModel)
    {
        return new ProductResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            CurrentPrice = productPricingModel.CurrentPrice,
            LastUpdatedDateTime = productPricingModel.LastUpdated
        };
    }

    private static PriceResponse MapToPriceResponse(PriceModel priceModel)
    {
        return new PriceResponse
        {
            Price = priceModel.Price,
            CreateDateTime = priceModel.CreateDateTime
        };
    }
}