using ProductPricing.Application.Contracts.Requests;
using ProductPricing.Application.Models.Domain;

namespace ProductPricing.Application.Mappers.Extensions;

public static class NewPriceRequestExtensions
{
    public static PriceModel ToPriceModel(this NewPriceRequest request) => 
        new()
        {
            CreateDateTime = DateTime.UtcNow,
            Price = request.NewPrice
        };
}