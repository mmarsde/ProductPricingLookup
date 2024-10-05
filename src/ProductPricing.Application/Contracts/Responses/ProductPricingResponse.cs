namespace ProductPricing.Application.Contracts.Responses;

public class ProductPricingResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public IEnumerable<PriceResponse> PriceHistory { get; init; } = Enumerable.Empty<PriceResponse>();
}