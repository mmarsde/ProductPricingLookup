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
            PriceHistory = productPricingModel.PriceHistory.Select(MapToPriceResponse)
        };
    }
    
    public static ProductsResponse MapToProductsResponse(this IEnumerable<ProductPricingModel> productPricingModels)
    {
        return new ProductsResponse
        {
            Products = productPricingModels.Select(MapToProductResponse)
        };
    }

    public static DiscountResponse MapToDiscountResponse(this ProductPricingModel productPricingModel, decimal discountPrice)
    {
        return new DiscountResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            OriginalPrice = productPricingModel.CurrentPrice,
            DiscountedPrice = discountPrice
        };
    }

    public static NewPriceResponse MapToNewPriceResponse(this ProductPricingModel productPricingModel)
    {
        return new NewPriceResponse
        {
            Id = productPricingModel.Id,
            Name = productPricingModel.Name,
            LastUpdated = productPricingModel.LastUpdated,
            NewPrice = productPricingModel.CurrentPrice
        };
    }
    
    private static ProductResponse MapToProductResponse(this ProductPricingModel productPricingModel)
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