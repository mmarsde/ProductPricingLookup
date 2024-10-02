namespace ProductPricing.Application.Contracts.Responses;

public class PriceResponse
{
    public required decimal Price { get; set; }
    public required DateTime CreateDateTime { get; set; }
}