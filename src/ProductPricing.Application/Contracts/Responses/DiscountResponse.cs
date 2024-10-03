namespace ProductPricing.Application.Contracts.Responses;

public class DiscountResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public decimal OriginalPrice { get; init; }
    public decimal DiscountedPrice { get; init; }
}