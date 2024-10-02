namespace ProductPricing.Application.Contracts.Responses;

public class ProductsResponse
{
    public IEnumerable<ProductResponse> Products { get; set; } = Enumerable.Empty<ProductResponse>();
}