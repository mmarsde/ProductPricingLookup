namespace ProductPricing.Application.Contracts.Responses;

public class ProductResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public decimal CurrentPrice { get; init; }
    public DateTime LastUpdatedDateTime { get; init; }
}