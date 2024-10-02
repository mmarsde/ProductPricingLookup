namespace ProductPricing.Application.Contracts.Responses;

public class ProductResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }
}