namespace ProductPricing.Application.Models.Domain;

public class ProductPricingModel
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required decimal CurrentPrice { get; set; }
    public required DateTime LastUpdated { get; set; }
    public IEnumerable<PriceModel> PriceHistory { get; set; } = Enumerable.Empty<PriceModel>();
}