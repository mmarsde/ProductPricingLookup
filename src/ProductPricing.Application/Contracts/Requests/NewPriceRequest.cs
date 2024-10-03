namespace ProductPricing.Application.Contracts.Requests;

public class NewPriceRequest
{
    public int Id { get; init; }
    public decimal NewPrice { get; init; }
    public DateTime LastUpdated { get; init; }
}