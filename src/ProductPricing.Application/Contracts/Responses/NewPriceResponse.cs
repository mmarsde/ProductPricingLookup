namespace ProductPricing.Application.Contracts.Responses;

public class NewPriceResponse : ProductResponse
{
    public decimal NewPrice { get; init; }
}