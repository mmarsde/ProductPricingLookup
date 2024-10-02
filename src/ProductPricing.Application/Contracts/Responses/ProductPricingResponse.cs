namespace ProductPricing.Application.Contracts.Responses;

public class ProductPricingResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal CurrentPrice { get; set; }
    public required DateTime LastUpdatedDateTime { get; set; }
    public IEnumerable<PriceResponse> PriceHistory { get; set; } = Enumerable.Empty<PriceResponse>();
}