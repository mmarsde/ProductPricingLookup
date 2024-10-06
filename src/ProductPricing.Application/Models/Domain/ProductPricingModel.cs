namespace ProductPricing.Application.Models.Domain;

public class ProductPricingModel
{
    private IEnumerable<PriceModel> _priceHistory = Enumerable.Empty<PriceModel>();
    
    public int Id { get; init; }
    public required string Name { get; init; }
    public required decimal CurrentPrice { get; set; }
    public required DateTime LastUpdated { get; set; }

    public IEnumerable<PriceModel> PriceHistory
    {
        get => _priceHistory.OrderByDescending(x => x.CreateDateTime);
        set => _priceHistory = value;
    }
}