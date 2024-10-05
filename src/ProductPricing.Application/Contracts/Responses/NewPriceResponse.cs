namespace ProductPricing.Application.Contracts.Responses;

public class NewPriceResponse
{
    public int Id { get; init; }
    public decimal NewPrice { get; init; }
    public string Name { get; init; }
    public DateTime LastUpdated { get; init; }
}