namespace ProductPricing.Application.Contracts.Responses;

public class ProductPricingResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal CurrentPrice { get; init; }
    public required DateTime LastUpdatedDateTime { get; init; }
    public IEnumerable<PriceResponse> PriceHistory { get; init; } = Enumerable.Empty<PriceResponse>();
}